using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
    public sealed partial class Notifica��oSimples : Apresenta��o.Formul�rios.Notifica��o
    {
        public Notifica��oSimples(string t�tulo, string descri��o)
        {
            InitializeComponent();

            T�tulo = t�tulo;
            Descri��o = descri��o;
        }

        public string Descri��o
        {
            get { return lblDescri��o.Text; }
            set { lblDescri��o.Text = value; }
        }

        public override string ToString()
        {
            return Descri��o;
        }
    }
}

