using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Entidades.Privilégio;
using System.Drawing.Imaging;

namespace Apresentação.Formulários
{	
	/// <summary>
	/// Botão para seleção de ambiente do sistema em
	/// que o usuário irá trabalhar.
    /// Cada botão conheçe um controlador. Este é atribuído externamente. 
    /// Caso não seja atribuído, um novo controlador é gerado.
    /// O botão tambem tem a propriedade privilégio, 
    /// em que ele será exibido apenas se o usuário tiver aquele previlégio.
	/// </summary>
	/// 
	/// <remarks>
	/// O botão, ao clicado, solicita ao controlador
	/// (<see cref="ControladorBaseInferior"/>)
	/// que substitua a base inferior do formulário
	/// (<see cref="BaseFormulário"/>.
	/// </remarks>
	public class Botão : IDisposable
	{
        public const float TamanhoFiguraMáximo = 67f;

        /// <summary>
        /// Controlador de exibição de base inferior.
        /// </summary>
		private ControladorBaseInferior controlador;

        /// <summary>
        /// Determina se ao ser clicado deve mostrar a primeira
        /// base inferior novamente ou a última exibida.
        /// </summary>
		private bool retornarÀPrimeira = false;

        /// <summary>
        /// Privilégios necessários para exibição do botão.
        /// </summary>
        private Permissão privilégio = Permissão.Nenhuma;
        
        /// <summary>
        /// Imagem a ser exibida.
        /// </summary>
        private Image imagem;

        /// <summary>
        /// Texto a ser exibido.
        /// </summary>
        private string texto;

        /// <summary>
        /// Tamanho do botão.
        /// </summary>
        private SizeF tamanho = new SizeF(57, 57);

        private PointF posição = new PointF(0f, 0f);

        /// <summary>
        /// Interesse do usuário no botão.
        /// </summary>
        private double doi = 0.0;

        /// <summary>
        /// Formulário.
        /// </summary>
        private BaseFormulário baseFormulário;

        private int ordenação;

        public delegate void ModificadoCallback(Botão botão);
        public event ModificadoCallback Modificado;

        #region Propriedades

        public int Ordenação { get { return ordenação; } set { ordenação = value; } }

        internal BaseFormulário BaseFormulário { get { return baseFormulário; } set { baseFormulário = value; } }

        [DefaultValue(57f), Browsable(false), ReadOnly(true)]
        internal float Width { get { return tamanho.Width; } set { tamanho.Width = value; } }
        
        [DefaultValue(57f), Browsable(false), ReadOnly(true)]
        internal float Height { get { return tamanho.Height; } set { tamanho.Height = value; } }
        
        [DefaultValue(0f), Browsable(false), ReadOnly(true)]
        internal float Left { get { return posição.X; } set { posição.X = value; } }

        [DefaultValue(0f), Browsable(false), ReadOnly(true)]
        internal float Top { get { return posição.Y; } set { posição.Y = value; } }

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
                    Controlador = ConstruirControladorPadrão();

                return controlador;
            }
            set
            {
                if (controlador != null)
                    throw new Exception("Controlador já atribuído anteriormente!");

                controlador = value;

                if (value != null)
                {
                    controlador.Formulário = baseFormulário;
                    controlador.DefinirBotão(this);
                    controlador.RetornarÀPrimeira = retornarÀPrimeira;
                }
            }
        }

        /// <summary>
        /// Determina se ao esconder o controle exibirá
        /// da próxima vez a primeira base inferior inserida
        /// no controlador.
        /// </summary>
        [DefaultValue(false), Browsable(true),
        Description("Determina se ao esconder o controle exibirá da próxima vez a primeira base inferior inserida no controlador.")]
        public bool RetornarÀPrimeira
        {
            get { return controlador == null ? retornarÀPrimeira : Controlador.RetornarÀPrimeira; }
            set
            {
                if (controlador == null)
                    retornarÀPrimeira = value;
                else
                    Controlador.RetornarÀPrimeira = retornarÀPrimeira = value;
            }
        }

        /// <summary>
        /// Privilégios necessários para mostrar o botão.
        /// </summary>
        [DefaultValue(Permissão.Nenhuma)]
        public Permissão Privilégios
        {
            get { return privilégio; }
            set { privilégio = value; }
        }

        /// <summary>
        /// Imagem do botoão.
        /// </summary>
        [DefaultValue(null)]
        public Image Imagem
        {
            get { return imagem; }
            set { imagem = value; if (Modificado != null) Modificado(this); }
        }

        /// <summary>
        /// Texto do botão.
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
		/// Ocorre ao clicar no botão.
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
		/// Constrói um controlador padrão.
		/// </summary>
		/// <returns>Controlador.</returns>
		protected virtual ControladorBaseInferior ConstruirControladorPadrão()
		{
			return new ControladorBaseInferior();
		}

        /// <summary>
        /// Desenha o botão.
        /// </summary>
        public void Desenhar(Graphics g)
        {
            float[][] matrixItems;
            ColorMatrix colorMatrix;
            SizeF tFigura = new SizeF();
            Rectangle pFigura;
            float doi = (float)Math.Abs(this.doi);
            int yFigura;
            
            /* Altura o botão: 57 pixels em tamanho normal,
             * 77 pixels para tamanho máximo.
             */
            tFigura.Height = Math.Min(tamanho.Height, TamanhoFiguraMáximo);
            tFigura.Width = imagem.Width * tFigura.Height / imagem.Height;
            pFigura = new Rectangle(
                (int)Math.Round((tamanho.Width - tFigura.Width) / 2f + posição.X),
                yFigura = (int)Math.Round((TamanhoFiguraMáximo - tFigura.Height) / 2f + posição.Y),
                (int)Math.Round(tFigura.Width),
                (int)Math.Round(tFigura.Height));

            // Atribui transparência para a imagem, conforme doi
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
                            (tamanho.Width - tTexto.Width) / 2 + posição.X,
                            tFigura.Height + yFigura);
                    }
                }
        }
    }
}

