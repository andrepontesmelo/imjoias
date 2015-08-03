using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class Permissões : UserControl
    {
        private Entidades.Pessoa.Funcionário funcionário;

        public Permissões()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Entidade do funcionário.
        /// </summary>
        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public Entidades.Pessoa.Funcionário Entidade
        {
            get { return funcionário; }
            set
            {
                funcionário = value;

                AoAlterarEntidade(value);

                txtUsuário.ReadOnly = value.Cadastrado && !String.IsNullOrEmpty(value.Usuário);
                txtUsuário.Text = value.Usuário;
                lblSenha.Visible = !txtUsuário.ReadOnly;
            }
        }

        public string Usuário
        {
            get { return txtUsuário.Text; }
        }

        private void AoAlterarEntidade(Entidades.Pessoa.Funcionário funcionário)
        {
            AoAlterarEntidade(funcionário, Controls);
        }

        private void AoAlterarEntidade(Entidades.Pessoa.Funcionário funcionário, ControlCollection controles)
        {
            foreach (Control controle in controles)
            {
                AoAlterarEntidade(funcionário, controle.Controls);

                if (controle is ChkPermissão)
                    ((ChkPermissão)controle).AoAlterarEntidade(funcionário);
            }
        }

        private void txtUsuário_Leave(object sender, EventArgs e)
        {
            if (!DesignMode && txtUsuário.Text != funcionário.Usuário)
                funcionário.Usuário = txtUsuário.Text;
        }

        private void btnPrivVendedor_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is GroupBox)
                {
                    GroupBox grupo = (GroupBox)c;

                    foreach (Control subControle in grupo.Controls)
                    {
                        if (subControle is CheckBox)
                            ((CheckBox)subControle).Checked = false;
                    }
                }
            }

            StringBuilder precisaPermissoes = new StringBuilder();

            if (chkCadastroAcesso.Enabled)
                chkCadastroAcesso.Checked = true;
            else
                precisaPermissoes.AppendLine(chkCadastroAcesso.Text);

            if (chkPermissãoAdicionarHistórico.Enabled)
                chkPermissãoAdicionarHistórico.Checked = true;
            else
                precisaPermissoes.AppendLine(chkPermissãoAdicionarHistórico.Text);

            if (chkVendasEditar.Enabled)
                chkVendasEditar.Checked = true;
            else
                precisaPermissoes.AppendLine(chkVendasEditar.Text);

            if (chkConsignadoSaída.Enabled)
                chkConsignadoSaída.Checked = true;
            else
                precisaPermissoes.AppendLine(chkConsignadoSaída.Text);

            if (chkConsignadoRetorno.Enabled)
                chkConsignadoRetorno.Checked = true;
            else
                precisaPermissoes.AppendLine(chkConsignadoRetorno.Text);

            if (precisaPermissoes.Length > 0)
                MessageBox.Show(this, 
                    "Favor solicitar as seguintes permissões para outro funcionário:\n\n" + precisaPermissoes.ToString(),
                    "Permissões adicionais necessárias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        public void FocarTxtUsuário() {
            txtUsuário.Focus();
        }
    }
}
