using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Controle
{
    /// <summary>
    /// Controle de exibição da dívida de um cliente.
    /// </summary>
    public partial class ClienteDívida : QuadroSimples
    {
        private Entidades.Pessoa.Pessoa cliente;
        private Entidades.Controle.Dívida.InfoVenda[] vendasPendentes;

        public delegate void PagamentoCallback(Entidades.Pagamentos.Pagamento pagamento);
        public delegate void VendaCallback(Entidades.Relacionamento.Venda.Venda venda);
        
        public event PagamentoCallback AoClicarPagamento;
        public event VendaCallback AoClicarVenda;

        public ClienteDívida(Entidades.Pessoa.Pessoa cliente)
        {
            InitializeComponent();
            this.cliente = cliente;

            Carregar();
        }

        private void Carregar()
        {
            double dívida, tPagamentosPendentes = 0, tPagamentosDevolvidos = 0;

            lblCódigo.Text = cliente.Código.ToString();
            lblNome.Text = cliente.Nome;

            vendasPendentes = Entidades.Controle.Dívida.ObterVendasNãoQuitadas(cliente, out dívida);

            dívidas.Valor = dívida.ToString("C");

            foreach (Entidades.Controle.Dívida.InfoVenda venda in vendasPendentes)
            {
                dívidas.Itens.Add(new ItemExpandível.Item(
                    "Venda " + venda.CódigoFormatado,
                    venda.Dívida.ToString("C"),
                    new EventHandler(AoClicarItemVenda),
                    venda));
            }

            foreach (Entidades.Pagamentos.Pagamento pagamento in Entidades.Pagamentos.Pagamento.ObterPagamentos(cliente, true))
            {
                if (pagamento.Pendente)
                {
                    tPagamentosPendentes += pagamento.Valor;
                    pagamentosPendentes.Itens.Add(new ItemExpandível.Item(
                        pagamento.ToString(),
                        pagamento.Valor.ToString("C"),
                        new EventHandler(AoClicarItemPagamento),
                        pagamento));
                }
                if (pagamento.Devolvido)
                {
                    tPagamentosDevolvidos += pagamento.Valor;
                    pagamentosDevolvidos.Itens.Add(new ItemExpandível.Item(
                        pagamento.ToString(),
                        pagamento.Valor.ToString("C"),
                        new EventHandler(AoClicarItemPagamento),
                        pagamento));
                }
            }

            pagamentosPendentes.Valor = tPagamentosPendentes.ToString("C");
            pagamentosDevolvidos.Valor = tPagamentosDevolvidos.ToString("C");
        }

        private void AoClicarItemPagamento(object sender, EventArgs e)
        {
            AoClicarPagamento((Entidades.Pagamentos.Pagamento)((ItemExpandível.Item)sender).Objeto);
        }

        private void AoClicarItemVenda(object sender, EventArgs e)
        {
            AoClicarVenda(
                Entidades.Relacionamento.Venda.Venda.ObterVenda(((IDadosVenda)((ItemExpandível.Item)sender).Objeto).Código));
        }
    }
}
