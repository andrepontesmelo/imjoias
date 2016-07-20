using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Pedido.PedidosParaFornecedores
{
    public class ControleImpressãoPedidosParaFornecedores
    {
        public static void PrepararImpressão(ReportClass relatório, List<Entidades.PedidoConserto.Pedido> pedidos)
        {
            DataSetPedidosParaFornecedores ds = new DataSetPedidosParaFornecedores();

            PrepararFornecedores(ds);
            PrepararItens(pedidos, ds);
            PrepararObservações(pedidos, ds);

            relatório.SetDataSource(ds);
            relatório.Subreports["RelatórioPedido.rpt"].SetDataSource(ds);
        }

        private static void PrepararItens(List<Entidades.PedidoConserto.Pedido> pedidos, DataSetPedidosParaFornecedores ds)
        {
            DataTable tabelaPedidoItem = ds.Tables["PedidoItem"];
            List<Entidades.PedidoConserto.MercadoriaEmFalta> itens = Entidades.PedidoConserto.MercadoriaEmFalta.Obter(pedidos, true);

            foreach (Entidades.PedidoConserto.MercadoriaEmFalta item in itens)
            {
                DataRow linha = tabelaPedidoItem.NewRow();
                linha["referênciaFormatada"] = item.ReferênciaFormatada;
                linha["quantidade"] = item.Quantidade;
                linha["fornecedor"] = item.Fornecedor;
                linha["pedidos"] = item.Pedidos;
                linha["detalhes"] = item.Detalhes;
                linha["referênciaFornecedor"] = item.ReferênciaFornecedorFFL;
                linha["saldoConsignado"] = item.SaldoConsignado;

                tabelaPedidoItem.Rows.Add(linha);
            }
        }

        private static void PrepararFornecedores(DataSetPedidosParaFornecedores ds)
        {
            DataTable tabelaFornecedor = ds.Tables["Fornecedor"];
            IList<Entidades.Fornecedor> fornecedores = Entidades.Fornecedor.ObterFornecedores();
            foreach (Entidades.Fornecedor f in fornecedores)
            {
                DataRow linha = tabelaFornecedor.NewRow();
                linha["código"] = f.Código;

                tabelaFornecedor.Rows.Add(linha);
            }
        }

        private static void PrepararObservações(List<Entidades.PedidoConserto.Pedido> pedidos, DataSetPedidosParaFornecedores ds)
        {
            DataTable tabelaPedido = ds.Tables["Pedido"];
            foreach (Entidades.PedidoConserto.Pedido p in pedidos)
            {
                if (!p.DataConclusão.HasValue && p.Observações != null && p.Observações.Trim().Length > 0)
                {
                    DataRow linha = tabelaPedido.NewRow();
                    linha["código"] = p.Código;
                    linha["observações"] = p.Observações.Trim();
                    tabelaPedido.Rows.Add(linha);
                }
            }
        }
    }
}
