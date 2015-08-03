using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    public partial class LstRastro : UserControl
    {
        // Atributos
        private Dictionary<ListViewItem, RastroItem> hashListViewItemRastro;

        // Eventos
        public event EventHandler ItemSelecionado;
        public event EventHandler ItemDeselecionado;
        public event EventHandler DuploClique;

        public LstRastro()
        {
            InitializeComponent();
        }

        public Entidades.Acerto.RastroItem Selecionado
        {
            get
            {
                if (lista.SelectedItems.Count == 0)
                    return null;
                else
                    return hashListViewItemRastro[lista.SelectedItems[0]];
            }
        }


        public void Abrir(Entidades.Mercadoria.Mercadoria mercadoria, Entidades.Acerto.ControleAcertoMercadorias acerto)
        {
            // Limpa a lista
            lista.Items.Clear();

            // Limpa a hash:
            hashListViewItemRastro = new Dictionary<ListViewItem, RastroItem>();

            // Obtém os dados do BD
            List<RastroItem> rastro =  acerto.ObterRastro(mercadoria);

            // Cria a lista 
            foreach (RastroItem itemRastro in rastro)
            {
                ListViewItem item = new ListViewItem(new String[lista.Columns.Count]);
                
                item.SubItems[colData.Index].Text = itemRastro.Data.ToLongDateString();
                item.SubItems[colDescrição.Index].Text = itemRastro.Descrição;
                item.SubItems[colDocumento.Index].Text = itemRastro.Documento;
                item.SubItems[colQuantidade.Index].Text = itemRastro.Quantidade.ToString();

                hashListViewItemRastro[item] = itemRastro;
                lista.Items.Add(item);
            }

            if (rastro.Count == 1)
                lista.Items[0].Selected = true;
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DuploClique(sender, e);
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Selecionado != null)
            {
                if (ItemSelecionado != null)
                    ItemSelecionado(sender, e);
            } else
            {
                if (ItemDeselecionado != null)
                    ItemDeselecionado(sender, e);
            }
        }
    }
}
