using Entidades.ComissãoCálculo;
using Entidades.ComissãoCálculo.Impressão;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Comissao
{
    public class ControladorImpressãoCompartilhada
    {
        public void PrepararImpressão(RelatorioCompartilhada relatório, List<ImpressãoCompartilhada> lstEntidades, Comissão c)
        {
            DataSetCompartilhada ds = new DataSetCompartilhada();

            DataTable tabelaInformações = ds.Tables["Informacoes"];
            DataRow linha = tabelaInformações.NewRow();
            linha["Mes"] = c.MêsReferência.ToString("MM/yyyy");

            tabelaInformações.Rows.Add(linha);

            DataTable tabelaItens = ds.Tables["Itens"];

            foreach (ImpressãoCompartilhada entidade in lstEntidades)
            {
                DataRow item = tabelaItens.NewRow();

                if (entidade.Comissaopara == entidade.Representante)
                    item["Valorv"] = 0;
                else
                    item["Valorv"] = entidade.Valorv;

                item["Valorc"] = entidade.Valorc;
                item["Valore"] = entidade.Valore;
                item["Apagar"] = entidade.APagar;
                item["Comissaopara"] = Entidades.Pessoa.Pessoa.ReduzirNome(entidade.Comissaopara);
                item["Vendedor"] = Entidades.Pessoa.Pessoa.ReduzirNome(entidade.Vendedor);
                item["Representante"] = Entidades.Pessoa.Pessoa.ReduzirNome(entidade.Representante);

                tabelaItens.Rows.Add(item);
            }

            relatório.SetDataSource(ds);
        }
    }
}
