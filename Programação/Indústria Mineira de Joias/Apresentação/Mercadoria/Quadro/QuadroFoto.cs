using Entidades.�lbum;
using System;

namespace Apresenta��o.Mercadoria
{
    public class QuadroFoto : Apresenta��o.Formul�rios.Quadro
	{
		private Mostrador picFoto;
		private System.ComponentModel.IContainer components = null;
		
		// Atributos
        private OrigemFoto origem = OrigemFoto.FazerNada;
        private Entidades.Mercadoria.Mercadoria mercadoria = null; //Mercadoria cuja foto ser� mostrada

		/// <summary>
		/// Origem indica de onde a thread ir� obter a foto.
		/// </summary>
		private enum OrigemFoto { EntidadeMercadoria, LogoIMJ, FazerNada };		

		public QuadroFoto()
		{	
			InitializeComponent(); 
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.picFoto = new Apresenta��o.Mercadoria.Mostrador();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFoto.Image = global::Apresenta��o.Resource.logo;
            this.picFoto.Location = new System.Drawing.Point(0, 22);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(597, 446);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 2;
            this.picFoto.TabStop = false;
            // 
            // QuadroFoto
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.Controls.Add(this.picFoto);
            this.Name = "QuadroFoto";
            this.Size = new System.Drawing.Size(597, 468);
            this.T�tulo = "Mercadoria";
            this.Load += new System.EventHandler(this.QuadroFoto_Load);
            this.Controls.SetChildIndex(this.picFoto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
		/// <summary>
		/// Caso a imagem mostrada n�o seja foto de mercadoria,
		/// nulo � retornado. Caso contr�rio retorna-se a refer�ncia n�o formatada.
		/// </summary>
		/// <returns></returns>
		private string �ltimaRefer�nciaMostrada()
		{
			switch (origem)
			{
				case OrigemFoto.FazerNada:
					return null;
			
				case OrigemFoto.LogoIMJ:
					return null;

				case OrigemFoto.EntidadeMercadoria:
					return mercadoria.Refer�nciaNum�rica;

				default:
					return null;
			}
		}

		/// <summary>
		/// Caso mercadoria seja nula, uma exce��o � gerada.
		/// </summary>
		/// <param name="mercadoria">para obter foto dela</param>
		public void MostrarFoto(Entidades.Mercadoria.Mercadoria mercadoria)
		{
            if (mercadoria == null)
                MostrarLogoIMJ();

            // Pode ser que a foto j� foi mostrada.
            else if (mercadoria.Refer�nciaNum�rica != �ltimaRefer�nciaMostrada())
            {
                this.origem = OrigemFoto.EntidadeMercadoria;
                this.mercadoria = mercadoria;

                picFoto.Mostrar(mercadoria);
            }
		}

        public void MostrarFoto(Foto foto)
        {
            picFoto.MostrarImagem(foto.Imagem);
        }

		public void MostrarLogoIMJ()
		{
            picFoto.Mostrar(null);
		}

		/// <summary>
		/// Verifica se a logotipo est� sendo exibida.
		/// </summary>
		public bool MostrandoLogo
		{
			get { return origem == OrigemFoto.LogoIMJ; }
		}

        private void QuadroFoto_Load(object sender, EventArgs e)
        {
            MostrarLogoIMJ();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
	}
}