using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
    public sealed partial class QuestionarSubstitui��oBI : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public QuestionarSubstitui��oBI()
        {
            InitializeComponent();
        }

        public QuestionarSubstitui��oBI(string t�tulo, string descri��o) : this()
        {
            txtT�tulo.Text = t�tulo;
            txtDescri��o.Text = descri��o;
        }
    }
}

