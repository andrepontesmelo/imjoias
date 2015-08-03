using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Manutenção.Tabela
{
    public partial class CmbTabelaPreço : UserControl
    {
        public CmbTabelaPreço()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            JanelaNovaTabela janela = new JanelaNovaTabela();
            janela.ShowDialog(this);
        }

    }
}
