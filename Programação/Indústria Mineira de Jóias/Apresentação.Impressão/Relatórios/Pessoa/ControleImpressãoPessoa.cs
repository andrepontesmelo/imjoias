using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Impressão.Relatórios.Pessoa
{
    public class ControleImpressãoPessoa
    {
        public void PrepararImpressão(ReportClass relatório, IEnumerable<Entidades.Pessoa.Impressão.PessoaImpressão> pessoas, Região região)
        {
            DataSetPessoa ds = new DataSetPessoa();
            DataTable tabela = ds.Tables["Pessoa"];
            DataTable info = ds.Tables["Informações"];
            DataRow itemInfo = info.NewRow();

            Representante representante = região.ObterRepresentante();
            itemInfo["Representante"] = (representante == null ? "" : representante.PrimeiroNome);
            itemInfo["Região"] = (região != null ? região.Nome : "");

            info.Rows.Add(itemInfo);

            foreach (Entidades.Pessoa.Impressão.PessoaImpressão p in pessoas)
            {
                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }

            relatório.SetDataSource(ds);
        }

        private void MapearItem(Entidades.Pessoa.Impressão.PessoaImpressão pessoa, DataRow linha)
        {
            linha["Nome"] = pessoa.Nome;
            linha["Código"] = pessoa.Código;
            linha["Telefones"] = pessoa.Telefones;
            linha["Endereços"] = pessoa.Endereços;
            linha["Documento"] = pessoa.Documento;

            string classificaçõesStr = "";

            Classificação[] classificações = Classificação.ObterClassificações(pessoa.Classificações);

            foreach (Classificação c in classificações)
                classificaçõesStr += c.Denominação + "\n";

            linha["Classificações"] = classificaçõesStr;
        }
    }
}
