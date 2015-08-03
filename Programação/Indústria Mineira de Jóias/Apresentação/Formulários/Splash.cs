using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Summary description for Splash.
	/// </summary>
	public sealed class Splash : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDesenvolvidoPor;
        private Label lblMensagem;
        private Label lblVers�o;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private static DateTime DataCompila��o()
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

            DateTime dataCompila��o = DataCompila��o();
            //dataCompila��o = dataCompila��o.AddDays(-500);

            TimeSpan diff = DateTime.Now.Date - dataCompila��o;
            int dias = (int) diff.TotalDays;

            //lblVers�o.Text = "Vers�o lan�ada " +
            //    (dias == 0 ? "hoje " : (dias == 1 ? "ontem " : "h� " + dias.ToString() + " dias"));

            //lblVers�o.Text += " (" + DateTime.Now.ToLongDateString() + ") ";

            //lblHoje.Text = DateTime.Now.ToLongDateString();

            if (dias == 0)
                lblVers�o.Text = "Compilado hoje";
            else if (dias == 1)
                lblVers�o.Text = "Compilado ontem";
            else if (dias <= 7)
                lblVers�o.Text = "Compilado h� " + dias.ToString() + " dias";
            else
                lblVers�o.Text = "Compilado em " + dataCompila��o.ToLongDateString();

            Application.DoEvents();
        }

        public void MostrarCarregandoVers�o()
        {
            lblVers�o.Text = "Verificando se existe nova vers�o";
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
            this.lblVers�o = new System.Windows.Forms.Label();
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
            // lblVers�o
            // 
            this.lblVers�o.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVers�o.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblVers�o.Location = new System.Drawing.Point(33, 9);
            this.lblVers�o.Name = "lblVers�o";
            this.lblVers�o.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVers�o.Size = new System.Drawing.Size(401, 20);
            this.lblVers�o.TabIndex = 7;
            this.lblVers�o.Text = ",";
            // 
            // Splash
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 262);
            this.ControlBox = false;
            this.Controls.Add(this.lblVers�o);
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

                //if (!j�Verificado)
                //{
                //    VerificarVers�o();
                //}
			}
		}

        //private bool j�Verificado = false;

        //private void VerificarVers�o()
        //{
        //    if (Acesso.Comum.Usu�rios.Usu�rioAtual != null)
        //    {
        //        Entidades.Configura��o.DadosGlobais.Inst�ncia.�ltimoLogInUsu�rio = DateTime.Now;

        //        if (Vers�oAntiga())
        //        {
        //            lblVers�o.ForeColor = Color.Red;
        //            lblVers�o.Font = new Font(lblVers�o.Font, FontStyle.Bold);

        //            //lblInfoVers�oDesatualizada.Visible = true;
        //            //lblDesenvolvidoPor.Visible = false;
        //            lblMensagem.Visible = false;
        //        }
        //        else 
        //        {
        //            Entidades.Configura��o.DadosGlobais.Inst�ncia.�ltimaVers�o = Application.ProductVersion;
        //        }

        //        j�Verificado = true;
        //    }
        //}

        ///// <summary>
        ///// Verifica se essa vers�o � antiga.
        ///// </summary>
        ///// <returns></returns>
        //private bool Vers�oAntiga()
        //{
        //    //string minha = Application.ProductVersion;
        //    //string cadastrada = Entidades.Configura��o.DadosGlobais.Inst�ncia.�ltimaVers�o;
            
        //    //string [] minhasPicada = minha.Split('.');
        //    //string [] cadastradaPicada = cadastrada.Split('.');

        //    //if (minhasPicada.Length != cadastradaPicada.Length)
        //    //    throw new Exception("Falha ao verificar vers�o: Minha: " + minha + " Cadastrada: " + cadastrada);

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
