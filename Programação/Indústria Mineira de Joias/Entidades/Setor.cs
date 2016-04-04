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
    [Cache�vel("ObterSetorSemCache"), N�oCopiarCache]
	public class Setor : DbManipula��oAutom�tica, IEquatable<Setor>
	{
        [DbChavePrim�ria(true)]
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
		/// C�digo do setor.
		/// </summary>
		public uint C�digo
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
		/// Se o setor � de atendimento.
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

		#region Recupera��o de dados
        
        public enum SetorSistema : uint
        { 
            Varejo = 1,
            Atacado = 2,
            AltoAtacado = 3,
            Representante = 100,
            N�oEspecificado = 99
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

            //    case SetorSistema.N�oEspecificado:
            //        return ObterSetor("N�o especificado");

            //    default:
            //        throw new NotSupportedException("Setor de sistema n�o suportado.");
            // }
        }

        private static Dictionary<uint, Setor> hashSetorC�digo = new System.Collections.Generic.Dictionary<uint, Setor>();

		/// <summary>
		/// Obt�m o setor do banco de dados.
		/// </summary>
		/// <param name="c�digo">C�digo do setor.</param>
		/// <returns>Informa��es do setor.</returns>
        public static Setor ObterSetor(uint c�digo)
        {
            if (!hashSetorC�digo.ContainsKey(c�digo))
            {
                Setor[] setores = ObterSetores();
                hashSetorC�digo.Clear();
                foreach (Setor s in setores)
                    hashSetorC�digo[s.C�digo] = s;
            }
            //return Acesso.Comum.Cache.CacheDb.Inst�ncia.ObterEntidade(typeof(Setor), c�digo) as Setor;

            return hashSetorC�digo[c�digo];
        }

        private static Dictionary<string, Setor> hashSetorNome = null;
        
        /// <summary>
        /// Obt�m o setor do banco de dados.
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


        public static Setor ObterSetorSemCache(uint c�digo)
		{
			Setor entidade;
				
			entidade = Mapear�nicaLinha<Setor>("SELECT * FROM setor WHERE codigo = " + DbTransformar(c�digo));
			
			return entidade;			
		}

		/// <summary>
		/// Obt�m setores de atendimento.
		/// </summary>
		/// <returns>Vetor de setor.</returns>
        public static Setor[] ObterSetoresAtendimento()
        {
            return Mapear<Setor>("SELECT * FROM setor WHERE atendimento = true").ToArray();
        }

        private static Setor[] todosSetores = null;

		/// <summary>
		/// Obt�m lista de todos os setores.
		/// </summary>
		/// <returns>Vetor de setores.</returns>
        public static Setor [] ObterSetores()
		{
            if (todosSetores == null)
                todosSetores = Mapear<Setor>("SELECT * FROM setor").ToArray();

            return todosSetores;
        }

		/// <summary>
		/// Obt�m o c�digo de um setor
		/// </summary>
		/// <param name="nome">Nome do setor</param>
		/// <returns>C�digo do setor</returns>
        public static long ObterSetorC�digo(string nome)
        {
            return (long) Acesso.Comum.Cache.CacheDb.Inst�ncia.ObterEntidade(typeof(long), nome);
        }
        
        //public static uint ObterSetorC�digoSemCache(string nome)
        //{
        //    IDbConnection conex�o;

        //    conex�o = Conex�o;

        //    lock (conex�o)
        //    {
        //        using (IDbCommand cmd = conex�o.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT codigo FROM setor WHERE nome = " + DbTransformar(nome);

        //            object obj;

        //            obj = cmd.ExecuteScalar();

        //            return obj != null ? Convert.ToUInt32(obj) : 0;
        //        }
        //    }
        //}

		/// <summary>
		/// Obt�m nome do setor
		/// </summary>
		/// <param name="c�digo">C�digo do setor</param>
		/// <returns>Nome do setor</returns>
		public static string ObterSetorNome(uint c�digo)
		{
			IDbConnection conex�o;

			conex�o = Conex�o;

			using (IDbCommand cmd = conex�o.CreateCommand())
			{
				cmd.CommandText = "SELECT nome FROM setor WHERE codigo = " + DbTransformar(c�digo);

				lock (conex�o)
				{
					object obj;

					obj = cmd.ExecuteScalar();

					return obj != null ? Convert.ToString(obj) : null;
				}
			}
		}

		#endregion

		#region Recupera��o de dados para Dataset

		/// <summary>
		/// Obt�m setores de atendimento.
		/// </summary>
		/// <returns>DataSet contendo setores de atendimento.</returns>
		public static System.Data.DataSet ObterSetoresAtendimentoDataSet()
		{
			string        cmd;
			IDataAdapter  adaptador;
			System.Data.DataSet	      setores;
			IDbConnection conex�o = Conex�o;

			cmd = "SELECT codigo, nome FROM setor WHERE atendimento = 1";

			setores = new System.Data.DataSet("Setores");
			adaptador = Usu�rios.Usu�rioAtual.CriarAdaptadorDados(conex�o, cmd);

			lock (conex�o)
			{
				adaptador.Fill(setores);
			}

			return setores;
		}

		#endregion

        #region Recupera��o de dados por cast

        public static implicit operator Setor(uint c�digo)
        {
            return (Setor)CacheDb.Inst�ncia.ObterEntidade(typeof(Setor), c�digo);
        }

        #endregion

		public override string ToString()
		{
			return nome;
		}

        /// <summary>
        /// Obt�m atendentes.
        /// </summary>
        /// <returns>Vetor de atendentes ordenado pelo rod�zio.</returns>
        public Funcion�rio[] ObterAtendentes()
        {
            return Funcion�rio.ObterFuncion�rios(this);
        }

        public bool Equals(Setor other)
        {
            if (other != null)
            {
                return C�digo == other.C�digo;
            }
            else
                return false;
        }
    }
}
