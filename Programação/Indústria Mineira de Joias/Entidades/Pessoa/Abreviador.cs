using System.Text;

namespace Entidades.Pessoa
{
    public class Abreviador
    {
        private static readonly string[] PALAVRAS_IGNORADAS = new string[]
        {
            "Representante",
            "Funcionário",
            "Funcionario",
            "Funcionária",
            "Funcionaria",
            ".",
            "-"
        };

        public static string AbreviarNome(string nome)
        {
            return AbreviarÚltimoNome(nome);
        }

        public static string AbreviarÚltimoNome(string nome)
        {
            string[] nomes = QuebrarPalavras(AbreviarNomesEspeciais(FiltrarParalavrasIgnoradas(nome)));

            StringBuilder buffer = new StringBuilder(nomes[0]);

            if (nomes.Length == 1)
                return buffer.ToString();

            buffer.Append(" ");
            buffer.Append(AbreviarPalavra(ObterÚltimoNome(nomes)));
            buffer.Append('.');

            return buffer.ToString();
        }

        private static string ObterÚltimoNome(string[] nomes)
        {
            return nomes[nomes.Length - 1];
        }

        private static string AbreviarPalavra(string palavra)
        {
            return palavra.Length <= 2 ? palavra : palavra[0].ToString();
        }

        private static string FiltrarParalavrasIgnoradas(string nome)
        {
            StringBuilder buffer = new StringBuilder(nome);

            foreach (string palavra in PALAVRAS_IGNORADAS)
                buffer.Replace(palavra, "");

            return buffer.ToString().Trim();
        }

        private static string AbreviarNomesEspeciais(string nome)
        {
            return nome.Replace("Junior", "Jr");
        }

        private static string[] QuebrarPalavras(string nome)
        {
            return nome.Split(' ');
        }
    }
}
