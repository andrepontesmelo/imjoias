using System;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Manutenção.Lista
{
    public partial class ListaMercadorias : UserControl
    {
        public event EventHandler DuploClique;

        public ListaMercadorias()
        {
            InitializeComponent();
        }

        private void lista_DoubleClick(object sender, System.EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }
    }
}
