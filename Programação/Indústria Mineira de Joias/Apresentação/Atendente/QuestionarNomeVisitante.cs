using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Atendimento.Atendente
{
    /// <summary>
    /// Janela para questionar se deve cadastrar o nome
    /// escolhido ou utilizar outro cadastro, como
    /// consumidor final.
    /// </summary>
    public partial class QuestionarNomeVisitante : JanelaExplicativa
    {
        public QuestionarNomeVisitante(string nome)
        {
            InitializeComponent();

            txtNome.Text = nome;

            optCriar.Enabled = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroEditar);
        }

        private void optCriar_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
        }

        public Entidades.Pessoa.Pessoa Pessoa
        {
            get
            {
                if (optCriar.Checked)
                    return Apresentação.Pessoa.Cadastro.CadastroPessoa.MostrarCadastrar();
                else if (optProcurar.Checked)
                    return Apresentação.Pessoa.Consultas.ProcurarPessoa.Procurar(null);
                else if (optConsumidorFinal.Checked)
                {
                    Entidades.Pessoa.Pessoa pessoa = Entidades.Pessoa.Pessoa.ObterConsumidorFinal();

                    if (pessoa.Nome.ToLower() == "consumidor final")
                        return pessoa;
                    else
                        return null;
                }
                else
                    throw new NotSupportedException();
            }
        }
    }
}