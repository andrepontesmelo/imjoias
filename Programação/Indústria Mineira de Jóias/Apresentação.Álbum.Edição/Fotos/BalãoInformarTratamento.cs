using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Álbum.Edição.Fotos
{
    public partial class BalãoInformarTratamento : Balloon.NET.BalloonWindow
    {
        public BalãoInformarTratamento()
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

