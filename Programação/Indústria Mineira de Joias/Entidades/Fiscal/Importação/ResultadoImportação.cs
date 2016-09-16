using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ResultadoImportação
    {
        private readonly static int TOTAL_CARACTERES_LINHA = 80;

        private List<string> arquivosFalhados;
        private List<string> arquivosSucesso;
        private List<string> arquivosIgnorados;

        private DateTime início;
        private string descriçãoProcesso;
       
        public TimeSpan TempoDecorrido => DateTime.Now - início;
        public int TotalArquivos => arquivosSucesso.Count + arquivosFalhados.Count + arquivosIgnorados.Count;

        public ResultadoImportação(string descriçãoProcesso)
        {
            arquivosFalhados = new List<string>();
            arquivosSucesso = new List<string>();
            arquivosIgnorados = new List<string>();
            this.descriçãoProcesso = descriçãoProcesso;

            início = DateTime.Now;
        }

        public string GravarArquivoTxt()
        {
            string arquivoTmp = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            string linhaTraços = new string('=', TOTAL_CARACTERES_LINHA);

            using (StreamWriter escritor = new StreamWriter(arquivoTmp))
            {
                escritor.WriteLine(descriçãoProcesso.ToUpper());
                escritor.WriteLine(linhaTraços);
                escritor.WriteLine();
                escritor.WriteLine(string.Format("Tempo decorrido: {0}", ObterTempoLegível(TempoDecorrido)));

                EscreveTaxas(escritor);
                EscreveArquivos("Falhas", arquivosFalhados, linhaTraços, escritor);
                EscreveArquivos("Sucesso", arquivosSucesso, linhaTraços, escritor);
                EscreveArquivos("Ignorados", arquivosIgnorados, linhaTraços, escritor);
                escritor.WriteLine(linhaTraços);

                escritor.WriteLine(string.Format("{0} - Processo iniciado em {1} e terminado em {2}",
                    início.ToLongDateString(), início.ToLongTimeString(), DateTime.Now.ToLongTimeString()));
            }

            return arquivoTmp;
        }

        private void EscreveTaxas(StreamWriter escritor)
        {
            if (TotalArquivos == 0)
            {
                escritor.WriteLine("Nenhum arquivo foi processado.");
                return;
            }

            EscreveTaxa(escritor, "Falhas", arquivosFalhados);
            EscreveTaxa(escritor, "Sucesso", arquivosSucesso);
            EscreveTaxa(escritor, "Ignorados", arquivosIgnorados);
        }

        private void EscreveTaxa(StreamWriter escritor, string nome, List<string> arquivos)
        {
            escritor.WriteLine(string.Format("{0}: {1} / {2} ({3}%)", nome, arquivos.Count, TotalArquivos,
                Math.Round((double)100 * arquivos.Count / TotalArquivos)));
        }

        private void EscreveArquivos(string título, List<string> arquivos, string linhaTraços, StreamWriter escritor)
        {
            if (arquivos.Count == 0)
                return;

            escritor.WriteLine();
            escritor.WriteLine(linhaTraços);
            escritor.WriteLine(título);
            escritor.WriteLine(linhaTraços);

            Adiciona(escritor, arquivos);
        }

        private static string ObterTempoLegível(TimeSpan tempo)
        {
            string formatado = string.Format("{0}{1}{2}{3}",
                tempo.Duration().Days > 0 ? string.Format("{0:0} dia{1}, ", tempo.Days, tempo.Days == 1 ? String.Empty : "s") : string.Empty,
                tempo.Duration().Hours > 0 ? string.Format("{0:0} hora{1}, ", tempo.Hours, tempo.Hours == 1 ? String.Empty : "s") : string.Empty,
                tempo.Duration().Minutes > 0 ? string.Format("{0:0} minuto{1}, ", tempo.Minutes, tempo.Minutes == 1 ? String.Empty : "s") : string.Empty,
                tempo.Duration().Seconds > 0 ? string.Format("{0:0} segundo{1}", tempo.Seconds, tempo.Seconds == 1 ? String.Empty : "s") : string.Empty);

            if (formatado.EndsWith(", ")) formatado = formatado.Substring(0, formatado.Length - 2);

            if (string.IsNullOrEmpty(formatado)) formatado = "0 segundos";

            return formatado;
        }

        private void Adiciona(StreamWriter escritor, List<string> arquivos)
        {
            int x = 0;

            foreach (string arquivo in arquivos)
                escritor.WriteLine(string.Format("{0} - {1}", ++x, arquivo));
        }

        public List<string> ArquivosFalhados => arquivosFalhados;
        public List<string> ArquivosSucesso => arquivosSucesso;
        public List<string> ArquivosIgnorados => arquivosIgnorados;
    }
}
