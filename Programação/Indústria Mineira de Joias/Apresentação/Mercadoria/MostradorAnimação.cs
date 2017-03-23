using Entidades.Álbum;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/* Usar timer ao invés de Thread não dá certo. Porquê ?
 * porque a exibição de animação pode ser chamada
 * pela thread do quadrofoto, que dorme logo em seguida.
 * Assim, o timer também dorme, e a animação não funciona.
 */

namespace Apresentação.Mercadoria
{
    /// <summary>
    /// Este controle serve para mostrar uma animação.
    /// </summary>
    public partial class MostradorAnimação : PictureBox
	{
		private const int				intervalo = 1000;
		
		// Intervalo para exibição das fotos, em milisegundos
		private volatile Animação animação;
		private volatile int quadroAtual = 0;

		// Thread
		private Thread						thread; 
		private volatile bool				animar;
        private bool                        mostrandoLogo = true;

		public MostradorAnimação()
		{
			InitializeComponent();

            this.SizeMode = PictureBoxSizeMode.Zoom;
		}

        private void CriarThread()
        {
            if (animação is AnimaçãoOca)
            {
                if (((AnimaçãoOca)animação).Carregado && animação.Imagens.Count <= 1)
                {
                    MostrarPróximoQuadro();
                    return;
                }
            }
            else if (animação == null || animação.Imagens.Count <= 1)
            {
                MostrarPróximoQuadro();
                return;
            }

            // Prepara a thread.
            thread = new Thread(new ThreadStart(LoopThread));
            thread.Name = "MostradorAnimação - thread";
            thread.IsBackground = true;
            //thread.Priority = ThreadPriority.Lowest;
            thread.Start();
        }
		
		protected override void Dispose( bool disposing )
		{
			base.Dispose(disposing);
			
			// Desliga a thread
            animar = false;
            animação = null;
		}
	

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MostradorAnimação
            // 
            this.Image = global::Apresentação.Resource.logo;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Métodos Públicos

        /// <summary>
        /// Inicia animação de mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria cuja animação será exibida.</param>
        /// <remarks>
        /// Verifica se a mercadoria já possui a animação carregada.
        /// Caso contrário, carrega em segundo plano.
        /// </remarks>
        public bool MostrarAnimação(Entidades.Mercadoria.Mercadoria mercadoria)
        {
#if DEBUG
            if (animação != null)
                Console.WriteLine("Mostrando animação: {0}", animação.ToString());
#endif
            if (mercadoria.FotoObtida)
            {
                MostrarAnimação(mercadoria.Animação);
                return true;
            }
            else
            {
                this.animação = new AnimaçãoOca(mercadoria);

                animar = true;

                if (thread == null)
                    CriarThread();
                else
                    InterromperThread();

                return false;
            }
        }
		
		/// <summary>
		/// Inicia uma animação.
		/// Chame PausarAnimação() para pausar.
		/// </summary>
		/// <param name="animação">Animação da mercadoria</param>
		public void MostrarAnimação(Animação animação)
		{
#if DEBUG
            if (animação != null)
                Console.WriteLine("Mostrando animação: {0}", animação.ToString());
#endif

			this.animação = animação;
			animar = true;

            if (animação == null || animação.Carregado && animação.Imagens.Count <= 1)
                MostrarPróximoQuadro();
            else
            {
                if (thread == null)
                    CriarThread();
                else
                    InterromperThread();
            }
        }

		/// <summary>
		/// Pausa a animação, mas imagem continua sendo mostrada.
		/// Chame ContinuarAnimação() para retomar.
		/// </summary>
		public void PausarAnimação()
		{
#if DEBUG
            if (animação != null)
                Console.WriteLine("Pausando animação: {0}", animação.ToString());
#endif

            animar = false;
			InterromperThread();
		}
		
		/// <summary>
		/// Continua a mostrar uma animação pausada anteriormente.
		/// </summary>
		public void ContinuarAnimação()
		{
#if DEBUG
            if (animação != null)
                Console.WriteLine("Continuando animação: {0}", animação.ToString());
#endif

            animar = true;

            if (thread == null)
                CriarThread();
            else
                InterromperThread();
        }

        private delegate void MostrarImagemCallback(Image imagem);

		/// <summary>
		/// Pausa alguma animação existente
		/// e mostra a imagem
		/// </summary>
		/// <param name="imagem"></param>
		public void MostrarImagem(Image imagem)
		{
            if (this.InvokeRequired)
            {
                MostrarImagemCallback método = new MostrarImagemCallback(MostrarImagem);
                
                this.BeginInvoke(método, imagem);
            }
            else
            {
                PausarAnimação();
                this.Image = imagem;
            }
		}

		#endregion

        private delegate void MostrarPróximoQuadroCallback();

		private void MostrarPróximoQuadro()
		{
            if (InvokeRequired)
            {
                MostrarPróximoQuadroCallback método = new MostrarPróximoQuadroCallback(MostrarPróximoQuadro);
                BeginInvoke(método);
            }
            else if (animação != null && !InvokeRequired && animação.Imagens.Count > 0)
			{
				quadroAtual %= animação.Imagens.Count;

				this.Image = (Image) animação.Imagens[quadroAtual];
                BackColor = new Bitmap(Image).GetPixel(0, 0);
                mostrandoLogo = false;

				quadroAtual++;
			}
            else if (!InvokeRequired && !mostrandoLogo)
            {
                MostrarImagem(Resource.logo);
                mostrandoLogo = true;
            }
		}
		
		
		/// <summary>
		/// Interrompe a thread com segurança.
		/// </summary>
		private void InterromperThread()
		{
            if (thread == null)
                return;

            try
            {
                thread.Interrupt();
            }
            catch { }
		}

		private void LoopThread()
		{
            bool repetir = false;

            try
            {
                do
                {
                    try
                    {
                        MostrarPróximoQuadro();

                        Thread.Sleep(intervalo);
                    }
                    catch (ThreadInterruptedException)
                    {
                        repetir = true;
                    }
                } while (thread != null && animar && (repetir || (animação != null && (!animação.Carregado || animação.Imagens.Count > 1))));

                if (thread != null && animação is AnimaçãoOca)
                    MostrarPróximoQuadro();
            }
            catch { }
            finally
            {
                thread = null;
            }
		}

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible && thread == null)
            {
                animar = true;
                CriarThread();
            }
            else if (!Visible && thread != null)
                animar = false;
        }
	}
}
