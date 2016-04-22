using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa
{
	class TxtTelefoneBal�o : Balloon.NET.BalloonWindow
	{
		private Apresenta��o.Pessoa.TxtTelefone txtTelefone;

		// Designer
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblT�tulo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdLigar;
		private System.Windows.Forms.Button cmdDesligar;
		private System.ComponentModel.IContainer components = null;

        public TxtTelefoneBal�o(Apresenta��o.Pessoa.TxtTelefone txtTelefone)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.txtTelefone = txtTelefone;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TxtTelefoneBal�o));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblT�tulo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmdLigar = new System.Windows.Forms.Button();
			this.cmdDesligar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(38, 57);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.AutoSize = true;
			this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblT�tulo.Location = new System.Drawing.Point(56, 8);
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(189, 16);
			this.lblT�tulo.TabIndex = 1;
			this.lblT�tulo.Text = "Formata��o autom�tica de telefone";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "O recurso de formata��o autom�tica de telefone formata uma entrada do tipo \"31348" +
				"12243\" para \"(31) 3481-2243\".";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(56, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 40);
			this.label2.TabIndex = 3;
			this.label2.Text = "Caso o telefone a ser inserido n�o esteja sendo formatado de forma adequada, voc�" +
				" pode desligar a formata��o autom�tica.";
			// 
			// cmdLigar
			// 
			this.cmdLigar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdLigar.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.cmdLigar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdLigar.Location = new System.Drawing.Point(208, 120);
			this.cmdLigar.Name = "cmdLigar";
			this.cmdLigar.TabIndex = 4;
			this.cmdLigar.Text = "&Ligar";
			this.cmdLigar.Click += new System.EventHandler(this.cmdLigar_Click);
			// 
			// cmdDesligar
			// 
			this.cmdDesligar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdDesligar.DialogResult = System.Windows.Forms.DialogResult.No;
			this.cmdDesligar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdDesligar.Location = new System.Drawing.Point(128, 120);
			this.cmdDesligar.Name = "cmdDesligar";
			this.cmdDesligar.TabIndex = 5;
			this.cmdDesligar.Text = "&Desligar";
			this.cmdDesligar.Click += new System.EventHandler(this.cmdDesligar_Click);
			// 
			// TxtTelefoneBal�o
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 150);
			this.Controls.Add(this.cmdDesligar);
			this.Controls.Add(this.cmdLigar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblT�tulo);
			this.Controls.Add(this.pictureBox1);
			this.Name = "CaixaTelefoneBal�o";
			this.Text = "Formata��o autom�tica de telefone";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdLigar_Click(object sender, System.EventArgs e)
		{
			txtTelefone.AutoFormatar = true;
			this.Close();
		}

		private void cmdDesligar_Click(object sender, System.EventArgs e)
		{
			txtTelefone.AutoFormatar = false;
			this.Close();
		}
	}
}

