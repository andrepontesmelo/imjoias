using Entidades.Fiscal.Fabricação;
using System.Collections.Generic;
using System.Data;
using System;
using Entidades.Fiscal;

namespace Apresentação.Impressão.Relatórios.Fiscal.Fabricação
{
    public class ControladorImpressãoFabricação : ControladorImpressãoFiscal
    {
        private Dictionary<string, MercadoriaFechamento> hashFechamento;

        public RelatórioFabricação CriarRelatório(FabricaçãoFiscal fabricação)
        {
            var relatório = new RelatórioFabricação();
            var dataset = new DataSetFabricação();
            relatório.SetDataSource(dataset);

            CriarAdicionarDocumento(dataset, fabricação);

            hashFechamento = MercadoriaFechamento.ObterHash(Fechamento.Obter(fabricação.Data).Código);
            CriarItens(SaídaFabricaçãoFiscal.Obter(fabricação.Código), true, dataset.Tables["Item"]);
            CriarItens(EntradaFabricaçãoFiscal.Obter(fabricação.Código), false, dataset.Tables["Item"]);

            return relatório;
        }

        private void CriarItens(List<ItemFabricaçãoFiscal> entidades, bool saída, DataTable tabelaItens)
        {
            foreach (var entidade in entidades)
            {
                DataRow item = CriarItem(tabelaItens, entidade, saída);
                tabelaItens.Rows.Add(item);
            }
        }


        private void CriarAdicionarDocumento(DataSetFabricação dataset, FabricaçãoFiscal entidade)
        {
            var tabelaDocumento = dataset.Tables["Documento"];
            tabelaDocumento.Rows.Add(CriarDocumento(tabelaDocumento, entidade));
        }

        private DataRow CriarDocumento(DataTable tabelaDocumento, FabricaçãoFiscal entidade)
        {
            var linha = CriarDocumento(tabelaDocumento);
            linha["data"] = entidade.DataFormatada;
            linha["código"] = entidade.Código;

            return linha;
        }

        private DataRow CriarItem(DataTable tabelaItens, ItemFabricaçãoFiscal entidade, bool saída)
        {
            var item = tabelaItens.NewRow();

            item["código"] = entidade.Código.ToString();
            item["referência"] = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
            item["quantidade"] = entidade.Quantidade.ToString();
            item["tipo"] = ObterTipo(saída);
            item["valor"] = entidade.Valor;

            if (hashFechamento != null)
            {
                var descrição = "";

                MercadoriaFechamento mercadoriaFechamento;
                if (hashFechamento.TryGetValue(entidade.Referência, out mercadoriaFechamento))
                    descrição = mercadoriaFechamento.Descrição;

                item["descrição"] = descrição; 
            }

            return item;
        }

        private object ObterTipo(bool saída)
        {
            return (saída ? "TO" : "OT");
        }
    }
}
