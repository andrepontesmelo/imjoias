using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.�lbum
{
	public class ConfirmarExclus�oFoto : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components = null;
		private PainelFotos painel;

		public ConfirmarExclus�oFoto()
		{
			InitializeComponent();
		}

		[Obsolete("N�o � necess�ria")]
		public void Adicionar(ArrayList lstImagens)
		{
			foreach (Image imagem in lstImagens)
				painel.AdicionarFoto(imagem);
		}
		
		public void Adicionar(Image imagem)
		{
			painel.AdicionarFoto(imagem);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ConfirmarExclus�oFoto));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.painel = new Apresenta��o.�lbum.PainelFotos();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(75, 22);
			this.lblT�tulo.Text = "Exclus�o";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(226, 48);
			this.lblDescri��o.Text = "Deseja apagar esta(s) foto(s) do cat�logo ?                  Esta op��o pode n�o " +
				"ser revers�vel !";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(216, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 3;
			this.button1.Text = "Apagar";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(216, 136);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancelar";
			// 
			// painel
			// 
			this.painel.Location = new System.Drawing.Point(8, 96);
			this.painel.Name = "painel";
			this.painel.Selecion�vel = false;
			this.painel.Size = new System.Drawing.Size(200, 72);
			this.painel.TabIndex = 5;
			// 
			// ConfirmarExclus�oFoto
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 176);
			this.Controls.Add(this.painel);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "ConfirmarExclus�oFoto";
			this.Text = "Confirma��o de exclus�o";
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.button2, 0);
			this.Controls.SetChildIndex(this.painel, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

