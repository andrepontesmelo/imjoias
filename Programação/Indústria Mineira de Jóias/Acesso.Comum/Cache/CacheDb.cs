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
		/// M�todos para recupera��o de tipos.
		/// </summary>
		private M�todosRecupera��o m�todos;

        /// <summary>
        /// Temporizador para manuten��o da cache.
        /// </summary>
        private Timer tmrManuten��o;

		/// <summary>
		/// Constr�i o cache.
		/// </summary>
		private CacheDb()
		{
			listaCache = new List<CacheDbItem>(tamanho);
			hashCache  = new Dictionary<CacheDbChave,CacheDbItem>(tamanho);
			m�todos    = new M�todosRecupera��o();

            tmrManuten��o = new Timer(1000 * 60 * 5);
            tmrManuten��o.AutoReset = true;
            tmrManuten��o.Elapsed += new ElapsedEventHandler(EfetuarManuten��o);
            tmrManuten��o.Start();
		}

		#region Singleton

		/// <summary>
		/// Inst�ncia �nica da classe.
		/// </summary>
		private static CacheDb inst�ncia = new CacheDb();

		/// <summary>
		/// Obt�m a inst�ncia �nica de CacheDb.
		/// </summary>
		public static CacheDb Inst�ncia
		{
			get { return inst�ncia; }
		}

		#endregion

		/// <summary>
		/// Obt�m entidade do cache ou do banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <param name="par�metros">Par�metros para recupera��o da entidade.</param>
		/// <returns>Entidade recuperada.</returns>
        public object ObterEntidade(Type tipo, params object[] par�metros)
        {
            CacheDbItem item;
            CacheDbChave chave;
            bool emCache;
            DbManipula��o entidade;

            chave = new CacheDbChave(tipo, par�metros);
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
                        entidade = Recuperar(tipo, par�metros);
                        Adicionar(tipo, par�metros, entidade);
                        return entidade;
                    }

                    item.Usos++;

#if DEBUG
                    //string copia;
                    //copia = item.Copiar ? " (A c�pia ser� feita)" : "";

                    //if (item.Entidade != null)
                    //    Console.WriteLine("Reutiliza��o {0} de item em cache: {2} {1}", item.Usos, item.Entidade.ToString(), copia);

#endif
                    if (item.Copiar)
                        return Copiar(item);
                    else
                        return item.Entidade;
                }
                else
                {
                    //Console.WriteLine("Infelizmente o item " + chave.ToString() + " n�o est� em cache... s� tenho " + hashCache.Count.ToString());
                    entidade = Recuperar(tipo, par�metros);
                    Adicionar(tipo, par�metros, entidade);
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
                    if (campo.FieldType.IsSubclassOf(typeof(DbManipula��o)))
                    {
                        DbManipula��o obj = (DbManipula��o)campo.GetValue(item.Entidade);

                        if (obj != null && obj.PossuiReferentes)
                            obj.Referentes.Remove(item.Entidade);
                    }
		}

        /// <summary>
        /// Remove item do cache.
        /// </summary>
        /// <param name="entidade">Item a ser removido.</param>
        public void Remover(DbManipula��o entidade)
        {
            CacheDbItem[] listaAntiga = new CacheDbItem[listaCache.Count];
            listaCache.CopyTo(listaAntiga);

            if (entidade != null)
            {
                Type tipo = entidade.GetType();

                foreach (CacheDbItem item in listaAntiga)
                    /* O tipo n�o pode ser comparado.
                        * Imagine que existe um item "Representante" em cache
                        * e deseja-se remover a mesma pessoa por�m "PessoaF�sica"
                        * Isso acontece na pr�tica!
                        */
                    ///if (item.Entidade != null && item.Entidade.GetType() == tipo && entidade.Referente(item.Entidade))
                    if (item.Entidade != null && entidade.Referente(item.Entidade))
                    {
                        Remover(item);
                        //break;
                        /* Deve-se remover todas as instancias.
                            * Existe caso em que h� mais de uma entidade repetida na cache.
                            * Como reproduzir ? Procure pessoa pelo codigo no atendimento fa�a alguma altera��o e procure novamente.
                            */
                    }
            }
        }

		/// <summary>
		/// Recupera entidade do banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo a ser recuperado.</param>
		/// <param name="par�metros">Par�metros para recuperar.</param>
		/// <returns></returns>
        private DbManipula��o Recuperar(Type tipo, object[] par�metros)
		{
			MethodInfo [] m�todos;
			DbManipula��o entidade = null;
            bool entidadeObtida = false;

			m�todos = this.m�todos[tipo];

			foreach (MethodInfo m�todo in m�todos)
			{
				ParameterInfo [] m�tPar�metros;
				bool             v�lido;
				
#if DEBUG
                if (m�todo == null)
                    throw new Exception("Erro: m�todo nulo encontrado.\n Isto provavelmente ocorreu porque existe atributos [Cache�vel()] em algum classe sem o m�todo correspondente. Dica: o m�todo retorna objeto do tipo " + tipo.ToString() + " mas n�o necess�riamente o problema est� nesta classe. ");
#endif

				m�tPar�metros = m�todo.GetParameters();
				v�lido        = m�tPar�metros.Length == par�metros.Length;

				if (!v�lido)
					continue;

                foreach (ParameterInfo par�metro in m�tPar�metros)
                    if (par�metros[par�metro.Position] != null)
                        v�lido &= par�metro.ParameterType.Equals(par�metros[par�metro.Position].GetType());
                    else
                        v�lido &= !par�metro.ParameterType.IsValueType || par�metro.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>);

				if (v�lido)
				{
                    try
                    {
                        entidade = (DbManipula��o) m�todo.Invoke(null, par�metros);
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
                entidadeObtida = RecuperarCompatibilidade(tipo, par�metros, m�todos, out entidade);

                if (!entidadeObtida)
                {
                     entidadeObtida = RecuperarConvertendo(tipo, par�metros, m�todos, out entidade);

                    if (!entidadeObtida)
                        throw new Exception("N�o foi poss�vel encontrar um m�todo v�lido para o conjunto de par�metros passado.");
                }
            }

			return entidade;
		}

		/// <summary>
		/// Recuperar conforme compatibilidade.
		/// </summary>
        /// <returns> verdadeiro se conseguiu recuperar </returns>
		private static bool RecuperarCompatibilidade(Type tipo, object [] par�metros, MethodInfo [] m�todos, out DbManipula��o entidade)
		{
			// Tentar compatibilidade
			foreach (MethodInfo m�todo in m�todos)
			{
				ParameterInfo [] m�tPar�metros;
				bool             v�lido;
				
				m�tPar�metros = m�todo.GetParameters();
				v�lido        = m�tPar�metros.Length == par�metros.Length;

				if (!v�lido)
					continue;

				foreach (ParameterInfo par�metro in m�tPar�metros)
                    if (par�metros[par�metro.Position] != null)
					    v�lido &= par�metro.ParameterType.IsAssignableFrom(par�metros[par�metro.Position].GetType());
                    else
                        v�lido &= !par�metro.ParameterType.IsValueType || par�metro.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>);

				if (v�lido)
				{
					entidade = (DbManipula��o) m�todo.Invoke(null, par�metros);
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
		private static bool RecuperarConvertendo(Type tipo, object [] par�metros, MethodInfo [] m�todos, out DbManipula��o entidade)
		{
			// Tentar compatibilidade
			foreach (MethodInfo m�todo in m�todos)
			{
				ParameterInfo [] m�tPar�metros;
				bool             v�lido;
				
				m�tPar�metros = m�todo.GetParameters();
				v�lido        = m�tPar�metros.Length == par�metros.Length;

				if (!v�lido)
					continue;

				if (v�lido)
				{
                    object[] pConvertidos = new object[par�metros.Length];

                    for (int i = 0; i < par�metros.Length; i++)
                        pConvertidos[i] = Convert.ChangeType(par�metros[i], m�tPar�metros[i].ParameterType);

					entidade = (DbManipula��o) m�todo.Invoke(null, pConvertidos);
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
		/// <param name="par�metros">Par�metros usados para recuperar a entidade.</param>
		/// <param name="entidade">Entidade.</param>
        public void Adicionar(Type tipo, object[] par�metros, DbManipula��o entidade)
		{
			CacheDbItem item;

			item = new CacheDbItem(entidade, ExtrairValidade(tipo), new CacheDbChave(tipo, par�metros));

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
        /// Realiza c�pia da entidade.
        /// </summary>
        /// <param name="item">Item na cache.</param>
        /// <returns>C�pia da entidade.</returns>
        private static object Copiar(CacheDbItem item)
        {
#if DEBUG
            Console.WriteLine("Copiando entidade " + item.ToString());
#endif

            DbManipula��o c�pia, original;

            original = item.Entidade;

            if (original is ICloneable)
                c�pia = (DbManipula��o)((ICloneable)original).Clone();
            else
            {
                Type tipo = original.GetType();

                c�pia = (DbManipula��o)tipo.Assembly.CreateInstance(tipo.FullName);

                foreach (FieldInfo campo in tipo.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.Public))
                {
                    campo.SetValue(c�pia, campo.GetValue(original));
                }
            }

#if DEBUG
            if (c�pia == null)
                throw new Exception("C�pia nula!");
#endif

            c�pia.Alterado += new DbManipula��o.DbManipula��oHandler(item.AoAlterarEntidade);

            return c�pia;
        }

        #region IDisposable Members

        public void Dispose()
        {
            tmrManuten��o.Dispose();
            listaCache.Clear();
        }

        #endregion

        /// <summary>
        /// Efetua manuten��o na cache, removendo itens j� vencidos.
        /// </summary>
        private void EfetuarManuten��o(object sender, ElapsedEventArgs e)
        {
            List<CacheDbItem> remo��o = new List<CacheDbItem>();
            DateTime agora = DateTime.Now;

#if DEBUG
            Console.WriteLine("Efetuando manuten��o da CacheDb.");
#endif

            lock (this)
                foreach (CacheDbItem item in listaCache)
                    if (item.Validade < agora)
                        remo��o.Add(item);

            foreach (CacheDbItem item in remo��o)
            {
#if DEBUG
                Console.WriteLine("Removendo item " + (item.Entidade != null ? item.Entidade.ToString() : "null"));
#endif
                lock (this)
                    listaCache.Remove(item);
            }

#if DEBUG
            Console.WriteLine("Manuten��o conclu�da.");
#endif
        }
    }
}
