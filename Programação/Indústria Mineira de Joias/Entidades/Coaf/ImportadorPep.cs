using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Coaf
{
    public class ImportadorPep
    {
        public int Importar(string arquivoCsv)
        {
            List<PessoaExpostaPoliticamente> pessoas = new List<PessoaExpostaPoliticamente>();

            var configuração = new CsvHelper.Configuration.CsvConfiguration();
            configuração.Delimiter = ";";

            HashSet<string> cpfsAdicionados = new HashSet<string>();
            var leitor = new CsvReader(File.OpenText(arquivoCsv), configuração);

            while (leitor.Read())
            {
                string cpf = leitor.GetField<string>(0).Trim();

                if (cpf.Length == 11 && !cpfsAdicionados.Contains(cpf))
                {
                    pessoas.Add(new PessoaExpostaPoliticamente(cpf));
                    cpfsAdicionados.Add(cpf);
                }
            }

            PessoaExpostaPoliticamente.Persistir(pessoas);

            return pessoas.Count;
        }
    }
}
