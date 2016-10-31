using Apresentação.Administrativo.Fiscal.BaseInferior;
using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntrada : BaseDocumento
    {
        public BaseEntrada() : base(EntradaFiscalPdf.Cache)
        {
            InitializeComponent();

            if (ModoDesenho)
                return;
            
            SubstituirControleDados(new DadosDocumentoEntrada());
        }

        protected override void Excluir()
        {
            EntradaFiscal.Excluir(new string[] { documento.Id });
        }

        protected override FiscalPdf ObterPdf()
        {
            return EntradaFiscalPdf.Obter(documento.Id);
        }

        protected override void CadastrarPdf(string arquivo)
        {
            var pdf = new EntradaFiscalPdf(documento.Id, System.IO.File.ReadAllBytes(arquivo));
            pdf.Cadastrar();
        }

        protected override ItemFiscal ConstruirItem(string códigoDocumento)
        {
            return new EntradaItemFiscal(códigoDocumento);
        }
    }
}
