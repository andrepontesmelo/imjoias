using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Histórico
{
    /// <summary>
    /// Histórico atribuído à pessoa.
    /// </summary>
    public partial class HistóricoPessoa : Apresentação.Formulários.Quadro, Apresentação.Formulários.IPósCargaSistema
    {
        /// <summary>
        /// Pessoa cujo histórico será exibido.
        /// </summary>
        private Entidades.Pessoa.Pessoa pessoa;


        public HistóricoPessoa()
        {
            InitializeComponent();
        }

        #region Propriedades

        /// <summary>
        /// Pessoa cujo histórico será exibido.
        /// </summary>
        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;

                if (pessoa != null)
                    CarregarHistórico();
                else
                    histórico.Itens.Clear();
            }
        }

        #endregion

        /// <summary>
        /// Carrega o histórico da pessoa.
        /// </summary>
        private void CarregarHistórico()
        {
            Entidades.Pessoa.Histórico[] entidades;

            histórico.Itens.Clear();
            
            entidades = Entidades.Pessoa.Histórico.ObterHistórico(pessoa);

            foreach (Entidades.Pessoa.Histórico item in entidades)
            {
                HistóricoPessoaItem ui;

                ui = new HistóricoPessoaItem(item);
                histórico.Itens.Add(ui);
            }

            histórico.MostrarÚltimo();
        }

        /// <summary>
        /// Ocorre quando usuário deseja adicionar uma nova entrada.
        /// </summary>
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (EditarHistórico dlg = new EditarHistórico(pessoa))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    dlg.Histórico.Cadastrar();
                    histórico.Itens.Add(new HistóricoPessoaItem(dlg.Histórico));
                    histórico.MostrarÚltimo();
                }
            }
        }

        public void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            btnAdicionar.Visible = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroAdicionarHistórico);
        }
    }
}

