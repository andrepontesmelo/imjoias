using Apresentação.Estoque.Extrato;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Estoque.Fornecedor;
using Apresentação.Impressão.Relatórios.Estoque.Referência;
using Apresentação.Impressão.Relatórios.Estoque.Resumo;
using CrystalDecisions.CrystalReports.Engine;
using Entidades.Estoque;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Estoque
{
    public partial class BaseEstoque : BaseInferior
    {
        private Saldo saldo;
        private JanelaOpçõesEstoque opções = new JanelaOpçõesEstoque();

        public BaseEstoque()
        {
            InitializeComponent();
        }

        private void opçãoZerarEstoque_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseZerarEstoque());
        }

        private void btnExtrato_Click(object sender, EventArgs e)
        {
            if (listaSaldo.Seleção == null)
            {
                MessageBox.Show(this,
                    "Selecionar uma referência primeiro",
                    "Nada selecionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
                AbrirExtrato(listaSaldo.Seleção);
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Entrada.BaseEntradas());
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaSaldo.Opções = opções;
            listaSaldo.Carregar();
        }

        private void listaSaldo_AoDuploClique(object sender, EventArgs e)
        {
            AbrirExtrato(listaSaldo.Seleção);
        }

        private void AbrirExtrato(Saldo s)
        {
            this.saldo = s;

            BaseExtrato novaBase = new BaseExtrato();
            novaBase.Carregar(s);

            SubstituirBase(novaBase);
        }

        private void btnRelatórioResumo_Click(object sender, EventArgs e)
        {
            List<Saldo> itens = ObterItens(Saldo.Ordem.FornecedorReferênciaPeso);

            if (itens == null)
                return;

            JanelaImpressão janela = new JanelaImpressão();

            RelatórioResumo r = new RelatórioResumo();

            new ControleImpressãoResumo().PrepararImpressão(r, itens);

            AbrirJanela(janela, r);
        }

        private void btnRelatórioFornecedor_Click(object sender, EventArgs e)
        {
            List<Saldo> itens = ObterItens(Saldo.Ordem.FornecedorReferênciaPeso);

            if (itens == null)
                return;

            JanelaImpressão janela = new JanelaImpressão();

            RelatórioFornecedor r = new RelatórioFornecedor();

            new ControleImpressãoFornecedor().PrepararImpressão(r, itens);

            AbrirJanela(janela, r);
        }

        private static void AbrirJanela(JanelaImpressão janela, ReportClass r)
        {
            janela.Título = "Resumo";
            janela.Descrição = "Relatório de resumo de estoque";
            janela.InserirDocumento(r, "Estoque");

            janela.Show();
        }

        private List<Saldo> ObterItens(Saldo.Ordem ordem)
        {
            List<Saldo> itens = Saldo.Obter(opções.IncluirPeso, opções.IncluirReferência, 
                opções.FornecedorÚnico, ordem, opções.UsarPesoMédio, opções.AgruparPrimeirosDígitos);

            return itens;
        }

        private void btnRelatórioReferência_Click(object sender, EventArgs e)
        {
            List<Saldo> itens = ObterItens(Saldo.Ordem.ReferênciaPeso);

            if (itens == null)
                return;

            JanelaImpressão janela = new JanelaImpressão();

            RelatórioReferência r = new RelatórioReferência();

            new ControleImpressãoReferência().PrepararImpressão(r, itens);

            AbrirJanela(janela, r);
        }

        private void opçãoConfigurações_Click(object sender, EventArgs e)
        {
            DialogResult resultado = opções.ShowDialog();

            if (resultado == DialogResult.OK)
                listaSaldo.Carregar();
        }
    }
}
