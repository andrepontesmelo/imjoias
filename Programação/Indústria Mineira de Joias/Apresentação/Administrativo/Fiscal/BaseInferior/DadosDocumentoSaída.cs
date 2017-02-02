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
            txtCpfEmissor.Text = saída.CpfEmissor == null ? "" : saída.CpfEmissor;
            txtCnpjEmissor.Text = saída.CnpjEmissor == null ? "" : saída.CnpjEmissor;
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

        private void txtCnpjEmissor_Validated(object sender, System.EventArgs e)
        {
            Documento.CnpjEmissor = txtCnpjEmissor.Text;
            Documento.Gravar();
        }

        private void txtCpfEmissor_Validated(object sender, System.EventArgs e)
        {
            Documento.CpfEmissor = txtCpfEmissor.Text;
            Documento.Gravar();
        }
    }
}