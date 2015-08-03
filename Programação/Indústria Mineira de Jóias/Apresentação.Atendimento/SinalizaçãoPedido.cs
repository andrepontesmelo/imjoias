using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Atendimento
{
    public partial class SinalizaçãoPedido : Apresentação.Formulários.QuadroSimples
    {
        public new EventHandler Click;

        public SinalizaçãoPedido()
        {
            InitializeComponent();
        }

        private void AoClicar(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}
