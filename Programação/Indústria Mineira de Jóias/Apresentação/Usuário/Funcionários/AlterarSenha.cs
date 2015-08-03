using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Usu�rio.Funcion�rios
{
    public partial class AlterarSenha : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public AlterarSenha()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNovaSenha.Text != txtConfirma��o.Text)
            {
                MessageBox.Show(
                    this,
                    "A nova senha n�o confere!",
                    "Alterar senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (txtNovaSenha.Text.Length < 4)
            {
                MessageBox.Show(
                    this,
                    "A nova senha � muito curta! Utilize pelo menos 4 caracteres.",
                    "Alterar senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            AguardeDB.Mostrar();

            try
            {
                Entidades.Pessoa.Funcion�rio.Funcion�rioAtual.AlterarSenha(txtSenhaAnterior.Text, txtNovaSenha.Text);

                DialogResult = DialogResult.OK;
                Close();

                AguardeDB.Fechar();
            }
            catch
            {
                AguardeDB.Fechar();

                MessageBox.Show(
                    this,
                    "N�o foi poss�vel alterar a senha. Verifique os dados digitados.",
                    "Alterar senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

