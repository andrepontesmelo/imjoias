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
        
        public void Carregar(string referência, Fechamento fechamento)
        {
            CarregarItens(CriarItens(Extrato.ObterEstoqueAcumulado(referência, fechamento)));
        }

        private void CarregarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);

            colIdPai.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colIdFilho.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colFabricação.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

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
            item.SubItems[colQuantidade.Index].Text = Math.Abs(entidade.Quantidade).ToString();
            item.SubItems[colTipoDocumento.Index].Text = entidade.TipoDocumento?.Nome;
            item.SubItems[colTipoExtrato.Index].Text = entidade.TipoExtrato;
            item.SubItems[colValor.Index].Text = entidade.Valor.ToString("C");
            item.SubItems[colIdPai.Index].Text = entidade.IdPai;
            item.SubItems[colIdFilho.Index].Text = entidade.IdFilho;
            item.SubItems[colFabricação.Index].Text = entidade.Fabricação.ToString();

            return item;
        }
    }
}

