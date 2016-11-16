using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Entidades
{
    [Serializable]
    [Cacheável("ObterSetor"), NãoCopiarCache]
	public class Setor : DbManipulaçãoAutomática, IEquatable<Setor>
	{
        [DbChavePrimária(true)]
		protected uint codigo;
		protected string nome;
		protected bool atendimento;
		protected ulong empresa = 0;
        protected ulong? tabelapadrao;

        private static List<Setor> setores = null;

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
            return (from setor in ObterSetores() where setor.Código.Equals(código) select setor).First();
        }
       
        public static Setor ObterSetor(string nome)
        {
            return (from setor in ObterSetores() where setor.Nome.Equals(nome) select setor).First();
        }

        public static Setor[] ObterSetoresAtendimento()
        {
            return (from setor in ObterSetores() where setor.Atendimento.Equals(true) select setor).ToArray();
        }

        public static List<Setor> ObterSetores()
		{
            if (setores == null)
                setores = Mapear<Setor>("SELECT * FROM setor");

            return setores;
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
