using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades;

namespace Apresentação.Usuário.Funcionários
{
    /// <summary>
    /// Lista de ramais.
    /// </summary>
    public partial class Ramais : UserControl, IAoMostrarBaseInferior
    {
        public event EventHandler AoDuploClique;
        private Dictionary<Setor, ListViewGroup> hashSetorGrupo;

        public Ramais()
        {
            InitializeComponent();
        }

        public void AoExibirDaPrimeiraVez(Apresentação.Formulários.BaseInferior baseInferior)
        {
            Setor[] setores = Setor.ObterSetores();
            hashSetorGrupo = new Dictionary<Setor, ListViewGroup>(setores.Length);
            foreach (Setor s in setores)
            {
                ListViewGroup grupo = new ListViewGroup(s.Nome);
                hashSetorGrupo.Add(s, grupo);
                lst.Groups.Add(grupo);
            }
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
                        item.Group = hashSetorGrupo[Setor.ObterSetor(ramal.Setor)];
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
            
            if (!bgRecuperação.IsBusy)
                bgRecuperação.RunWorkerAsync();
        }

        public Entidades.Pessoa.Funcionário Seleção
        {
            get
            {
                if (lst.SelectedItems.Count == 0) return null;

                return Entidades.Pessoa.Funcionário.ObterPessoa(((Entidades.Pessoa.Ramal)lst.SelectedItems[0].Tag).Funcionário);
            }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            if (AoDuploClique != null)
                AoDuploClique(sender, e);

            //UseWaitCursor = true;
            //Entidades.Pessoa.Funcionário funcionário =
            //    Entidades.Pessoa.Funcionário.ObterPessoa(((Entidades.Pessoa.Ramal)lst.SelectedItems[0].Tag).Funcionário);

            //Apresentação.Pessoa.Cadastro.CadastroFuncionário janela
            //    = new Apresentação.Pessoa.Cadastro.CadastroFuncionário(funcionário);

            //UseWaitCursor = false;

            //janela.ShowDialog();
        }
    }
}
