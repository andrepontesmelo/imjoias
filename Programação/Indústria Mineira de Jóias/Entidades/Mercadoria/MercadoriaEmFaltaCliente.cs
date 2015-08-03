using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Acesso.Comum;

namespace Entidades.Mercadoria
{
    /// <summary>
    /// Mercadorias que estão em pedidos(encomendas) em aberto são mercadorias em falta.
    /// 
    /// É útil obter estas mercadorias para exibir na tela de um cliente,
    /// para que se atenda as encomendas mais rapidamente evitando que uma mercadoria em falta
    /// seja emprestada por consignado para alguem.
    /// </summary>
    public class MercadoriaEmFaltaCliente : DbManipulaçãoAutomática
    {
#pragma warning disable 0649
        private long pedido;
        private string clienteNome;
        private decimal qtdpedido;
        public string descricao;

        [DbAtributo(TipoAtributo.Ignorar)]
        private double qtdconsignado;

        //private int diasEspera;
        private string referencia;
        private DateTime dataRecepcao;
#pragma warning restore 0649

        public MercadoriaEmFaltaCliente()
        {
        }

        public long Pedido
        {
            get { return pedido; }
        }

        public DateTime DataPedido
        {
            get
            {
                return dataRecepcao;
            }
        }

        public string Descricao
        { get { return descricao; } }
             
        public string ClienteNome
        {
            get { return clienteNome; }
        }

        public int QuantidadePedido
        {
            get { return (int) qtdpedido; }
        }

        public int QuantidadeConsignado
        {
            get { return (int) qtdconsignado; }
            set { qtdconsignado = value; }
        }

        /// <summary>
        /// Dias em que o pedido encontra-se em aberto.
        /// </summary>
        public int DiasEspera
        {
            get 
            {
                DateTime hoje = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Date;
                TimeSpan tempoEspera = hoje - dataRecepcao.Date;

                return (int) tempoEspera.TotalDays; 
            }
        }

        public string ReferênciaNumérica
        {
            get { return referencia; }
        }

        /// <summary>
        /// Obtém as mercadorias em falta que estão em consignado para uma determinada pessoa.
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static List<MercadoriaEmFaltaCliente> Obter(ulong pessoa)
        {
            List<MercadoriaEmFaltaCliente> listaPedidos = Mapear<MercadoriaEmFaltaCliente>(
                        " select pedido.codigo as pedido, pedido.dataRecepcao, pedidoitem.mercadoria as referencia, pessoa.nome as clienteNome, " + 
                        " sum(pedidoitem.quantidade) as qtdpedido, group_concat(pedidoitem.descricao) as descricao from " +
                        " pedido, pedidoitem, pessoa where pedido.codigo=pedidoitem.pedido " +
                        " and pessoa.codigo=pedido.cliente " +
                        " and tipo = 'E' " +
                        " and dataEntrega is null " + 
                        " and pedidoitem.mercadoria in (select referencia from saidaitem, saida, acertoconsignado where  " +
                        " saida.codigo=saidaitem.saida and saida.acerto=acertoconsignado.codigo and pessoa= " +
                        DbTransformar(pessoa) +
                        " and dataEfetiva is null) " +
                        " group by pedido.codigo, pedidoitem.mercadoria " +
                        " order by dataRecepcao ");

            if (listaPedidos.Count == 0)
                return listaPedidos;

            // Dado a referência, retorna a lista de pedidos que a contém
            Dictionary<string, List<MercadoriaEmFaltaCliente>> hash = new Dictionary<string, List<MercadoriaEmFaltaCliente>>(StringComparer.Ordinal);
            foreach (MercadoriaEmFaltaCliente m in listaPedidos)
            {
                List<MercadoriaEmFaltaCliente> lista = null;

                if (!hash.TryGetValue(m.ReferênciaNumérica, out lista))
                {
                    lista = new List<MercadoriaEmFaltaCliente>();
                    hash[m.ReferênciaNumérica] = lista;
                }

                lista.Add(m);
            }

            //return Mapear<MercadoriaEmFalta>(
            //" select pedido, dataRecepcao, c.referencia, clienteNome, qtdpedido, qtdsaidamenosretorno - sum(quantidade) as qtdconsignado from  " + 
            //" ( select pedido, dataRecepcao, b.referencia, clienteNome, qtdpedido, qtdsaida - sum(quantidade) as qtdsaidamenosretorno  from " + 
            //" ( select pedido, dataRecepcao, mercadoria as referencia, clienteNome, qtdpedido, sum(quantidade) as qtdsaida from  ( " +
            //" select pedido.codigo as pedido, pedido.dataRecepcao, pedidoitem.mercadoria, pessoa.nome as clienteNome, sum(pedidoitem.quantidade) as qtdpedido from " +
            //" pedido, pedidoitem, pessoa where pedido.codigo=pedidoitem.pedido " + 
            //" and pessoa.codigo=pedido.cliente " +
            //" and tipo = 'E'  " +
            //" and pedidoitem.mercadoria in (select referencia from saidaitem, saida, acertoconsignado where  " +
            //" saida.codigo=saidaitem.saida and saida.acerto=acertoconsignado.codigo and pessoa= " + DbTransformar(pessoa) + 
            //" and dataEfetiva is null) " +
            //" group by pedido.codigo  " +
            //" order by dataRecepcao  "  +
            //" ) a, saidaitem, saida, acertoconsignado where   "  +
            //" a.mercadoria=saidaitem.referencia and "  +
            //" saida.codigo=saidaitem.saida and saida.acerto=acertoconsignado.codigo and pessoa= " + DbTransformar(pessoa) + 
            //" group by a.pedido " +
            //" ) b, retornoitem, retorno, acertoconsignado where  "  +
            //" b.referencia = retornoitem.referencia and " +
            //" retorno.codigo=retornoitem.retorno and retorno.acerto=acertoconsignado.codigo and pessoa= " + DbTransformar(pessoa) + 
            // " group by referencia ) c, vendaitem, venda, acertoconsignado where  c.referencia = vendaitem.referencia and " +
            //" venda.codigo=vendaitem.venda and venda.acerto=acertoconsignado.codigo and (vendedor = " + DbTransformar(pessoa) +  " or venda.cliente = "  + DbTransformar(pessoa) +  " ) " +
            //" group by c.referencia having qtdconsignado > 0 ");

            StringBuilder referências = new StringBuilder();
            bool primeiro = true;

            foreach (MercadoriaEmFaltaCliente m in listaPedidos)
            {
                if (!primeiro)
                    referências.Append(",");

                referências.Append(DbTransformar(m.ReferênciaNumérica));
                primeiro = false;
            }
            string referênciasString = referências.ToString();

            StringBuilder comando = new StringBuilder();
            comando.Append(" select referencia, sum(s)-sum(r)-sum(v) from "
            + " ( select referencia, SUM(quantidade) as s, 0 as r, 0 as v from saida, saidaitem  "
            + " WHERE saida.acerto IN (select codigo from acertoconsignado where cliente=");
            comando.Append(DbTransformar(pessoa));
            comando.Append(" and dataEfetiva is null) "
            + " and referencia IN (");
            comando.Append(referênciasString);
            comando.Append(") and saida.codigo=saidaitem.saida group by referencia having s > 0"
            + " UNION select referencia, 0 as s, SUM(quantidade) as r, 0 as v from retorno, retornoitem  "
            + " WHERE retorno.acerto IN (select codigo from acertoconsignado where cliente=");
            comando.Append(DbTransformar(pessoa));
            comando.Append(" and dataEfetiva is null)  and referencia IN (");
            comando.Append(referênciasString);
            comando.Append(") and retorno.codigo=retornoitem.retorno group by referencia having r > 0"
            + " UNION select referencia, 0 as s, 0 as r, SUM(quantidade) as v from venda, vendaitem  "
            + " WHERE venda.acerto IN (select codigo from acertoconsignado where cliente=");
            comando.Append(DbTransformar(pessoa));
            comando.Append(" and dataEfetiva is null)  and referencia IN (");
            comando.Append(referênciasString);
            comando.Append(") and venda.codigo=vendaitem.venda group by referencia having v > 0 ) a  group by referencia ");



            IDbConnection conexão = Conexão;
            IDataReader leitor = null;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {

                    try
                    {
                        cmd.CommandText = comando.ToString();
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string referência = leitor.GetString(0);
                                double quantidade = leitor.GetDouble(1);

                                List<MercadoriaEmFaltaCliente> lista = hash[referência];
                                foreach (MercadoriaEmFaltaCliente m in lista)
                                {
                                    m.QuantidadeConsignado = (int)quantidade;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                    }
                }
            }

            return listaPedidos;
        }
       
    }
}
