
namespace Programa.Recep��o.Formul�rios.EntradaSa�da
{
	public class Bal�oAtribuirAus�ncia : Balloon.NET.BalloonWindow
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblHor�rio;
		private System.Windows.Forms.Label lblDescri��o;
		private System.Windows.Forms.Button btnSim;
		private System.Windows.Forms.Button btnN�o;
		private System.ComponentModel.IContainer components = null;

		public Bal�oAtribuirAus�ncia()
		{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Bal�oAtribuirAus�ncia));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblHor�rio = new System.Windows.Forms.Label();
			this.lblDescri��o = new System.Windows.Forms.Label();
			this.btnSim = new System.Windows.Forms.Button();
			this.btnN�o = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lblHor�rio
			// 
			this.lblHor�rio.AutoSize = true;
			this.lblHor�rio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHor�rio.Location = new System.Drawing.Point(48, 8);
			this.lblHor�rio.Name = "lblHor�rio";
			this.lblHor�rio.Size = new System.Drawing.Size(105, 16);
			this.lblHor�rio.TabIndex = 1;
			this.lblHor�rio.Text = "Hor�rio de trabalho";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Location = new System.Drawing.Point(48, 24);
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(208, 56);
			this.lblDescri��o.TabIndex = 2;
			this.lblDescri��o.Text = "Existem alguns funcion�rios cujo hor�rio de trabalho se expirou. Deseja verificar" +
				" quais funcion�rios podem ser atribuidos como ausentes?";
			// 
			// btnSim
			// 
			this.btnSim.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnSim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSim.Location = new System.Drawing.Point(104, 80);
			this.btnSim.Name = "btnSim";
			this.btnSim.TabIndex = 3;
			this.btnSim.Text = "Sim";
			// 
			// btnN�o
			// 
			this.btnN�o.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnN�o.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnN�o.Location = new System.Drawing.Point(184, 80);
			this.btnN�o.Name = "btnN�o";
			this.btnN�o.TabIndex = 4;
			this.btnN�o.Text = "N�o";
			// 
			// Bal�oAtribuirAus�ncia
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 110);
			this.Controls.Add(this.btnN�o);
			this.Controls.Add(this.btnSim);
			this.Controls.Add(this.lblDescri��o);
			this.Controls.Add(this.lblHor�rio);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Bal�oAtribuirAus�ncia";
			this.ResumeLayout(false);

		}
		#endregion
	}
}

