using System;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Coaf.Lista
{
    public partial class ListaPessoa : UserControl
    {
        public event EventHandler DuploClique;

        public ListaPessoa()
        {
            InitializeComponent();
        }

        public int? ObterPessoaSelecionada()
        {
            return 28816;
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }
    }
}
