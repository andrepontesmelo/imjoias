using Apresentação.Administrativo.Fiscal.BaseInferior;
using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaída : BaseDocumento
    {
        public BaseSaída() : base(SaidaFiscalPdf.Cache)
        {
            InitializeComponent();

            if (ModoDesenho)
                return;

            SubstituirControleDados(new DadosDocumentoSaída());
        }

        private SaídaFiscal Documento => documento as SaídaFiscal;

        protected override void Excluir()
        {
            SaídaFiscal.Excluir(new string[] { documento.Id });
        }

        protected override FiscalPdf ObterPdf()
        {
            return SaidaFiscalPdf.Obter(documento.Id);
        }

        protected override void CadastrarPdf(string arquivo)
        {
            var pdf = new SaidaFiscalPdf(documento.Id, System.IO.File.ReadAllBytes(arquivo));
            pdf.Cadastrar();
        }

        protected override ItemFiscal ConstruirItem(string códigoDocumento)
        {
            return new SaídaItemFiscal(códigoDocumento);
        }
    }
}
