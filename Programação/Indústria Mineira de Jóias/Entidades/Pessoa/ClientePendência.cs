using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Mercadoria;
using Entidades.PedidoConserto;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Estrutura que descreve uma pendência de um cliente.
    /// </summary>
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
            MercadoriaEmFalta
        }

        private Identificações identificação;

        /// <summary>
        /// Constrói a pendência.
        /// </summary>
        /// <param name="item">Item pendente.</param>
        public ClientePendência(Identificações identificação, string item, string descrição)
            : this(item, descrição)
        {
            this.identificação = identificação;
        }

        /// <summary>
        /// Constrói a pendência.
        /// </summary>
        /// <param name="item">Item pendente.</param>
        public ClientePendência(Identificações identificação, string item, string descrição, bool alertar)
            : this(item, descrição, alertar)
        {
            this.identificação = identificação;
        }

        /// <summary>
        /// Constrói a pendência.
        /// </summary>
        /// <param name="item">Item pendente.</param>
        public ClientePendência(string item, string descrição) : this(item, descrição, false)
        {
            identificação = Identificações.Desconhecida;
        }

        /// <summary>
        /// Constrói a pendência.
        /// </summary>
        /// <param name="item">Item pendente.</param>
        public ClientePendência(string item, string descrição, bool alertar)
        {
            this.item = item;
            this.descrição = descrição;
            this.alertar = alertar;
            identificação = Identificações.Desconhecida;
        }

        public string Item
        {
            get { return item; }
        }

        public string Descrição
        {
            get { return descrição; }
        }

        public bool Alertar
        {
            get { return alertar; }
        }

        public Identificações Identificação { get { return identificação; } }

        /// <summary>
        /// Obtém as pendências de um cliente.
        /// </summary>
        /// <returns>Lista encadeada contendo pendências do cliente.</returns>
        public static LinkedList<ClientePendência> ObterPendências(Pessoa cliente)
        {
            LinkedList<ClientePendência> pendências = new LinkedList<ClientePendência>();
            
            //int pagamentos;
            int pedidosProntos;
            int consertosProntos;
            
            double dívida = 0;
            int totalPagamentosPendentes = 0;

            //saídas = Relacionamento.Saída.Saída.ContarSaídasNãoAcertadas(cliente);
            //retornos = Relacionamento.Retorno.Retorno.ContarRetornosNãoAcertados(cliente);
            //pagamentos = Pagamentos.Pagamento.ContarPagamentosPendentes(cliente);
            //pedidos = Pedido.ContarPedidosPendentes(cliente);

            Pedido.ContarPedidosPendentesProntos(cliente, out pedidosProntos, out consertosProntos);
            //dívida = Dívida.ObterDívida(cliente);
            
            // Valcula valor em pagamentos pendentes.
            Entidades.Pagamentos.Pagamento[] pagamentos = 
            Entidades.Pagamentos.Pagamento.ObterPagamentos(cliente, true);
            foreach (Entidades.Pagamentos.Pagamento p in pagamentos)
            {
                dívida += 
                Entidades.Preço.Corrigir(p.ÚltimoVencimento,
                    Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual,
                    p.Valor,
                    Entidades.Configuração.DadosGlobais.Instância.Juros);
            }
            totalPagamentosPendentes = pagamentos.Length;

            //if (saídas > 0)
            //    pendências.AddLast(new ClientePendência("Saídas ", saídas.ToString()));

            //if (retornos > 0)
            //    pendências.AddLast(new ClientePendência("Retornos em aberto", retornos.ToString()));

            //if (pagamentos > 0)
            //    pendências.AddLast(new ClientePendência("Pagamentos pendentes", pagamentos.ToString()));

            //if (pedidos > 0)
            //    pendências.AddLast(new ClientePendência(Identificações.Pedido, "Pedidos pendentes", pedidos.ToString()));

            if (pedidosProntos > 0)
                pendências.AddLast(new ClientePendência(Identificações.PedidoPronto, "Ped. prontos", pedidosProntos.ToString()));
             
            if (consertosProntos > 0)
                pendências.AddLast(new ClientePendência(Identificações.PedidoPronto, "Cons. prontos", consertosProntos.ToString()));


            if (dívida > 0)
                pendências.AddFirst(new ClientePendência(totalPagamentosPendentes.ToString() + " " +
                    (totalPagamentosPendentes == 1 ? "Débito" : "Débitos"), string.Format("{0:C}", dívida), true));

            List<MercadoriaEmFaltaCliente> mercadoriasEmFalta = MercadoriaEmFaltaCliente.Obter(cliente.Código);

            if (mercadoriasEmFalta.Count > 0)
                pendências.AddFirst(new ClientePendência(Identificações.MercadoriaEmFalta, "Merc. em falta", mercadoriasEmFalta.Count.ToString(), false));

            return pendências;
        }
    }
}
