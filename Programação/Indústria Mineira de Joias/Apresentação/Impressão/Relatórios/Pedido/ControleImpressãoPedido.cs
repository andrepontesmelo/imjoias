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

namespace Apresentação.Impressão.Relatórios.Pedido
{
    public class ControleImpressãoPedido
    {
        public void PrepararImpressão(ReportClass relatório, List<Entidades.PedidoConserto.Pedido> pedidos, DateTime início, DateTime fim, bool apenasConsertos, bool períodoPrevisão)
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

            DataTable tabelaItens = ds.Tables["Itens"];
            PrepararItens(pedidos, tabelaItens);

            DataTable tabelaRastro = ds.Tables["Rastro"];
            Dictionary<string, List<Entidades.Mercadoria.Mercadoria.RastroConsignado>> rastreamentos = Entidades.Mercadoria.Mercadoria.ObterRastreamento();
            
            foreach (KeyValuePair<string, List<Entidades.Mercadoria.Mercadoria.RastroConsignado>> par in rastreamentos)
            {
                foreach (Entidades.Mercadoria.Mercadoria.RastroConsignado rastro in par.Value)
                {
                    DataRow linha = tabelaRastro.NewRow();
                    linha["referênciaNumérica"] = par.Key;
                    linha["referênciaRastreável"] = Entidades.Mercadoria.Mercadoria.ObterReferênciaRastreável(par.Key);
                    linha["quantidade"] = rastro.Quantidade;
                    linha["pessoaNome"] = Entidades.Pessoa.Pessoa.AbreviarNome(rastro.Pessoa.Nome);

                    tabelaRastro.Rows.Add(linha);
                }
            }


            List<Entidades.PedidoConserto.Pedido> listaPedidos = new List<Entidades.PedidoConserto.Pedido>();

            foreach (Entidades.PedidoConserto.Pedido pedido in pedidos)
            {
                /* Na apresentação, pode-se escolher entre já entregues ou não.
                 * Porém, apenas os ainda não entregues são obtidos para impressão.
                 * C:\Users\Andre Pontes\Source\Repos\imjoias\Programação\Indústria Mineira de Joias\Apresentação\Impressão\Relatórios\Pedido\ControleImpressãoPedido.cs
                 * É necessário filtrar ainda ou já concluidos.
                 * Só é impresso a pendência, ou seja, os pedidos não concluídos.
                 */

                if (!pedido.DataConclusão.HasValue)
                    listaPedidos.Add(pedido);
            }

            //listaPedidos.Sort();
            
            foreach (Entidades.PedidoConserto.Pedido p in listaPedidos)
            {
                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }

            relatório.SetDataSource(ds);
        }

        private static void MapearItem(Entidades.PedidoConserto.Pedido pedido, DataRow linha)
        {
            linha["código"] = pedido.Código;

            switch (pedido.TipoPedido)
            {
                case Entidades.PedidoConserto.Pedido.Tipo.Conserto:
                    linha["tipo"] = "Conserto";
                    break;

                case Entidades.PedidoConserto.Pedido.Tipo.Pedido:
                    linha["tipo"] = "Pedido";
                    break;

                default:
                    throw new NotSupportedException();
            }

            if (pedido.Cliente != null)
            {
                List<Entidades.Pessoa.Endereço.Endereço> endereços =
                pedido.Cliente.Endereços.ExtrairElementos();

                string cidade = endereços.Count > 0 ? endereços[0].Localidade != null ? endereços[0].Localidade.Nome + endereços[0].Localidade.Estado != null ? " - " + endereços[0].Localidade.Estado.Sigla : "" : "" : "";
                linha["cliente"] = pedido.Cliente.Nome + " (" + pedido.Cliente.Código.ToString() + ") " + cidade;
            } else
                linha["cliente"] = pedido.NomeDoCliente;
                

            linha["representante"] = pedido.Representante != null ? Entidades.Pessoa.Pessoa.AbreviarNome(pedido.Representante.Nome) : "";
            linha["receptor"] = pedido.Receptor.PrimeiroNome;
            linha["dataRecepção"] = pedido.DataRecepção;
            linha["dataPrevisão"] = pedido.DataPrevisão;
            linha["observações"] = pedido.Observações;
            
            //linha["controle"] = pedido.Controle != null ? pedido.Controle.ToString() : "";
        }

        public static void PrepararItens(List<Entidades.PedidoConserto.Pedido> pedidos, DataTable tabelaItens)
        {
            Dictionary<string, MercadoriaFornecedor> fornecedores = MercadoriaFornecedor.ObterFornecedores();
            List<PedidoItem> itens = PedidoItem.Obter(pedidos);
            foreach (PedidoItem p in itens)
            {
                DataRow linha = tabelaItens.NewRow();
                linha["código"] = p.Código;
                linha["pedido"] = p.Pedido;
                linha["quantidade"] = p.Quantidade;
                linha["referênciaFormatada"] = p.ReferênciaFormatada;
                linha["referênciaNumérica"] = p.ReferênciaNumérica;
                linha["referênciaRastreável"] = Entidades.Mercadoria.Mercadoria.ObterReferênciaRastreável(p.ReferênciaNumérica);

                if (!String.IsNullOrEmpty(p.Descrição))
                    linha["descrição"] = p.Descrição.Replace("\r\n"," ");

                MercadoriaFornecedor fornecedor = null;
                if ((p.ReferênciaNumérica != null) && fornecedores.TryGetValue(p.ReferênciaNumérica, out fornecedor))
                {
                    linha["fornecedor"] = fornecedor.FornecedorCódigo.ToString();
                    linha["refFornecedor"] = fornecedor.ReferênciaFornecedorComFFL;
                }

                tabelaItens.Rows.Add(linha);
            }
        }

    }
}
