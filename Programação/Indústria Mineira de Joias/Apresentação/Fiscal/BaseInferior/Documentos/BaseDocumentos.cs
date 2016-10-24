using Apresentação.Fiscal.BaseInferior.Documentos;
using Apresentação.Fiscal.Lista;
using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    public partial class BaseDocumentos : Formulários.BaseInferior
    {
        private ControladorExclusão controlador;

        public BaseDocumentos()
        {
            InitializeComponent();

            controlador = new ControladorExclusão(this);
        }

        private void opçãoExcluir_Click(object sender, System.EventArgs e)
        {
            controlador.Excluir();
        }

        public virtual ListaDocumentoFiscal ObterListaAtiva()
        {
            throw new System.Exception("abstrato");
        }

        protected virtual void AbrirDocumento(DocumentoFiscal documento)
        {
            throw new System.Exception("abstrato");
        }
    }
}
