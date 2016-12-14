using Entidades.Fiscal;
using Entidades.Fiscal.Registro;
using System;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Fiscal.Inventário
{
    public class ControladorImpressãoInventário : ControladorImpressãoFiscal
    {
        public RelatórioInventário CriarRelatório(Fechamento fechamento)
        {
            var relatório = new RelatórioInventário();
            var dataset = new DataSetInventário();
            relatório.SetDataSource(dataset);

            CriarAdicionarDocumento(dataset, fechamento.Fim);
            CriarItens(Entidades.Fiscal.Inventário.Obter(fechamento), dataset.Tables["Item"]);

            return relatório;
        }

        private void CriarItens(List<Entidades.Fiscal.Inventário> entidades, DataTable tabelaItens)
        {
            foreach (var entidade in entidades)
            {
                DataRow item = CriarItem(tabelaItens, entidade);
                tabelaItens.Rows.Add(item);
            }
        }


        private void CriarAdicionarDocumento(DataSetInventário dataset, DateTime data)
        {
            var tabelaDocumento = dataset.Tables["Documento"];
            tabelaDocumento.Rows.Add(CriarDocumento(tabelaDocumento, data));
        }

        private DataRow CriarDocumento(DataTable tabelaDocumento, DateTime data)
        {
            var linha = CriarDocumento(tabelaDocumento);
            linha["data"] = string.Format("{0}", data.ToShortDateString());

            return linha;
        }

        protected override DataRow CriarItem(DataTable tabelaItens, RegistroAbstrato entidadeGenérica)
        {
            DataRow item = base.CriarItem(tabelaItens, entidadeGenérica);

            var entidade = (Entidades.Fiscal.Inventário)entidadeGenérica;

            item["valorUnitário"] = entidade.ValorUnitário;
            item["valorTotal"] = entidade.ValorTotal;
            item["quantidade"] = entidade.Quantidade.ToString();

            return item;
        }
    }
}

