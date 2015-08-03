using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Manutenção.Tabela
{
    public partial class ListaTabelasPreços : UserControl
    {
        public ListaTabelasPreços()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            new JanelaNovaTabela().ShowDialog(this);
        }
    }
}
