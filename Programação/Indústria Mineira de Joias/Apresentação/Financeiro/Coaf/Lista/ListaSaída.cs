using Entidades.Fiscal;
using System;

using System.Windows.Forms;
using System.Collections.Generic;

namespace Apresentação.Financeiro.Coaf.Lista
{
    public partial class ListaSaída : UserControl
    {
        public event EventHandler DuploClique;

        public ListaSaída()
        {
            InitializeComponent();
        }

        public SaídaFiscal ObterSaídaSelecionada()
        {
            return SaídaFiscal.ObterEntidade("1003@1");
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }


        public void Carregar(string cpfCnpj)
        {
            lista.Items.Clear();
            lista.Items.AddRange(CriarItens(SaídaFiscal.Obter(cpfCnpj)));
        }

        private ListViewItem[] CriarItens(List<SaídaFiscal> saídas)
        {
            ListViewItem[] resultado = new ListViewItem[saídas.Count];
            int x = 0;

            foreach (SaídaFiscal saída in saídas)
                resultado[x++] = CriarItem(saída);

            return resultado;
        }

        private ListViewItem CriarItem(SaídaFiscal saída)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.AddRange(new string[] { "", "", "", "", "", "" });

            item.SubItems[colDataSaída.Index].Text = saída.DataSaída.ToShortDateString();
            item.SubItems[colSaída.Index].Text = saída.Id;
            item.SubItems[colTotal.Index].Text = saída.ValorTotal.ToString("C");
            item.SubItems[colVenda.Index].Text = saída.Venda.ToString();

            if (saída.Cancelada)
                item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Strikeout);

            return item;
        }
    }
}
