using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Manuten��o.Tabela
{
    public partial class JanelaNovaTabela : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public JanelaNovaTabela()
        {
            InitializeComponent();
        }

        private void JanelaNovaTabela_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Deve-se cadastrar aqui");
        }
    }
}

