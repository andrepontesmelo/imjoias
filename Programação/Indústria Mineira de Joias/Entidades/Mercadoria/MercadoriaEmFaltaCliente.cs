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

        public string ReferênciaRastreável
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
                string.Format(
                " select p.codigo as pedido, p.dataRecepcao, substr(i.mercadoria,1,{0}) as referencia, pessoa.nome as clienteNome, " +
                " sum(i.quantidade) as qtdpedido, group_concat(i.descricao) as descricao " +
                " FROM pedido p JOIN pedidoitem i ON p.codigo=i.pedido " +
                " JOIN pessoa ON pessoa.codigo=p.cliente " +
                " WHERE tipo = 'E' AND dataEntrega is null " +
                " AND substr(i.mercadoria,1,{0}) in " +
                " ( " +
                "   select distinct substr(referencia,1,{0}) " +
                "   FROM saidaitem i  " +
                "   JOIN saida s ON s.codigo=i.saida " +
                "   JOIN acertoconsignado a ON s.acerto=a.codigo " +
                "   WHERE pessoa={1} and dataEfetiva is null " +
                " ) " +
                " GROUP BY p.codigo, i.mercadoria  order by dataRecepcao ", Mercadoria.TAMANHO_REFERÊNCIA_RASTREÁVEL, pessoa));

            if (listaPedidos.Count == 0)
                return listaPedidos;

            // Dado a referência, retorna a lista de pedidos que a contém
            Dictionary<string, List<MercadoriaEmFaltaCliente>> hash = new Dictionary<string, List<MercadoriaEmFaltaCliente>>(StringComparer.Ordinal);
            foreach (MercadoriaEmFaltaCliente m in listaPedidos)
            {
                List<MercadoriaEmFaltaCliente> lista = null;

                if (!hash.TryGetValue(m.ReferênciaRastreável, out lista))
                {
                    lista = new List<MercadoriaEmFaltaCliente>();
                    hash[m.ReferênciaRastreável] = lista;
                }

                lista.Add(m);
            }

            StringBuilder referências = new StringBuilder();
            bool primeiro = true;

            foreach (MercadoriaEmFaltaCliente m in listaPedidos)
            {
                if (!primeiro)
                    referências.Append(",");

                referências.Append(DbTransformar(m.ReferênciaRastreável));
                primeiro = false;
            }
            string referênciasString = referências.ToString();

            string comando = string.Format(
                " SELECT referencia," +
                "        sum(s)-sum(r)-sum(v)" +
                " FROM" +
                "     (SELECT substr(referencia,1,{0}) as referencia, SUM(quantidade) AS s, 0 AS r, 0 AS v" +
                "     FROM saida sa JOIN saidaitem si ON sa.codigo=si.saida" +
                "      WHERE sa.acerto IN (SELECT codigo FROM acertoconsignado WHERE cliente={1} AND dataEfetiva IS NULL)" +
                "      AND substr(referencia,1,{0}) IN ({2})" +
                "      GROUP BY substr(referencia,1,{0})" +
                "      HAVING s > 0" +
                "      UNION SELECT substr(referencia,1,{0}) as referencia,0 AS s,SUM(quantidade) AS r, 0 AS v" +
                "      FROM retorno re JOIN retornoitem ri ON re.codigo=ri.retorno" +
                "      WHERE re.acerto IN" +
                "              (SELECT codigo" +
                "               FROM acertoconsignado" +
                "               WHERE cliente={1} AND dataEfetiva IS NULL)" +
                "          AND substr(referencia,1,{0}) IN ({2})" +
                "      GROUP BY substr(referencia,1,{0})" +
                "      HAVING r > 0" +
                "      UNION SELECT substr(referencia,1,{0}) as referencia," +
                "                   0 AS s, 0 AS r, SUM(quantidade) AS v" +
                "      FROM venda ve JOIN vendaitem vi ON ve.codigo=vi.venda" +
                "      WHERE ve.acerto IN" +
                "              (SELECT codigo" +
                "               FROM acertoconsignado" +
                "               WHERE cliente={1} AND dataEfetiva IS NULL)" +
                "          AND substr(referencia,1,{0}) IN ({2})" +
                "      GROUP BY substr(referencia,1,{0})" +
                "      HAVING v > 0) a" +
                " GROUP BY referencia", Mercadoria.TAMANHO_REFERÊNCIA_RASTREÁVEL, pessoa, referênciasString);

            IDbConnection conexão = Conexão;
            IDataReader leitor = null;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {

                    try
                    {
                        cmd.CommandText = comando;
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
