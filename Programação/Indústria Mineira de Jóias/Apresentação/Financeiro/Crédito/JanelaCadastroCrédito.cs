using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Crédito
{
    public partial class JanelaCadastroCrédito : JanelaExplicativa
    {
        private Entidades.Financeiro.Crédito entidade;

        public JanelaCadastroCrédito()
        {
            InitializeComponent();
        }

        public void AbrirParaCadastro(Entidades.Pessoa.Pessoa pessoa)
        {
            entidade = new Entidades.Financeiro.Crédito();
            entidade.Pessoa = pessoa;
            CarregarEntidade(entidade);
            txtValor.Text = "";
            txtValor.Focus();
        }

        public void CarregarEntidade(Entidades.Financeiro.Crédito entidade)
        {
            this.entidade = entidade;

            txtDescrição.Text = entidade.Descrição;
            txtValor.Double = entidade.Valor;
            dateTimePicker1.Value = entidade.Data;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            entidade.Descrição = txtDescrição.Text;
            entidade.Valor = txtValor.Double;
            entidade.Data = dateTimePicker1.Value;

            if (entidade.Cadastrado)
                entidade.Atualizar();
            else
                entidade.Cadastrar();

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
