using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Coaf.Sumário
{
    public class ControladorImpressãoSumárioCoaf
    {
        public RelatórioSumárioCoaf CriarRelatório()
        {
            var relatório = new RelatórioSumárioCoaf();
            var dataset = new DataSetSumarioCoaf();
            relatório.SetDataSource(dataset);

            var linhaInfo = dataset.Tables["Informações"].NewRow();
            linhaInfo["dataInicio"] = "2001/01/01";
            linhaInfo["dataFim"] = "2010/01/01";
            dataset.Tables["Informações"].Rows.Add(linhaInfo);

            var tabelaPessoa = dataset.Tables["Pessoas"];

            var linhaPessoa = tabelaPessoa.NewRow();
            linhaPessoa["código"] = 55555;
            linhaPessoa["nome"] = "André Pontes";
            linhaPessoa["pep"] = "Não";
            linhaPessoa["cpfCnpj"] = "07676631602";
            linhaPessoa["valorAcumulado"] = "R$ 50.000,00";
            linhaPessoa["pendências"] = "Cadastrar Orgão Emissor";
            tabelaPessoa.Rows.Add(linhaPessoa);

            var linhaPessoa2 = tabelaPessoa.NewRow();
            linhaPessoa2["código"] = 55555;
            linhaPessoa2["nome"] = "Ellen Carolina";
            linhaPessoa2["pep"] = "Não";
            linhaPessoa2["cpfCnpj"] = "123.112.232-02";
            linhaPessoa2["valorAcumulado"] = "R$ 10.000,00";
            linhaPessoa2["pendências"] = "";
            tabelaPessoa.Rows.Add(linhaPessoa2);

            var tabelaSaídas = dataset.Tables["Saídas"];

            var linhaSaída = tabelaSaídas.NewRow();
            linhaSaída["id"] = 2222;
            linhaSaída["data"] = "2010/03/03";
            linhaSaída["valorTotal"] = "R$ 50,00";
            linhaSaída["códigoVenda"] = 1234;
            linhaSaída["cpfCnpj"] = "07676631602";
            tabelaSaídas.Rows.Add(linhaSaída);

            var linhaSaída2 = tabelaSaídas.NewRow();
            linhaSaída2["id"] = 1322;
            linhaSaída2["data"] = "2001/01/03";
            linhaSaída2["valorTotal"] = "R$ 25,45";
            linhaSaída2["códigoVenda"] = 4321;
            linhaSaída2["cpfCnpj"] = "07676631602";
            tabelaSaídas.Rows.Add(linhaSaída2);

            var linhaSaída3 = tabelaSaídas.NewRow();
            linhaSaída3["id"] = 5555;
            linhaSaída3["data"] = "2022/01/03";
            linhaSaída3["valorTotal"] = "R$ 125,45";
            linhaSaída3["códigoVenda"] = 14321;
            linhaSaída3["cpfCnpj"] = "123.112.232-02";
            tabelaSaídas.Rows.Add(linhaSaída3);

            return relatório;
        }
    }
}
