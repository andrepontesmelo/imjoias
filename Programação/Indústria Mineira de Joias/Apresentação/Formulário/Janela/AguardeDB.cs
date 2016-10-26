using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public sealed partial class AguardeDB : Form
    {
        private static volatile bool abortado = false;
        private static volatile bool suspenso = false;
        private FechandoCallback aoFechar;
        private SuspendendoCallback aoSuspender;

        private AguardeDB()
        {
            InitializeComponent();

            Fechando += aoFechar = new FechandoCallback(AoFechar);
            Suspendendo += aoSuspender = new SuspendendoCallback(AoSuspender);

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
                        Hide();
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
            } else
            {
                suspenso = valor;

                if (contador <= 0)
                    Hide();
                else
                {
                    if (valor)
                        Hide();
                    else if (!Disposing && Enabled)
                        Show();
                }
            }
        }

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
                    Hide();
            }
            catch
            {
            }
        }

        private static Thread thread;
        private static volatile int contador;

        public static void Mostrar()
        {
            abortado = false;

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

        public static void Fechar()
        {
            try
            {
                if (--contador <= 0 && Fechando != null)
                if (Fechando != null)
                    Fechando();
                else if (thread != null)
                    abortado = true;
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

        private static void LoopMostrar()
        {
            try
            {
                using (AguardeDB janela = new AguardeDB())
                {
                    if (contador > 0 && !abortado && !suspenso)
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

        private void AguardeDB_Shown(object sender, EventArgs e)
        {
            if (contador == 0 || abortado)
                AoFechar();
        }

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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (abortado || contador <= 0)
                Hide();
        }
    }
}