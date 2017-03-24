using CrystalDecisions.CrystalReports.Engine;
using Entidades.Mercadoria;
using Entidades.PedidoConserto;
using System;
using System.Collections.Generic;
using System.Data;

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

            PrepararItens(pedidos, ds.Tables["Itens"]);
            AdicionarRastreamento(ds.Tables["Rastro"], Entidades.Mercadoria.Mercadoria.ObterRastreamento());
            AdicionarPedidosPendentes(pedidos, tabela);
            relatório.SetDataSource(ds);
        }

        private static void AdicionarPedidosPendentes(List<Entidades.PedidoConserto.Pedido> pedidos, DataTable tabela)
        {
            foreach (Entidades.PedidoConserto.Pedido p in ObterPedidosPendentes(pedidos))
            {
                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }
        }

        private static List<Entidades.PedidoConserto.Pedido> ObterPedidosPendentes(List<Entidades.PedidoConserto.Pedido> pedidos)
        {
            List<Entidades.PedidoConserto.Pedido> listaPedidos = new List<Entidades.PedidoConserto.Pedido>();

            foreach (Entidades.PedidoConserto.Pedido pedido in pedidos)
            {
                if (!pedido.DataConclusão.HasValue)
                    listaPedidos.Add(pedido);
            }

            return listaPedidos;
        }

        private static void AdicionarRastreamento(DataTable tabelaRastro, Dictionary<string, List<Entidades.Mercadoria.Mercadoria.RastroConsignado>> rastreamentos)
        {
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
        }

        private static void MapearItem(Entidades.PedidoConserto.Pedido pedido, DataRow linha)
        {
            linha["código"] = pedido.Código;
            linha["tipo"] = ObterTipoPedido(pedido.TipoPedido);

            linha["cliente"] = (pedido.Cliente != null) ?
                pedido.Cliente.Nome + " (" + pedido.Cliente.Código.ToString() + ") " + ObterCidade(pedido) :
                pedido.NomeDoCliente;

            linha["representante"] = pedido.Representante != null ? Entidades.Pessoa.Pessoa.AbreviarNome(pedido.Representante.Nome) : "";
            linha["receptor"] = pedido.Receptor.PrimeiroNome;
            linha["dataRecepção"] = pedido.DataRecepção;
            linha["dataPrevisão"] = pedido.DataPrevisão;
            linha["observações"] = pedido.Observações;
        }

        private static string ObterCidade(Entidades.PedidoConserto.Pedido pedido)
        {
            List<Entidades.Pessoa.Endereço.Endereço> endereços = pedido.Cliente.Endereços.ExtrairElementos();
            return endereços.Count > 0 ? endereços[0].Localidade != null ? endereços[0].Localidade.Nome + endereços[0].Localidade.Estado != null ? " - " + endereços[0].Localidade.Estado.Sigla : "" : "" : "";
        }

        private static object ObterTipoPedido(Entidades.PedidoConserto.Pedido.Tipo tipo)
        {
            switch (tipo)
            {
                case Entidades.PedidoConserto.Pedido.Tipo.Conserto:
                    return "Conserto";

                case Entidades.PedidoConserto.Pedido.Tipo.Pedido:
                    return "Pedido";

                default:
                    throw new NotSupportedException();
            }
        }

        public static void PrepararItens(List<Entidades.PedidoConserto.Pedido> pedidos, DataTable tabelaItens)
        {
            Dictionary<string, MercadoriaFornecedor> fornecedores = MercadoriaFornecedor.ObterFornecedores();
            List<PedidoItem> itens = PedidoItem.Obter(pedidos);

            foreach (PedidoItem item in itens)
            {
                AdicionarItem(tabelaItens, fornecedores, item);
            }
        }

        private static void AdicionarItem(DataTable tabelaItens, Dictionary<string, MercadoriaFornecedor> hashFornecedores, PedidoItem item)
        {
            DataRow linha = tabelaItens.NewRow();
            linha["código"] = item.Código;
            linha["pedido"] = item.Pedido;
            linha["quantidade"] = item.Quantidade;
            linha["referênciaFormatada"] = item.ReferênciaFormatada;
            linha["referênciaNumérica"] = item.ReferênciaNumérica;
            linha["referênciaRastreável"] = Entidades.Mercadoria.Mercadoria.ObterReferênciaRastreável(item.ReferênciaNumérica);

            if (!String.IsNullOrEmpty(item.Descrição))
                linha["descrição"] = item.Descrição.Replace("\r\n", " ");

            MercadoriaFornecedor fornecedor = null;
            if ((item.ReferênciaNumérica != null) && hashFornecedores.TryGetValue(item.ReferênciaNumérica, out fornecedor))
            {
                linha["fornecedor"] = fornecedor.FornecedorCódigo.ToString();
                linha["refFornecedor"] = fornecedor.ReferênciaFornecedorComFFL;
            }

            tabelaItens.Rows.Add(linha);
        }
    }
}
