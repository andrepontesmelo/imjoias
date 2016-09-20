using Entidades.Comissão;
using Entidades.Comissão.Impressão;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Comissao
{
    public class ControladorImpressãoResumo
    {
        public void PrepararImpressão(RelatorioResumo relatório, List<ImpressãoResumo> lstEntidades, Comissão c)
        {
            DataSetResumo ds = new DataSetResumo();

            DataTable tabelaInformações = ds.Tables["Informacoes"];
            DataRow linha = tabelaInformações.NewRow();
            linha["Mes"] = c.MêsReferência.ToString("MM/yyyy");

            tabelaInformações.Rows.Add(linha);

            DataTable tabelaItens = ds.Tables["Itens"];

            foreach (ImpressãoResumo entidade in lstEntidades)
            {
                DataRow item = tabelaItens.NewRow();
                item["valorv"] = entidade.Valorv;
                item["faturamentocompartilhado"] = entidade.FaturamentoCompartilhado;
                item["valorc"] = entidade.Valorc;
                item["valore"] = entidade.Valore;
                item["apagar"] = entidade.APagar;
                item["nomecomissaopara"] = Entidades.Pessoa.Pessoa.AbreviarNome(entidade.Nomecomissaopara);
                item["setor"] = entidade.Setor;

                tabelaItens.Rows.Add(item);
            }

            relatório.SetDataSource(ds);
        }
    }
}
