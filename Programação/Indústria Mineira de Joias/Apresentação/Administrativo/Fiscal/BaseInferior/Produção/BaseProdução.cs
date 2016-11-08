using Apresentação.Formulários;
using Entidades.Fiscal.Excessões;
using Entidades.Fiscal.Produção;
using Entidades.Fiscal.Tipo;
using System.Windows.Forms;

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

            try
            {
                AguardeDB.Mostrar();
                produção.AdicionarProdução(new ItemProduçãoFiscal(txtMercadoria.ReferênciaNumérica, (decimal)txtQuantidade.Double));
            }
            catch (EsquemaInexistente erro)
            {
                AguardeDB.Fechar();
                MessageBox.Show(this,
                erro.Message,
                "Erro ao incluir TO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                Carregar(produção);
                AguardeDB.Fechar();
            }
        }

        private void listaEntradas_AoExcluir(object sender, System.EventArgs e)
        {
            MessageBox.Show(this,
                "Favor manipular apenas as saídas.",
                "Manipulação de entrada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void listaSaídas_AoExcluir(object sender, System.EventArgs e)
        {
            var seleção = listaSaídas.ObterSeleção();

            if (seleção.Count == 0)
                return;

            if (MessageBox.Show(this,
                string.Format("Confirma exclusão de {0} iten(s) ?", seleção.Count),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            AguardeDB.Mostrar();
            try
            {
                produção.Remover(seleção);
            }
            catch (EsquemaInexistente erro)
            {
                AguardeDB.Fechar();
                MessageBox.Show(this,
                erro.Message,
                "Erro ao remover seleção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                Carregar(produção);
                AguardeDB.Fechar();
            }
        }
    }
}
