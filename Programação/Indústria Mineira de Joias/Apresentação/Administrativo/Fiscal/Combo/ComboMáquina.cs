using Apresentação.Formulário;
using Entidades.Configuração;
using Entidades.Fiscal;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Combo
{
    public partial class ComboMáquina : ComboBox
    {
        public ComboMáquina()
        {
            InitializeComponent();

            if (DadosGlobais.ModoDesenho)
                return;

            Carregar();
        }

        private void Carregar()
        {
            Items.Add("");
            Items.AddRange(Máquina.Máquinas.ToArray());
        }

        public Máquina Seleção
        {
            get { return SelectedItem as Máquina; }
            set { SelectedItem = value; }
        }
    }
}
