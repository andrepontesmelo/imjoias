using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Impressão.Relatórios.PagamentosCliente;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.NotaPromissória;
using Entidades.Pagamentos;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class BasePagamentos : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;

        public BasePagamentos()
        {
            InitializeComponent();
        }

        public void Abrir(Entidades.Pessoa.Pessoa pessoa)
        {
            títuloBaseInferior.Título = "Pagamentos de " + pessoa.Nome;
            this.pessoa = pessoa;

            lista.Cliente = pessoa;
            //lista.Carregar();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            lista.Carregar();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            PagamentosCliente relatório = new PagamentosCliente();
            JanelaImpressão janela = new JanelaImpressão();
            janela.Título = "Pagamentos de " + pessoa.Nome;
            janela.Descrição = "Visualização de impressão";
            ControleImpressãoPagamentosCliente.PrepararImpressão(relatório, pessoa, lista.ObterPagamentosExibidos());
            janela.InserirDocumento(relatório, "Pagamentos");
            janela.Abrir(this);
        }

        private void opçãoImprimirPromissórias_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            JanelaImpressão janela = new JanelaImpressão();
            janela.Título = "Nota Promissória";
            janela.Descrição = "Visualização de impressão para nota promissória";

            List<NotaPromissória> lstNotasPromissórias =
                NotaPromissória.FiltrarNotasPromissórias(lista.ObterPagamentosSelecionadosOuExibidos(), true);

            if (lstNotasPromissórias.Count == 0)
            {
                AguardeDB.Fechar();

                MessageBox.Show(this,
                    "Não existem notas promissórias pendentes",
                    "Impressão de NPs",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                return;
            }

            Relatório relatório = new Relatório();
            ControleImpressão controle = new ControleImpressão();

            controle.PrepararImpressão(relatório, lstNotasPromissórias);

            janela.InserirDocumento(relatório, "Nota(s) Promissória(s)");

            AguardeDB.Fechar();
            janela.Abrir(this);
        }
    }
}
