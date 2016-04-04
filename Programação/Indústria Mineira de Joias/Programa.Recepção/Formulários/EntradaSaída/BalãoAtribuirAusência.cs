
namespace Programa.Recepção.Formulários.EntradaSaída
{
	public class BalãoAtribuirAusência : Balloon.NET.BalloonWindow
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblHorário;
		private System.Windows.Forms.Label lblDescrição;
		private System.Windows.Forms.Button btnSim;
		private System.Windows.Forms.Button btnNão;
		private System.ComponentModel.IContainer components = null;

		public BalãoAtribuirAusência()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BalãoAtribuirAusência));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblHorário = new System.Windows.Forms.Label();
			this.lblDescrição = new System.Windows.Forms.Label();
			this.btnSim = new System.Windows.Forms.Button();
			this.btnNão = new System.Windows.Forms.Button();
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
			// lblHorário
			// 
			this.lblHorário.AutoSize = true;
			this.lblHorário.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHorário.Location = new System.Drawing.Point(48, 8);
			this.lblHorário.Name = "lblHorário";
			this.lblHorário.Size = new System.Drawing.Size(105, 16);
			this.lblHorário.TabIndex = 1;
			this.lblHorário.Text = "Horário de trabalho";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Location = new System.Drawing.Point(48, 24);
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(208, 56);
			this.lblDescrição.TabIndex = 2;
			this.lblDescrição.Text = "Existem alguns funcionários cujo horário de trabalho se expirou. Deseja verificar" +
				" quais funcionários podem ser atribuidos como ausentes?";
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
			// btnNão
			// 
			this.btnNão.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNão.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnNão.Location = new System.Drawing.Point(184, 80);
			this.btnNão.Name = "btnNão";
			this.btnNão.TabIndex = 4;
			this.btnNão.Text = "Não";
			// 
			// BalãoAtribuirAusência
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 110);
			this.Controls.Add(this.btnNão);
			this.Controls.Add(this.btnSim);
			this.Controls.Add(this.lblDescrição);
			this.Controls.Add(this.lblHorário);
			this.Controls.Add(this.pictureBox1);
			this.Name = "BalãoAtribuirAusência";
			this.ResumeLayout(false);

		}
		#endregion
	}
}

