using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.PedidoConserto
{
    /// <summary>
    /// É uma classe de fronteira, usada na impressão do relatório de mesmo nome.
    /// </summary>
    public class MercadoriaEmFalta : DbManipulaçãoAutomática
    {
#pragma warning disable 0649
        private string referenciaNumerica;
        private long fornecedor;
        private decimal quantidade;
        private string referenciaFornecedor;
        private int saldoConsignado;
        private string pedidos;
        private string detalhes;

#pragma warning restore 0649
        public string ReferênciaFormatada
        {
            get
            {
                return Mercadoria.Mercadoria.MascararReferência(referenciaNumerica,
                    Mercadoria.Mercadoria.ObterDígito(referenciaNumerica));
            }
        }

        public string ReferênciaFornecedor
        {
            get { return referenciaFornecedor; }
        }

        /// <summary>
        /// É a quantidade desta mercadoria que está nas saídas, abatendo vendas e devoluções.
        /// É o saldo que está em consignado, o que pode ser recuperável em termos de mercadoria para a empresa.
        /// </summary>
        public int SaldoConsignado
        {
            get
            {
                return saldoConsignado;
            }
        }


        public long Fornecedor
        {
            get { return fornecedor; }
        }

        public decimal Quantidade
        {
            get { return quantidade; }
        }

        public String Pedidos
        {
            get 
            {
                return pedidos;
            }
        }

        public String Detalhes
        {
            get
            {
                return detalhes;
            }
        }

        /// <summary>
        /// Considera apenas os pedidos em anexo.
        /// Caso pedidos seja nulo, recupera todas as mercadorias em falta!
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public static List<MercadoriaEmFalta> Obter(List<Pedido> pedidos, bool somenteEmAberto)
        {
            if (pedidos != null && pedidos.Count == 0)
                return new List<MercadoriaEmFalta>();

            List<MercadoriaEmFalta> lista = 
                Mapear<MercadoriaEmFalta>(
                "select p.mercadoria as referenciaNumerica, fornecedor, sum(quantidade) as quantidade, GROUP_CONCAT(p.pedido) as pedidos, GROUP_CONCAT(p.descricao) as detalhes, referenciaFornecedor from pedido, pedidoitem p " + 
" left join vinculomercadoriafornecedor v on p.mercadoria= v.mercadoria " +
" where pedido.codigo=p.pedido and LENGTH(p.mercadoria) > 0 and tipo='E' " + 
(pedidos == null ? "" : " AND p.pedido in " + DbTransformarConjunto(pedidos)) +
(somenteEmAberto ? " AND dataConclusao is null " : "") + 
" group by referenciaNumerica order by referenciaNumerica ");

            Dictionary<string, List<Entidades.Mercadoria.Mercadoria.RastroConsignado>>
                hashRastreamento = Mercadoria.Mercadoria.ObterRastreamento();

            // Preenche o atributo saldoConsignado, que é a soma das quantidade em saídas - venda - retorno.
            foreach (MercadoriaEmFalta referênciaEmFalta in lista)
            {
                List<Entidades.Mercadoria.Mercadoria.RastroConsignado> rastro = null;
                int saldo = 0;

                if (hashRastreamento.TryGetValue(referênciaEmFalta.referenciaNumerica, out rastro))
                {
                    foreach (Entidades.Mercadoria.Mercadoria.RastroConsignado r in rastro)
                        saldo += r.Quantidade;
                }

                referênciaEmFalta.saldoConsignado = saldo;
            }


            return lista;
        }

        public static List<Pedido> ObterPedidosQueTemMercadoriasEmFalta()
        {
            List<Pedido> pedidos = pedidos = Mapear<Pedido>(
             " select * from pedido where codigo in " +
             " (select distinct(p.pedido) from pedido, pedidoitem p " +
             " left join vinculomercadoriafornecedor v on p.mercadoria= v.mercadoria " +
             " where pedido.codigo=p.pedido and LENGTH(p.mercadoria) > 0 and tipo='E' " +
             " AND dataConclusao is null ) ");

            return pedidos;
        }
    }
}
