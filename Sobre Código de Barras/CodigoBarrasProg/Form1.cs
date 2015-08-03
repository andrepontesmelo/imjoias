using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CódigoDeBarras;

namespace CodigoBarrasProg
{
	public class Form1 : System.Windows.Forms.Form
	{
		private GeradorCódigoDeBarras a = new Interleaved25();

		// Formulário
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
//			a.Tamanho.Width = 500;
			InitializeComponent();
		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Red;
			this.pictureBox1.Location = new System.Drawing.Point(24, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(584, 400);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(64, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(144, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(648, 462);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{Application.Run(new Form1());	}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			pictureBox1.Image = a.GerarImagem(textBox1.Text);
		}
	}
}
