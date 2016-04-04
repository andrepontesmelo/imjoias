using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Hist�rico
{
    /// <summary>
    /// Hist�rico atribu�do � pessoa.
    /// </summary>
    public partial class Hist�ricoPessoa : Apresenta��o.Formul�rios.Quadro, Apresenta��o.Formul�rios.IP�sCargaSistema
    {
        /// <summary>
        /// Pessoa cujo hist�rico ser� exibido.
        /// </summary>
        private Entidades.Pessoa.Pessoa pessoa;


        public Hist�ricoPessoa()
        {
            InitializeComponent();
        }

        #region Propriedades

        /// <summary>
        /// Pessoa cujo hist�rico ser� exibido.
        /// </summary>
        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;

                if (pessoa != null)
                    CarregarHist�rico();
                else
                    hist�rico.Itens.Clear();
            }
        }

        #endregion

        /// <summary>
        /// Carrega o hist�rico da pessoa.
        /// </summary>
        private void CarregarHist�rico()
        {
            Entidades.Pessoa.Hist�rico[] entidades;

            hist�rico.Itens.Clear();
            
            entidades = Entidades.Pessoa.Hist�rico.ObterHist�rico(pessoa);

            foreach (Entidades.Pessoa.Hist�rico item in entidades)
            {
                Hist�ricoPessoaItem ui;

                ui = new Hist�ricoPessoaItem(item);
                hist�rico.Itens.Add(ui);
            }

            hist�rico.Mostrar�ltimo();
        }

        /// <summary>
        /// Ocorre quando usu�rio deseja adicionar uma nova entrada.
        /// </summary>
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (EditarHist�rico dlg = new EditarHist�rico(pessoa))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    dlg.Hist�rico.Cadastrar();
                    hist�rico.Itens.Add(new Hist�ricoPessoaItem(dlg.Hist�rico));
                    hist�rico.Mostrar�ltimo();
                }
            }
        }

        public void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            btnAdicionar.Visible = Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.CadastroAdicionarHist�rico);
        }
    }
}

