using Entidades.Fiscal;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Fiscal.ListaDocumento
{
    public class ControladorImpressão : ControladorImpressãoFiscal
    {
        public Relatório CriarRelatório(string referência, Fechamento fechamento)
        {
            var relatório = new Relatório();
            var dataset = new DataSetListaDocumento();
            relatório.SetDataSource(dataset);

            CriarAdicionarDocumento(dataset, fechamento);
            CriarItens(new List<Entidades.Fiscal.Registro.RegistroAbstrato>(), dataset.Tables["Item"]);

            return relatório;
        }

        private void CriarAdicionarDocumento(DataSetListaDocumento dataset, Fechamento fechamento)
        {
            var tabelaDocumento = dataset.Tables["Documento"];
            tabelaDocumento.Rows.Add(CriarDocumento(tabelaDocumento, fechamento));
        }

        private void CriarItens(List<Entidades.Fiscal.Registro.RegistroAbstrato> entidades, DataTable tabelaItens)
        {
            foreach (var entidade in entidades)
            {
                DataRow item = CriarItem(tabelaItens);
                tabelaItens.Rows.Add(item);
            }
        }


        private DataRow CriarDocumento(DataTable tabelaDocumento, Fechamento fechamento)
        {
            var linha = CriarDocumento(tabelaDocumento);

            linha["título"] = "REGISTRO DE ENTRADAS";
            linha["fechamento"] = string.Format("DE: {0} ATÉ: {1}", fechamento.Início.ToShortDateString(),
                fechamento.Fim.ToShortDateString());

            return linha;
        }

        protected DataRow CriarItem(DataTable tabelaItens)
        {
            var item = tabelaItens.NewRow();

            //item["data"] = entidade.DataFormatada;

            return item;
        }
    }
}