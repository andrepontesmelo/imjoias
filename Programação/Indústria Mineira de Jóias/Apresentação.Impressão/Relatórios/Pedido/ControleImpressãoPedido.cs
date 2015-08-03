using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;

namespace Apresentação.Impressão.Relatórios.Pedido
{
    public class ControleImpressãoPedido
    {
        public void PrepararImpressão(ReportClass relatório, IEnumerable<Entidades.Pedido> pedidos, DateTime início, DateTime fim, bool apenasConsertos, bool períodoPrevisão)
        {
            DataSetPedido ds = new DataSetPedido();
            DataTable tabela = ds.Tables["Pedido"];
            DataTable info = ds.Tables["Informações"];
            DataRow item = info.NewRow();
            item["dataInicio"] = início.ToShortDateString();
            item["dataFim"] = fim.ToShortDateString();
            item["título"] = apenasConsertos ? "Relação de Consertos" : "Relação de Pedidos";
            item["tipoPeríodo"] = períodoPrevisão ? "Previsão" : "Recebido";

            info.Rows.Add(item);

            List<Entidades.Pedido> listaPedidos = new List<Entidades.Pedido>();

            foreach (Entidades.Pedido pedido in pedidos)
            {
                /* Na apresentação, pode-se escolher entre já entregues ou não.
                 * Porém, apenas os ainda não entregues são obtidos para impressão.
                 * 
                 * É necessário filtrar ainda ou já concluidos.
                 * Só é impresso a pendência, ou seja, os pedidos não concluídos.
                 */

                if (!pedido.DataConclusão.HasValue)
                    listaPedidos.Add(pedido);
            }

            //listaPedidos.Sort();
            
            foreach (Entidades.Pedido p in listaPedidos)
            {
                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }

            relatório.SetDataSource(ds);
        }

        private void MapearItem(Entidades.Pedido pedido, DataRow linha)
        {
            linha["código"] = pedido.Código;

            switch (pedido.TipoPedido)
            {
                case Entidades.Pedido.Tipo.Conserto:
                    linha["tipo"] = "Conserto";
                    break;

                case Entidades.Pedido.Tipo.Pedido:
                    linha["tipo"] = "Pedido";
                    break;

                default:
                    throw new NotSupportedException();
            }

            List<Entidades.Pessoa.Endereço.Endereço> endereços =
            pedido.Cliente.Endereços.ExtrairElementos();

            string cidade = endereços.Count > 0 ? endereços[0].Localidade != null ? endereços[0].Localidade.Nome + endereços[0].Localidade.Estado != null ? " - " + endereços[0].Localidade.Estado.Sigla : "" : "" : "";

            linha["cliente"] = pedido.Cliente.Nome + "(cód " + pedido.Cliente.Código.ToString() + ") " + cidade;
            linha["representante"] = pedido.Representante != null ? pedido.Representante.Nome : "";
            linha["receptor"] = pedido.Receptor.PrimeiroNome;
            linha["dataRecepção"] = pedido.DataRecepção;
            linha["dataPrevisão"] = pedido.DataPrevisão;
            linha["observações"] = pedido.Observações;
            linha["controle"] = pedido.Controle != null ? pedido.Controle.ToString() : "";
        }
    }
}
