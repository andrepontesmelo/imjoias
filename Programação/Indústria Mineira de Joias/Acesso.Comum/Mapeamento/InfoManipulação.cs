using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Acesso.Comum.Mapeamento;
using Acesso.Comum.Exceções;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Carrega informações para manipulação de um objeto
	/// no banco de dados.
	/// </summary>
    [Serializable]
	class InfoManipulação
	{
		#region Atributos

        /// <summary>
        /// Campos mapeados para atributos da entidade do banco de dados.
        /// </summary>
        FieldInfo[] vetorChavePrimária, vetorChavePrimáriaPersonalizável, vetorAtributos;

        /// <summary>
		/// Campos de auto-incremento.
		/// </summary>
		private FieldInfo[] vetorAutoIncremento;

        /// <summary>
        /// Campos marcados como relacionamento invertido. Tais
        /// campos serão manipulados após o objeto principal.
        /// </summary>
        private FieldInfo[] vetorRelacionamentoInvertido;

        /// <summary>
        /// Nome da tabela.
        /// </summary>
        private string tabela;

		#endregion

		#region Construção

		/// <summary>
		/// Constrói as informações
		/// </summary>
		private InfoManipulação(Type tipo)
		{
			tabela = ExtrairNomeTabela(tipo);

			ExtrairAtributos(tipo, out vetorChavePrimária, out vetorChavePrimáriaPersonalizável, out vetorAtributos, out vetorAutoIncremento);
        }

        /// <summary>
        /// Hash mapeando tipo à informação de manipulação.
        /// </summary>
        private static Dictionary<Type, InfoManipulação> hashTipo = new Dictionary<Type, InfoManipulação>();

        /// <summary>
        /// Acessa informações de manipulação de um tipo específico.
        /// </summary>
        /// <param name="tipo">Tipo a ser manipulado.</param>
        /// <returns>Informações de manipulação.</returns>
        public static InfoManipulação ObterManipulação(Type tipo)
        {
            InfoManipulação info;

            lock (hashTipo)
            {
                if (hashTipo.TryGetValue(tipo, out info))
                    return info;

                info = new InfoManipulação(tipo);
                hashTipo.Add(tipo, info);
            }

            return info;
        }

        #endregion

        #region Propriedades

        /// <summary>
		/// Vetor de campos cujo valores são auto-incrementados.
		/// </summary>
		public FieldInfo [] AutoIncremento
		{
			get { return vetorAutoIncremento; }
		}

        /// <summary>
        /// Campos mapeados como chave-primária criados pelo banco de dados.
        /// </summary>
        public FieldInfo[] ChavePrimária
        {
            get { return vetorChavePrimária; }
        }
        
        /// <summary>
        /// Campos mapeados como chave-primária que podem ser atribuídas pelo usuário.
        /// </summary>
        public FieldInfo[] ChavePrimáriaPersonalizável
        {
            get { return vetorChavePrimáriaPersonalizável; }
        }

        /// <summary>
        /// Demais campos mapeados para o banco de dados.
        /// </summary>
        public FieldInfo[] Atributos
        {
            get { return vetorAtributos; }
        }

        /// <summary>
        /// Nome da tabela.
        /// </summary>
        public string Tabela
        {
            get { return tabela; }
        }

        #endregion

		#region Extração de nomes (tabela, coluna e chave-extrangeira)

		/// <summary>
		/// Extrai o nome da tabela.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <returns>Nome da tabela.</returns>
		private static string ExtrairNomeTabela(Type tipo)
		{
			DbTabela [] atributos;

			atributos = (DbTabela []) tipo.GetCustomAttributes(typeof(DbTabela), false);

			if (atributos.Length == 0)
				return tipo.Name.ToLower();
			
			else if (atributos.Length == 1)
				return atributos[0].Tabela;

			else
				throw new Exception("Uma entidade não pode possuir mais de um atributo \"DbTabela\".");
		}

		#endregion

		#region Extração de atributos (campos de um objeto)

		/// <summary>
		/// Extrai atributos de um tipo, preparando o objeto para
		/// preenchimento de dados. O método ainda atribui no parâmetro
		/// "colunas" o nome das colunas dos atributos, para ser
		/// utilizado na construção do objeto. Tal valor não é armazenado
		/// internamente no objeto, visto que só será utilizado na construção
		/// dos comandos SQL.
		/// </summary>
		/// <param name="tipo">Tipo cujos atributos serão extraídos.</param>
		private void ExtrairAtributos(
			Type tipo,
			out FieldInfo [] vetorChavePrimária,
			out FieldInfo [] vetorChavePrimáriaPersonalizável,
			out FieldInfo [] vetorAtributosComuns,
			out FieldInfo [] vetorAutoIncremento)
		{
            List<FieldInfo> chavePrimária = new List<FieldInfo>();
            List<FieldInfo> chavePrimáriaPersonalizável = new List<FieldInfo>();
            List<FieldInfo> atributos = new List<FieldInfo>();
            List<FieldInfo> autoIncremento = new List<FieldInfo>();
            List<FieldInfo> relacionamentoInvertido = new List<FieldInfo>();

			// Extrair campos.
			foreach (FieldInfo campo in tipo.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
			{
				DbAtributo atributoCampo;

				atributoCampo = (DbAtributo)((DbAtributo[])campo.GetCustomAttributes(typeof(DbAtributo), false));
				
				if (atributoCampo.Ignorar)
					continue;

                /* Verificar o tipo do objeto:
                 *   i) Se ele é chave primária;
                 *  ii) se ele é um relacionamento invertido;
                 * iii) ou se ele é um atributo qualquer.
                 */
                if (atributoCampo.ChavePrimária)
                {
                    chavePrimária.Add(campo);

                    if (!atributoCampo.AutoIncremento)
                        chavePrimáriaPersonalizável.Add(campo);
                    else
                        autoIncremento.Add(campo);
                }
                else // verificar opções (ii) a (iii)
                {
                    DbRelacionamentoInvertido[] atributoTipo;

                    atributoTipo = ((DbRelacionamentoInvertido[])campo.FieldType.GetCustomAttributes(typeof(DbRelacionamentoInvertido), true));

                    if (atributoTipo.Length > 0)
                    {
                        /* No segundo caso, o objeto não entra como coluna, porém
                         * ele é armazenado em uma tabela à parte. Ao término da
                         * manipulação do objeto principal, será chamado o comando
                         * correspondente de manipulação no objeto relacionado.
                         */
                        relacionamentoInvertido.Add(campo);
                    }
                    else
                        atributos.Add(campo);
                }
			}

			// Atribuir atributos do objeto.
			vetorChavePrimária               = chavePrimária.ToArray();
			vetorChavePrimáriaPersonalizável = chavePrimáriaPersonalizável.ToArray();
			vetorAtributosComuns             = atributos.ToArray();
			vetorAutoIncremento              = autoIncremento.ToArray();
            vetorRelacionamentoInvertido     = relacionamentoInvertido.ToArray();
		}

		#endregion

        /// <summary>
        /// Campos de relacionamento invertido.
        /// </summary>
        public DbManipulação[] ObterRelacionamentosInvertidos(DbManipulaçãoAutomática entidade)
        {
            DbManipulação[] relacionamentos;

            relacionamentos = new DbManipulação[vetorRelacionamentoInvertido.Length];

            for (int i = 0; i < vetorRelacionamentoInvertido.Length; i++)
                relacionamentos[i] = (DbManipulação)vetorRelacionamentoInvertido[i].GetValue(entidade);

            return relacionamentos;
        }
	}
}
