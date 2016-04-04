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
using Entidades.Estoque;

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

        Dictionary<ZeragemEstoque, ListViewGroup> hashGrupos = new Dictionary<ZeragemEstoque,ListViewGroup>();

        internal void Carregar()
        {
            lst.Items.Clear();
            hashItemEntidade = new Dictionary<ListViewItem, Comissão>();

            List<ZeragemEstoque> lstZeragem = CarregaGruposZeragemEstoque();

            List<Comissão> lstComissões = Comissão.ObterComissões();
            foreach (Comissão e in lstComissões)
            {
                ListViewItem item = new ListViewItem(e.Código.ToString());
                item.SubItems.AddRange(new string[] { e.MêsReferência.ToString("MMMM/yyyy"),
                    e.Descrição,
                    e.Pago ? "Pago" : "Não Pago"
                });

                item.Group = DescobreGrupoZeragemEstoque(e.Código, lstZeragem);

                lst.Items.Add(item);
                hashItemEntidade.Add(item, e);
            }

            lst.AutoResizeColumn(colDescrição.Index, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private List<ZeragemEstoque> CarregaGruposZeragemEstoque()
        {
            List<ZeragemEstoque> lstZeragem = ZeragemEstoque.Obter();

            hashGrupos.Clear();
            lst.Groups.Clear();
            foreach (ZeragemEstoque e in lstZeragem)
            {
                ListViewGroup novoGrupo = new ListViewGroup("Integrado ao Estoque após Comissão nr. " +
                    e.ComissaoVigente.ToString() + " - " + e.Observações);

                hashGrupos[e] = novoGrupo;
                lst.Groups.Add(novoGrupo);
            }

            lst.Groups.Add(new ListViewGroup("Não Integrado ao Estoque"));
            lstZeragem.Reverse();
            return lstZeragem;
        }



        private ListViewGroup DescobreGrupoZeragemEstoque(int códigoComissão, List<ZeragemEstoque> lstZeragemOrdenadoComissão)
        {
            ListViewGroup semEstoque = lst.Groups[lst.Groups.Count - 1];

            if (lstZeragemOrdenadoComissão.Count == 0 ||
                códigoComissão <= lstZeragemOrdenadoComissão[0].ComissaoVigente)
                return semEstoque;

            for (int x = lstZeragemOrdenadoComissão.Count - 1 ; x >= 0; x--)
            {
                if (códigoComissão > lstZeragemOrdenadoComissão[x].ComissaoVigente)
                    return hashGrupos[lstZeragemOrdenadoComissão[x]];
            }

            return semEstoque;
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
