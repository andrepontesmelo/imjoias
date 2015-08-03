using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria
{
	public class RelatarProblemaFoto : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescri��o;
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

			pic�cone.Image = Entidades.�lbum.Foto.Redesenhar(imagem, pic�cone.Width, pic�cone.Height);
		}
		/// <summary>
		/// Descri��o do problema, entrado pelo usu�rio
		/// </summary>
		public string Descri��o
		{
			get 
			{
				return txtDescri��o.Text;
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
            this.txtDescri��o = new System.Windows.Forms.TextBox();
            this.lnkRelatar = new System.Windows.Forms.LinkLabel();
            this.lnkCancelar = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(237, 20);
            this.lblT�tulo.Text = "Relatar problema com a foto";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(298, 48);
            this.lblDescri��o.Text = "Ajude a melhorar a qualidade do �lbum relatando algum problema, tal como: falta d" +
                "e nitidez da foto ou v�nculo com uma mercadoria que n�o corresponde a imagem.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescri��o);
            this.groupBox1.Location = new System.Drawing.Point(8, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descri��o do problema";
            // 
            // txtDescri��o
            // 
            this.txtDescri��o.Location = new System.Drawing.Point(8, 16);
            this.txtDescri��o.Multiline = true;
            this.txtDescri��o.Name = "txtDescri��o";
            this.txtDescri��o.Size = new System.Drawing.Size(352, 64);
            this.txtDescri��o.TabIndex = 4;
            this.txtDescri��o.TextChanged += new System.EventHandler(this.txtDescri��o_TextChanged);
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
            this.Text = "Aperfei�oamento do �lbum";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RelatarProblemaFoto_Paint);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lnkRelatar, 0);
            this.Controls.SetChildIndex(this.lnkCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void RelatarProblemaFoto_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			txtDescri��o.Focus();
		}

		private void txtDescri��o_TextChanged(object sender, System.EventArgs e)
		{
            lnkRelatar.Enabled = Descri��o.Trim().Length > 0;
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

