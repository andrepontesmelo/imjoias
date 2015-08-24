using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Apresentação
{
    public class ControladorInatividade
    {
        private int TEMPO_INATIVIDADE_MINUTOS = 10;

        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        internal struct LASTINPUTINFO 
        {
            public uint cbSize;

            public uint dwTime;
        }

        private Timer timer = new Timer();

        public ControladorInatividade()
        {
            timer.Enabled = false;
            timer.Interval = 15000;
            timer.Tick += timer_Tick;
        }

        public void Iniciar()
        {
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            TimeSpan tempoParado = TimeSpan.FromTicks(Environment.TickCount - lastInPut.dwTime);

            if (tempoParado.TotalMinutes > TEMPO_INATIVIDADE_MINUTOS)
                Reiniciar();
        }

        private void Reiniciar()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); 
            Environment.Exit(0); 
        }
    }
}
