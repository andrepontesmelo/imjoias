using System.Collections.Generic;
using Entidades.Fiscal.Fabricação;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaEntradaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        public ListaEntradaFabricaçãoFiscal()
        { 
            InitializeComponent();
        }

        protected override List<ItemFabricaçãoFiscal> ObterItensEntidade(FabricaçãoFiscal fabricação)
        {
            return EntradaFabricaçãoFiscal.Obter(fabricação.Código);
        }
    }
}
