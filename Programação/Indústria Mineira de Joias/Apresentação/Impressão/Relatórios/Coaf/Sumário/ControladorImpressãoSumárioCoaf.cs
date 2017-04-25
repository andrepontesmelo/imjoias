using CrystalDecisions.CrystalReports.Engine;
using Entidades.Coaf;
using Entidades.Coaf.Inconsistência;
using Entidades.Fiscal;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Coaf.Sumário
{
    public class ControladorImpressãoSumárioCoaf
    {
        private Dictionary<uint, InconsistênciaPessoa> hashInconsistências;
        private DataSetSumarioCoaf dataset;

        public ControladorImpressãoSumárioCoaf(Dictionary<uint, InconsistênciaPessoa> hashInconsistências)
        {
            this.hashInconsistências = hashInconsistências;
        }

        internal ReportClass CriarRelatório(List<PessoaResumo> pessoas, List<SaídaFiscal> saídas)
        {
            var relatório = new RelatórioSumárioCoaf();

            CriarDataSet(relatório);
            PreencherInformaçõesGerais();
            PreencherPessoas(pessoas);
            PreencherSaídas(saídas);

            return relatório;
        }

        private void CriarDataSet(RelatórioSumárioCoaf relatório)
        {
            dataset = new DataSetSumarioCoaf();
            relatório.SetDataSource(dataset);
        }

        private void PreencherSaídas(List<SaídaFiscal> saídas)
        {
            var tabelaSaídas = dataset.Tables["Saídas"];
            foreach (SaídaFiscal saída in saídas)
                tabelaSaídas.Rows.Add(ObterSaída(tabelaSaídas, saída));
        }

        private void PreencherPessoas(List<PessoaResumo> pessoas)
        {
            var tabelaPessoa = dataset.Tables["Pessoas"];
            foreach (PessoaResumo pessoa in pessoas)
            {
                if (pessoa.Verificável)
                    tabelaPessoa.Rows.Add(CriarPessoa(tabelaPessoa, pessoa));
            }
        }

        private void PreencherInformaçõesGerais()
        {
            var linhaInfo = dataset.Tables["Informações"].NewRow();
            linhaInfo["dataInicio"] = ConfiguraçõesCoaf.Instância.DataInício.Valor.ToShortDateString();
            linhaInfo["dataFim"] = ConfiguraçõesCoaf.Instância.DataFim.Valor.ToShortDateString();
            dataset.Tables["Informações"].Rows.Add(linhaInfo);
        }

        private static DataRow ObterSaída(DataTable tabelaSaídas, SaídaFiscal saída)
        {
            var linhaSaída = tabelaSaídas.NewRow();
            linhaSaída["id"] = saída.Id;
            linhaSaída["data"] = saída.DataSaída.ToShortDateString();
            linhaSaída["valorTotal"] = saída.ValorTotal.ToString("C");
            linhaSaída["códigoVenda"] = saída.Venda;
            linhaSaída["cpfCnpj"] = Entidades.Pessoa.Pessoa.FormatarCpfCnpj(saída.CpfCnpjEmissor);

            return linhaSaída;
        }

        private DataRow CriarPessoa(DataTable tabelaPessoa, PessoaResumo pessoa)
        {
            var linhaPessoa = tabelaPessoa.NewRow();
            if (pessoa.Código != 0)
            {
                linhaPessoa["código"] = pessoa.Código;
                linhaPessoa["nome"] = pessoa.Nome.ToUpper();
                linhaPessoa["pep"] = pessoa.PoliticamenteExposta;
                linhaPessoa["cargoPep"] = pessoa.DescriçãoPessoaExposta == null ? null : 
                    "PEP: " + pessoa.DescriçãoPessoaExposta;

                InconsistênciaPessoa inconsistência;
                if (hashInconsistências.TryGetValue(pessoa.Código, out inconsistência))
                    linhaPessoa["pendências"] = inconsistência.Concatenar();
            }
            else
                linhaPessoa["nome"] = "<< PESSOA SEM CADASTRO >>";

            linhaPessoa["cpfCnpj"] = Entidades.Pessoa.Pessoa.FormatarCpfCnpj(pessoa.CpfCnpj);
            linhaPessoa["valorAcumulado"] = pessoa.ValorAcumulado.ToString("C");
            linhaPessoa["notificável"] = pessoa.Notificável;

            return linhaPessoa;
        }
    }
}
