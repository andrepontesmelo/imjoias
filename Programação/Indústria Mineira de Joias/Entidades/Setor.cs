using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades
{
    [Serializable]
    [Cacheável("ObterSetorSemCache"), NãoCopiarCache]
	public class Setor : DbManipulaçãoAutomática, IEquatable<Setor>
	{
        [DbChavePrimária(true)]
		protected uint codigo;
		protected string nome;
		protected bool atendimento;
		protected ulong empresa = 0;
        protected ulong? tabelapadrao;

        private static Dictionary<uint, Setor> hashSetorCódigo = new Dictionary<uint, Setor>();
        private static Dictionary<string, Setor> hashSetorNome = null;

        public Setor()
		{
		}

        public uint Código => codigo;

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

        public static Setor ObterSetor(uint código)
        {
            if (!hashSetorCódigo.ContainsKey(código))
            {
                Setor[] setores = ObterSetores();
                hashSetorCódigo.Clear();
                foreach (Setor s in setores)
                    hashSetorCódigo[s.Código] = s;
            }

            return hashSetorCódigo[código];
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


        public static Setor ObterSetorSemCache(uint código)
		{
			Setor entidade;
				
			entidade = MapearÚnicaLinha<Setor>("SELECT * FROM setor WHERE codigo = " + DbTransformar(código));
			
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

        public static long ObterSetorCódigo(string nome)
        {
            return (long) CacheDb.Instância.ObterEntidade(typeof(long), nome);
        }
        
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

        public static implicit operator Setor(uint código)
        {
            return (Setor)CacheDb.Instância.ObterEntidade(typeof(Setor), código);
        }

		public override string ToString()
		{
			return nome;
		}

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

        internal static string ObterSetoresSeparadosPorVirgula(Setor[] setores)
        {
            if (setores.Length == 0)
                return "";

            string strSetores = "";

            foreach (Setor setor in setores)
            {
                if (strSetores.Length > 0)
                    strSetores += ", ";

                strSetores += setor.Código;
            }

            return strSetores;
        }
    }
}
