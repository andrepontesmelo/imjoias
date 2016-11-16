using Apresentação.Formulários;
using Entidades.Mercadoria;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Janela
{
    public partial class JanelaPesquisaReferência : JanelaExplicativa
    {
        public delegate void AoSelecionarDelegate(string referência);
        public event AoSelecionarDelegate AoSelecionar;

        public JanelaPesquisaReferência()
        {
            InitializeComponent();
        }

        public void Carregar()
        {
            var mercadorias = Entidades.Mercadoria.Mercadoria.ObterMercadoriasCampos();

            localizador.Realçar();
            localizador.Abrir();

            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(CriarItens(mercadorias));
            lista.ResumeLayout();
        }

        private ListViewItem[] CriarItens(IEnumerator mercadorias)
        {
            List<ListViewItem> itens = new List<ListViewItem>();
            mercadorias.Reset();
            while (mercadorias.MoveNext())
                itens.Add(CriarItem(mercadorias.Current as MercadoriaCampos));

            return itens.ToArray();
        }

        private ListViewItem CriarItem(MercadoriaCampos mercadoriaCampos)
        {
            ListViewItem item = new ListViewItem();
            item.Text = mercadoriaCampos.Referência;
            item.SubItems.Add(mercadoriaCampos.Descrição);

            localizador.InserirPalavraBuscável(mercadoriaCampos.Referência, item);
            localizador.InserirPalavraBuscável(mercadoriaCampos.ReferênciaNumérica + mercadoriaCampos.Dígito, item);

            return item;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Carregar();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FecharSeItemSelecionado();
        }

        private string ReferênciaSelecionada
        {
            get
            {
                if (lista.SelectedItems.Count == 0)
                    return null;

                return lista.SelectedItems[0].Text;
            }
        }

        private bool DispararEventoItemSelecionado()
        {
            var seleção = ReferênciaSelecionada;

            if (seleção == null || AoSelecionar == null)
                return false;

            AoSelecionar.Invoke(seleção);
            return true;
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            FecharSeItemSelecionado();
        }

        private void FecharSeItemSelecionado()
        {
            if (!DispararEventoItemSelecionado())
                return;

            Close();
        }

        private void localizador_RealçarItens(ArrayList itens)
        {
            foreach (ListViewItem i in itens)
                i.BackColor = System.Drawing.Color.Yellow;
        }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lista.Items)
            {
                i.BackColor = System.Drawing.Color.White;
            }
        }

        private void localizador_EncontrarItemÚnico(object item, object últimoEncontrado)
        {
            SelecionarApenas((ListViewItem) item);

            if (!DispararEventoItemSelecionado())
                return;

            Close();
        }

        private void SelecionarApenas(ListViewItem item)
        {
            lista.SelectedItems.Clear();
            item.Selected = true;
        }

        private void localizador_EncontrarItem(object item, object últimoEncontrado)
        {
            var i = (ListViewItem) item;

            SelecionarApenas(i);
            i.EnsureVisible();
        }
    }
}
