using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o
{
	public class SalvarConfigura��o : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFormato;
		private System.Windows.Forms.TextBox txtAutor;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components = null;

		public SalvarConfigura��o()
		{
			// This call is required by the Windows Form Designer.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalvarConfigura��o));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFormato = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(168, 20);
            this.lblT�tulo.Text = "Salvar configura��o";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Escolha um formato alternativo caso queira preservar a configura��o da etiqueta a" +
                "nterior. Neste caso, as altera��es ir�o compor uma nova etiqueta.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Formato:";
            // 
            // txtFormato
            // 
            this.txtFormato.Location = new System.Drawing.Point(144, 112);
            this.txtFormato.Name = "txtFormato";
            this.txtFormato.Size = new System.Drawing.Size(168, 20);
            this.txtFormato.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Autor:";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(144, 144);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.ReadOnly = true;
            this.txtAutor.Size = new System.Drawing.Size(168, 20);
            this.txtAutor.TabIndex = 6;
            this.toolTip.SetToolTip(this.txtAutor, "O autor do formato sempre ser� o nome do usu�rio utilizado para iniciar o program" +
                    "a.");
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(304, 184);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 7;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(224, 184);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            // 
            // SalvarConfigura��o
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(392, 216);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFormato);
            this.Controls.Add(this.label1);
            this.Name = "SalvarConfigura��o";
            this.Text = "Salvar configura��o";
            this.TopMost = false;
            this.Load += new System.EventHandler(this.SalvarConfigura��o_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtFormato, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtAutor, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Ocorre ao carregar o formul�rio
		/// </summary>
		private void SalvarConfigura��o_Load(object sender, System.EventArgs e)
		{
			txtAutor.Text = Acesso.Comum.Usu�rios.Usu�rioAtual.Nome;
			txtFormato.Focus();
		}

		/// <summary>
		/// Nome do formato
		/// </summary>
		public string Formato
		{
			get { return txtFormato.Text; }
			set { txtFormato.Text = value; }
		}
	}
}

