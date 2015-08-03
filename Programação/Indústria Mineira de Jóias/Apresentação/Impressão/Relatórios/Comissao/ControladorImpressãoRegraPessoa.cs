using Entidades.ComissãoCálculo;
using Entidades.ComissãoCálculo.Impressão;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Comissao
{
    public class ControladorImpressãoRegraPessoa
    {
        public void PrepararImpressão(RelatorioRegraPessoa relatório, List<ImpressãoRegraPessoa> lstEntidades, Comissão c)
        {
            DataSetRegraPessoa ds = new DataSetRegraPessoa();

            DataTable tabelaInformações = ds.Tables["Informacoes"];
            DataRow linha = tabelaInformações.NewRow();
            linha["Mes"] = c.MêsReferência.ToString("MM/yyyy");

            tabelaInformações.Rows.Add(linha);

            DataTable tabelaItens = ds.Tables["Itens"];

            foreach (ImpressãoRegraPessoa entidade in lstEntidades)
            {
                DataRow item = tabelaItens.NewRow();
                item["valorv"] = entidade.Valorv;
                item["valorc"] = entidade.Valorc;
                item["valore"] = entidade.Valore;
                item["apagar"] = entidade.APagar;
                item["regra"] = Regra.ObterNome(entidade.Regra);
                item["Comissaopara"] = Entidades.Pessoa.Pessoa.ReduzirNome(entidade.Nomecomissaopara);

                tabelaItens.Rows.Add(item);
            }

            relatório.SetDataSource(ds);
        }

    }
}
