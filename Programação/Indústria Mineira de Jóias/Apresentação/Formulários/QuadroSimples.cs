using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Apresentação.Formulários
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design",
     typeof(System.ComponentModel.Design.IDesigner))]
    [Serializable]
    public partial class QuadroSimples : UserControl
    {
        private GraphicsPath caminho, caminho2;
        private int tamanho = 5;
        private int distância = 2;
        private Color borda = Color.WhiteSmoke, cor1 = Color.White, cor2 = Color.WhiteSmoke;

        [DefaultValue(5)]
        public int Tamanho { get { return tamanho; } set { tamanho = value; Invalidate(); RefazerCaminho();  } }

        [DefaultValue(2)]
        public int Distância { get { return distância; } set { distância = value; Invalidate(); RefazerCaminho();  } }

        [DefaultValue(typeof(Color), "Color.WhiteSmoke")]
        public Color Borda { get { return borda; } set { borda = value; Invalidate(); } }

        [DefaultValue(typeof(Color), "Color.White")]
        public Color Cor1 { get { return cor1; } set { cor1 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), "Color.WhiteSmoke")]
        public Color Cor2 { get { return cor2; } set { cor2 = value; Invalidate(); } }

        public QuadroSimples()
        {
                caminho = new GraphicsPath();
                caminho2 = new GraphicsPath();

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefazerCaminho();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RefazerCaminho();
        }

        private void RefazerCaminho()
        {
            caminho.Reset();
            caminho.AddArc(0, 0, tamanho, tamanho, 180, 90);
            caminho.AddArc(this.Width - tamanho, 0, tamanho, tamanho, 270, 90);
            caminho.AddArc(this.Width - tamanho, this.Height - tamanho, tamanho, tamanho, 0, 90);
            caminho.AddArc(0, this.Height - tamanho, tamanho, tamanho, 90, 90);
            caminho.CloseFigure();

            caminho2.Reset();
            caminho2.AddArc(distância, distância, tamanho, tamanho, 180, 90);
            caminho2.AddArc(this.Width - tamanho - distância, distância, tamanho, tamanho, 270, 90);
            caminho2.AddArc(this.Width - tamanho - distância, this.Height - tamanho - distância, tamanho, tamanho, 0, 90);
            caminho2.AddArc(distância, this.Height - tamanho - distância, tamanho, tamanho, 90, 90);
            caminho2.CloseFigure();

            Invalidate(true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            using (Pen pen = new Pen(borda, 2))
            {
                e.Graphics.DrawPath(pen, caminho);
            }

            using (Brush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(this.Width, this.Height),
                cor1, cor2))
            {
                e.Graphics.FillPath(brush, caminho2);
            }
        }
    }
}
