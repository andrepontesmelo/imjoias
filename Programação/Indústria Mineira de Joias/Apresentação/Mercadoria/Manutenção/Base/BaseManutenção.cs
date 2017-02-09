using Apresentação.Formulários;

namespace Apresentação.Mercadoria.Manutenção.Base
{
    public partial class BaseManutenção : BaseInferior
    {
        public BaseManutenção()
        {
            InitializeComponent();
        }

        private void lista_DuploClique(object sender, System.EventArgs e)
        {
            SubstituirBase(new BaseEdição());
        }
    }
}
