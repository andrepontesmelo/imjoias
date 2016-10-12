using Apresentação.Formulários;
using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Janela
{
    public partial class JanelaCFOP : JanelaExplicativa
    {
        public delegate void CFOPDelegate (Cfop cfop);
        public event CFOPDelegate AoEscolher;
        List<Cfop> entidades = null;

        public JanelaCFOP()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Carregar()
        {
            bg.RunWorkerCompleted += bg_RunWorkerCompleted;
            bg.DoWork += bg_DoWork;
            bg.RunWorkerAsync();
            UseWaitCursor = true;
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            entidades = Cfop.Obter();
            // e.Result = entidades;
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //List<Cfop> entidades = (List<Cfop>)e.Result;
            lista.Items.Clear();
 
            foreach (Cfop item in entidades)
            {
                AdicionaItem(item);
            }
            
            colDescrição.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            UseWaitCursor = false;
        }

        private void AdicionaItem(Cfop item)
        {
            ListViewItem i = new ListViewItem(item.Codigo.ToString());
            i.Tag = item;
            i.SubItems.Add(item.Descricao);
            //novosItens.Add(i);
            lista.Items.Add(i);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count == 0)
                return;

            if (AoEscolher != null)
                AoEscolher((Cfop) lista.SelectedItems[0].Tag);

            Hide();
        }

        private void JanelaCFOP_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            lista.BeginUpdate();
            lista.Items.Clear();
            foreach (Cfop i in entidades)
            {
                if (i.Descricao.ToLowerInvariant().Contains(txtBusca.Text.ToLowerInvariant()))
                    AdicionaItem(i);
            }

            lista.EndUpdate();

        }
    }
}
