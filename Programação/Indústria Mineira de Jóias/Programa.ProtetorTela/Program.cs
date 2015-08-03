using System;
using System.Windows.Forms;
using System.Globalization;

namespace Programa.ProtetorTela
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Get the 2 character command line argument
                string arg = args[0].ToLower(CultureInfo.InvariantCulture).Trim().Substring(0, 2);
                switch (arg)
                {
                    case "/c":
                        // Show the options dialog
                        ShowOptions();
                        break;
                    case "/p":
                        //ShowPreview(args[1]);
                        break;
                    case "/s":
                        // Show screensaver form
                        ShowScreenSaver();
                        break;
                    default:
                        MessageBox.Show("Invalid command line argument :" + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // If no arguments were passed in, show the screensaver
                ShowScreenSaver();
            }
        }

        static void ShowOptions()
        {
            OptionsForm optionsForm = new OptionsForm();
            Application.Run(optionsForm);
        }

        static void ShowScreenSaver()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            ScreenSaverForm screenSaver = new ScreenSaverForm();
            Application.Run(screenSaver);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e.Exception);
            }
            catch { }
        }

        //static void ShowPreview(string hwnd)
        //{
        //    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(new IntPtr(long.Parse(hwnd))))
        //    {
        //        g.FillRectangle(System.Drawing.Brushes.White, g.ClipBounds);
        //        g.DrawImageUnscaled(
        //            Entidades.Álbum.Foto.Redesenhar(
        //            Properties.Resources.Logo, Convert.ToInt32(g.ClipBounds.Width), Convert.ToInt32(g.ClipBounds.Height)),
        //            Convert.ToInt32(g.ClipBounds.Left),
        //            Convert.ToInt32(g.ClipBounds.Top));
        //    }
        //}
    }
}