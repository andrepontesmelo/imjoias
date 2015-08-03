using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
	public class RelatarProblemaFoto : Apresentação.Formulários.JanelaExplicativa
	{
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescrição;
        private LinkLabel lnkRelatar;
        private LinkLabel lnkCancelar;
		private System.ComponentModel.IContainer components = null;

        // Construtora para modo Disign
        public RelatarProblemaFoto()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Abre a janela
		/// </summary>
		/// <param name="imagem">Imagem da foto com problema</param>
		public RelatarProblemaFoto(Image imagem)
		{
			InitializeComponent();

			picÍcone.Image = Entidades.Álbum.Foto.Redesenhar(imagem, picÍcone.Width, picÍcone.Height);
		}
		/// <summary>
		/// Descrição do problema, entrado pelo usuário
		/// </summary>
		public string Descrição
		{
			get 
			{
				return txtDescrição.Text;
			}
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatarProblemaFoto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.lnkRelatar = new System.Windows.Forms.LinkLabel();
            this.lnkCancelar = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(237, 20);
            this.lblTítulo.Text = "Relatar problema com a foto";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(298, 48);
            this.lblDescrição.Text = "Ajude a melhorar a qualidade do álbum relatando algum problema, tal como: falta d" +
                "e nitidez da foto ou vínculo com uma mercadoria que não corresponde a imagem.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescrição);
            this.groupBox1.Location = new System.Drawing.Point(8, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição do problema";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Location = new System.Drawing.Point(8, 16);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(352, 64);
            this.txtDescrição.TabIndex = 4;
            this.txtDescrição.TextChanged += new System.EventHandler(this.txtDescrição_TextChanged);
            // 
            // lnkRelatar
            // 
            this.lnkRelatar.AutoSize = true;
            this.lnkRelatar.Enabled = false;
            this.lnkRelatar.Location = new System.Drawing.Point(270, 189);
            this.lnkRelatar.Name = "lnkRelatar";
            this.lnkRelatar.Size = new System.Drawing.Size(41, 13);
            this.lnkRelatar.TabIndex = 7;
            this.lnkRelatar.TabStop = true;
            this.lnkRelatar.Text = "Relatar";
            this.lnkRelatar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRelatar_LinkClicked);
            // 
            // lnkCancelar
            // 
            this.lnkCancelar.AutoSize = true;
            this.lnkCancelar.Location = new System.Drawing.Point(323, 189);
            this.lnkCancelar.Name = "lnkCancelar";
            this.lnkCancelar.Size = new System.Drawing.Size(49, 13);
            this.lnkCancelar.TabIndex = 8;
            this.lnkCancelar.TabStop = true;
            this.lnkCancelar.Text = "Cancelar";
            this.lnkCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancelar_LinkClicked);
            // 
            // RelatarProblemaFoto
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(386, 211);
            this.Controls.Add(this.lnkCancelar);
            this.Controls.Add(this.lnkRelatar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RelatarProblemaFoto";
            this.Text = "Aperfeiçoamento do álbum";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RelatarProblemaFoto_Paint);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lnkRelatar, 0);
            this.Controls.SetChildIndex(this.lnkCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void RelatarProblemaFoto_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			txtDescrição.Focus();
		}

		private void txtDescrição_TextChanged(object sender, System.EventArgs e)
		{
            lnkRelatar.Enabled = Descrição.Trim().Length > 0;
		}

        private void lnkRelatar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lnkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
	}
}

