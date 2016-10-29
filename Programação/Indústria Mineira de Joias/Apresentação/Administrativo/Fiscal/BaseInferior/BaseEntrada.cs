using System.Collections.Generic;
using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntrada : BaseDocumento
    {
        public BaseEntrada() : base(Entidades.Fiscal.Pdf.EntradaFiscalPdf.Cache)
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(true);
        }

        public override void Carregar(DocumentoFiscal documento)
        {
            base.Carregar(documento);

            dtEntradaSaída.Value = ((EntradaFiscal)documento).DataEntrada;
        }

        protected override List<string> ObterIds()
        {
            return EntradaFiscal.ObterIds();
        }

        protected override void Excluir()
        {
            EntradaFiscal.Excluir(new string[] { documento.Id });
        }
    }
}
