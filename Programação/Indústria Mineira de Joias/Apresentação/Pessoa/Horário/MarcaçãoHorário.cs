using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Horário
{
    partial class MarcaçãoHorário : UserControl
    {
        /// <summary>
        /// Hora inicial para exibição.
        /// </summary>
        private ushort horaInicial = 07;

        /// <summary>
        /// Hora final para exibição.
        /// </summary>
        private ushort horaFinal = 19;

        /// <summary>
        /// Hora inicial de exibição.
        /// </summary>
        [DefaultValue((ushort)07)]
        public ushort HoraInicial
        {
            get { return horaInicial; }
            set { horaInicial = value; }
        }

        /// <summary>
        /// Hora final de exibição.
        /// </summary>
        [DefaultValue((ushort)19)]
        public ushort HoraFinal
        {
            get { return horaFinal; }
            set { horaFinal = value; }
        }

        public MarcaçãoHorário()
        {
            InitializeComponent();
        }

        private void controleHorário_Paint(object sender, PaintEventArgs e)
        {
            float passo;
            ushort hora = horaInicial;

            passo = controleHorário.ClientSize.Height / (float)(horaFinal - horaInicial + 1);

            for (float i = 0; i < controleHorário.ClientSize.Height; i += passo)
            {
                string str = String.Format("{0}h", hora++);
                SizeF  tamanho = e.Graphics.MeasureString(str, Font);

                e.Graphics.DrawString(
                    str,
                    this.Font,
                    new SolidBrush(SystemColors.ControlText),
                    controleHorário.ClientSize.Width - tamanho.Width, i);
            }
        }
    }
}
