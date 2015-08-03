using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Entidades.Mercadoria;
using System.Collections;

namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    public partial class ListaComponentesCusto : UserControl
    {
        // Atributos
        private Dictionary<ListViewItem, ComponenteCusto> hashItemCCusto;

        // Eventos
        public event EventHandler ClicouAdicionar;
        public event EventHandler ClicouExcluir;
        public event EventHandler ClicouAlterar;

        public ComponenteCusto Selecionado
        {
            get
            {
                if (lst.SelectedItems.Count == 0) return null;

                return hashItemCCusto[(ListViewItem)lst.SelectedItems[0]];
            }
        }

        public ListaComponentesCusto()
        {
            InitializeComponent();
            hashItemCCusto = new Dictionary<ListViewItem, ComponenteCusto>();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }
        
        protected void Excluir()
        {
            if (ClicouExcluir != null)
                ClicouExcluir(this, EventArgs.Empty);
        }

        protected void Adicionar()
        {
            if (ClicouAdicionar != null)
                ClicouAdicionar(this, EventArgs.Empty);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        /// <summary>
        /// Carrega na lista todos os componentes de custo cadastrados
        /// </summary>
        public void CarregarTodosComponentes()
        {
            List<ComponenteCusto> componentes;

            Limpar();

            componentes = ComponenteCusto.ObterComponentes();

            foreach (ComponenteCusto c in componentes)
                InserirItem(c);

            colNome.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            AtualizarEnabled();
        }

        protected ListViewItem InserirItem(ComponenteCusto c)
        {
            // Faz item da list view 
            ListViewItem novo = new ListViewItem(new string[lst.Columns.Count]);

            PreencherListViewItem(novo, c);

            // Adiciona no localizador
            localizador.InserirListViewItem(novo);

            // Informa na hash
            hashItemCCusto.Add(novo, c);

            // Adiciona item 
            lst.Items.Add(novo);

            return novo;
        }

        protected virtual void PreencherListViewItem(ListViewItem item, ComponenteCusto c)
        {
            item.SubItems[colCódigo.Index].Text = c.Código.ToString();
            item.SubItems[colValor.Index].Text = c.Valor.ToString();
            item.SubItems[colNome.Index].Text = c.Nome;

            if (c.MultiplicarComponenteCusto != null)
                item.SubItems[colRelativo.Index].Text = ((ComponenteCusto)c.MultiplicarComponenteCusto).ToString();

            item.SubItems[colValorAbsoluto.Index].Text = c.ObterValorAbsoluto().ToString();
        }

        private void localizador_EncontrarItem(object item, object itemAnterior)
        {
            ListViewItem itemListView = (ListViewItem)item;
            ListViewItem itemListViewAnterior = itemAnterior as ListViewItem;

            if (itemListViewAnterior != null)
                itemListViewAnterior.Selected = false;

            itemListView.Selected = true;
            itemListView.EnsureVisible();
        }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lst.Items)
                i.BackColor = Color.White;
        }

        private void localizador_RealçarItens(ArrayList itens)
        {
            foreach (ListViewItem i in itens)
            {
                i.UseItemStyleForSubItems = true;
                i.BackColor = Color.LightGreen;
            }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            if (ClicouAlterar != null && Selecionado != null)
                ClicouAlterar(sender, e);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ClicouAlterar != null)
                ClicouAlterar(sender, e);
        }

        protected void AtualizarEnabled()
        {
            btnAlterar.Enabled = btnExcluir.Enabled
                = (Selecionado != null);
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarEnabled();
        }

        public void Limpar()
        {
            hashItemCCusto.Clear();
            lst.Items.Clear();
            localizador.Limpar();
        }
    }
}