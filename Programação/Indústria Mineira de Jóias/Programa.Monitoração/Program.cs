using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Acesso.Comum;
using Acesso.MySQL;

namespace Programa.Monitoração
{
    static class Program
    {
        public static MySQLUsuários usuários = new MySQLUsuários();

        class Windows
        {
            private IDbConnection conexão;
            private DateTime? últimoBug;

            private Timer timer;
            private NotifyIcon notificação;
            private bool dessincronizado = true;
            private bool usuárioAlertadoDessinconização = false;
            private bool usuárioAlertadoSincronzação = false;
            private bool usuárioAlertadoConexãoPerdida = true;

            private void AtualizarTray()
            {
                if (ConexãoFechada)
                {
                    notificação.Icon = Properties.Resources.desconectado;
                    notificação.Text = "Conectando..." + Parâmetros.Instância.HostCompleto;
                }
                else if (dessincronizado)
                    notificação.Icon = Properties.Resources.desatualizado;
                else
                    notificação.Icon = Properties.Resources.online;
            }

            private bool ConexãoFechada
            {
                get
                {
                    return (conexão == null || conexão.State != ConnectionState.Open);
                }
            }

            public Windows()
            {
                ContextMenu menu = new ContextMenu();

                timer = new Timer();
                timer.Interval = 60000;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Enabled = true;

                MenuItem itemFechar = new MenuItem("Fechar");
                menu.MenuItems.Add(itemFechar);
                itemFechar.Click += new EventHandler(Fechar);

                notificação = new NotifyIcon();
                notificação.ContextMenu = menu;
                notificação.Visible = true;
                notificação.Click += new EventHandler(notificação_Click);

                AtualizarTray();
                Conectar();
            }

            void notificação_Click(object sender, EventArgs e)
            {
                usuárioAlertadoDessinconização = false;
                usuárioAlertadoConexãoPerdida= false;
                usuárioAlertadoSincronzação= false;

                Atualizar();
            }

            void Atualizar()
            {
                if (ConexãoFechada)
                {
                    if (!usuárioAlertadoConexãoPerdida)
                    {
                        usuárioAlertadoConexãoPerdida = true;
                        notificação.ShowBalloonTip(
                            59990,
                            "Desconectado!", "Conexão ao mysql perdida. \nTentando nova conexão...\n\n\n" + Parâmetros.Instância.HostCompleto,
                            ToolTipIcon.Error);
                    }

                    Conectar();
                }
                else
                {
                    DateTime ultimaData = ObterÚltimaData();
                    DateTime? últimoBug = ObterÚltimoBug();
                    TimeSpan intervalo;

                    intervalo = DateTime.Now - ultimaData;

                    usuárioAlertadoConexãoPerdida = false;

                    
                    dessincronizado = intervalo.TotalHours > Parâmetros.Instância.AlertaHoras;
                    notificação.Text = dessincronizado ? "Dessincronizado" : "Sincronizado";
                    notificação.Text += "\n\nÚltima data: " + ultimaData.ToString();

                    if ((dessincronizado && !usuárioAlertadoDessinconização && ultimaData != DateTime.MinValue)
                        || (!dessincronizado && !usuárioAlertadoSincronzação))
                        Notificar(dessincronizado, intervalo, ultimaData);
                    else if ((últimoBug.HasValue && !this.últimoBug.HasValue) ||
                        (últimoBug.HasValue && this.últimoBug.HasValue && últimoBug > this.últimoBug))
                    {
                        this.últimoBug = últimoBug;
                        NotificarBug();
                    }
                }

                AtualizarTray();
            }

            void timer_Tick(object sender, EventArgs e)
            {
                Atualizar();
            }

            private void Notificar(bool dessincronizado, TimeSpan intervalo, DateTime ultimaData)
            {
                notificação.ShowBalloonTip(10000,
                 dessincronizado ? "Sistema dessincronizado!" : "Sincronizado",
                 ObterMensagemStatus() + "\n" + Parâmetros.Instância.HostCompleto + "\n\nÚltima atualização:\n" + ultimaData.ToLongDateString() + " " + ultimaData.ToShortTimeString() + "\n\nAtraso de " + FormatarDiferença(intervalo),
                 dessincronizado ? ToolTipIcon.Warning : ToolTipIcon.Info);

                if (dessincronizado)
                    usuárioAlertadoDessinconização = true;
                else
                    usuárioAlertadoSincronzação = true;
            }

            private void NotificarBug()
            {
                notificação.ShowBalloonTip(int.MaxValue,
                    "Vamos corrigir um bug?",
                    "Deu pau há " + FormatarDiferença(DateTime.Now - últimoBug.Value)
                    + ".",
                    ToolTipIcon.Error);
            }

            private string FormatarDiferença(TimeSpan diferença)
            {
                string texto = "";

                if (diferença.Days > 0)
                    texto += diferença.Days + " dia" + (diferença.Days > 1 ? "s" : "") + ", ";
                if (diferença.Hours > 0)
                    texto += diferença.Hours + " hora" + (diferença.Hours > 1 ? "s" : "") + " e ";

                texto += diferença.Minutes +  " minuto" + (diferença.Minutes > 1 ? "s" : "");

                return texto;
            }

            void Fechar(object sender, EventArgs e)
            {
                Application.Exit();
            }

            public DateTime ObterÚltimaData()
            {
                DateTime data;
                IDbCommand cmd = conexão.CreateCommand();
                cmd.CommandText = "select * from ((select max(data) as data from saidaitem)  UNION (select max(data) as data from vendaitem) UNION (select max(data) as data from retornoitem) UNION (select max(ultimadata) as data from bug) UNION (select max(entrada) as data FROM visita)) datas where data is not null order by data desc limit 1";

                try 
                {
                    data = (DateTime)cmd.ExecuteScalar();
                } catch (Exception)
                {
                    data = DateTime.MinValue;
                }

                return data;
            }

            private string ObterMensagemStatus()
            {
                string msg;
                IDbCommand cmd = conexão.CreateCommand();
                IDataReader leitor = null;
                cmd.CommandText = "show slave status";

                try
                {
                    leitor = cmd.ExecuteReader();
                    leitor.Read();

                    msg = (string) leitor[0];
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();
                }

                return msg;
            }

            public DateTime? ObterÚltimoBug()
            {
                DateTime? data;
                IDbCommand cmd = conexão.CreateCommand();
                cmd.CommandText = "select max(ultimaData) from bug where corrigido = 0 AND ignorar = 0";

                try
                {
                    object obj = cmd.ExecuteScalar();

                    if (obj != null && !(obj is DBNull))
                        data = (DateTime)cmd.ExecuteScalar();
                    else
                        data = null;
                }
                catch (Exception)
                {
                    data = null;
                }

                return data;
            }

            private void Conectar()
            {
                usuárioAlertadoDessinconização = false;
                usuárioAlertadoSincronzação = false;

                try
                {
                    conexão = usuários.Conectar("imjoias", "***REMOVED***", Parâmetros.Instância.Host, Parâmetros.Instância.Port, Parâmetros.Instância.Database);
                }
                catch
                {
                    conexão = null;
                }

                Atualizar();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             Windows windows;

             windows = new Windows();
             Application.Run();
        }
    }
}
