using System;
using System.Data;
using Entidades.Fiscal.Registro;
using System.Collections.Generic;

namespace Apresentação.Impressão.Relatórios.Fiscal.Extrato
{
    public class ControladorImpressãoExtrato : ControladorImpressãoFiscal
    {
        public RelatórioExtrato CriarRelatório(string referência, DateTime dataInicial, DateTime dataFinal)
        {
            var relatório = new RelatórioExtrato();
            var dataset = new DataSetExtrato();
            relatório.SetDataSource(dataset);

            CriarAdicionarDocumento(dataset, dataInicial, dataFinal);
            CriarItens(Entidades.Fiscal.Extrato.Obter(referência, dataInicial, dataFinal), dataset.Tables["Item"]);

            return relatório;
        }

        private void CriarAdicionarDocumento(DataSetExtrato dataset, DateTime dataInicial, DateTime dataFinal)
        {
            var tabelaDocumento = dataset.Tables["Documento"];
            tabelaDocumento.Rows.Add(CriarDocumento(tabelaDocumento, dataInicial, dataFinal));
        }

        private void CriarItens(List<Entidades.Fiscal.Extrato> entidades, DataTable tabelaItens)
        {
            foreach (var entidade in entidades)
            {
                DataRow item = CriarItem(tabelaItens, entidade);
                tabelaItens.Rows.Add(item);
            }
        }


        private DataRow CriarDocumento(DataTable tabelaDocumento, DateTime dataInicial, DateTime dataFinal)
        {
            var linha = CriarDocumento(tabelaDocumento);
            linha["dataInicial"] = dataInicial.ToShortDateString();
            linha["dataFinal"] = dataFinal.ToShortDateString();

            return linha;
        }

        protected override DataRow CriarItem(DataTable tabelaItens, RegistroAbstrato entidadeGenérica)
        {
            DataRow item = base.CriarItem(tabelaItens, entidadeGenérica);

            var entidade = (Entidades.Fiscal.Extrato) entidadeGenérica;

            item["data"] = entidade.DataFormatada;
            item["valor"] = entidade.ValorFormatado;
            item["tipoResumido"] = entidade.TipoResumido;
            item["estoqueAnterior"] = "est. ant.";
            item["entradaSaída"] = entidade.EntradaSaída;
            item["quantidade"] = entidade.Quantidade.ToString();

            return item;
        }
    }
}
