using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Apresentação.Pessoa
{
    [ProvideProperty("FormatarNome", typeof(TextBoxBase))]
    public partial class FormatadorNome : Component, IExtenderProvider
    {
        /// <summary>
        /// Título da mensagem exibida ao usuário sugerindo
        /// que o nome não esteja digitado corretamente.
        /// </summary>
        private const string adequarNomeTítulo = "Provável digitação incorreta de nome";

        /// <summary>
        /// Mensagem exibida ao usuário sugerindo que o nome
        /// não esteja digitado corretamente.
        /// </summary>
        private const string adequarNomeDescrição = "Por favor, digite apenas o nome de uma\n" +
                                           "única pessoa na caixa de texto. É importante\n" +
                                           "que cada dado seja preenchido em seu devido\n" +
                                           "lugar para que o processamento futuro\n" +
                                           "automático dos dados seja feito de\n" +
                                           "forma correta.";

        /// <summary>
        /// Tempo de espera por alteração em milissegundos.
        /// </summary>
        private const int tempoAlteração = 150;
        
        /// <summary>
        /// TextBox que será formatada.
        /// </summary>
        private List<TextBoxBase> controles = new List<TextBoxBase>();

        /// <summary>
        /// Determina se o TextBox foi alterado.
        /// </summary>
        private volatile bool alterado = false;

        /// <summary>
        /// Determina se o TextBox está formatado.
        /// </summary>
        private volatile bool formatado = false;

        /// <summary>
        /// Tratamento de pressionamento de tecla.
        /// </summary>
        private KeyPressEventHandler aoPressionarTecla;

        /// <summary>
        /// Tratamento de perda de foco no TextBox.
        /// </summary>
        private EventHandler aoDeixarTextBox;

        /// <summary>
        /// Tratamento de alteração no TextBox.
        /// </summary>
        private EventHandler aoAlterarTexto;


        #region Construtores

        public FormatadorNome()
        {
            InitializeComponent();

            aoPressionarTecla = new KeyPressEventHandler(AoPressionarTecla);
            aoDeixarTextBox = new EventHandler(AoDeixarTextBox);
            aoAlterarTexto = new EventHandler(AoAlterarTexto);

            if (constantes == null)
                CarregarConstantes();
        }

        public FormatadorNome(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            aoPressionarTecla = new KeyPressEventHandler(AoPressionarTecla);
            aoDeixarTextBox = new EventHandler(AoDeixarTextBox);
            aoAlterarTexto = new EventHandler(AoAlterarTexto);

            if (constantes == null)
                CarregarConstantes();
        }

        #endregion

        /// <summary>
        /// Desvincula TextBox do formatador.
        /// </summary>
        private void Desvincular(TextBoxBase txt)
        {
            txt.KeyPress -= aoPressionarTecla;
            txt.Leave -= aoDeixarTextBox;
            txt.TextChanged -= aoAlterarTexto;

            controles.Remove(txt);
        }

        /// <summary>
        /// Vinclua TextBox ao formatador.
        /// </summary>
        private void Vincular(TextBoxBase txt)
        {
            txt.KeyPress += aoPressionarTecla;
            txt.Leave += aoDeixarTextBox;
            txt.TextChanged += aoAlterarTexto;

            controles.Add(txt);
        }

        /// <summary>
        /// Ocorre ao alterar o conteúdo do TextBox.
        /// </summary>
        private void AoAlterarTexto(object sender, EventArgs e)
        {
            alterado = true;
            formatado = false;

            if (!bgFormatação.IsBusy)
                bgFormatação.RunWorkerAsync((TextBoxBase)sender);
        }

        /// <summary>
        /// Ocorre quando o usuário deixa o TextBox.
        /// </summary>
        private void AoDeixarTextBox(object sender, EventArgs e)
        {
            TextBoxBase txt = (TextBoxBase)sender;

            if (!formatado)
                if (bgFormatação.IsBusy)
                    try
                    {
                        bgFormatação.CancelAsync();
                        AlterarTextBox(txt, FormatarTexto(txt.Text));
                    }
                    catch { }
                else
                    AlterarTextBox(txt, FormatarTexto(txt.Text));
        }

        /// <summary>
        /// Ocorre ao pressionar a tecla.
        /// </summary>
        private void AoPressionarTecla(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '-':
                case '/':
                case ',':
                case ';':
                case ':':
                case '(':
                case '[':
                case '{':
                case '}':
                case ']':
                case ')':
                case '|':
                case '\\':
                case '*':
                case '+':
                case '<':
                case '>':
                case '?':
                    //MostrarMensagem((TextBoxBase)sender, adequarNomeTítulo, adequarNomeDescrição);
                    break;
            }
        }

        /// <summary>
        /// Formata em segundo plano o conteúdo do TextBox.
        /// </summary>
        private void FormatarConteúdo(object sender, DoWorkEventArgs e)
        {
            do
            {
                do
                {
                    alterado = false;
                    Thread.Sleep(tempoAlteração);
                } while (alterado && !bgFormatação.CancellationPending);

                if (!bgFormatação.CancellationPending)
                    e.Result = new object[] {
                        e.Argument,
                        FormatarTexto(RecuperarTexto((TextBoxBase)e.Argument)) };
                else
                    e.Cancel = true;
            } while (alterado && !bgFormatação.CancellationPending);
        }

        /// <summary>
        /// Assinatura do método para recuperação de texto do TextBox.
        /// </summary>
        /// <returns>Texto do TextBox.</returns>
        private delegate string RecuperarTextoCallback(TextBoxBase txt);

        /// <summary>
        /// Recupera de forma segura o conteúdo do TextBox.
        /// </summary>
        /// <returns>Conteúdo do TextBox.</returns>
        private string RecuperarTexto(TextBoxBase txt)
        {
            if (txt.InvokeRequired)
            {
                RecuperarTextoCallback método = new RecuperarTextoCallback(RecuperarTexto);
                try
                {
                    return (string)txt.Invoke(método, txt);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            else
                return txt.Text;
        }

        /// <summary>
        /// Ocorre ao terminar de formatar o conteúdo
        /// do TextBox de forma assíncrona.
        /// </summary>
        private void AoFormatarAssincronamente(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                object[] vetor = (object[])e.Result;

                AlterarTextBox((TextBoxBase)vetor[0], (string)vetor[1]);
            }
        }

        /// <summary>
        /// Altera o conteúdo da TextBox.
        /// </summary>
        /// <param name="texto">Novo conteúdo.</param>
        private void AlterarTextBox(TextBoxBase txt, string texto)
        {
            int pos = txt.SelectionStart;
            int tam = txt.SelectionLength;
            string anterior = txt.Text;

            txt.Text = texto;

            txt.SelectionStart = pos;
            txt.SelectionLength = tam;

            /* Caso o TextBox esteja com foco e no final
             * existir um espaço, mantê-lo para digitação
             * do restante do nome.
             */
            if (txt.Focused && pos > txt.SelectionStart && anterior.Substring(anterior.Length - 1, 1) == " ")
            {
                txt.Text += " ";
                txt.SelectionStart = txt.Text.Length;
                formatado = false;
            }
            else
                formatado = true;
        }

        /// <summary>
        /// Formata um texto.
        /// </summary>
        /// <param name="texto">Texto a ser formatado.</param>
        /// <returns>Texto formatado.</returns>
        public static string FormatarTexto(string texto)
        {
            string textoFormatado = "";
            String[] palavras;

            if (texto == null || texto.Trim().Length == 0)
                return texto;

            texto = texto.Trim();
            texto = (texto.Substring(0, 1)).ToUpper() + texto.Substring(1, texto.Length - 1).ToLower();

            texto = texto.Replace("( ", "("); // ( andre ) -> (andre)
            texto = texto.Replace(" )", ")");

            palavras = texto.Split(' ');

            for (int x = 0; x < palavras.Length; x++)
            {
                string palavra = palavras[x];

                if (palavra.Length != 0)
                {
                    string constante;

                    if (x != 0)
                        textoFormatado += " ";

                    if (constantes.TryGetValue(palavra, out constante))
                        textoFormatado += constante;

                    else if (palavra.StartsWith("(") && palavra.Length > 1)
                    {
                        textoFormatado += palavra.Substring(0, 2).ToUpper();
                        textoFormatado += palavra.Substring(2, palavra.Length - 2).ToLower();
                    }
                    else
                        textoFormatado += palavra.Substring(0, 1).ToUpper() + palavra.Substring(1, palavra.Length - 1).ToLower();
                }
            }
            
            return textoFormatado;
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is TextBoxBase;
        }

        [Description("Determina se deseja que a TextBox seja formatada como nome."),
         DefaultValue(false)]
        public bool GetFormatarNome(TextBoxBase controle)
        {
            return controles.Contains(controle);
        }

        public void SetFormatarNome(TextBoxBase controle, bool valor)
        {
            if (!valor && controles.Contains(controle))
                Desvincular(controle);

            else if (valor && !controles.Contains(controle))
                Vincular(controle);
        }

        #endregion
    }
}
