using Entidades.Fiscal;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Apresentação.Administrativo.Fiscal.Combo
{
    public partial class ComboFechamento : UserControl
    {
        public event EventHandler SelectedIndexChanged;

        public ComboFechamento()
        {
            InitializeComponent();
            cmb.SelectedIndexChanged += Cmb_SelectedIndexChanged;
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(sender, e);
        }

        public object Seleção => cmb.SelectedItem;

        public void Carregar()
        {
            CarregarItens(Fechamento.Obter());
        }

        private void CarregarItens(List<Fechamento> entidades)
        {
            cmb.Items.Clear();
            cmb.Items.AddRange(entidades.ToArray());
        }
    }
}
