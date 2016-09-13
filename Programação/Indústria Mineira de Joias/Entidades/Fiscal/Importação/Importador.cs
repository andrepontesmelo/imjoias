using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public abstract class Importador
    {
        protected List<string> ObterArquivos(string pasta, string padrão, SearchOption opções)
        {
            List<string> arquivos = new List<string>();
            foreach (string arquivo in Directory.EnumerateFiles(pasta, padrão, opções))
                arquivos.Add(arquivo);

            return arquivos;
        }

    }
}
