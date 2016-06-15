using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using Entidades.Relacionamento;

namespace Apresentação.Impressão.Relatórios.Retorno
{
    public class ControleImpressãoRetorno : ControleImpressãoRelacionamento<DataSetRetorno, Entidades.Relacionamento.Retorno.Retorno>
    {
        protected override void MapearInformações(System.Data.DataRow linha, Entidades.Relacionamento.Retorno.Retorno retorno)
        {
            base.MapearInformações(linha, retorno);

            linha["acerto"] = retorno.AcertoConsignado != null ? retorno.AcertoConsignado.Código.ToString() : "Não definido";
        }

        internal static List<ReportClass> CriarImpressão(List<Relacionamento> listaDocumentos)
        {
            List<ReportClass> relatórios = new List<ReportClass>();

            ControleImpressãoRetorno controleRetorno = new ControleImpressãoRetorno();
            foreach (Entidades.Relacionamento.Retorno.Retorno retorno in listaDocumentos)
            {
                ReportClass relatório = new Relatório();
                controleRetorno.PrepararImpressão(relatório, retorno);
                relatórios.Add(relatório);
            }

            return relatórios;
        }
    }
}
