using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Barra de bot�es
	/// </summary>
	public class BarraBot�es : UserControl
	{
 		private Bot�o [] bot�es = new Bot�o[0];

        private const float foco = 0.6f;
        private const float zoom = 0.8f;
        private const int margem = 15;

        private bool mouseSobre = false;

		/// <summary>
		/// Constr�i uma barra de bot�es.
		/// </summary>
		public BarraBot�es()
		{
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromKnownColor(KnownColor.Transparent);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BarraBot�es_MouseMove);
            this.MouseLeave += new System.EventHandler(this.BarraBot�es_MouseLeave);
            this.MouseHover += new System.EventHandler(this.BarraBot�es_MouseHover);

            Cursor = Cursors.Hand;
        }

		/// <summary>
		/// Bot�es do formul�rio
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Bot�o [] Bot�es
		{
			get { return bot�es; }
            set
            {
                bot�es = value;

                if (!DesignMode)
                    foreach (Bot�o bot�o in bot�es)
                    {
                        bot�o.BaseFormul�rio = ParentForm as BaseFormul�rio;
                        bot�o.Modificado += new Bot�o.ModificadoCallback(AoModificarBot�o);
                    }

                if (bot�es != null && bot�es.Length > 0 && Width > 0)
                    AjustarTamanhos();

                Invalidate();
            }
		}

		/// <summary>
		/// Adiciona um bot�o � barra de bot�es.
		/// </summary>
		/// <param name="bot�o">Bot�o a ser adicionado.</param>
        public void AdicionarBot�o(Bot�o bot�o)
        {
            Bot�o[] anterior = this.bot�es;
            int i = 0;

            bot�es = new Bot�o[anterior.Length + 1];
            anterior.CopyTo(bot�es, 0);

            while (i < anterior.Length && bot�o.Ordena��o > anterior[i].Ordena��o)
                i++;

            for (int j = anterior.Length; j > i; j--)
                bot�es[j] = bot�es[j - 1];

            bot�es[i] = bot�o;

            if (!DesignMode)
            {
                bot�o.BaseFormul�rio = ParentForm as BaseFormul�rio;
                bot�o.Modificado += new Bot�o.ModificadoCallback(AoModificarBot�o);
            }

            Invalidate();
        }

        /// <summary>
        /// Remove um bot�o da barra.
        /// </summary>
        public void RemoverBot�o(Bot�o bot�o)
        {
            Bot�o[] anterior = this.bot�es;
            int i = 0;

            bot�es = new Bot�o[anterior.Length - 1];

            foreach (Bot�o aux in anterior)
                if (aux != bot�o)
                    bot�es[i++] = aux;

            Invalidate();
        }

		/// <summary>
		/// Ocorre ao redimensionar um bot�o.
		/// </summary>
		private void AoModificarBot�o(Bot�o bot�o)
		{
            Invalidate();
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            foreach (Bot�o bot�o in bot�es)
                bot�o.Dispose();
        }

        #region Extra�do do exemplo HyperBar do Microsoft Expression

        private double Fun��oHiperb�lica(double x, double zoom, double variance)
        {
            // This method name takes a slight liberty with the word 'hyperbolic' as the equation used is in fact Gaussian in nature.
            double exponent = (x * x) / (2 * variance * variance);
            return zoom * Math.Exp(-exponent);
        }

        private double ColumnDistanceFromDOI(Int32 columnIndex, Int32 columnCount)
        {
            // This method works for both the FunctionProfile Grid and the HyperBar Grid. It returns the
            // distance a column is from the degree of interest (DOI) as a proportion of the width of the control
            // containing the columns. The position of the mouse pointer within the HyperBar Grid (as a proportion
            // of its width) indicates the degree of interest. If the mouse is not currently within the HyperBar
            // Grid then 0.5 is the default value - i.e. the default DOI value is halfway across the HyperBar Grid.
            // This default DOI only affects how the FunctionProfile Grid appears because it must show a preview of
            // the hyperbolic function and its parameters at all times; the HyperBar Grid's columns are given a
            // default width when the mouse pointer is not within it.

            if (mouseSobre)
            {
                double mouseProportion = 0.5;

                Point mousePos = PointToClient(System.Windows.Forms.Cursor.Position);
                mouseProportion = mousePos.X / ((double)ClientSize.Width - margem);
                double positionProportion = (double)(columnIndex + 0.5) / (double)columnCount;
                return mouseProportion - positionProportion;
            }
            else
                return 0.2;
        }

        private void AjustarTamanhos()
        {
            double[] tamanhos = new double[bot�es.Length];
            double soma = 0;
            int posx = 0;

            // Whenever the mouse pointer moves within the HyperBar Grid, the user is effectively
            // indicating an adjustment in her degree of interest (DOI). Recalculate the size of each column
            // in respect to the new DOI.

            for (int i = 0; i < bot�es.Length; ++i)
            {
                double distanceFromDOI = ColumnDistanceFromDOI(i, bot�es.Length);

                // Plug the distance from zero (the DOI itself is at zero) into the hyperbolic function.
                double hyperbolic = Fun��oHiperb�lica(distanceFromDOI, zoom, foco);

                // Use Grid 'star-sizing' to set the Width of each column as a weighted proportion of available space.
                // The hyperbolic function returns a value in the range (0,1) which needs to be scaled to the actual
                // height of the HyperBar Grid.
                tamanhos[i] = hyperbolic;
                soma += hyperbolic;

                bot�es[i].DOI = distanceFromDOI;
            }

            for (int i = 0; i < bot�es.Length; i++)
            {
                bot�es[i].Width = (float)Math.Round(tamanhos[i] / soma * (ClientSize.Width - 6 * bot�es.Length - margem));
                bot�es[i].Height = (float)Math.Round(tamanhos[i] * Bot�o.TamanhoFiguraM�ximo);
                bot�es[i].Left = posx;

                posx += (int)Math.Round(bot�es[i].Width) + 6;
            }

            Invalidate();
        }

        #endregion

        /// <summary>
        /// Ocorre ao colocar o mouse sobre a barra.
        /// </summary>
        private void BarraBot�es_MouseHover(object sender, EventArgs e)
        {
            mouseSobre = true;
        }

        /// <summary>
        /// Ocorre ao retirar o mouse da barra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarraBot�es_MouseLeave(object sender, EventArgs e)
        {
            mouseSobre = false;
            AjustarTamanhos();
        }

        /// <summary>
        /// Ocorre ao mover o mouse sobre a barra de bot�es.
        /// </summary>
        private void BarraBot�es_MouseMove(object sender, MouseEventArgs e)
        {
            mouseSobre = true;
            AjustarTamanhos();
        }

        /// <summary>
        /// Ocorre ao desenhar, repassando a tarefa para cada bot�o.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (Bot�o bot�o in bot�es)
                bot�o.Desenhar(e.Graphics);
        }

        /// <summary>
        /// Ocorer ao clicar, disparando chamada no bot�o correspondente.
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            Bot�o clicado;

            base.OnClick(e);

            if (Enabled)
            {
                clicado = bot�es[0];

                for (int i = 1; i < bot�es.Length; i++)
                    if (Math.Abs(bot�es[i].DOI) < Math.Abs(clicado.DOI))
                        clicado = bot�es[i];

                clicado.Click();
            }
        }

        /// <summary>
        /// Ocorre ao redimensionar, redesenhando controle.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AjustarTamanhos();
            Invalidate();
        }
    }
}
		