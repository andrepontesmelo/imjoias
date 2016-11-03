using Apresentação.Administrativo.Fiscal.BaseInferior;
using Apresentação.Formulário.Exceção;
using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;
using Entidades.Fiscal.Tipo;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseDocumento : Formulários.BaseInferior
    {
        protected DocumentoFiscal documento;
        private CacheIds cacheIdsPDFS;
        private ItemFiscal itemSendoAlterado;

        public BaseDocumento()
        {
            InitializeComponent();
        }

        public BaseDocumento(CacheIds cacheIdsPDFS)
        {
            InitializeComponent();
            this.cacheIdsPDFS = cacheIdsPDFS;
        }

        public virtual void Carregar(DocumentoFiscal documento)
        {
            this.documento = documento;
            CarregarControlesEdição(documento);
            CarregarControlesPDF(documento);
            lstItens.Carregar(documento);
        }

        private void CarregarControlesEdição(DocumentoFiscal documento)
        {
            título.Descrição = "Edição de " + documento.ToString();
            txtObservações.Text = documento.Observações;

            dados.CarregarControlesEdição(documento);
        }

        private void CarregarControlesPDF(DocumentoFiscal documento)
        {
            var pdfExistente = cacheIdsPDFS.Contém(documento.Id);
            opçãoCarregarPDF.Enabled = !pdfExistente;
            opçãoExcluirPDF.Enabled = pdfExistente;
            opçãoAbrirPDF.Enabled = pdfExistente;
        }

        private void txtObservações_Validated(object sender, System.EventArgs e)
        {
            documento.Observações = txtObservações.Text;
            documento.Gravar();
        }

        private void opçãoExcluirDocumento_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this,
                "Confirma exclusão deste documento ?",
                "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ExcluirDocumento();

            SubstituirBaseParaAnterior();
        }

        protected virtual void ExcluirDocumento()
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void opçãoAbrirPDF_Click(object sender, EventArgs e)
        {
            var visualizador = new VisualizadorPDF();
            visualizador.Carregar(ObterPdf());
            visualizador.ShowDialog(this);
        }

        protected virtual FiscalPdf ObterPdf()
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void opçãoExcluirPDF_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Confirma exclusão do PDF armazenado?",
                "Exclusão de PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ObterPdf().Descadastrar();

            CarregarControlesPDF(documento);
        }

        private void opçãoCarregarPDF_Click(object sender, EventArgs e)
        {
            FileDialog janela = new OpenFileDialog();
            janela.Title = "Seleção de PDF";
            janela.FileName = "*.pdf";

            if (janela.ShowDialog() != DialogResult.OK)
                return;

            if (!System.IO.File.Exists(janela.FileName))
                return;

            CadastrarPdf(janela.FileName);
            CarregarControlesPDF(documento);
        }

        protected virtual void CadastrarPdf(string arquivo)
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void lstItens_AoSelecionar(ItemFiscal entidade)
        {
            CarregarItem(entidade);
            btnExcluir.Enabled = entidade != null;
        }

        private void CarregarItem(ItemFiscal entidade)
        {
            itemSendoAlterado = entidade;
            CarregarAtributos(entidade);

            if (entidade == null)
                MostrarBotãoCadastrar();
            else
                MostrarBotãoAlterar();
        }

        private void MostrarBotãoAlterar()
        {
            btnIncluir.Visible = false;
            btnAlterar.Visible = true;
        }

        private void CarregarAtributos(ItemFiscal entidade)
        {
            txtReferência.Text = entidade?.Referência;
            txtCFOP.Text = entidade?.Cfop?.ToString();
            txtDescrição.Text = entidade?.Descrição;
            txtValorTotal.Text = entidade?.Valor.ToString("C");
            txtValorUnitário.Text = entidade?.ValorUnitário.ToString("C");
            txtQuantidade.Text = entidade?.Quantidade.ToString();

            var tipoUnidade = entidade?.TipoUnidade;
            cmbTipoUnidade.Seleção = tipoUnidade == null ? null : TipoUnidade.Obter((int)tipoUnidade);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Atribuir(itemSendoAlterado);
            itemSendoAlterado.DefinirDesatualizado();
            itemSendoAlterado.Atualizar();

            lstItens.Recarregar(itemSendoAlterado);
        }

        private void Atribuir(ItemFiscal entidade)
        {
            entidade.Referência = txtReferência.Text;
            entidade.Descrição = txtDescrição.Text;
            entidade.Quantidade = (decimal) txtQuantidade.Double;
            entidade.TipoUnidade = cmbTipoUnidade.Seleção?.Id;

            entidade.Cfop = null;
            int cfop;
            if (int.TryParse(txtCFOP.Text, out cfop))
                entidade.Cfop = cfop;

            entidade.Valor = (decimal)txtValorTotal.Double;
            entidade.ValorUnitário = (decimal)txtValorUnitário.Double;
        }

        protected virtual ItemFiscal ConstruirItem(string códigoDocumento)
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            var item = ConstruirItem(documento.Id);
            Atribuir(item);
            item.Cadastrar();

            lstItens.Adicionar(item);
            CarregarItem(null);
        }
        

        private void MostrarBotãoCadastrar()
        {
            btnIncluir.Visible = true;
            btnAlterar.Visible = false;
        }

        protected void SubstituirControleDados(DadosDocumento novoControle)
        {
            grpDados.Controls.Remove(dados);
            novoControle.Anchor = dados.Anchor;
            novoControle.Location = dados.Location;
            novoControle.Size = dados.Size;
            grpDados.Controls.Add(novoControle);

            dados = novoControle;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirItens();
        }

        private void ExcluirItens()
        {
            var itensSelecionados = lstItens.ItensSelecionados;

            if (itensSelecionados.Count == 0)
                return;

            if (MessageBox.Show(this, string.Format("Deseja excluir {0} ite{1}?",
                itensSelecionados.Count,
                (itensSelecionados.Count == 1 ? "m" : "ns")),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;


            documento.Excluir(itensSelecionados);

            lstItens.Carregar(documento);

            CancelarAlteração();
        }

        private void CancelarAlteração()
        {
            CarregarItem(null);
        }

        private void lstItens_AoExcluir(object sender, EventArgs e)
        {
            ExcluirItens();
        }
    }
}
