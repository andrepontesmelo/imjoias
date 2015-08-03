using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Neg�cio.Controle;
using Entidades;
using Observador;
using Neg�cio.Observador;
using Neg�cio;

namespace Administra��o.Bases.Relat�rio
{
	/// <summary>
	/// Summary description for ResumoAtual.
	/// </summary>
	public class ResumoAtual : System.Windows.Forms.UserControl
	{
		private IAdministra��o		controle;
		private EventoObserva��o	observa��oVisitante;

		// Designer
		private Apresenta��o.Formul�rios.Quadro quadroEsperaXVisitantes;
		private Apresenta��o.Formul�rios.Quadro quadroVisitantes14Dias;
		private Estat�stica.Gr�fico gr�ficoVisitantes14Dias;
		private Estat�stica.Legenda legendaVisitantes14Dias;
		private Estat�stica.Gr�fico gr�ficoEsperaXVisitantes;
		private Estat�stica.Legenda legendaEsperaXVisitantes;
		private Apresenta��o.Formul�rios.Quadro quadroM�diaHor�ria;
		private Estat�stica.Gr�fico gr�ficoM�diaHor�ria;
		private System.Windows.Forms.Label label1;
		private Apresenta��o.Formul�rios.Quadro quadroMotivo;
		private Estat�stica.Gr�fico gr�ficoMotivo;
		private Estat�stica.Legenda legendaMotivo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResumoAtual()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Observa��o
			observa��oVisitante = new EventoObserva��o(Observa��oVisitante);

			// Gr�fico
//			gr�ficoVisitantes14Dias.ValorX += new Estat�stica.Desenhista.Convers�oValor(gr�ficoVisitantes14Dias_ValorX);
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

				if (controle != null)
					((IControle) controle).Observa��oVisitante -= observa��oVisitante;
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
			this.quadroVisitantes14Dias = new Apresenta��o.Formul�rios.Quadro();
			this.legendaVisitantes14Dias = new Estat�stica.Legenda();
			this.gr�ficoVisitantes14Dias = new Estat�stica.Gr�fico();
			this.quadroEsperaXVisitantes = new Apresenta��o.Formul�rios.Quadro();
			this.legendaEsperaXVisitantes = new Estat�stica.Legenda();
			this.gr�ficoEsperaXVisitantes = new Estat�stica.Gr�fico();
			this.quadroM�diaHor�ria = new Apresenta��o.Formul�rios.Quadro();
			this.label1 = new System.Windows.Forms.Label();
			this.gr�ficoM�diaHor�ria = new Estat�stica.Gr�fico();
			this.quadroMotivo = new Apresenta��o.Formul�rios.Quadro();
			this.legendaMotivo = new Estat�stica.Legenda();
			this.gr�ficoMotivo = new Estat�stica.Gr�fico();
			this.quadroVisitantes14Dias.SuspendLayout();
			this.quadroEsperaXVisitantes.SuspendLayout();
			this.quadroM�diaHor�ria.SuspendLayout();
			this.quadroMotivo.SuspendLayout();
			this.SuspendLayout();
			// 
			// quadroVisitantes14Dias
			// 
			this.quadroVisitantes14Dias.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.quadroVisitantes14Dias.BackColor = System.Drawing.Color.Beige;
			this.quadroVisitantes14Dias.bInfDirArredondada = true;
			this.quadroVisitantes14Dias.bInfEsqArredondada = true;
			this.quadroVisitantes14Dias.bSupDirArredondada = true;
			this.quadroVisitantes14Dias.bSupEsqArredondada = true;
			this.quadroVisitantes14Dias.Controls.Add(this.legendaVisitantes14Dias);
			this.quadroVisitantes14Dias.Controls.Add(this.gr�ficoVisitantes14Dias);
			this.quadroVisitantes14Dias.Cor = System.Drawing.Color.Black;
			this.quadroVisitantes14Dias.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroVisitantes14Dias.LetraT�tulo = System.Drawing.Color.White;
			this.quadroVisitantes14Dias.Location = new System.Drawing.Point(0, 0);
			this.quadroVisitantes14Dias.Name = "quadroVisitantes14Dias";
			this.quadroVisitantes14Dias.Size = new System.Drawing.Size(288, 208);
			this.quadroVisitantes14Dias.TabIndex = 0;
			this.quadroVisitantes14Dias.Tamanho = 30;
			this.quadroVisitantes14Dias.T�tulo = "Crescimento de visitantes nos �ltimos 14 dias";
			// 
			// legendaVisitantes14Dias
			// 
			this.legendaVisitantes14Dias.AutoSize = false;
			this.legendaVisitantes14Dias.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaVisitantes14Dias.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaVisitantes14Dias.Colunas = 2;
			this.legendaVisitantes14Dias.Distanciamento = 2;
			this.legendaVisitantes14Dias.Espa�amento = 5;
			this.legendaVisitantes14Dias.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.legendaVisitantes14Dias.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaVisitantes14Dias.Gr�fico = this.gr�ficoVisitantes14Dias;
			this.legendaVisitantes14Dias.Location = new System.Drawing.Point(16, 168);
			this.legendaVisitantes14Dias.Name = "legendaVisitantes14Dias";
			this.legendaVisitantes14Dias.QuadradoTamanho = 4;
			this.legendaVisitantes14Dias.Size = new System.Drawing.Size(256, 32);
			this.legendaVisitantes14Dias.TabIndex = 4;
			// 
			// gr�ficoVisitantes14Dias
			// 
			this.gr�ficoVisitantes14Dias.BackColor = System.Drawing.Color.Transparent;
			this.gr�ficoVisitantes14Dias.Dados = null;
			this.gr�ficoVisitantes14Dias.EixoX = "Dias";
			this.gr�ficoVisitantes14Dias.EixoY = "Pessoas";
			this.gr�ficoVisitantes14Dias.EstiloDesenho = Estat�stica.Estilo.LinhasV�rtices;
			this.gr�ficoVisitantes14Dias.For�arEscritaValoresX = false;
			this.gr�ficoVisitantes14Dias.FundoCor = System.Drawing.Color.Transparent;
			this.gr�ficoVisitantes14Dias.GapHorizontal = 15;
			this.gr�ficoVisitantes14Dias.GapVertical = 20;
			this.gr�ficoVisitantes14Dias.GradeHorizontal = true;
			this.gr�ficoVisitantes14Dias.GradeVertical = true;
			this.gr�ficoVisitantes14Dias.Legendas = null;
			this.gr�ficoVisitantes14Dias.Location = new System.Drawing.Point(16, 32);
			this.gr�ficoVisitantes14Dias.MaxX = 13;
			this.gr�ficoVisitantes14Dias.MaxY = 0;
			this.gr�ficoVisitantes14Dias.MinX = 0;
			this.gr�ficoVisitantes14Dias.MinY = 0;
			this.gr�ficoVisitantes14Dias.Name = "gr�ficoVisitantes14Dias";
			this.gr�ficoVisitantes14Dias.Size = new System.Drawing.Size(264, 128);
			this.gr�ficoVisitantes14Dias.TabIndex = 1;
			this.gr�ficoVisitantes14Dias.ValoresX = true;
			this.gr�ficoVisitantes14Dias.ValoresY = true;
			this.gr�ficoVisitantes14Dias.V�rticeTamanho = 5F;
			this.gr�ficoVisitantes14Dias.Vetor�nico = null;
			// 
			// quadroEsperaXVisitantes
			// 
			this.quadroEsperaXVisitantes.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.quadroEsperaXVisitantes.BackColor = System.Drawing.Color.Beige;
			this.quadroEsperaXVisitantes.bInfDirArredondada = true;
			this.quadroEsperaXVisitantes.bInfEsqArredondada = true;
			this.quadroEsperaXVisitantes.bSupDirArredondada = true;
			this.quadroEsperaXVisitantes.bSupEsqArredondada = true;
			this.quadroEsperaXVisitantes.Controls.Add(this.legendaEsperaXVisitantes);
			this.quadroEsperaXVisitantes.Controls.Add(this.gr�ficoEsperaXVisitantes);
			this.quadroEsperaXVisitantes.Cor = System.Drawing.Color.Black;
			this.quadroEsperaXVisitantes.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroEsperaXVisitantes.LetraT�tulo = System.Drawing.Color.White;
			this.quadroEsperaXVisitantes.Location = new System.Drawing.Point(304, 0);
			this.quadroEsperaXVisitantes.Name = "quadroEsperaXVisitantes";
			this.quadroEsperaXVisitantes.Size = new System.Drawing.Size(288, 208);
			this.quadroEsperaXVisitantes.TabIndex = 1;
			this.quadroEsperaXVisitantes.Tamanho = 30;
			this.quadroEsperaXVisitantes.T�tulo = "Espera por atendimento na recep��o pelos �ltimos 15 visitantes por setor";
			// 
			// legendaEsperaXVisitantes
			// 
			this.legendaEsperaXVisitantes.AutoSize = false;
			this.legendaEsperaXVisitantes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaEsperaXVisitantes.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaEsperaXVisitantes.Colunas = 2;
			this.legendaEsperaXVisitantes.Distanciamento = 2;
			this.legendaEsperaXVisitantes.Espa�amento = 5;
			this.legendaEsperaXVisitantes.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.legendaEsperaXVisitantes.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaEsperaXVisitantes.Gr�fico = this.gr�ficoEsperaXVisitantes;
			this.legendaEsperaXVisitantes.Location = new System.Drawing.Point(16, 168);
			this.legendaEsperaXVisitantes.Name = "legendaEsperaXVisitantes";
			this.legendaEsperaXVisitantes.QuadradoTamanho = 4;
			this.legendaEsperaXVisitantes.Size = new System.Drawing.Size(256, 32);
			this.legendaEsperaXVisitantes.TabIndex = 2;
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
			this.gr�ficoEsperaXVisitantes.Size = new System.Drawing.Size(272, 128);
			this.gr�ficoEsperaXVisitantes.TabIndex = 1;
			this.gr�ficoEsperaXVisitantes.ValoresX = false;
			this.gr�ficoEsperaXVisitantes.ValoresY = true;
			this.gr�ficoEsperaXVisitantes.V�rticeTamanho = 5F;
			this.gr�ficoEsperaXVisitantes.Vetor�nico = null;
			// 
			// quadroM�diaHor�ria
			// 
			this.quadroM�diaHor�ria.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.quadroM�diaHor�ria.BackColor = System.Drawing.Color.Beige;
			this.quadroM�diaHor�ria.bInfDirArredondada = true;
			this.quadroM�diaHor�ria.bInfEsqArredondada = true;
			this.quadroM�diaHor�ria.bSupDirArredondada = true;
			this.quadroM�diaHor�ria.bSupEsqArredondada = true;
			this.quadroM�diaHor�ria.Controls.Add(this.label1);
			this.quadroM�diaHor�ria.Controls.Add(this.gr�ficoM�diaHor�ria);
			this.quadroM�diaHor�ria.Cor = System.Drawing.Color.Black;
			this.quadroM�diaHor�ria.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroM�diaHor�ria.LetraT�tulo = System.Drawing.Color.White;
			this.quadroM�diaHor�ria.Location = new System.Drawing.Point(0, 224);
			this.quadroM�diaHor�ria.Name = "quadroM�diaHor�ria";
			this.quadroM�diaHor�ria.Size = new System.Drawing.Size(288, 208);
			this.quadroM�diaHor�ria.TabIndex = 2;
			this.quadroM�diaHor�ria.Tamanho = 30;
			this.quadroM�diaHor�ria.T�tulo = "M�dia de visitantes nos �ltimos 14 dias*";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "* Desconsiderando o dia de hoje";
			// 
			// gr�ficoM�diaHor�ria
			// 
			this.gr�ficoM�diaHor�ria.BackColor = System.Drawing.Color.Transparent;
			this.gr�ficoM�diaHor�ria.Dados = null;
			this.gr�ficoM�diaHor�ria.EixoX = "Horas";
			this.gr�ficoM�diaHor�ria.EixoY = "Pessoas";
			this.gr�ficoM�diaHor�ria.EstiloDesenho = Estat�stica.Estilo.Barras;
			this.gr�ficoM�diaHor�ria.For�arEscritaValoresX = false;
			this.gr�ficoM�diaHor�ria.FundoCor = System.Drawing.Color.Transparent;
			this.gr�ficoM�diaHor�ria.GapHorizontal = 0;
			this.gr�ficoM�diaHor�ria.GapVertical = 20;
			this.gr�ficoM�diaHor�ria.GradeHorizontal = true;
			this.gr�ficoM�diaHor�ria.GradeVertical = false;
			this.gr�ficoM�diaHor�ria.Legendas = null;
			this.gr�ficoM�diaHor�ria.Location = new System.Drawing.Point(16, 32);
			this.gr�ficoM�diaHor�ria.MaxX = 23;
			this.gr�ficoM�diaHor�ria.MaxY = 2;
			this.gr�ficoM�diaHor�ria.MinX = 0;
			this.gr�ficoM�diaHor�ria.MinY = 0;
			this.gr�ficoM�diaHor�ria.Name = "gr�ficoM�diaHor�ria";
			this.gr�ficoM�diaHor�ria.Size = new System.Drawing.Size(264, 144);
			this.gr�ficoM�diaHor�ria.TabIndex = 1;
			this.gr�ficoM�diaHor�ria.ValoresX = true;
			this.gr�ficoM�diaHor�ria.ValoresY = true;
			this.gr�ficoM�diaHor�ria.V�rticeTamanho = 5F;
			this.gr�ficoM�diaHor�ria.Vetor�nico = null;
			// 
			// quadroMotivo
			// 
			this.quadroMotivo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.quadroMotivo.BackColor = System.Drawing.Color.Beige;
			this.quadroMotivo.bInfDirArredondada = true;
			this.quadroMotivo.bInfEsqArredondada = true;
			this.quadroMotivo.bSupDirArredondada = true;
			this.quadroMotivo.bSupEsqArredondada = true;
			this.quadroMotivo.Controls.Add(this.legendaMotivo);
			this.quadroMotivo.Controls.Add(this.gr�ficoMotivo);
			this.quadroMotivo.Cor = System.Drawing.Color.Black;
			this.quadroMotivo.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroMotivo.LetraT�tulo = System.Drawing.Color.White;
			this.quadroMotivo.Location = new System.Drawing.Point(304, 224);
			this.quadroMotivo.Name = "quadroMotivo";
			this.quadroMotivo.Size = new System.Drawing.Size(288, 208);
			this.quadroMotivo.TabIndex = 3;
			this.quadroMotivo.Tamanho = 30;
			this.quadroMotivo.T�tulo = "Motivo das visitas nos �ltimos 14 dias";
			// 
			// legendaMotivo
			// 
			this.legendaMotivo.AutoSize = false;
			this.legendaMotivo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaMotivo.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaMotivo.Colunas = 3;
			this.legendaMotivo.Distanciamento = 2;
			this.legendaMotivo.Espa�amento = 5;
			this.legendaMotivo.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.legendaMotivo.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaMotivo.Gr�fico = this.gr�ficoMotivo;
			this.legendaMotivo.Location = new System.Drawing.Point(16, 152);
			this.legendaMotivo.Name = "legendaMotivo";
			this.legendaMotivo.QuadradoTamanho = 4;
			this.legendaMotivo.Size = new System.Drawing.Size(256, 48);
			this.legendaMotivo.TabIndex = 2;
			// 
			// gr�ficoMotivo
			// 
			this.gr�ficoMotivo.BackColor = System.Drawing.Color.Transparent;
			this.gr�ficoMotivo.Dados = null;
			this.gr�ficoMotivo.EixoX = "Horas";
			this.gr�ficoMotivo.EixoY = "Pessoas";
			this.gr�ficoMotivo.EstiloDesenho = Estat�stica.Estilo.Pizza;
			this.gr�ficoMotivo.For�arEscritaValoresX = false;
			this.gr�ficoMotivo.FundoCor = System.Drawing.Color.Transparent;
			this.gr�ficoMotivo.GapHorizontal = 0;
			this.gr�ficoMotivo.GapVertical = 20;
			this.gr�ficoMotivo.GradeHorizontal = true;
			this.gr�ficoMotivo.GradeVertical = true;
			this.gr�ficoMotivo.Legendas = null;
			this.gr�ficoMotivo.Location = new System.Drawing.Point(16, 32);
			this.gr�ficoMotivo.MaxX = -1;
			this.gr�ficoMotivo.MaxY = 0;
			this.gr�ficoMotivo.MinX = 0;
			this.gr�ficoMotivo.MinY = 0;
			this.gr�ficoMotivo.Name = "gr�ficoMotivo";
			this.gr�ficoMotivo.Size = new System.Drawing.Size(264, 120);
			this.gr�ficoMotivo.TabIndex = 1;
			this.gr�ficoMotivo.ValoresX = true;
			this.gr�ficoMotivo.ValoresY = true;
			this.gr�ficoMotivo.V�rticeTamanho = 5F;
			this.gr�ficoMotivo.Vetor�nico = null;
			// 
			// ResumoAtual
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.quadroMotivo);
			this.Controls.Add(this.quadroM�diaHor�ria);
			this.Controls.Add(this.quadroEsperaXVisitantes);
			this.Controls.Add(this.quadroVisitantes14Dias);
			this.Name = "ResumoAtual";
			this.Size = new System.Drawing.Size(592, 440);
			this.quadroVisitantes14Dias.ResumeLayout(false);
			this.quadroEsperaXVisitantes.ResumeLayout(false);
			this.quadroM�diaHor�ria.ResumeLayout(false);
			this.quadroMotivo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public IAdministra��o Controle
		{
			get { return controle; }
			set
			{
				controle = value;

//				AnalisarVisitantes14Dias();
//				AnalisarEsperaXVisitantes();
				ConstruirGr�ficos();

				// Tratar eventos
				((IControle) controle).Preparar();
				((IControle) controle).Observa��oVisitante += observa��oVisitante;
			}
		}

		#region Observa��o

		/// <summary>
		/// Observa a��o de visitantes
		/// </summary>
		public void Observa��oVisitante(ISujeito sujeito, int a��o, object obj)
		{
			try
			{
				switch ((A��oVisitante) a��o)
				{
					case A��oVisitante.Entrou:
						AcrescentarVisitante((IVisitante) sujeito);
						break;

					case A��oVisitante.Desistiu:
						AcrescentarEspera((IVisitante) sujeito);
						break;

					case A��oVisitante.T�rminoEspera:
						AcrescentarEspera((IVisitante) sujeito, ((TimeSpan) obj).Seconds / 60f);
						break;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		#endregion

		#region An�lise de dados para constru��o de gr�ficos

		/// <summary>
		/// Analisa dados de visitantes para montar gr�fico
		/// </summary>
		private void AnalisarVisitantes14Dias()
		{
			const int	dias = 14;
			double [][] di�rio;
			double []	m�diaHor�ria;
			DateTime	in�cio;
			ArrayList	visitas;
			ArrayList	strSetores;
			ArrayList	setores;
			double []	dadosMotivo = new double[Enum.GetNames(typeof(MotivoContato)).Length];
			int []		valoresEnumMotivo = (int []) Enum.GetValues(typeof(MotivoContato));

			// Considerando o dia de hoje, dias - 1
			in�cio		 = DateTime.Now.Date.Subtract(new TimeSpan(dias - 1, 0, 0, 0 ,0));
			visitas = controle.ObterVisitas(in�cio, DateTime.Now);

			if (visitas.Count == 0)
				return;

			strSetores	 = new ArrayList();
			setores		 = new ArrayList();
			m�diaHor�ria = new double[24];
			
			// Obter setores de atendimento
			foreach (Neg�cio.ISetor setor in controle.ObterSetores())
				if (setor.Dados.Atendimento)
					setores.Add(setor);

			setores.Sort();

			foreach (Neg�cio.ISetor setor in setores)
				strSetores.Add(setor.Dados.Nome);

			strSetores.Add("Total");

			// Considerar mais um setor para a soma total
			di�rio = new double[setores.Count + 1][];

			for (int i = 0; i <= setores.Count; i++)
				di�rio[i] = new double[dias];

			// Construir m�dia
			foreach (Visita visita in visitas)
			{
				TimeSpan dif = DateTime.Now.Date - visita.Entrada.Date;
				int dia = dias - 1 - dif.Days;

				// Gr�fico de visitantes
				if (visita.Setor != null)
				{
					int p = setores.BinarySearch(visita.Setor);

					if (p >= 0)
						di�rio[p][dia]++;
				}

				di�rio[setores.Count][dia]++;

				// Gr�fico de m�dia hor�ria
				if (visita.Entrada.Date != DateTime.Now.Date)		// O dia atual � desconsiderado
					m�diaHor�ria[visita.Entrada.Hour] += 1f / dias;

				// Gr�fico de motivo de visita
				for (int i = 0; i < valoresEnumMotivo.Length; i++)
					if ((((int) visita.Motivo) & valoresEnumMotivo[i]) > 0)
						dadosMotivo[i]++;
					else if ((int) visita.Motivo == (int) MotivoContato.Desconhecido)
						dadosMotivo[0]++;
			}

			gr�ficoVisitantes14Dias.Dados = di�rio;
			gr�ficoVisitantes14Dias.Legendas = (string []) strSetores.ToArray(typeof(string));

			gr�ficoM�diaHor�ria.Vetor�nico = m�diaHor�ria;

			gr�ficoMotivo.Vetor�nico = dadosMotivo;
			gr�ficoMotivo.Legendas = Enum.GetNames(typeof(MotivoContato));
		}

		private void AnalisarEsperaXVisitantes()
		{
			const int   nVisitantes = 15;
			double [][] dados;
			ArrayList   setores = new ArrayList();
			string []	legenda;

			// Obter setores de atendimento
			foreach (Neg�cio.ISetor setor in controle.ObterSetores())
				if (setor.Dados.Atendimento)
					setores.Add(setor);

			setores.Sort();

			dados = new double[setores.Count][];
			legenda = new string[setores.Count];

			for (int i = 0; i < dados.Length; i++)
			{
				double [] esperas;
				ISetor setor;

				dados[i] = new double [nVisitantes];
				setor    = ((Neg�cio.ISetor) setores[i]);
				esperas  = controle.ObterEsperas(nVisitantes, setor.Dados.C�digo);
				legenda[i] = setor.Dados.Nome;

				// Preencher dados
				for (int j = nVisitantes - 1; j >= nVisitantes - esperas.Length; j--)
					dados[i][j] = esperas[nVisitantes - j - 1];
			}

			gr�ficoEsperaXVisitantes.Dados = dados;
			gr�ficoEsperaXVisitantes.Legendas = legenda;
		}

		#endregion

		#region Gr�ficos/Atualiza��o de gr�ficos

		/// <summary>
		/// Legenda dos valores no eixo X do gr�fico de visitantes
		/// </summary>
		private string gr�ficoVisitantes14Dias_ValorX(double valor)
		{
			DateTime dia = DateTime.Now.Date.Subtract(
				new TimeSpan(13 - (int) valor, 0, 0, 0, 0));

			return dia.ToString("ddd");
		}

		/// <summary>
		/// Acrescenta novo visitante ao dia de hoje
		/// </summary>
		private void AcrescentarVisitante(IVisitante visitante)
		{
			try
			{
				int seq��ncias = gr�ficoVisitantes14Dias.Dados.Length - 1;

				// Total
				gr�ficoVisitantes14Dias.Dados[seq��ncias][13]++;
			
				// Setor
				if (visitante.Visita.Setor != null)
				{
					for (int i = 0; i < seq��ncias - 1; i++)
					{
						if (gr�ficoVisitantes14Dias.Legendas[i] == visitante.Visita.Setor)
						{
							double [][] dados = gr�ficoVisitantes14Dias.Dados;

							dados[i][13]++;

							gr�ficoVisitantes14Dias.Dados = dados;

							break;
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		/// <summary>
		/// Acrescenta tempo em que cliente esperou por atendimento
		/// </summary>
		private void AcrescentarEspera(IVisitante visitante)
		{
			AcrescentarEspera(visitante, visitante.Visita.Espera.Seconds / 60f);
		}

		/// <summary>
		/// Acrescenta tempo em que cliente esperou por atendimento
		/// </summary>
		private void AcrescentarEspera(IVisitante visitante, double minutos)
		{
			for (int i = 0; i < gr�ficoEsperaXVisitantes.Legendas.Length; i++)
			{
				if (gr�ficoEsperaXVisitantes.Legendas[i] == visitante.Visita.Setor)
				{
					double [][] dados;

					dados = gr�ficoEsperaXVisitantes.Dados;

					for (int j = 1; j < gr�ficoEsperaXVisitantes.Dados[i].Length; j++)
						dados[i][j - 1] = gr�ficoEsperaXVisitantes.Dados[i][j];

					dados[i][gr�ficoEsperaXVisitantes.Dados[i].Length - 1] = minutos;

					gr�ficoEsperaXVisitantes.Dados = dados;
				}
			}
		}

		#endregion

		/// <summary>
		/// Recupera do banco de dados as informa��es para
		/// constru��o de gr�ficos
		/// </summary>
		private void ConstruirGr�ficos()
		{
			ConstruirGr�ficoVisitantesDi�rios();
			ConstruirGr�ficoEsperaAtendimento();
		}

		/// <summary>
		/// Constr�i gr�fico de visitantes di�rios
		/// </summary>
		private void ConstruirGr�ficoVisitantesDi�rios()
		{
			/*
			Ind�stria_Mineira_de_J�ias.An�liseEstat�stica.Visitantes visitantes;
			DateTime  in�cio;
			string [] legenda;
			const int dias = 14;

			// Atribui��es
			visitantes = controle.Estat�sticaVisitantes;
			in�cio     = DateTime.Now.Date.Subtract(new TimeSpan(dias - 1, 0, 0, 0 ,0));

			// Recupera��o de dados
			gr�ficoVisitantes14Dias.Dados = visitantes.ObterVisitantesDi�riosSetor(
				in�cio, DateTime.Now, out legenda);
			gr�ficoVisitantes14Dias.Legendas = legenda;
			*/
		}

		/// <summary>
		/// Constr�i gr�fico de espera por atendimentos
		/// </summary>
		private void ConstruirGr�ficoEsperaAtendimento()
		{
/*			Ind�stria_Mineira_de_J�ias.An�liseEstat�stica.Visitantes visitantes;
			const int nVisitantes = 15;
			string [] legenda;

			visitantes = controle.Estat�sticaVisitantes;

			gr�ficoEsperaXVisitantes.Dados = visitantes.ObterEspera(nVisitantes, out legenda);
			gr�ficoEsperaXVisitantes.Legendas = legenda;
*/		}
	}
}
