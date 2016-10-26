using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
    public partial class QuadroOp��o : UserControl
    {
        public new event EventHandler Click;

        public string T�tulo { get { return lblT�tulo.Text; } set { lblT�tulo.Text = value; } }
        public string Descri��o { get { return lblDescri��o.Text; } set { lblDescri��o.Text = value; } }
        public Image �cone { get { return pic.Image; } set { pic.Image = value; } }

        public QuadroOp��o()
        {
            InitializeComponent();
        }

        private void AoClicar(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}

