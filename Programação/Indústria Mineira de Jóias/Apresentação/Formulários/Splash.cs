using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Summary description for Splash.
	/// </summary>
	public sealed class Splash : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDesenvolvidoPor;
        private Label lblMensagem;
        private Label lblVersão;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private static DateTime DataCompilação()
        {

            DateTime resultado = new DateTime(2000, 1, 1);

            System.Version v =
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;


            resultado = resultado.AddDays(v.Build);
            resultado.AddSeconds(v.Revision * 2);

            if (TimeZone.IsDaylightSavingTime(DateTime.Now, TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Now.Year)))
                resultado = resultado.AddHours(1);

            return resultado;
        }

        public Splash()
        {
            System.Windows.Forms.Cursor.Current = Cursors.AppStarting;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            DateTime dataCompilação = DataCompilação();
            //dataCompilação = dataCompilação.AddDays(-500);

            TimeSpan diff = DateTime.Now.Date - dataCompilação;
            int dias = (int) diff.TotalDays;

            //lblVersão.Text = "Versão lançada " +
            //    (dias == 0 ? "hoje " : (dias == 1 ? "ontem " : "há " + dias.ToString() + " dias"));

            //lblVersão.Text += " (" + DateTime.Now.ToLongDateString() + ") ";

            //lblHoje.Text = DateTime.Now.ToLongDateString();

            if (dias == 0)
                lblVersão.Text = "Compilado hoje";
            else if (dias == 1)
                lblVersão.Text = "Compilado ontem";
            else if (dias <= 7)
                lblVersão.Text = "Compilado há " + dias.ToString() + " dias";
            else
                lblVersão.Text = "Compilado em " + dataCompilação.ToLongDateString();

            Application.DoEvents();
        }

        public void MostrarCarregandoVersão()
        {
            lblVersão.Text = "Verificando se existe nova versão";
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDesenvolvidoPor = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblVersão = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblDesenvolvidoPor
            // 
            this.lblDesenvolvidoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesenvolvidoPor.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesenvolvidoPor.ForeColor = System.Drawing.Color.Black;
            this.lblDesenvolvidoPor.Location = new System.Drawing.Point(277, 225);
            this.lblDesenvolvidoPor.Name = "lblDesenvolvidoPor";
            this.lblDesenvolvidoPor.Size = new System.Drawing.Size(154, 31);
            this.lblDesenvolvidoPor.TabIndex = 1;
            this.lblDesenvolvidoPor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblMensagem.Location = new System.Drawing.Point(8, 231);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(263, 24);
            this.lblMensagem.TabIndex = 2;
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblVersão
            // 
            this.lblVersão.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersão.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblVersão.Location = new System.Drawing.Point(33, 9);
            this.lblVersão.Name = "lblVersão";
            this.lblVersão.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVersão.Size = new System.Drawing.Size(401, 20);
            this.lblVersão.TabIndex = 7;
            this.lblVersão.Text = ",";
            // 
            // Splash
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 262);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersão);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.lblDesenvolvidoPor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closed += new System.EventHandler(this.Splash_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Splash_Closed(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

		public string Mensagem
		{
			get { return lblMensagem.Text; }
			set
			{
				lblMensagem.Text = value;
				lblMensagem.Refresh();
                Application.DoEvents();

                //if (!jáVerificado)
                //{
                //    VerificarVersão();
                //}
			}
		}

        //private bool jáVerificado = false;

        //private void VerificarVersão()
        //{
        //    if (Acesso.Comum.Usuários.UsuárioAtual != null)
        //    {
        //        Entidades.Configuração.DadosGlobais.Instância.ÚltimoLogInUsuário = DateTime.Now;

        //        if (VersãoAntiga())
        //        {
        //            lblVersão.ForeColor = Color.Red;
        //            lblVersão.Font = new Font(lblVersão.Font, FontStyle.Bold);

        //            //lblInfoVersãoDesatualizada.Visible = true;
        //            //lblDesenvolvidoPor.Visible = false;
        //            lblMensagem.Visible = false;
        //        }
        //        else 
        //        {
        //            Entidades.Configuração.DadosGlobais.Instância.ÚltimaVersão = Application.ProductVersion;
        //        }

        //        jáVerificado = true;
        //    }
        //}

        ///// <summary>
        ///// Verifica se essa versão é antiga.
        ///// </summary>
        ///// <returns></returns>
        //private bool VersãoAntiga()
        //{
        //    //string minha = Application.ProductVersion;
        //    //string cadastrada = Entidades.Configuração.DadosGlobais.Instância.ÚltimaVersão;
            
        //    //string [] minhasPicada = minha.Split('.');
        //    //string [] cadastradaPicada = cadastrada.Split('.');

        //    //if (minhasPicada.Length != cadastradaPicada.Length)
        //    //    throw new Exception("Falha ao verificar versão: Minha: " + minha + " Cadastrada: " + cadastrada);

        //    //for (int x = 0; x < minhasPicada.Length; x++)
        //    //{
        //    //    int minhaInt;
        //    //    int cadastradaInt;

        //    //    int.TryParse(minhasPicada[x], out minhaInt);
        //    //    int.TryParse(cadastradaPicada[x], out cadastradaInt);

        //    //    if (minhaInt < cadastradaInt)
        //    //        return true;
        //    //    else if (minhaInt > cadastradaInt)
        //    //        return false;
        //    //}

        //    return false;
        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
