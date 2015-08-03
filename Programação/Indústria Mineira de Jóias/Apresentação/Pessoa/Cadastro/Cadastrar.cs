using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    partial class Cadastrar : Apresentação.Formulários.JanelaExplicativa
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao passar do painel de definição do tipo
        /// de pessoa.
        /// </summary>
        private void painelTipoPessoa_ValidandoTransição(object sender, CancelEventArgs e)
        {
            e.Cancel = !(radioPFísica.Checked ^ radioPJurídica.Checked);
        }

        /// <summary>
        /// Ocorre ao sair do painel de definição do vínculo
        /// da pessoa-física.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void painelVínculo_ValidandoTransição(object sender, CancelEventArgs e)
        {
            e.Cancel = radioPFísica.Checked && !(radioFuncionário.Checked || radioRepresentante.Checked || radioCliente.Checked);

            if (!e.Cancel && radioPFísica.Checked)
            {
                if (radioRepresentante.Checked &&
                    MessageBox.Show(
                        this,
                        "Você deseja mesmo cadastrar um novo REPRESENTANTE?\n\nClientes do varejo, atacado e alto-atacado devem ser sempre cadastrados como cliente e não como representante!",
                        "Cadastro de representante",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
                else if (radioFuncionário.Checked &&
                    MessageBox.Show(
                        this,
                        "Você deseja mesmo cadastrar um novo FUNCIONÁRIO?",
                        "Cadastro de funcionário",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Ocorre ao mudar de painel.
        /// </summary>
        private void assistenteControle_MudançaPainel(Apresentação.Formulários.Assistente.PainelAssistente painel, int nPainel)
        {
            if (nPainel == 1 && radioPJurídica.Checked)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Tipo de pessoa: física ou jurídica.
        /// </summary>
        public Entidades.Pessoa.TipoPessoa TipoPessoa
        {
            get
            {
                return radioPFísica.Checked ? Entidades.Pessoa.TipoPessoa.Física : Entidades.Pessoa.TipoPessoa.Jurídica;
            }
        }

        /// <summary>
        /// Tipo de pessoa-física: cliente (outro), funcionário ou representante.
        /// </summary>
        public Entidades.Pessoa.TipoPessoaFísica TipoPessoaFísica
        {
            get
            {
                if (radioFuncionário.Checked)
                    return Entidades.Pessoa.TipoPessoaFísica.Funcionário;

                if (radioRepresentante.Checked)
                    return Entidades.Pessoa.TipoPessoaFísica.Representante;

                return Entidades.Pessoa.TipoPessoaFísica.Outro;
            }
        }

        /// <summary>
        /// Ocorre ao terminar o assistente.
        /// </summary>
        private void assistenteControle_Terminado(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}

