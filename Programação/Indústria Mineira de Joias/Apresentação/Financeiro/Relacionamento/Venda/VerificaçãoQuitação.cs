using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Venda
{
    /// <summary>
    /// Realiza verificação de quitação de vendas em segundo plano.
    /// </summary>
    public class VerificaçãoQuitação : TrabalhoSegundoPlano
    {
        private Entidades.Pessoa.Pessoa cliente;
        private Entidades.Relacionamento.Venda.Venda[] vendas;
        private Entidades.Pagamentos.Pagamento[] pagamentosPendentes;
        private double dívida;

        public delegate void VerificaçãoCallback(Entidades.Pessoa.Pessoa cliente, Entidades.Relacionamento.Venda.Venda[] vendas, double dívida);
        public delegate void VerificaçãoPagamentosCallback(Entidades.Pessoa.Pessoa cliente, Entidades.Pagamentos.Pagamento[] pagamentosPendentes);
        public event VerificaçãoCallback AoEncontrarVendasNãoQuitadas;
        public event VerificaçãoPagamentosCallback AoEncontrarPagamentosPendentes;
        public event EventHandler AoTerminarVerificação;

        public VerificaçãoQuitação(Entidades.Pessoa.Pessoa cliente)
        {
            this.cliente = cliente;
        }

        protected override void RealizarTrabalho()
        {
            vendas = Entidades.Relacionamento.Venda.Venda.ObterVendasNãoQuitadas(cliente, out dívida);
            pagamentosPendentes = Entidades.Pagamentos.Pagamento.ObterPagamentos(cliente, true);
        }

        public Entidades.Relacionamento.Venda.Venda[] VendasNãoQuitadas
        {
            get { return vendas; }
        }

        public double Dívida { get { return dívida; } }

        protected override void AoTerminar()
        {
            base.AoTerminar();

            if (vendas.Length > 0 && AoEncontrarVendasNãoQuitadas != null)
                AoEncontrarVendasNãoQuitadas(cliente, vendas, dívida);

            if (pagamentosPendentes.Length > 0 && AoEncontrarPagamentosPendentes != null)
                AoEncontrarPagamentosPendentes(cliente, pagamentosPendentes);

            if (AoTerminarVerificação != null)
                AoTerminarVerificação(this, null);
        }
    }
}
