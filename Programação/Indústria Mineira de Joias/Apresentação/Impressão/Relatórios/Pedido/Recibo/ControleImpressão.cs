using CrystalDecisions.CrystalReports.Engine;
using Entidades.Pessoa;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Pedido.Recibo
{
    public class ControleImpressão
    {
        public void PrepararImpressão(ReportClass relatório, List<Entidades.PedidoConserto.Pedido> pedidos)
        {
            DataSetRecibo ds = new DataSetRecibo();
            DataTable tabela = ds.Tables["Recibo"];
            foreach (Entidades.PedidoConserto.Pedido p in pedidos)
            {
                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }

            DataTable tabelaItens = ds.Tables["Itens"];
            ControleImpressãoPedido.PrepararItens(pedidos, tabelaItens);
            relatório.SetDataSource(ds);
        }


        private static void MapearItem(Entidades.PedidoConserto.Pedido pedido, DataRow linha)
        {
            linha["código"] = pedido.Código;
            linha["tipoPedido"] = pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Pedido;

            if (pedido.Cliente != null)
            {
                linha["clienteNome"] = pedido.Cliente.Nome;
                linha["clienteCódigo"] = pedido.Cliente.Código.ToString();
                if (pedido.Cliente.Telefones != null && pedido.Cliente.Telefones.ContarElementos() > 0)
                {
                    Telefone primeiroTelefone = pedido.Cliente.Telefones.ExtrairElementos()[0];
                    linha["telefoneCliente"] = string.Format("{0} {1}", primeiroTelefone.Número, primeiroTelefone.Descrição);
                }
            }
            else
            {
                linha["clienteNome"] = pedido.NomeDoCliente;
            }

            linha["representanteNome"] = pedido.Representante != null ? pedido.Representante.Nome : "";
            linha["recepçãoFuncionárioNome"] = pedido.Receptor.Nome;
            linha["dataRecepção"] = pedido.DataRecepção.ToShortDateString();
            linha["dataPrevisão"] = pedido.DataPrevisão.ToShortDateString();
            linha["observações"] =  pedido.Observações == null ? "" : pedido.Observações.ToUpper();
            linha["pertenceAoCliente"] = pedido.PertenceAoCliente;
            linha["despachar"] = pedido.EntregaPedido == Entidades.PedidoConserto.Pedido.Entrega.Despachar;
            linha["valor"] = pedido.Valor.ToString("C");
        }
    }
}
