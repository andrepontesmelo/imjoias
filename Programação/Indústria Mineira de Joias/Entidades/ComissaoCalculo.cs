using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Acesso.Comum;
using Entidades.Mercadoria;

namespace Entidades
{
    public class ComissaoCalculo : DbManipulaçãoSimples
    {
        public static string ObterComissao(List<int> vendas)
        {
            if (vendas.Count == 0) return "";

            IDbConnection conexao;
            IDataReader leitor;

            StringBuilder resultado = new StringBuilder();

            StringBuilder grupoVendas = new StringBuilder("(");
            bool primeiro = true;

            foreach (int v in vendas) 
            {
                if (!primeiro)
                    grupoVendas.Append(",");

                grupoVendas.Append(v.ToString());

                primeiro = false;
            }
            grupoVendas.Append(")");

            // Total de comisssão por faixa

            String consultaFaixa = "select * from " +
                " (select c.faixa, c.comissaovenda-c.comissaodevolucao as comissao from " +
                " ( " +
                " select a.faixa, ifnull(comissaovenda,0) as comissaovenda, ifnull(comissaodevolucao,0) as comissaodevolucao " +

                " from " +
                " ( " +

                " select mercadoria.faixa, " +
                " sum(vendaitem.indice * vendaitem.quantidade * venda.cotacao * if(mercadoria.depeso,  0.05, 0.10)) as comissaovenda " +

                " from venda " +
                " left join vendaitem on venda.codigo=vendaitem.venda " +
                " left join mercadoria on vendaitem.referencia=mercadoria.referencia " +
                " where venda in " + grupoVendas.ToString() +
                " group by mercadoria.faixa " +
                " ) a " +
                " left join " +
                " ( " +
                " select mercadoria.faixa, " +
                " sum(vendadevolucao.indice * vendadevolucao.quantidade * venda.cotacao * if(mercadoria.depeso,  0.05, 0.10)) as comissaodevolucao " +

                " from venda " +
                " left join vendadevolucao on venda.codigo=vendadevolucao.venda " +
                " left join mercadoria on vendadevolucao.referencia=mercadoria.referencia " +
                " where venda in  " + grupoVendas.ToString() +
                " group by mercadoria.faixa " +
                " ) b on  a.faixa=b.faixa " +
                " ) c) d ";

            resultado.Append("\r\n===================================");
            resultado.Append("\r\nTOTAL DE COMISSAO POR FAIXA");
            resultado.Append("\r\n===================================");

            //call calcularcomissao()
            using (conexao = Conexão) {
                using (IDbCommand cmd = conexao.CreateCommand()) {
                    cmd.CommandText = "CALL CALCULARCOMISSAO()";
                    cmd.ExecuteNonQuery();
                }
            }

            using (conexao = Conexão) {
                using (IDbCommand cmd = conexao.CreateCommand()) {
                    cmd.CommandText = consultaFaixa;
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read()) {
                        resultado.Append("\r\nFAIXA " + leitor.GetString(0) + " \tR$ " + Math.Round(leitor.GetDouble(1), 2).ToString());
                    }

                    leitor.Close();
                }
            }

            resultado.Append("\r\n===================================");
            resultado.Append("\r\nTOTAL DE COMISSAO POR VENDA");
            resultado.Append("\r\n===================================");
            
            resultado.Append("\r\nVENDA\tTOTAL R$\tCOMSSAO R$");

            // Total da comissão por venda
            //

            double totalComissão = 0;
            double totalValor = 0;

            using (conexao = Conexão) {
                using (IDbCommand cmd = conexao.CreateCommand()) {
                    cmd.CommandText = "select venda.codigo, vendasintetizada.valortotal, venda.comissao from venda join vendasintetizada on venda.codigo=vendasintetizada.codigo WHERE venda.codigo in " + grupoVendas.ToString();
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read()) {
                        double comissão = Math.Round(leitor.GetDouble(2), 2);
                        double valor = Math.Round(leitor.GetDouble(1), 2);

                        resultado.Append("\r\n" + leitor.GetInt32(0).ToString() + " \t" + valor.ToString() +
                        "\t" + comissão.ToString());

                        totalComissão += comissão;
                        totalValor += valor;
                    }

                    leitor.Close();
                }
            }

            resultado.Append("\r\n===================================");
            resultado.Append("\r\nTOTAL\tR$ " + totalValor.ToString() + "\t" + totalComissão.ToString());
            resultado.Append("\r\n===================================");

            return resultado.ToString();
        }
    }
}
