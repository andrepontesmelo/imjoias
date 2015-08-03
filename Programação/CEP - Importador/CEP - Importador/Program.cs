using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Importador
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

            string origem;
            string destino;

            using (System.Windows.Forms.OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Importar banco de CEP";
                dlg.Filter = "Banco de dados do Microsoft Access (*.mdb)|*.mdb|Todos os arquivos|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                    origem = dlg.FileName;
                else
                    return;
            }

            Application.Run(new Acompanhamento(origem));
        }
    }
}
