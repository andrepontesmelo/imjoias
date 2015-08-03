using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;

namespace Apresentação.Impressão.Relatórios.Pedido.Recibo
{
    public class ControleImpressão
    {
        public void PrepararImpressão(ReportClass relatório, IEnumerable<Entidades.Pedido> pedidos)
        {
            DataSetRecibo ds = new DataSetRecibo();
            DataTable tabela = ds.Tables["Recibo"];

            foreach (Entidades.Pedido p in pedidos)
            {
                // Cada pedido 2 vias +)

                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);

                linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }

            relatório.SetDataSource(ds);
        }

        private void MapearItem(Entidades.Pedido pedido, DataRow linha)
        {
            linha["código"] = pedido.Controle.HasValue ? pedido.Controle.Value : pedido.Código;
            linha["tipoPedido"] = pedido.TipoPedido == Entidades.Pedido.Tipo.Pedido;

            //List<Entidades.Pessoa.Endereço.Endereço> endereços =
            //pedido.Cliente.Endereços.ExtrairElementos();
            //string cidade = endereços.Count > 0 ? endereços[0].Localidade != null ? endereços[0].Localidade.Nome + endereços[0].Localidade.Estado != null ? " - " + endereços[0].Localidade.Estado.Sigla : "" : "" : "";


            linha["clienteNome"] = pedido.Cliente.Nome;
            linha["clienteCódigo"] = pedido.Cliente.Código.ToString();
            linha["representanteNome"] = pedido.Representante != null ? pedido.Representante.Nome : "";
            linha["recepçãoFuncionárioNome"] = pedido.Receptor.Nome;
            linha["dataRecepção"] = pedido.DataRecepção.ToShortDateString();
            linha["dataPrevisão"] = pedido.DataPrevisão.ToShortDateString();
            linha["observações"] = pedido.Observações;
            linha["pertenceAoCliente"] = pedido.PertenceAoCliente;
            linha["despachar"] = pedido.EntregaPedido == Entidades.Pedido.Entrega.Despachar;

            //linha["controle"] = pedido.Controle != null ? pedido.Controle.ToString() : "";
        }
    }
}
