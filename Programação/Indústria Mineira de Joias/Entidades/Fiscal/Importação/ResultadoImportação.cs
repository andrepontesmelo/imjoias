using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ResultadoImportação
    {
        private static readonly int MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO = 5;

        private List<KeyValuePair<string, Exception>> arquivosFalhados;
        private List<string> arquivosSucesso;
        private List<KeyValuePair<string, Motivo>> arquivosIgnorados;

        private DateTime início;
        private DateTime fim;
        public TimeSpan TempoDecorrido => fim - início;

        private string descriçãoProcesso;
        public int TotalArquivos => arquivosSucesso.Count + arquivosFalhados.Count + arquivosIgnorados.Count;
        private string linhasTraços;

        private int ObterMáximoTamanhoColuna()
        {
            return ObtemTamanhoMáximo(0, arquivosSucesso);
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
            arquivosIgnorados = new List<KeyValuePair<string, Motivo>>();
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

        private void EscreveArquivos(string título, List<KeyValuePair<string, Motivo>> arquivos, StreamWriter escritor)
        {
            if (arquivos.Count == 0)
                return;

            Dictionary<Motivo, List<string>> grupos = AgruparMotivo(arquivos);

            EscreveCabeçalhoGrupo(título, escritor, grupos);
            DescreveGrupos(escritor, grupos);
        }

        private void DescreveGrupos(StreamWriter escritor, Dictionary<Motivo, List<string>> grupos)
        {
            foreach (KeyValuePair<Motivo, List<string>> grupo in grupos)
            {
                escritor.WriteLine();
                escritor.WriteLine(grupo.Key);
                escritor.WriteLine();

                int x = 0;
                foreach (string arquivo in grupo.Value)
                {
                    escritor.WriteLine(string.Format("{0} - {1}", ++x, arquivo));
                }
            }
        }

        private void EscreveCabeçalhoGrupo(string título, StreamWriter escritor, Dictionary<Motivo, List<string>> grupos)
        {
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine();
            escritor.WriteLine(título);
            escritor.WriteLine();

            foreach (KeyValuePair<Motivo, List<string>> grupo in grupos)
            {
                escritor.WriteLine(string.Format(" > {0} {1} do tipo {2}", grupo.Value.Count,
                    grupo.Value.Count == 1 ? "arquivo" : "arquivos",
                    grupo.Key));

                escritor.WriteLine();
            }

            escritor.WriteLine(linhasTraços);
        }

        private Dictionary<Motivo, List<string>> AgruparMotivo(List<KeyValuePair<string, Motivo>> arquivos)
        {
            Dictionary<Motivo, List<string>> hashMotivos = new Dictionary<Motivo, List<string>>();

            foreach (KeyValuePair<string, Motivo> par in arquivos)
            {
                List<string> lista;
                
                if (!hashMotivos.TryGetValue(par.Value, out lista))
                {
                    lista = new List<string>();
                    hashMotivos[par.Value] = lista;
                }

                lista.Add(par.Key);
            }

            return hashMotivos;
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
                escritor.WriteLine(grupo.Key.Name);
                escritor.WriteLine();

                int x = 0;
                foreach (KeyValuePair<string, Exception> par in grupo.Value)
                {
                    escritor.WriteLine(string.Format("{0} - {1}", ++x, par.Key));
                    escritor.WriteLine(string.Format("      {0}", par.Value.Message));
                }
            }
        }

        private void EscreveCabeçalhoGrupo(string título, StreamWriter escritor, Dictionary<Type, List<KeyValuePair<string, Exception>>> grupos)
        {
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine();
            escritor.WriteLine(título);
            escritor.WriteLine();

            foreach (KeyValuePair<Type, List<KeyValuePair<string, Exception>>> grupo in grupos)
            {
                escritor.WriteLine(string.Format(" > {0} {1} do tipo {2}", grupo.Value.Count, 
                    grupo.Value.Count == 1 ? "falha" : "falhas",
                    grupo.Key.Name));

                EscreverDescriçõesErros(escritor, grupo);
                escritor.WriteLine();
            }

            escritor.WriteLine(linhasTraços);
        }

        private void EscreverDescriçõesErros(StreamWriter escritor, KeyValuePair<Type, List<KeyValuePair<string, Exception>>> grupo)
        {
            SortedSet<string> descrições = new SortedSet<string>();

            foreach (KeyValuePair<string, Exception> par in grupo.Value)
            {
                descrições.Add(par.Value.Message);
                if (descrições.Count > MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO)
                    break;
            }

            if (descrições.Count < MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO)
            {
                foreach (string descrição in descrições)
                    escritor.WriteLine(string.Format("  .. {0}", descrição));
            }
            else
                escritor.WriteLine("    [...]");
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
        public List<KeyValuePair<string, Motivo>> ArquivosIgnorados => arquivosIgnorados;
    }
}
