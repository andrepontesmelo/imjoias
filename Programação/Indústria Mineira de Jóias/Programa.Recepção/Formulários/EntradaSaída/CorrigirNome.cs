using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;


namespace Programa.Recepção.Formulários.EntradaSaída
{
    public partial class CorrigirNome : JanelaExplicativa
    {
        public CorrigirNome(string nome)
        {
            InitializeComponent();

            this.txtNome.Text = nome;
        }

        public string Nome
        {
            get { return txtNome.Text; }
        }
    }
}