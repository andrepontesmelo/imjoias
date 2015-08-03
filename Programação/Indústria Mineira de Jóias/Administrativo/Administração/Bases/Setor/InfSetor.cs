using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Ind�stria_Mineira_de_J�ias.An�liseEstat�stica;

namespace Administra��o.Bases.Setor
{
	/// <summary>
	/// Summary description for InfSetor.
	/// </summary>
	public class InfSetor : System.Windows.Forms.UserControl
	{
		private Apresenta��o.Formul�rios.Quadro quadroEsperaXVisitantes;
		private Estat�stica.Gr�fico gr�ficoEsperaXVisitantes;
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
			gr�ficoEsperaXVisitantes.MaxY = 2;
//			gr�ficoEsperaXVisitantes.Vetor�nico = An�lises.AnalisarEsperaXVisitantes(Principal.Controle, 50, setor);
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
			this.quadroEsperaXVisitantes = new Apresenta��o.Formul�rios.Quadro();
			this.gr�ficoEsperaXVisitantes = new Estat�stica.Gr�fico();
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
			this.quadroEsperaXVisitantes.Controls.Add(this.gr�ficoEsperaXVisitantes);
			this.quadroEsperaXVisitantes.Cor = System.Drawing.Color.Black;
			this.quadroEsperaXVisitantes.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroEsperaXVisitantes.LetraT�tulo = System.Drawing.Color.White;
			this.quadroEsperaXVisitantes.Location = new System.Drawing.Point(0, 0);
			this.quadroEsperaXVisitantes.Name = "quadroEsperaXVisitantes";
			this.quadroEsperaXVisitantes.Size = new System.Drawing.Size(432, 208);
			this.quadroEsperaXVisitantes.TabIndex = 2;
			this.quadroEsperaXVisitantes.Tamanho = 30;
			this.quadroEsperaXVisitantes.T�tulo = "Espera por atendimento na recep��o pelos �ltimos 50 visitantes por setor";
			// 
			// gr�ficoEsperaXVisitantes
			// 
			this.gr�ficoEsperaXVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoEsperaXVisitantes.BackColor = System.Drawing.Color.Transparent;
			this.gr�ficoEsperaXVisitantes.Dados = null;
			this.gr�ficoEsperaXVisitantes.EixoX = "�ltimos Visitantes";
			this.gr�ficoEsperaXVisitantes.EixoY = "Espera (minutos)";
			this.gr�ficoEsperaXVisitantes.EstiloDesenho = Estat�stica.Estilo.LinhasV�rtices;
			this.gr�ficoEsperaXVisitantes.For�arEscritaValoresX = false;
			this.gr�ficoEsperaXVisitantes.FundoCor = System.Drawing.Color.Transparent;
			this.gr�ficoEsperaXVisitantes.GapHorizontal = 0;
			this.gr�ficoEsperaXVisitantes.GapVertical = 20;
			this.gr�ficoEsperaXVisitantes.GradeHorizontal = true;
			this.gr�ficoEsperaXVisitantes.GradeVertical = true;
			this.gr�ficoEsperaXVisitantes.Legendas = null;
			this.gr�ficoEsperaXVisitantes.Location = new System.Drawing.Point(8, 32);
			this.gr�ficoEsperaXVisitantes.MaxX = -1;
			this.gr�ficoEsperaXVisitantes.MaxY = 2;
			this.gr�ficoEsperaXVisitantes.MinX = 0;
			this.gr�ficoEsperaXVisitantes.MinY = 0;
			this.gr�ficoEsperaXVisitantes.Name = "gr�ficoEsperaXVisitantes";
			this.gr�ficoEsperaXVisitantes.Size = new System.Drawing.Size(416, 168);
			this.gr�ficoEsperaXVisitantes.TabIndex = 1;
			this.gr�ficoEsperaXVisitantes.ValoresX = false;
			this.gr�ficoEsperaXVisitantes.ValoresY = true;
			this.gr�ficoEsperaXVisitantes.V�rticeTamanho = 5F;
			this.gr�ficoEsperaXVisitantes.Vetor�nico = null;
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
