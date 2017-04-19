using Entidades.Coaf.Inconsistência;
using Entidades.Mercadoria;
using Entidades.PedidoConserto;
using System.Collections.Generic;

namespace Entidades.Pessoa
{
    public struct ClientePendência
    {
        private string item;
        private string descrição;
        private bool alertar;

        public enum Identificações
        {
            Desconhecida,
            Pedido, 
            PedidoPronto,
            MercadoriaEmFalta,
            Coaf
        }

        private Identificações identificação;

        public ClientePendência(Identificações identificação, string item, string descrição) : this(item, descrição)
        {
            this.identificação = identificação;
        }

        public ClientePendência(Identificações identificação, string item, string descrição, bool alertar) : this(item, descrição, alertar)
        {
            this.identificação = identificação;
        }

        public ClientePendência(string item, string descrição) : this(item, descrição, false)
        {
            identificação = Identificações.Desconhecida;
        }

        public ClientePendência(string item, string descrição, bool alertar)
        {
            this.item = item;
            this.descrição = descrição;
            this.alertar = alertar;

            identificação = Identificações.Desconhecida;
        }

        public string Item => item;
        public string Descrição => descrição;
        public bool Alertar => alertar;
        public Identificações Identificação => identificação;

        public static LinkedList<ClientePendência> ObterPendências(Pessoa cliente)
        {
            LinkedList<ClientePendência> pendências = new LinkedList<ClientePendência>();

            int pedidosProntos;
            int consertosProntos;

            double dívida = 0;

            Pedido.ContarPedidosPendentesProntos(cliente, out pedidosProntos, out consertosProntos);
            int totalPagamentosPendentes = CalculaTotalPendente(cliente, ref dívida);

            if (pedidosProntos > 0)
                pendências.AddLast(new ClientePendência(Identificações.PedidoPronto, "Ped. prontos", pedidosProntos.ToString()));

            if (consertosProntos > 0)
                pendências.AddLast(new ClientePendência(Identificações.PedidoPronto, "Cons. prontos", consertosProntos.ToString()));


            double crédito = Financeiro.Crédito.ObterSomaCréditos(cliente);
            if (crédito != 0)
                pendências.AddFirst(new ClientePendência("Crédito", crédito.ToString("C")));

            if (dívida > 0)
                pendências.AddFirst(new ClientePendência(totalPagamentosPendentes.ToString() + " " +
                    (totalPagamentosPendentes == 1 ? "Débito" : "Débitos"), string.Format("{0:C}", dívida), true));

            List<MercadoriaEmFaltaCliente> mercadoriasEmFalta = MercadoriaEmFaltaCliente.Obter(cliente.Código);

            if (mercadoriasEmFalta.Count > 0)
                pendências.AddFirst(new ClientePendência(Identificações.MercadoriaEmFalta, "Merc. em falta", mercadoriasEmFalta.Count.ToString(), false));

            var inconsistênciaCoaf = InconsistênciaPessoa.ObterInconsistência(cliente.Código);
            if (inconsistênciaCoaf.Inconsistências.Count > 0)
            {
                foreach (var i in inconsistênciaCoaf.Inconsistências)
                    pendências.AddLast(new ClientePendência(Identificações.Coaf, "Ficha", InconsistênciaPessoa.ObterDescriçãoResumida(i), true));
            }

            return pendências;
        }

        private static int CalculaTotalPendente(Pessoa cliente, ref double dívida)
        {
            int totalPagamentosPendentes;
            Pagamentos.Pagamento[] pagamentos =
Pagamentos.Pagamento.ObterPagamentos(cliente, true);
            foreach (Pagamentos.Pagamento p in pagamentos)
            {
                dívida +=
                Preço.Corrigir(p.ÚltimoVencimento,
                    Configuração.DadosGlobais.Instância.HoraDataAtual,
                    p.Valor,
                    Configuração.DadosGlobais.Instância.Juros);
            }
            totalPagamentosPendentes = pagamentos.Length;
            return totalPagamentosPendentes;
        }
    }
}
