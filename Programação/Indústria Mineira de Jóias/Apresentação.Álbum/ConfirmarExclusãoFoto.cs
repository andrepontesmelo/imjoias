using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Álbum
{
	public class ConfirmarExclusãoFoto : Apresentação.Formulários.JanelaExplicativa
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components = null;
		private PainelFotos painel;

		public ConfirmarExclusãoFoto()
		{
			InitializeComponent();
		}

		[Obsolete("Não é necessária")]
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ConfirmarExclusãoFoto));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.painel = new Apresentação.Álbum.PainelFotos();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(75, 22);
			this.lblTítulo.Text = "Exclusão";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(226, 48);
			this.lblDescrição.Text = "Deseja apagar esta(s) foto(s) do catálogo ?                  Esta opção pode não " +
				"ser reversível !";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Name = "picÍcone";
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
			this.painel.Selecionável = false;
			this.painel.Size = new System.Drawing.Size(200, 72);
			this.painel.TabIndex = 5;
			// 
			// ConfirmarExclusãoFoto
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 176);
			this.Controls.Add(this.painel);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "ConfirmarExclusãoFoto";
			this.Text = "Confirmação de exclusão";
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.button2, 0);
			this.Controls.SetChildIndex(this.painel, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

