using Entidades.Fiscal;
using System;

using System.Windows.Forms;

namespace Apresentação.Financeiro.Coaf.Lista
{
    public partial class ListaSaída : UserControl
    {
        public event EventHandler DuploClique;

        public ListaSaída()
        {
            InitializeComponent();
        }

        public SaídaFiscal ObterSaídaSelecionada()
        {
            return SaídaFiscal.ObterEntidade("1003@1");
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }
    }
}
