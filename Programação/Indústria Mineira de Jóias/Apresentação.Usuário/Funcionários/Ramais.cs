using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Usuário.Funcionários
{
    /// <summary>
    /// Lista de ramais.
    /// </summary>
    public partial class Ramais : UserControl, IAoMostrarBaseInferior
    {
        public Ramais()
        {
            InitializeComponent();
        }

        public void AoExibirDaPrimeiraVez(Apresentação.Formulários.BaseInferior baseInferior)
        {
        }

        public void AoExibir(Apresentação.Formulários.BaseInferior baseInferior)
        {
            Atualizar();
        }

        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Entidades.Pessoa.Ramal.ObterRamais();
        }

        private delegate void bgRecuperação_RunWorkerCompletedCallBack(object sender, RunWorkerCompletedEventArgs e);
        
        private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (lst.InvokeRequired)
            {
                bgRecuperação_RunWorkerCompletedCallBack c = new bgRecuperação_RunWorkerCompletedCallBack(bgRecuperação_RunWorkerCompleted);
                lst.BeginInvoke(c, sender, e);
            }
            else
            {

                lst.Items.Clear();

                if (!e.Cancelled)

                    foreach (Entidades.Pessoa.Ramal ramal in (Entidades.Pessoa.Ramal[])e.Result)
                    {
                        ListViewItem item = new ListViewItem(new string[] { ramal.Nome, ramal.Número.ToString() });
                        item.Tag = ramal;

                        lst.Items.Add(item);
                    }

                Cursor = Cursors.Default;
            }
        }

        private void lst_Resize(object sender, EventArgs e)
        {
            colNome.Width = lst.ClientSize.Width - colRamal.Width - 20;
        }

        internal void Atualizar()
        {
            Cursor = Cursors.AppStarting;
            bgRecuperação.RunWorkerAsync();
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            Entidades.Pessoa.Funcionário funcionário =
            (Entidades.Pessoa.Funcionário)Entidades.Pessoa.Pessoa.ObterPessoa(
            ((Entidades.Pessoa.Ramal)lst.SelectedItems[0].Tag).Funcionário);

            Apresentação.Pessoa.Cadastro.CadastroFuncionário janela
                = new Apresentação.Pessoa.Cadastro.CadastroFuncionário(funcionário);

            janela.ShowDialog();
        }
    }
}
