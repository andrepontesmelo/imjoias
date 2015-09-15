using System;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Armazena as entidades recuperadas recentemente no banco de dados,
	/// para aumentar o desempenho do sistema.
	/// </summary>
	public sealed class CacheDb : IDisposable
	{
		/// <summary>
		/// Tamanho do cache.
		/// </summary>
        private const int tamanho = 5000;
		
		/// <summary>
		/// Lista da cache ordenada por validade.
		/// </summary>
		private List<CacheDbItem> listaCache;

		/// <summary>
		/// Tabela cache.
		/// </summary>
		private volatile Dictionary<CacheDbChave, CacheDbItem> hashCache;

		/// <summary>
		/// Métodos para recuperação de tipos.
		/// </summary>
		private MétodosRecuperação métodos;

        /// <summary>
        /// Temporizador para manutenção da cache.
        /// </summary>
        private Timer tmrManutenção;

		/// <summary>
		/// Constrói o cache.
		/// </summary>
		private CacheDb()
		{
			listaCache = new List<CacheDbItem>(tamanho);
			hashCache  = new Dictionary<CacheDbChave,CacheDbItem>(tamanho);
			métodos    = new MétodosRecuperação();

            tmrManutenção = new Timer(1000 * 60 * 5);
            tmrManutenção.AutoReset = true;
            tmrManutenção.Elapsed += new ElapsedEventHandler(EfetuarManutenção);
            tmrManutenção.Start();
		}

		#region Singleton

		/// <summary>
		/// Instância única da classe.
		/// </summary>
		private static CacheDb instância = new CacheDb();

		/// <summary>
		/// Obtém a instância única de CacheDb.
		/// </summary>
		public static CacheDb Instância
		{
			get { return instância; }
		}

		#endregion

		/// <summary>
		/// Obtém entidade do cache ou do banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <param name="parâmetros">Parâmetros para recuperação da entidade.</param>
		/// <returns>Entidade recuperada.</returns>
        public object ObterEntidade(Type tipo, params object[] parâmetros)
        {
            CacheDbItem item;
            CacheDbChave chave;
            bool emCache;
            DbManipulação entidade;

            chave = new CacheDbChave(tipo, parâmetros);
            int qtd;
            lock (this)
            {
                emCache = hashCache.TryGetValue(chave, out item);
                qtd = hashCache.Count;
                if (emCache)
                {
                    if (item.Validade < DateTime.Now || item.Entidade == null)
                    {
#if DEBUG
                        Console.WriteLine("Validade expirada: {0}; {1}", tipo.ToString(), item.Entidade != null ? item.Entidade.ToString() : "null");
#endif

                        Remover(item);
                        entidade = Recuperar(tipo, parâmetros);
                        Adicionar(tipo, parâmetros, entidade);
                        return entidade;
                    }

                    item.Usos++;

#if DEBUG
                    //string copia;
                    //copia = item.Copiar ? " (A cópia será feita)" : "";

                    //if (item.Entidade != null)
                    //    Console.WriteLine("Reutilização {0} de item em cache: {2} {1}", item.Usos, item.Entidade.ToString(), copia);

#endif
                    if (item.Copiar)
                        return Copiar(item);
                    else
                        return item.Entidade;
                }
                else
                {
                    //Console.WriteLine("Infelizmente o item " + chave.ToString() + " não está em cache... só tenho " + hashCache.Count.ToString());
                    entidade = Recuperar(tipo, parâmetros);
                    Adicionar(tipo, parâmetros, entidade);
                    return entidade;
                }
            }
        }

		/// <summary>
		/// Remove item do cache.
		/// </summary>
		/// <param name="item">Item a ser removido.</param>
		private void Remover(CacheDbItem item)
		{
#if DEBUG
            Console.WriteLine("Removendo da cache {0}", item.ToString());
#endif

			listaCache.Remove(item);
			hashCache.Remove(item.Chave);

            // Remove item da lista de referentes.
            if (item.Entidade != null)
                foreach (FieldInfo campo in item.Entidade.GetType().GetFields(BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Public))
                    if (campo.FieldType.IsSubclassOf(typeof(DbManipulação)))
                    {
                        DbManipulação obj = (DbManipulação)campo.GetValue(item.Entidade);

                        if (obj != null && obj.PossuiReferentes)
                            obj.Referentes.Remove(item.Entidade);
                    }
		}

        /// <summary>
        /// Remove item do cache.
        /// </summary>
        /// <param name="entidade">Item a ser removido.</param>
        public void Remover(DbManipulação entidade)
        {
            CacheDbItem[] listaAntiga = new CacheDbItem[listaCache.Count];
            listaCache.CopyTo(listaAntiga);

            if (entidade != null)
            {
                Type tipo = entidade.GetType();

                foreach (CacheDbItem item in listaAntiga)
                    /* O tipo não pode ser comparado.
                        * Imagine que existe um item "Representante" em cache
                        * e deseja-se remover a mesma pessoa porém "PessoaFísica"
                        * Isso acontece na prática!
                        */
                    ///if (item.Entidade != null && item.Entidade.GetType() == tipo && entidade.Referente(item.Entidade))
                    if (item.Entidade != null && entidade.Referente(item.Entidade))
                    {
                        Remover(item);
                        //break;
                        /* Deve-se remover todas as instancias.
                            * Existe caso em que há mais de uma entidade repetida na cache.
                            * Como reproduzir ? Procure pessoa pelo codigo no atendimento faça alguma alteração e procure novamente.
                            */
                    }
            }
        }

		/// <summary>
		/// Recupera entidade do banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo a ser recuperado.</param>
		/// <param name="parâmetros">Parâmetros para recuperar.</param>
		/// <returns></returns>
        private DbManipulação Recuperar(Type tipo, object[] parâmetros)
		{
			MethodInfo [] métodos;
			DbManipulação entidade = null;
            bool entidadeObtida = false;

			métodos = this.métodos[tipo];

			foreach (MethodInfo método in métodos)
			{
				ParameterInfo [] métParâmetros;
				bool             válido;
				
#if DEBUG
                if (método == null)
                    throw new Exception("Erro: método nulo encontrado.\n Isto provavelmente ocorreu porque existe atributos [Cacheável()] em algum classe sem o método correspondente. Dica: o método retorna objeto do tipo " + tipo.ToString() + " mas não necessáriamente o problema está nesta classe. ");
#endif

				métParâmetros = método.GetParameters();
				válido        = métParâmetros.Length == parâmetros.Length;

				if (!válido)
					continue;

                foreach (ParameterInfo parâmetro in métParâmetros)
                    if (parâmetros[parâmetro.Position] != null)
                        válido &= parâmetro.ParameterType.Equals(parâmetros[parâmetro.Position].GetType());
                    else
                        válido &= !parâmetro.ParameterType.IsValueType || parâmetro.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>);

				if (válido)
				{
                    try
                    {
                        entidade = (DbManipulação) método.Invoke(null, parâmetros);
                        entidadeObtida = true;
					}
					catch (TargetInvocationException e)
					{
						Console.WriteLine(e.InnerException.ToString());
						throw new Exception(e.InnerException.Message, e);
					}
					
                    if (entidadeObtida)
                        break;
				}
			}

            if (!entidadeObtida)
            {
                entidadeObtida = RecuperarCompatibilidade(tipo, parâmetros, métodos, out entidade);

                if (!entidadeObtida)
                {
                     entidadeObtida = RecuperarConvertendo(tipo, parâmetros, métodos, out entidade);

                    if (!entidadeObtida)
                        throw new Exception("Não foi possível encontrar um método válido para o conjunto de parâmetros passado.");
                }
            }

			return entidade;
		}

		/// <summary>
		/// Recuperar conforme compatibilidade.
		/// </summary>
        /// <returns> verdadeiro se conseguiu recuperar </returns>
		private static bool RecuperarCompatibilidade(Type tipo, object [] parâmetros, MethodInfo [] métodos, out DbManipulação entidade)
		{
			// Tentar compatibilidade
			foreach (MethodInfo método in métodos)
			{
				ParameterInfo [] métParâmetros;
				bool             válido;
				
				métParâmetros = método.GetParameters();
				válido        = métParâmetros.Length == parâmetros.Length;

				if (!válido)
					continue;

				foreach (ParameterInfo parâmetro in métParâmetros)
                    if (parâmetros[parâmetro.Position] != null)
					    válido &= parâmetro.ParameterType.IsAssignableFrom(parâmetros[parâmetro.Position].GetType());
                    else
                        válido &= !parâmetro.ParameterType.IsValueType || parâmetro.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>);

				if (válido)
				{
					entidade = (DbManipulação) método.Invoke(null, parâmetros);
                    return true;
				}
			}

            entidade = null;
            return false;
        }

		/// <summary>
		/// Recuperar conforme compatibilidade.
		/// </summary>
        /// <returns> verdadeiro se conseguiu. </returns>
		private static bool RecuperarConvertendo(Type tipo, object [] parâmetros, MethodInfo [] métodos, out DbManipulação entidade)
		{
			// Tentar compatibilidade
			foreach (MethodInfo método in métodos)
			{
				ParameterInfo [] métParâmetros;
				bool             válido;
				
				métParâmetros = método.GetParameters();
				válido        = métParâmetros.Length == parâmetros.Length;

				if (!válido)
					continue;

				if (válido)
				{
                    object[] pConvertidos = new object[parâmetros.Length];

                    for (int i = 0; i < parâmetros.Length; i++)
                        pConvertidos[i] = Convert.ChangeType(parâmetros[i], métParâmetros[i].ParameterType);

					entidade = (DbManipulação) método.Invoke(null, pConvertidos);
                    return true;
				}
			}

            entidade = null;
			return false;
		}

		/// <summary>
		/// Adiciona uma entidade no cache.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <param name="parâmetros">Parâmetros usados para recuperar a entidade.</param>
		/// <param name="entidade">Entidade.</param>
        public void Adicionar(Type tipo, object[] parâmetros, DbManipulação entidade)
		{
			CacheDbItem item;

			item = new CacheDbItem(entidade, ExtrairValidade(tipo), new CacheDbChave(tipo, parâmetros));

            while (listaCache.Count >= tamanho)
                Remover(listaCache[0]);

			hashCache.Add(item.Chave, item);
            listaCache.Add(item);
			listaCache.Sort();

#if DEBUG
            //Console.WriteLine("Adicionado {0} ({1}) em cache. {2} itens em cache.", tipo.ToString(), entidade, listaCache.Count);
#endif
		}

		/// <summary>
		/// Extrai a validade de um tipo.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <returns>Data de validade.</returns>
		private static DateTime ExtrairValidade(Type tipo)
		{
			Validade [] validades;

			validades = (Validade []) tipo.GetCustomAttributes(typeof(Validade), true);

			if (validades.Length == 0)
				return DateTime.Now.AddMinutes(30);

			return DateTime.Now.Add(validades[0].Prazo);
		}

        /// <summary>
        /// Realiza cópia da entidade.
        /// </summary>
        /// <param name="item">Item na cache.</param>
        /// <returns>Cópia da entidade.</returns>
        private static object Copiar(CacheDbItem item)
        {
#if DEBUG
            Console.WriteLine("Copiando entidade " + item.ToString());
#endif

            DbManipulação cópia, original;

            original = item.Entidade;

            if (original is ICloneable)
                cópia = (DbManipulação)((ICloneable)original).Clone();
            else
            {
                Type tipo = original.GetType();

                cópia = (DbManipulação)tipo.Assembly.CreateInstance(tipo.FullName);

                foreach (FieldInfo campo in tipo.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.Public))
                {
                    campo.SetValue(cópia, campo.GetValue(original));
                }
            }

#if DEBUG
            if (cópia == null)
                throw new Exception("Cópia nula!");
#endif

            cópia.Alterado += new DbManipulação.DbManipulaçãoHandler(item.AoAlterarEntidade);

            return cópia;
        }

        #region IDisposable Members

        public void Dispose()
        {
            tmrManutenção.Dispose();
            listaCache.Clear();
        }

        #endregion

        /// <summary>
        /// Efetua manutenção na cache, removendo itens já vencidos.
        /// </summary>
        private void EfetuarManutenção(object sender, ElapsedEventArgs e)
        {
            List<CacheDbItem> remoção = new List<CacheDbItem>();
            DateTime agora = DateTime.Now;

#if DEBUG
            Console.WriteLine("Efetuando manutenção da CacheDb.");
#endif

            lock (this)
                foreach (CacheDbItem item in listaCache)
                    if (item.Validade < agora)
                        remoção.Add(item);

            foreach (CacheDbItem item in remoção)
            {
#if DEBUG
                Console.WriteLine("Removendo item " + (item.Entidade != null ? item.Entidade.ToString() : "null"));
#endif
                lock (this)
                    listaCache.Remove(item);
            }

#if DEBUG
            Console.WriteLine("Manutenção concluída.");
#endif
        }
    }
}
