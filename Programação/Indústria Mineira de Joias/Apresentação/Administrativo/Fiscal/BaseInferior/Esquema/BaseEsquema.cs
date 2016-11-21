using System;
using Entidades.Fiscal.Esquema;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquema : Apresentação.Formulários.BaseInferior
    {
        private EsquemaProdução esquema;
        private MateriaPrima ingrediente;

        public BaseEsquema()
        {
            InitializeComponent();
            txtMercadoriaSelecionada.ListarApenas = TipoMercadoria.MatériaPrima;
            txtMercadoriaProduzida.ListarApenas = TipoMercadoria.NãoMatériaPrima;
        }

        internal void Carregar(EsquemaProdução esquema)
        {
            this.esquema = esquema;

            listaIngredientes.Carregar(esquema);

            txtCFOPProduzido.Text = esquema.CFOP.ToString();
            if (esquema.Referência != null)
                txtMercadoriaProduzida.Referência = Entidades.Mercadoria.Mercadoria.MascararReferência(esquema.Referência, true);
            else
                txtMercadoriaProduzida.Referência = "";

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

        private void CarregarIngrediente(MateriaPrima ingrediente)
        {
            txtMercadoriaSelecionada.Referência = ingrediente?.Referência;
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

            ingrediente.Referência = txtMercadoriaSelecionada.Referência;
            ingrediente.Quantidade = (decimal)txtQuantidadeSelecionada.Double;
            ingrediente.Atualizar();
            ingrediente = null;

            listaIngredientes.Carregar(esquema);
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

            MateriaPrima.Excluir(seleção);
            Carregar(esquema);
        }

        private void listaIngredientes_AoExcluir(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (esquema.Referência == null)
                return;


            try
            {
                new MateriaPrima(esquema.Referência,
                    txtMercadoriaSelecionada.Referência,
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

        private void txtMercadoriaProduzida_ReferênciaAlterada(object sender, EventArgs e)
        {
            var referênciaAnterior = esquema.Referência;
            var mercadoria = txtMercadoriaProduzida.Mercadoria;

            if (mercadoria == null)
            {
                txtMercadoriaProduzida.Referência = referênciaAnterior;
                return;
            }

            txtDescriçãoProduzida.Text = mercadoria.Descrição;
            txtCFOPProduzido.Text = mercadoria.CFOP.ToString();
            cmbTipoUnidadeProduzido.Seleção = mercadoria.TipoUnidadeComercial;

            try
            {
                esquema.Referência = mercadoria.ReferênciaNumérica;
                esquema.Persistir();
            }
            catch (Exception)
            {
                esquema.Referência = referênciaAnterior;
                txtMercadoriaProduzida.Referência = referênciaAnterior;

                MessageBox.Show(this,
                    "Verifique se esta referência já possui esquema de produção",
                    "Erro ao alterar referência",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtMercadoriaSelecionada_ReferênciaAlterada(object sender, EventArgs e)
        {
            var mercadoria = txtMercadoriaSelecionada.Mercadoria;

            btnAlterar.Enabled = mercadoria != null && ingrediente != null;

            txtDescriçãoSelecionado.Text = mercadoria?.Descrição;
            txtCFOPSelecionado.Text = mercadoria?.CFOP.ToString();
            cmbTipoUnidadeSelecionada.Seleção = mercadoria == null ? null : mercadoria.TipoUnidadeComercial;
        }
    }
}
