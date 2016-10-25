using System;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public partial class ListViewUsabilidade : ListView
    {
        public event EventHandler AoExcluir;

        public ListViewUsabilidade()
        {
            InitializeComponent();
        }

        private void ListViewUsabilidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
                SelecionarTudo();

            if (e.KeyCode == Keys.Delete)
                AoExcluir?.Invoke(sender, e);
        }

        private void SelecionarTudo()
        {
            SuspendLayout();

            foreach (ListViewItem i in Items)
                i.Selected = true;

            ResumeLayout();
        }
    }
}
