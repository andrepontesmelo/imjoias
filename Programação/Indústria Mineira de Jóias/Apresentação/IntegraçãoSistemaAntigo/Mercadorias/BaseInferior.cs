using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negócio.Fachada;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Mercadorias
{
	public class BaseInferior : Apresentação.Formulários.BaseInferior
	{
		private System.ComponentModel.IContainer components = null;

		//Variáveis 
		private DataSet dsNovo = new DataSet();
		private System.Windows.Forms.Button btnInicio;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private DataSet dsVelho = new DataSet();	
	
		public BaseInferior()
		{
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
			this.btnInicio = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Name = "esquerda";
			this.esquerda.Size = new System.Drawing.Size(187, 376);
			// 
			// btnInicio
			// 
			this.btnInicio.Location = new System.Drawing.Point(328, 40);
			this.btnInicio.Name = "btnInicio";
			this.btnInicio.Size = new System.Drawing.Size(104, 96);
			this.btnInicio.TabIndex = 6;
			this.btnInicio.Text = "Inicio";
			this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(288, 208);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(88, 48);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "linkLabel1";
			// 
			// BaseInferior
			// 
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnInicio);
			this.Name = "BaseInferior";
			this.Size = new System.Drawing.Size(608, 376);
			this.Controls.SetChildIndex(this.btnInicio, 0);
			this.Controls.SetChildIndex(this.linkLabel1, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnInicio_Click(object sender, System.EventArgs e)
		{
			
		}

	}
}

