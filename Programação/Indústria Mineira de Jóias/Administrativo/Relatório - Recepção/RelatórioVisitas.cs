using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Negócio;

using Entidades;
using Entidades.Pessoa;

using Apresentação.Formulários;

namespace Relatório.Recepção
{
	public class RelatórioVisitas : Apresentação.Formulários.JanelaExplicativa, IComparer
	{
		private Hashtable	linhas;
		private ArrayList	visitas;
		private int			pessoas;
		private	DateTime	início;
		private DateTime	final;
		private Hashtable	valorXGráficoDistDiária = new Hashtable();
		private ArrayList	strSetores = new ArrayList();

		// Designer
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TabPage tabLista;
		private System.Windows.Forms.ListView lstVisitantes;
		private System.Windows.Forms.ColumnHeader colVisitante;
		private System.Windows.Forms.ColumnHeader colMotivo;
		private System.Windows.Forms.ColumnHeader colSetor;
		private System.Windows.Forms.ColumnHeader colAtendente;
		private System.Windows.Forms.ColumnHeader colEntrada;
		private System.Windows.Forms.ColumnHeader colSaída;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage tabDistHorária;
		private System.Windows.Forms.TabPage tabDistDiária;
		private Estatística.Gráfico gráficoDistHorária;
		private Estatística.Gráfico gráficoDistDiária;
		private System.Windows.Forms.TabPage tabSetor;
		private System.Windows.Forms.TabPage tabMotivo;
		private Estatística.Gráfico gráficoDistSetor;
		private Estatística.Legenda legendaDistSetor;
		private System.Windows.Forms.ImageList imgs;
		private System.Windows.Forms.TabPage tabSetor2;
		private Estatística.Gráfico gráficoDistSetor2;
		private System.Windows.Forms.TabPage tabSetores3;
		private System.Windows.Forms.TabPage tabMotivo2;
		private System.Windows.Forms.TabPage tabMotivo3;
		private Estatística.Gráfico gráficoDistMotivoBarra;
		private Estatística.Gráfico gráficoDistMotivoDias;
		private Estatística.Legenda legendaDistMotivoDias;
		private Estatística.Gráfico gráficoPizzaSetores;
		private Estatística.Gráfico gráficoPizzaMotivo;
		private Estatística.Legenda legendaGráficoPizzaSetores;
		private Estatística.Legenda legendaGráficoPizzaMotivo;
		private System.ComponentModel.IContainer components = null;

		public RelatórioVisitas(Negócio.Controle.IControle controle, DateTime início, DateTime término, string descrição)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Aguarde aguarde;

			aguarde = new Aguarde("Recuperando informações do banco de dados...", 5);
			aguarde.Show();
			aguarde.Refresh();

			this.SuspendLayout();

			lblDescrição.Text = descrição;

			this.ResumeLayout();

			visitas = controle.ObterVisitas(início, término);

			linhas = new Hashtable(visitas.Count);

			// Construir lista
			aguarde.Passo("Construindo lista de visitantes...");

			foreach (Visita visita in visitas)
			{
				foreach (Pessoa p in visita.Pessoas)
				{
					InserirLinha(visita, p.Nome);
					pessoas++;
				}

				foreach (string n in visita.Nomes)
				{
					InserirLinha(visita, n);
					pessoas++;
				}
			}

//			this.visitas = (ArrayList) visitas.Clone();

			this.início = início;
			this.final = término;

//			gráficoDistDiária.ValorX += new Estatística.Desenhista.ConversãoValor(gráficoDistDiária_ValorX);
//			gráficoDistSetor.ValorX += new Estatística.Desenhista.ConversãoValor(gráficoDistDiária_ValorX);
//			gráficoDistSetor2.ValorX += new Estatística.Desenhista.ConversãoValor(gráficoDistSetor2_ValorX);
//			gráficoDistMotivoDias.ValorX += new Estatística.Desenhista.ConversãoValor(gráficoDistDiária_ValorX);
//			gráficoDistMotivoBarra.ValorX += new Estatística.Desenhista.ConversãoValor(gráficoDistMotivoBarra_ValorX);

			aguarde.Passo("Construindo distribuição média horária...");
			ConstruirDistMédiaHorária();

			aguarde.Passo("Construindo distribuição por setor...");
			ConstruirDistSetor();

			aguarde.Passo("Construindo distribuição por motivos...");
			ConstruirDistMotivo();

			aguarde.Close();
			aguarde.Dispose();
		}

		private void InserirLinha(Visita visita, string nome)
		{
			ListViewItem ítem = new ListViewItem(nome);

			ítem.SubItems.Add(visita.MotivoTexto);

			ítem.SubItems.Add(visita.Setor);

			string atendimentos = "";

			foreach (VisitaAtendimento va in visita.Atendimentos)
			{
				if (atendimentos.Length == 0)
					atendimentos = va.Funcionário.Nome;
				else
					atendimentos += ", " + va.Funcionário.Nome;
			}

			ítem.SubItems.Add(atendimentos);

			ítem.SubItems.Add(visita.Entrada.ToLongTimeString());

			if (!visita.NaEmpresa)
				ítem.SubItems.Add(visita.Saída.ToLongTimeString());
			else
				ítem.SubItems.Add("");

			lstVisitantes.Items.Add(ítem);

			linhas[ítem] = visita;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RelatórioVisitas));
			this.cmdOK = new System.Windows.Forms.Button();
			this.tab = new System.Windows.Forms.TabControl();
			this.tabLista = new System.Windows.Forms.TabPage();
			this.lstVisitantes = new System.Windows.Forms.ListView();
			this.colVisitante = new System.Windows.Forms.ColumnHeader();
			this.colMotivo = new System.Windows.Forms.ColumnHeader();
			this.colSetor = new System.Windows.Forms.ColumnHeader();
			this.colAtendente = new System.Windows.Forms.ColumnHeader();
			this.colEntrada = new System.Windows.Forms.ColumnHeader();
			this.colSaída = new System.Windows.Forms.ColumnHeader();
			this.tabDistHorária = new System.Windows.Forms.TabPage();
			this.gráficoDistHorária = new Estatística.Gráfico();
			this.tabSetor2 = new System.Windows.Forms.TabPage();
			this.gráficoDistSetor2 = new Estatística.Gráfico();
			this.tabMotivo2 = new System.Windows.Forms.TabPage();
			this.gráficoDistMotivoBarra = new Estatística.Gráfico();
			this.tabDistDiária = new System.Windows.Forms.TabPage();
			this.gráficoDistDiária = new Estatística.Gráfico();
			this.tabSetor = new System.Windows.Forms.TabPage();
			this.legendaDistSetor = new Estatística.Legenda();
			this.gráficoDistSetor = new Estatística.Gráfico();
			this.tabMotivo = new System.Windows.Forms.TabPage();
			this.legendaDistMotivoDias = new Estatística.Legenda();
			this.gráficoDistMotivoDias = new Estatística.Gráfico();
			this.tabSetores3 = new System.Windows.Forms.TabPage();
			this.legendaGráficoPizzaSetores = new Estatística.Legenda();
			this.gráficoPizzaSetores = new Estatística.Gráfico();
			this.tabMotivo3 = new System.Windows.Forms.TabPage();
			this.legendaGráficoPizzaMotivo = new Estatística.Legenda();
			this.gráficoPizzaMotivo = new Estatística.Gráfico();
			this.imgs = new System.Windows.Forms.ImageList(this.components);
			this.tab.SuspendLayout();
			this.tabLista.SuspendLayout();
			this.tabDistHorária.SuspendLayout();
			this.tabSetor2.SuspendLayout();
			this.tabMotivo2.SuspendLayout();
			this.tabDistDiária.SuspendLayout();
			this.tabSetor.SuspendLayout();
			this.tabMotivo.SuspendLayout();
			this.tabSetores3.SuspendLayout();
			this.tabMotivo3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(178, 22);
			this.lblTítulo.Text = "Relatório de Visitantes";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(11570, 40);
			this.lblDescrição.Text = "Visualize aqui os visitantes que estiveram na empresa.";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Location = new System.Drawing.Point(8, 16);
			this.picÍcone.Name = "picÍcone";
			this.picÍcone.Size = new System.Drawing.Size(56, 64);
			this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(534, 430);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 6;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// tab
			// 
			this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tab.Controls.Add(this.tabLista);
			this.tab.Controls.Add(this.tabDistHorária);
			this.tab.Controls.Add(this.tabSetor2);
			this.tab.Controls.Add(this.tabMotivo2);
			this.tab.Controls.Add(this.tabDistDiária);
			this.tab.Controls.Add(this.tabSetor);
			this.tab.Controls.Add(this.tabMotivo);
			this.tab.Controls.Add(this.tabSetores3);
			this.tab.Controls.Add(this.tabMotivo3);
			this.tab.ImageList = this.imgs;
			this.tab.Location = new System.Drawing.Point(8, 96);
			this.tab.Multiline = true;
			this.tab.Name = "tab";
			this.tab.SelectedIndex = 0;
			this.tab.Size = new System.Drawing.Size(598, 326);
			this.tab.TabIndex = 7;
			this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
			// 
			// tabLista
			// 
			this.tabLista.Controls.Add(this.lstVisitantes);
			this.tabLista.ImageIndex = 3;
			this.tabLista.Location = new System.Drawing.Point(4, 42);
			this.tabLista.Name = "tabLista";
			this.tabLista.Size = new System.Drawing.Size(590, 280);
			this.tabLista.TabIndex = 0;
			this.tabLista.Text = "Lista";
			// 
			// lstVisitantes
			// 
			this.lstVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstVisitantes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.colVisitante,
																							this.colMotivo,
																							this.colSetor,
																							this.colAtendente,
																							this.colEntrada,
																							this.colSaída});
			this.lstVisitantes.FullRowSelect = true;
			this.lstVisitantes.GridLines = true;
			this.lstVisitantes.Location = new System.Drawing.Point(8, 8);
			this.lstVisitantes.MultiSelect = false;
			this.lstVisitantes.Name = "lstVisitantes";
			this.lstVisitantes.Size = new System.Drawing.Size(574, 266);
			this.lstVisitantes.TabIndex = 6;
			this.lstVisitantes.View = System.Windows.Forms.View.Details;
			this.lstVisitantes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVisitantes_ColumnClick);
			// 
			// colVisitante
			// 
			this.colVisitante.Text = "Visitante";
			this.colVisitante.Width = 176;
			// 
			// colMotivo
			// 
			this.colMotivo.Text = "Motivo";
			this.colMotivo.Width = 95;
			// 
			// colSetor
			// 
			this.colSetor.Text = "Setor";
			this.colSetor.Width = 67;
			// 
			// colAtendente
			// 
			this.colAtendente.Text = "Atendente";
			this.colAtendente.Width = 81;
			// 
			// colEntrada
			// 
			this.colEntrada.Text = "Entrada";
			// 
			// colSaída
			// 
			this.colSaída.Text = "Saída";
			// 
			// tabDistHorária
			// 
			this.tabDistHorária.BackColor = System.Drawing.Color.White;
			this.tabDistHorária.Controls.Add(this.gráficoDistHorária);
			this.tabDistHorária.ImageIndex = 0;
			this.tabDistHorária.Location = new System.Drawing.Point(4, 42);
			this.tabDistHorária.Name = "tabDistHorária";
			this.tabDistHorária.Size = new System.Drawing.Size(590, 280);
			this.tabDistHorária.TabIndex = 1;
			this.tabDistHorária.Text = "Média horária";
			// 
			// gráficoDistHorária
			// 
			this.gráficoDistHorária.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoDistHorária.BackColor = System.Drawing.Color.White;
			this.gráficoDistHorária.Dados = null;
			this.gráficoDistHorária.EixoX = "Horas";
			this.gráficoDistHorária.EixoY = "Pessoas";
			this.gráficoDistHorária.EstiloDesenho = Estatística.Estilo.Barras;
			this.gráficoDistHorária.ForçarEscritaValoresX = false;
			this.gráficoDistHorária.FundoCor = System.Drawing.Color.White;
			this.gráficoDistHorária.GapHorizontal = 0;
			this.gráficoDistHorária.GapVertical = 20;
			this.gráficoDistHorária.GradeHorizontal = true;
			this.gráficoDistHorária.GradeVertical = true;
			this.gráficoDistHorária.Legendas = null;
			this.gráficoDistHorária.Location = new System.Drawing.Point(8, 8);
			this.gráficoDistHorária.MaxX = 24;
			this.gráficoDistHorária.MaxY = 2;
			this.gráficoDistHorária.MinX = 0;
			this.gráficoDistHorária.MinY = 0;
			this.gráficoDistHorária.Name = "gráficoDistHorária";
			this.gráficoDistHorária.Size = new System.Drawing.Size(574, 264);
			this.gráficoDistHorária.TabIndex = 0;
			this.gráficoDistHorária.ValoresX = true;
			this.gráficoDistHorária.ValoresY = true;
			this.gráficoDistHorária.VérticeTamanho = 5F;
			this.gráficoDistHorária.VetorÚnico = null;
			// 
			// tabSetor2
			// 
			this.tabSetor2.BackColor = System.Drawing.Color.White;
			this.tabSetor2.Controls.Add(this.gráficoDistSetor2);
			this.tabSetor2.ImageIndex = 0;
			this.tabSetor2.Location = new System.Drawing.Point(4, 42);
			this.tabSetor2.Name = "tabSetor2";
			this.tabSetor2.Size = new System.Drawing.Size(590, 280);
			this.tabSetor2.TabIndex = 5;
			this.tabSetor2.Text = "Distribuição por Setores";
			// 
			// gráficoDistSetor2
			// 
			this.gráficoDistSetor2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoDistSetor2.BackColor = System.Drawing.Color.White;
			this.gráficoDistSetor2.Dados = null;
			this.gráficoDistSetor2.EixoX = "Setores";
			this.gráficoDistSetor2.EixoY = "Pessoas";
			this.gráficoDistSetor2.EstiloDesenho = Estatística.Estilo.Barras;
			this.gráficoDistSetor2.ForçarEscritaValoresX = false;
			this.gráficoDistSetor2.FundoCor = System.Drawing.Color.White;
			this.gráficoDistSetor2.GapHorizontal = 0;
			this.gráficoDistSetor2.GapVertical = 20;
			this.gráficoDistSetor2.GradeHorizontal = true;
			this.gráficoDistSetor2.GradeVertical = true;
			this.gráficoDistSetor2.Legendas = null;
			this.gráficoDistSetor2.Location = new System.Drawing.Point(8, 8);
			this.gráficoDistSetor2.MaxX = -1;
			this.gráficoDistSetor2.MaxY = 2;
			this.gráficoDistSetor2.MinX = 0;
			this.gráficoDistSetor2.MinY = 0;
			this.gráficoDistSetor2.Name = "gráficoDistSetor2";
			this.gráficoDistSetor2.Size = new System.Drawing.Size(574, 264);
			this.gráficoDistSetor2.TabIndex = 0;
			this.gráficoDistSetor2.ValoresX = true;
			this.gráficoDistSetor2.ValoresY = true;
			this.gráficoDistSetor2.VérticeTamanho = 5F;
			this.gráficoDistSetor2.VetorÚnico = null;
			// 
			// tabMotivo2
			// 
			this.tabMotivo2.BackColor = System.Drawing.Color.White;
			this.tabMotivo2.Controls.Add(this.gráficoDistMotivoBarra);
			this.tabMotivo2.ImageIndex = 0;
			this.tabMotivo2.Location = new System.Drawing.Point(4, 42);
			this.tabMotivo2.Name = "tabMotivo2";
			this.tabMotivo2.Size = new System.Drawing.Size(590, 280);
			this.tabMotivo2.TabIndex = 7;
			this.tabMotivo2.Text = "Distribuição por Motivo";
			// 
			// gráficoDistMotivoBarra
			// 
			this.gráficoDistMotivoBarra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoDistMotivoBarra.BackColor = System.Drawing.Color.White;
			this.gráficoDistMotivoBarra.Dados = null;
			this.gráficoDistMotivoBarra.EixoX = "Motivo";
			this.gráficoDistMotivoBarra.EixoY = "Pessoas";
			this.gráficoDistMotivoBarra.EstiloDesenho = Estatística.Estilo.Barras;
			this.gráficoDistMotivoBarra.ForçarEscritaValoresX = true;
			this.gráficoDistMotivoBarra.FundoCor = System.Drawing.Color.White;
			this.gráficoDistMotivoBarra.GapHorizontal = 0;
			this.gráficoDistMotivoBarra.GapVertical = 20;
			this.gráficoDistMotivoBarra.GradeHorizontal = true;
			this.gráficoDistMotivoBarra.GradeVertical = true;
			this.gráficoDistMotivoBarra.Legendas = null;
			this.gráficoDistMotivoBarra.Location = new System.Drawing.Point(8, 8);
			this.gráficoDistMotivoBarra.MaxX = -1;
			this.gráficoDistMotivoBarra.MaxY = 0;
			this.gráficoDistMotivoBarra.MinX = 0;
			this.gráficoDistMotivoBarra.MinY = 0;
			this.gráficoDistMotivoBarra.Name = "gráficoDistMotivoBarra";
			this.gráficoDistMotivoBarra.Size = new System.Drawing.Size(576, 264);
			this.gráficoDistMotivoBarra.TabIndex = 0;
			this.gráficoDistMotivoBarra.ValoresX = true;
			this.gráficoDistMotivoBarra.ValoresY = true;
			this.gráficoDistMotivoBarra.VérticeTamanho = 5F;
			this.gráficoDistMotivoBarra.VetorÚnico = null;
			// 
			// tabDistDiária
			// 
			this.tabDistDiária.BackColor = System.Drawing.Color.White;
			this.tabDistDiária.Controls.Add(this.gráficoDistDiária);
			this.tabDistDiária.ImageIndex = 1;
			this.tabDistDiária.Location = new System.Drawing.Point(4, 42);
			this.tabDistDiária.Name = "tabDistDiária";
			this.tabDistDiária.Size = new System.Drawing.Size(590, 280);
			this.tabDistDiária.TabIndex = 2;
			this.tabDistDiária.Text = "Distribuição diária";
			// 
			// gráficoDistDiária
			// 
			this.gráficoDistDiária.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoDistDiária.BackColor = System.Drawing.Color.White;
			this.gráficoDistDiária.Dados = null;
			this.gráficoDistDiária.EixoX = "Dias";
			this.gráficoDistDiária.EixoY = "Pessoas";
			this.gráficoDistDiária.EstiloDesenho = Estatística.Estilo.Linhas;
			this.gráficoDistDiária.ForçarEscritaValoresX = false;
			this.gráficoDistDiária.FundoCor = System.Drawing.Color.White;
			this.gráficoDistDiária.GapHorizontal = 80;
			this.gráficoDistDiária.GapVertical = 20;
			this.gráficoDistDiária.GradeHorizontal = true;
			this.gráficoDistDiária.GradeVertical = true;
			this.gráficoDistDiária.Legendas = null;
			this.gráficoDistDiária.Location = new System.Drawing.Point(8, 8);
			this.gráficoDistDiária.MaxX = -1;
			this.gráficoDistDiária.MaxY = 0;
			this.gráficoDistDiária.MinX = 0;
			this.gráficoDistDiária.MinY = 0;
			this.gráficoDistDiária.Name = "gráficoDistDiária";
			this.gráficoDistDiária.Size = new System.Drawing.Size(574, 264);
			this.gráficoDistDiária.TabIndex = 0;
			this.gráficoDistDiária.ValoresX = true;
			this.gráficoDistDiária.ValoresY = true;
			this.gráficoDistDiária.VérticeTamanho = 5F;
			this.gráficoDistDiária.VetorÚnico = null;
			// 
			// tabSetor
			// 
			this.tabSetor.BackColor = System.Drawing.Color.White;
			this.tabSetor.Controls.Add(this.legendaDistSetor);
			this.tabSetor.Controls.Add(this.gráficoDistSetor);
			this.tabSetor.ImageIndex = 1;
			this.tabSetor.Location = new System.Drawing.Point(4, 42);
			this.tabSetor.Name = "tabSetor";
			this.tabSetor.Size = new System.Drawing.Size(590, 280);
			this.tabSetor.TabIndex = 3;
			this.tabSetor.Text = "Distribuição por Setor";
			// 
			// legendaDistSetor
			// 
			this.legendaDistSetor.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.legendaDistSetor.AutoSize = true;
			this.legendaDistSetor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistSetor.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaDistSetor.Distanciamento = 5;
			this.legendaDistSetor.Espaçamento = 10;
			this.legendaDistSetor.Fonte = new System.Drawing.Font("Arial", 9F);
			this.legendaDistSetor.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistSetor.Gráfico = this.gráficoDistSetor;
			this.legendaDistSetor.Location = new System.Drawing.Point(472, 96);
			this.legendaDistSetor.Name = "legendaDistSetor";
			this.legendaDistSetor.QuadradoTamanho = 9;
			this.legendaDistSetor.Size = new System.Drawing.Size(112, 56);
			this.legendaDistSetor.TabIndex = 1;
			// 
			// gráficoDistSetor
			// 
			this.gráficoDistSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoDistSetor.BackColor = System.Drawing.Color.White;
			this.gráficoDistSetor.Dados = null;
			this.gráficoDistSetor.EixoX = "Dias";
			this.gráficoDistSetor.EixoY = "Pessoas";
			this.gráficoDistSetor.EstiloDesenho = Estatística.Estilo.LinhasVértices;
			this.gráficoDistSetor.ForçarEscritaValoresX = false;
			this.gráficoDistSetor.FundoCor = System.Drawing.Color.White;
			this.gráficoDistSetor.GapHorizontal = 0;
			this.gráficoDistSetor.GapVertical = 20;
			this.gráficoDistSetor.GradeHorizontal = true;
			this.gráficoDistSetor.GradeVertical = true;
			this.gráficoDistSetor.Legendas = null;
			this.gráficoDistSetor.Location = new System.Drawing.Point(8, 8);
			this.gráficoDistSetor.MaxX = -1;
			this.gráficoDistSetor.MaxY = 10;
			this.gráficoDistSetor.MinX = 0;
			this.gráficoDistSetor.MinY = 0;
			this.gráficoDistSetor.Name = "gráficoDistSetor";
			this.gráficoDistSetor.Size = new System.Drawing.Size(472, 264);
			this.gráficoDistSetor.TabIndex = 0;
			this.gráficoDistSetor.ValoresX = true;
			this.gráficoDistSetor.ValoresY = true;
			this.gráficoDistSetor.VérticeTamanho = 5F;
			this.gráficoDistSetor.VetorÚnico = null;
			// 
			// tabMotivo
			// 
			this.tabMotivo.BackColor = System.Drawing.Color.White;
			this.tabMotivo.Controls.Add(this.legendaDistMotivoDias);
			this.tabMotivo.Controls.Add(this.gráficoDistMotivoDias);
			this.tabMotivo.ImageIndex = 1;
			this.tabMotivo.Location = new System.Drawing.Point(4, 42);
			this.tabMotivo.Name = "tabMotivo";
			this.tabMotivo.Size = new System.Drawing.Size(590, 280);
			this.tabMotivo.TabIndex = 4;
			this.tabMotivo.Text = "Distribuição por Motivo";
			// 
			// legendaDistMotivoDias
			// 
			this.legendaDistMotivoDias.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.legendaDistMotivoDias.AutoSize = true;
			this.legendaDistMotivoDias.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistMotivoDias.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaDistMotivoDias.Distanciamento = 2;
			this.legendaDistMotivoDias.Espaçamento = 5;
			this.legendaDistMotivoDias.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legendaDistMotivoDias.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistMotivoDias.Gráfico = this.gráficoDistMotivoDias;
			this.legendaDistMotivoDias.Location = new System.Drawing.Point(472, 56);
			this.legendaDistMotivoDias.Name = "legendaDistMotivoDias";
			this.legendaDistMotivoDias.QuadradoTamanho = 4;
			this.legendaDistMotivoDias.Size = new System.Drawing.Size(112, 80);
			this.legendaDistMotivoDias.TabIndex = 1;
			// 
			// gráficoDistMotivoDias
			// 
			this.gráficoDistMotivoDias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoDistMotivoDias.BackColor = System.Drawing.Color.White;
			this.gráficoDistMotivoDias.Dados = null;
			this.gráficoDistMotivoDias.EixoX = "Dias";
			this.gráficoDistMotivoDias.EixoY = "Pessoas";
			this.gráficoDistMotivoDias.EstiloDesenho = Estatística.Estilo.LinhasVértices;
			this.gráficoDistMotivoDias.ForçarEscritaValoresX = false;
			this.gráficoDistMotivoDias.FundoCor = System.Drawing.Color.White;
			this.gráficoDistMotivoDias.GapHorizontal = 0;
			this.gráficoDistMotivoDias.GapVertical = 20;
			this.gráficoDistMotivoDias.GradeHorizontal = true;
			this.gráficoDistMotivoDias.GradeVertical = true;
			this.gráficoDistMotivoDias.Legendas = null;
			this.gráficoDistMotivoDias.Location = new System.Drawing.Point(8, 8);
			this.gráficoDistMotivoDias.MaxX = -1;
			this.gráficoDistMotivoDias.MaxY = 10;
			this.gráficoDistMotivoDias.MinX = 0;
			this.gráficoDistMotivoDias.MinY = 0;
			this.gráficoDistMotivoDias.Name = "gráficoDistMotivoDias";
			this.gráficoDistMotivoDias.Size = new System.Drawing.Size(472, 264);
			this.gráficoDistMotivoDias.TabIndex = 0;
			this.gráficoDistMotivoDias.ValoresX = true;
			this.gráficoDistMotivoDias.ValoresY = true;
			this.gráficoDistMotivoDias.VérticeTamanho = 5F;
			this.gráficoDistMotivoDias.VetorÚnico = null;
			// 
			// tabSetores3
			// 
			this.tabSetores3.BackColor = System.Drawing.Color.White;
			this.tabSetores3.Controls.Add(this.legendaGráficoPizzaSetores);
			this.tabSetores3.Controls.Add(this.gráficoPizzaSetores);
			this.tabSetores3.ImageIndex = 2;
			this.tabSetores3.Location = new System.Drawing.Point(4, 42);
			this.tabSetores3.Name = "tabSetores3";
			this.tabSetores3.Size = new System.Drawing.Size(590, 280);
			this.tabSetores3.TabIndex = 6;
			this.tabSetores3.Text = "Distribuição por setores";
			// 
			// legendaGráficoPizzaSetores
			// 
			this.legendaGráficoPizzaSetores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.legendaGráficoPizzaSetores.AutoSize = true;
			this.legendaGráficoPizzaSetores.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGráficoPizzaSetores.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaGráficoPizzaSetores.Distanciamento = 2;
			this.legendaGráficoPizzaSetores.Espaçamento = 5;
			this.legendaGráficoPizzaSetores.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legendaGráficoPizzaSetores.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGráficoPizzaSetores.Gráfico = this.gráficoPizzaSetores;
			this.legendaGráficoPizzaSetores.Location = new System.Drawing.Point(424, 8);
			this.legendaGráficoPizzaSetores.Name = "legendaGráficoPizzaSetores";
			this.legendaGráficoPizzaSetores.QuadradoTamanho = 4;
			this.legendaGráficoPizzaSetores.Size = new System.Drawing.Size(160, 112);
			this.legendaGráficoPizzaSetores.TabIndex = 1;
			// 
			// gráficoPizzaSetores
			// 
			this.gráficoPizzaSetores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoPizzaSetores.BackColor = System.Drawing.Color.White;
			this.gráficoPizzaSetores.Dados = null;
			this.gráficoPizzaSetores.EixoX = "Eixo X";
			this.gráficoPizzaSetores.EixoY = "Eixo Y";
			this.gráficoPizzaSetores.EstiloDesenho = Estatística.Estilo.Pizza;
			this.gráficoPizzaSetores.ForçarEscritaValoresX = false;
			this.gráficoPizzaSetores.FundoCor = System.Drawing.Color.White;
			this.gráficoPizzaSetores.GapHorizontal = 0;
			this.gráficoPizzaSetores.GapVertical = 20;
			this.gráficoPizzaSetores.GradeHorizontal = true;
			this.gráficoPizzaSetores.GradeVertical = true;
			this.gráficoPizzaSetores.Legendas = null;
			this.gráficoPizzaSetores.Location = new System.Drawing.Point(8, 8);
			this.gráficoPizzaSetores.MaxX = -1;
			this.gráficoPizzaSetores.MaxY = 0;
			this.gráficoPizzaSetores.MinX = 0;
			this.gráficoPizzaSetores.MinY = 0;
			this.gráficoPizzaSetores.Name = "gráficoPizzaSetores";
			this.gráficoPizzaSetores.Size = new System.Drawing.Size(576, 264);
			this.gráficoPizzaSetores.TabIndex = 0;
			this.gráficoPizzaSetores.ValoresX = true;
			this.gráficoPizzaSetores.ValoresY = true;
			this.gráficoPizzaSetores.VérticeTamanho = 5F;
			this.gráficoPizzaSetores.VetorÚnico = null;
			// 
			// tabMotivo3
			// 
			this.tabMotivo3.BackColor = System.Drawing.Color.White;
			this.tabMotivo3.Controls.Add(this.legendaGráficoPizzaMotivo);
			this.tabMotivo3.Controls.Add(this.gráficoPizzaMotivo);
			this.tabMotivo3.ImageIndex = 2;
			this.tabMotivo3.Location = new System.Drawing.Point(4, 42);
			this.tabMotivo3.Name = "tabMotivo3";
			this.tabMotivo3.Size = new System.Drawing.Size(590, 280);
			this.tabMotivo3.TabIndex = 8;
			this.tabMotivo3.Text = "Distribuição por Motivo";
			// 
			// legendaGráficoPizzaMotivo
			// 
			this.legendaGráficoPizzaMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.legendaGráficoPizzaMotivo.AutoSize = true;
			this.legendaGráficoPizzaMotivo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGráficoPizzaMotivo.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaGráficoPizzaMotivo.Distanciamento = 2;
			this.legendaGráficoPizzaMotivo.Espaçamento = 5;
			this.legendaGráficoPizzaMotivo.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legendaGráficoPizzaMotivo.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGráficoPizzaMotivo.Gráfico = this.gráficoPizzaMotivo;
			this.legendaGráficoPizzaMotivo.Location = new System.Drawing.Point(424, 8);
			this.legendaGráficoPizzaMotivo.Name = "legendaGráficoPizzaMotivo";
			this.legendaGráficoPizzaMotivo.QuadradoTamanho = 4;
			this.legendaGráficoPizzaMotivo.Size = new System.Drawing.Size(160, 112);
			this.legendaGráficoPizzaMotivo.TabIndex = 1;
			// 
			// gráficoPizzaMotivo
			// 
			this.gráficoPizzaMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoPizzaMotivo.BackColor = System.Drawing.Color.White;
			this.gráficoPizzaMotivo.Dados = null;
			this.gráficoPizzaMotivo.EixoX = "Motivos";
			this.gráficoPizzaMotivo.EixoY = "Pessoas";
			this.gráficoPizzaMotivo.EstiloDesenho = Estatística.Estilo.Pizza;
			this.gráficoPizzaMotivo.ForçarEscritaValoresX = false;
			this.gráficoPizzaMotivo.FundoCor = System.Drawing.Color.White;
			this.gráficoPizzaMotivo.GapHorizontal = 0;
			this.gráficoPizzaMotivo.GapVertical = 20;
			this.gráficoPizzaMotivo.GradeHorizontal = true;
			this.gráficoPizzaMotivo.GradeVertical = true;
			this.gráficoPizzaMotivo.Legendas = null;
			this.gráficoPizzaMotivo.Location = new System.Drawing.Point(8, 8);
			this.gráficoPizzaMotivo.MaxX = -1;
			this.gráficoPizzaMotivo.MaxY = 0;
			this.gráficoPizzaMotivo.MinX = 0;
			this.gráficoPizzaMotivo.MinY = 0;
			this.gráficoPizzaMotivo.Name = "gráficoPizzaMotivo";
			this.gráficoPizzaMotivo.Size = new System.Drawing.Size(576, 264);
			this.gráficoPizzaMotivo.TabIndex = 0;
			this.gráficoPizzaMotivo.ValoresX = true;
			this.gráficoPizzaMotivo.ValoresY = true;
			this.gráficoPizzaMotivo.VérticeTamanho = 5F;
			this.gráficoPizzaMotivo.VetorÚnico = null;
			// 
			// imgs
			// 
			this.imgs.ImageSize = new System.Drawing.Size(16, 16);
			this.imgs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgs.ImageStream")));
			this.imgs.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// RelatórioVisitas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 462);
			this.Controls.Add(this.tab);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "RelatórioVisitas";
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relatório [Visitantas]";
			this.TopMost = false;
			this.Load += new System.EventHandler(this.RelatórioVisitas_Load);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.tab, 0);
			this.tab.ResumeLayout(false);
			this.tabLista.ResumeLayout(false);
			this.tabDistHorária.ResumeLayout(false);
			this.tabSetor2.ResumeLayout(false);
			this.tabMotivo2.ResumeLayout(false);
			this.tabDistDiária.ResumeLayout(false);
			this.tabSetor.ResumeLayout(false);
			this.tabMotivo.ResumeLayout(false);
			this.tabSetores3.ResumeLayout(false);
			this.tabMotivo3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void RelatórioVisitas_Load(object sender, System.EventArgs e)
		{
			this.SuspendLayout();

			this.lblDescrição.Size = new System.Drawing.Size(512, 40);

			this.ResumeLayout();
		}

		#region Ordenação dos visitantes

		private int colunaOrdenação = 0;

		public int Compare(object x, object y)
		{
			ListViewItem a, b;

			a = (ListViewItem) x;
			b = (ListViewItem) y;

			switch (colunaOrdenação)
			{
				case 0: // colVisitante.Index:
				case 1: //colMotivo.Index:
				case 2: //colSetor.Index:
				case 3: //colAtendente.Index:
					return string.Compare(a.SubItems[colunaOrdenação].Text, b.SubItems[colunaOrdenação].Text, true);

				case 4: //colEntrada.Index:
					return DateTime.Compare(((Visita) linhas[a]).Entrada, ((Visita) linhas[b]).Entrada);

				case 5: //colSaída.Index:
					return DateTime.Compare(((Visita) linhas[a]).Saída, ((Visita) linhas[b]).Saída);
			}

			return 0;
		}

		private void lstVisitantes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			colunaOrdenação = e.Column;
			lstVisitantes.ListViewItemSorter = this;
			lstVisitantes.Sort();
		}

		#endregion

		private void tab_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void ConstruirDistMédiaHorária()
		{
			TimeSpan dif = final - início;
			int divisorPadrão;
			int [] divisores = new int[24];
			double [] média = new double[24];
			double [] diário;

			// Construir divisores
			divisorPadrão = DiasÚteis(início.Date, final.Date) + 1;

			for (int i = 0; i < 24; i++)
			{
				divisores[i] = divisorPadrão;

				if (início.Hour > i)
					divisores[i]--;

				if (final.Hour < i)
					divisores[i]--;

				if (divisores[i] <= 0)
					divisores[i] = 1;
			}

			diário = new double[DiasÚteis(início.Date, final.Date) + 1];

			// Construir média
			foreach (Visita visita in visitas)
			{
				int diaÚtil = DiasÚteis(início.Date, visita.Entrada.Date);

				média[visita.Entrada.Hour] += (float) 1 / divisores[visita.Entrada.Hour];
				diário[diaÚtil]++;
			}

			// Construir legenda X
			DateTime aux = início;
			int auxDia = 0;

			while (aux <= final)
			{
				if ((int) aux.DayOfWeek > 0 && (int) aux.DayOfWeek < 6)
					valorXGráficoDistDiária[auxDia++] = aux.ToString("ddd dd/MM");

				aux = aux.AddDays(1);
			}

			// Construir gráfico
			gráficoDistHorária.VetorÚnico = média;
			gráficoDistDiária.MaxX = divisorPadrão;
			gráficoDistDiária.VetorÚnico = diário;

			if (início.Date == final.Date)
				tab.TabPages.Remove(tabDistDiária);
		}

		private int DiasÚteis(DateTime início, DateTime final)
		{
			TimeSpan ts = final.Date - início.Date;
			int dias = ts.Days;

			if ((int) início.DayOfWeek + dias < 6)
				return dias;

			// Verificar sábados e domingos
			int aux = dias;

			aux -= 8 - (int) início.DayOfWeek;

			int semanas = aux / 7;

			aux -= semanas * 2;

			aux += 6 - (int) início.DayOfWeek;

			if (aux <= 0)
				return ts.Days;
			else
				return aux;
		}

		private string gráficoDistDiária_ValorX(double valor)
		{
			object obj = valorXGráficoDistDiária[(int) valor];

			return (string) obj;
		}

		private void ConstruirDistSetor()
		{
			int diasÚteis = DiasÚteis(início, final);
			double [][] diário;
			double [] porSetor;
			int setores = 0;
			Hashtable hashSetores = new Hashtable();

			foreach (Visita visita in visitas)
			{
				if (visita.Setor != null && !hashSetores.ContainsKey(visita.Setor))
				{
					hashSetores[visita.Setor] = setores++;
					strSetores.Add(visita.Setor);
				}
			}

			diário = new double[setores][];
			porSetor = new double[setores];

			for (int i = 0; i < setores; i++)
				diário[i] = new double[diasÚteis + 1];

			// Construir média
			foreach (Visita visita in visitas)
			{
				int diaÚtil = DiasÚteis(início.Date, visita.Entrada.Date);

				if (visita.Setor != null)
				{
					diário[(int) hashSetores[visita.Setor]][diaÚtil]++;
					porSetor[(int) hashSetores[visita.Setor]]++;
				}
			}

			gráficoDistSetor.Dados = diário;
			gráficoDistSetor2.VetorÚnico = porSetor;
			gráficoPizzaSetores.VetorÚnico = porSetor;

			gráficoDistSetor.Legendas = (string []) strSetores.ToArray(typeof(string));
			gráficoPizzaSetores.Legendas = (string []) strSetores.ToArray(typeof(string));

//			legendaDistSetor.Invalidate();

			if (início.Date == final.Date)
				tab.TabPages.Remove(tabSetor);
		}

		private string gráficoDistSetor2_ValorX(double valor)
		{
			return (string) strSetores[(int) valor];
		}

		private void ConstruirDistMotivo()
		{
			double [] [] diário;
			double [] dados = new double[Enum.GetNames(typeof(MotivoContato)).Length];
			int [] valoresEnum = (int []) Enum.GetValues(typeof(MotivoContato));
			int diasÚteis = DiasÚteis(início, final) + 1;

			diário = new double[dados.Length][];

			for (int i = 0; i < diário.Length; i++)
				diário[i] = new double[diasÚteis];

			foreach (Visita visita in visitas)
				for (int i = 0; i < valoresEnum.Length; i++)
					if ((((int) visita.Motivo) & valoresEnum[i]) > 0)
					{
						dados[i]++;
						diário[i][DiasÚteis(início, visita.Entrada)]++;
					}
					else if ((int) visita.Motivo == (int) MotivoContato.Desconhecido)
					{
						dados[0]++;
						diário[0][DiasÚteis(início, visita.Entrada)]++;
					}

			gráficoDistMotivoBarra.VetorÚnico = dados;
			gráficoDistMotivoDias.Dados = diário;
			gráficoDistMotivoDias.Legendas = Enum.GetNames(typeof(MotivoContato));
			gráficoPizzaMotivo.VetorÚnico = dados;
			gráficoPizzaMotivo.Legendas = Enum.GetNames(typeof(MotivoContato));
		}

		private string gráficoDistMotivoBarra_ValorX(double valor)
		{
			return Enum.GetNames(typeof(MotivoContato))[(int) valor];
		}
	}
}

