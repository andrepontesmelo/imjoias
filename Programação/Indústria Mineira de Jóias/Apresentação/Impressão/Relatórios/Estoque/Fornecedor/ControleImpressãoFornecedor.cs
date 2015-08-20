using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Estoque.Fornecedor
{
    public class ControleImpressãoFornecedor 
    {
        public DataSet GerarDataSet(List<Entidades.Estoque.Saldo> itens)
        {
            DataSet ds = new DataSet();
            DataTable tabelaItens = ds.Tables["Itens"];

            // Preencher itens do relacionamento
            foreach (Entidades.Estoque.Saldo saldo in itens)
            {
                DataRow linha = tabelaItens.NewRow();
                MapearItem(linha, saldo);
                tabelaItens.Rows.Add(linha);
            }

            return ds;
        }
        /// <summary>
        /// Mapeia um saquinho para uma linha da tabela de itens do DataSet.
        /// </summary>
        protected virtual void MapearItem(DataRow linha, Entidades.Estoque.Saldo s)
        {
            linha["referência"] = Entidades.Mercadoria.Mercadoria.MascararReferência(s.Referencia, true);
            linha["entrada"] = s.Entrada;
            linha["venda"] = s.Venda;
            linha["devolução"] = s.Devolucao;
            linha["saldo"] = s.SaldoValor;

            linha["peso"] = s.Peso;
            linha["depeso"] = s.Depeso;
            linha["fornecedor"] = s.FornecedorNome.Trim();
            linha["reffornecedor"] = s.FornecedorReferência.Trim().ToUpper();
            linha["pesosaldo"] = s.ProdudoPesoSaldo;
        }

        public virtual void PrepararImpressão(ReportClass relatório, List<Entidades.Estoque.Saldo> itens)
        {
            relatório.SetDataSource(GerarDataSet(itens));
        }
    }
}
