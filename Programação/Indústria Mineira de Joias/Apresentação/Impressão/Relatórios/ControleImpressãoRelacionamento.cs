using CrystalDecisions.CrystalReports.Engine;
using Entidades;
using Entidades.Mercadoria;
using Entidades.Relacionamento;
using System;
using System.Data;

namespace Apresentação.Impressão.Relatórios
{
    public class ControleImpressãoRelacionamento<TDataSet, TRelacionamento>
        where TDataSet : DataSet, new()
        where TRelacionamento : Relacionamento
    {
        public virtual TDataSet GerarDataSet(TRelacionamento relacionamento)
        {
            TDataSet ds = new TDataSet();
            DataTable tabelaItens = ds.Tables["Itens"];
            DataTable tabelaInformações = ds.Tables["Informações"];

            PreencherItens(relacionamento, tabelaItens);
            PreencherInformaçõesGerais(relacionamento, tabelaInformações);

            return ds;
        }

        private void PreencherInformaçõesGerais(TRelacionamento relacionamento, DataTable tabelaInformações)
        {
            DataRow linhaInfo = tabelaInformações.NewRow();
            MapearInformações(linhaInfo, relacionamento);
            tabelaInformações.Rows.Add(linhaInfo);
        }

        private void PreencherItens(TRelacionamento relacionamento, DataTable tabelaItens)
        {
            bool erro;
            foreach (SaquinhoRelacionamento s in relacionamento.Itens.ObterSaquinhosAgrupadosOrdenados(out erro))
            {
                DataRow linha = tabelaItens.NewRow();
                MapearItem(linha, s, relacionamento);
                tabelaItens.Rows.Add(linha);
            }
        }

        protected virtual void MapearItem(DataRow linha, SaquinhoRelacionamento s, TRelacionamento relacionamento)
        {
            linha["referência"] = s.Mercadoria.Referência;
            linha["faixaGrupo"] = s.Mercadoria.Faixa;
            linha["índice"] = Math.Round(s.Índice, 2);
            linha["quantidade"] = s.Quantidade;
            linha["peso"] = Math.Round(s.Mercadoria.DePeso ? s.Peso : 0.0, 2);
            linha["descrição"] = s.Mercadoria.Descrição;
            linha["depeso"] = s.Mercadoria.DePeso;
        }

        protected virtual string ObterCódigoDocumento(TRelacionamento relacionamento)
        {
                return relacionamento.Código.ToString();
        }

        protected virtual void MapearInformações(DataRow linha, TRelacionamento relacionamento)
        {
            linha["funcionário"] = relacionamento.DigitadoPor.Nome;
            linha["data"] = relacionamento.Data.ToShortDateString();
            linha["código"] = ObterCódigoDocumento(relacionamento);

            if (!String.IsNullOrEmpty(relacionamento.Observações))
                linha["observações"] = relacionamento.Observações;

            MapearInformaçõesAcerto(linha, relacionamento);
        }

        private static void MapearInformaçõesAcerto(DataRow linha, TRelacionamento relacionamento)
        {
            if (relacionamento is RelacionamentoAcerto)
            {
                RelacionamentoAcerto relacionamentoAcerto = relacionamento as RelacionamentoAcerto;
                linha["tabela"] = relacionamentoAcerto.TabelaPreço.Nome;
                linha["pessoa"] = relacionamentoAcerto.Pessoa.Nome + " (" + relacionamentoAcerto.Pessoa.Código + ")";
            }
        }

        public virtual void PrepararImpressão(ReportClass relatório, TRelacionamento relacionamento)
        {
            relatório.SetDataSource(GerarDataSet(relacionamento));
        }
    }
}
