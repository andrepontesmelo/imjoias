using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Entidades.Fiscal.Pdf;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseDocumento : Formulários.BaseInferior
    {
        protected DocumentoFiscal documento;
        private CacheIds cacheIdsPDFS;

        public BaseDocumento(CacheIds cacheIdsPDFS)
        {
            InitializeComponent();
            this.cacheIdsPDFS = cacheIdsPDFS;
        }

        public virtual void Carregar(DocumentoFiscal documento)
        {
            this.documento = documento;

            CarregarControlesEdição(documento);
            CarregarControlesDF(documento);
        }

        private void CarregarControlesDF(DocumentoFiscal documento)
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
    }
}

