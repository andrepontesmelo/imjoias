using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Entidades.Privil�gio;
using System.Drawing.Imaging;

namespace Apresenta��o.Formul�rios
{	
	/// <summary>
	/// Bot�o para sele��o de ambiente do sistema em
	/// que o usu�rio ir� trabalhar.
    /// Cada bot�o conhe�e um controlador. Este � atribu�do externamente. 
    /// Caso n�o seja atribu�do, um novo controlador � gerado.
    /// O bot�o tambem tem a propriedade privil�gio, 
    /// em que ele ser� exibido apenas se o usu�rio tiver aquele previl�gio.
	/// </summary>
	/// 
	/// <remarks>
	/// O bot�o, ao clicado, solicita ao controlador
	/// (<see cref="ControladorBaseInferior"/>)
	/// que substitua a base inferior do formul�rio
	/// (<see cref="BaseFormul�rio"/>.
	/// </remarks>
	public class Bot�o : IDisposable
	{
        public const float TamanhoFiguraM�ximo = 67f;

        /// <summary>
        /// Controlador de exibi��o de base inferior.
        /// </summary>
		private ControladorBaseInferior controlador;

        /// <summary>
        /// Determina se ao ser clicado deve mostrar a primeira
        /// base inferior novamente ou a �ltima exibida.
        /// </summary>
		private bool retornar�Primeira = false;

        /// <summary>
        /// Privil�gios necess�rios para exibi��o do bot�o.
        /// </summary>
        private Permiss�o privil�gio = Permiss�o.Nenhuma;
        
        /// <summary>
        /// Imagem a ser exibida.
        /// </summary>
        private Image imagem;

        /// <summary>
        /// Texto a ser exibido.
        /// </summary>
        private string texto;

        /// <summary>
        /// Tamanho do bot�o.
        /// </summary>
        private SizeF tamanho = new SizeF(57, 57);

        private PointF posi��o = new PointF(0f, 0f);

        /// <summary>
        /// Interesse do usu�rio no bot�o.
        /// </summary>
        private double doi = 0.0;

        /// <summary>
        /// Formul�rio.
        /// </summary>
        private BaseFormul�rio baseFormul�rio;

        private int ordena��o;

        public delegate void ModificadoCallback(Bot�o bot�o);
        public event ModificadoCallback Modificado;

        #region Propriedades

        public int Ordena��o { get { return ordena��o; } set { ordena��o = value; } }

        internal BaseFormul�rio BaseFormul�rio { get { return baseFormul�rio; } set { baseFormul�rio = value; } }

        [DefaultValue(57f), Browsable(false), ReadOnly(true)]
        internal float Width { get { return tamanho.Width; } set { tamanho.Width = value; } }
        
        [DefaultValue(57f), Browsable(false), ReadOnly(true)]
        internal float Height { get { return tamanho.Height; } set { tamanho.Height = value; } }
        
        [DefaultValue(0f), Browsable(false), ReadOnly(true)]
        internal float Left { get { return posi��o.X; } set { posi��o.X = value; } }

        [DefaultValue(0f), Browsable(false), ReadOnly(true)]
        internal float Top { get { return posi��o.Y; } set { posi��o.Y = value; } }

        [DefaultValue(0.0), Browsable(false), ReadOnly(true)]
        internal double DOI { get { return doi; } set { doi = value; } }

        /// <summary>
        /// Controlador da base inferior.
        /// </summary>
        [Browsable(false), Description("Controlador da base inferior."), DefaultValue(null), ReadOnly(true)]
        public ControladorBaseInferior Controlador
        {
            get
            {
                if (controlador == null)
                    Controlador = ConstruirControladorPadr�o();

                return controlador;
            }
            set
            {
                if (controlador != null)
                    throw new Exception("Controlador j� atribu�do anteriormente!");

                controlador = value;

                if (value != null)
                {
                    controlador.Formul�rio = baseFormul�rio;
                    controlador.DefinirBot�o(this);
                    controlador.Retornar�Primeira = retornar�Primeira;
                }
            }
        }

        /// <summary>
        /// Determina se ao esconder o controle exibir�
        /// da pr�xima vez a primeira base inferior inserida
        /// no controlador.
        /// </summary>
        [DefaultValue(false), Browsable(true),
        Description("Determina se ao esconder o controle exibir� da pr�xima vez a primeira base inferior inserida no controlador.")]
        public bool Retornar�Primeira
        {
            get { return controlador == null ? retornar�Primeira : Controlador.Retornar�Primeira; }
            set
            {
                if (controlador == null)
                    retornar�Primeira = value;
                else
                    Controlador.Retornar�Primeira = retornar�Primeira = value;
            }
        }

        /// <summary>
        /// Privil�gios necess�rios para mostrar o bot�o.
        /// </summary>
        [DefaultValue(Permiss�o.Nenhuma)]
        public Permiss�o Privil�gios
        {
            get { return privil�gio; }
            set { privil�gio = value; }
        }

        /// <summary>
        /// Imagem do boto�o.
        /// </summary>
        [DefaultValue(null)]
        public Image Imagem
        {
            get { return imagem; }
            set { imagem = value; if (Modificado != null) Modificado(this); }
        }

        /// <summary>
        /// Texto do bot�o.
        /// </summary>
        public string Texto
        {
            get { return texto; }
            set { texto = value; if (Modificado != null) Modificado(this);  }
        }

        #endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public void Dispose()
		{
            Controlador.Dispose();
		}

		/// <summary>
		/// Ocorre ao clicar no bot�o.
		/// </summary>
		internal void Click()
		{
			controlador.Exibir();
		}

		/// <summary>
		/// Adiciona base inferior a ser exibida.
		/// </summary>
		/// <param name="baseInferior">Base inferior a ser exibida.</param>
		public void AdicionarBaseInferior(BaseInferior baseInferior)
		{
			Controlador.InserirBaseInferior(baseInferior);
		}

		/// <summary>
		/// Constr�i um controlador padr�o.
		/// </summary>
		/// <returns>Controlador.</returns>
		protected virtual ControladorBaseInferior ConstruirControladorPadr�o()
		{
			return new ControladorBaseInferior();
		}

        /// <summary>
        /// Desenha o bot�o.
        /// </summary>
        public void Desenhar(Graphics g)
        {
            float[][] matrixItems;
            ColorMatrix colorMatrix;
            SizeF tFigura = new SizeF();
            Rectangle pFigura;
            float doi = (float)Math.Abs(this.doi);
            int yFigura;
            
            /* Altura o bot�o: 57 pixels em tamanho normal,
             * 77 pixels para tamanho m�ximo.
             */
            tFigura.Height = Math.Min(tamanho.Height, TamanhoFiguraM�ximo);
            tFigura.Width = imagem.Width * tFigura.Height / imagem.Height;
            pFigura = new Rectangle(
                (int)Math.Round((tamanho.Width - tFigura.Width) / 2f + posi��o.X),
                yFigura = (int)Math.Round((TamanhoFiguraM�ximo - tFigura.Height) / 2f + posi��o.Y),
                (int)Math.Round(tFigura.Width),
                (int)Math.Round(tFigura.Height));

            // Atribui transpar�ncia para a imagem, conforme doi
            matrixItems = new float[][] { 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, 1-doi, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            colorMatrix = new ColorMatrix(matrixItems);

            using (ImageAttributes imageAtt = new ImageAttributes())
            {
                imageAtt.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap);

                g.DrawImage(
                    imagem,
                    pFigura,
                    0, 0, imagem.Width, imagem.Height,
                    GraphicsUnit.Pixel, imageAtt);
            }

            float fAlpha = 8f;

            if (doi < 1f / fAlpha && texto != null)
                using (Font font = new Font(FontFamily.GenericSansSerif, 8.5f * (1-doi), FontStyle.Bold))
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb((int)Math.Round((1-doi * fAlpha) * 255), Color.Black)))
                    {
                        SizeF tTexto = g.MeasureString(texto, font);

                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                        g.DrawString(texto, font, brush,
                            (tamanho.Width - tTexto.Width) / 2 + posi��o.X,
                            tFigura.Height + yFigura);
                    }
                }
        }
    }
}

