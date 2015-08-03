using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Venda
{
    public partial class JanelaEscolhaDatasPagamento : Apresentação.Formulários.JanelaExplicativa
    {
        List<DateTime> datas = new List<DateTime>();

        public List<DateTime> Datas
        {
            get { return datas; }
            set 
            { 
                datas = value;
                RefazLista();
            }
        }
                 
        public JanelaEscolhaDatasPagamento()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //if (!datas.Contains(monthCalendar1.SelectionStart))
            //    datas.Add(monthCalendar1.SelectionStart);

            //monthCalendar1.SelectionEnd = monthCalendar1.SelectionStart;

            //RefazLista();
        }

        private void RefazLista()
        {
            lstDatas.Items.Clear();

            datas.Sort();

            foreach (DateTime t in datas)
                lstDatas.Items.Add(t.ToShortDateString());

            monthCalendar1.BoldedDates = datas.ToArray();
        }

        private void lstDatas_DoubleClick(object sender, EventArgs e)
        {
            if (lstDatas.SelectedItem == null)
                return;

            lstDatas.Items.Remove(lstDatas.SelectedItem);

            datas.Clear();

            foreach (string s in lstDatas.Items)
            {
                DateTime t;
                DateTime.TryParse(s, out t);
                datas.Add(t);
            }

            // Nao é necessário, só para garantir:
            RefazLista();
        }

        private void lstDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDatas.SelectedItem != null)
            {
                DateTime t;
                DateTime.TryParse(lstDatas.SelectedItem.ToString(), out t);
                monthCalendar1.SelectionStart = t;
                monthCalendar1.SelectionEnd = t;
            }
        }

        private void btnRemoveData_Click(object sender, EventArgs e)
        {
            if ((lstDatas.SelectedItems.Count == 0
                ) && (lstDatas.Items.Count > 0))
                    lstDatas.SelectedItems.Add(lstDatas.Items[lstDatas.Items.Count - 1]);

            lstDatas_DoubleClick(sender, e);
        }

        private void btnAdicionarData_Click(object sender, EventArgs e)
        {
            if (!datas.Contains(monthCalendar1.SelectionStart))
                datas.Add(monthCalendar1.SelectionStart);

            monthCalendar1.SelectionEnd = monthCalendar1.SelectionStart;

            RefazLista();
        }
    }
}