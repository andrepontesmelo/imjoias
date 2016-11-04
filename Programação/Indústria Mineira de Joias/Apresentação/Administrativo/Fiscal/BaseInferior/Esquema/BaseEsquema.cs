using System;
using Entidades.Fiscal.Esquema;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquema : Apresentação.Formulários.BaseInferior
    {
        private EsquemaProdução esquema;

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
                return;

            CarregarIngrediente(seleção[0]);
        }

        private void CarregarIngrediente(Ingrediente ingrediente)
        {
            txtReferênciaSelecionada.Referência = ingrediente.Referência;
            txtCFOPSelecionado.Text = ingrediente.CFOP.ToString();
            txtQuantidadeSelecionada.Text = ingrediente.Quantidade.ToString();
            txtDescriçãoSelecionado.Text = ingrediente.Descrição;
            cmbTipoUnidadeSelecionada.Seleção = ingrediente.TipoUnidadeComercial;
        }
    }
}
