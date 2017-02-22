using System;
using System.Data;
using System.Reflection;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Exceções;
using System.Collections.Generic;
using Acesso.Comum.Cache;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Representante da empresa.
	/// </summary>
    [Serializable, DbTransação, NãoCopiarCache]
	public class Representante : PessoaFísica
	{
        public const string strSetor = "Representante";

		/// <summary>
		/// Constrói um representante vazio.
		/// </summary>
		public Representante()
		{
		}

		/// <summary>
		/// Constrói um representante a partir de uma pessoa-física.
		/// </summary>
		/// <param name="pessoaFísica">Dados da pessoa-física.</param>
		public Representante(PessoaFísica pessoaFísica)
		{
			FieldInfo []  camposPessoaFísica;

			// Copiar dados da pessoa física
			camposPessoaFísica = typeof(PessoaFísica).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Copiar dados
			foreach (FieldInfo campo in camposPessoaFísica)
			{
				object valor;

				valor = campo.GetValue(pessoaFísica);
				campo.SetValue(this, valor);
			}

            DefinirCadastrado(false);
		}

        public Representante(string cpf) : base(cpf)
        {
        }

        #region Cadastrar, Atualizar e Descadastrar

        /// <summary>
        /// Cadastra um representante.
        /// </summary>
        /// <remarks>
        /// Caso a pessoa-física já esteja cadastrada,
        /// somente é inserido uma linha na tabela Representante.
        /// </remarks>
        public override void Cadastrar()
		{
			/* O código 0 indica que a pessoa-física
			 * não encontra-se cadastrada no banco de dados.
			 */
            if (Código == 0)
            {
                try
                {
                    base.Cadastrar();
                }
                catch (Exception e)
                {
                    codigo = 0;
                    throw new Exception(e.Message, e);
                }
            }
            else
            {
                IDbConnection conexão;
                IDbCommand cmd;

                lock (this)
                {
                    if (Cadastrado)
                        throw new EntidadeJáExistente(this);

                    conexão = Conexão;

                    using (cmd = conexão.CreateCommand())
                    {
                        lock (conexão)
                            Cadastrar(cmd);
                    }

                    DefinirCadastrado();
                    DefinirAtualizado();
                }
            }
		}

		/// <summary>
		/// Cadastra este representante.
		/// </summary>
		/// <param name="cmd">Comando para cadastro.</param>
		protected override void Cadastrar(IDbCommand cmd)
		{
            AssegurarSetor();

			if (Transacionando)
				base.Cadastrar(cmd);

			cmd.CommandText = "INSERT INTO representante (codigo) VALUES ("
				+ codigo + ")";

			cmd.ExecuteNonQuery();
		}

        private void AssegurarSetor()
        {
            if (setor == null || string.Compare(setor.Nome, strSetor, true) == 0)
                setor = Setor.ObterSetor(strSetor);
        }

		/// <summary>
		/// Descadastra este representante.
		/// </summary>
		/// <param name="cmd">Comando para descadastro.</param>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM representante WHERE codigo = " + DbTransformar(this.codigo);
			cmd.ExecuteNonQuery();

			if (Transacionando)
				base.Descadastrar();
		}

		#endregion

		/// <summary>
		/// Recupera todos os representantes cadastrados.
		/// </summary>
		/// <returns>Vetor de Representante.</returns>
        public static Representante[] ObterRepresentantes()
        {
            return Mapear<Representante>("SELECT * FROM pessoa p, pessoafisica pf, representante r "
                + "WHERE p.codigo = pf.codigo AND pf.codigo = r.codigo").ToArray();
        }

		/// <summary>
		/// Obtém uma pessoa a partir de um código.
		/// </summary>
		/// <param name="código">Código da pessoa.</param>
		/// <returns>Retorna uma pessoa-física.</returns>
		public new static Representante ObterPessoa(ulong código)
		{
            //string comando = "SELECT * FROM pessoa p, pessoafisica pf, representante r"
            //    + " WHERE p.codigo = pf.codigo AND r.codigo = pf.codigo"
            //    + " AND p.codigo = " + DbTransformar(código);

            //return MapearÚnicaLinha<Representante>(comando);

            Representante encontrado = null;
            Representantes.TryGetValue(código, out encontrado);
            return encontrado;
        }

        
        /// <summary>
        /// Só deve ser usado dentro de ÉRepresentante
        /// </summary>
        private static Dictionary<ulong, Representante> representantes = null;
        private static Dictionary<ulong, Representante> Representantes
        {
            get
            {
                if (representantes == null)
                {
                    Representante[] todos = ObterRepresentantes();
                    representantes = new Dictionary<ulong, Representante>();
                    foreach (Representante r in todos)
                        representantes.Add(r.Código, r);
                }

                return representantes;
            }
        }

        public static bool ÉRepresentante(Pessoa pessoa)
        {
            return Representantes.ContainsKey(pessoa.Código);
        }

        /// <summary>
        /// Obtém representantes cujo nome contém a chave.
        /// </summary>
        /// <param name="nomeBase">Chave a ser procurada.</param>
        /// <param name="limite">Limite de representantes a ser recuperado.</param>
        /// <returns>Vetor de representantes.</returns>
        public static Representante[] ObterRepresentantes(string nomeBase, int limite)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    List<Representante> dados = new List<Representante>(limite);

                    string tmpNome;

                    /***
                     * Primeiramente inserir nome base
                     */
                    tmpNome = DbTransformar(nomeBase).Replace(' ', '%').Replace("%%", "%");

                    cmd.CommandText = "SELECT p.*,r.* FROM pessoa p JOIN representante r ON p.codigo = r.codigo WHERE nome LIKE '" +
                        tmpNome.Substring(1, tmpNome.Length - 2) + "%' ORDER BY nome ASC LIMIT " +
                        limite.ToString();

                    Mapear<Representante>(cmd, dados);


                    /***
                     * Pesquisar demais nomes, se necessário
                     */
                    if (dados.Count == 0)
                    {
                        ICollection nomes = ExtrairNomes(nomeBase);

                        cmd.CommandText = "SELECT p.*,r.* FROM pessoa p JOIN representante r ON p.codigo = r.codigo WHERE ";

                        bool primeiro = true;


                        foreach (string parte in nomes)
                        {
                            if (!primeiro)
                                cmd.CommandText += " OR ";

                            primeiro = false;

                            tmpNome = DbTransformar(parte);
                            cmd.CommandText += "nome LIKE '%" +
                                tmpNome.Substring(1, tmpNome.Length - 2) + "%' ";
                        }

                        cmd.CommandText += " ORDER BY nome ASC LIMIT " + ((int)(limite - dados.Count)).ToString();

                        Mapear<Representante>(cmd, dados);
                    }

                    return dados.ToArray();
                }
            }
        }
    }
}
