using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;

namespace Apresentação.Impressão.Relatórios.Mercadoria
{
    public class ControleImpressãoMercadoria
    {
        public void PrepararImpressão(ReportClass relatório, IEnumerable<Entidades.Mercadoria.MercadoriaImpressão> mercadoria)
        {
            DataSetMercadoria ds = new DataSetMercadoria();
            DataTable tabela = ds.Tables["Mercadoria"];

            foreach (Entidades.Mercadoria.MercadoriaImpressão m in mercadoria)
            {
                DataRow linha = tabela.NewRow();
                MapearItem(m, linha);
                tabela.Rows.Add(linha);
            }

            relatório.SetDataSource(ds);
        }

        private void MapearItem(Entidades.Mercadoria.MercadoriaImpressão mercadoria, DataRow linha)
        {
            linha["referência"] = mercadoria.Referência;
            linha["peso"] = mercadoria.Peso;
            linha["índice"] = mercadoria.Índice;
            linha["depeso"] = mercadoria.DePeso.ToString();
        }
    }
}
