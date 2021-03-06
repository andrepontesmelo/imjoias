﻿using Apresentação.Formulário.Exceção;
using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.BaseInferior
{
    public partial class DadosDocumento : UserControl
    {
        protected DocumentoFiscal documento;

        public DadosDocumento()
        {
            InitializeComponent();
        }

        internal virtual void CarregarControlesEdição(DocumentoFiscal documento)
        {
            this.documento = documento;

            txtId.Text = documento.Id;
            dtEmissão.Value = documento.DataEmissão;
            txtValor.Text = documento.ValorTotal.ToString("C");
            txtDesconto.Text = documento.Desconto.ToString("C");
            txtSubtotal.Text = documento.SubTotal.ToString("C");
            txtNúmero.Text = documento.Número.ToString();
            txtEmitente.Text = documento.CNPJEmitenteFormatado;
            txtCpfEmissor.Text = documento.CpfEmissor == null ? "" : documento.CpfEmissor;
            txtCnpjEmissor.Text = documento.CnpjEmissor == null ? "" : documento.CnpjEmissor;

            cmbTipoDocumento.Seleção = TipoDocumento.Obter(documento.TipoDocumento);
        }

        public virtual List<string> ObterIdsEmUso()
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void txtId_Validated(object sender, System.EventArgs e)
        {
            documento.Id = txtId.Text;
            documento.Gravar();
        }

        private void dtEmissão_Validated(object sender, System.EventArgs e)
        {
            documento.DataEmissão = dtEmissão.Value;
            documento.Gravar();
        }

        private void txtValor_Validated(object sender, System.EventArgs e)
        {
            documento.ValorTotal = (decimal)txtValor.Double;
            documento.Gravar();
        }

        private void txtNúmero_Validated(object sender, System.EventArgs e)
        {
            documento.Número = txtNúmero.Int;
            documento.Gravar();
        }

        private void txtEmitente_Validated(object sender, System.EventArgs e)
        {
            documento.CnpjEmitente = txtEmitente.Text;
            documento.Gravar();
        }

        private void cmbTipoDocumento_Validated(object sender, System.EventArgs e)
        {
            documento.TipoDocumento = cmbTipoDocumento.Seleção.Id;
            documento.Gravar();
        }

        private void txtId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var idDesejado = txtId.Text.Trim().ToLower();
            e.Cancel = !idDesejado.ToLower().Equals(documento.Id.ToLower()) && ObterIdsEmUso().Contains(idDesejado);
        }

        private void txtSubtotal_Validated(object sender, System.EventArgs e)
        {
            documento.SubTotal = (decimal) txtSubtotal.Double;
            documento.Gravar();
        }

        private void txtDesconto_Validated(object sender, System.EventArgs e)
        {
            documento.Desconto = (decimal) txtDesconto.Double;
            documento.Gravar();
        }

        private void txtCnpjEmissor_Validated(object sender, System.EventArgs e)
        {
            documento.CnpjEmissor = txtCnpjEmissor.TextoSemFormatação;
            documento.Gravar();
        }

        private void txtCpfEmissor_Validated(object sender, System.EventArgs e)
        {
            documento.CpfEmissor = txtCpfEmissor.TextoSemFormatação;
            documento.Gravar();
        }
    }
}
