using System;
using Entidades.Fiscal.Esquema;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquema : Apresentação.Formulários.BaseInferior
    {
        private EsquemaProdução esquema;
        private Ingrediente ingrediente;

        public BaseEsquema()
        {
            InitializeComponent();
        }

        internal void Carregar(EsquemaProdução esquema)
        {
            this.esquema = esquema;

            listaIngredientes.Carregar(esquema);

            txtCFOPProduzido.Text = esquema.CFOP.ToString();
            txtReferênciaProduzida.Referência = esquema.Referência;
            txtQuantidadeProduzida.Text = esquema.Quantidade.ToString();
            txtDescriçãoProduzida.Text = esquema.Descrição;
            cmbTipoUnidadeProduzido.Seleção = esquema.TipoUnidadeFiscal;
        }

        private void listaIngredientes_AoSelecionar(object sender, System.EventArgs e)
        {
            var seleção = listaIngredientes.Seleção;

            if (seleção.Count == 0)
            {
                btnAlterar.Enabled = false;
                return;
            }

            CarregarIngrediente(seleção[0]);
        }

        private void CarregarIngrediente(Ingrediente ingrediente)
        {
            txtReferênciaSelecionada.Referência = ingrediente.Referência;
            txtCFOPSelecionado.Text = ingrediente.CFOP.ToString();
            txtQuantidadeSelecionada.Text = ingrediente.Quantidade.ToString();
            txtDescriçãoSelecionado.Text = ingrediente.Descrição;
            cmbTipoUnidadeSelecionada.Seleção = ingrediente.TipoUnidadeComercial;

            this.ingrediente = ingrediente;
            btnAlterar.Enabled = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = false;

            ingrediente.Referência = txtReferênciaSelecionada.ReferênciaNumérica;
            ingrediente.Quantidade = (decimal)txtQuantidadeSelecionada.Double;
            ingrediente.Persistir();
            ingrediente = null;

            listaIngredientes.Carregar(esquema);
        }

        private void txtReferênciaSelecionada_ReferênciaAlterada(object sender, EventArgs e)
        {
            var mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(txtReferênciaSelecionada.ReferênciaNumérica);

            btnAlterar.Enabled = mercadoria != null && ingrediente != null;

            txtDescriçãoSelecionado.Text = mercadoria?.Descrição;
            txtCFOPSelecionado.Text = mercadoria?.CFOP.ToString();
            cmbTipoUnidadeSelecionada.Seleção = mercadoria == null ? null :
                Entidades.Fiscal.Tipo.TipoUnidade.Obter(mercadoria.TipoUnidadeComercial);
        }
    }
}
