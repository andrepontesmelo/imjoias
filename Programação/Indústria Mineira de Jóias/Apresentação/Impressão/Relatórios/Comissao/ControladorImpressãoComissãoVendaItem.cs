using Entidades.ComissãoCálculo;
using Entidades.ComissãoCálculo.Impressão;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Comissao
{
    public class ControladorImpressãoComissãoVendaItem : ControladorImpressãoComissãoVenda
    {
        public void PrepararImpressão(RelatorioComissaoVendaItem relatório, List<ImpressãoComissãoVendaItem> lstEntidades, Comissão c)
        {
            DataSet ds = ObterDataSet(lstEntidades, c);
            relatório.SetDataSource(ds);
        }

        public DataSet ObterDataSet(List<ImpressãoComissãoVendaItem> lstEntidades, Comissão c)
        {
            DataSetVendaItem ds = new DataSetVendaItem();

            DataTable tabelaInformações = ds.Tables["Informacoes"];
            DataRow linha = tabelaInformações.NewRow();
            linha["Mes"] = c.MêsReferência.ToString("MM/yyyy");

            tabelaInformações.Rows.Add(linha);

            DataTable tabelaItens = ds.Tables["Itens"];

            foreach (ImpressãoComissãoVenda entidade in lstEntidades)
                entidade.ObterImpressão(tabelaItens);

            return ds;
        }
    }
}
