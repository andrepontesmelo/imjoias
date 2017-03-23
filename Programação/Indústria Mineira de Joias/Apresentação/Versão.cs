namespace Apresentação
{
    public class Versão
    {
        public static string GithubBranch = "v0.7.0.3";
        public static string NomeAplicação = "Indústria Mineira de Joias";
        public static bool Beta = false;

        public static string Descrição = string.Format("{0} {1} {2}",
            NomeAplicação,
            GithubBranch,
            Beta ? "Beta - 17 de março 14h" : "");
    }
}
