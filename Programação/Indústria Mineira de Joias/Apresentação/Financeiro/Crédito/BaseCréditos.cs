using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Financeiro;

namespace Apresentação.Financeiro.Crédito
{
    public partial class BaseCréditos : BaseInferior
    {
        public Entidades.Pessoa.Pessoa Pessoa { get; set; }
        private Dictionary<ListViewItem, Entidades.Financeiro.Crédito> hashCréditos;

        private ListViewColumnSorter ordenador;

        public BaseCréditos()
        {
            InitializeComponent();
            ordenador = new ListViewColumnSorter();
            lstCréditos.ListViewItemSorter = ordenador;
        }

        protected override void AoExibir()
        {
            base.AoExibir();
            CarrregarLista();
        }

        private void opçãoNovoCrédito_Click(object sender, EventArgs e)
        {
            JanelaCadastroCrédito janela = new JanelaCadastroCrédito();
            janela.AbrirParaCadastro(Pessoa);
            janela.ShowDialog(this);
            AoExibir();
        }

        private void CarrregarLista()
        {
            AguardeDB.Mostrar();

            lstCréditos.SuspendLayout();
            lstCréditos.Items.Clear();
            hashCréditos = new Dictionary<ListViewItem, Entidades.Financeiro.Crédito>();

            List<Entidades.Financeiro.Crédito> entidades = 
                Entidades.Financeiro.Crédito.ObterCréditos(Pessoa);

            Dictionary<uint, ulong> hashCréditoVenda = VendaCrédito.ObterHashCréditoVenda(Pessoa.Código);

            foreach (Entidades.Financeiro.Crédito entidade in entidades) 
                AdicionarItem(hashCréditoVenda, entidade);

            lstCréditos.AutoResizeColumns(entidades.Count == 0 ? ColumnHeaderAutoResizeStyle.HeaderSize : ColumnHeaderAutoResizeStyle.ColumnContent);

            lstCréditos.ResumeLayout();
            AguardeDB.Fechar();
        }

        private void AdicionarItem(Dictionary<uint, ulong> hashCréditoVenda, Entidades.Financeiro.Crédito entidade)
        {
            ListViewItem item = new ListViewItem(entidade.Data.ToShortDateString());
            hashCréditos[item] = entidade;
            item.SubItems.Add(entidade.Valor.ToString("C"));
            item.SubItems.Add(entidade.Descrição);

            ulong códigoVenda;

            if (hashCréditoVenda.TryGetValue(entidade.Código, out códigoVenda))
            {
                item.SubItems.Add(códigoVenda.ToString());
            }
            else
                item.BackColor = Color.GreenYellow;

            lstCréditos.Items.Add(item);
        }


        private void lstCréditos_DoubleClick(object sender, EventArgs e)
        {
            if (lstCréditos.SelectedItems.Count > 0) 
            {
                JanelaCadastroCrédito janela = new JanelaCadastroCrédito();
                janela.CarregarEntidade(hashCréditos[lstCréditos.SelectedItems[0]]);
                janela.ShowDialog(this);
                AoExibir();
            }
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            if (lstCréditos.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this,
                    "Confirma exclusão de " + lstCréditos.SelectedItems.Count.ToString() +
                    " crédito" + (lstCréditos.SelectedItems.Count == 1 ? "" : "s") + " ? ",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                foreach (ListViewItem item in lstCréditos.SelectedItems)
                {
                    Entidades.Financeiro.Crédito crédito = hashCréditos[item];
                    crédito.Descadastrar();
                }

                CarrregarLista();
            }
        }

        private void lstCréditos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lstCréditos, e);
        }
    }
}
