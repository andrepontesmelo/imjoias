using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Programa.TesteDesempenho
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Apresentação.Formulários.Aplicação.Executar(typeof(Principal), new Acesso.MySQL.MySQLUsuários());
        }
    }
}