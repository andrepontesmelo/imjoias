using Entidades.Coaf;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Coaf.Notificações
{
    public partial class ListaNotificações : UserControl
    {
        public event EventHandler AoSelecionar;

        public ListaNotificações()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new Formulários.ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
            lista.ItemSelectionChanged += Lista_ItemSelectionChanged;
        }

        private void Lista_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            AoSelecionar?.Invoke(sender, e);
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((Formulários.ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        public void Carregar()
        {
            if (!bgNotificações.IsBusy)
                bgNotificações.RunWorkerAsync();
        }

        private void bgNotificações_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = Notificação.Obter();
        }

        private void bgNotificações_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            List<Notificação> lstNotificação = (List<Notificação>) e.Result;

            ListViewItem[] itens = CriarItens(lstNotificação);

            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem[] CriarItens(List<Notificação> lstNotificação)
        {
            ListViewItem[] resultado = new ListViewItem[lstNotificação.Count];

            int idx = 0;
            foreach (Notificação notificação in lstNotificação)
                resultado[idx++] = CriarItem(notificação);

            return resultado;
        }

        private ListViewItem CriarItem(Notificação notificação)
        {
            ListViewItem item = new ListViewItem(new string[lista.Columns.Count]);

            item.SubItems[colNotificação.Index].Text = notificação.Código.ToString();
            item.SubItems[colData.Index].Text = notificação.Data.ToShortDateString();
            item.SubItems[colNome.Index].Text = notificação.Nome;
            item.SubItems[colInício.Index].Text = notificação.OcorrênciaInício.ToShortDateString();
            item.SubItems[colFim.Index].Text = notificação.OcorrênciaFim.ToShortDateString();
            item.SubItems[colValor.Index].Text = notificação.Valor.ToString("C");
            item.Tag = notificação;

            return item;
        }

        public Notificação Seleção
        {
            get
            {
                if (lista.SelectedItems.Count == 0)
                    return null;

                return lista.SelectedItems[0].Tag as Notificação;
            }
        }
    }
}
