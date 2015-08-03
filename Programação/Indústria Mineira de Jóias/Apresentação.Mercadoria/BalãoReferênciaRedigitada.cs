using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    partial class BalãoReferênciaRedigitada : Balloon.NET.BalloonWindow
    {
        public BalãoReferênciaRedigitada()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void BalãoReferênciaRedigitada_Shown(object sender, EventArgs e)
        {
            Apresentação.Útil.Beepador.Dica();
        }
    }
}

