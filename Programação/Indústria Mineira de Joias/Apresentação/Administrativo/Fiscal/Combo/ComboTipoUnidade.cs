using Apresentação.Formulário;
using Entidades.Configuração;
using Entidades.Fiscal.Tipo;

namespace Apresentação.Fiscal.Combobox
{
    public partial class ComboTipoUnidade : ComboRígido
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

        protected override bool SeleçãoNula => Seleção == null;
    }
}
