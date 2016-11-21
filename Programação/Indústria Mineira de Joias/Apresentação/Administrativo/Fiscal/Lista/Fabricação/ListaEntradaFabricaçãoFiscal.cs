using Entidades.Fiscal.Fabricação;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaEntradaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        public ListaEntradaFabricaçãoFiscal()
        { 
            InitializeComponent();
        }

        public void Carregar(int fabricação)
        {
            Carregar(EntradaFabricaçãoFiscal.Obter(fabricação));
        }
    }
}
