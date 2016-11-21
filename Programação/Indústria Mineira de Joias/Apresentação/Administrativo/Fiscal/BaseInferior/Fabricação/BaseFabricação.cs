using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Formulários;
using Entidades.Fiscal.Exceções;
using Entidades.Fiscal.Fabricação;
using System.Windows.Forms;
using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.fabricação
{
    public partial class BaseFabricação : Formulários.BaseInferior
    {
        FabricaçãoFiscal fabricação;

        public BaseFabricação()
        {
            InitializeComponent();
        }

        public BaseFabricação(FabricaçãoFiscal fabricação) : this()
        {
            Carregar(fabricação);
        }

        internal void Carregar(FabricaçãoFiscal fabricação)
        {
            this.fabricação = fabricação;
            títuloBaseInferior.Título = string.Format("Fabricação fiscal #{0} de {1}", fabricação.Código, fabricação.DataFormatada);
            listaEntradas.Carregar(fabricação.Código);
            listaSaídas.Carregar(fabricação.Código);
        }

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {
            if (txtQuantidade.Double == 0)
                return;

            try
            {
                AguardeDB.Mostrar();
                fabricação.AdicionarFabricação(new ItemFabricaçãoFiscal(txtMercadoria.Mercadoria.ReferênciaNumérica, (decimal)txtQuantidade.Double));
                LimparCampos();
            }
            catch (ExceçãoFiscal erro)
            {
                AguardeDB.Fechar();
                MensagemErro.MostrarMensagem(this, erro, "Erro ao incluir TO");
            }
            finally
            {
                Carregar(fabricação);
                AguardeDB.Fechar();
            }
        }

        private void LimparCampos()
        {
            txtMercadoria.Referência = "";
            txtCFOP.Text = "";
            txtDescrição.Text = "";
            txtQuantidade.Text = "";
            cmbTipoUnidade = null;
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
                fabricação.Remover(seleção);
            }
            catch (ExceçãoFiscal erro)
            {
                AguardeDB.Fechar();
                MensagemErro.MostrarMensagem(this, erro, "Erro ao remover seleção");
            }
            finally
            {
                Carregar(fabricação);
                AguardeDB.Fechar();
            }
        }

        private void txtMercadoria_ReferênciaAlterada(object sender, System.EventArgs e)
        {
            var mercadoria = txtMercadoria.Mercadoria;

            txtCFOP.Text = mercadoria?.CFOP.ToString();
            txtDescrição.Text = mercadoria?.Descrição;
            cmbTipoUnidade.Seleção = mercadoria == null ? null : mercadoria.TipoUnidadeComercial;
        }
    }
}
