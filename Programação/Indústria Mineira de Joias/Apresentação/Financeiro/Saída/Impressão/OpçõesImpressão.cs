using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negócio;

namespace Apresentação.Pedido.Impressão
{
	public class OpçõesImpressão : Apresentação.Formulários.JanelaExplicativa
	{
		private Apresentação.Formulários.Assistente.AssistenteControle assistente;
		private Apresentação.Formulários.Assistente.PainelAssistente painelOpções;
		private Apresentação.Formulários.Assistente.PainelAssistente painelCrystal;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer visualizador;
		private System.ComponentModel.IContainer components = null;
		
		private IPedido pedido;

		public OpçõesImpressão(IPedido pedido)
		{
			InitializeComponent();
			this.pedido = pedido;

			// TODO: tornar assincrono
			ObterDados();
		}

		/// <summary>
		/// Obtém dados do banco de dados, e atualiza relatório
		/// </summary>
		private void ObterDados()
		{
			System.Data.DataSet ds = 
				pedido.Imprimir();

			RelatórioCrystal rpt = new RelatórioCrystal();
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OpçõesImpressão));
			this.assistente = new Apresentação.Formulários.Assistente.AssistenteControle();
			this.painelOpções = new Apresentação.Formulários.Assistente.PainelAssistente();
			this.painelCrystal = new Apresentação.Formulários.Assistente.PainelAssistente();
			this.visualizador = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.assistente.SuspendLayout();
			this.painelCrystal.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(682, 48);
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Name = "picÍcone";
			// 
			// assistente
			// 
			this.assistente.Controls.Add(this.painelOpções);
			this.assistente.Controls.Add(this.painelCrystal);
			this.assistente.Itens = new Apresentação.Formulários.Assistente.PainelAssistente[] {
																								   this.painelOpções,
																								   this.painelCrystal};
			this.assistente.Location = new System.Drawing.Point(8, 96);
			this.assistente.Name = "assistente";
			this.assistente.PainelAtual = 1;
			this.assistente.Size = new System.Drawing.Size(752, 392);
			this.assistente.TabIndex = 4;
			// 
			// painelOpções
			// 
			this.painelOpções.AutoScroll = true;
			this.painelOpções.Location = new System.Drawing.Point(0, 0);
			this.painelOpções.Name = "painelOpções";
			this.painelOpções.Size = new System.Drawing.Size(752, 360);
			this.painelOpções.TabIndex = 1;
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
			// OpçõesImpressão
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(770, 496);
			this.Controls.Add(this.assistente);
			this.Name = "OpçõesImpressão";
			this.Text = "Opções de impressão";
			this.Controls.SetChildIndex(this.assistente, 0);
			this.assistente.ResumeLayout(false);
			this.painelCrystal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

