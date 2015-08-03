using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Cadastro
{
    partial class Cadastrar : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao passar do painel de defini��o do tipo
        /// de pessoa.
        /// </summary>
        private void painelTipoPessoa_ValidandoTransi��o(object sender, CancelEventArgs e)
        {
            e.Cancel = !(radioPF�sica.Checked ^ radioPJur�dica.Checked);
        }

        /// <summary>
        /// Ocorre ao sair do painel de defini��o do v�nculo
        /// da pessoa-f�sica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void painelV�nculo_ValidandoTransi��o(object sender, CancelEventArgs e)
        {
            e.Cancel = radioPF�sica.Checked && !(radioFuncion�rio.Checked || radioRepresentante.Checked || radioCliente.Checked);

            if (!e.Cancel && radioPF�sica.Checked)
            {
                if (radioRepresentante.Checked &&
                    MessageBox.Show(
                        this,
                        "Voc� deseja mesmo cadastrar um novo REPRESENTANTE?\n\nClientes do varejo, atacado e alto-atacado devem ser sempre cadastrados como cliente e n�o como representante!",
                        "Cadastro de representante",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
                else if (radioFuncion�rio.Checked &&
                    MessageBox.Show(
                        this,
                        "Voc� deseja mesmo cadastrar um novo FUNCION�RIO?",
                        "Cadastro de funcion�rio",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Ocorre ao mudar de painel.
        /// </summary>
        private void assistenteControle_Mudan�aPainel(Apresenta��o.Formul�rios.Assistente.PainelAssistente painel, int nPainel)
        {
            if (nPainel == 1 && radioPJur�dica.Checked)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Tipo de pessoa: f�sica ou jur�dica.
        /// </summary>
        public Entidades.Pessoa.TipoPessoa TipoPessoa
        {
            get
            {
                return radioPF�sica.Checked ? Entidades.Pessoa.TipoPessoa.F�sica : Entidades.Pessoa.TipoPessoa.Jur�dica;
            }
        }

        /// <summary>
        /// Tipo de pessoa-f�sica: cliente (outro), funcion�rio ou representante.
        /// </summary>
        public Entidades.Pessoa.TipoPessoaF�sica TipoPessoaF�sica
        {
            get
            {
                if (radioFuncion�rio.Checked)
                    return Entidades.Pessoa.TipoPessoaF�sica.Funcion�rio;

                if (radioRepresentante.Checked)
                    return Entidades.Pessoa.TipoPessoaF�sica.Representante;

                return Entidades.Pessoa.TipoPessoaF�sica.Outro;
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

