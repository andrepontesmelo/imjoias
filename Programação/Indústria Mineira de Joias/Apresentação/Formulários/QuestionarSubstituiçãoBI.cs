using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public sealed partial class QuestionarSubstituiçãoBI : Apresentação.Formulários.JanelaExplicativa
    {
        public QuestionarSubstituiçãoBI()
        {
            InitializeComponent();
        }

        public QuestionarSubstituiçãoBI(string título, string descrição) : this()
        {
            txtTítulo.Text = título;
            txtDescrição.Text = descrição;
        }
    }
}

