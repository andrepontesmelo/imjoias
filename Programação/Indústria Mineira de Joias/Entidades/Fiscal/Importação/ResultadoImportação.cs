using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ResultadoImportação
    {
        private List<KeyValuePair<string, Exception>> arquivosFalhados;
        private List<string> arquivosSucesso;
        private List<string> arquivosIgnorados;

        private DateTime início;
        private DateTime fim;
        public TimeSpan TempoDecorrido => fim - início;

        private string descriçãoProcesso;
        public int TotalArquivos => arquivosSucesso.Count + arquivosFalhados.Count + arquivosIgnorados.Count;
        private string linhasTraços;

        private int ObterMáximoTamanhoColuna()
        {
            int tamanhoMáximo = 0;

            tamanhoMáximo = ObtemTamanhoMáximo(tamanhoMáximo, arquivosSucesso);
            tamanhoMáximo = ObtemTamanhoMáximo(tamanhoMáximo, arquivosIgnorados);

            return tamanhoMáximo;
        }

        private int ObtemTamanhoMáximo(int tamanhoMáximo, List<string> arquivos)
        {
            foreach (string x in arquivos)
                if (x.Length > tamanhoMáximo)
                    tamanhoMáximo = x.Length;

            return tamanhoMáximo;
        }

        public ResultadoImportação(string descriçãoProcesso)
        {
            this.descriçãoProcesso = descriçãoProcesso;
            início = DateTime.Now;
            arquivosFalhados = new List<KeyValuePair<string, Exception>>();
            arquivosSucesso = new List<string>();
            arquivosIgnorados = new List<string>();
        }

        public string GravarArquivoTxt(string versão)
        {
            fim = DateTime.Now;

            string arquivoTmp = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            linhasTraços = new string('=', ObterMáximoTamanhoColuna()) + '\n';

            using (StreamWriter escritor = new StreamWriter(arquivoTmp))
            {
                EscreveCabeçalho(escritor);
                EscreveTaxas(escritor);
                EscreveTodosArquivos(escritor);

                escritor.WriteLine(string.Format("{0} - {1} - Processo iniciado em {2} e terminado em {3}", versão,
                    início.ToLongDateString(), início.ToLongTimeString(), DateTime.Now.ToLongTimeString()));
            }

            return arquivoTmp;
        }

        private void EscreveCabeçalho(StreamWriter escritor)
        {
            escritor.WriteLine(descriçãoProcesso.ToUpper());
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine(string.Format("Tempo decorrido: {0}", ObterTempoLegível(TempoDecorrido)));
        }

        private void EscreveTodosArquivos(StreamWriter escritor)
        {
            EscreveArquivos("Falhas", arquivosFalhados, escritor);
            EscreveArquivos("Sucesso", arquivosSucesso, escritor);
            EscreveArquivos("Ignorados", arquivosIgnorados, escritor);

            escritor.WriteLine(linhasTraços);
        }

        private void EscreveArquivos(string título, List<string> arquivos, StreamWriter escritor)
        {
            if (arquivos.Count == 0)
                return;

            EscreveTítulo(título, escritor);

            Adiciona(escritor, arquivos);
        }

        private void EscreveTítulo(string título, StreamWriter escritor)
        {
            escritor.WriteLine();
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine(título);
            escritor.WriteLine(linhasTraços);
        }

        private void EscreveArquivos(string título, List<KeyValuePair<string, Exception>> arquivosFalhados, StreamWriter escritor)
        {
            if (arquivosFalhados.Count == 0)
                return;

            Dictionary<Type, List<KeyValuePair<string, Exception>>> grupos = AgruparTipoFalha(arquivosFalhados);

            EscreveCabeçalhoGrupo(título, escritor, grupos);
            DescreveGrupos(escritor, grupos);
        }

        private static void DescreveGrupos(StreamWriter escritor, Dictionary<Type, List<KeyValuePair<string, Exception>>> grupos)
        {
            foreach (KeyValuePair<Type, List<KeyValuePair<string, Exception>>> grupo in grupos)
            {
                escritor.WriteLine();
                escritor.WriteLine(string.Format(" --  {0} -- ", grupo.Key.ToString()));

                int x = 0;
                foreach (KeyValuePair<string, Exception> par in grupo.Value)
                    escritor.WriteLine(string.Format("{0} - {1}", ++x, par.Key));
            }
        }

        private void EscreveCabeçalhoGrupo(string título, StreamWriter escritor, Dictionary<Type, List<KeyValuePair<string, Exception>>> grupos)
        {
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine(título);

            foreach (KeyValuePair<Type, List<KeyValuePair<string, Exception>>> grupo in grupos)
                escritor.WriteLine(string.Format("  >> {0} Falha(s) do tipo {1}", grupo.Value.Count, grupo.Key.ToString()));

            escritor.WriteLine(linhasTraços);
        }

        private Dictionary<Type, List<KeyValuePair<string, Exception>>> AgruparTipoFalha(List<KeyValuePair<string, Exception>> arquivosFalhados)
        {
            Dictionary<Type, List<KeyValuePair<string, Exception>>> hashTipos = new Dictionary<Type, List<KeyValuePair<string, Exception>>>();

            foreach (KeyValuePair<string, Exception> par in arquivosFalhados)
            {
                List<KeyValuePair<string, Exception>> lista;
                Type tipo = par.Value.GetType();
                if (!hashTipos.TryGetValue(tipo, out lista))
                {
                    lista = new List<KeyValuePair<string, Exception>>();
                    hashTipos[tipo] = lista;
                }

                lista.Add(par);
            }

            return hashTipos;
        }

        private void Adiciona(StreamWriter escritor, List<string> arquivos)
        {
            int x = 0;

            foreach (string arquivo in arquivos)
                escritor.WriteLine(string.Format("{0} - {1}", ++x, arquivo));
        }

        private void EscreveTaxas(StreamWriter escritor)
        {
            if (TotalArquivos == 0)
            {
                escritor.WriteLine("Nenhum arquivo foi processado.");
                return;
            }

            EscreveTaxa(escritor, "Falhas", arquivosFalhados.Count);
            EscreveTaxa(escritor, "Sucesso", arquivosSucesso.Count);
            EscreveTaxa(escritor, "Ignorados", arquivosIgnorados.Count);
        }

        internal void AdicionarFalha(string arquivo, Exception erro)
        {
            arquivosFalhados.Add(new KeyValuePair<string, Exception>(arquivo, erro));
        }

        private void EscreveTaxa(StreamWriter escritor, string nome, int qtdArquivos)
        {
            escritor.WriteLine(string.Format("{0}: {1} / {2} ({3}%)", nome, qtdArquivos, TotalArquivos,
                Math.Round((double) 100 * qtdArquivos / TotalArquivos)));
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

        public List<KeyValuePair<string, Exception>> ArquivosFalhados => arquivosFalhados;
        public List<string> ArquivosSucesso => arquivosSucesso;
        public List<string> ArquivosIgnorados => arquivosIgnorados;
    }
}
