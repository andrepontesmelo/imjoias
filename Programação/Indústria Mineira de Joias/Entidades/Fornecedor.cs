using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades
{
    public class Fornecedor : DbManipula��oAutom�tica
	{
		[DbChavePrim�ria(true), DbColuna("codigo")]
		private ulong c�digo;

        public ulong C�digo => c�digo;

		public Fornecedor()
		{
		}

		public Fornecedor(ulong c�digo)
		{
			this.c�digo = c�digo;
		}

        public override string ToString()
        {
            return c�digo.ToString();
        }

        public static IList<Fornecedor> ObterFornecedores()
        {
            return Mapear<Fornecedor>("select * from fornecedor");
        }
	}
}
