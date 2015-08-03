using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Cota��o
{
	/// <summary>
	/// Bal�o ilustrado para cota��o.
	/// </summary>
	internal class Bal�oCota��o : Balloon.NET.BalloonWindow
	{
		private bool utilizarTemporizador = true;

		private System.Windows.Forms.PictureBox picCota��o;
		private System.Windows.Forms.Label lblT�tulo;
		private System.Windows.Forms.Timer timer;
		private System.ComponentModel.IContainer components = null;

		public Bal�oCota��o()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Bal�oCota��o));
			this.picCota��o = new System.Windows.Forms.PictureBox();
			this.lblT�tulo = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// picCota��o
			// 
			this.picCota��o.Image = ((System.Drawing.Image)(resources.GetObject("picCota��o.Image")));
			this.picCota��o.Location = new System.Drawing.Point(8, 8);
			this.picCota��o.Name = "picCota��o";
			this.picCota��o.Size = new System.Drawing.Size(24, 24);
			this.picCota��o.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCota��o.TabIndex = 1;
			this.picCota��o.TabStop = false;
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblT�tulo.Location = new System.Drawing.Point(40, 8);
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(248, 24);
			this.lblT�tulo.TabIndex = 2;
			this.lblT�tulo.Text = "Informativo da Cota��o";
			this.lblT�tulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// timer
			// 
			this.timer.Interval = 15000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// Bal�oCota��o
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 94);
			this.Controls.Add(this.lblT�tulo);
			this.Controls.Add(this.picCota��o);
			this.Name = "Bal�oCota��o";
			this.Click += new System.EventHandler(this.Bal�oCota��o_Click);
			this.Load += new System.EventHandler(this.Bal�oCota��o_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bal�oCota��o_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		private void Bal�oCota��o_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			timer.Enabled = !DesignMode;
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
            timer.Enabled = false;

            if (utilizarTemporizador)
                Hide();
		}

        private void Bal�oCota��o_Click(object sender, System.EventArgs e)
        {
            Bal�oFoiClicado();
        }

        protected virtual void Bal�oFoiClicado()
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                Hide();
            }
        }

		/// <summary>
		/// Ocorre ao carregar o bal�o.
		/// </summary>
		private void Bal�oCota��o_Load(object sender, System.EventArgs e)
		{
			// Monitorar click nos objetos
			EventHandler delega��o = new EventHandler(Bal�oCota��o_Click);
			Queue        fila      = new Queue();

			fila.Enqueue(Controls);

			while (fila.Count > 0)
			{
				ICollection controles = (ICollection) fila.Dequeue();

				foreach (Control controle in controles)
				{
					fila.Enqueue(controle.Controls);
					controle.Click += delega��o;
				}
			}

            Neg�cio.Beepador.Aviso();
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = lblT�tulo.Text = value;
			}
		}

		/// <summary>
		/// Quando ligado, o temporizador ir� fechar o bal�o ap�s
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

