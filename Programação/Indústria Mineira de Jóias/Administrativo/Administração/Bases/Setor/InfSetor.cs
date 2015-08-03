using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Indústria_Mineira_de_Jóias.AnáliseEstatística;

namespace Administração.Bases.Setor
{
	/// <summary>
	/// Summary description for InfSetor.
	/// </summary>
	public class InfSetor : System.Windows.Forms.UserControl
	{
		private Apresentação.Formulários.Quadro quadroEsperaXVisitantes;
		private Estatística.Gráfico gráficoEsperaXVisitantes;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InfSetor()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public void Preparar(long setor)
		{
			gráficoEsperaXVisitantes.MaxY = 2;
//			gráficoEsperaXVisitantes.VetorÚnico = Análises.AnalisarEsperaXVisitantes(Principal.Controle, 50, setor);
			throw new NotImplementedException("Reimplementar!");
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.quadroEsperaXVisitantes = new Apresentação.Formulários.Quadro();
			this.gráficoEsperaXVisitantes = new Estatística.Gráfico();
			this.quadroEsperaXVisitantes.SuspendLayout();
			this.SuspendLayout();
			// 
			// quadroEsperaXVisitantes
			// 
			this.quadroEsperaXVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroEsperaXVisitantes.BackColor = System.Drawing.Color.Beige;
			this.quadroEsperaXVisitantes.bInfDirArredondada = true;
			this.quadroEsperaXVisitantes.bInfEsqArredondada = true;
			this.quadroEsperaXVisitantes.bSupDirArredondada = true;
			this.quadroEsperaXVisitantes.bSupEsqArredondada = true;
			this.quadroEsperaXVisitantes.Controls.Add(this.gráficoEsperaXVisitantes);
			this.quadroEsperaXVisitantes.Cor = System.Drawing.Color.Black;
			this.quadroEsperaXVisitantes.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroEsperaXVisitantes.LetraTítulo = System.Drawing.Color.White;
			this.quadroEsperaXVisitantes.Location = new System.Drawing.Point(0, 0);
			this.quadroEsperaXVisitantes.Name = "quadroEsperaXVisitantes";
			this.quadroEsperaXVisitantes.Size = new System.Drawing.Size(432, 208);
			this.quadroEsperaXVisitantes.TabIndex = 2;
			this.quadroEsperaXVisitantes.Tamanho = 30;
			this.quadroEsperaXVisitantes.Título = "Espera por atendimento na recepção pelos últimos 50 visitantes por setor";
			// 
			// gráficoEsperaXVisitantes
			// 
			this.gráficoEsperaXVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoEsperaXVisitantes.BackColor = System.Drawing.Color.Transparent;
			this.gráficoEsperaXVisitantes.Dados = null;
			this.gráficoEsperaXVisitantes.EixoX = "Últimos Visitantes";
			this.gráficoEsperaXVisitantes.EixoY = "Espera (minutos)";
			this.gráficoEsperaXVisitantes.EstiloDesenho = Estatística.Estilo.LinhasVértices;
			this.gráficoEsperaXVisitantes.ForçarEscritaValoresX = false;
			this.gráficoEsperaXVisitantes.FundoCor = System.Drawing.Color.Transparent;
			this.gráficoEsperaXVisitantes.GapHorizontal = 0;
			this.gráficoEsperaXVisitantes.GapVertical = 20;
			this.gráficoEsperaXVisitantes.GradeHorizontal = true;
			this.gráficoEsperaXVisitantes.GradeVertical = true;
			this.gráficoEsperaXVisitantes.Legendas = null;
			this.gráficoEsperaXVisitantes.Location = new System.Drawing.Point(8, 32);
			this.gráficoEsperaXVisitantes.MaxX = -1;
			this.gráficoEsperaXVisitantes.MaxY = 2;
			this.gráficoEsperaXVisitantes.MinX = 0;
			this.gráficoEsperaXVisitantes.MinY = 0;
			this.gráficoEsperaXVisitantes.Name = "gráficoEsperaXVisitantes";
			this.gráficoEsperaXVisitantes.Size = new System.Drawing.Size(416, 168);
			this.gráficoEsperaXVisitantes.TabIndex = 1;
			this.gráficoEsperaXVisitantes.ValoresX = false;
			this.gráficoEsperaXVisitantes.ValoresY = true;
			this.gráficoEsperaXVisitantes.VérticeTamanho = 5F;
			this.gráficoEsperaXVisitantes.VetorÚnico = null;
			// 
			// InfSetor
			// 
			this.Controls.Add(this.quadroEsperaXVisitantes);
			this.Name = "InfSetor";
			this.Size = new System.Drawing.Size(432, 264);
			this.quadroEsperaXVisitantes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
