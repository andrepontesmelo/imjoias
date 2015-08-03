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

        public BaseCréditos()
        {
            InitializeComponent();
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

            foreach (Entidades.Crédito entidade in entidades) 
            {
                ListViewItem item = new ListViewItem(entidade.Data.ToShortDateString());
                hashCréditos[item] = entidade;
                item.SubItems.Add(entidade.Valor.ToString("C"));

                //if (entidade.Venda == null)
                //    item.SubItems.Add("");
                //else
                //    item.SubItems.Add(entidade.Venda.Código.ToString());

                item.SubItems.Add(entidade.Descrição);

                //if (entidade.Venda == null)
                //    item.Font = new Font(item.Font, FontStyle.Bold);
                //else
                //    item.Font = new Font(item.Font, FontStyle.Regular);

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
    }
}
