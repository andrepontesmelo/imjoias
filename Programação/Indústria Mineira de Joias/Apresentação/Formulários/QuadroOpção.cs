using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public partial class QuadroOpção : UserControl
    {
        public new event EventHandler Click;

        public string Título { get { return lblTítulo.Text; } set { lblTítulo.Text = value; } }
        public string Descrição { get { return lblDescrição.Text; } set { lblDescrição.Text = value; } }
        public Image Ícone { get { return pic.Image; } set { pic.Image = value; } }

        public QuadroOpção()
        {
            InitializeComponent();
        }

        private void AoClicar(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}

