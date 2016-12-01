using Entidades.Fiscal;
using Entidades.Fiscal.Registro;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Fiscal.ListaDocumento
{
    public class ControladorImpressão : ControladorImpressãoFiscal
    {
        public Relatório CriarRelatório(Fechamento fechamento, List<DocumentoFiscal> entidades, bool entradas)
        {
            var relatório = new Relatório();
            var dataset = new DataSetListaDocumento();
            relatório.SetDataSource(dataset);

            CriarAdicionarDocumento(dataset, fechamento, entradas);
            CriarItens(entidades, dataset.Tables["Item"]);

            return relatório;
        }

        private void CriarAdicionarDocumento(DataSetListaDocumento dataset, Fechamento fechamento, bool entradas)
        {
            var tabelaDocumento = dataset.Tables["Documento"];
            tabelaDocumento.Rows.Add(CriarDocumento(tabelaDocumento, fechamento, entradas));
        }

        private void CriarItens(List<DocumentoFiscal> entidades, DataTable tabelaItens)
        {
            foreach (var entidade in entidades)
            {
                DataRow item = CriarItem(tabelaItens);

                item["tipoDocumento"] = Entidades.Fiscal.Tipo.TipoDocumento.Obter(entidade.TipoDocumento).NomeResumido;
                item["numero"] = entidade.Número;
                item["Id"] = entidade.Id;
                item["Valor"] = entidade.ValorTotal;
                item["Emissão"] = entidade.DataEmissão.ToShortDateString();
                item["Emitente"] = entidade.CNPJEmitenteFormatado;

                var saída = entidade as SaídaFiscal;
                var entrada = entidade as EntradaFiscal;

                if (saída != null)
                {
                    item["Cancelada"] = saída.Cancelada;
                    item["DataEntradaSaída"] = saída.DataSaída.ToShortDateString();
                    item["Máquina"] = saída.Máquina;
                }

                if (entrada != null)
                {
                    item["DataEntradaSaída"] = entrada.DataEntrada.ToShortDateString();
                }

                tabelaItens.Rows.Add(item);
            }
        }


        private DataRow CriarDocumento(DataTable tabelaDocumento, Fechamento fechamento, bool entradas)
        {
            var linha = CriarDocumento(tabelaDocumento);

            linha["título"] = entradas ? "REGISTRO DE ENTRADAS" : "REGISTRO DE SAÍDAS";
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