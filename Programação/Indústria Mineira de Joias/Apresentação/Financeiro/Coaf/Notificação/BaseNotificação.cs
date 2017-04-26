using Apresentação.Formulários;

namespace Apresentação.Financeiro.Coaf
{
    public partial class BaseNotificação : BaseInferior
    {
        public BaseNotificação()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaNotificações.Carregar();
        }
    }
}
