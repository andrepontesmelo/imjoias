using Entidades;
using Entidades.Configuração;
using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Administrativo.Fiscal.BaseInferior
{
    public partial class DadosDocumentoSaída : DadosDocumento
    {
        public DadosDocumentoSaída()
        {
            InitializeComponent();

            if (DadosGlobais.ModoDesenho)
                return;

            cmbSetor.Carregar(true);
            cmbTipoDocumento.Carregar(false);
        }

        public override List<string> ObterIdsEmUso()
        {
            return SaídaFiscal.ObterIds();
        }

        internal override void CarregarControlesEdição(DocumentoFiscal documento)
        {
            base.CarregarControlesEdição(documento);

            var saída = (SaídaFiscal) documento;

            cmbSetor.Seleção = Setor.ObterSetor(saída.Setor);
            chkCancelada.Checked = saída.Cancelada;
            dtEntradaSaída.Value = saída.DataSaída;
            cmbMáquina.Seleção = Máquina.ObterMáquina(saída.Máquina);
            txtVenda.Text = saída.Venda.ToString();
        }

        private void cmbSetor_Validated(object sender, System.EventArgs e)
        {
            Documento.Setor = cmbSetor.Seleção.Código;
            Documento.Gravar();
        }

        private SaídaFiscal Documento => documento as SaídaFiscal;

        private void chkCancelada_Validated(object sender, System.EventArgs e)
        {
            Documento.Cancelada = chkCancelada.Checked;
            Documento.Gravar();
        }

        private void dtEntradaSaída_Validated(object sender, System.EventArgs e)
        {
            Documento.DataSaída = dtEntradaSaída.Value;
            Documento.Gravar();
        }

        private void cmbMáquina_Validated(object sender, System.EventArgs e)
        {
            Documento.Máquina = cmbMáquina.Seleção?.Código;
            Documento.Gravar();
        }

        private void txtVenda_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtVenda.Text.Trim().Equals(""))
            {
                e.Cancel = false;
                return;
            }

            int valor;
            if (!int.TryParse(txtVenda.Text, out valor))
            {
                e.Cancel = true;
                return;
            }

            var venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(valor);
            e.Cancel = venda == null;
        }

        private void txtVenda_Validated(object sender, System.EventArgs e)
        {
            int valor;

            if (!int.TryParse(txtVenda.Text, out valor) || valor == 0)
            {
                Documento.Venda = null;
            } else
                Documento.Venda = valor;

            Documento.Gravar();
        }
    }
}