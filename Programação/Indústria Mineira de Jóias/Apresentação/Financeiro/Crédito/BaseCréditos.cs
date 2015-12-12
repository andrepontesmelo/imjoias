using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Crédito
{
    public partial class BaseCréditos : BaseInferior
    {
        public Entidades.Pessoa.Pessoa Pessoa { get; set; }
        private Dictionary<ListViewItem, Entidades.Crédito> hashCréditos;

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

            lstCréditos.Items.Clear();
            hashCréditos = new Dictionary<ListViewItem, Entidades.Crédito>();

            List<Entidades.Crédito> entidades = 
                Entidades.Crédito.ObterCréditos(Pessoa);

            List<Entidades.Crédito> créditosNãoUtilizados =
                Entidades.Crédito.ObterCréditosNãoUtilizados(Pessoa);

            foreach (Entidades.Crédito entidade in entidades) 
            {
                ListViewItem item = new ListViewItem(entidade.Data.ToShortDateString());
                hashCréditos[item] = entidade;
                item.SubItems.Add(entidade.Valor.ToString("C"));
                item.SubItems.Add(entidade.Descrição);

                if (créditosNãoUtilizados.Contains(entidade))
                    item.BackColor = Color.GreenYellow;

                lstCréditos.Items.Add(item);
            }

            AguardeDB.Fechar();
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
                foreach (ListViewItem item in lstCréditos.SelectedItems)
                {
                    Entidades.Crédito crédito = hashCréditos[item];
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
