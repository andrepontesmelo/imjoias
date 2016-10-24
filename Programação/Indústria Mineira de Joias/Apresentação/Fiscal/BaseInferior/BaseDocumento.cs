using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;

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

            txtId.Text = documento.Id;
            dtEmissão.Value = documento.DataEmissão;
            txtValor.Text = documento.ValorTotal.ToString("C");
            txtNúmero.Text = documento.Número.ToString();
            txtEmitente.Text = documento.CNPJEmitenteFormatado;
            cmbTipoDocumento.Seleção = TipoDocumento.Obter(documento.TipoDocumento);
        }
    }
}
