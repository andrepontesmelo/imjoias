using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Relat�rio.Recep��o;

namespace Administra��o.Bases
{
	public class Relat�rios : Apresenta��o.Formul�rios.BaseInferior
	{
		private System.Windows.Forms.Button cmdVisitantes;
		private System.Windows.Forms.Panel conte�do;
		private Administra��o.Bases.Relat�rio.ResumoAtual resumoAtual;
		private System.ComponentModel.IContainer components = null;

		public Relat�rios()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			resumoAtual.Controle = Principal.Controle;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Relat�rios));
			this.cmdVisitantes = new System.Windows.Forms.Button();
			this.conte�do = new System.Windows.Forms.Panel();
			this.resumoAtual = new Administra��o.Bases.Relat�rio.ResumoAtual();
			this.esquerda.SuspendLayout();
			this.conte�do.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Controls.Add(this.cmdVisitantes);
			this.esquerda.Name = "esquerda";
			// 
			// cmdVisitantes
			// 
			this.cmdVisitantes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(207)), ((System.Byte)(218)), ((System.Byte)(186)));
			this.cmdVisitantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdVisitantes.Image = ((System.Drawing.Image)(resources.GetObject("cmdVisitantes.Image")));
			this.cmdVisitantes.Location = new System.Drawing.Point(16, 16);
			this.cmdVisitantes.Name = "cmdVisitantes";
			this.cmdVisitantes.Size = new System.Drawing.Size(128, 112);
			this.cmdVisitantes.TabIndex = 6;
			this.cmdVisitantes.Text = "Relat�rio de Visitantes";
			this.cmdVisitantes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.cmdVisitantes.Click += new System.EventHandler(this.cmdVisitantes_Click);
			// 
			// conte�do
			// 
			this.conte�do.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.conte�do.Controls.Add(this.resumoAtual);
			this.conte�do.Location = new System.Drawing.Point(192, 0);
			this.conte�do.Name = "conte�do";
			this.conte�do.Size = new System.Drawing.Size(328, 296);
			this.conte�do.TabIndex = 6;
			// 
			// resumoAtual
			// 
			this.resumoAtual.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resumoAtual.Location = new System.Drawing.Point(0, 0);
			this.resumoAtual.Name = "resumoAtual";
			this.resumoAtual.Size = new System.Drawing.Size(328, 296);
			this.resumoAtual.TabIndex = 7;
			// 
			// Relat�rios
			// 
			this.Controls.Add(this.conte�do);
			this.Name = "Relat�rios";
			this.Size = new System.Drawing.Size(520, 296);
			this.Controls.SetChildIndex(this.conte�do, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.esquerda.ResumeLayout(false);
			this.conte�do.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdVisitantes_Click(object sender, System.EventArgs e)
		{
			SolicitarVisitantes form = new SolicitarVisitantes(Principal.Controle);

			form.Owner = this.ParentForm;
			form.Show();
		}
	}
}

