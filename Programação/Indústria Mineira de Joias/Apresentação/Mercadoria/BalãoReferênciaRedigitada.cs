using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neg�cio;

namespace Apresenta��o.Mercadoria
{
    partial class Bal�oRefer�nciaRedigitada : Balloon.NET.BalloonWindow
    {
        public Bal�oRefer�nciaRedigitada()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void Bal�oRefer�nciaRedigitada_Shown(object sender, EventArgs e)
        {
            Beepador.Dica();
        }
    }
}

