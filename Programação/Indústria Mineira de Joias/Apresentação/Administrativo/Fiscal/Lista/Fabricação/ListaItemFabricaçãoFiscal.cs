using Entidades.Fiscal.Fabricação;
using Entidades.Fiscal.Registro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaItemFabricaçãoFiscal : UserControl
    {
        public event EventHandler AoExcluir;
        public event EventHandler AoSelecionar;
        private FabricaçãoFiscal fabricação;
        private Dictionary<string, decimal> hashSaldoAnterior, hashSaldoPosterior;


        public ListaItemFabricaçãoFiscal()
        {
            InitializeComponent();
            lista.AoExcluir += Lista_AoExcluir;
            lista.SelectedIndexChanged += Lista_SelectedIndexChanged;
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            AoSelecionar?.Invoke(sender, e);
        }

        private void Lista_AoExcluir(object sender, EventArgs e)
        {
            AoExcluir?.Invoke(sender, e);
        }

        public ItemFabricaçãoFiscal Seleção => lista.SelectedItems.Count > 0 ? lista.SelectedItems[0].Tag as ItemFabricaçãoFiscal : null;

        public void Carregar(FabricaçãoFiscal fabricação)
        {
            this.fabricação = fabricação;

            hashSaldoAnterior = InventárioRelativo.ObterHashReferênciaQuantidadeInventárioAnterior(fabricação.Data);
            hashSaldoPosterior = InventárioRelativo.ObterHashReferênciaQuantidadeInventárioPosterior(fabricação.Data);

            AdicionarItens(CriarItensGráficos(ObterItensEntidade(fabricação)));
        }

        protected virtual List<ItemFabricaçãoFiscal> ObterItensEntidade(FabricaçãoFiscal fabricação)
        {
            throw new NotImplementedException();
        }

        private ListViewItem[] CriarItensGráficos(List<ItemFabricaçãoFiscal> entidades)
        {
            ListViewItem[] itens = new ListViewItem[entidades.Count];
            int x = 0;

            foreach (var entidade in entidades)
                itens[x++] = CriarItem(entidade);

            return itens;
        }

        private void AdicionarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem CriarItem(ItemFabricaçãoFiscal entidade)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colCódigo.Index].Text = entidade.Código.ToString();
            item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
            item.SubItems[colCFOP.Index].Text = entidade.CFOP.ToString();
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colDescrição.Index].Text = entidade.Mercadoria?.Descrição;
            item.SubItems[colTipo.Index].Text = entidade.Mercadoria?.TipoUnidadeComercial.Nome;
            item.SubItems[colValor.Index].Text = entidade.Valor.ToString("C");

            decimal saldoAnterior = 0;
            hashSaldoAnterior.TryGetValue(entidade.Referência, out saldoAnterior);
            item.SubItems[colSaldoAnterior.Index].Text = saldoAnterior.ToString();
            item.SubItems[colSaldoPosterior.Index].Text = hashSaldoPosterior[entidade.Referência].ToString();

            item.Tag = entidade;

            return item;
        }

        public List<ItemFabricaçãoFiscal> ObterSeleção()
        {
            List<ItemFabricaçãoFiscal> resultado = new List<ItemFabricaçãoFiscal>();

            foreach (ListViewItem item in lista.SelectedItems)
                resultado.Add(item.Tag as ItemFabricaçãoFiscal);

            return resultado;
        }
    }
}
