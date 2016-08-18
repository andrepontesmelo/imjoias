using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Janela para exibição de manipulação de dados no banco de dados.
    /// </summary>
    /// <example>
    /// AguardeDB.Mostrar();
    /// Entidades.Bla zé = Entidades.Bla.Carregar();
    /// AguardeDB.Fechar();
    /// </example>
    public sealed partial class AguardeDB : Form
    {
        private static volatile bool abortar = false;
        private FechandoCallback aoFechar;
        private SuspendendoCallback aoSuspender;

        /// <summary>
        /// Constrói a janela de aguarde.
        /// </summary>
        private AguardeDB()
        {
            InitializeComponent();

            AguardeDB.Fechando += aoFechar = new FechandoCallback(AoFechar);
            AguardeDB.Suspendendo += aoSuspender = new SuspendendoCallback(AoSuspender);

            Application.EnterThreadModal += new EventHandler(Application_EnterThreadModal);
            Application.LeaveThreadModal += new EventHandler(Application_LeaveThreadModal);
        }

        void Application_LeaveThreadModal(object sender, EventArgs e)
        {
            try
            {
                Enabled = false;
                if (!Disposing)
                {
                    Visible = contador > 0;

                    if (contador <= 0)
                        Hide(); // Close();
                }
            }
            catch { }
        }

        void Application_EnterThreadModal(object sender, EventArgs e)
        {
            try
            {
                if (Enabled)
                    Visible = false;
            }
            catch { }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        void AoSuspender(bool valor)
        {
            if (InvokeRequired)
            {
                SuspendendoCallback método = new SuspendendoCallback(AoSuspender);
                BeginInvoke(método, valor);
            }
            else if (contador <= 0)
                Hide();
            else
            {
                if (valor)
                    Hide();
                else if (!Disposing && Enabled)
                    Show();
            }
        }


        /// <summary>
        /// Ocorre quando não existe mais nenhum dado sendo
        /// carregado do banco de dados.
        /// </summary>
        void AoFechar()
        {
            try
            {
                if (InvokeRequired)
                {
                    FechandoCallback método = new FechandoCallback(AoFechar);
                    BeginInvoke(método);
                }
                else
                {
                    Hide();
                    //Close();
                    //Dispose();
                }
            }
            catch
            {
            }
        }

        #region Itens estáticos

        private static Thread thread;
        private static volatile int contador;

        /// <summary>
        /// Mostra a janela em segundo plano.
        /// </summary>
        public static void Mostrar()
        {
            //#if DEBUG
//            Console.WriteLine("AguardeDB Mostrando...");
//            DepurarRastro();
//#endif
            abortar = false;

            try
            {
                if (contador++ <= 0)
                    contador = 1;

                if (thread == null)
                {
                    thread = new Thread(new ThreadStart(LoopMostrar));
                    thread.Name = "AguardeDB - mostrar";
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Fecha a janela se todos os dados já estiverem sido carregados.
        /// </summary>
        public static void Fechar()
        {
            try
            {
                if (--contador <= 0 && Fechando != null)
                if (Fechando != null)
                    Fechando();
                else if (thread != null)
                    abortar = true;
            }
            catch
            {
            }
        }

        public static void Suspensão(bool valor)
        {
            try
            {
                if (Suspendendo != null)
                    Suspendendo(valor);
                else
                {
                    contador = 0;
                    Fechar();
                }
            }
            catch { }
        }

        /// <summary>
        /// Loop para mostrar janela.
        /// </summary>
        private static void LoopMostrar()
        {
            try
            {
                using (AguardeDB janela = new AguardeDB())
                {
                    if (contador > 0 && !abortar)
                        janela.ShowDialog();
                }
            }
            catch
            {
            }
            finally
            {
                thread = null;
            }
        }

        private delegate void FechandoCallback();
        private delegate void SuspendendoCallback(bool valor);

        private static event FechandoCallback Fechando;
        private static event SuspendendoCallback Suspendendo;

        #endregion

        private void AguardeDB_Shown(object sender, EventArgs e)
        {
            if (contador == 0 || abortar)
                AoFechar();
        }

#if DEBUG
        private static void DepurarRastro()
        {
            try
            {
                System.Diagnostics.StackTrace pilha;
                System.Diagnostics.StackFrame quadro, quadro2;
                string arq1, arq2;
                string[] sep;
                int cnt = 0;

                pilha = new System.Diagnostics.StackTrace(3, true);

                Console.WriteLine();
                Console.WriteLine("AguardeDB ==========================");

                do
                {
                    quadro = pilha.GetFrame(cnt++);
                    quadro2 = pilha.GetFrame(cnt);

                    if (quadro != null)
                        arq1 = quadro.GetFileName();
                    else
                    {
                        arq1 = null;
                        arq2 = null;
                        break;
                    }

                    if (quadro2 != null)
                        arq2 = quadro2.GetFileName();
                    else
                    {
                        arq2 = null;
                        break;
                    }
                } while (arq1 == null);

                if (arq1 != null)
                {
                    sep = arq1.Split('\\');

                    if (sep.Length > 0)
                        arq1 = sep[sep.Length - 1];
                }

                if (arq2 != null)
                {
                    sep = arq2.Split('\\');

                    if (sep.Length > 0)
                        arq2 = sep[sep.Length - 1];
                }

                if (arq1 != null)
                    Console.WriteLine("~ Comando <- {0} ({1}:{2})",
                        quadro.GetMethod().Name, arq1, quadro.GetFileLineNumber());

                if (arq2 != null)
                    Console.WriteLine("             {0} ({1}:{2})\n",
                        quadro2.GetMethod().Name, arq2, quadro2.GetFileLineNumber());
            }
            catch
            {
                Console.WriteLine("Erro ao rastrear comando!");
            }
        }
#endif

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (abortar || contador <= 0)
            {
                Hide();
            }
        }
    }
}