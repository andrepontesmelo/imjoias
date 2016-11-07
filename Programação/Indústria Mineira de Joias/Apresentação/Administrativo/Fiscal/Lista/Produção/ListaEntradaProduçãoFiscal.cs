using Entidades.Fiscal.Produção;

namespace Apresentação.Administrativo.Fiscal.Lista.Produção
{
    public partial class ListaEntradaProduçãoFiscal : ListaItemProduçãoFiscal
    {
        public ListaEntradaProduçãoFiscal()
        { 
            InitializeComponent();
        }

        public void Carregar(int produção)
        {
            Carregar(EntradaProduçãoFiscal.Obter(produção));
        }
    }
}
