using Entidades.Fiscal.Produção;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Produção
{
    public partial class BaseProdução : Apresentação.Formulários.BaseInferior
    {
        ProduçãoFiscal produção;

        public BaseProdução()
        {
            InitializeComponent();
        }

        internal void Carregar(ProduçãoFiscal produção)
        {
            this.produção = produção;
            títuloBaseInferior.Título = string.Format("Produção fiscal #{0} de {1}", produção.Código, produção.DataFormatada);
        }
    }
}
