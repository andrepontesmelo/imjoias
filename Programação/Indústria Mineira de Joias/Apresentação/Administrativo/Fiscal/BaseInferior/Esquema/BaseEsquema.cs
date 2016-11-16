using System;
using Entidades.Fiscal.Esquema;
using System.Windows.Forms;

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
            if (esquema.Referência != null)
                txtReferênciaProduzida.Referência = Entidades.Mercadoria.Mercadoria.MascararReferência(esquema.Referência, true);
            else
                txtReferênciaProduzida.Referência = "";

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
            txtReferênciaSelecionada.Referência = ingrediente?.Referência;
            txtCFOPSelecionado.Text = ingrediente?.CFOP.ToString();
            txtQuantidadeSelecionada.Text = ingrediente?.Quantidade.ToString();
            txtDescriçãoSelecionado.Text = ingrediente?.Descrição;
            cmbTipoUnidadeSelecionada.Seleção = ingrediente?.TipoUnidadeComercial;

            this.ingrediente = ingrediente;
            btnAlterar.Enabled = ingrediente != null;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = false;

            ingrediente.Referência = txtReferênciaSelecionada.ReferênciaNumérica;
            ingrediente.Quantidade = (decimal)txtQuantidadeSelecionada.Double;
            ingrediente.Atualizar();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            var seleção = listaIngredientes.Seleção;

            if (seleção.Count == 0)
                return;

            if (MessageBox.Show(this,
                string.Format("Deseja excluir {0} ingrediente{1} ?",
                seleção.Count, (seleção.Count == 1 ? "" : "s")),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            Ingrediente.Excluir(seleção);
            Carregar(esquema);
        }

        private void listaIngredientes_AoExcluir(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                new Ingrediente(esquema.Referência,
                    txtReferênciaSelecionada.ReferênciaNumérica,
                    (decimal)txtQuantidadeSelecionada.Double).Cadastrar();
            } catch (Exception erro)
            {
                MessageBox.Show(this,
                    erro.Message,
                    "Não foi possível adicionar ingrediente");

                return;
            }

            listaIngredientes.Carregar(esquema);
            CarregarIngrediente(null);
        }

        private void txtQuantidadeProduzida_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal quantidadeAnterior = esquema.Quantidade;

            try
            {
                esquema.Quantidade = (decimal)txtQuantidadeProduzida.Double;
                esquema.Persistir();
            } catch(Exception)
            {
                esquema.Quantidade = quantidadeAnterior;
                e.Cancel = true;
            }

            e.Cancel = false;
        }

        private void txtReferênciaProduzida_ReferênciaConfirmada(object sender, EventArgs e)
        {
            string referênciaAnterior = esquema.Referência;

            try
            {
                esquema.Referência = txtReferênciaProduzida.ReferênciaNumérica;
                esquema.Persistir();
            }
            catch (Exception)
            {
                esquema.Referência = referênciaAnterior;
                txtReferênciaProduzida.Referência = referênciaAnterior;

                MessageBox.Show(this,
                    "Verifique se esta referência já possui esquema de produção",
                    "Erro ao alterar referência",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
