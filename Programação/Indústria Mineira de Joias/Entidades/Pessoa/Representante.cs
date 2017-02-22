using System;
using System.Data;
using System.Reflection;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Exce��es;
using System.Collections.Generic;
using Acesso.Comum.Cache;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Representante da empresa.
	/// </summary>
    [Serializable, DbTransa��o, N�oCopiarCache]
	public class Representante : PessoaF�sica
	{
        public const string strSetor = "Representante";

		/// <summary>
		/// Constr�i um representante vazio.
		/// </summary>
		public Representante()
		{
		}

		/// <summary>
		/// Constr�i um representante a partir de uma pessoa-f�sica.
		/// </summary>
		/// <param name="pessoaF�sica">Dados da pessoa-f�sica.</param>
		public Representante(PessoaF�sica pessoaF�sica)
		{
			FieldInfo []  camposPessoaF�sica;

			// Copiar dados da pessoa f�sica
			camposPessoaF�sica = typeof(PessoaF�sica).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Copiar dados
			foreach (FieldInfo campo in camposPessoaF�sica)
			{
				object valor;

				valor = campo.GetValue(pessoaF�sica);
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
        /// Caso a pessoa-f�sica j� esteja cadastrada,
        /// somente � inserido uma linha na tabela Representante.
        /// </remarks>
        public override void Cadastrar()
		{
			/* O c�digo 0 indica que a pessoa-f�sica
			 * n�o encontra-se cadastrada no banco de dados.
			 */
            if (C�digo == 0)
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
                IDbConnection conex�o;
                IDbCommand cmd;

                lock (this)
                {
                    if (Cadastrado)
                        throw new EntidadeJ�Existente(this);

                    conex�o = Conex�o;

                    using (cmd = conex�o.CreateCommand())
                    {
                        lock (conex�o)
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
		/// Obt�m uma pessoa a partir de um c�digo.
		/// </summary>
		/// <param name="c�digo">C�digo da pessoa.</param>
		/// <returns>Retorna uma pessoa-f�sica.</returns>
		public new static Representante ObterPessoa(ulong c�digo)
		{
            //string comando = "SELECT * FROM pessoa p, pessoafisica pf, representante r"
            //    + " WHERE p.codigo = pf.codigo AND r.codigo = pf.codigo"
            //    + " AND p.codigo = " + DbTransformar(c�digo);

            //return Mapear�nicaLinha<Representante>(comando);

            Representante encontrado = null;
            Representantes.TryGetValue(c�digo, out encontrado);
            return encontrado;
        }

        
        /// <summary>
        /// S� deve ser usado dentro de �Representante
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
                        representantes.Add(r.C�digo, r);
                }

                return representantes;
            }
        }

        public static bool �Representante(Pessoa pessoa)
        {
            return Representantes.ContainsKey(pessoa.C�digo);
        }

        /// <summary>
        /// Obt�m representantes cujo nome cont�m a chave.
        /// </summary>
        /// <param name="nomeBase">Chave a ser procurada.</param>
        /// <param name="limite">Limite de representantes a ser recuperado.</param>
        /// <returns>Vetor de representantes.</returns>
        public static Representante[] ObterRepresentantes(string nomeBase, int limite)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
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
                     * Pesquisar demais nomes, se necess�rio
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
