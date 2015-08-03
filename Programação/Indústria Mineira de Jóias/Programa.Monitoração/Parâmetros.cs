using System;
using System.Collections.Generic;
using System.Text;

namespace Programa.Monitoração
{
    public class Parâmetros
    {
        private static Parâmetros instância;
        private string host;
        private int port;
        private string database;
        private int alertaHoras;

        public string Host { get { return host; } }
        public string Database { get { return database; } }
        public int AlertaHoras
        {
            get
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        if (DateTime.Now.Hour < 13)
                            return alertaHoras;
                        else
                            return DateTime.Now.Hour - 13 + alertaHoras;

                    case DayOfWeek.Sunday:
                        return 32 + alertaHoras;

                    case DayOfWeek.Monday:
                        if (DateTime.Now.Hour < 7)
                            return 7 + 24 + 12 + alertaHoras;
                        else if (DateTime.Now.Hour > 18)
                            return DateTime.Now.Hour - 18 + alertaHoras;
                        else
                            return alertaHoras;

                    default:
                        if (DateTime.Now.Hour < 7)
                            return 7 + (24 - 18) + alertaHoras;
                        else if (DateTime.Now.Hour > 18)
                            return DateTime.Now.Hour - 18 + alertaHoras;
                        else
                            return alertaHoras;
                }
            }
        }
        public int Port { get { return port; } }

        public string HostCompleto
        {
            get
            {
                return database + "@" + host + ":" + port.ToString();
            }
        }

        public static Parâmetros Instância
        {
            get
            {
                if (instância == null)
                    instância = new Parâmetros();

                return instância;
            }
        }

        private Parâmetros()
        {
            Carregar();
        }

        private void Carregar()
        {
            try
            {
                Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");

                try
                {
                    reg = reg.OpenSubKey("Indústria Mineira de Jóias");
                    reg = reg.OpenSubKey("monitor");

                    if (reg == null)
                        throw new NullReferenceException();
                }
                catch
                {
                    host = "127.0.0.1";
                    port = 46033;
                    database = "imjoias";
                    alertaHoras = 3;
                    return;
                }

                host = (string)reg.GetValue("host", "127.0.0.1");
                port = int.Parse((string)reg.GetValue("port", "46033"));
                database = (string)reg.GetValue("database", "imjoias");
                alertaHoras = int.Parse((string)reg.GetValue("alerta horas", 3));
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Regedit preenchido incorretamente: " + e.Message);
            }
        }
    }
}
