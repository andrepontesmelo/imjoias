using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Coaf
{
    public class ImportadorPep
    {
        private const string COLUNA_DESCRIÇÂO_FUNÇÃO = "Descricao_Funcao_PEP";
        private const string COLUNA_NOME_ORGÃO = "Nome_Orgao_PEP";
        private const string COLUNA_CPF = "CPF_PEP";
        public int Importar(string arquivoCsv)
        {
            List<PessoaExpostaPoliticamente> pessoas = new List<PessoaExpostaPoliticamente>();

            var configuração = new CsvHelper.Configuration.CsvConfiguration();
            configuração.Delimiter = ";";

            HashSet<string> cpfsAdicionados = new HashSet<string>();
            var leitor = new CsvReader(File.OpenText(arquivoCsv), configuração);

            while (leitor.Read())
            {
                string cpf = leitor.GetField<string>(COLUNA_CPF);

                if (cpf.Length == 11 && !cpfsAdicionados.Contains(cpf))
                {
                    pessoas.Add(new PessoaExpostaPoliticamente(cpf, LerDescrição(leitor)));
                    cpfsAdicionados.Add(cpf);
                }
            }

            PessoaExpostaPoliticamente.Persistir(pessoas);

            return pessoas.Count;
        }

        private string LerDescrição(CsvReader leitor)
        {
            return string.Format("{0} - {1}",
                leitor.GetField<string>(COLUNA_DESCRIÇÂO_FUNÇÃO),
                leitor.GetField<string>(COLUNA_NOME_ORGÃO));
        }

        private string Limpar(string entrada)
        {
            return entrada.Replace("\"", "").Replace("'", "").Trim();
        }
    }
}
