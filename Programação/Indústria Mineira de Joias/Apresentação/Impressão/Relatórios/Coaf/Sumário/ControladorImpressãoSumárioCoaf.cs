using CrystalDecisions.CrystalReports.Engine;
using Entidades.Coaf;
using Entidades.Coaf.Inconsistência;
using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Impressão.Relatórios.Coaf.Sumário
{
    public class ControladorImpressãoSumárioCoaf
    {
        internal ReportClass CriarRelatório(List<PessoaResumo> pessoas, List<SaídaFiscal> saídas,
            Dictionary<uint, InconsistênciaPessoa> hashInconsistências)
        {
            Entidades.Coaf.Inconsistência.InconsistênciaPessoa.ObterInconsistências();
            var relatório = new RelatórioSumárioCoaf();
            var dataset = new DataSetSumarioCoaf();
            relatório.SetDataSource(dataset);

            var linhaInfo = dataset.Tables["Informações"].NewRow();
            linhaInfo["dataInicio"] = ConfiguraçõesCoaf.Instância.DataInício.Valor.ToShortDateString();
            linhaInfo["dataFim"] = ConfiguraçõesCoaf.Instância.DataFim.Valor.ToShortDateString(); ;
            dataset.Tables["Informações"].Rows.Add(linhaInfo);

            var tabelaPessoa = dataset.Tables["Pessoas"];
            foreach (PessoaResumo pessoa in pessoas)
            {
                var linhaPessoa = tabelaPessoa.NewRow();
                if (pessoa.Código != 0)
                {
                    linhaPessoa["código"] = pessoa.Código;
                    linhaPessoa["nome"] = pessoa.Nome;
                    linhaPessoa["pep"] = pessoa.PessoaPoliticamenteExposta;

                    InconsistênciaPessoa inconsistência;
                    if (hashInconsistências.TryGetValue(pessoa.Código, out inconsistência))
                        linhaPessoa["pendências"] = inconsistência.Concatenar();
                } else
                    linhaPessoa["nome"] = "Pessoa sem cadastro";

                linhaPessoa["cpfCnpj"] = pessoa.CpfCnpj;
                linhaPessoa["valorAcumulado"] = pessoa.ValorAcumulado;
                
                tabelaPessoa.Rows.Add(linhaPessoa);
            }

            var tabelaSaídas = dataset.Tables["Saídas"];

            foreach (SaídaFiscal saída in saídas) 
            {
                var linhaSaída = tabelaSaídas.NewRow();
                linhaSaída["id"] = saída.Id;
                linhaSaída["data"] = saída.DataSaída;
                linhaSaída["valorTotal"] = saída.ValorTotal;
                linhaSaída["códigoVenda"] = saída.Venda;
                linhaSaída["cpfCnpj"] = saída.CpfCnpjEmissor;
                tabelaSaídas.Rows.Add(linhaSaída);
            }

            return relatório;
        }
    }
}
