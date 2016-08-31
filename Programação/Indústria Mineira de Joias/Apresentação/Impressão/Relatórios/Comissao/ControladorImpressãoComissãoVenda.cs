using Entidades.Comissão;
using Entidades.Comissão.Impressão;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Comissao
{
    public class ControladorImpressãoComissãoVenda
    {
        public void PrepararImpressão(RelatorioComissaoVenda relatório, List<ImpressãoComissãoVenda> lstEntidades, Comissão c)
        {
            DataSet ds = ObterDataSet(lstEntidades, c);
            relatório.SetDataSource(ds);
        }

        public DataSet ObterDataSet(List<ImpressãoComissãoVenda> lstEntidades, Comissão c)
        {
            DataSetComissaoVenda ds = new DataSetComissaoVenda();

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
