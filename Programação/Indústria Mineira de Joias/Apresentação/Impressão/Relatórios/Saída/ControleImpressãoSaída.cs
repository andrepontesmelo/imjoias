using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using Entidades.Relacionamento;

namespace Apresentação.Impressão.Relatórios.Saída
{
    public class ControleImpressãoSaída : ControleImpressãoRelacionamento<DataSetSaída, Entidades.Relacionamento.Saída.Saída>
    {
        protected override void MapearInformações(System.Data.DataRow linha, Entidades.Relacionamento.Saída.Saída saída)
        {
            base.MapearInformações(linha, saída);

            linha["cotação"] = saída.Cotação;

            if (saída.AcertoConsignado != null)
            {
                linha["previsãoAcerto"] =
                    saída.AcertoConsignado.Previsão.HasValue ?
                    saída.AcertoConsignado.Previsão.Value.ToString("dd/MM/yyyy 'às' HH:mm")
                    : "Sem previsão";
                linha["acerto"] = saída.AcertoConsignado.Código.ToString();
            }
            else
            {
                linha["previsãoAcerto"] = "Sem previsão";
                linha["acerto"] = "Não definido";
            }

            bool imprimirPreço = !Representante.ÉRepresentante(saída.Pessoa);

            imprimirPreço &= (saída.Pessoa.Setor != null) && (saída.Pessoa.Setor.Código != 
                Setor.ObterSetor(Setor.SetorSistema.AltoAtacado).Código);
            

            linha["imprimirPreço"] = imprimirPreço;
            linha["tabela"] = saída.TabelaPreço.Nome;
        }

        protected override void MapearItem(System.Data.DataRow linha, Entidades.Relacionamento.SaquinhoRelacionamento s, Entidades.Relacionamento.Saída.Saída relacionamento)
        {
            base.MapearItem(linha, s, relacionamento);

            linha["preço"] = s.Mercadoria.CalcularPreço(relacionamento.Cotação).Valor;
        }

        internal static List<ReportClass> CriarImpressão(List<Relacionamento> listaDocumentos)
        {
            List<ReportClass> relatórios = new List<ReportClass>();
            ControleImpressãoSaída controleSaída = new ControleImpressãoSaída();

            foreach (Entidades.Relacionamento.Saída.Saída saida in listaDocumentos)
            {
                ReportClass relatório = new Relatório();
                controleSaída.PrepararImpressão(relatório, saida);
                relatórios.Add(relatório);
            }

            return relatórios;
        }
    }
}
