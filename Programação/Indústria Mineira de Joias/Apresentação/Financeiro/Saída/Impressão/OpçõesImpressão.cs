using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Neg�cio;

namespace Apresenta��o.Pedido.Impress�o
{
	public class Op��esImpress�o : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private Apresenta��o.Formul�rios.Assistente.AssistenteControle assistente;
		private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelOp��es;
		private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelCrystal;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer visualizador;
		private System.ComponentModel.IContainer components = null;
		
		private IPedido pedido;

		public Op��esImpress�o(IPedido pedido)
		{
			InitializeComponent();
			this.pedido = pedido;

			// TODO: tornar assincrono
			ObterDados();
		}

		/// <summary>
		/// Obt�m dados do banco de dados, e atualiza relat�rio
		/// </summary>
		private void ObterDados()
		{
			System.Data.DataSet ds = 
				pedido.Imprimir();

			Relat�rioCrystal rpt = new Relat�rioCrystal();
			
			rpt.SetDataSource(ds);
			visualizador.ReportSource = rpt;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Op��esImpress�o));
			this.assistente = new Apresenta��o.Formul�rios.Assistente.AssistenteControle();
			this.painelOp��es = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
			this.painelCrystal = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
			this.visualizador = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.assistente.SuspendLayout();
			this.painelCrystal.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(682, 48);
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// assistente
			// 
			this.assistente.Controls.Add(this.painelOp��es);
			this.assistente.Controls.Add(this.painelCrystal);
			this.assistente.Itens = new Apresenta��o.Formul�rios.Assistente.PainelAssistente[] {
																								   this.painelOp��es,
																								   this.painelCrystal};
			this.assistente.Location = new System.Drawing.Point(8, 96);
			this.assistente.Name = "assistente";
			this.assistente.PainelAtual = 1;
			this.assistente.Size = new System.Drawing.Size(752, 392);
			this.assistente.TabIndex = 4;
			// 
			// painelOp��es
			// 
			this.painelOp��es.AutoScroll = true;
			this.painelOp��es.Location = new System.Drawing.Point(0, 0);
			this.painelOp��es.Name = "painelOp��es";
			this.painelOp��es.Size = new System.Drawing.Size(752, 360);
			this.painelOp��es.TabIndex = 1;
			// 
			// painelCrystal
			// 
			this.painelCrystal.AutoScroll = true;
			this.painelCrystal.Controls.Add(this.visualizador);
			this.painelCrystal.Location = new System.Drawing.Point(0, 0);
			this.painelCrystal.Name = "painelCrystal";
			this.painelCrystal.Size = new System.Drawing.Size(752, 360);
			this.painelCrystal.TabIndex = 2;
			// 
			// visualizador
			// 
			this.visualizador.ActiveViewIndex = -1;
			this.visualizador.DisplayGroupTree = false;
			this.visualizador.EnableDrillDown = false;
			this.visualizador.Location = new System.Drawing.Point(8, 8);
			this.visualizador.Name = "visualizador";
			this.visualizador.ReportSource = null;
			this.visualizador.ShowCloseButton = false;
			this.visualizador.ShowExportButton = false;
			this.visualizador.ShowGroupTreeButton = false;
			this.visualizador.ShowRefreshButton = false;
			this.visualizador.Size = new System.Drawing.Size(736, 344);
			this.visualizador.TabIndex = 0;
			// 
			// Op��esImpress�o
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(770, 496);
			this.Controls.Add(this.assistente);
			this.Name = "Op��esImpress�o";
			this.Text = "Op��es de impress�o";
			this.Controls.SetChildIndex(this.assistente, 0);
			this.assistente.ResumeLayout(false);
			this.painelCrystal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

