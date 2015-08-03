using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Etiqueta.Impressão
{
	public class Renomear : Apresentação.Formulários.JanelaExplicativa
	{
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.TextBox txtNovoNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNomeAntigo;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;

		public Renomear(string nomeAntigo)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			txtNomeAntigo.Text = nomeAntigo;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Renomear));
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.txtNovoNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNomeAntigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(148, 22);
			this.lblTítulo.Text = "Renomear formato";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Text = "Escolha um novo nome para o formato selecionado anteriormente.";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Name = "picÍcone";
			this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Location = new System.Drawing.Point(232, 168);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 14;
			this.cmdOK.Text = "OK";
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.Location = new System.Drawing.Point(312, 168);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.TabIndex = 13;
			this.cmdCancelar.Text = "Cancelar";
			// 
			// txtNovoNome
			// 
			this.txtNovoNome.Location = new System.Drawing.Point(152, 136);
			this.txtNovoNome.Name = "txtNovoNome";
			this.txtNovoNome.Size = new System.Drawing.Size(168, 20);
			this.txtNovoNome.TabIndex = 12;
			this.txtNovoNome.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(80, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Novo nome:";
			// 
			// txtNomeAntigo
			// 
			this.txtNomeAntigo.Location = new System.Drawing.Point(152, 104);
			this.txtNomeAntigo.Name = "txtNomeAntigo";
			this.txtNomeAntigo.ReadOnly = true;
			this.txtNomeAntigo.Size = new System.Drawing.Size(168, 20);
			this.txtNomeAntigo.TabIndex = 10;
			this.txtNomeAntigo.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(80, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Nome antigo:";
			// 
			// Renomear
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancelar;
			this.ClientSize = new System.Drawing.Size(392, 198);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancelar);
			this.Controls.Add(this.txtNovoNome);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNomeAntigo);
			this.Controls.Add(this.label1);
			this.Name = "Renomear";
			this.Text = "Configuração de etiquetas";
			this.TopMost = false;
			this.Load += new System.EventHandler(this.Renomear_Load);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtNomeAntigo, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtNovoNome, 0);
			this.Controls.SetChildIndex(this.cmdCancelar, 0);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao carregar o formulário
		/// </summary>
		private void Renomear_Load(object sender, System.EventArgs e)
		{
			txtNovoNome.Focus();
		}

		/// <summary>
		/// Novo nome
		/// </summary>
		public string Nome
		{
			get { return txtNovoNome.Text; }
			set { txtNovoNome.Text = value; }
		}
	}
}

