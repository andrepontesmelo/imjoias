using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Negócio.Controle;
using Entidades;
using Observador;
using Negócio.Observador;
using Negócio;

namespace Administração.Bases.Relatório
{
	/// <summary>
	/// Summary description for ResumoAtual.
	/// </summary>
	public class ResumoAtual : System.Windows.Forms.UserControl
	{
		private IAdministração		controle;
		private EventoObservação	observaçãoVisitante;

		// Designer
		private Apresentação.Formulários.Quadro quadroEsperaXVisitantes;
		private Apresentação.Formulários.Quadro quadroVisitantes14Dias;
		private Estatística.Gráfico gráficoVisitantes14Dias;
		private Estatística.Legenda legendaVisitantes14Dias;
		private Estatística.Gráfico gráficoEsperaXVisitantes;
		private Estatística.Legenda legendaEsperaXVisitantes;
		private Apresentação.Formulários.Quadro quadroMédiaHorária;
		private Estatística.Gráfico gráficoMédiaHorária;
		private System.Windows.Forms.Label label1;
		private Apresentação.Formulários.Quadro quadroMotivo;
		private Estatística.Gráfico gráficoMotivo;
		private Estatística.Legenda legendaMotivo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResumoAtual()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Observação
			observaçãoVisitante = new EventoObservação(ObservaçãoVisitante);

			// Gráfico
//			gráficoVisitantes14Dias.ValorX += new Estatística.Desenhista.ConversãoValor(gráficoVisitantes14Dias_ValorX);
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
					((IControle) controle).ObservaçãoVisitante -= observaçãoVisitante;
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
			this.quadroVisitantes14Dias = new Apresentação.Formulários.Quadro();
			this.legendaVisitantes14Dias = new Estatística.Legenda();
			this.gráficoVisitantes14Dias = new Estatística.Gráfico();
			this.quadroEsperaXVisitantes = new Apresentação.Formulários.Quadro();
			this.legendaEsperaXVisitantes = new Estatística.Legenda();
			this.gráficoEsperaXVisitantes = new Estatística.Gráfico();
			this.quadroMédiaHorária = new Apresentação.Formulários.Quadro();
			this.label1 = new System.Windows.Forms.Label();
			this.gráficoMédiaHorária = new Estatística.Gráfico();
			this.quadroMotivo = new Apresentação.Formulários.Quadro();
			this.legendaMotivo = new Estatística.Legenda();
			this.gráficoMotivo = new Estatística.Gráfico();
			this.quadroVisitantes14Dias.SuspendLayout();
			this.quadroEsperaXVisitantes.SuspendLayout();
			this.quadroMédiaHorária.SuspendLayout();
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
			this.quadroVisitantes14Dias.Controls.Add(this.gráficoVisitantes14Dias);
			this.quadroVisitantes14Dias.Cor = System.Drawing.Color.Black;
			this.quadroVisitantes14Dias.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroVisitantes14Dias.LetraTítulo = System.Drawing.Color.White;
			this.quadroVisitantes14Dias.Location = new System.Drawing.Point(0, 0);
			this.quadroVisitantes14Dias.Name = "quadroVisitantes14Dias";
			this.quadroVisitantes14Dias.Size = new System.Drawing.Size(288, 208);
			this.quadroVisitantes14Dias.TabIndex = 0;
			this.quadroVisitantes14Dias.Tamanho = 30;
			this.quadroVisitantes14Dias.Título = "Crescimento de visitantes nos últimos 14 dias";
			// 
			// legendaVisitantes14Dias
			// 
			this.legendaVisitantes14Dias.AutoSize = false;
			this.legendaVisitantes14Dias.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaVisitantes14Dias.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaVisitantes14Dias.Colunas = 2;
			this.legendaVisitantes14Dias.Distanciamento = 2;
			this.legendaVisitantes14Dias.Espaçamento = 5;
			this.legendaVisitantes14Dias.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.legendaVisitantes14Dias.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaVisitantes14Dias.Gráfico = this.gráficoVisitantes14Dias;
			this.legendaVisitantes14Dias.Location = new System.Drawing.Point(16, 168);
			this.legendaVisitantes14Dias.Name = "legendaVisitantes14Dias";
			this.legendaVisitantes14Dias.QuadradoTamanho = 4;
			this.legendaVisitantes14Dias.Size = new System.Drawing.Size(256, 32);
			this.legendaVisitantes14Dias.TabIndex = 4;
			// 
			// gráficoVisitantes14Dias
			// 
			this.gráficoVisitantes14Dias.BackColor = System.Drawing.Color.Transparent;
			this.gráficoVisitantes14Dias.Dados = null;
			this.gráficoVisitantes14Dias.EixoX = "Dias";
			this.gráficoVisitantes14Dias.EixoY = "Pessoas";
			this.gráficoVisitantes14Dias.EstiloDesenho = Estatística.Estilo.LinhasVértices;
			this.gráficoVisitantes14Dias.ForçarEscritaValoresX = false;
			this.gráficoVisitantes14Dias.FundoCor = System.Drawing.Color.Transparent;
			this.gráficoVisitantes14Dias.GapHorizontal = 15;
			this.gráficoVisitantes14Dias.GapVertical = 20;
			this.gráficoVisitantes14Dias.GradeHorizontal = true;
			this.gráficoVisitantes14Dias.GradeVertical = true;
			this.gráficoVisitantes14Dias.Legendas = null;
			this.gráficoVisitantes14Dias.Location = new System.Drawing.Point(16, 32);
			this.gráficoVisitantes14Dias.MaxX = 13;
			this.gráficoVisitantes14Dias.MaxY = 0;
			this.gráficoVisitantes14Dias.MinX = 0;
			this.gráficoVisitantes14Dias.MinY = 0;
			this.gráficoVisitantes14Dias.Name = "gráficoVisitantes14Dias";
			this.gráficoVisitantes14Dias.Size = new System.Drawing.Size(264, 128);
			this.gráficoVisitantes14Dias.TabIndex = 1;
			this.gráficoVisitantes14Dias.ValoresX = true;
			this.gráficoVisitantes14Dias.ValoresY = true;
			this.gráficoVisitantes14Dias.VérticeTamanho = 5F;
			this.gráficoVisitantes14Dias.VetorÚnico = null;
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
			this.quadroEsperaXVisitantes.Controls.Add(this.gráficoEsperaXVisitantes);
			this.quadroEsperaXVisitantes.Cor = System.Drawing.Color.Black;
			this.quadroEsperaXVisitantes.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroEsperaXVisitantes.LetraTítulo = System.Drawing.Color.White;
			this.quadroEsperaXVisitantes.Location = new System.Drawing.Point(304, 0);
			this.quadroEsperaXVisitantes.Name = "quadroEsperaXVisitantes";
			this.quadroEsperaXVisitantes.Size = new System.Drawing.Size(288, 208);
			this.quadroEsperaXVisitantes.TabIndex = 1;
			this.quadroEsperaXVisitantes.Tamanho = 30;
			this.quadroEsperaXVisitantes.Título = "Espera por atendimento na recepção pelos últimos 15 visitantes por setor";
			// 
			// legendaEsperaXVisitantes
			// 
			this.legendaEsperaXVisitantes.AutoSize = false;
			this.legendaEsperaXVisitantes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaEsperaXVisitantes.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaEsperaXVisitantes.Colunas = 2;
			this.legendaEsperaXVisitantes.Distanciamento = 2;
			this.legendaEsperaXVisitantes.Espaçamento = 5;
			this.legendaEsperaXVisitantes.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.legendaEsperaXVisitantes.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaEsperaXVisitantes.Gráfico = this.gráficoEsperaXVisitantes;
			this.legendaEsperaXVisitantes.Location = new System.Drawing.Point(16, 168);
			this.legendaEsperaXVisitantes.Name = "legendaEsperaXVisitantes";
			this.legendaEsperaXVisitantes.QuadradoTamanho = 4;
			this.legendaEsperaXVisitantes.Size = new System.Drawing.Size(256, 32);
			this.legendaEsperaXVisitantes.TabIndex = 2;
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
			this.gráficoEsperaXVisitantes.Size = new System.Drawing.Size(272, 128);
			this.gráficoEsperaXVisitantes.TabIndex = 1;
			this.gráficoEsperaXVisitantes.ValoresX = false;
			this.gráficoEsperaXVisitantes.ValoresY = true;
			this.gráficoEsperaXVisitantes.VérticeTamanho = 5F;
			this.gráficoEsperaXVisitantes.VetorÚnico = null;
			// 
			// quadroMédiaHorária
			// 
			this.quadroMédiaHorária.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.quadroMédiaHorária.BackColor = System.Drawing.Color.Beige;
			this.quadroMédiaHorária.bInfDirArredondada = true;
			this.quadroMédiaHorária.bInfEsqArredondada = true;
			this.quadroMédiaHorária.bSupDirArredondada = true;
			this.quadroMédiaHorária.bSupEsqArredondada = true;
			this.quadroMédiaHorária.Controls.Add(this.label1);
			this.quadroMédiaHorária.Controls.Add(this.gráficoMédiaHorária);
			this.quadroMédiaHorária.Cor = System.Drawing.Color.Black;
			this.quadroMédiaHorária.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroMédiaHorária.LetraTítulo = System.Drawing.Color.White;
			this.quadroMédiaHorária.Location = new System.Drawing.Point(0, 224);
			this.quadroMédiaHorária.Name = "quadroMédiaHorária";
			this.quadroMédiaHorária.Size = new System.Drawing.Size(288, 208);
			this.quadroMédiaHorária.TabIndex = 2;
			this.quadroMédiaHorária.Tamanho = 30;
			this.quadroMédiaHorária.Título = "Média de visitantes nos últimos 14 dias*";
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
			// gráficoMédiaHorária
			// 
			this.gráficoMédiaHorária.BackColor = System.Drawing.Color.Transparent;
			this.gráficoMédiaHorária.Dados = null;
			this.gráficoMédiaHorária.EixoX = "Horas";
			this.gráficoMédiaHorária.EixoY = "Pessoas";
			this.gráficoMédiaHorária.EstiloDesenho = Estatística.Estilo.Barras;
			this.gráficoMédiaHorária.ForçarEscritaValoresX = false;
			this.gráficoMédiaHorária.FundoCor = System.Drawing.Color.Transparent;
			this.gráficoMédiaHorária.GapHorizontal = 0;
			this.gráficoMédiaHorária.GapVertical = 20;
			this.gráficoMédiaHorária.GradeHorizontal = true;
			this.gráficoMédiaHorária.GradeVertical = false;
			this.gráficoMédiaHorária.Legendas = null;
			this.gráficoMédiaHorária.Location = new System.Drawing.Point(16, 32);
			this.gráficoMédiaHorária.MaxX = 23;
			this.gráficoMédiaHorária.MaxY = 2;
			this.gráficoMédiaHorária.MinX = 0;
			this.gráficoMédiaHorária.MinY = 0;
			this.gráficoMédiaHorária.Name = "gráficoMédiaHorária";
			this.gráficoMédiaHorária.Size = new System.Drawing.Size(264, 144);
			this.gráficoMédiaHorária.TabIndex = 1;
			this.gráficoMédiaHorária.ValoresX = true;
			this.gráficoMédiaHorária.ValoresY = true;
			this.gráficoMédiaHorária.VérticeTamanho = 5F;
			this.gráficoMédiaHorária.VetorÚnico = null;
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
			this.quadroMotivo.Controls.Add(this.gráficoMotivo);
			this.quadroMotivo.Cor = System.Drawing.Color.Black;
			this.quadroMotivo.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroMotivo.LetraTítulo = System.Drawing.Color.White;
			this.quadroMotivo.Location = new System.Drawing.Point(304, 224);
			this.quadroMotivo.Name = "quadroMotivo";
			this.quadroMotivo.Size = new System.Drawing.Size(288, 208);
			this.quadroMotivo.TabIndex = 3;
			this.quadroMotivo.Tamanho = 30;
			this.quadroMotivo.Título = "Motivo das visitas nos últimos 14 dias";
			// 
			// legendaMotivo
			// 
			this.legendaMotivo.AutoSize = false;
			this.legendaMotivo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaMotivo.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaMotivo.Colunas = 3;
			this.legendaMotivo.Distanciamento = 2;
			this.legendaMotivo.Espaçamento = 5;
			this.legendaMotivo.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.legendaMotivo.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaMotivo.Gráfico = this.gráficoMotivo;
			this.legendaMotivo.Location = new System.Drawing.Point(16, 152);
			this.legendaMotivo.Name = "legendaMotivo";
			this.legendaMotivo.QuadradoTamanho = 4;
			this.legendaMotivo.Size = new System.Drawing.Size(256, 48);
			this.legendaMotivo.TabIndex = 2;
			// 
			// gráficoMotivo
			// 
			this.gráficoMotivo.BackColor = System.Drawing.Color.Transparent;
			this.gráficoMotivo.Dados = null;
			this.gráficoMotivo.EixoX = "Horas";
			this.gráficoMotivo.EixoY = "Pessoas";
			this.gráficoMotivo.EstiloDesenho = Estatística.Estilo.Pizza;
			this.gráficoMotivo.ForçarEscritaValoresX = false;
			this.gráficoMotivo.FundoCor = System.Drawing.Color.Transparent;
			this.gráficoMotivo.GapHorizontal = 0;
			this.gráficoMotivo.GapVertical = 20;
			this.gráficoMotivo.GradeHorizontal = true;
			this.gráficoMotivo.GradeVertical = true;
			this.gráficoMotivo.Legendas = null;
			this.gráficoMotivo.Location = new System.Drawing.Point(16, 32);
			this.gráficoMotivo.MaxX = -1;
			this.gráficoMotivo.MaxY = 0;
			this.gráficoMotivo.MinX = 0;
			this.gráficoMotivo.MinY = 0;
			this.gráficoMotivo.Name = "gráficoMotivo";
			this.gráficoMotivo.Size = new System.Drawing.Size(264, 120);
			this.gráficoMotivo.TabIndex = 1;
			this.gráficoMotivo.ValoresX = true;
			this.gráficoMotivo.ValoresY = true;
			this.gráficoMotivo.VérticeTamanho = 5F;
			this.gráficoMotivo.VetorÚnico = null;
			// 
			// ResumoAtual
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.quadroMotivo);
			this.Controls.Add(this.quadroMédiaHorária);
			this.Controls.Add(this.quadroEsperaXVisitantes);
			this.Controls.Add(this.quadroVisitantes14Dias);
			this.Name = "ResumoAtual";
			this.Size = new System.Drawing.Size(592, 440);
			this.quadroVisitantes14Dias.ResumeLayout(false);
			this.quadroEsperaXVisitantes.ResumeLayout(false);
			this.quadroMédiaHorária.ResumeLayout(false);
			this.quadroMotivo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public IAdministração Controle
		{
			get { return controle; }
			set
			{
				controle = value;

//				AnalisarVisitantes14Dias();
//				AnalisarEsperaXVisitantes();
				ConstruirGráficos();

				// Tratar eventos
				((IControle) controle).Preparar();
				((IControle) controle).ObservaçãoVisitante += observaçãoVisitante;
			}
		}

		#region Observação

		/// <summary>
		/// Observa ação de visitantes
		/// </summary>
		public void ObservaçãoVisitante(ISujeito sujeito, int ação, object obj)
		{
			try
			{
				switch ((AçãoVisitante) ação)
				{
					case AçãoVisitante.Entrou:
						AcrescentarVisitante((IVisitante) sujeito);
						break;

					case AçãoVisitante.Desistiu:
						AcrescentarEspera((IVisitante) sujeito);
						break;

					case AçãoVisitante.TérminoEspera:
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

		#region Análise de dados para construção de gráficos

		/// <summary>
		/// Analisa dados de visitantes para montar gráfico
		/// </summary>
		private void AnalisarVisitantes14Dias()
		{
			const int	dias = 14;
			double [][] diário;
			double []	médiaHorária;
			DateTime	início;
			ArrayList	visitas;
			ArrayList	strSetores;
			ArrayList	setores;
			double []	dadosMotivo = new double[Enum.GetNames(typeof(MotivoContato)).Length];
			int []		valoresEnumMotivo = (int []) Enum.GetValues(typeof(MotivoContato));

			// Considerando o dia de hoje, dias - 1
			início		 = DateTime.Now.Date.Subtract(new TimeSpan(dias - 1, 0, 0, 0 ,0));
			visitas = controle.ObterVisitas(início, DateTime.Now);

			if (visitas.Count == 0)
				return;

			strSetores	 = new ArrayList();
			setores		 = new ArrayList();
			médiaHorária = new double[24];
			
			// Obter setores de atendimento
			foreach (Negócio.ISetor setor in controle.ObterSetores())
				if (setor.Dados.Atendimento)
					setores.Add(setor);

			setores.Sort();

			foreach (Negócio.ISetor setor in setores)
				strSetores.Add(setor.Dados.Nome);

			strSetores.Add("Total");

			// Considerar mais um setor para a soma total
			diário = new double[setores.Count + 1][];

			for (int i = 0; i <= setores.Count; i++)
				diário[i] = new double[dias];

			// Construir média
			foreach (Visita visita in visitas)
			{
				TimeSpan dif = DateTime.Now.Date - visita.Entrada.Date;
				int dia = dias - 1 - dif.Days;

				// Gráfico de visitantes
				if (visita.Setor != null)
				{
					int p = setores.BinarySearch(visita.Setor);

					if (p >= 0)
						diário[p][dia]++;
				}

				diário[setores.Count][dia]++;

				// Gráfico de média horária
				if (visita.Entrada.Date != DateTime.Now.Date)		// O dia atual é desconsiderado
					médiaHorária[visita.Entrada.Hour] += 1f / dias;

				// Gráfico de motivo de visita
				for (int i = 0; i < valoresEnumMotivo.Length; i++)
					if ((((int) visita.Motivo) & valoresEnumMotivo[i]) > 0)
						dadosMotivo[i]++;
					else if ((int) visita.Motivo == (int) MotivoContato.Desconhecido)
						dadosMotivo[0]++;
			}

			gráficoVisitantes14Dias.Dados = diário;
			gráficoVisitantes14Dias.Legendas = (string []) strSetores.ToArray(typeof(string));

			gráficoMédiaHorária.VetorÚnico = médiaHorária;

			gráficoMotivo.VetorÚnico = dadosMotivo;
			gráficoMotivo.Legendas = Enum.GetNames(typeof(MotivoContato));
		}

		private void AnalisarEsperaXVisitantes()
		{
			const int   nVisitantes = 15;
			double [][] dados;
			ArrayList   setores = new ArrayList();
			string []	legenda;

			// Obter setores de atendimento
			foreach (Negócio.ISetor setor in controle.ObterSetores())
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
				setor    = ((Negócio.ISetor) setores[i]);
				esperas  = controle.ObterEsperas(nVisitantes, setor.Dados.Código);
				legenda[i] = setor.Dados.Nome;

				// Preencher dados
				for (int j = nVisitantes - 1; j >= nVisitantes - esperas.Length; j--)
					dados[i][j] = esperas[nVisitantes - j - 1];
			}

			gráficoEsperaXVisitantes.Dados = dados;
			gráficoEsperaXVisitantes.Legendas = legenda;
		}

		#endregion

		#region Gráficos/Atualização de gráficos

		/// <summary>
		/// Legenda dos valores no eixo X do gráfico de visitantes
		/// </summary>
		private string gráficoVisitantes14Dias_ValorX(double valor)
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
				int seqüências = gráficoVisitantes14Dias.Dados.Length - 1;

				// Total
				gráficoVisitantes14Dias.Dados[seqüências][13]++;
			
				// Setor
				if (visitante.Visita.Setor != null)
				{
					for (int i = 0; i < seqüências - 1; i++)
					{
						if (gráficoVisitantes14Dias.Legendas[i] == visitante.Visita.Setor)
						{
							double [][] dados = gráficoVisitantes14Dias.Dados;

							dados[i][13]++;

							gráficoVisitantes14Dias.Dados = dados;

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
			for (int i = 0; i < gráficoEsperaXVisitantes.Legendas.Length; i++)
			{
				if (gráficoEsperaXVisitantes.Legendas[i] == visitante.Visita.Setor)
				{
					double [][] dados;

					dados = gráficoEsperaXVisitantes.Dados;

					for (int j = 1; j < gráficoEsperaXVisitantes.Dados[i].Length; j++)
						dados[i][j - 1] = gráficoEsperaXVisitantes.Dados[i][j];

					dados[i][gráficoEsperaXVisitantes.Dados[i].Length - 1] = minutos;

					gráficoEsperaXVisitantes.Dados = dados;
				}
			}
		}

		#endregion

		/// <summary>
		/// Recupera do banco de dados as informações para
		/// construção de gráficos
		/// </summary>
		private void ConstruirGráficos()
		{
			ConstruirGráficoVisitantesDiários();
			ConstruirGráficoEsperaAtendimento();
		}

		/// <summary>
		/// Constrói gráfico de visitantes diários
		/// </summary>
		private void ConstruirGráficoVisitantesDiários()
		{
			/*
			Indústria_Mineira_de_Jóias.AnáliseEstatística.Visitantes visitantes;
			DateTime  início;
			string [] legenda;
			const int dias = 14;

			// Atribuições
			visitantes = controle.EstatísticaVisitantes;
			início     = DateTime.Now.Date.Subtract(new TimeSpan(dias - 1, 0, 0, 0 ,0));

			// Recuperação de dados
			gráficoVisitantes14Dias.Dados = visitantes.ObterVisitantesDiáriosSetor(
				início, DateTime.Now, out legenda);
			gráficoVisitantes14Dias.Legendas = legenda;
			*/
		}

		/// <summary>
		/// Constrói gráfico de espera por atendimentos
		/// </summary>
		private void ConstruirGráficoEsperaAtendimento()
		{
/*			Indústria_Mineira_de_Jóias.AnáliseEstatística.Visitantes visitantes;
			const int nVisitantes = 15;
			string [] legenda;

			visitantes = controle.EstatísticaVisitantes;

			gráficoEsperaXVisitantes.Dados = visitantes.ObterEspera(nVisitantes, out legenda);
			gráficoEsperaXVisitantes.Legendas = legenda;
*/		}
	}
}
