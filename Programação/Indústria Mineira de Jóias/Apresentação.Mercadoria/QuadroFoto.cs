using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Álbum;

namespace Apresentação.Mercadoria
{
	public class QuadroFoto : Apresentação.Formulários.Quadro
	{
		private MostradorAnimação picFoto;
		private System.ComponentModel.IContainer components = null;
		
		// Atributos
		private bool reportarErros;	// Escolha do usuário
        private OrigemFoto origem = OrigemFoto.FazerNada;
        private Entidades.Mercadoria.Mercadoria mercadoria = null; //Mercadoria cuja foto será mostrada

		/// <summary>
		/// Origem indica de onde a thread irá obter a foto.
		/// </summary>
		private enum OrigemFoto { EntidadeMercadoria, LogoIMJ, FazerNada };		

        ///// <summary>
        ///// Permite que o usuário reporte erros sobre a foto
        ///// </summary>
        //[Description("Permite que o usuário reporte um erro referente à foto mostrada atualmente.")]
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
            this.picFoto = new Apresentação.Mercadoria.MostradorAnimação();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picFoto.Image = global::Apresentação.Mercadoria.Properties.Resources.logo;
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
            this.Título = "Mercadoria";
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

			string referênciaNumérica = ÚltimaReferênciaMostrada();

			if (referênciaNumérica == null) 
			{
				MessageBox.Show(this, "Não existe foto de mercadoria sendo mostrada", "Não é possível registrar erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);	
				return;
			}
			
			janela = new RelatarProblemaFoto(picFoto.Image);
			resultado = janela.ShowDialog(this);
			
			if (resultado == DialogResult.Cancel)
			{
				MessageBox.Show(this, "O relatório de erros não foi preenchido", "Processo cancelado pelo usuário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		
			new Entidades.Álbum.ProblemaFoto(referênciaNumérica, janela.Descrição).Cadastrar();
			MessageBox.Show(this, "Obrigado por contribuir no aperfeiçoamento do álbum", "Mensagem registrada", MessageBoxButtons.OK, MessageBoxIcon.Information );

			janela.Dispose();
		}

		
		/// <summary>
		/// Caso a imagem mostrada não seja foto de mercadoria,
		/// nulo é retornado. Caso contrário retorna-se a referência não formatada.
		/// </summary>
		/// <returns></returns>
		private string ÚltimaReferênciaMostrada()
		{
			switch (origem)
			{
				case OrigemFoto.FazerNada:
					return null;
			
				case OrigemFoto.LogoIMJ:
					return null;

				case OrigemFoto.EntidadeMercadoria:
					return mercadoria.ReferênciaNumérica;

				default:
					return null;
			}
		}

		/// <summary>
		/// Caso mercadoria seja nula, uma exceção é gerada.
		/// </summary>
		/// <param name="mercadoria">para obter foto dela</param>
		public void MostrarFoto(Entidades.Mercadoria.Mercadoria mercadoria)
		{
            if (mercadoria == null)
                MostrarLogoIMJ();

            // Pode ser que a foto já foi mostrada.
            else if (mercadoria.ReferênciaNumérica != ÚltimaReferênciaMostrada())
            {
                this.origem = OrigemFoto.EntidadeMercadoria;
                this.mercadoria = mercadoria;

                picFoto.MostrarAnimação(mercadoria);
            }
		}

        public void MostrarFoto(Foto foto)
        {
            picFoto.MostrarImagem(foto.Imagem);
        }

        /// <summary>
		/// Mostra o logo, imagem já pre-estabelecida no picFoto.Image.
		/// </summary>
		/// <remarks> Só deve ser chamada externamente à classe QuadroFoto</remarks>
		public void MostrarLogoIMJ()
		{
            origem = OrigemFoto.LogoIMJ;
            picFoto.MostrarImagem(Properties.Resources.logo);
		}

		/// <summary>
		/// Verifica se a logotipo está sendo exibida.
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