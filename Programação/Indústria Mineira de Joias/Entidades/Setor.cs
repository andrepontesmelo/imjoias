using System;
using System.Collections;
using System.Data;
using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Pessoa;
using System.Collections.Generic;

namespace Entidades
{
	[Serializable]
    [Cacheável("ObterSetorSemCache"), NãoCopiarCache]
	public class Setor : DbManipulaçãoAutomática, IEquatable<Setor>
	{
        [DbChavePrimária(true)]
		protected uint		codigo;
		protected string	nome;
		protected bool		atendimento;
		protected ulong		empresa = 0;
        protected ulong?    tabelapadrao;

		public Setor()
		{
		}

		#region Propriedades

		/// <summary>
		/// Código do setor.
		/// </summary>
		public uint Código
		{
			get { return codigo; }
		}

		/// <summary>
		/// Nome do setor.
		/// </summary>
		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		/// <summary>
		/// Se o setor é de atendimento.
		/// </summary>
		public bool Atendimento
		{
			get { return atendimento; }
			set { atendimento = value; }
		}

		/// <summary>
		/// Empresa vinculada ao setor.
		/// </summary>
		public ulong Empresa
		{
			get { return empresa; }
			set { empresa = value; }
		}

		#endregion

		#region Recuperação de dados
        
        public enum SetorSistema : uint
        { 
            Varejo = 1,
            Atacado = 2,
            AltoAtacado = 3,
            Representante = 100,
            NãoEspecificado = 99
        }

        public static Setor ObterSetor(SetorSistema setor)
        {
            return ObterSetor((uint) setor);

            //switch (setor)
            //{
            //    case SetorSistema.Varejo:
            //        return ObterSetor("Varejo");

            //    case SetorSistema.Atacado:
            //        return ObterSetor("Atacado");

            //    case SetorSistema.AltoAtacado:
            //        return ObterSetor("Alto-Atacado");

            //    case SetorSistema.Representante:
            //        return ObterSetor("Representante");

            //    case SetorSistema.NãoEspecificado:
            //        return ObterSetor("Não especificado");

            //    default:
            //        throw new NotSupportedException("Setor de sistema não suportado.");
            // }
        }

        private static Dictionary<uint, Setor> hashSetorCódigo = new System.Collections.Generic.Dictionary<uint, Setor>();

		/// <summary>
		/// Obtém o setor do banco de dados.
		/// </summary>
		/// <param name="código">Código do setor.</param>
		/// <returns>Informações do setor.</returns>
        public static Setor ObterSetor(uint código)
        {
            if (!hashSetorCódigo.ContainsKey(código))
            {
                Setor[] setores = ObterSetores();
                hashSetorCódigo.Clear();
                foreach (Setor s in setores)
                    hashSetorCódigo[s.Código] = s;
            }
            //return Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(Setor), código) as Setor;

            return hashSetorCódigo[código];
        }

        private static Dictionary<string, Setor> hashSetorNome = null;
        
        /// <summary>
        /// Obtém o setor do banco de dados.
        /// </summary>
        /// <param name="nome">Nome do setor.</param>
        public static Setor ObterSetor(string nome)
        {
            Setor[] setores = ObterSetores();

            if (hashSetorNome == null)
            {
                hashSetorNome = new Dictionary<string, Setor>(setores.Length);
                foreach (Setor s in setores)
                    hashSetorNome.Add(s.Nome, s);
            }

            Setor retorno;
            if (hashSetorNome.TryGetValue(nome, out retorno))
            {
                return retorno;
            }
            else
                return null;
        }


        public static Setor ObterSetorSemCache(uint código)
		{
			Setor entidade;
				
			entidade = MapearÚnicaLinha<Setor>("SELECT * FROM setor WHERE codigo = " + DbTransformar(código));
			
			return entidade;			
		}

		/// <summary>
		/// Obtém setores de atendimento.
		/// </summary>
		/// <returns>Vetor de setor.</returns>
        public static Setor[] ObterSetoresAtendimento()
        {
            return Mapear<Setor>("SELECT * FROM setor WHERE atendimento = true").ToArray();
        }

        private static Setor[] todosSetores = null;

		/// <summary>
		/// Obtém lista de todos os setores.
		/// </summary>
		/// <returns>Vetor de setores.</returns>
        public static Setor [] ObterSetores()
		{
            if (todosSetores == null)
                todosSetores = Mapear<Setor>("SELECT * FROM setor").ToArray();

            return todosSetores;
        }

		/// <summary>
		/// Obtém o código de um setor
		/// </summary>
		/// <param name="nome">Nome do setor</param>
		/// <returns>Código do setor</returns>
        public static long ObterSetorCódigo(string nome)
        {
            return (long) Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(long), nome);
        }
        
        //public static uint ObterSetorCódigoSemCache(string nome)
        //{
        //    IDbConnection conexão;

        //    conexão = Conexão;

        //    lock (conexão)
        //    {
        //        using (IDbCommand cmd = conexão.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT codigo FROM setor WHERE nome = " + DbTransformar(nome);

        //            object obj;

        //            obj = cmd.ExecuteScalar();

        //            return obj != null ? Convert.ToUInt32(obj) : 0;
        //        }
        //    }
        //}

		/// <summary>
		/// Obtém nome do setor
		/// </summary>
		/// <param name="código">Código do setor</param>
		/// <returns>Nome do setor</returns>
		public static string ObterSetorNome(uint código)
		{
			IDbConnection conexão;

			conexão = Conexão;

			using (IDbCommand cmd = conexão.CreateCommand())
			{
				cmd.CommandText = "SELECT nome FROM setor WHERE codigo = " + DbTransformar(código);

				lock (conexão)
				{
					object obj;

					obj = cmd.ExecuteScalar();

					return obj != null ? Convert.ToString(obj) : null;
				}
			}
		}

		#endregion

		#region Recuperação de dados para Dataset

		/// <summary>
		/// Obtém setores de atendimento.
		/// </summary>
		/// <returns>DataSet contendo setores de atendimento.</returns>
		public static System.Data.DataSet ObterSetoresAtendimentoDataSet()
		{
			string        cmd;
			IDataAdapter  adaptador;
			System.Data.DataSet	      setores;
			IDbConnection conexão = Conexão;

			cmd = "SELECT codigo, nome FROM setor WHERE atendimento = 1";

			setores = new System.Data.DataSet("Setores");
			adaptador = Usuários.UsuárioAtual.CriarAdaptadorDados(conexão, cmd);

			lock (conexão)
			{
				adaptador.Fill(setores);
			}

			return setores;
		}

		#endregion

        #region Recuperação de dados por cast

        public static implicit operator Setor(uint código)
        {
            return (Setor)CacheDb.Instância.ObterEntidade(typeof(Setor), código);
        }

        #endregion

		public override string ToString()
		{
			return nome;
		}

        /// <summary>
        /// Obtém atendentes.
        /// </summary>
        /// <returns>Vetor de atendentes ordenado pelo rodízio.</returns>
        public Funcionário[] ObterAtendentes()
        {
            return Funcionário.ObterFuncionários(this);
        }

        public bool Equals(Setor other)
        {
            if (other != null)
            {
                return Código == other.Código;
            }
            else
                return false;
        }
    }
}
