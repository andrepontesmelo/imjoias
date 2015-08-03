using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Programa.Recep��o.Formul�rios.EntradaSa�da
{
	sealed class Notifica��oHor�rio : Apresenta��o.Formul�rios.Notifica��o
	{
		// Atributo
		private Entidades.Pessoa.Funcion�rio funcion�rio;

		// Evento
		public delegate void DAtribuirAus�ncia(Entidades.Pessoa.Funcion�rio funcion�rio);
		public event DAtribuirAus�ncia AtribuirAus�ncia;

		// Designer
		private System.Windows.Forms.Label lblFuncion�rio;
		private System.Windows.Forms.Label lblHor�rio;
		private System.Windows.Forms.PictureBox picFoto;
		private System.Windows.Forms.Button btnAtribuirAus�ncia;
		private System.ComponentModel.IContainer components = null;

		public Notifica��oHor�rio(Entidades.Pessoa.Funcion�rio funcion�rio)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			lblFuncion�rio.Text = funcion�rio.Nome;
			lblHor�rio.Text = "Hor�rio de trabalho: " + funcion�rio.TabelaHor�rio.ObterHor�rioAtual();

            //if (funcion�rio.Foto != null)
            //    picFoto.Image = funcion�rio.Foto;

			this.funcion�rio = funcion�rio;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Notifica��oHor�rio));
			this.picFoto = new System.Windows.Forms.PictureBox();
			this.lblFuncion�rio = new System.Windows.Forms.Label();
			this.lblHor�rio = new System.Windows.Forms.Label();
			this.btnAtribuirAus�ncia = new System.Windows.Forms.Button();
			this.quadro.SuspendLayout();
			this.SuspendLayout();
			// 
			// quadro
			// 
			this.quadro.Controls.Add(this.btnAtribuirAus�ncia);
			this.quadro.Controls.Add(this.lblFuncion�rio);
			this.quadro.Controls.Add(this.picFoto);
			this.quadro.Controls.Add(this.lblHor�rio);
			this.quadro.Name = "quadro";
			this.quadro.T�tulo = "Hor�rio de trabalho";
			this.quadro.Controls.SetChildIndex(this.lblHor�rio, 0);
			this.quadro.Controls.SetChildIndex(this.picFoto, 0);
			this.quadro.Controls.SetChildIndex(this.lblFuncion�rio, 0);
			this.quadro.Controls.SetChildIndex(this.btnAtribuirAus�ncia, 0);
			// 
			// picFoto
			// 
			this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
			this.picFoto.Location = new System.Drawing.Point(8, 32);
			this.picFoto.Name = "picFoto";
			this.picFoto.Size = new System.Drawing.Size(60, 80);
			this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picFoto.TabIndex = 2;
			this.picFoto.TabStop = false;
			// 
			// lblFuncion�rio
			// 
			this.lblFuncion�rio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFuncion�rio.Location = new System.Drawing.Point(80, 32);
			this.lblFuncion�rio.Name = "lblFuncion�rio";
			this.lblFuncion�rio.Size = new System.Drawing.Size(200, 16);
			this.lblFuncion�rio.TabIndex = 3;
			this.lblFuncion�rio.Text = "Nome do funcion�rio";
			// 
			// lblHor�rio
			// 
			this.lblHor�rio.BackColor = System.Drawing.Color.Transparent;
			this.lblHor�rio.Location = new System.Drawing.Point(80, 48);
			this.lblHor�rio.Name = "lblHor�rio";
			this.lblHor�rio.Size = new System.Drawing.Size(200, 32);
			this.lblHor�rio.TabIndex = 4;
			this.lblHor�rio.Text = "Hor�rio de trabalho expirou.";
			// 
			// btnAtribuirAus�ncia
			// 
			this.btnAtribuirAus�ncia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAtribuirAus�ncia.Location = new System.Drawing.Point(144, 88);
			this.btnAtribuirAus�ncia.Name = "btnAtribuirAus�ncia";
			this.btnAtribuirAus�ncia.Size = new System.Drawing.Size(104, 23);
			this.btnAtribuirAus�ncia.TabIndex = 5;
			this.btnAtribuirAus�ncia.Text = "Atribuir aus�ncia";
			this.btnAtribuirAus�ncia.Click += new System.EventHandler(this.btnAtribuirAus�ncia_Click);
			// 
			// Notifica��oHor�rio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 120);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "Notifica��oHor�rio";
			this.T�tulo = "Hor�rio de trabalho";
			this.quadro.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre quando o usu�rio clica em atribuir aus�ncia.
		/// </summary>
		private void btnAtribuirAus�ncia_Click(object sender, System.EventArgs e)
		{
			AtribuirAus�ncia(funcion�rio);
			this.Close();
		}
	}
}

