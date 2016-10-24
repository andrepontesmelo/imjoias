using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseDocumento : Apresentação.Formulários.BaseInferior
    {
        public BaseDocumento()
        {
            InitializeComponent();
        }

        public virtual void Carregar(DocumentoFiscal documento)
        {
            título.Descrição = "Edição de " + documento.ToString();
        }
    }
}
