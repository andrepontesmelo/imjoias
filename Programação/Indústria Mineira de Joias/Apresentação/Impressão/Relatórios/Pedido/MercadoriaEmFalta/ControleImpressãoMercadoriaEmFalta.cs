using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;
using Entidades.Mercadoria;
using Entidades.PedidoConserto;

namespace Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFalta
{
    public class ControleImpressãoMercadoriaEmFalta
    {
        public static void PrepararImpressão(ReportClass relatório, List<Entidades.PedidoConserto.MercadoriaEmFalta> itens)
        {
            DataSetMercadoriaEmFalta ds = new DataSetMercadoriaEmFalta();
            DataTable tabelaPedidoItem = ds.Tables["PedidoItem"];
            List<Entidades.PedidoConserto.Pedido> pedidos =
                Entidades.PedidoConserto.MercadoriaEmFalta.ObterPedidosQueTemMercadoriasEmFalta();

            foreach (Entidades.PedidoConserto.MercadoriaEmFalta item in itens)
            {
                DataRow linha = tabelaPedidoItem.NewRow();
                linha["referênciaFormatada"] = item.ReferênciaFormatada;
                linha["quantidade"] = item.Quantidade;
                linha["fornecedor"] = item.Fornecedor;
                linha["pedidos"] = item.Pedidos;
                linha["detalhes"] = item.Detalhes;
                linha["referênciaFornecedor"] = item.ReferênciaFornecedor;
                linha["saldoConsignado"] = item.SaldoConsignado;

                tabelaPedidoItem.Rows.Add(linha);
            }

            // Observação dos pedidos
            DataTable tabelaPedido = ds.Tables["Pedido"];
            foreach (Entidades.PedidoConserto.Pedido p in pedidos)
            {
                //if (p.Observações != null && p.Observações.Trim().Length > 0
                //    && numeraçãoPedidosMostrados.Contains(p.Código.ToString()))
                if (!p.DataConclusão.HasValue && p.Observações != null && p.Observações.Trim().Length > 0)
                {
                    DataRow linha = tabelaPedido.NewRow();
                    linha["código"] = p.Código;
                    linha["observações"] = p.Observações.Trim();
                    tabelaPedido.Rows.Add(linha);
                }
            }

            relatório.SetDataSource(ds);
            relatório.Subreports["RelatórioPedido.rpt"].SetDataSource(ds);
        }
    }
}
