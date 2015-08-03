﻿using System;
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
        private Entidades.Crédito entidade;

        //public Entidades.Crédito Entidade
        //{
        //    get { return entidade; }
        //}

        public JanelaCadastroCrédito()
        {
            InitializeComponent();
        }

        public void AbrirParaCadastro(Entidades.Pessoa.Pessoa pessoa)
        {
            entidade = new Entidades.Crédito();
            entidade.Pessoa = pessoa;
            CarregarEntidade(entidade);
            txtValor.Text = "";
            txtValor.Focus();
        }

        public void CarregarEntidade(Entidades.Crédito entidade)
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
    }
}
