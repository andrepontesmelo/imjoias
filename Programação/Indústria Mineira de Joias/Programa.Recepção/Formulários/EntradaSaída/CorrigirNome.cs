using Apresentação.Formulários;


namespace Programa.Recepção.Formulários.EntradaSaída
{
    public partial class CorrigirNome : JanelaExplicativa
    {
        public CorrigirNome(string nome)
        {
            InitializeComponent();

            this.txtNome.Text = nome;
        }


        public string Nome
        {
            get { return txtNome.Text; }
        }
    }
}