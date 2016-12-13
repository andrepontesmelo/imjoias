using System;
using System.Data;
using Entidades.Fiscal.Registro;
using System.Collections.Generic;
using Entidades.Fiscal;

namespace Apresentação.Impressão.Relatórios.Fiscal.Extrato
{
    public class ControladorImpressãoExtrato : ControladorImpressãoFiscal
    {
        private Dictionary<string, decimal> hashReferênciaInventárioAnterior;

        public RelatórioExtrato CriarRelatório(string referência, Fechamento fechamento)
        {
            var relatório = new RelatórioExtrato();
            var dataset = new DataSetExtrato();
            relatório.SetDataSource(dataset);
            hashReferênciaInventárioAnterior = InventárioRelativo.ObterHashReferênciaQuantidadeInventárioAnterior(fechamento.Início);

            CriarAdicionarDocumento(dataset, fechamento.Início, fechamento.Fim);
            CriarItens(Entidades.Fiscal.Extrato.ObterEstoqueAcumulado(referência, fechamento), dataset.Tables["Item"]);

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

            item["cfop"] = entidade.CFOP;
            item["data"] = entidade.DataFormatada;
            item["valor"] = entidade.ValorFormatado;
            item["tipoResumido"] = entidade.TipoResumido;
            item["entradaSaída"] = entidade.EntradaSaída;
            item["quantidade"] = entidade.Quantidade.ToString();
            item["estoque"] = entidade.Estoque.ToString();

            decimal estoqueAnterior = 0;
            hashReferênciaInventárioAnterior.TryGetValue(entidadeGenérica.Referência, out estoqueAnterior);
            item["estoqueAnterior"] = estoqueAnterior;

            return item;
        }
    }
}
