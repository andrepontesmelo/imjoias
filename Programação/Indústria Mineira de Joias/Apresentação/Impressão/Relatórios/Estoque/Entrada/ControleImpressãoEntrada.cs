using Apresentação.Impressão.Relatórios.Estoque.Entrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using Entidades.Relacionamento;

namespace Apresentação.Impressão.Relatórios.Entrada
{
    public class ControleImpressãoEntrada : ControleImpressãoRelacionamento<DataSetEntrada, Entidades.Estoque.Entrada>
    {
        protected override void MapearInformações(System.Data.DataRow linha, Entidades.Estoque.Entrada entrada)
        {
            base.MapearInformações(linha, entrada);
            linha["tabela"] = entrada.TabelaPreço.Nome;
        }

        protected override void MapearItem(System.Data.DataRow linha, 
            Entidades.Relacionamento.SaquinhoRelacionamento s,
            Entidades.Estoque.Entrada relacionamento)
        {
            base.MapearItem(linha, s, relacionamento);
        }

        internal static List<ReportClass> CriarImpressão(List<Relacionamento> listaDocumentos)
        {
            List<ReportClass> relatórios = new List<ReportClass>();

            ControleImpressãoEntrada controleEntrada = new ControleImpressãoEntrada();
            foreach (Entidades.Estoque.Entrada entrada in listaDocumentos)
            {
                ReportClass relatório = new RelatorioEntrada();
                controleEntrada.PrepararImpressão(relatório, entrada);
                relatórios.Add(relatório);
            }

            return relatórios;
        }
    }
}
