using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Acerto;
using System.Data;
using Entidades.Pessoa;
using CrystalDecisions.CrystalReports.Engine;

namespace Apresentação.Impressão.Relatórios.Acerto
{
    public class ControleImpressãoAcerto
    {
        private bool resumido = false;

        public bool Resumido { get { return resumido; } set { resumido = value; } }

        public DataSetAcerto GerarDataSet(ControleAcertoMercadorias acerto)
        {
            DataSetAcerto ds = new DataSetAcerto();
            DataTable tabelaItens = ds.Tables["Itens"];
            DataTable tabelaInformações = ds.Tables["Informações"];

            resumido = Representante.ÉRepresentante(acerto.Pessoa);

            List<SaquinhoAcerto> coleção = acerto.ColeçãoSaquinhos;
            // Preencher itens do relacionamento
            foreach (SaquinhoAcerto s in coleção)
            {
                if (!resumido || s.QtdAcerto != 0)
                {
                    DataRow linha = tabelaItens.NewRow();
                    MapearItem(linha, s, acerto);
                    tabelaItens.Rows.Add(linha);
                }
            }

            // Preencher informações gerais
            DataRow linhaInfo = tabelaInformações.NewRow();
            MapearInformações(linhaInfo, acerto);
            tabelaInformações.Rows.Add(linhaInfo);

            return ds;
        }

        /// <summary>
        /// Mapeia um saquinho para uma linha da tabela de itens do DataSet.
        /// </summary>
        protected static void MapearItem(DataRow linha, SaquinhoAcerto s, ControleAcertoMercadorias acerto)
        {
            linha["referência"] = s.Mercadoria.Referência;
            linha["faixaGrupo"] = s.Mercadoria.Faixa + " - " + s.Mercadoria.Grupo.ToString();
            linha["índice"] = s.Índice;
            linha["peso"] = s.Mercadoria.DePeso ? s.Peso : 0.0;
            linha["descrição"] = s.Mercadoria.Descrição;
            linha["depeso"] = s.Mercadoria.DePeso;
            linha["saída"] = s.QtdSaída;
            linha["retorno"] = s.QtdRetorno;
            linha["venda"] = s.QtdVenda;
            linha["acerto"] = s.QtdAcerto;
            linha["devolução"] = s.QtdDevolvida;
        }


        /// <summary>
        /// Mapeia informações gerais do relacionamento à linha única da tabela Informações.
        /// </summary>
        protected static void MapearInformações(DataRow linha, ControleAcertoMercadorias acerto)
        {
            // Nome do funcionário que digitou
            //linha["funcionário"] = Funcionário.FuncionárioAtual.Nome;
            linha["funcionário"] = acerto.Acerto.FuncAcerto != null ? acerto.Acerto.FuncAcerto.Nome : "N/D";
            //linha["data"] = relacionamento.Data.ToShortDateString();
            linha["código"] = acerto.Acerto.Código.ToString();
            linha["pessoa"] = acerto.Pessoa.Nome;
            linha["cotação"] = acerto.Acerto.Cotação.HasValue ? acerto.Acerto.Cotação.Value : 0;
            linha["mostrarÍndices"] = !Representante.ÉRepresentante(acerto.Pessoa);
            
            //SumárioDevolução sumário = 
            //    SumárioDevolução.ObterSumário(acerto.ColeçãoSaquinhos, acerto.Acerto.Cotação);

            linha["índiceDevolvidoPeso"] = acerto.ObterÍndiceDevolvido(true).ToString();
            linha["índiceDevolvidoPeça"] = acerto.ObterÍndiceDevolvido(false).ToString();
            
            linha["valorDevolvidoPeso"] = acerto.ObterValorDevolvido(true).ToString("C");
            linha["valorDevolvidoPeça"] = acerto.ObterValorDevolvido(false).ToString("C");
            linha["valorVendidoPeso"] = acerto.ObterValorVendido(true).ToString("C");
            linha["valorVendidoPeça"] = acerto.ObterValorVendido(false).ToString("C");
            linha["valorPagar"] = acerto.ObterValorPagar().ToString("C");
            linha["índicePagar"] = Math.Round(acerto.ObterÍndicePagar(),2);
            linha["valorDesconto"] = acerto.ObterDesconto().ToString("C");

            bool primeiro = true;

            foreach (long codSaída in acerto.CódigoSaídas)
            {
                if (!primeiro)
                    linha["saídas"] += ", ";
                else
                    primeiro = false;

                linha["saídas"] += codSaída.ToString();
            }

            primeiro = true;

            foreach (long codRetorno in acerto.CódigoRetornos)
            {
                if (!primeiro)
                    linha["retornos"] += ", ";
                else
                    primeiro = false;

                linha["retornos"] += codRetorno.ToString();
            }

            primeiro = true;

            foreach (long codVenda in acerto.CódigoVendas)
            {
                if (!primeiro)
                    linha["vendas"] += ", ";
                else
                    primeiro = false;

                linha["vendas"] += codVenda.ToString();
            }
        }

        public virtual void PrepararImpressão(ReportClass relatório, ControleAcertoMercadorias relacionamento)
        {
            relatório.SetDataSource(GerarDataSet(relacionamento));
        }
    
    }
}
