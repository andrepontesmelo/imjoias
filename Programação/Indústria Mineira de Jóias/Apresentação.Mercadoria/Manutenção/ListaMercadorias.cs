using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;
using System.Collections;
using Apresentação.Formulários;

namespace Apresentação.Mercadoria.Manutenção
{
    public partial class ListaMercadorias : UserControl
    {
        // Atributos
        private Dictionary<ListViewItem, MercadoriaManutenção> hashItemEntidade;
        private Font fonteExclusão, fonteAlteração;
        private bool apenasDentroDeLinha = true;

        // eventos
        public delegate void EventoDelegate(MercadoriaManutenção manutenção);
        public event EventoDelegate Alterar;
        public event EventHandler Adicionar, Excluir;

        public ListaMercadorias()
        {
            InitializeComponent();

            fonteExclusão = new Font(Font, FontStyle.Strikeout);
            fonteAlteração = new Font(Font, FontStyle.Bold);

            colReferência.Name = "colReferência";
            colPeso.Name = "colPeso";
            colDescrição.Name = "colDescrição";
            colFaixa.Name = "colFaixa";
            colGrupo.Name = "colGrupo";
            colTeor.Name = "colTeor";
            colForaDeLinha.Name = "colForaDeLinha";
        }

        [Description("Apenas carregar itens dentro de linha")]
        [DefaultValue(true)]
        public bool ApenasDentroDeLinha
        {
            get { return apenasDentroDeLinha; }
            set 
            { 
                apenasDentroDeLinha = value;
                Carregar();
            }
        }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lista.Items)
                i.BackColor = Color.White;
        }


        private void localizador_EncontrarItem(object item, object itemAnterior)
        {
            ListViewItem i = (ListViewItem) item;
            ListViewItem iAnterior = itemAnterior as ListViewItem;

            if (iAnterior != null)
                iAnterior.Selected = false;

            i.Selected = true;
            i.EnsureVisible();
        }

        private void localizador_RealçarItens(System.Collections.ArrayList itens)
        {
            foreach (ListViewItem i in itens)
            {
                i.UseItemStyleForSubItems = true;
                i.BackColor = Color.LightGreen;
            }
        }

        public void Carregar()
        {
            Aguarde janelaAguarde;
            
            // Número de atualizações na janelaAguarde
            const int atualizações = 40;
            

            Apresentação.Formulários.SinalizaçãoCarga sinalização
            = Apresentação.Formulários.SinalizaçãoCarga.Sinalizar(this, "Carregando", "Aguarde enquanto as mercadorias são obtidas do banco de dados.");

            lista.Visible = false;

            lista.Items.Clear();
            localizador.Limpar();

            List<MercadoriaManutenção> entidades = MercadoriaManutenção.Obter(apenasDentroDeLinha);

            janelaAguarde = new Aguarde("Preenchendo lista", atualizações);
            janelaAguarde.Abrir();
            hashItemEntidade = new Dictionary<ListViewItem, MercadoriaManutenção>(entidades.Count);
            lista.ListViewItemSorter = new ListaMercadoriaOrdenador(hashItemEntidade);

            foreach (MercadoriaManutenção entidade in entidades)
            {
                ListViewItem i = new ListViewItem();

                i.SubItems.AddRange(new string[9] { "", "", "", "", "", "", "", "", "" });
                i.SubItems[colReferência.Index].Text  = entidade.Referência;
                i.SubItems[colPeso.Index].Text = entidade.Peso.ToString();
                i.SubItems[colDescrição.Index].Text = entidade.Descrição;
                
                if (entidade.Faixa != null)
                    i.SubItems[colFaixa.Index].Text = entidade.Faixa.ToString();

                i.SubItems[colGrupo.Index].Text = entidade.Grupo.ToString();
                i.SubItems[colTeor.Index].Text = entidade.Teor.ToString();
                i.SubItems[colForaDeLinha.Index].Text = entidade.ForaDeLinha ? "Excluida" : "";

                if (entidade.ForaDeLinha)
                {
                    i.UseItemStyleForSubItems = true;
                    i.Font = fonteExclusão;
                    i.ForeColor = Color.Red;
                }
                else if (entidade.Alterar)
                {
                    i.UseItemStyleForSubItems = true;
                    i.Font = fonteAlteração;
                }

                i.Group = entidade.DePeso ? lista.Groups[1] : lista.Groups[0];

                hashItemEntidade.Add(i, entidade);
                localizador.InserirListViewItem(i);
                lista.Items.Add(i);

                janelaAguarde.Passo(entidade.Referência);
            }

            lista.Visible = true;
            Apresentação.Formulários.SinalizaçãoCarga.Dessinalizar(sinalização);
            janelaAguarde.Close();
        }

        /// <summary>
        /// O(n) - Gera lista com os itens selecionados.
        /// </summary>
        public List<MercadoriaManutenção> ObterItensSelecionados()
        {
            List<MercadoriaManutenção> listaSelecionados = new List<MercadoriaManutenção>(lista.SelectedItems.Count);

            foreach (ListViewItem i in lista.SelectedItems)
                listaSelecionados.Add(hashItemEntidade[i]);

            return listaSelecionados;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListaMercadoriaOrdenador) lista.ListViewItemSorter).DefinirColuna(lista.Columns[e.Column]))
                lista.Sorting = SortOrder.Ascending;
            else
                lista.Sorting = SortOrder.Descending;

            lista.Sort();

        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAlterar.Enabled = btnExcluir.Enabled = 
                lista.SelectedItems.Count != 0;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Alterar != null)
                Alterar(hashItemEntidade[lista.SelectedItems[0]]);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (Alterar != null && lista.SelectedItems.Count > 0)
                Alterar(hashItemEntidade[lista.SelectedItems[0]]);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Adicionar != null)
                Adicionar(sender, e);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Excluir != null)
                Excluir(sender, e);
        }
    }
}
