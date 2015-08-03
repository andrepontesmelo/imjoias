using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Barra de botões
	/// </summary>
	public class BarraBotões : UserControl
	{
 		private Botão [] botões = new Botão[0];

        private const float foco = 0.6f;
        private const float zoom = 0.8f;
        private const int margem = 15;

        private bool mouseSobre = false;

		/// <summary>
		/// Constrói uma barra de botões.
		/// </summary>
		public BarraBotões()
		{
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromKnownColor(KnownColor.Transparent);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BarraBotões_MouseMove);
            this.MouseLeave += new System.EventHandler(this.BarraBotões_MouseLeave);
            this.MouseHover += new System.EventHandler(this.BarraBotões_MouseHover);

            Cursor = Cursors.Hand;
        }

		/// <summary>
		/// Botões do formulário
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Botão [] Botões
		{
			get { return botões; }
            set
            {
                botões = value;

                if (!DesignMode)
                    foreach (Botão botão in botões)
                    {
                        botão.BaseFormulário = ParentForm as BaseFormulário;
                        botão.Modificado += new Botão.ModificadoCallback(AoModificarBotão);
                    }

                if (botões != null && botões.Length > 0 && Width > 0)
                    AjustarTamanhos();

                Invalidate();
            }
		}

		/// <summary>
		/// Adiciona um botão à barra de botões.
		/// </summary>
		/// <param name="botão">Botão a ser adicionado.</param>
        public void AdicionarBotão(Botão botão)
        {
            Botão[] anterior = this.botões;
            int i = 0;

            botões = new Botão[anterior.Length + 1];
            anterior.CopyTo(botões, 0);

            while (i < anterior.Length && botão.Ordenação > anterior[i].Ordenação)
                i++;

            for (int j = anterior.Length; j > i; j--)
                botões[j] = botões[j - 1];

            botões[i] = botão;

            if (!DesignMode)
            {
                botão.BaseFormulário = ParentForm as BaseFormulário;
                botão.Modificado += new Botão.ModificadoCallback(AoModificarBotão);
            }

            Invalidate();
        }

        /// <summary>
        /// Remove um botão da barra.
        /// </summary>
        public void RemoverBotão(Botão botão)
        {
            Botão[] anterior = this.botões;
            int i = 0;

            botões = new Botão[anterior.Length - 1];

            foreach (Botão aux in anterior)
                if (aux != botão)
                    botões[i++] = aux;

            Invalidate();
        }

		/// <summary>
		/// Ocorre ao redimensionar um botão.
		/// </summary>
		private void AoModificarBotão(Botão botão)
		{
            Invalidate();
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            foreach (Botão botão in botões)
                botão.Dispose();
        }

        #region Extraído do exemplo HyperBar do Microsoft Expression

        private double FunçãoHiperbólica(double x, double zoom, double variance)
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
            double[] tamanhos = new double[botões.Length];
            double soma = 0;
            int posx = 0;

            // Whenever the mouse pointer moves within the HyperBar Grid, the user is effectively
            // indicating an adjustment in her degree of interest (DOI). Recalculate the size of each column
            // in respect to the new DOI.

            for (int i = 0; i < botões.Length; ++i)
            {
                double distanceFromDOI = ColumnDistanceFromDOI(i, botões.Length);

                // Plug the distance from zero (the DOI itself is at zero) into the hyperbolic function.
                double hyperbolic = FunçãoHiperbólica(distanceFromDOI, zoom, foco);

                // Use Grid 'star-sizing' to set the Width of each column as a weighted proportion of available space.
                // The hyperbolic function returns a value in the range (0,1) which needs to be scaled to the actual
                // height of the HyperBar Grid.
                tamanhos[i] = hyperbolic;
                soma += hyperbolic;

                botões[i].DOI = distanceFromDOI;
            }

            for (int i = 0; i < botões.Length; i++)
            {
                botões[i].Width = (float)Math.Round(tamanhos[i] / soma * (ClientSize.Width - 6 * botões.Length - margem));
                botões[i].Height = (float)Math.Round(tamanhos[i] * Botão.TamanhoFiguraMáximo);
                botões[i].Left = posx;

                posx += (int)Math.Round(botões[i].Width) + 6;
            }

            Invalidate();
        }

        #endregion

        /// <summary>
        /// Ocorre ao colocar o mouse sobre a barra.
        /// </summary>
        private void BarraBotões_MouseHover(object sender, EventArgs e)
        {
            mouseSobre = true;
        }

        /// <summary>
        /// Ocorre ao retirar o mouse da barra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarraBotões_MouseLeave(object sender, EventArgs e)
        {
            mouseSobre = false;
            AjustarTamanhos();
        }

        /// <summary>
        /// Ocorre ao mover o mouse sobre a barra de botões.
        /// </summary>
        private void BarraBotões_MouseMove(object sender, MouseEventArgs e)
        {
            mouseSobre = true;
            AjustarTamanhos();
        }

        /// <summary>
        /// Ocorre ao desenhar, repassando a tarefa para cada botão.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (Botão botão in botões)
                botão.Desenhar(e.Graphics);
        }

        /// <summary>
        /// Ocorer ao clicar, disparando chamada no botão correspondente.
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            Botão clicado;

            base.OnClick(e);

            if (Enabled)
            {
                clicado = botões[0];

                for (int i = 1; i < botões.Length; i++)
                    if (Math.Abs(botões[i].DOI) < Math.Abs(clicado.DOI))
                        clicado = botões[i];

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
		