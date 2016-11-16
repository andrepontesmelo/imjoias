using Entidades.Fiscal.Produção;

namespace Apresentação.Administrativo.Fiscal.Lista.Produção
{
    public partial class ListaSaídaProduçãoFiscal : ListaItemProduçãoFiscal
    {
        public ListaSaídaProduçãoFiscal()
        {
            InitializeComponent();
        }

        public void Carregar(int produção)
        {
            Carregar(SaídaProduçãoFiscal.Obter(produção));
        }
    }
}
