using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Atendimento
{
    public partial class Sinaliza��oPedido : Apresenta��o.Formul�rios.QuadroSimples
    {
        public new EventHandler Click;

        public Sinaliza��oPedido()
        {
            InitializeComponent();
        }

        private void AoClicar(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}
