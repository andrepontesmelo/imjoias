using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades
{
    [Serializable]
    [Cache�vel("ObterSetorSemCache"), N�oCopiarCache]
	public class Setor : DbManipula��oAutom�tica, IEquatable<Setor>
	{
        [DbChavePrim�ria(true)]
		protected uint codigo;
		protected string nome;
		protected bool atendimento;
		protected ulong empresa = 0;
        protected ulong? tabelapadrao;

        private static Dictionary<uint, Setor> hashSetorC�digo = new Dictionary<uint, Setor>();
        private static Dictionary<string, Setor> hashSetorNome = null;

        public Setor()
		{
		}

        public uint C�digo => codigo;

        public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}
		public bool Atendimento
		{
			get { return atendimento; }
			set { atendimento = value; }
		}

		public ulong Empresa
		{
			get { return empresa; }
			set { empresa = value; }
		}

        public static Setor ObterSetor(SetorSistema setor)
        {
            return ObterSetor((uint) setor);
        }

        public static Setor ObterSetor(uint c�digo)
        {
            if (!hashSetorC�digo.ContainsKey(c�digo))
            {
                Setor[] setores = ObterSetores();
                hashSetorC�digo.Clear();
                foreach (Setor s in setores)
                    hashSetorC�digo[s.C�digo] = s;
            }

            return hashSetorC�digo[c�digo];
        }

       
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

        public static Setor[] ObterSetoresAtendimento()
        {
            return Mapear<Setor>("SELECT * FROM setor WHERE atendimento = true").ToArray();
        }

        private static Setor[] todosSetores = null;

        public static Setor [] ObterSetores()
		{
            if (todosSetores == null)
                todosSetores = Mapear<Setor>("SELECT * FROM setor").ToArray();

            return todosSetores;
        }

        public static long ObterSetorC�digo(string nome)
        {
            return (long) CacheDb.Inst�ncia.ObterEntidade(typeof(long), nome);
        }
        
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

        public static implicit operator Setor(uint c�digo)
        {
            return (Setor)CacheDb.Inst�ncia.ObterEntidade(typeof(Setor), c�digo);
        }

		public override string ToString()
		{
			return nome;
		}

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

        internal static string ObterSetoresSeparadosPorVirgula(Setor[] setores)
        {
            if (setores.Length == 0)
                return "";

            string strSetores = "";

            foreach (Setor setor in setores)
            {
                if (strSetores.Length > 0)
                    strSetores += ", ";

                strSetores += setor.C�digo;
            }

            return strSetores;
        }
    }
}
