using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    public partial class SinalizaçãoMercadoriaEmFalta : Apresentação.Formulários.QuadroSimples
    {
        public new EventHandler Click;

        public SinalizaçãoMercadoriaEmFalta()
        {
            InitializeComponent();
        }

        private void AoClicar(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}
