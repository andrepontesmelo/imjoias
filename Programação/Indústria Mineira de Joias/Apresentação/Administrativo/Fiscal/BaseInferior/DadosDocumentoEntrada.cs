using Entidades.Configuração;
using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Administrativo.Fiscal.BaseInferior
{
    public partial class DadosDocumentoEntrada : DadosDocumento
    {
        public DadosDocumentoEntrada()
        {
            InitializeComponent();

            if (!DadosGlobais.ModoDesenho)
                cmbTipoDocumento.Carregar(true);
        }

        public override List<string> ObterIdsEmUso()
        {
            return EntradaFiscal.ObterIds();
        }

        internal override void CarregarControlesEdição(DocumentoFiscal documento)
        {
            base.CarregarControlesEdição(documento);

            dtEntradaSaída.Value = ((EntradaFiscal)documento).DataEntrada;
        }

        private void dtEntradaSaída_Validated(object sender, System.EventArgs e)
        {
            ((EntradaFiscal)documento).DataEntrada = dtEntradaSaída.Value;
            documento.Gravar();
        }
    }
}
