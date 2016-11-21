using Entidades.Fiscal.Fabricação;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaSaídaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        public ListaSaídaFabricaçãoFiscal()
        {
            InitializeComponent();
        }

        public void Carregar(int fabricação)
        {
            Carregar(SaídaFabricaçãoFiscal.Obter(fabricação));
        }
    }
}
