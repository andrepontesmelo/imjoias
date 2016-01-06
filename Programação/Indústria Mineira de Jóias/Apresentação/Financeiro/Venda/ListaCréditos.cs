using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Venda;

namespace Apresentação.Financeiro.Venda
{
    public partial class ListaCréditos : UserControl
    {
        private Entidades.Relacionamento.Venda.Venda venda;
        private BaseEditarVenda baseEditarVenda = null;

        private ListViewColumnSorter ordenador;

        public ListaCréditos()
        {
            InitializeComponent();
            ordenador = new ListViewColumnSorter();
            lista.ListViewItemSorter = ordenador;
        }

        public void InformarBaseEditarVenda(BaseEditarVenda controle)
        {
            if (baseEditarVenda != null)
                return;

            baseEditarVenda = controle;
            baseEditarVenda.TravaAlterada += new BaseEditarRelacionamento.TravaAlteradaHandler(baseEditarVenda_TravaAlterada);

        }

        void baseEditarVenda_TravaAlterada(BaseEditarRelacionamento sender, Entidades.Relacionamento.Relacionamento e, bool entidadeTravada)
        {
            AtualizarEnables(entidadeTravada);
        }


        public void Abrir(Entidades.Relacionamento.Venda.Venda venda)
        {
            this.venda = venda;

            venda.ItensCrédito.AoAdicionar += new Acesso.Comum.DbComposição<VendaCrédito>.EventoComposição(ItensCrédito_AoAdicionar);
            venda.ItensCrédito.AoRemover += new Acesso.Comum.DbComposição<VendaCrédito>.EventoComposição(ItensCrédito_AoRemover);

            Carregar();
        }

        private void Carregar()
        {
            lista.Items.Clear();

            SinalizaçãoCarga.Sinalizar(lista, "Carregando dados...", "Aguarde enquanto os Créditos são carregados.");

            bgCarregar.RunWorkerAsync();
        }

        void ItensCrédito_AoRemover(Acesso.Comum.DbComposição<VendaCrédito> composição, VendaCrédito entidade)
        {
            foreach (ListViewItem item in lista.Items)
                if (entidade.Equals(item.Tag))
                {
                    lista.Items.Remove(item);

                    return;
                }

            Carregar();
        }

        void ItensCrédito_AoAdicionar(Acesso.Comum.DbComposição<VendaCrédito> composição, VendaCrédito entidade)
        {
            if (entidade.Venda == venda)
                Adicionar(entidade);

            CalcularSumário();
        }

        /// <summary>
        /// Quem chama adicionar deve depois chamar CalcularSumário()
        /// </summary>
        /// <param name="Crédito"></param>
        private void Adicionar(VendaCrédito Crédito)
        {
            ListViewItem item = new ListViewItem();

            System.Globalization.CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

            item.Text = Crédito.Data.ToString("dd/MM/yyyy");
            item.SubItems.Add(Crédito.Descrição);
            item.SubItems.Add(Crédito.DiasDeJuros.ToString());
            item.SubItems.Add(Crédito.ValorBruto.ToString("C", cultura));
            item.SubItems.Add(Crédito.ValorLíquido.ToString("C", cultura));

            item.Tag = Crédito;

            lista.Items.Add(item);
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarEnables(venda.TravadoEmCache);
        }

        private void AtualizarEnables(bool vendaTravada)
        {
            if (vendaTravada)
            {
                btnAlterar.Enabled = btnExcluir.Enabled = false;
                btnAdicionar.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = lista.SelectedItems.Count == 1;
                btnExcluir.Enabled = lista.SelectedItems.Count >= 1;

                btnAdicionar.Enabled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            AtualizarEnables(venda.Travado);

            if (!btnExcluir.Enabled)
                return;


            if (!venda.Travado)
            {
                if (lista.SelectedItems.Count == 0)
                    return;

                if (MessageBox.Show(this,
                    "Confirma exclusão de " + lista.SelectedItems.Count.ToString() +
                    " crédito" + (lista.SelectedItems.Count == 1 ? "" : "s") + " ? ",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                foreach (ListViewItem i in lista.SelectedItems)
                {
                    VendaCrédito Crédito = (VendaCrédito)i.Tag;
                    venda.ItensCrédito.Remover(Crédito);
                }
            }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não é possível remover nenhum crédito à venda travada.",
                    "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CalcularSumário();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!venda.Cadastrado)
            {
                MessageBox.Show(
                ParentForm,
                "Não é possível adicionar nenhum crédito à venda não cadastrada.",
                "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            } else if (!venda.Travado)
                using (EditarCrédito dlg = new EditarCrédito(venda))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        venda.ItensCrédito.Adicionar(dlg.Crédito);
                }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não é possível adicionar nenhum crédito à venda travada.",
                    "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AtualizarEnables(venda.Travado);

            if (!btnAlterar.Enabled)
                return;

            if (!venda.Travado)
                using (EditarCrédito dlg = new EditarCrédito((VendaCrédito)lista.SelectedItems[0].Tag))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        dlg.Crédito.Atualizar();
                        Carregar();
                    }
                }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não é possível editar nenhum crédito à venda travada.",
                    "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CalcularSumário();
        }

        private void bgCarregar_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = venda.ItensCrédito;
        }

        private void bgCarregar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (VendaCrédito Crédito in (IEnumerable<VendaCrédito>)e.Result)
                Adicionar(Crédito);

            CalcularSumário();
            SinalizaçãoCarga.Dessinalizar(lista);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
                btnAlterar_Click(sender, e);
        }

        /// <summary>
        /// Refaz statusbar
        /// </summary>
        private void CalcularSumário()
        {
            double totalBruto = 0;
            double totalLíquido = 0;
            System.Globalization.CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

            foreach (ListViewItem item in lista.Items)
            {
                VendaCrédito Crédito = (VendaCrédito)item.Tag;
                totalBruto += Crédito.ValorBruto;
                totalLíquido += Crédito.ValorLíquido;
            }

            statusTxtQtd.Text = lista.Items.Count.ToString() + " " + (lista.Items.Count == 1 ? "Crédito" : "Créditos");
            statusTxtBruto.Text = "Bruto: " + totalBruto.ToString("C", cultura);
            statusTxtLíquido.Text = "Líquido: " + totalLíquido.ToString("C", cultura);
        }


        internal void AdicionarCadastrando(List<Entidades.Financeiro.Crédito> créditosNãoUtilizados)
        {
            foreach (Entidades.Financeiro.Crédito p in créditosNãoUtilizados) 
            {
                VendaCrédito crédito = new VendaCrédito(venda);
                crédito.ValorBruto = p.Valor;
                crédito.Descrição = p.Descrição;
                crédito.Data = p.Data;
                crédito.CobrarJuros = true;
                crédito.DiasDeJuros = Entidades.Preço.CalcularDias(crédito.Data, venda.Data);
                crédito.CalcularValorLíquido();
                crédito.Credito = p.Código;

                p.Atualizar();

                venda.ItensCrédito.Adicionar(crédito);
            }
        }

        /// <summary>
        /// Recalcula os juros e salva.
        /// </summary>
        /// <param name="novaData"></param>
        public void DataDaVendaFoiAtualizada(DateTime novaData)
        {
            foreach (VendaCrédito entidade in venda.ItensCrédito)
            {
                entidade.DiasDeJuros = Entidades.Preço.CalcularDias(entidade.Data, venda.Data);
                entidade.CalcularValorLíquido();
                entidade.Atualizar();
            }

            Carregar();
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lista, e);
        }
    }
}
