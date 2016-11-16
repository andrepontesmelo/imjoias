using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ResultadoImportação
    {
        private ConjuntoAgrupado arquivosFalhados;
        private ConjuntoAgrupado arquivosIgnorados;
        private ConjuntoAgrupado arquivosSucesso;

        private DateTime início;
        private DateTime fim;
        public TimeSpan TempoDecorrido => fim - início;

        private string descriçãoProcesso;
        public int TotalArquivos => arquivosSucesso.TotalArquivos + arquivosFalhados.TotalArquivos + arquivosIgnorados.TotalArquivos;
        private string linhasTraços;

        private StreamWriter escritor;
        private string nomeArquivoSaída;

        private int ObterMáximoTamanhoColuna()
        {
            int tamanhoMáximo = 0;

            tamanhoMáximo = arquivosFalhados.ObtemTamanhoMáximo(tamanhoMáximo);
            tamanhoMáximo = arquivosIgnorados.ObtemTamanhoMáximo(tamanhoMáximo);
            tamanhoMáximo = arquivosSucesso.ObtemTamanhoMáximo(tamanhoMáximo);

            return tamanhoMáximo;
        }

        public ResultadoImportação(string descriçãoProcesso)
        {
            início = DateTime.Now;
            nomeArquivoSaída = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            escritor = new StreamWriter(nomeArquivoSaída);
            this.descriçãoProcesso = descriçãoProcesso;

            arquivosSucesso = new ConjuntoAgrupado(escritor);
            arquivosIgnorados = new ConjuntoAgrupadoMotivo(escritor);
            arquivosFalhados = new ConjuntoAgrupadoExceção(escritor);
        }

        public string GravarArquivoTxt(string versão)
        {
            fim = DateTime.Now;

            linhasTraços = new string('=', ObterMáximoTamanhoColuna()) + '\n';

            EscreveCabeçalho();
            EscreveTaxas();
            EscreveTodosArquivos();

            escritor.WriteLine(string.Format("{0} - {1} - Processo iniciado em {2} e terminado em {3}", versão,
                início.ToLongDateString(), início.ToLongTimeString(), DateTime.Now.ToLongTimeString()));

            escritor.Close();
            
            return nomeArquivoSaída;
        }

        private void EscreveCabeçalho()
        {
            escritor.WriteLine(descriçãoProcesso.ToUpper());
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine(string.Format("Tempo decorrido: {0}", ObterTempoLegível(TempoDecorrido)));
        }

        private void EscreveTodosArquivos()
        {
            EscreverComTítulo("Falhas", arquivosFalhados);
            EscreverComTítulo("Sucesso", arquivosSucesso);
            EscreverComTítulo("Ignorados", arquivosIgnorados);

            escritor.WriteLine(linhasTraços);
        }

        private void EscreverComTítulo(string título, ConjuntoAgrupado conjunto)
        {
            escritor.WriteLine(linhasTraços);
            escritor.WriteLine();
            escritor.WriteLine(título);
            escritor.WriteLine();

            conjunto.Escrever();
        }

        private void EscreveTaxas()
        {
            if (TotalArquivos == 0)
            {
                escritor.WriteLine("Nenhum arquivo foi processado.");
                return;
            }

            EscreveTaxa("Falhas", arquivosFalhados.TotalArquivos);
            EscreveTaxa("Sucesso", arquivosSucesso.TotalArquivos);
            EscreveTaxa("Ignorados", arquivosIgnorados.TotalArquivos);
        }

        internal void AdicionarFalha(string arquivo, Exception erro)
        {
            arquivosFalhados.Adicionar(new ArquivoExceção(arquivo, erro));
        }

        private void EscreveTaxa(string nome, int qtdArquivos)
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

        public ConjuntoAgrupado ArquivosSucesso => arquivosSucesso;
        public ConjuntoAgrupado ArquivosFalhados => arquivosFalhados;
        public ConjuntoAgrupado ArquivosIgnorados => arquivosIgnorados;
    }
}
