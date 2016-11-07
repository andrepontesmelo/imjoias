using Entidades.Fiscal.Produção;
using Entidades.Fiscal.Tipo;

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
            listaEntradas.Carregar(produção.Código);
            listaSaídas.Carregar(produção.Código);
        }

        private void txtMercadoria_ReferênciaConfirmada(object sender, System.EventArgs e)
        {
            var mercadoria = txtMercadoria.Mercadoria;
            txtCFOP.Text = mercadoria?.CFOP.ToString();
            txtDescrição.Text = mercadoria?.Descrição;
            cmbTipoUnidade.Seleção = mercadoria == null ? null : TipoUnidade.Obter(mercadoria.TipoUnidadeComercial);
        }

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {
            if (txtQuantidade.Double == 0)
                return;

            produção.AdicionarProdução(txtMercadoria.ReferênciaNumérica, (decimal)txtQuantidade.Double);
            Carregar(produção);
        }
    }
}
