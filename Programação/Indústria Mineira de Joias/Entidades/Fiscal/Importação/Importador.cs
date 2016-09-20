using System.Collections.Generic;
using System.ComponentModel;
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

        public static void AtualizarPorcentagem(BackgroundWorker thread, ResultadoImportação resultado, List<string> arquivos)
        {
            if (arquivos.Count < 100 || resultado.TotalArquivos % 10 == 0)
                thread.ReportProgress(100 * resultado.TotalArquivos / arquivos.Count);
        }

        public virtual ResultadoImportação ImportarArquivos(string pasta, BackgroundWorker thread)
        {
            return ImportarArquivos(pasta, SearchOption.AllDirectories, thread);
        }

        public abstract ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread);
    }
}
