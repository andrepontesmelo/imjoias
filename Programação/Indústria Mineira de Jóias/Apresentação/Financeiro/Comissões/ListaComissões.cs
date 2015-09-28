using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.ComissãoCálculo;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Comissões
{
    public partial class ListaComissões : UserControl
    {
        private Dictionary<ListViewItem, Comissão> hashItemEntidade = null;
        public event EventHandler DuploClique;

        public delegate void TeclaDelegate (Keys teclas);
        public event TeclaDelegate AoPressionar;

        public ListaComissões()
        {
            InitializeComponent();

            lst.ListViewItemSorter = new ListViewColumnSorter();
            lst.ColumnClick += lst_ColumnClick;
        }

        void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lst.ListViewItemSorter).OnClick(lst, e);
        }

        internal void Carregar()
        {
            lst.Items.Clear();
            hashItemEntidade = new Dictionary<ListViewItem, Comissão>();

            List<Comissão> lstComissões = Comissão.ObterComissões();
            foreach (Comissão e in lstComissões)
            {
                ListViewItem item = new ListViewItem(e.Código.ToString());
                item.SubItems.AddRange(new string[] { e.MêsReferência.ToString("MMMM/yyyy"),
                    e.Descrição,
                    e.Pago ? "Pago" : "Não Pago"
                });

                lst.Items.Add(item);
                hashItemEntidade.Add(item, e);
            }

        }

        public Comissão Selecionado
        {
            get
            {
                if (lst.SelectedItems.Count == 0)
                    return null;

                return hashItemEntidade[lst.SelectedItems[0]];
            }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            if (DuploClique != null)
                DuploClique(sender, e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None)
            {
                if (AoPressionar != null)
                    AoPressionar(keyData);
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
