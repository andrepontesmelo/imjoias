using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Usuário.Funcionários
{
    public partial class AlterarSenha : Apresentação.Formulários.JanelaExplicativa
    {
        public AlterarSenha()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNovaSenha.Text != txtConfirmação.Text)
            {
                MessageBox.Show(
                    this,
                    "A nova senha não confere!",
                    "Alterar senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (txtNovaSenha.Text.Length < 4)
            {
                MessageBox.Show(
                    this,
                    "A nova senha é muito curta! Utilize pelo menos 4 caracteres.",
                    "Alterar senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            AguardeDB.Mostrar();

            try
            {
                Entidades.Pessoa.Funcionário.FuncionárioAtual.AlterarSenha(txtSenhaAnterior.Text, txtNovaSenha.Text);

                DialogResult = DialogResult.OK;
                Close();

                AguardeDB.Fechar();
            }
            catch
            {
                AguardeDB.Fechar();

                MessageBox.Show(
                    this,
                    "Não foi possível alterar a senha. Verifique os dados digitados.",
                    "Alterar senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

