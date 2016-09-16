using System;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
    public sealed class Aguarde : JanelaExplicativa
	{
        private DateTime �ltimoEvento = DateTime.Now;

		private ProgressBar progresso;
		private Label lblA��o;
		private System.ComponentModel.IContainer components = null;

		public Aguarde(string a��o, int a��es)
		{
			InitializeComponent();

			lblA��o.Text = a��o;
			progresso.Maximum = a��es;
		}

		public Aguarde(string a��o, int a��es, string t�tulo, string descri��o)
		{
			InitializeComponent();

			lblA��o.Text = a��o;
			progresso.Maximum = a��es;

			lblT�tulo.Text = t�tulo;
			lblDescri��o.Text = descri��o;
		}

        public void Abrir()
        {
            Show();
            Update();

            Application.DoEvents();
        }

		public void Passo(string a��o)
		{
			lblA��o.Text = a��o;
			progresso.PerformStep();

            Application.DoEvents();
		}

        public void Passos(int valor)
        {
            progresso.Value = valor;

            Application.DoEvents();
        }

        public void Passo()
		{
            TimeSpan dif = DateTime.Now - �ltimoEvento;

            progresso.PerformStep();

            if (dif.TotalSeconds > 10)
            {
                Application.DoEvents();
                �ltimoEvento = DateTime.Now;
            }
		}

		protected override void Dispose( bool disposing )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aguarde));
            this.lblA��o = new System.Windows.Forms.Label();
            this.progresso = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(92, 20);
            this.lblT�tulo.Text = "Aguarde...";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Por favor, aguarde enquanto o sistema processa dados.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // lblA��o
            // 
            this.lblA��o.Location = new System.Drawing.Point(24, 96);
            this.lblA��o.Name = "lblA��o";
            this.lblA��o.Size = new System.Drawing.Size(344, 32);
            this.lblA��o.TabIndex = 3;
            this.lblA��o.Text = "Processando dados...";
            this.lblA��o.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // progresso
            // 
            this.progresso.Location = new System.Drawing.Point(24, 128);
            this.progresso.Maximum = 1;
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(344, 16);
            this.progresso.Step = 1;
            this.progresso.TabIndex = 4;
            // 
            // Aguarde
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 168);
            this.Controls.Add(this.progresso);
            this.Controls.Add(this.lblA��o);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "Aguarde";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aguarde...";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.lblA��o, 0);
            this.Controls.SetChildIndex(this.progresso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}

