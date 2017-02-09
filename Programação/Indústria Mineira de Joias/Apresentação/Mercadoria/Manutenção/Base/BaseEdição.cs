using Apresentação.Formulários;
using Entidades.Fiscal.Tipo;

namespace Apresentação.Mercadoria.Manutenção.Base
{
    public partial class BaseEdição : BaseInferior
    {
        public BaseEdição()
        {
            InitializeComponent();
            comboboxFornecedor1.Carregar();
            comboTipoUnidade1.Seleção = TipoUnidade.Obter(TipoUnidadeSistema.Pca);
            cmbFaixa1.Text = "C";
        }
    }
}
