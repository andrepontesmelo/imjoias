using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;
using Entidades.Mercadoria;

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

            DataRow linha2 = tabelaItens.NewRow();
            linha2["código"] = 22;
            linha2["pedido"] = 33;
            linha2["referênciaFormatada"] = "ref. formatada";

            tabelaItens.Rows.Add(linha2);

            relatório.SetDataSource(ds);
            //relatório.Subreports["Miolo.rpt"].SetDataSource(ds);
        }


        private static void MapearItem(Entidades.PedidoConserto.Pedido pedido, DataRow linha)
        {
            //linha["código"] = pedido.Controle.HasValue ? pedido.Controle.Value : pedido.Código;
            linha["código"] = pedido.Código;
            linha["tipoPedido"] = pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Pedido;

            //List<Entidades.Pessoa.Endereço.Endereço> endereços =
            //pedido.Cliente.Endereços.ExtrairElementos();
            //string cidade = endereços.Count > 0 ? endereços[0].Localidade != null ? endereços[0].Localidade.Nome + endereços[0].Localidade.Estado != null ? " - " + endereços[0].Localidade.Estado.Sigla : "" : "" : "";

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
            //linha["controle"] = pedido.Controle != null ? pedido.Controle.ToString() : "";
        }
    }
}
