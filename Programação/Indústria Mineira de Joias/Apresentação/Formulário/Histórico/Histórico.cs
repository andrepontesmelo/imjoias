using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários.Histórico
{
    /// <summary>
    /// Mostra um histórico contendo data e autoria.
    /// </summary>
    public partial class Histórico : UserControl
    {
        /// <summary>
        /// Itens do histórico.
        /// </summary>
        private List<IHistóricoItem> itens = new List<IHistóricoItem>();

        public Histórico()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #region Propriedades

        /// <summary>
        /// Itens do histórico.
        /// </summary>
        [Browsable(false), ReadOnly(true)]
        public List<IHistóricoItem> Itens
        {
            get { return itens; }
            set { itens = value; }
        }

        #endregion

        /// <summary>
        /// Ocorre ao desenhar o controle.
        /// </summary>
        private void Histórico_Paint(object sender, PaintEventArgs e)
        {
            float y = 0;

            using (Brush bgBrush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(bgBrush, 0, 0, Width, Height);

            foreach (IHistóricoItem item in itens)
            {
                item.Localização = new RectangleF(
                    0f, y, ClientSize.Width, item.Localização.Height);

                item.Desenhar(e.Graphics);

                y += item.Altura + 15;
            }

            if (painel.Height != (int)y + 1)
            {
                painel.Height = (int)y + 1;
                AutoScrollPosition = new Point(painel.Width - 1, painel.Height - 1);
            }
        }

        private void painel_Resize(object sender, EventArgs e)
        {
            painel.Invalidate();
        }

        public void MostrarÚltimo()
        {
            painel.Refresh();
            AutoScrollPosition = new Point(painel.Width - 1, painel.Height - 1);
        }
    }
}
