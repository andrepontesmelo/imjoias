using Entidades.Fiscal.Tipo;

namespace Apresentação.Fiscal.Combobox
{
    public partial class ComboTipoUnidade : System.Windows.Forms.ComboBox
    {
        public ComboTipoUnidade()
        {
            InitializeComponent();
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
    }
}
