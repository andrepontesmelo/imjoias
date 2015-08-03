using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades.Relacionamento;
using CrystalDecisions.CrystalReports.Engine;

namespace Apresentação.Impressão.Relatórios
{
    public class ControleImpressãoRelacionamento<TDataSet, TRelacionamento>
        where TDataSet : DataSet, new()
        where TRelacionamento : Entidades.Relacionamento.Relacionamento
    {
        public virtual TDataSet GerarDataSet(TRelacionamento relacionamento)
        {
            TDataSet ds = new TDataSet();
            DataTable tabelaItens = ds.Tables["Itens"];
            DataTable tabelaInformações = ds.Tables["Informações"];

            // Preencher itens do relacionamento
            foreach (SaquinhoRelacionamento s in relacionamento.Itens.ObterSaquinhosAgrupadosOrdenados())
            {
                DataRow linha = tabelaItens.NewRow();
                MapearItem(linha, s, relacionamento);
                tabelaItens.Rows.Add(linha);
            }

            // Preencher informações gerais
            DataRow linhaInfo = tabelaInformações.NewRow();
            MapearInformações(linhaInfo, relacionamento);
            tabelaInformações.Rows.Add(linhaInfo);

            return ds;
        }

        /// <summary>
        /// Mapeia um saquinho para uma linha da tabela de itens do DataSet.
        /// </summary>
        protected virtual void MapearItem(DataRow linha, SaquinhoRelacionamento s, TRelacionamento relacionamento)
        {
            linha["referência"] = s.Mercadoria.Referência;
            linha["faixaGrupo"] = s.Mercadoria.Faixa + " - " + s.Mercadoria.Grupo.ToString();
            linha["índice"] = Math.Round(s.Índice, 2);
            linha["quantidade"] = s.Quantidade;
            linha["peso"] = Math.Round(s.Mercadoria.DePeso ? s.Peso : 0.0, 2);
            linha["descrição"] = s.Mercadoria.Descrição;
            linha["depeso"] = s.Mercadoria.DePeso;
        }

        /// <summary>
        /// Mapeia informações gerais do relacionamento à linha única da tabela Informações.
        /// </summary>
        protected virtual void MapearInformações(DataRow linha, TRelacionamento relacionamento)
        {
            // Nome do funcionário que digitou
            linha["funcionário"] = relacionamento.DigitadoPor.Nome;
            linha["data"] = relacionamento.Data.ToShortDateString();
            linha["código"] = relacionamento.Código.ToString();
            linha["pessoa"] = relacionamento.Pessoa.Nome + " (cód: " + relacionamento.Pessoa.Código + ")";
            linha["tabela"] = relacionamento.TabelaPreço.Nome;
            
            if (!String.IsNullOrEmpty(relacionamento.Observações))
                linha["observações"] = relacionamento.Observações;
        }

        public virtual void PrepararImpressão(ReportClass relatório, TRelacionamento relacionamento)
        {
            relatório.SetDataSource(GerarDataSet(relacionamento));
        }
    }
}
