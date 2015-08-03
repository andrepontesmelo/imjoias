using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.�lbum;

namespace Apresenta��o.Mercadoria
{
	public class QuadroFoto : Apresenta��o.Formul�rios.Quadro
	{
		private MostradorAnima��o picFoto;
		private System.ComponentModel.IContainer components = null;
		
		// Atributos
		private bool reportarErros;	// Escolha do usu�rio
        private OrigemFoto origem = OrigemFoto.FazerNada;
        private Entidades.Mercadoria.Mercadoria mercadoria = null; //Mercadoria cuja foto ser� mostrada

		/// <summary>
		/// Origem indica de onde a thread ir� obter a foto.
		/// </summary>
		private enum OrigemFoto { EntidadeMercadoria, LogoIMJ, FazerNada };		

        ///// <summary>
        ///// Permite que o usu�rio reporte erros sobre a foto
        ///// </summary>
        //[Description("Permite que o usu�rio reporte um erro referente � foto mostrada atualmente.")]
        //[Browsable(true)]
        //public bool ReportarErros
        //{
        //    get { return reportarErros; }
        //    set 
        //    { 
        //        reportarErros = value;
        //        lnkReportar.Visible = value;
        //    }	
        //}

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
            this.picFoto = new Apresenta��o.Mercadoria.MostradorAnima��o();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picFoto.Image = global::Apresenta��o.Mercadoria.Properties.Resources.logo;
            this.picFoto.Location = new System.Drawing.Point(0, 27);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(597, 441);
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

		private void lnkReportar_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			RelatarProblemaFoto janela;
			DialogResult resultado;

			string refer�nciaNum�rica = �ltimaRefer�nciaMostrada();

			if (refer�nciaNum�rica == null) 
			{
				MessageBox.Show(this, "N�o existe foto de mercadoria sendo mostrada", "N�o � poss�vel registrar erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);	
				return;
			}
			
			janela = new RelatarProblemaFoto(picFoto.Image);
			resultado = janela.ShowDialog(this);
			
			if (resultado == DialogResult.Cancel)
			{
				MessageBox.Show(this, "O relat�rio de erros n�o foi preenchido", "Processo cancelado pelo usu�rio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		
			new Entidades.�lbum.ProblemaFoto(refer�nciaNum�rica, janela.Descri��o).Cadastrar();
			MessageBox.Show(this, "Obrigado por contribuir no aperfei�oamento do �lbum", "Mensagem registrada", MessageBoxButtons.OK, MessageBoxIcon.Information );

			janela.Dispose();
		}

		
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

                picFoto.MostrarAnima��o(mercadoria);
            }
		}

        public void MostrarFoto(Foto foto)
        {
            picFoto.MostrarImagem(foto.Imagem);
        }

        /// <summary>
		/// Mostra o logo, imagem j� pre-estabelecida no picFoto.Image.
		/// </summary>
		/// <remarks> S� deve ser chamada externamente � classe QuadroFoto</remarks>
		public void MostrarLogoIMJ()
		{
            origem = OrigemFoto.LogoIMJ;
            picFoto.MostrarImagem(Properties.Resources.logo);
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