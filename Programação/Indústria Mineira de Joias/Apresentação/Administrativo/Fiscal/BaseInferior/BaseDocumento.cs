using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
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

        private void CarregarControlesPDF(DocumentoFiscal documento)
        {
            var pdfExistente = cacheIdsPDFS.Contém(documento.Id);
            opçãoCarregarPDF.Enabled = !pdfExistente;
            opçãoExcluirPDF.Enabled = pdfExistente;
            opçãoAbrirPDF.Enabled = pdfExistente;
        }

        private void CarregarControlesEdição(DocumentoFiscal documento)
        {
            título.Descrição = "Edição de " + documento.ToString();
            txtId.Text = documento.Id;
            dtEmissão.Value = documento.DataEmissão;
            txtValor.Text = documento.ValorTotal.ToString("C");
            txtNúmero.Text = documento.Número.ToString();
            txtEmitente.Text = documento.CNPJEmitenteFormatado;
            txtObservações.Text = documento.Observações;
            cmbTipoDocumento.Seleção = TipoDocumento.Obter(documento.TipoDocumento);
        }

        private void txtId_Validated(object sender, System.EventArgs e)
        {
            documento.Id = txtId.Text;
            Gravar();
        }

        protected void Gravar()
        {
            documento.Gravar();
        }

        private void dtEmissão_Validated(object sender, System.EventArgs e)
        {
            documento.DataEmissão = dtEmissão.Value;
            Gravar();
        }

        private void txtValor_Validated(object sender, System.EventArgs e)
        {
            documento.ValorTotal = (decimal) txtValor.Double;
            Gravar();
        }

        private void txtNúmero_Validated(object sender, System.EventArgs e)
        {
            documento.Número = txtNúmero.Int;
            Gravar();
        }

        private void txtEmitente_Validated(object sender, System.EventArgs e)
        {
            documento.CnpjEmitente = txtEmitente.Text;
            Gravar();
        }

        private void cmbTipoDocumento_Validated(object sender, System.EventArgs e)
        {
            documento.TipoDocumento = cmbTipoDocumento.Seleção.Id;
            Gravar();
        }

        private void txtId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var idDesejado = txtId.Text.Trim().ToLower();
            e.Cancel = !idDesejado.Equals(documento.Id) && ObterIds().Contains(idDesejado);
        }

        protected virtual List<string> ObterIds()
        {
            throw new Exception("abstrato");
        }

        private void txtObservações_Validated(object sender, System.EventArgs e)
        {
            documento.Observações = txtObservações.Text;
            Gravar();
        }

        private void opçãoExcluirDocumento_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this,
                "Confirma exclusão deste documento ?",
                "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Excluir();

            SubstituirBaseParaAnterior();
        }

        protected virtual void Excluir()
        {
            throw new Exception("abstrato");
        }

        private void opçãoAbrirPDF_Click(object sender, EventArgs e)
        {
            var visualizador = new VisualizadorPDF();
            visualizador.Carregar(ObterPdf());
            visualizador.ShowDialog(this);
        }

        protected virtual FiscalPdf ObterPdf()
        {
            throw new Exception("abstrato");
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
            throw new Exception("abstrato");
        }

        private void lstItens_AoSelecionar(ItemFiscal entidade)
        {
            CarregarItem(entidade);
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
            btnCadastrar.Visible = false;
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
            throw new Exception("abstrato");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var item = ConstruirItem(documento.Id);
            Atribuir(item);
            item.Cadastrar();

            lstItens.Adicionar(item);
            CarregarItem(null);
        }
        

        private void MostrarBotãoCadastrar()
        {
            btnCadastrar.Visible = true;
            btnAlterar.Visible = false;
        }
    }
}

