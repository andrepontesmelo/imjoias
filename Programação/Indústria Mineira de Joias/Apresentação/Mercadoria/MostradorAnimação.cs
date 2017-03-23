using Entidades.�lbum;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/* Usar timer ao inv�s de Thread n�o d� certo. Porqu� ?
 * porque a exibi��o de anima��o pode ser chamada
 * pela thread do quadrofoto, que dorme logo em seguida.
 * Assim, o timer tamb�m dorme, e a anima��o n�o funciona.
 */

namespace Apresenta��o.Mercadoria
{
    /// <summary>
    /// Este controle serve para mostrar uma anima��o.
    /// </summary>
    public partial class MostradorAnima��o : PictureBox
	{
		private const int				intervalo = 1000;
		
		// Intervalo para exibi��o das fotos, em milisegundos
		private volatile Anima��o anima��o;
		private volatile int quadroAtual = 0;

		// Thread
		private Thread						thread; 
		private volatile bool				animar;
        private bool                        mostrandoLogo = true;

		public MostradorAnima��o()
		{
			InitializeComponent();

            this.SizeMode = PictureBoxSizeMode.Zoom;
		}

        private void CriarThread()
        {
            if (anima��o is Anima��oOca)
            {
                if (((Anima��oOca)anima��o).Carregado && anima��o.Imagens.Count <= 1)
                {
                    MostrarPr�ximoQuadro();
                    return;
                }
            }
            else if (anima��o == null || anima��o.Imagens.Count <= 1)
            {
                MostrarPr�ximoQuadro();
                return;
            }

            // Prepara a thread.
            thread = new Thread(new ThreadStart(LoopThread));
            thread.Name = "MostradorAnima��o - thread";
            thread.IsBackground = true;
            //thread.Priority = ThreadPriority.Lowest;
            thread.Start();
        }
		
		protected override void Dispose( bool disposing )
		{
			base.Dispose(disposing);
			
			// Desliga a thread
            animar = false;
            anima��o = null;
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
            // MostradorAnima��o
            // 
            this.Image = global::Apresenta��o.Resource.logo;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region M�todos P�blicos

        /// <summary>
        /// Inicia anima��o de mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria cuja anima��o ser� exibida.</param>
        /// <remarks>
        /// Verifica se a mercadoria j� possui a anima��o carregada.
        /// Caso contr�rio, carrega em segundo plano.
        /// </remarks>
        public bool MostrarAnima��o(Entidades.Mercadoria.Mercadoria mercadoria)
        {
#if DEBUG
            if (anima��o != null)
                Console.WriteLine("Mostrando anima��o: {0}", anima��o.ToString());
#endif
            if (mercadoria.FotoObtida)
            {
                MostrarAnima��o(mercadoria.Anima��o);
                return true;
            }
            else
            {
                this.anima��o = new Anima��oOca(mercadoria);

                animar = true;

                if (thread == null)
                    CriarThread();
                else
                    InterromperThread();

                return false;
            }
        }
		
		/// <summary>
		/// Inicia uma anima��o.
		/// Chame PausarAnima��o() para pausar.
		/// </summary>
		/// <param name="anima��o">Anima��o da mercadoria</param>
		public void MostrarAnima��o(Anima��o anima��o)
		{
#if DEBUG
            if (anima��o != null)
                Console.WriteLine("Mostrando anima��o: {0}", anima��o.ToString());
#endif

			this.anima��o = anima��o;
			animar = true;

            if (anima��o == null || anima��o.Carregado && anima��o.Imagens.Count <= 1)
                MostrarPr�ximoQuadro();
            else
            {
                if (thread == null)
                    CriarThread();
                else
                    InterromperThread();
            }
        }

		/// <summary>
		/// Pausa a anima��o, mas imagem continua sendo mostrada.
		/// Chame ContinuarAnima��o() para retomar.
		/// </summary>
		public void PausarAnima��o()
		{
#if DEBUG
            if (anima��o != null)
                Console.WriteLine("Pausando anima��o: {0}", anima��o.ToString());
#endif

            animar = false;
			InterromperThread();
		}
		
		/// <summary>
		/// Continua a mostrar uma anima��o pausada anteriormente.
		/// </summary>
		public void ContinuarAnima��o()
		{
#if DEBUG
            if (anima��o != null)
                Console.WriteLine("Continuando anima��o: {0}", anima��o.ToString());
#endif

            animar = true;

            if (thread == null)
                CriarThread();
            else
                InterromperThread();
        }

        private delegate void MostrarImagemCallback(Image imagem);

		/// <summary>
		/// Pausa alguma anima��o existente
		/// e mostra a imagem
		/// </summary>
		/// <param name="imagem"></param>
		public void MostrarImagem(Image imagem)
		{
            if (this.InvokeRequired)
            {
                MostrarImagemCallback m�todo = new MostrarImagemCallback(MostrarImagem);
                
                this.BeginInvoke(m�todo, imagem);
            }
            else
            {
                PausarAnima��o();
                this.Image = imagem;
            }
		}

		#endregion

        private delegate void MostrarPr�ximoQuadroCallback();

		private void MostrarPr�ximoQuadro()
		{
            if (InvokeRequired)
            {
                MostrarPr�ximoQuadroCallback m�todo = new MostrarPr�ximoQuadroCallback(MostrarPr�ximoQuadro);
                BeginInvoke(m�todo);
            }
            else if (anima��o != null && !InvokeRequired && anima��o.Imagens.Count > 0)
			{
				quadroAtual %= anima��o.Imagens.Count;

				this.Image = (Image) anima��o.Imagens[quadroAtual];
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
		/// Interrompe a thread com seguran�a.
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
                        MostrarPr�ximoQuadro();

                        Thread.Sleep(intervalo);
                    }
                    catch (ThreadInterruptedException)
                    {
                        repetir = true;
                    }
                } while (thread != null && animar && (repetir || (anima��o != null && (!anima��o.Carregado || anima��o.Imagens.Count > 1))));

                if (thread != null && anima��o is Anima��oOca)
                    MostrarPr�ximoQuadro();
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
