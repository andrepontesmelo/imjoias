using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Impressão.Cliente;
using Apresentação.Impressão;
using System.Windows.Forms;

namespace Apresentação.Formulários.Impressão
{
    /// <summary>
    /// Controla a fila de impressão de documentos.
    /// </summary>
    /// <remarks>
    /// Ao terminar a impressão, o próprio objeto libera
    /// seus recursos chamando o método Dispose.
    /// </remarks>
    public class FilaImpressão : IDisposable
    {
        private ControleImpressão controle;
        private DadosCandidatura impressora;
        private NotifyIcon ícone;
        private Queue<DadosDocumento> documentos = new Queue<DadosDocumento>();
        private bool imprimindo = false;

        public event ControleImpressão.EventoImpressão AoImprimirDocumento;
        public event ControleImpressão.EventoImpressão AoFalharDocumento;

        /// <summary>
        /// Mantém uma lista das filas em execução.
        /// </summary>
        private static List<FilaImpressão> filas;

        /// <summary>
        /// Obtém uma nova fila a ser impressa.
        /// </summary>
        /// <remarks>
        /// A utilização do método estático permite que a fila
        /// não seja liberada pelo serviço de Garbage Colector
        /// mesmo que o programador não mantenha uma referência
        /// para este objeto depois de mandar imprimir. Assim
        /// o processo pode ser concluído de forma assíncrona.
        /// </remarks>
        public static FilaImpressão ObterFila(ControleImpressão controle, DadosCandidatura impressora)
        {
            FilaImpressão fila;

            if (filas == null)
                filas = new List<FilaImpressão>();

            fila = new FilaImpressão(controle, impressora);
            filas.Add(fila);

            return fila;
        }

        private FilaImpressão(ControleImpressão controle, DadosCandidatura impressora)
        {
            this.controle = controle;
            this.impressora = impressora;

            ícone = new NotifyIcon();
            ícone.Text = "Impressão remota";
            ícone.Icon = Properties.Resources.printer;
            ícone.Visible = true;

            controle.ImpressãoCompleta += new ControleImpressão.EventoImpressão(ImpressãoCompleta);
            controle.ErroImpressão += new ControleImpressão.EventoImpressão(ErroImpressão);
        }

        /// <summary>
        /// Ocorre quando não é possível imprimir documento remotamente.
        /// </summary>
        private void ErroImpressão(TipoDocumento tipo, ulong código)
        {
            MessageBox.Show(
                "ATENÇÃO!\n\nNão foi possível imprimir o documento " + Enum.GetName(typeof(TipoDocumento), tipo) +
                " de código " + código.ToString() + ".",
                "Falha na impressão",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            FinalizarImpressão();

            try
            {
                if (AoFalharDocumento != null)
                    AoFalharDocumento(tipo, código);
            }
            catch { }
        }

        /// <summary>
        /// Ocorre quando a impressão de um documento é completado.
        /// </summary>
        private void ImpressãoCompleta(TipoDocumento tipo, ulong código)
        {
            if (tipo != TipoDocumento.Acerto)
                NotificaçãoSimples.Mostrar(
                    "Impressão completada!",
                    "Documento " + Enum.GetName(typeof(TipoDocumento), tipo) +
                    " " + código.ToString() + " foi impresso com sucesso.");
            else
                NotificaçãoSimples.Mostrar(
                    "Impressão completada!",
                    "O acerto foi impresso com sucesso.");

            FinalizarImpressão();

            try
            {
                if (AoImprimirDocumento != null)
                    AoImprimirDocumento(tipo, código);
            }
            catch { }
        }

        /// <summary>
        /// Imprime um documento.
        /// </summary>
        /// <param name="código">Código do documento a ser impresso.</param>
        public void Imprimir(ulong código, int cópias)
        {
            lock (documentos)
            {
                DadosDocumento documento = new DadosDocumento(controle.Tipo, código);
                documento.Cópias = cópias;

                documentos.Enqueue(documento);
            }

            ImprimirPróximo();
        }

        /// <summary>
        /// Imprime um conjunto de documentos.
        /// </summary>
        /// <param name="códigos">Vetor de códigos de documentos a serem impressos.</param>
        public void Imprimir(ulong[] códigos, int cópias)
        {
            foreach (ulong código in códigos)
            {
                DadosDocumento documento = new DadosDocumento(controle.Tipo, código);
                documento.Cópias = cópias;
                
                documentos.Enqueue(documento);
            }

            ImprimirPróximo();
        }

        /// <summary>
        /// Imprime próximo docuemnto da fila.
        /// </summary>
        private void ImprimirPróximo()
        {
            lock (documentos)
                if (!imprimindo)
                {
                    DadosDocumento documento = documentos.Dequeue();

                    imprimindo = true;

                    if (documento.Tipo != TipoDocumento.Acerto)
                        ícone.ShowBalloonTip(5000,
                            "Iniciando impressão",
                            "Documento " + Enum.GetName(typeof(TipoDocumento), documento.Tipo) +
                            " " + documento.Código.ToString() + " foi enviado para impressão.",
                            ToolTipIcon.Info);
                    else
                        ícone.ShowBalloonTip(5000,
                            "Iniciando impressão",
                            "O acerto foi enviado para impressão.",
                            ToolTipIcon.Info);

                    try
                    {
                        controle.RequisitarImpressão(impressora, documento);
                    }
                    catch (Exception e)
                    {
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

                        ErroImpressão(documento.Tipo, documento.Código);
                    }
                }
        }

        /// <summary>
        /// Imprime um documento, especificando a página inicial e a página final.
        /// </summary>
        /// <param name="código">Código do documento.</param>
        /// <param name="págInicial">Página inicial.</param>
        /// <param name="págFinal">Página final.</param>
        public void Imprimir(ulong código, int págInicial, int págFinal, int cópias)
        {
            if (controle.Tipo == TipoDocumento.Acerto)
                throw new NotSupportedException("O método para impressão escolhido não pode ser usado para imprimir acerto.");

            lock (documentos)
            {
                DadosDocumento documento = new DadosDocumento(controle.Tipo, código);

                documento.PágInicial = págInicial;
                documento.PágFinal = págFinal;
                documento.Cópias = cópias;

                documentos.Enqueue(documento);
            }

            ImprimirPróximo();
        }

        public void Imprimir(Entidades.Acerto.ControleAcertoMercadorias acerto, int págInicial, int págFinal, int cópias)
        {
            if (controle.Tipo != TipoDocumento.Acerto)
                throw new NotSupportedException("O método para impressão escolhido só pode ser usado para impressão de acerto.");

            lock (documentos)
            {
                if (imprimindo || documentos.Count > 0)
                    throw new NotSupportedException("Não é possível enfileirar várias impressões de acerto.");

                imprimindo = true;
            }

            DadosDocumento documento = new DadosDocumento(TipoDocumento.Acerto, acerto.Acerto.Código);

            documento.PágInicial = págInicial;
            documento.PágFinal = págFinal;
            documento.Cópias = cópias;

            ícone.ShowBalloonTip(5000,
                "Iniciando impressão ",
                "O acerto foi enviado para impressão.",
                ToolTipIcon.Info);

            try
            {
                controle.RequisitarImpressão(impressora, documento);
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

                ErroImpressão(documento.Tipo, documento.Código);
            }
        }
        

        /// <summary>
        /// Finaliza a impressão de um documento, iniciando a impressão
        /// do próximo, se houver.
        /// </summary>
        private void FinalizarImpressão()
        {
            lock (documentos)
            {
                imprimindo = false;

                if (documentos.Count > 0)
                    ImprimirPróximo();
                else
                {
                    AsyncDispose método = new AsyncDispose(Dispose);
                    ícone.Visible = false;
                    filas.Remove(this);
                    método.BeginInvoke(new AsyncCallback(DisposeCallback), método);
                }
            }
        }

        #region IDisposable Members

        private delegate void AsyncDispose();

        public void Dispose()
        {
            try
            {
                if (controle != null)
                {
                    controle.Dispose();
                    controle = null;
                }
            }
            finally
            {
                filas.Remove(this);
            }
        }

        private void DisposeCallback(IAsyncResult resultado)
        {
            AsyncDispose método = (AsyncDispose)resultado.AsyncState;
            método.EndInvoke(resultado);
        }

        #endregion
    }
}
