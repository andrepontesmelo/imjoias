using System;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public sealed class Aguarde : JanelaExplicativa
	{
        private DateTime últimoEvento = DateTime.Now;

		private ProgressBar progresso;
		private Label lblAção;
		private System.ComponentModel.IContainer components = null;

		public Aguarde(string ação, int ações)
		{
			InitializeComponent();

			lblAção.Text = ação;
			progresso.Maximum = ações;
		}

		public Aguarde(string ação, int ações, string título, string descrição)
		{
			InitializeComponent();

			lblAção.Text = ação;
			progresso.Maximum = ações;

			lblTítulo.Text = título;
			lblDescrição.Text = descrição;
		}

        public void Abrir()
        {
            Show();
            Update();

            Application.DoEvents();
        }

		public void Passo(string ação)
		{
			lblAção.Text = ação;
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
            TimeSpan dif = DateTime.Now - últimoEvento;

            progresso.PerformStep();

            if (dif.TotalSeconds > 10)
            {
                Application.DoEvents();
                últimoEvento = DateTime.Now;
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
            this.lblAção = new System.Windows.Forms.Label();
            this.progresso = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(92, 20);
            this.lblTítulo.Text = "Aguarde...";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Por favor, aguarde enquanto o sistema processa dados.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // lblAção
            // 
            this.lblAção.Location = new System.Drawing.Point(24, 96);
            this.lblAção.Name = "lblAção";
            this.lblAção.Size = new System.Drawing.Size(344, 32);
            this.lblAção.TabIndex = 3;
            this.lblAção.Text = "Processando dados...";
            this.lblAção.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.Controls.Add(this.lblAção);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "Aguarde";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aguarde...";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.lblAção, 0);
            this.Controls.SetChildIndex(this.progresso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}

