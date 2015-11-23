using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Configuração;
using System.Globalization;

namespace Entidades.Estoque
{
    public partial class ListaZeragemEstoque : UserControl
    {
        private static CultureInfo cultura = DadosGlobais.Instância.Cultura;

        public ListaZeragemEstoque()
        {
            InitializeComponent();
        }

        public void Carregar()
        {
            listView1.Items.Clear();

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ZeragemEstoque> lst = ZeragemEstoque.Obter();
            e.Result = lst;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<ZeragemEstoque> retorno = (List<ZeragemEstoque>)e.Result;

            listView1.SuspendLayout();

            foreach (ZeragemEstoque z in retorno)
            {
                ListViewItem item = new ListViewItem(z.Data.ToLongDateString() + " " + z.Data.ToLongTimeString());
                item.SubItems.Add(Entidades.Pessoa.Pessoa.ReduzirNome(z.Funcionário.Nome));
                item.SubItems.Add(z.ComissaoVigente.ToString());
                item.SubItems.Add(z.Observações);
                item.Tag = z;
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(colComissãoVigente.Index, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.ResumeLayout();
        }

        public List<ZeragemEstoque> Seleção
        {
            get
            {
                List<ZeragemEstoque> retorno = new List<ZeragemEstoque>();

                if (listView1.SelectedItems.Count == 0)
                    return retorno;

                foreach (ListViewItem i in listView1.SelectedItems)
                    retorno.Add(i.Tag as ZeragemEstoque);

                return retorno;
            }
        }
    }
}
