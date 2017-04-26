using Entidades.Coaf;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Apresentação.Financeiro.Coaf.Notificações
{
    public partial class ListaNotificações : UserControl
    {
        public ListaNotificações()
        {
            InitializeComponent();
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

            return item;
        }
    }
}
