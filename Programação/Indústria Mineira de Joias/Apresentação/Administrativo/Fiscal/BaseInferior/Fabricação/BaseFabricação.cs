using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Administrativo.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.Fabricação;
using Entidades.Configuração;
using Entidades.Fiscal;
using Entidades.Fiscal.Exceções;
using Entidades.Fiscal.Fabricação;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.fabricação
{
    public partial class BaseFabricação : Formulários.BaseInferior
    {
        private FabricaçãoFiscal fabricação;
        private Fechamento fechamento;
        private ItemFabricaçãoFiscal itemAlteração;
        private TipoAlteração? tipoAlteração;

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
            listaEntradas.Carregar(fabricação);
            listaSaídas.Carregar(fabricação);

            fechamento = Fechamento.Obter(fabricação.Data);
            if (fechamento != null)
                títuloBaseInferior.Descrição = string.Format("Serão usados os esquemas do fechamento {0}, vigentes de {1} até {2}.",
                    fechamento.Código, fechamento.Início.ToShortDateString(), fechamento.Fim.ToShortDateString());
            else
                títuloBaseInferior.Descrição = "Tela em modo somente leitura uma vez que não é possível encontrar fechamento para a data desta fabricação. Altere a data da fabricação ou altere a data dos fechamentos.";

            AtualizarVisão(false, null, null);
        }

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {
            if (txtQuantidade.Double == 0)
                return;

            if (txtMercadoria.Mercadoria == null)
            {
                MessageBox.Show("Referência não encontrada");
                return;
            }

            try
            {
                AguardeDB.Mostrar();
                fabricação.AdicionarFabricação(new SaídaFabricaçãoFiscal(txtMercadoria.Mercadoria.ReferênciaNumérica, 
                    (decimal) txtQuantidade.Double, 
                    (decimal) txtValor.Double,
                    int.Parse(txtCFOP.Text),
                    (decimal) txtPeso.Double), fechamento);
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
            txtCFOP.Text = FabricaçãoFiscal.CfopPadrãoOperaçõesInternas.Valor.ToString();
            txtDescrição.Text = "";
            txtPeso.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
            cmbTipoUnidade.Seleção = null;
        }

        private void txtMercadoria_ReferênciaAlterada(object sender, System.EventArgs e)
        {
            var mercadoria = txtMercadoria.Mercadoria;

            txtDescrição.Text = mercadoria?.Descrição;
            
            var hash = MercadoriaFechamento.ObterHash(fechamento.Código);

            MercadoriaFechamento entidade = null;
            decimal valor = 0;
            decimal peso = 0;

            if (mercadoria != null && hash.TryGetValue(mercadoria.ReferênciaNumérica, out entidade))
            {
                valor = entidade.Valor;
                peso = entidade.Peso;
            }

            txtValor.Text = valor.ToString();
            txtPeso.Text = peso.ToString();

            cmbTipoUnidade.Seleção = mercadoria == null ? null : mercadoria.TipoUnidadeComercial;
        }

        private void opçãoConfigurar_Click(object sender, EventArgs e)
        {
            var janela = new JanelaEdiçãoFabricação(fabricação);

            if (janela.Mostrar(this) == DialogResult.Cancel)
                return;

            Carregar(fabricação);
        }

        private void listaSaídas_AoSelecionar(object sender, EventArgs e)
        {
            bool alteração = listaSaídas.Seleção != null;

            AtualizarVisão(alteração, TipoAlteração.TO, listaSaídas.Seleção);
        }

        private void AtualizarVisão(bool alteração, TipoAlteração? tipoAlteração, ItemFabricaçãoFiscal item)
        {
            this.tipoAlteração = tipoAlteração;

            AtualizarBotões(alteração, ObterTexto(tipoAlteração));
            AtualizarCor(alteração);
            AtualizarItem(item);

            bool somenteLeitura = (fechamento == null);
            quadroItem.Enabled = !somenteLeitura;
        }

        private static string ObterTexto(TipoAlteração? tipoAlteração)
        {
            string texto;
            if (tipoAlteração == null)
                texto = "Incluir TO";
            else if (tipoAlteração == TipoAlteração.OT)
                texto = "Alterar OT";
            else if (tipoAlteração == TipoAlteração.TO)
                texto = "Alterar TO";
            else
                throw new NotImplementedException();
            return texto;
        }

        private void AtualizarItem(ItemFabricaçãoFiscal item)
        {
            itemAlteração = item;

            if (item == null)
            {
                LimparCampos();
                return;
            }

            SaídaFabricaçãoFiscal saída = item as SaídaFabricaçãoFiscal;

            if (saída == null)
            {
                txtPeso.Enabled = false;
                txtPeso.Text = "";
            } else
            {
                txtPeso.Enabled = true;
                txtPeso.Text = saída.Peso.ToString();
            }

            txtMercadoria.Referência = item.Referência;
            txtDescrição.Text = item.Mercadoria?.Descrição;
            txtCFOP.Text = item.CFOP.ToString();
            txtQuantidade.Text = item.Quantidade.ToString();
            txtValor.Text = item.Valor.ToString();

            cmbTipoUnidade.Seleção = item.Mercadoria?.TipoUnidadeComercial;
        }

        private void AtualizarBotões(bool alteração, string textoAlteração)
        {
            btnExcluir.Visible = alteração;
            btnAlterar.Visible = alteração;
            btnAlterar.Text = textoAlteração;
            btnIncluir.Visible = !alteração;
        }

        private void AtualizarCor(bool alteração)
        {
            if (alteração)
                quadroItem.BackColor = Color.FromArgb(255, 255, 192);
            else
                quadroItem.BackColor = Color.FromArgb(242, 239, 221);
        }

        private void listaEntradas_AoSelecionar(object sender, EventArgs e)
        {
            bool alteração = listaEntradas.Seleção != null;
            AtualizarVisão(alteração, TipoAlteração.OT, listaEntradas.Seleção);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarVisão(false, null, null);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Certifique-se de atualizar os outros itens envolvidos para manter a consistência do documento. \nConfirma Alteração ?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            itemAlteração.Referência = txtMercadoria.Referência;
            itemAlteração.Quantidade = (decimal) txtQuantidade.Double;
            itemAlteração.Valor = (decimal) txtValor.Double;

            if (tipoAlteração == TipoAlteração.TO)
                SaídaFabricaçãoFiscal.Alterar(new SaídaFabricaçãoFiscal(itemAlteração, (decimal)txtPeso.Double));
            else if (tipoAlteração == TipoAlteração.OT)
                EntradaFabricaçãoFiscal.Alterar(itemAlteração);
            else throw new NotImplementedException();

            Carregar(fabricação);
        }

        private enum TipoAlteração
        {
            TO, OT
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Certifique-se de atualizar os outros itens envolvidos para manter a consistência do documento. \nConfirma Exclusão ?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            if (tipoAlteração == TipoAlteração.TO)
                SaídaFabricaçãoFiscal.Excluir(itemAlteração);
            else if (tipoAlteração == TipoAlteração.OT)
                EntradaFabricaçãoFiscal.Excluir(itemAlteração);
            else throw new NotImplementedException();

            Carregar(fabricação);
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            var janela = new JanelaImpressão();
            var controlador = new ControladorImpressãoFabricação();
            janela.InserirDocumento(controlador.CriarRelatório(fabricação), "Fabricação");

            janela.ShowDialog(this);
        }
    }
}
