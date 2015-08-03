using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apresentação.Impressão.Servidor;
using Apresentação.Impressão;
using System.Drawing.Printing;
using System.ServiceProcess;

namespace Programa.ServidorImpressão
{
    static class Program
    {
        private static Serviço serviço;

        class Windows
        {
            private NotifyIcon notificação;
            private ServiceController serviçoWindows;

            public Windows()
            {
                ContextMenu menu = new ContextMenu();
                List<MenuItem> impressoras = new List<MenuItem>();

                try
                {
                    serviçoWindows = new System.ServiceProcess.ServiceController("IMJPrint");

                    if (serviçoWindows.Status != ServiceControllerStatus.Running && serviçoWindows.Status != ServiceControllerStatus.StartPending)
                    {
                        serviçoWindows.Close();
                        serviçoWindows = null;
                    }
                    else
                    {
                        MenuItem itemServ = new MenuItem("Serviço");
                        itemServ.Checked = true;
                        itemServ.Click += new EventHandler(AlternarServiço);
                        menu.MenuItems.Add(itemServ);
                    }
                }
                catch
                {
                    serviçoWindows = null;
                }

                foreach (string impressora in PrinterSettings.InstalledPrinters)
                {
                    MenuItem itemImp = new MenuItem(impressora);
                    itemImp.Click += new EventHandler(ImpressoraClick);
                    impressoras.Add(itemImp);
                }

                menu.MenuItems.Add("Impressoras", impressoras.ToArray());

                menu.MenuItems.Add(new MenuItem("-"));

                MenuItem item = new MenuItem("Fechar");
                menu.MenuItems.Add(item);
                item.Click += new EventHandler(item_Click);

                notificação = new NotifyIcon(); 
                notificação.Text = "Servidor de impressão remota";
                notificação.Icon = Properties.Resources.ícone;
                notificação.ContextMenu = menu;
                notificação.Visible = true;
            }

            void AlternarServiço(object sender, EventArgs e)
            {
                ((MenuItem)sender).Checked = !((MenuItem)sender).Checked;

                if (((MenuItem)sender).Checked)
                    serviçoWindows.Start();
                else
                    serviçoWindows.Stop();
            }

            void ImpressoraClick(object sender, EventArgs e)
            {
                ConfigurarImpressora dlg = new ConfigurarImpressora(new ConfiguraçãoImpressora(((MenuItem)sender).Text), serviço, serviçoWindows);
                dlg.Show();
            }

            void item_Click(object sender, EventArgs e)
            {
                notificação.Visible = false;
                Application.Exit();
            }

            public ServiceController ServiçoWindows { get { return serviçoWindows; } }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Windows windows;

            try
            {
                windows = new Windows();
            }
            catch
            {
                windows = null;
            }

            Acesso.MySQL.MySQLUsuários usuários = new Acesso.MySQL.MySQLUsuários();

            usuários.EfetuarLogin("imjoias", "***REMOVED***");

            if (windows == null || windows.ServiçoWindows == null)
            {
                try
                {
                    serviço = new Serviço();
                }
                catch
                {
                    MessageBox.Show("Não foi possível ligar o serviço. Configuração ainda é possível.");
                }
            }

            Application.Run();
        }
   }
}