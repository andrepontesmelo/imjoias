using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades
{
    public class Fornecedor : DbManipulaçãoAutomática
	{
		[DbChavePrimária(true), DbColuna("codigo")]
		private ulong código;

        public ulong Código => código;

		public Fornecedor()
		{
		}

		public Fornecedor(ulong código)
		{
			this.código = código;
		}

        public override string ToString()
        {
            return código.ToString();
        }

        public static IList<Fornecedor> ObterFornecedores()
        {
            return Mapear<Fornecedor>("select * from fornecedor");
        }
	}
}
