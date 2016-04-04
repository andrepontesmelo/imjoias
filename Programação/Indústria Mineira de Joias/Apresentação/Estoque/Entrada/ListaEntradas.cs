using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Estoque.Entrada
{
    public partial class ListaEntradas : UserControl
    {
        public event EventHandler AoDuploClique;
        public event EventHandler AoExcluir;

        public ListaEntradas()
        {
            InitializeComponent();
        }

        internal void Carregar()
        {
            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }


        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Entidades.Estoque.Entrada> lst = (List<Entidades.Estoque.Entrada>)e.Result;

            listView1.SuspendLayout();
            listView1.Items.Clear();
            foreach (Entidades.Estoque.Entrada entrada in lst)
            {
                ListViewItem i = new ListViewItem(entrada.Código.ToString());
                i.SubItems.Add(entrada.Data.ToLongDateString());
                i.SubItems.Add(Entidades.Pessoa.Pessoa.ReduzirNome(entrada.DigitadoPor.Nome));
                i.SubItems.Add(entrada.Observações);
                i.Tag = entrada;
                listView1.Items.Add(i);
            }
            listView1.ResumeLayout();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Entidades.Estoque.Entrada.Obter();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (AoDuploClique != null)
                AoDuploClique(sender, e);
        }

        public List<Entidades.Estoque.Entrada> Seleção
        {
            get
            {
                List<Entidades.Estoque.Entrada> lista = new List<Entidades.Estoque.Entrada>();

                if (listView1.SelectedItems.Count == 0)
                    return lista; 

                foreach (ListViewItem i in listView1.SelectedItems)
                    lista.Add(i.Tag as Entidades.Estoque.Entrada);

                return lista;
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
                SelecionarTudo();

            if (e.KeyCode == Keys.Delete && AoExcluir != null)
                AoExcluir(sender, e);
        }

        private void SelecionarTudo()
        {
            listView1.SuspendLayout();
            foreach (ListViewItem i in listView1.Items)
                i.Selected = true;
            listView1.ResumeLayout();
        }
    }
}
