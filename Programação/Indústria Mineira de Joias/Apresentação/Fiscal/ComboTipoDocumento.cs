using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class ComboTipoDocumento : ComboBox
    {
        public ComboTipoDocumento()
        {
            InitializeComponent();
        }

        public void Carregar()
        {
            Items.AddRange(TipoDocumento.Tipos.ToArray());
        }
    }
}
