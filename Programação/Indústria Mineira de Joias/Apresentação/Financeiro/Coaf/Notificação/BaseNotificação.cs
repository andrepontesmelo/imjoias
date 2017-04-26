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

        private void listaNotificações_AoSelecionar(object sender, System.EventArgs e)
        {
            var seleção = listaNotificações.Seleção;

            if (seleção == null)
                listaSaída.Limpar();
            else
                listaSaída.Carregar(seleção);
        }
    }
}
