using Entidades.ComissãoCálculo;
using Entidades.ComissãoCálculo.Impressão;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Comissao
{
    public class ControladorImpressãoComissãoSetor 
    {
        public void PrepararImpressão(RelatorioSetor relatório, List<ImpressãoSetor> lstEntidades, Comissão c)
        {
            DataSetSetor ds = new DataSetSetor();

            DataTable tabelaInformações = ds.Tables["Informacoes"];
            DataRow linha = tabelaInformações.NewRow();
            linha["Mes"] = c.MêsReferência.ToString("MM/yyyy");

            tabelaInformações.Rows.Add(linha);

            DataTable tabelaItens = ds.Tables["Itens"];

            foreach (ImpressãoSetor entidade in lstEntidades)
            {
                DataRow item = tabelaItens.NewRow();
                item["valorv"] = entidade.Valorv;
                item["valorc"] = entidade.Valorc;
                item["valore"] = entidade.Valore;
                item["apagar"] = entidade.APagar;
                item["nomecomissaopara"] = Entidades.Pessoa.Pessoa.AbreviarNome(entidade.Nomecomissaopara);
                item["setor"] = entidade.Setor.Nome;

                tabelaItens.Rows.Add(item);
            }

            relatório.SetDataSource(ds);
        }
    }
}
