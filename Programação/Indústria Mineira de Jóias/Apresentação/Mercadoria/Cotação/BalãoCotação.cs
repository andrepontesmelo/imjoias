using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Cotação
{
	/// <summary>
	/// Balão ilustrado para cotação.
	/// </summary>
	internal class BalãoCotação : Balloon.NET.BalloonWindow
	{
		private bool utilizarTemporizador = true;

		private System.Windows.Forms.PictureBox picCotação;
		private System.Windows.Forms.Label lblTítulo;
		private System.Windows.Forms.Timer timer;
		private System.ComponentModel.IContainer components = null;

		public BalãoCotação()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BalãoCotação));
			this.picCotação = new System.Windows.Forms.PictureBox();
			this.lblTítulo = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// picCotação
			// 
			this.picCotação.Image = ((System.Drawing.Image)(resources.GetObject("picCotação.Image")));
			this.picCotação.Location = new System.Drawing.Point(8, 8);
			this.picCotação.Name = "picCotação";
			this.picCotação.Size = new System.Drawing.Size(24, 24);
			this.picCotação.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCotação.TabIndex = 1;
			this.picCotação.TabStop = false;
			// 
			// lblTítulo
			// 
			this.lblTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTítulo.Location = new System.Drawing.Point(40, 8);
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(248, 24);
			this.lblTítulo.TabIndex = 2;
			this.lblTítulo.Text = "Informativo da Cotação";
			this.lblTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// timer
			// 
			this.timer.Interval = 15000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// BalãoCotação
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 94);
			this.Controls.Add(this.lblTítulo);
			this.Controls.Add(this.picCotação);
			this.Name = "BalãoCotação";
			this.Click += new System.EventHandler(this.BalãoCotação_Click);
			this.Load += new System.EventHandler(this.BalãoCotação_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.BalãoCotação_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		private void BalãoCotação_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			timer.Enabled = !DesignMode;
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
            timer.Enabled = false;

            if (utilizarTemporizador)
                Hide();
		}

        private void BalãoCotação_Click(object sender, System.EventArgs e)
        {
            BalãoFoiClicado();
        }

        protected virtual void BalãoFoiClicado()
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                Hide();
            }
        }

		/// <summary>
		/// Ocorre ao carregar o balão.
		/// </summary>
		private void BalãoCotação_Load(object sender, System.EventArgs e)
		{
			// Monitorar click nos objetos
			EventHandler delegação = new EventHandler(BalãoCotação_Click);
			Queue        fila      = new Queue();

			fila.Enqueue(Controls);

			while (fila.Count > 0)
			{
				ICollection controles = (ICollection) fila.Dequeue();

				foreach (Control controle in controles)
				{
					fila.Enqueue(controle.Controls);
					controle.Click += delegação;
				}
			}

            Negócio.Beepador.Aviso();
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = lblTítulo.Text = value;
			}
		}

		/// <summary>
		/// Quando ligado, o temporizador irá fechar o balão após
		/// um determinado tempo.
		/// </summary>
		[DefaultValue(true)]
		public bool UtilizarTemporizador
		{
			get { return utilizarTemporizador; }
			set
            {
                utilizarTemporizador = value;
                timer.Enabled = value;
            }
		}
	}
}

