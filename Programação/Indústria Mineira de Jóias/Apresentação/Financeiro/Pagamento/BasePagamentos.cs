using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Impressão.Relatórios.PagamentosCliente;
using Apresentação.Formulários;

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
    }
}
