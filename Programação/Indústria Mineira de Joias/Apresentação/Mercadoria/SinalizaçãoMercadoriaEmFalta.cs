using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria
{
    public partial class Sinaliza��oMercadoriaEmFalta : Apresenta��o.Formul�rios.QuadroSimples
    {
        public new EventHandler Click;

        public Sinaliza��oMercadoriaEmFalta()
        {
            InitializeComponent();
        }

        private void AoClicar(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}
