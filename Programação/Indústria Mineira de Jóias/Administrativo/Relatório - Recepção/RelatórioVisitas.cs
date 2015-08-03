using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Neg�cio;

using Entidades;
using Entidades.Pessoa;

using Apresenta��o.Formul�rios;

namespace Relat�rio.Recep��o
{
	public class Relat�rioVisitas : Apresenta��o.Formul�rios.JanelaExplicativa, IComparer
	{
		private Hashtable	linhas;
		private ArrayList	visitas;
		private int			pessoas;
		private	DateTime	in�cio;
		private DateTime	final;
		private Hashtable	valorXGr�ficoDistDi�ria = new Hashtable();
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
		private System.Windows.Forms.ColumnHeader colSa�da;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage tabDistHor�ria;
		private System.Windows.Forms.TabPage tabDistDi�ria;
		private Estat�stica.Gr�fico gr�ficoDistHor�ria;
		private Estat�stica.Gr�fico gr�ficoDistDi�ria;
		private System.Windows.Forms.TabPage tabSetor;
		private System.Windows.Forms.TabPage tabMotivo;
		private Estat�stica.Gr�fico gr�ficoDistSetor;
		private Estat�stica.Legenda legendaDistSetor;
		private System.Windows.Forms.ImageList imgs;
		private System.Windows.Forms.TabPage tabSetor2;
		private Estat�stica.Gr�fico gr�ficoDistSetor2;
		private System.Windows.Forms.TabPage tabSetores3;
		private System.Windows.Forms.TabPage tabMotivo2;
		private System.Windows.Forms.TabPage tabMotivo3;
		private Estat�stica.Gr�fico gr�ficoDistMotivoBarra;
		private Estat�stica.Gr�fico gr�ficoDistMotivoDias;
		private Estat�stica.Legenda legendaDistMotivoDias;
		private Estat�stica.Gr�fico gr�ficoPizzaSetores;
		private Estat�stica.Gr�fico gr�ficoPizzaMotivo;
		private Estat�stica.Legenda legendaGr�ficoPizzaSetores;
		private Estat�stica.Legenda legendaGr�ficoPizzaMotivo;
		private System.ComponentModel.IContainer components = null;

		public Relat�rioVisitas(Neg�cio.Controle.IControle controle, DateTime in�cio, DateTime t�rmino, string descri��o)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Aguarde aguarde;

			aguarde = new Aguarde("Recuperando informa��es do banco de dados...", 5);
			aguarde.Show();
			aguarde.Refresh();

			this.SuspendLayout();

			lblDescri��o.Text = descri��o;

			this.ResumeLayout();

			visitas = controle.ObterVisitas(in�cio, t�rmino);

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

			this.in�cio = in�cio;
			this.final = t�rmino;

//			gr�ficoDistDi�ria.ValorX += new Estat�stica.Desenhista.Convers�oValor(gr�ficoDistDi�ria_ValorX);
//			gr�ficoDistSetor.ValorX += new Estat�stica.Desenhista.Convers�oValor(gr�ficoDistDi�ria_ValorX);
//			gr�ficoDistSetor2.ValorX += new Estat�stica.Desenhista.Convers�oValor(gr�ficoDistSetor2_ValorX);
//			gr�ficoDistMotivoDias.ValorX += new Estat�stica.Desenhista.Convers�oValor(gr�ficoDistDi�ria_ValorX);
//			gr�ficoDistMotivoBarra.ValorX += new Estat�stica.Desenhista.Convers�oValor(gr�ficoDistMotivoBarra_ValorX);

			aguarde.Passo("Construindo distribui��o m�dia hor�ria...");
			ConstruirDistM�diaHor�ria();

			aguarde.Passo("Construindo distribui��o por setor...");
			ConstruirDistSetor();

			aguarde.Passo("Construindo distribui��o por motivos...");
			ConstruirDistMotivo();

			aguarde.Close();
			aguarde.Dispose();
		}

		private void InserirLinha(Visita visita, string nome)
		{
			ListViewItem �tem = new ListViewItem(nome);

			�tem.SubItems.Add(visita.MotivoTexto);

			�tem.SubItems.Add(visita.Setor);

			string atendimentos = "";

			foreach (VisitaAtendimento va in visita.Atendimentos)
			{
				if (atendimentos.Length == 0)
					atendimentos = va.Funcion�rio.Nome;
				else
					atendimentos += ", " + va.Funcion�rio.Nome;
			}

			�tem.SubItems.Add(atendimentos);

			�tem.SubItems.Add(visita.Entrada.ToLongTimeString());

			if (!visita.NaEmpresa)
				�tem.SubItems.Add(visita.Sa�da.ToLongTimeString());
			else
				�tem.SubItems.Add("");

			lstVisitantes.Items.Add(�tem);

			linhas[�tem] = visita;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Relat�rioVisitas));
			this.cmdOK = new System.Windows.Forms.Button();
			this.tab = new System.Windows.Forms.TabControl();
			this.tabLista = new System.Windows.Forms.TabPage();
			this.lstVisitantes = new System.Windows.Forms.ListView();
			this.colVisitante = new System.Windows.Forms.ColumnHeader();
			this.colMotivo = new System.Windows.Forms.ColumnHeader();
			this.colSetor = new System.Windows.Forms.ColumnHeader();
			this.colAtendente = new System.Windows.Forms.ColumnHeader();
			this.colEntrada = new System.Windows.Forms.ColumnHeader();
			this.colSa�da = new System.Windows.Forms.ColumnHeader();
			this.tabDistHor�ria = new System.Windows.Forms.TabPage();
			this.gr�ficoDistHor�ria = new Estat�stica.Gr�fico();
			this.tabSetor2 = new System.Windows.Forms.TabPage();
			this.gr�ficoDistSetor2 = new Estat�stica.Gr�fico();
			this.tabMotivo2 = new System.Windows.Forms.TabPage();
			this.gr�ficoDistMotivoBarra = new Estat�stica.Gr�fico();
			this.tabDistDi�ria = new System.Windows.Forms.TabPage();
			this.gr�ficoDistDi�ria = new Estat�stica.Gr�fico();
			this.tabSetor = new System.Windows.Forms.TabPage();
			this.legendaDistSetor = new Estat�stica.Legenda();
			this.gr�ficoDistSetor = new Estat�stica.Gr�fico();
			this.tabMotivo = new System.Windows.Forms.TabPage();
			this.legendaDistMotivoDias = new Estat�stica.Legenda();
			this.gr�ficoDistMotivoDias = new Estat�stica.Gr�fico();
			this.tabSetores3 = new System.Windows.Forms.TabPage();
			this.legendaGr�ficoPizzaSetores = new Estat�stica.Legenda();
			this.gr�ficoPizzaSetores = new Estat�stica.Gr�fico();
			this.tabMotivo3 = new System.Windows.Forms.TabPage();
			this.legendaGr�ficoPizzaMotivo = new Estat�stica.Legenda();
			this.gr�ficoPizzaMotivo = new Estat�stica.Gr�fico();
			this.imgs = new System.Windows.Forms.ImageList(this.components);
			this.tab.SuspendLayout();
			this.tabLista.SuspendLayout();
			this.tabDistHor�ria.SuspendLayout();
			this.tabSetor2.SuspendLayout();
			this.tabMotivo2.SuspendLayout();
			this.tabDistDi�ria.SuspendLayout();
			this.tabSetor.SuspendLayout();
			this.tabMotivo.SuspendLayout();
			this.tabSetores3.SuspendLayout();
			this.tabMotivo3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(178, 22);
			this.lblT�tulo.Text = "Relat�rio de Visitantes";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(11570, 40);
			this.lblDescri��o.Text = "Visualize aqui os visitantes que estiveram na empresa.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Location = new System.Drawing.Point(8, 16);
			this.pic�cone.Name = "pic�cone";
			this.pic�cone.Size = new System.Drawing.Size(56, 64);
			this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
			this.tab.Controls.Add(this.tabDistHor�ria);
			this.tab.Controls.Add(this.tabSetor2);
			this.tab.Controls.Add(this.tabMotivo2);
			this.tab.Controls.Add(this.tabDistDi�ria);
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
																							this.colSa�da});
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
			// colSa�da
			// 
			this.colSa�da.Text = "Sa�da";
			// 
			// tabDistHor�ria
			// 
			this.tabDistHor�ria.BackColor = System.Drawing.Color.White;
			this.tabDistHor�ria.Controls.Add(this.gr�ficoDistHor�ria);
			this.tabDistHor�ria.ImageIndex = 0;
			this.tabDistHor�ria.Location = new System.Drawing.Point(4, 42);
			this.tabDistHor�ria.Name = "tabDistHor�ria";
			this.tabDistHor�ria.Size = new System.Drawing.Size(590, 280);
			this.tabDistHor�ria.TabIndex = 1;
			this.tabDistHor�ria.Text = "M�dia hor�ria";
			// 
			// gr�ficoDistHor�ria
			// 
			this.gr�ficoDistHor�ria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoDistHor�ria.BackColor = System.Drawing.Color.White;
			this.gr�ficoDistHor�ria.Dados = null;
			this.gr�ficoDistHor�ria.EixoX = "Horas";
			this.gr�ficoDistHor�ria.EixoY = "Pessoas";
			this.gr�ficoDistHor�ria.EstiloDesenho = Estat�stica.Estilo.Barras;
			this.gr�ficoDistHor�ria.For�arEscritaValoresX = false;
			this.gr�ficoDistHor�ria.FundoCor = System.Drawing.Color.White;
			this.gr�ficoDistHor�ria.GapHorizontal = 0;
			this.gr�ficoDistHor�ria.GapVertical = 20;
			this.gr�ficoDistHor�ria.GradeHorizontal = true;
			this.gr�ficoDistHor�ria.GradeVertical = true;
			this.gr�ficoDistHor�ria.Legendas = null;
			this.gr�ficoDistHor�ria.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoDistHor�ria.MaxX = 24;
			this.gr�ficoDistHor�ria.MaxY = 2;
			this.gr�ficoDistHor�ria.MinX = 0;
			this.gr�ficoDistHor�ria.MinY = 0;
			this.gr�ficoDistHor�ria.Name = "gr�ficoDistHor�ria";
			this.gr�ficoDistHor�ria.Size = new System.Drawing.Size(574, 264);
			this.gr�ficoDistHor�ria.TabIndex = 0;
			this.gr�ficoDistHor�ria.ValoresX = true;
			this.gr�ficoDistHor�ria.ValoresY = true;
			this.gr�ficoDistHor�ria.V�rticeTamanho = 5F;
			this.gr�ficoDistHor�ria.Vetor�nico = null;
			// 
			// tabSetor2
			// 
			this.tabSetor2.BackColor = System.Drawing.Color.White;
			this.tabSetor2.Controls.Add(this.gr�ficoDistSetor2);
			this.tabSetor2.ImageIndex = 0;
			this.tabSetor2.Location = new System.Drawing.Point(4, 42);
			this.tabSetor2.Name = "tabSetor2";
			this.tabSetor2.Size = new System.Drawing.Size(590, 280);
			this.tabSetor2.TabIndex = 5;
			this.tabSetor2.Text = "Distribui��o por Setores";
			// 
			// gr�ficoDistSetor2
			// 
			this.gr�ficoDistSetor2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoDistSetor2.BackColor = System.Drawing.Color.White;
			this.gr�ficoDistSetor2.Dados = null;
			this.gr�ficoDistSetor2.EixoX = "Setores";
			this.gr�ficoDistSetor2.EixoY = "Pessoas";
			this.gr�ficoDistSetor2.EstiloDesenho = Estat�stica.Estilo.Barras;
			this.gr�ficoDistSetor2.For�arEscritaValoresX = false;
			this.gr�ficoDistSetor2.FundoCor = System.Drawing.Color.White;
			this.gr�ficoDistSetor2.GapHorizontal = 0;
			this.gr�ficoDistSetor2.GapVertical = 20;
			this.gr�ficoDistSetor2.GradeHorizontal = true;
			this.gr�ficoDistSetor2.GradeVertical = true;
			this.gr�ficoDistSetor2.Legendas = null;
			this.gr�ficoDistSetor2.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoDistSetor2.MaxX = -1;
			this.gr�ficoDistSetor2.MaxY = 2;
			this.gr�ficoDistSetor2.MinX = 0;
			this.gr�ficoDistSetor2.MinY = 0;
			this.gr�ficoDistSetor2.Name = "gr�ficoDistSetor2";
			this.gr�ficoDistSetor2.Size = new System.Drawing.Size(574, 264);
			this.gr�ficoDistSetor2.TabIndex = 0;
			this.gr�ficoDistSetor2.ValoresX = true;
			this.gr�ficoDistSetor2.ValoresY = true;
			this.gr�ficoDistSetor2.V�rticeTamanho = 5F;
			this.gr�ficoDistSetor2.Vetor�nico = null;
			// 
			// tabMotivo2
			// 
			this.tabMotivo2.BackColor = System.Drawing.Color.White;
			this.tabMotivo2.Controls.Add(this.gr�ficoDistMotivoBarra);
			this.tabMotivo2.ImageIndex = 0;
			this.tabMotivo2.Location = new System.Drawing.Point(4, 42);
			this.tabMotivo2.Name = "tabMotivo2";
			this.tabMotivo2.Size = new System.Drawing.Size(590, 280);
			this.tabMotivo2.TabIndex = 7;
			this.tabMotivo2.Text = "Distribui��o por Motivo";
			// 
			// gr�ficoDistMotivoBarra
			// 
			this.gr�ficoDistMotivoBarra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoDistMotivoBarra.BackColor = System.Drawing.Color.White;
			this.gr�ficoDistMotivoBarra.Dados = null;
			this.gr�ficoDistMotivoBarra.EixoX = "Motivo";
			this.gr�ficoDistMotivoBarra.EixoY = "Pessoas";
			this.gr�ficoDistMotivoBarra.EstiloDesenho = Estat�stica.Estilo.Barras;
			this.gr�ficoDistMotivoBarra.For�arEscritaValoresX = true;
			this.gr�ficoDistMotivoBarra.FundoCor = System.Drawing.Color.White;
			this.gr�ficoDistMotivoBarra.GapHorizontal = 0;
			this.gr�ficoDistMotivoBarra.GapVertical = 20;
			this.gr�ficoDistMotivoBarra.GradeHorizontal = true;
			this.gr�ficoDistMotivoBarra.GradeVertical = true;
			this.gr�ficoDistMotivoBarra.Legendas = null;
			this.gr�ficoDistMotivoBarra.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoDistMotivoBarra.MaxX = -1;
			this.gr�ficoDistMotivoBarra.MaxY = 0;
			this.gr�ficoDistMotivoBarra.MinX = 0;
			this.gr�ficoDistMotivoBarra.MinY = 0;
			this.gr�ficoDistMotivoBarra.Name = "gr�ficoDistMotivoBarra";
			this.gr�ficoDistMotivoBarra.Size = new System.Drawing.Size(576, 264);
			this.gr�ficoDistMotivoBarra.TabIndex = 0;
			this.gr�ficoDistMotivoBarra.ValoresX = true;
			this.gr�ficoDistMotivoBarra.ValoresY = true;
			this.gr�ficoDistMotivoBarra.V�rticeTamanho = 5F;
			this.gr�ficoDistMotivoBarra.Vetor�nico = null;
			// 
			// tabDistDi�ria
			// 
			this.tabDistDi�ria.BackColor = System.Drawing.Color.White;
			this.tabDistDi�ria.Controls.Add(this.gr�ficoDistDi�ria);
			this.tabDistDi�ria.ImageIndex = 1;
			this.tabDistDi�ria.Location = new System.Drawing.Point(4, 42);
			this.tabDistDi�ria.Name = "tabDistDi�ria";
			this.tabDistDi�ria.Size = new System.Drawing.Size(590, 280);
			this.tabDistDi�ria.TabIndex = 2;
			this.tabDistDi�ria.Text = "Distribui��o di�ria";
			// 
			// gr�ficoDistDi�ria
			// 
			this.gr�ficoDistDi�ria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoDistDi�ria.BackColor = System.Drawing.Color.White;
			this.gr�ficoDistDi�ria.Dados = null;
			this.gr�ficoDistDi�ria.EixoX = "Dias";
			this.gr�ficoDistDi�ria.EixoY = "Pessoas";
			this.gr�ficoDistDi�ria.EstiloDesenho = Estat�stica.Estilo.Linhas;
			this.gr�ficoDistDi�ria.For�arEscritaValoresX = false;
			this.gr�ficoDistDi�ria.FundoCor = System.Drawing.Color.White;
			this.gr�ficoDistDi�ria.GapHorizontal = 80;
			this.gr�ficoDistDi�ria.GapVertical = 20;
			this.gr�ficoDistDi�ria.GradeHorizontal = true;
			this.gr�ficoDistDi�ria.GradeVertical = true;
			this.gr�ficoDistDi�ria.Legendas = null;
			this.gr�ficoDistDi�ria.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoDistDi�ria.MaxX = -1;
			this.gr�ficoDistDi�ria.MaxY = 0;
			this.gr�ficoDistDi�ria.MinX = 0;
			this.gr�ficoDistDi�ria.MinY = 0;
			this.gr�ficoDistDi�ria.Name = "gr�ficoDistDi�ria";
			this.gr�ficoDistDi�ria.Size = new System.Drawing.Size(574, 264);
			this.gr�ficoDistDi�ria.TabIndex = 0;
			this.gr�ficoDistDi�ria.ValoresX = true;
			this.gr�ficoDistDi�ria.ValoresY = true;
			this.gr�ficoDistDi�ria.V�rticeTamanho = 5F;
			this.gr�ficoDistDi�ria.Vetor�nico = null;
			// 
			// tabSetor
			// 
			this.tabSetor.BackColor = System.Drawing.Color.White;
			this.tabSetor.Controls.Add(this.legendaDistSetor);
			this.tabSetor.Controls.Add(this.gr�ficoDistSetor);
			this.tabSetor.ImageIndex = 1;
			this.tabSetor.Location = new System.Drawing.Point(4, 42);
			this.tabSetor.Name = "tabSetor";
			this.tabSetor.Size = new System.Drawing.Size(590, 280);
			this.tabSetor.TabIndex = 3;
			this.tabSetor.Text = "Distribui��o por Setor";
			// 
			// legendaDistSetor
			// 
			this.legendaDistSetor.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.legendaDistSetor.AutoSize = true;
			this.legendaDistSetor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistSetor.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaDistSetor.Distanciamento = 5;
			this.legendaDistSetor.Espa�amento = 10;
			this.legendaDistSetor.Fonte = new System.Drawing.Font("Arial", 9F);
			this.legendaDistSetor.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistSetor.Gr�fico = this.gr�ficoDistSetor;
			this.legendaDistSetor.Location = new System.Drawing.Point(472, 96);
			this.legendaDistSetor.Name = "legendaDistSetor";
			this.legendaDistSetor.QuadradoTamanho = 9;
			this.legendaDistSetor.Size = new System.Drawing.Size(112, 56);
			this.legendaDistSetor.TabIndex = 1;
			// 
			// gr�ficoDistSetor
			// 
			this.gr�ficoDistSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoDistSetor.BackColor = System.Drawing.Color.White;
			this.gr�ficoDistSetor.Dados = null;
			this.gr�ficoDistSetor.EixoX = "Dias";
			this.gr�ficoDistSetor.EixoY = "Pessoas";
			this.gr�ficoDistSetor.EstiloDesenho = Estat�stica.Estilo.LinhasV�rtices;
			this.gr�ficoDistSetor.For�arEscritaValoresX = false;
			this.gr�ficoDistSetor.FundoCor = System.Drawing.Color.White;
			this.gr�ficoDistSetor.GapHorizontal = 0;
			this.gr�ficoDistSetor.GapVertical = 20;
			this.gr�ficoDistSetor.GradeHorizontal = true;
			this.gr�ficoDistSetor.GradeVertical = true;
			this.gr�ficoDistSetor.Legendas = null;
			this.gr�ficoDistSetor.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoDistSetor.MaxX = -1;
			this.gr�ficoDistSetor.MaxY = 10;
			this.gr�ficoDistSetor.MinX = 0;
			this.gr�ficoDistSetor.MinY = 0;
			this.gr�ficoDistSetor.Name = "gr�ficoDistSetor";
			this.gr�ficoDistSetor.Size = new System.Drawing.Size(472, 264);
			this.gr�ficoDistSetor.TabIndex = 0;
			this.gr�ficoDistSetor.ValoresX = true;
			this.gr�ficoDistSetor.ValoresY = true;
			this.gr�ficoDistSetor.V�rticeTamanho = 5F;
			this.gr�ficoDistSetor.Vetor�nico = null;
			// 
			// tabMotivo
			// 
			this.tabMotivo.BackColor = System.Drawing.Color.White;
			this.tabMotivo.Controls.Add(this.legendaDistMotivoDias);
			this.tabMotivo.Controls.Add(this.gr�ficoDistMotivoDias);
			this.tabMotivo.ImageIndex = 1;
			this.tabMotivo.Location = new System.Drawing.Point(4, 42);
			this.tabMotivo.Name = "tabMotivo";
			this.tabMotivo.Size = new System.Drawing.Size(590, 280);
			this.tabMotivo.TabIndex = 4;
			this.tabMotivo.Text = "Distribui��o por Motivo";
			// 
			// legendaDistMotivoDias
			// 
			this.legendaDistMotivoDias.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.legendaDistMotivoDias.AutoSize = true;
			this.legendaDistMotivoDias.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistMotivoDias.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaDistMotivoDias.Distanciamento = 2;
			this.legendaDistMotivoDias.Espa�amento = 5;
			this.legendaDistMotivoDias.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legendaDistMotivoDias.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaDistMotivoDias.Gr�fico = this.gr�ficoDistMotivoDias;
			this.legendaDistMotivoDias.Location = new System.Drawing.Point(472, 56);
			this.legendaDistMotivoDias.Name = "legendaDistMotivoDias";
			this.legendaDistMotivoDias.QuadradoTamanho = 4;
			this.legendaDistMotivoDias.Size = new System.Drawing.Size(112, 80);
			this.legendaDistMotivoDias.TabIndex = 1;
			// 
			// gr�ficoDistMotivoDias
			// 
			this.gr�ficoDistMotivoDias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoDistMotivoDias.BackColor = System.Drawing.Color.White;
			this.gr�ficoDistMotivoDias.Dados = null;
			this.gr�ficoDistMotivoDias.EixoX = "Dias";
			this.gr�ficoDistMotivoDias.EixoY = "Pessoas";
			this.gr�ficoDistMotivoDias.EstiloDesenho = Estat�stica.Estilo.LinhasV�rtices;
			this.gr�ficoDistMotivoDias.For�arEscritaValoresX = false;
			this.gr�ficoDistMotivoDias.FundoCor = System.Drawing.Color.White;
			this.gr�ficoDistMotivoDias.GapHorizontal = 0;
			this.gr�ficoDistMotivoDias.GapVertical = 20;
			this.gr�ficoDistMotivoDias.GradeHorizontal = true;
			this.gr�ficoDistMotivoDias.GradeVertical = true;
			this.gr�ficoDistMotivoDias.Legendas = null;
			this.gr�ficoDistMotivoDias.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoDistMotivoDias.MaxX = -1;
			this.gr�ficoDistMotivoDias.MaxY = 10;
			this.gr�ficoDistMotivoDias.MinX = 0;
			this.gr�ficoDistMotivoDias.MinY = 0;
			this.gr�ficoDistMotivoDias.Name = "gr�ficoDistMotivoDias";
			this.gr�ficoDistMotivoDias.Size = new System.Drawing.Size(472, 264);
			this.gr�ficoDistMotivoDias.TabIndex = 0;
			this.gr�ficoDistMotivoDias.ValoresX = true;
			this.gr�ficoDistMotivoDias.ValoresY = true;
			this.gr�ficoDistMotivoDias.V�rticeTamanho = 5F;
			this.gr�ficoDistMotivoDias.Vetor�nico = null;
			// 
			// tabSetores3
			// 
			this.tabSetores3.BackColor = System.Drawing.Color.White;
			this.tabSetores3.Controls.Add(this.legendaGr�ficoPizzaSetores);
			this.tabSetores3.Controls.Add(this.gr�ficoPizzaSetores);
			this.tabSetores3.ImageIndex = 2;
			this.tabSetores3.Location = new System.Drawing.Point(4, 42);
			this.tabSetores3.Name = "tabSetores3";
			this.tabSetores3.Size = new System.Drawing.Size(590, 280);
			this.tabSetores3.TabIndex = 6;
			this.tabSetores3.Text = "Distribui��o por setores";
			// 
			// legendaGr�ficoPizzaSetores
			// 
			this.legendaGr�ficoPizzaSetores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.legendaGr�ficoPizzaSetores.AutoSize = true;
			this.legendaGr�ficoPizzaSetores.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGr�ficoPizzaSetores.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaGr�ficoPizzaSetores.Distanciamento = 2;
			this.legendaGr�ficoPizzaSetores.Espa�amento = 5;
			this.legendaGr�ficoPizzaSetores.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legendaGr�ficoPizzaSetores.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGr�ficoPizzaSetores.Gr�fico = this.gr�ficoPizzaSetores;
			this.legendaGr�ficoPizzaSetores.Location = new System.Drawing.Point(424, 8);
			this.legendaGr�ficoPizzaSetores.Name = "legendaGr�ficoPizzaSetores";
			this.legendaGr�ficoPizzaSetores.QuadradoTamanho = 4;
			this.legendaGr�ficoPizzaSetores.Size = new System.Drawing.Size(160, 112);
			this.legendaGr�ficoPizzaSetores.TabIndex = 1;
			// 
			// gr�ficoPizzaSetores
			// 
			this.gr�ficoPizzaSetores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoPizzaSetores.BackColor = System.Drawing.Color.White;
			this.gr�ficoPizzaSetores.Dados = null;
			this.gr�ficoPizzaSetores.EixoX = "Eixo X";
			this.gr�ficoPizzaSetores.EixoY = "Eixo Y";
			this.gr�ficoPizzaSetores.EstiloDesenho = Estat�stica.Estilo.Pizza;
			this.gr�ficoPizzaSetores.For�arEscritaValoresX = false;
			this.gr�ficoPizzaSetores.FundoCor = System.Drawing.Color.White;
			this.gr�ficoPizzaSetores.GapHorizontal = 0;
			this.gr�ficoPizzaSetores.GapVertical = 20;
			this.gr�ficoPizzaSetores.GradeHorizontal = true;
			this.gr�ficoPizzaSetores.GradeVertical = true;
			this.gr�ficoPizzaSetores.Legendas = null;
			this.gr�ficoPizzaSetores.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoPizzaSetores.MaxX = -1;
			this.gr�ficoPizzaSetores.MaxY = 0;
			this.gr�ficoPizzaSetores.MinX = 0;
			this.gr�ficoPizzaSetores.MinY = 0;
			this.gr�ficoPizzaSetores.Name = "gr�ficoPizzaSetores";
			this.gr�ficoPizzaSetores.Size = new System.Drawing.Size(576, 264);
			this.gr�ficoPizzaSetores.TabIndex = 0;
			this.gr�ficoPizzaSetores.ValoresX = true;
			this.gr�ficoPizzaSetores.ValoresY = true;
			this.gr�ficoPizzaSetores.V�rticeTamanho = 5F;
			this.gr�ficoPizzaSetores.Vetor�nico = null;
			// 
			// tabMotivo3
			// 
			this.tabMotivo3.BackColor = System.Drawing.Color.White;
			this.tabMotivo3.Controls.Add(this.legendaGr�ficoPizzaMotivo);
			this.tabMotivo3.Controls.Add(this.gr�ficoPizzaMotivo);
			this.tabMotivo3.ImageIndex = 2;
			this.tabMotivo3.Location = new System.Drawing.Point(4, 42);
			this.tabMotivo3.Name = "tabMotivo3";
			this.tabMotivo3.Size = new System.Drawing.Size(590, 280);
			this.tabMotivo3.TabIndex = 8;
			this.tabMotivo3.Text = "Distribui��o por Motivo";
			// 
			// legendaGr�ficoPizzaMotivo
			// 
			this.legendaGr�ficoPizzaMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.legendaGr�ficoPizzaMotivo.AutoSize = true;
			this.legendaGr�ficoPizzaMotivo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGr�ficoPizzaMotivo.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legendaGr�ficoPizzaMotivo.Distanciamento = 2;
			this.legendaGr�ficoPizzaMotivo.Espa�amento = 5;
			this.legendaGr�ficoPizzaMotivo.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legendaGr�ficoPizzaMotivo.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legendaGr�ficoPizzaMotivo.Gr�fico = this.gr�ficoPizzaMotivo;
			this.legendaGr�ficoPizzaMotivo.Location = new System.Drawing.Point(424, 8);
			this.legendaGr�ficoPizzaMotivo.Name = "legendaGr�ficoPizzaMotivo";
			this.legendaGr�ficoPizzaMotivo.QuadradoTamanho = 4;
			this.legendaGr�ficoPizzaMotivo.Size = new System.Drawing.Size(160, 112);
			this.legendaGr�ficoPizzaMotivo.TabIndex = 1;
			// 
			// gr�ficoPizzaMotivo
			// 
			this.gr�ficoPizzaMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoPizzaMotivo.BackColor = System.Drawing.Color.White;
			this.gr�ficoPizzaMotivo.Dados = null;
			this.gr�ficoPizzaMotivo.EixoX = "Motivos";
			this.gr�ficoPizzaMotivo.EixoY = "Pessoas";
			this.gr�ficoPizzaMotivo.EstiloDesenho = Estat�stica.Estilo.Pizza;
			this.gr�ficoPizzaMotivo.For�arEscritaValoresX = false;
			this.gr�ficoPizzaMotivo.FundoCor = System.Drawing.Color.White;
			this.gr�ficoPizzaMotivo.GapHorizontal = 0;
			this.gr�ficoPizzaMotivo.GapVertical = 20;
			this.gr�ficoPizzaMotivo.GradeHorizontal = true;
			this.gr�ficoPizzaMotivo.GradeVertical = true;
			this.gr�ficoPizzaMotivo.Legendas = null;
			this.gr�ficoPizzaMotivo.Location = new System.Drawing.Point(8, 8);
			this.gr�ficoPizzaMotivo.MaxX = -1;
			this.gr�ficoPizzaMotivo.MaxY = 0;
			this.gr�ficoPizzaMotivo.MinX = 0;
			this.gr�ficoPizzaMotivo.MinY = 0;
			this.gr�ficoPizzaMotivo.Name = "gr�ficoPizzaMotivo";
			this.gr�ficoPizzaMotivo.Size = new System.Drawing.Size(576, 264);
			this.gr�ficoPizzaMotivo.TabIndex = 0;
			this.gr�ficoPizzaMotivo.ValoresX = true;
			this.gr�ficoPizzaMotivo.ValoresY = true;
			this.gr�ficoPizzaMotivo.V�rticeTamanho = 5F;
			this.gr�ficoPizzaMotivo.Vetor�nico = null;
			// 
			// imgs
			// 
			this.imgs.ImageSize = new System.Drawing.Size(16, 16);
			this.imgs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgs.ImageStream")));
			this.imgs.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Relat�rioVisitas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 462);
			this.Controls.Add(this.tab);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "Relat�rioVisitas";
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relat�rio [Visitantas]";
			this.TopMost = false;
			this.Load += new System.EventHandler(this.Relat�rioVisitas_Load);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.tab, 0);
			this.tab.ResumeLayout(false);
			this.tabLista.ResumeLayout(false);
			this.tabDistHor�ria.ResumeLayout(false);
			this.tabSetor2.ResumeLayout(false);
			this.tabMotivo2.ResumeLayout(false);
			this.tabDistDi�ria.ResumeLayout(false);
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

		private void Relat�rioVisitas_Load(object sender, System.EventArgs e)
		{
			this.SuspendLayout();

			this.lblDescri��o.Size = new System.Drawing.Size(512, 40);

			this.ResumeLayout();
		}

		#region Ordena��o dos visitantes

		private int colunaOrdena��o = 0;

		public int Compare(object x, object y)
		{
			ListViewItem a, b;

			a = (ListViewItem) x;
			b = (ListViewItem) y;

			switch (colunaOrdena��o)
			{
				case 0: // colVisitante.Index:
				case 1: //colMotivo.Index:
				case 2: //colSetor.Index:
				case 3: //colAtendente.Index:
					return string.Compare(a.SubItems[colunaOrdena��o].Text, b.SubItems[colunaOrdena��o].Text, true);

				case 4: //colEntrada.Index:
					return DateTime.Compare(((Visita) linhas[a]).Entrada, ((Visita) linhas[b]).Entrada);

				case 5: //colSa�da.Index:
					return DateTime.Compare(((Visita) linhas[a]).Sa�da, ((Visita) linhas[b]).Sa�da);
			}

			return 0;
		}

		private void lstVisitantes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			colunaOrdena��o = e.Column;
			lstVisitantes.ListViewItemSorter = this;
			lstVisitantes.Sort();
		}

		#endregion

		private void tab_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void ConstruirDistM�diaHor�ria()
		{
			TimeSpan dif = final - in�cio;
			int divisorPadr�o;
			int [] divisores = new int[24];
			double [] m�dia = new double[24];
			double [] di�rio;

			// Construir divisores
			divisorPadr�o = Dias�teis(in�cio.Date, final.Date) + 1;

			for (int i = 0; i < 24; i++)
			{
				divisores[i] = divisorPadr�o;

				if (in�cio.Hour > i)
					divisores[i]--;

				if (final.Hour < i)
					divisores[i]--;

				if (divisores[i] <= 0)
					divisores[i] = 1;
			}

			di�rio = new double[Dias�teis(in�cio.Date, final.Date) + 1];

			// Construir m�dia
			foreach (Visita visita in visitas)
			{
				int dia�til = Dias�teis(in�cio.Date, visita.Entrada.Date);

				m�dia[visita.Entrada.Hour] += (float) 1 / divisores[visita.Entrada.Hour];
				di�rio[dia�til]++;
			}

			// Construir legenda X
			DateTime aux = in�cio;
			int auxDia = 0;

			while (aux <= final)
			{
				if ((int) aux.DayOfWeek > 0 && (int) aux.DayOfWeek < 6)
					valorXGr�ficoDistDi�ria[auxDia++] = aux.ToString("ddd dd/MM");

				aux = aux.AddDays(1);
			}

			// Construir gr�fico
			gr�ficoDistHor�ria.Vetor�nico = m�dia;
			gr�ficoDistDi�ria.MaxX = divisorPadr�o;
			gr�ficoDistDi�ria.Vetor�nico = di�rio;

			if (in�cio.Date == final.Date)
				tab.TabPages.Remove(tabDistDi�ria);
		}

		private int Dias�teis(DateTime in�cio, DateTime final)
		{
			TimeSpan ts = final.Date - in�cio.Date;
			int dias = ts.Days;

			if ((int) in�cio.DayOfWeek + dias < 6)
				return dias;

			// Verificar s�bados e domingos
			int aux = dias;

			aux -= 8 - (int) in�cio.DayOfWeek;

			int semanas = aux / 7;

			aux -= semanas * 2;

			aux += 6 - (int) in�cio.DayOfWeek;

			if (aux <= 0)
				return ts.Days;
			else
				return aux;
		}

		private string gr�ficoDistDi�ria_ValorX(double valor)
		{
			object obj = valorXGr�ficoDistDi�ria[(int) valor];

			return (string) obj;
		}

		private void ConstruirDistSetor()
		{
			int dias�teis = Dias�teis(in�cio, final);
			double [][] di�rio;
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

			di�rio = new double[setores][];
			porSetor = new double[setores];

			for (int i = 0; i < setores; i++)
				di�rio[i] = new double[dias�teis + 1];

			// Construir m�dia
			foreach (Visita visita in visitas)
			{
				int dia�til = Dias�teis(in�cio.Date, visita.Entrada.Date);

				if (visita.Setor != null)
				{
					di�rio[(int) hashSetores[visita.Setor]][dia�til]++;
					porSetor[(int) hashSetores[visita.Setor]]++;
				}
			}

			gr�ficoDistSetor.Dados = di�rio;
			gr�ficoDistSetor2.Vetor�nico = porSetor;
			gr�ficoPizzaSetores.Vetor�nico = porSetor;

			gr�ficoDistSetor.Legendas = (string []) strSetores.ToArray(typeof(string));
			gr�ficoPizzaSetores.Legendas = (string []) strSetores.ToArray(typeof(string));

//			legendaDistSetor.Invalidate();

			if (in�cio.Date == final.Date)
				tab.TabPages.Remove(tabSetor);
		}

		private string gr�ficoDistSetor2_ValorX(double valor)
		{
			return (string) strSetores[(int) valor];
		}

		private void ConstruirDistMotivo()
		{
			double [] [] di�rio;
			double [] dados = new double[Enum.GetNames(typeof(MotivoContato)).Length];
			int [] valoresEnum = (int []) Enum.GetValues(typeof(MotivoContato));
			int dias�teis = Dias�teis(in�cio, final) + 1;

			di�rio = new double[dados.Length][];

			for (int i = 0; i < di�rio.Length; i++)
				di�rio[i] = new double[dias�teis];

			foreach (Visita visita in visitas)
				for (int i = 0; i < valoresEnum.Length; i++)
					if ((((int) visita.Motivo) & valoresEnum[i]) > 0)
					{
						dados[i]++;
						di�rio[i][Dias�teis(in�cio, visita.Entrada)]++;
					}
					else if ((int) visita.Motivo == (int) MotivoContato.Desconhecido)
					{
						dados[0]++;
						di�rio[0][Dias�teis(in�cio, visita.Entrada)]++;
					}

			gr�ficoDistMotivoBarra.Vetor�nico = dados;
			gr�ficoDistMotivoDias.Dados = di�rio;
			gr�ficoDistMotivoDias.Legendas = Enum.GetNames(typeof(MotivoContato));
			gr�ficoPizzaMotivo.Vetor�nico = dados;
			gr�ficoPizzaMotivo.Legendas = Enum.GetNames(typeof(MotivoContato));
		}

		private string gr�ficoDistMotivoBarra_ValorX(double valor)
		{
			return Enum.GetNames(typeof(MotivoContato))[(int) valor];
		}
	}
}

