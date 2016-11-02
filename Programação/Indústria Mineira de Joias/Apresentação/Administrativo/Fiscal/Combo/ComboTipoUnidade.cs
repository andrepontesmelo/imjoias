using Entidades.Configuração;
using Entidades.Fiscal.Tipo;

namespace Apresentação.Fiscal.Combobox
{
    public partial class ComboTipoUnidade : System.Windows.Forms.ComboBox
    {
        public ComboTipoUnidade()
        {
            InitializeComponent();

            if (DadosGlobais.ModoDesenho)
                return;

            Items.Clear();
            Items.AddRange(TipoUnidade.Tipos.ToArray());
        }

        public TipoUnidade Seleção
        {
            get
            {
                return SelectedItem as TipoUnidade;
            }
            set
            {
                SelectedItem = value;
            }
        }

        private void ComboTipoUnidade_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Seleção == null;
        }
    }
}
