using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFaltaCliente
{
    public class ControleImpressão
    {
        public static void PrepararImpressão(ReportClass relatório,
            List<Entidades.Mercadoria.MercadoriaEmFaltaCliente> itens,
            Entidades.Pessoa.Pessoa emPosseDe)
        {
            DataSetMercadoriaEmFaltaCliente ds = new DataSetMercadoriaEmFaltaCliente();
            DataTable tabelaItens = ds.Tables["Itens"];

            foreach (Entidades.Mercadoria.MercadoriaEmFaltaCliente item in itens)
            {
                DataRow linha = tabelaItens.NewRow();
                linha["referência"] = Entidades.Mercadoria.Mercadoria.MascararReferência(item.ReferênciaNumérica);
                linha["pedido"] = item.Pedido;
                linha["qtdPedido"] = item.QuantidadePedido;
                linha["qtdConsignação"] = item.QuantidadeConsignado;
                linha["dataPedido"] = item.DataPedido.ToShortDateString();
                linha["cliente"] = item.ClienteNome;
                linha["descrição"] = item.Descricao;

                tabelaItens.Rows.Add(linha);
            }


            DataTable tabelaInformações = ds.Tables["Informações"];
            DataRow linhaÚnica = tabelaInformações.NewRow();
            linhaÚnica["cliente"] = emPosseDe.Nome;
            tabelaInformações.Rows.Add(linhaÚnica);

            relatório.SetDataSource(ds);
        }
    }
}
