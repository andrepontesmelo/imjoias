using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Acesso.Comum.Mapeamento;
using Acesso.Comum.Exce��es;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Carrega informa��es para manipula��o de um objeto
	/// no banco de dados.
	/// </summary>
    [Serializable]
	class InfoManipula��o
	{
		#region Atributos

        /// <summary>
        /// Campos mapeados para atributos da entidade do banco de dados.
        /// </summary>
        FieldInfo[] vetorChavePrim�ria, vetorChavePrim�riaPersonaliz�vel, vetorAtributos;

        /// <summary>
		/// Campos de auto-incremento.
		/// </summary>
		private FieldInfo[] vetorAutoIncremento;

        /// <summary>
        /// Campos marcados como relacionamento invertido. Tais
        /// campos ser�o manipulados ap�s o objeto principal.
        /// </summary>
        private FieldInfo[] vetorRelacionamentoInvertido;

        /// <summary>
        /// Nome da tabela.
        /// </summary>
        private string tabela;

		#endregion

		#region Constru��o

		/// <summary>
		/// Constr�i as informa��es
		/// </summary>
		private InfoManipula��o(Type tipo)
		{
			tabela = ExtrairNomeTabela(tipo);

			ExtrairAtributos(tipo, out vetorChavePrim�ria, out vetorChavePrim�riaPersonaliz�vel, out vetorAtributos, out vetorAutoIncremento);
        }

        /// <summary>
        /// Hash mapeando tipo � informa��o de manipula��o.
        /// </summary>
        private static Dictionary<Type, InfoManipula��o> hashTipo = new Dictionary<Type, InfoManipula��o>();

        /// <summary>
        /// Acessa informa��es de manipula��o de um tipo espec�fico.
        /// </summary>
        /// <param name="tipo">Tipo a ser manipulado.</param>
        /// <returns>Informa��es de manipula��o.</returns>
        public static InfoManipula��o ObterManipula��o(Type tipo)
        {
            InfoManipula��o info;

            lock (hashTipo)
            {
                if (hashTipo.TryGetValue(tipo, out info))
                    return info;

                info = new InfoManipula��o(tipo);
                hashTipo.Add(tipo, info);
            }

            return info;
        }

        #endregion

        #region Propriedades

        /// <summary>
		/// Vetor de campos cujo valores s�o auto-incrementados.
		/// </summary>
		public FieldInfo [] AutoIncremento
		{
			get { return vetorAutoIncremento; }
		}

        /// <summary>
        /// Campos mapeados como chave-prim�ria criados pelo banco de dados.
        /// </summary>
        public FieldInfo[] ChavePrim�ria
        {
            get { return vetorChavePrim�ria; }
        }
        
        /// <summary>
        /// Campos mapeados como chave-prim�ria que podem ser atribu�das pelo usu�rio.
        /// </summary>
        public FieldInfo[] ChavePrim�riaPersonaliz�vel
        {
            get { return vetorChavePrim�riaPersonaliz�vel; }
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

		#region Extra��o de nomes (tabela, coluna e chave-extrangeira)

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
				throw new Exception("Uma entidade n�o pode possuir mais de um atributo \"DbTabela\".");
		}

		#endregion

		#region Extra��o de atributos (campos de um objeto)

		/// <summary>
		/// Extrai atributos de um tipo, preparando o objeto para
		/// preenchimento de dados. O m�todo ainda atribui no par�metro
		/// "colunas" o nome das colunas dos atributos, para ser
		/// utilizado na constru��o do objeto. Tal valor n�o � armazenado
		/// internamente no objeto, visto que s� ser� utilizado na constru��o
		/// dos comandos SQL.
		/// </summary>
		/// <param name="tipo">Tipo cujos atributos ser�o extra�dos.</param>
		private void ExtrairAtributos(
			Type tipo,
			out FieldInfo [] vetorChavePrim�ria,
			out FieldInfo [] vetorChavePrim�riaPersonaliz�vel,
			out FieldInfo [] vetorAtributosComuns,
			out FieldInfo [] vetorAutoIncremento)
		{
            List<FieldInfo> chavePrim�ria = new List<FieldInfo>();
            List<FieldInfo> chavePrim�riaPersonaliz�vel = new List<FieldInfo>();
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
                 *   i) Se ele � chave prim�ria;
                 *  ii) se ele � um relacionamento invertido;
                 * iii) ou se ele � um atributo qualquer.
                 */
                if (atributoCampo.ChavePrim�ria)
                {
                    chavePrim�ria.Add(campo);

                    if (!atributoCampo.AutoIncremento)
                        chavePrim�riaPersonaliz�vel.Add(campo);
                    else
                        autoIncremento.Add(campo);
                }
                else // verificar op��es (ii) a (iii)
                {
                    DbRelacionamentoInvertido[] atributoTipo;

                    atributoTipo = ((DbRelacionamentoInvertido[])campo.FieldType.GetCustomAttributes(typeof(DbRelacionamentoInvertido), true));

                    if (atributoTipo.Length > 0)
                    {
                        /* No segundo caso, o objeto n�o entra como coluna, por�m
                         * ele � armazenado em uma tabela � parte. Ao t�rmino da
                         * manipula��o do objeto principal, ser� chamado o comando
                         * correspondente de manipula��o no objeto relacionado.
                         */
                        relacionamentoInvertido.Add(campo);
                    }
                    else
                        atributos.Add(campo);
                }
			}

			// Atribuir atributos do objeto.
			vetorChavePrim�ria               = chavePrim�ria.ToArray();
			vetorChavePrim�riaPersonaliz�vel = chavePrim�riaPersonaliz�vel.ToArray();
			vetorAtributosComuns             = atributos.ToArray();
			vetorAutoIncremento              = autoIncremento.ToArray();
            vetorRelacionamentoInvertido     = relacionamentoInvertido.ToArray();
		}

		#endregion

        /// <summary>
        /// Campos de relacionamento invertido.
        /// </summary>
        public DbManipula��o[] ObterRelacionamentosInvertidos(DbManipula��oAutom�tica entidade)
        {
            DbManipula��o[] relacionamentos;

            relacionamentos = new DbManipula��o[vetorRelacionamentoInvertido.Length];

            for (int i = 0; i < vetorRelacionamentoInvertido.Length; i++)
                relacionamentos[i] = (DbManipula��o)vetorRelacionamentoInvertido[i].GetValue(entidade);

            return relacionamentos;
        }
	}
}
