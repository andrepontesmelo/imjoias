using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.�lbum.Edi��o.Fotos
{
    public partial class Bal�oInformarTratamento : Balloon.NET.BalloonWindow
    {
        public Bal�oInformarTratamento()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}

