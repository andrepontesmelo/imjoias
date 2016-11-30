using Entidades.Fiscal.Fabricação;
using System.Collections.Generic;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaSaídaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        public ListaSaídaFabricaçãoFiscal()
        {
            InitializeComponent();
        }

        protected override List<ItemFabricaçãoFiscal> ObterItensEntidade(FabricaçãoFiscal fabricação)
        {
            return SaídaFabricaçãoFiscal.Obter(fabricação.Código);
        }
    }
}
