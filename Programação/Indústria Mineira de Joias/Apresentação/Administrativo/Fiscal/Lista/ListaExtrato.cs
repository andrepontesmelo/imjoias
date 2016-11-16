using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaExtrato : UserControl
    {
        public ListaExtrato()
        {
            InitializeComponent();
        }
        
        public void Carregar(string referência, DateTime início, DateTime fim)
        {
            CarregarItens(CriarItens(Extrato.ObterEstoqueAcumulado(referência, início, fim)));
        }

        private void CarregarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem[] CriarItens(List<Extrato> entidades)
        {
            ListViewItem[] itens = new ListViewItem[entidades.Count];
            int x = 0;

            foreach (var entidade in entidades)
                itens[x++] = CriarItem(entidade);

            return itens;
        }

        private ListViewItem CriarItem(Extrato entidade)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.Tag = entidade;
            item.SubItems[colData.Index].Text = entidade.DataFormatada;
            item.SubItems[colEstoque.Index].Text = entidade.Estoque.ToString();
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colTipoDocumento.Index].Text = entidade.TipoDocumento?.Nome;
            item.SubItems[colTipoExtrato.Index].Text = entidade.TipoExtrato;
            item.SubItems[colValor.Index].Text = entidade.Valor.ToString("C");

            return item;
        }
    }
}
