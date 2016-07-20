using Acesso.Comum;
using System;
using System.Collections.Generic;

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
        private bool foradelinha;
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

        public string ReferênciaFornecedor => referenciaFornecedor;

        public string ReferênciaFornecedorFFL => referenciaFornecedor + ( foradelinha ? " FFL " : "");

        public int SaldoConsignado => saldoConsignado;


        public long Fornecedor => fornecedor;

        public decimal Quantidade => quantidade;

        public String Pedidos => pedidos;

        public String Detalhes => detalhes;

        public static List<MercadoriaEmFalta> Obter(List<Pedido> pedidos, bool somenteEmAberto)
        {
            if (pedidos != null && pedidos.Count == 0)
                return new List<MercadoriaEmFalta>();

            List<MercadoriaEmFalta> lista =
                Mapear<MercadoriaEmFalta>(
                "select p.mercadoria as referenciaNumerica, foradelinha, fornecedor, sum(quantidade) as quantidade, GROUP_CONCAT(p.pedido) as pedidos, GROUP_CONCAT(p.descricao) as detalhes, referenciaFornecedor from pedido, pedidoitem p " +
                " left join vinculomercadoriafornecedor v on p.mercadoria= v.mercadoria " +
                " where pedido.codigo=p.pedido and LENGTH(p.mercadoria) > 0 and tipo='E' " +
                (pedidos == null ? "" : " AND p.pedido in " + DbTransformarConjunto(pedidos)) +
                (somenteEmAberto ? " AND dataConclusao is null " : "") +
                " group by referenciaNumerica order by referenciaNumerica ");

            Dictionary<string, List<Entidades.Mercadoria.Mercadoria.RastroConsignado>>
                hashRastreamento = Mercadoria.Mercadoria.ObterRastreamento();

            PreencheSaldoConsignado(lista, hashRastreamento);

            return lista;
        }

        private static void PreencheSaldoConsignado(List<MercadoriaEmFalta> lista, Dictionary<string, List<Mercadoria.Mercadoria.RastroConsignado>> hashRastreamento)
        {
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
