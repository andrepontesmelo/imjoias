using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Importação.Intervenção
{
    public partial class QuestionarDevedor : Form
    {
        public QuestionarDevedor(Entidades.Pessoa.Pessoa pessoa)
        {
            InitializeComponent();

            txtObs.Text = pessoa.Observações;

            classificador.Pessoa = pessoa;
        }
    }
}