using System.Collections.Generic;
using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;
using Entidades.Configuração;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntrada : BaseDocumento
    {
        public BaseEntrada() : base(EntradaFiscalPdf.Cache)
        {
            InitializeComponent();

            if (ModoDesenho)
                return;

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

        protected override FiscalPdf ObterPdf()
        {
            return EntradaFiscalPdf.Obter(documento.Id);
        }

        protected override void CadastrarPdf(string arquivo)
        {
            var pdf = new EntradaFiscalPdf(documento.Id, System.IO.File.ReadAllBytes(arquivo));
            pdf.Cadastrar();
        }
    }
}
