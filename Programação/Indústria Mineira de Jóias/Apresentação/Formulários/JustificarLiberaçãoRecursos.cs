using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Formulário de justificativa para liberação de recursos.
    /// </summary>
    partial class JustificarLiberaçãoRecursos : JanelaExplicativa
    {
        public JustificarLiberaçãoRecursos(Entidades.Pessoa.Pessoa autorizada, string responsável, string recurso)
        {
            InitializeComponent();

            txtPessoa.Text = autorizada.Nome;
            txtResponsável.Text = responsável;
            txtRecurso.Text = recurso;
        }

        private void JustificarLiberaçãoRecursos_Shown(object sender, EventArgs e)
        {
            txtMotivo.Focus();
        }

        public string Motivo
        {
            get { return txtMotivo.Text; }
        }

        internal string Senha
        {
            get { return txtSenha.Text; }
        }
    }
}