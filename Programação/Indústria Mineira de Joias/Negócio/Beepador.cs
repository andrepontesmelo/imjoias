using System;
using System.Runtime.InteropServices;

namespace Negócio
{
	/// <summary>
	/// Classe utilitária para beeps
	/// </summary>
	public abstract class Beepador
	{
		[DllImport("kernel32.dll")]
		private static extern bool Beep(int freq, int duration);

		private Beepador()
		{}

		public static void Aviso()
		{
            try
            {
                Beep(200, 50);
                Beep(400, 50);
            }
            catch { }
		}

		public static void Erro()
		{
            try
            {
                Beep(2000, 50);
                Beep(400, 400);
            }
            catch { }
		}

		public static void EsperandoPorAtendimento()
		{
            try
            {
                Beep(440, 100);
                Beep(300, 100);
            }
            catch { }
		}

		public static void EsperandoPorAtendimentoUrgente()
		{
            try
            {
                Beep(1000, 100);
                Beep(2000, 100);
            }
            catch { }
		}

		public static void BalãoReferênciaNãoEncontrada()
		{
            try
            {
                Beep(2000, 50);
                Beep(400, 400);
            }
            catch { }
		}

		public static void Despertador()
		{
            try
            {
                Beep(1200, 500);
                Beep(1800, 250);
            }
            catch { }
		}

        public static void Dica()
        {
            try
            {
                Beep(200, 50);
                Beep(300, 50);
                Beep(400, 50);
            }
            catch { }
        }

        public static void Alerta()
        {
            try
            {
                Beep(440, 100);
                Beep(300, 100);
            }
            catch { }
        }
    }
}
