using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseDocumento : Formulários.BaseInferior
    {
        protected DocumentoFiscal documento;

        public BaseDocumento()
        {
            InitializeComponent();
        }

        public virtual void Carregar(DocumentoFiscal documento)
        {
            this.documento = documento;

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
            throw new System.Exception("abstrato");
        }

        private void txtObservações_Validated(object sender, System.EventArgs e)
        {
            documento.Observações = txtObservações.Text;
            Gravar();
        }
    }
}

