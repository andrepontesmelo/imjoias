using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using Entidades.Estatística;

namespace Entidades.Faturamento
{
    public class FaturamentoMercadorias : DbManipulaçãoSimples
    {
        public enum Agrupamento
        {
            Mercadoria
        }

        private Agrupamento agrupamento = Agrupamento.Mercadoria;

        /// <summary>
        /// Lista de informações das mercadorias.
        /// </summary>
        private LinkedList<InfoMercadoria> lista;

        /// <summary>
        /// Objeto plotável com informações sobre faturamento
        /// da mercadoria.
        /// </summary>
        public class InfoMercadoria : IPlotávelRotulado
        {
            private FaturamentoMercadorias pai;
            private IDMercadoria mercadoria;
            private double faturamento;
            private long qtd;

            internal InfoMercadoria(FaturamentoMercadorias pai, IDMercadoria mercadoria, double faturamento, long qtd)
            {
                this.pai = pai;
                this.mercadoria = mercadoria;
                this.faturamento = faturamento;
                this.qtd = qtd;
            }

            public double ObterValorPlotagem()
            {
                return faturamento;
            }

            public string ObterRótulo()
            {
                return pai.ObterSeqüênciaPlotagem(mercadoria);
            }

            public IDMercadoria Mercadoria
            {
                get { return mercadoria; }
            }

            public double Faturamento
            {
                get { return faturamento; }
            }

            public long Quantidade
            {
                get { return qtd; }
            }
        }

        /// <summary>
        /// Obtém o faturamento das mercadorias que correspondem a
        /// pelo menos uma porcentagem mínima do faturamento total.
        /// </summary>
        /// <param name="porcentagem">Porcentagem mínima.</param>
        /// <param name="períodoInicial">Período inicial.</param>
        /// <param name="períodoFinal">Período final.</param>
        public FaturamentoMercadorias(float porcentagemMínima, DateTime períodoInicial, DateTime períodoFinal)
        {
            IDbConnection conexão;
            lista = new LinkedList<InfoMercadoria>();
            //double restante;

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    IDataReader leitor;

                    cmd.CommandText = @"SELECT i.referencia, i.peso, SUM(i.indice * i.quantidade * v.cotacao) / "
                        + "(SELECT SUM(i.indice * i.quantidade * v.cotacao)"
                        + " FROM imjoias.vendaitem i JOIN imjoias.venda v ON v.codigo = i.venda"
                        + " WHERE v.data BETWEEN " + DbTransformar(períodoInicial) + " AND " + DbTransformar(períodoFinal)
                        + ") * 100 AS faturamento, sum(i.quantidade) AS qtd"
                        + " FROM imjoias.vendaitem i JOIN imjoias.venda v ON v.codigo = i.venda"
                        + " WHERE v.data BETWEEN " + DbTransformar(períodoInicial) + " AND " + DbTransformar(períodoFinal)
                        + " GROUP BY i.referencia, i.peso"
                        + " HAVING faturamento >= " + DbTransformar(porcentagemMínima)
                        + " ORDER BY faturamento DESC";

                    using (leitor = cmd.ExecuteReader())
                    {

                        try
                        {
                            while (leitor.Read())
                            {
                                InfoMercadoria info;

                                info = new InfoMercadoria(this, new IDMercadoria(
                                    leitor.GetString(0), leitor.GetDouble(1)),
                                    leitor.GetDouble(2),
                                    leitor.GetInt64(3));

                                lista.AddLast(info);
                            }
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();
                        }
                    }
                    //cmd.CommandText = @"SELECT SUM(faturamento) FROM (SELECT i.referencia, SUM(i.indice * i.quantidade * v.cotacao) AS faturamento"
                    //    + " FROM vendaItem i JOIN venda v ON v.codigo = i.venda"
                    //    + " WHERE v.data BETWEEN " + DbTransformar(períodoInicial) + " AND " + DbTransformar(períodoFinal)
                    //    + " GROUP BY i.referencia"
                    //    + " HAVING faturamento < ((SELECT SUM(indice * quantidade * cotacao) FROM vendaItem) / 100 * " + porcentagemMínima.ToString() + ")) f";

                    //restante = Convert.ToDouble(cmd.ExecuteScalar());
                }

            //lista.AddLast(new InfoMercadoria(this, null, restante, 0));
        }

        /// <summary>
        /// Faturamento das mercadorias.
        /// </summary>
        public LinkedList<InfoMercadoria> Itens
        {
            get { return lista; }
        }

        internal string ObterSeqüênciaPlotagem(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            if (mercadoria == null)
                return "Outros";

            switch (agrupamento)
            {
                case Agrupamento.Mercadoria:
                    return mercadoria.Referência + ", " + mercadoria.PesoFormatado;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
