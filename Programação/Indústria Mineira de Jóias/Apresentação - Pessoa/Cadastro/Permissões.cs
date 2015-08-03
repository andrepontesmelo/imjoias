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

                txtUsuário.ReadOnly = value.Cadastrado && value.Usuário != null && value.Usuário != "";
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
            chkCadastroAcesso.Checked = true;
            chkPermissãoAdicionarHistórico.Checked = true;
            chkVendasEditar.Checked = true;
            chkConsignadoSaída.Checked = true;
            chkConsignadoRetorno.Checked = true;
        }
    }
}
