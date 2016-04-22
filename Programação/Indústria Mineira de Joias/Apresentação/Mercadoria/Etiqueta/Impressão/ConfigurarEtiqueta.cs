using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Xml;
using Entidades.Etiqueta;

namespace Apresentação.Mercadoria.Etiqueta.Impressão
{
	public class ConfigurarEtiqueta : Apresentação.Formulários.BaseInferior
	{
		private EtiquetaFormato formato;

		// Formulário
		private Report.Layout.Complex.ItemLayout layoutEtiqueta;
		private Apresentação.Formulários.Quadro quadroEtiqueta;
		private Report.Designer.LayoutDesign layoutDesign;
		private Apresentação.Formulários.Quadro quadroPropriedades;
		private Apresentação.Formulários.Quadro quadro1;
		private System.Windows.Forms.Label lblTamanho;
		private Report.Layout.LabelLayout labelLayout;
		private System.Windows.Forms.TextBox txtEspaçamentoVertical;
		private System.Windows.Forms.Label lblEspaçamentoVertical;
		private System.Windows.Forms.TextBox txtAltura;
		private System.Windows.Forms.Label lblAltura;
		private System.Windows.Forms.TextBox txtLargura;
		private System.Windows.Forms.Label lblLargura;
		private System.Windows.Forms.TextBox txtEspaçamentoHorizontal;
		private System.Windows.Forms.Label lblEspaçamentoHorizontal;
		private System.Windows.Forms.GroupBox grpMargens;
		private System.Windows.Forms.TextBox txtMargemSuperior;
		private System.Windows.Forms.Label lblMargemSuperior;
		private System.Windows.Forms.Label lblMargemEsquerda;
		private System.Windows.Forms.TextBox txtMargemEsquerda;
		private System.Windows.Forms.Label lblMargemInferior;
		private System.Windows.Forms.TextBox txtMargemInferior;
		private System.Windows.Forms.Label lblMargemDireita;
		private System.Windows.Forms.TextBox txtMargemDireita;
		private System.Windows.Forms.Label label1;
		private Apresentação.Formulários.Quadro quadroElementos;
		private System.Windows.Forms.Panel painelElementos;
		private System.Windows.Forms.ToolBar barraElementos;
		private System.Windows.Forms.ToolBarButton elementoReferência;
		private System.Windows.Forms.ToolBarButton elementoÍndice;
		private System.Windows.Forms.ToolBarButton elementoPeso;
		private System.Windows.Forms.ToolBarButton elementoCódigoBarras;
		private System.Windows.Forms.ToolBarButton elementoFoto;
		private System.Windows.Forms.ImageList íconesElementos;
		private System.Windows.Forms.PropertyGrid propriedades;
		private System.Windows.Forms.ToolBarButton elementoLogo;
		private System.Windows.Forms.Label lblX;
		private System.Windows.Forms.TextBox txtAlturaFolha;
		private System.Windows.Forms.TextBox txtLarguraFolha;
		private Apresentação.Formulários.Quadro quadroConfiguração;
		private Apresentação.Formulários.Opção opçãoSalvar;
		private Apresentação.Formulários.Opção opçãoCancelar;
		private System.Windows.Forms.ToolBarButton elementoTexto;
		private System.Windows.Forms.ToolBarButton elementoFaixaGrupo;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a configuração padrão
		/// </summary>
		public ConfigurarEtiqueta()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			labelLayout.Items.Add(layoutEtiqueta);

			formato = null;
		}

		/// <summary>
		/// Constrói configuração para um formato já existente
		/// </summary>
		/// <param name="formato">Formato a ser editado</param>
		public ConfigurarEtiqueta(EtiquetaFormato formato)
		{
			InitializeComponent();

			labelLayout.Items.Add(layoutEtiqueta);

			CarregarFormato(formato);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ConfigurarEtiqueta));
			this.layoutEtiqueta = new Report.Layout.Complex.ItemLayout(this.components);
			this.quadroEtiqueta = new Apresentação.Formulários.Quadro();
			this.layoutDesign = new Report.Designer.LayoutDesign();
			this.quadroPropriedades = new Apresentação.Formulários.Quadro();
			this.propriedades = new System.Windows.Forms.PropertyGrid();
			this.labelLayout = new Report.Layout.LabelLayout(this.components);
			this.quadro1 = new Apresentação.Formulários.Quadro();
			this.txtAlturaFolha = new System.Windows.Forms.TextBox();
			this.lblX = new System.Windows.Forms.Label();
			this.txtLarguraFolha = new System.Windows.Forms.TextBox();
			this.grpMargens = new System.Windows.Forms.GroupBox();
			this.txtMargemDireita = new System.Windows.Forms.TextBox();
			this.lblMargemDireita = new System.Windows.Forms.Label();
			this.txtMargemInferior = new System.Windows.Forms.TextBox();
			this.lblMargemInferior = new System.Windows.Forms.Label();
			this.txtMargemEsquerda = new System.Windows.Forms.TextBox();
			this.lblMargemEsquerda = new System.Windows.Forms.Label();
			this.txtMargemSuperior = new System.Windows.Forms.TextBox();
			this.lblMargemSuperior = new System.Windows.Forms.Label();
			this.txtEspaçamentoVertical = new System.Windows.Forms.TextBox();
			this.lblEspaçamentoVertical = new System.Windows.Forms.Label();
			this.txtAltura = new System.Windows.Forms.TextBox();
			this.lblAltura = new System.Windows.Forms.Label();
			this.txtLargura = new System.Windows.Forms.TextBox();
			this.lblLargura = new System.Windows.Forms.Label();
			this.txtEspaçamentoHorizontal = new System.Windows.Forms.TextBox();
			this.lblEspaçamentoHorizontal = new System.Windows.Forms.Label();
			this.lblTamanho = new System.Windows.Forms.Label();
			this.quadroElementos = new Apresentação.Formulários.Quadro();
			this.painelElementos = new System.Windows.Forms.Panel();
			this.barraElementos = new System.Windows.Forms.ToolBar();
			this.elementoReferência = new System.Windows.Forms.ToolBarButton();
			this.elementoÍndice = new System.Windows.Forms.ToolBarButton();
			this.elementoPeso = new System.Windows.Forms.ToolBarButton();
			this.elementoCódigoBarras = new System.Windows.Forms.ToolBarButton();
			this.elementoFoto = new System.Windows.Forms.ToolBarButton();
			this.elementoLogo = new System.Windows.Forms.ToolBarButton();
			this.elementoTexto = new System.Windows.Forms.ToolBarButton();
			this.íconesElementos = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.quadroConfiguração = new Apresentação.Formulários.Quadro();
			this.opçãoCancelar = new Apresentação.Formulários.Opção();
			this.opçãoSalvar = new Apresentação.Formulários.Opção();
			this.elementoFaixaGrupo = new System.Windows.Forms.ToolBarButton();
			this.esquerda.SuspendLayout();
			this.quadroEtiqueta.SuspendLayout();
			this.quadroPropriedades.SuspendLayout();
			this.quadro1.SuspendLayout();
			this.grpMargens.SuspendLayout();
			this.quadroElementos.SuspendLayout();
			this.painelElementos.SuspendLayout();
			this.quadroConfiguração.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Controls.Add(this.quadroConfiguração);
			this.esquerda.Controls.Add(this.quadroElementos);
			this.esquerda.Size = new System.Drawing.Size(187, 456);
			// 
			// layoutEtiqueta
			// 
			this.layoutEtiqueta.DefaultAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.layoutEtiqueta.DefaultTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.layoutEtiqueta.Height = 2.54F;
			this.layoutEtiqueta.Size = ((System.Drawing.SizeF)(resources.GetObject("layoutEtiqueta.Size")));
			this.layoutEtiqueta.Width = 2.54F;
			// 
			// quadroEtiqueta
			// 
			this.quadroEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroEtiqueta.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroEtiqueta.bInfDirArredondada = false;
			this.quadroEtiqueta.bInfEsqArredondada = false;
			this.quadroEtiqueta.bSupDirArredondada = true;
			this.quadroEtiqueta.bSupEsqArredondada = true;
			this.quadroEtiqueta.Controls.Add(this.layoutDesign);
			this.quadroEtiqueta.Cor = System.Drawing.Color.Black;
			this.quadroEtiqueta.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroEtiqueta.LetraTítulo = System.Drawing.Color.White;
			this.quadroEtiqueta.Location = new System.Drawing.Point(192, 8);
			this.quadroEtiqueta.Name = "quadroEtiqueta";
			this.quadroEtiqueta.Size = new System.Drawing.Size(392, 158);
			this.quadroEtiqueta.TabIndex = 7;
			this.quadroEtiqueta.Tamanho = 30;
			this.quadroEtiqueta.Título = "Leiaute da Etiqueta";
			// 
			// layoutDesign
			// 
			this.layoutDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.layoutDesign.AutoScroll = true;
			this.layoutDesign.BackColor = System.Drawing.Color.Gray;
			this.layoutDesign.Grid = ((System.Drawing.SizeF)(resources.GetObject("layoutDesign.Grid")));
			this.layoutDesign.InsertItemHeight = 9F;
			this.layoutDesign.InsertItemWidth = 50F;
			this.layoutDesign.Layout = this.layoutEtiqueta;
			this.layoutDesign.Location = new System.Drawing.Point(1, 24);
			this.layoutDesign.Name = "layoutDesign";
			this.layoutDesign.Size = new System.Drawing.Size(390, 133);
			this.layoutDesign.TabIndex = 7;
			this.layoutDesign.SelectedItemChanged += new Report.Designer.LayoutDesign.SelectedItemChangedEvent(this.layoutDesign_SelectedItemChanged);
			// 
			// quadroPropriedades
			// 
			this.quadroPropriedades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroPropriedades.BackColor = System.Drawing.Color.Linen;
			this.quadroPropriedades.bInfDirArredondada = true;
			this.quadroPropriedades.bInfEsqArredondada = true;
			this.quadroPropriedades.bSupDirArredondada = true;
			this.quadroPropriedades.bSupEsqArredondada = true;
			this.quadroPropriedades.Controls.Add(this.propriedades);
			this.quadroPropriedades.Cor = System.Drawing.Color.Black;
			this.quadroPropriedades.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroPropriedades.LetraTítulo = System.Drawing.Color.White;
			this.quadroPropriedades.Location = new System.Drawing.Point(600, 8);
			this.quadroPropriedades.Name = "quadroPropriedades";
			this.quadroPropriedades.Size = new System.Drawing.Size(184, 430);
			this.quadroPropriedades.TabIndex = 8;
			this.quadroPropriedades.Tamanho = 30;
			this.quadroPropriedades.Título = "Propriedades da Seleção";
			// 
			// propriedades
			// 
			this.propriedades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propriedades.CommandsBackColor = System.Drawing.Color.White;
			this.propriedades.CommandsVisibleIfAvailable = true;
			this.propriedades.LargeButtons = false;
			this.propriedades.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propriedades.Location = new System.Drawing.Point(8, 32);
			this.propriedades.Name = "propriedades";
			this.propriedades.Size = new System.Drawing.Size(168, 390);
			this.propriedades.TabIndex = 9;
			this.propriedades.Text = "Propriedades da etiqueta";
			this.propriedades.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propriedades.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.propriedades.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propriedades_PropertyValueChanged);
			// 
			// labelLayout
			// 
			this.labelLayout.Document = null;
			this.labelLayout.GapHorizontal = 0F;
			this.labelLayout.GapVertical = 0F;
			this.labelLayout.MarginBottom = 0F;
			this.labelLayout.MarginLeft = 0F;
			this.labelLayout.MarginRight = 0F;
			this.labelLayout.MarginTop = 0F;
			this.labelLayout.Objects = null;
			this.labelLayout.XmlFileName = null;
			// 
			// quadro1
			// 
			this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadro1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadro1.bInfDirArredondada = true;
			this.quadro1.bInfEsqArredondada = true;
			this.quadro1.bSupDirArredondada = true;
			this.quadro1.bSupEsqArredondada = true;
			this.quadro1.Controls.Add(this.txtAlturaFolha);
			this.quadro1.Controls.Add(this.lblX);
			this.quadro1.Controls.Add(this.txtLarguraFolha);
			this.quadro1.Controls.Add(this.grpMargens);
			this.quadro1.Controls.Add(this.txtEspaçamentoVertical);
			this.quadro1.Controls.Add(this.lblEspaçamentoVertical);
			this.quadro1.Controls.Add(this.txtAltura);
			this.quadro1.Controls.Add(this.lblAltura);
			this.quadro1.Controls.Add(this.txtLargura);
			this.quadro1.Controls.Add(this.lblLargura);
			this.quadro1.Controls.Add(this.txtEspaçamentoHorizontal);
			this.quadro1.Controls.Add(this.lblEspaçamentoHorizontal);
			this.quadro1.Controls.Add(this.lblTamanho);
			this.quadro1.Cor = System.Drawing.Color.Black;
			this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadro1.LetraTítulo = System.Drawing.Color.White;
			this.quadro1.Location = new System.Drawing.Point(192, 182);
			this.quadro1.Name = "quadro1";
			this.quadro1.Size = new System.Drawing.Size(392, 256);
			this.quadro1.TabIndex = 9;
			this.quadro1.Tamanho = 30;
			this.quadro1.Título = "Propriedades da Folha";
			// 
			// txtAlturaFolha
			// 
			this.txtAlturaFolha.Location = new System.Drawing.Point(232, 32);
			this.txtAlturaFolha.Name = "txtAlturaFolha";
			this.txtAlturaFolha.Size = new System.Drawing.Size(88, 20);
			this.txtAlturaFolha.TabIndex = 14;
			this.txtAlturaFolha.Text = "";
			this.txtAlturaFolha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtAlturaFolha.Validated += new System.EventHandler(this.txtAlturaFolha_Validated);
			// 
			// lblX
			// 
			this.lblX.AutoSize = true;
			this.lblX.Location = new System.Drawing.Point(216, 34);
			this.lblX.Name = "lblX";
			this.lblX.Size = new System.Drawing.Size(10, 16);
			this.lblX.TabIndex = 13;
			this.lblX.Text = "x";
			// 
			// txtLarguraFolha
			// 
			this.txtLarguraFolha.Location = new System.Drawing.Point(112, 32);
			this.txtLarguraFolha.Name = "txtLarguraFolha";
			this.txtLarguraFolha.Size = new System.Drawing.Size(96, 20);
			this.txtLarguraFolha.TabIndex = 12;
			this.txtLarguraFolha.Text = "";
			this.txtLarguraFolha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtLarguraFolha.Validated += new System.EventHandler(this.txtLarguraFolha_Validated);
			// 
			// grpMargens
			// 
			this.grpMargens.Controls.Add(this.txtMargemDireita);
			this.grpMargens.Controls.Add(this.lblMargemDireita);
			this.grpMargens.Controls.Add(this.txtMargemInferior);
			this.grpMargens.Controls.Add(this.lblMargemInferior);
			this.grpMargens.Controls.Add(this.txtMargemEsquerda);
			this.grpMargens.Controls.Add(this.lblMargemEsquerda);
			this.grpMargens.Controls.Add(this.txtMargemSuperior);
			this.grpMargens.Controls.Add(this.lblMargemSuperior);
			this.grpMargens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.grpMargens.Location = new System.Drawing.Point(8, 184);
			this.grpMargens.Name = "grpMargens";
			this.grpMargens.Size = new System.Drawing.Size(376, 64);
			this.grpMargens.TabIndex = 11;
			this.grpMargens.TabStop = false;
			this.grpMargens.Text = "Margens";
			// 
			// txtMargemDireita
			// 
			this.txtMargemDireita.Location = new System.Drawing.Point(272, 40);
			this.txtMargemDireita.Name = "txtMargemDireita";
			this.txtMargemDireita.Size = new System.Drawing.Size(96, 20);
			this.txtMargemDireita.TabIndex = 20;
			this.txtMargemDireita.Text = "";
			this.txtMargemDireita.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtMargemDireita.Validated += new System.EventHandler(this.txtMargemDireita_Validated);
			// 
			// lblMargemDireita
			// 
			this.lblMargemDireita.AutoSize = true;
			this.lblMargemDireita.Location = new System.Drawing.Point(208, 42);
			this.lblMargemDireita.Name = "lblMargemDireita";
			this.lblMargemDireita.Size = new System.Drawing.Size(40, 16);
			this.lblMargemDireita.TabIndex = 19;
			this.lblMargemDireita.Text = "Direita:";
			// 
			// txtMargemInferior
			// 
			this.txtMargemInferior.Location = new System.Drawing.Point(104, 40);
			this.txtMargemInferior.Name = "txtMargemInferior";
			this.txtMargemInferior.Size = new System.Drawing.Size(96, 20);
			this.txtMargemInferior.TabIndex = 18;
			this.txtMargemInferior.Text = "";
			this.txtMargemInferior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtMargemInferior.Validated += new System.EventHandler(this.txtMargemInferior_Validated);
			// 
			// lblMargemInferior
			// 
			this.lblMargemInferior.AutoSize = true;
			this.lblMargemInferior.Location = new System.Drawing.Point(8, 42);
			this.lblMargemInferior.Name = "lblMargemInferior";
			this.lblMargemInferior.Size = new System.Drawing.Size(43, 16);
			this.lblMargemInferior.TabIndex = 17;
			this.lblMargemInferior.Text = "Inferior:";
			// 
			// txtMargemEsquerda
			// 
			this.txtMargemEsquerda.Location = new System.Drawing.Point(272, 16);
			this.txtMargemEsquerda.Name = "txtMargemEsquerda";
			this.txtMargemEsquerda.Size = new System.Drawing.Size(96, 20);
			this.txtMargemEsquerda.TabIndex = 16;
			this.txtMargemEsquerda.Text = "";
			this.txtMargemEsquerda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtMargemEsquerda.Validated += new System.EventHandler(this.txtMargemEsquerda_Validated);
			// 
			// lblMargemEsquerda
			// 
			this.lblMargemEsquerda.AutoSize = true;
			this.lblMargemEsquerda.Location = new System.Drawing.Point(208, 18);
			this.lblMargemEsquerda.Name = "lblMargemEsquerda";
			this.lblMargemEsquerda.Size = new System.Drawing.Size(56, 16);
			this.lblMargemEsquerda.TabIndex = 15;
			this.lblMargemEsquerda.Text = "Esquerda:";
			// 
			// txtMargemSuperior
			// 
			this.txtMargemSuperior.Location = new System.Drawing.Point(104, 16);
			this.txtMargemSuperior.Name = "txtMargemSuperior";
			this.txtMargemSuperior.Size = new System.Drawing.Size(96, 20);
			this.txtMargemSuperior.TabIndex = 14;
			this.txtMargemSuperior.Text = "";
			this.txtMargemSuperior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtMargemSuperior.Validated += new System.EventHandler(this.txtMargemSuperior_Validated);
			// 
			// lblMargemSuperior
			// 
			this.lblMargemSuperior.Location = new System.Drawing.Point(8, 18);
			this.lblMargemSuperior.Name = "lblMargemSuperior";
			this.lblMargemSuperior.Size = new System.Drawing.Size(56, 16);
			this.lblMargemSuperior.TabIndex = 13;
			this.lblMargemSuperior.Text = "Superior:";
			// 
			// txtEspaçamentoVertical
			// 
			this.txtEspaçamentoVertical.Location = new System.Drawing.Point(112, 160);
			this.txtEspaçamentoVertical.Name = "txtEspaçamentoVertical";
			this.txtEspaçamentoVertical.Size = new System.Drawing.Size(96, 20);
			this.txtEspaçamentoVertical.TabIndex = 10;
			this.txtEspaçamentoVertical.Text = "";
			this.txtEspaçamentoVertical.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtEspaçamentoVertical.Validated += new System.EventHandler(this.txtEspaçamentoVertical_Validated);
			// 
			// lblEspaçamentoVertical
			// 
			this.lblEspaçamentoVertical.BackColor = System.Drawing.Color.Transparent;
			this.lblEspaçamentoVertical.Location = new System.Drawing.Point(8, 154);
			this.lblEspaçamentoVertical.Name = "lblEspaçamentoVertical";
			this.lblEspaçamentoVertical.Size = new System.Drawing.Size(100, 32);
			this.lblEspaçamentoVertical.TabIndex = 9;
			this.lblEspaçamentoVertical.Text = "Espaçamento vertical (cm):";
			// 
			// txtAltura
			// 
			this.txtAltura.Location = new System.Drawing.Point(112, 96);
			this.txtAltura.Name = "txtAltura";
			this.txtAltura.Size = new System.Drawing.Size(96, 20);
			this.txtAltura.TabIndex = 6;
			this.txtAltura.Text = "";
			this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtAltura.Validating += new System.ComponentModel.CancelEventHandler(this.Tamanho_Validating);
			// 
			// lblAltura
			// 
			this.lblAltura.Location = new System.Drawing.Point(8, 90);
			this.lblAltura.Name = "lblAltura";
			this.lblAltura.Size = new System.Drawing.Size(100, 32);
			this.lblAltura.TabIndex = 5;
			this.lblAltura.Text = "Altura da etiqueta (cm):";
			// 
			// txtLargura
			// 
			this.txtLargura.Location = new System.Drawing.Point(112, 64);
			this.txtLargura.Name = "txtLargura";
			this.txtLargura.Size = new System.Drawing.Size(96, 20);
			this.txtLargura.TabIndex = 4;
			this.txtLargura.Text = "";
			this.txtLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtLargura.Validating += new System.ComponentModel.CancelEventHandler(this.Tamanho_Validating);
			// 
			// lblLargura
			// 
			this.lblLargura.Location = new System.Drawing.Point(8, 58);
			this.lblLargura.Name = "lblLargura";
			this.lblLargura.Size = new System.Drawing.Size(100, 32);
			this.lblLargura.TabIndex = 3;
			this.lblLargura.Text = "Largura da etiqueta (cm):";
			// 
			// txtEspaçamentoHorizontal
			// 
			this.txtEspaçamentoHorizontal.Location = new System.Drawing.Point(112, 128);
			this.txtEspaçamentoHorizontal.Name = "txtEspaçamentoHorizontal";
			this.txtEspaçamentoHorizontal.Size = new System.Drawing.Size(96, 20);
			this.txtEspaçamentoHorizontal.TabIndex = 8;
			this.txtEspaçamentoHorizontal.Text = "";
			this.txtEspaçamentoHorizontal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarNúmeros);
			this.txtEspaçamentoHorizontal.Validated += new System.EventHandler(this.txtEspaçamentoHorizontal_Validated);
			// 
			// lblEspaçamentoHorizontal
			// 
			this.lblEspaçamentoHorizontal.BackColor = System.Drawing.Color.Transparent;
			this.lblEspaçamentoHorizontal.Location = new System.Drawing.Point(8, 122);
			this.lblEspaçamentoHorizontal.Name = "lblEspaçamentoHorizontal";
			this.lblEspaçamentoHorizontal.Size = new System.Drawing.Size(100, 32);
			this.lblEspaçamentoHorizontal.TabIndex = 7;
			this.lblEspaçamentoHorizontal.Text = "Espaçamento horizontal (cm):";
			// 
			// lblTamanho
			// 
			this.lblTamanho.BackColor = System.Drawing.Color.Transparent;
			this.lblTamanho.Location = new System.Drawing.Point(8, 26);
			this.lblTamanho.Name = "lblTamanho";
			this.lblTamanho.Size = new System.Drawing.Size(104, 32);
			this.lblTamanho.TabIndex = 1;
			this.lblTamanho.Text = "Tamanho da folha (cm):";
			// 
			// quadroElementos
			// 
			this.quadroElementos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroElementos.bInfDirArredondada = true;
			this.quadroElementos.bInfEsqArredondada = true;
			this.quadroElementos.bSupDirArredondada = true;
			this.quadroElementos.bSupEsqArredondada = true;
			this.quadroElementos.Controls.Add(this.painelElementos);
			this.quadroElementos.Controls.Add(this.label1);
			this.quadroElementos.Cor = System.Drawing.Color.Black;
			this.quadroElementos.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroElementos.LetraTítulo = System.Drawing.Color.White;
			this.quadroElementos.Location = new System.Drawing.Point(8, 104);
			this.quadroElementos.Name = "quadroElementos";
			this.quadroElementos.Size = new System.Drawing.Size(160, 264);
			this.quadroElementos.TabIndex = 0;
			this.quadroElementos.Tamanho = 30;
			this.quadroElementos.Título = "Elementos da etiqueta";
			// 
			// painelElementos
			// 
			this.painelElementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.painelElementos.BackColor = System.Drawing.Color.Transparent;
			this.painelElementos.Controls.Add(this.barraElementos);
			this.painelElementos.Location = new System.Drawing.Point(8, 80);
			this.painelElementos.Name = "painelElementos";
			this.painelElementos.Size = new System.Drawing.Size(144, 176);
			this.painelElementos.TabIndex = 3;
			// 
			// barraElementos
			// 
			this.barraElementos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.barraElementos.AutoSize = false;
			this.barraElementos.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							  this.elementoReferência,
																							  this.elementoÍndice,
																							  this.elementoFaixaGrupo,
																							  this.elementoPeso,
																							  this.elementoCódigoBarras,
																							  this.elementoFoto,
																							  this.elementoLogo,
																							  this.elementoTexto});
			this.barraElementos.ButtonSize = new System.Drawing.Size(140, 22);
			this.barraElementos.Divider = false;
			this.barraElementos.Dock = System.Windows.Forms.DockStyle.Left;
			this.barraElementos.DropDownArrows = true;
			this.barraElementos.ImageList = this.íconesElementos;
			this.barraElementos.Location = new System.Drawing.Point(0, 0);
			this.barraElementos.Name = "barraElementos";
			this.barraElementos.ShowToolTips = true;
			this.barraElementos.Size = new System.Drawing.Size(141, 176);
			this.barraElementos.TabIndex = 0;
			this.barraElementos.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.barraElementos.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.barraElementos_ButtonClick);
			// 
			// elementoReferência
			// 
			this.elementoReferência.ImageIndex = 0;
			this.elementoReferência.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoReferência.Text = "Referência";
			// 
			// elementoÍndice
			// 
			this.elementoÍndice.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoÍndice.Text = "Índice";
			// 
			// elementoPeso
			// 
			this.elementoPeso.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoPeso.Text = "Peso";
			// 
			// elementoCódigoBarras
			// 
			this.elementoCódigoBarras.ImageIndex = 1;
			this.elementoCódigoBarras.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoCódigoBarras.Text = "Código de Barras";
			// 
			// elementoFoto
			// 
			this.elementoFoto.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoFoto.Text = "Foto";
			// 
			// elementoLogo
			// 
			this.elementoLogo.ImageIndex = 2;
			this.elementoLogo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoLogo.Text = "Logotipo";
			// 
			// elementoTexto
			// 
			this.elementoTexto.ImageIndex = 3;
			this.elementoTexto.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoTexto.Text = "Texto";
			// 
			// íconesElementos
			// 
			this.íconesElementos.ImageSize = new System.Drawing.Size(16, 16);
			this.íconesElementos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("íconesElementos.ImageStream")));
			this.íconesElementos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "Clique nas opções abaixo para inserir o elemento no leiaute da etiqueta:";
			// 
			// quadroConfiguração
			// 
			this.quadroConfiguração.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroConfiguração.bInfDirArredondada = true;
			this.quadroConfiguração.bInfEsqArredondada = true;
			this.quadroConfiguração.bSupDirArredondada = true;
			this.quadroConfiguração.bSupEsqArredondada = true;
			this.quadroConfiguração.Controls.Add(this.opçãoCancelar);
			this.quadroConfiguração.Controls.Add(this.opçãoSalvar);
			this.quadroConfiguração.Cor = System.Drawing.Color.Black;
			this.quadroConfiguração.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroConfiguração.LetraTítulo = System.Drawing.Color.White;
			this.quadroConfiguração.Location = new System.Drawing.Point(8, 16);
			this.quadroConfiguração.Name = "quadroConfiguração";
			this.quadroConfiguração.Size = new System.Drawing.Size(160, 80);
			this.quadroConfiguração.TabIndex = 1;
			this.quadroConfiguração.Tamanho = 30;
			this.quadroConfiguração.Título = "Configuração";
			// 
			// opçãoCancelar
			// 
			this.opçãoCancelar.BackColor = System.Drawing.Color.Transparent;
			this.opçãoCancelar.Descrição = "Cancelar";
			this.opçãoCancelar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoCancelar.Imagem")));
			this.opçãoCancelar.Location = new System.Drawing.Point(8, 56);
			this.opçãoCancelar.Name = "opçãoCancelar";
			this.opçãoCancelar.Size = new System.Drawing.Size(144, 24);
			this.opçãoCancelar.TabIndex = 3;
			this.opçãoCancelar.Click += new System.EventHandler(this.opçãoCancelar_Click);
			// 
			// opçãoSalvar
			// 
			this.opçãoSalvar.BackColor = System.Drawing.Color.Transparent;
			this.opçãoSalvar.Descrição = "Salvar configuração";
			this.opçãoSalvar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoSalvar.Imagem")));
			this.opçãoSalvar.Location = new System.Drawing.Point(8, 32);
			this.opçãoSalvar.Name = "opçãoSalvar";
			this.opçãoSalvar.Size = new System.Drawing.Size(144, 24);
			this.opçãoSalvar.TabIndex = 1;
			this.opçãoSalvar.Click += new System.EventHandler(this.opçãoSalvar_Click);
			// 
			// elementoFaixaGrupo
			// 
			this.elementoFaixaGrupo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoFaixaGrupo.Text = "Faixa e Grupo";
			// 
			// ConfigurarEtiqueta
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.quadro1);
			this.Controls.Add(this.quadroEtiqueta);
			this.Controls.Add(this.quadroPropriedades);
			this.Name = "ConfigurarEtiqueta";
			this.Size = new System.Drawing.Size(800, 456);
			this.Load += new System.EventHandler(this.ConfigurarEtiqueta_Load);
			this.Controls.SetChildIndex(this.quadroPropriedades, 0);
			this.Controls.SetChildIndex(this.quadroEtiqueta, 0);
			this.Controls.SetChildIndex(this.quadro1, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.esquerda.ResumeLayout(false);
			this.quadroEtiqueta.ResumeLayout(false);
			this.quadroPropriedades.ResumeLayout(false);
			this.quadro1.ResumeLayout(false);
			this.grpMargens.ResumeLayout(false);
			this.quadroElementos.ResumeLayout(false);
			this.painelElementos.ResumeLayout(false);
			this.quadroConfiguração.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao teclar em campo numérico. Somente números e
		/// separador de decimais são aceitos.
		/// </summary>
		private void AoTeclarNúmeros(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '.' || e.KeyChar == ',')
			{
				e.Handled = true;

				((TextBox) sender).SelectedText = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			}
			else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
				e.Handled = true;		
		}

		/// <summary>
		/// Ocorre ao carregar o controle de configuração de etiqueta
		/// </summary>
		private void ConfigurarEtiqueta_Load(object sender, System.EventArgs e)
		{
			txtLargura.Text = layoutEtiqueta.Width.ToString(NumberFormatInfo.CurrentInfo);
			txtAltura.Text  = layoutEtiqueta.Height.ToString(NumberFormatInfo.CurrentInfo);

			txtEspaçamentoHorizontal.Text = labelLayout.GapHorizontal.ToString(NumberFormatInfo.CurrentInfo);
			txtEspaçamentoVertical.Text = labelLayout.GapVertical.ToString(NumberFormatInfo.CurrentInfo);

			txtMargemSuperior.Text = labelLayout.MarginTop.ToString(NumberFormatInfo.CurrentInfo);
			txtMargemEsquerda.Text = labelLayout.MarginLeft.ToString(NumberFormatInfo.CurrentInfo);
			txtMargemDireita.Text  = labelLayout.MarginRight.ToString(NumberFormatInfo.CurrentInfo);
			txtMargemInferior.Text = labelLayout.MarginBottom.ToString(NumberFormatInfo.CurrentInfo);

			propriedades.SelectedObject = layoutEtiqueta;

			txtLarguraFolha.Text = (labelLayout.PaperSize.Width * 0.0254f).ToString(NumberFormatInfo.CurrentInfo);
			txtAlturaFolha.Text  = (labelLayout.PaperSize.Height * 0.0254f).ToString(NumberFormatInfo.CurrentInfo);
		}

		/// <summary>
		/// Ocorre ao clicar em um botão da barra de elementos
		/// </summary>
		private void barraElementos_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Pushed)
			{
				DesmarcarBotõesElementos(e.Button);

				propriedades.Enabled = false;

				if (e.Button == elementoReferência)
					layoutDesign.Insert(typeof(Impressão.Layout.Referência));
			
				else if (e.Button == elementoÍndice)
					layoutDesign.Insert(typeof(Impressão.Layout.Índice));

				else if (e.Button == elementoFaixaGrupo)
					layoutDesign.Insert(typeof(Impressão.Layout.FaixaGrupo));

				else if (e.Button == elementoPeso)
					layoutDesign.Insert(typeof(Impressão.Layout.Peso));

				else if (e.Button == elementoCódigoBarras)
					layoutDesign.Insert(typeof(Impressão.Layout.CódigoDeBarras));

				else if (e.Button == elementoFoto)
					layoutDesign.Insert(typeof(Impressão.Layout.Foto));

				else if (e.Button == elementoLogo)
					layoutDesign.Insert(typeof(Impressão.Layout.Logotipo));

				else if (e.Button == elementoTexto)
					layoutDesign.Insert(typeof(Report.Layout.Complex.StaticLabel));

				propriedades.Enabled = true;
			}
			else
				layoutDesign.SetPointer(true);
		}

		/// <summary>
		/// Desmarca todos os botões de elementos, com exceção
		/// de um específico.
		/// </summary>
		/// <param name="exceção">Único botão a não ser desmarcado</param>
		private void DesmarcarBotõesElementos(ToolBarButton exceção)
		{
			foreach (ToolBarButton botão in barraElementos.Buttons)
				if (botão != exceção && botão.Pushed)
					botão.Pushed = false;
		}

		/// <summary>
		/// Ocorre ao selecionar ítem no designer de leiaute
		/// </summary>
		private void layoutDesign_SelectedItemChanged(Report.Designer.LayoutDesign sender, Report.Layout.Complex.IPrintableItem selection)
		{
			if (propriedades.Enabled)
			{
				if (selection != null)
					propriedades.SelectedObject = selection;
				else
					propriedades.SelectedObject = layoutEtiqueta;

				DesmarcarBotõesElementos(null);
			}
		}

		/// <summary>
		/// Ocorre ao alterar alguma propriedade de algum elemento
		/// </summary>
		private void propriedades_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			layoutDesign.Redraw();
		}

		#region Mapeamento de propriedades do labelLayout para o formulário

		private void txtMargemSuperior_Validated(object sender, System.EventArgs e)
		{
			labelLayout.MarginTop = float.Parse(txtMargemSuperior.Text, NumberFormatInfo.CurrentInfo);
		}

		private void txtMargemEsquerda_Validated(object sender, System.EventArgs e)
		{
			labelLayout.MarginLeft = float.Parse(txtMargemEsquerda.Text, NumberFormatInfo.CurrentInfo);
		}

		private void txtMargemInferior_Validated(object sender, System.EventArgs e)
		{
			labelLayout.MarginBottom = float.Parse(txtMargemInferior.Text, NumberFormatInfo.CurrentInfo);
		}

		private void txtMargemDireita_Validated(object sender, System.EventArgs e)
		{
			labelLayout.MarginRight = float.Parse(txtMargemDireita.Text, NumberFormatInfo.CurrentInfo);
		}

		private void txtEspaçamentoHorizontal_Validated(object sender, System.EventArgs e)
		{
			labelLayout.GapHorizontal = float.Parse(txtEspaçamentoHorizontal.Text, NumberFormatInfo.CurrentInfo);
		}

		private void txtEspaçamentoVertical_Validated(object sender, System.EventArgs e)
		{
			labelLayout.GapVertical = float.Parse(txtEspaçamentoVertical.Text, NumberFormatInfo.CurrentInfo);
		}
		
		/// <summary>
		/// Ocorre ao validar o tamanho da etiqueta
		/// </summary>
		private void Tamanho_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if (sender == txtLargura)
					layoutEtiqueta.Width = float.Parse(txtLargura.Text, NumberFormatInfo.CurrentInfo);
				else if (sender == txtAltura)
					layoutEtiqueta.Height = float.Parse(txtAltura.Text, NumberFormatInfo.CurrentInfo);

				layoutDesign.ResizePage();
				layoutDesign.Redraw();

				e.Cancel = false;
			}
			catch
			{
				e.Cancel = true;
			}
		}

		private void txtLarguraFolha_Validated(object sender, System.EventArgs e)
		{
			if (labelLayout.PaperSize.Kind != PaperKind.Custom)
				labelLayout.PaperSize = new PaperSize("Personalizado", (int) (float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int) (float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
			else
				try
				{
					labelLayout.PaperSize.Width = (int) (float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f);
				}
				catch
				{
					labelLayout.PaperSize = new PaperSize("Personalizado", (int) (float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int) (float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
				}
		}

		private void txtAlturaFolha_Validated(object sender, System.EventArgs e)
		{
			if (labelLayout.PaperSize.Kind != PaperKind.Custom)
				labelLayout.PaperSize = new PaperSize("Personalizado", (int) (float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int) (float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
			else
				try
				{
					labelLayout.PaperSize.Height = (int) (float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f);
				}
				catch
				{
					labelLayout.PaperSize = new PaperSize("Personalizado", (int) (float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int) (float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
				}
		}

		#endregion

		/// <summary>
		/// Ocorre ao solicitar salvamento da configuração
		/// </summary>
		private void opçãoSalvar_Click(object sender, System.EventArgs e)
		{
			string configuração;

			configuração = GerarConfiguração();

			// Mostrar janela para salvar configuração
			using (SalvarConfiguração dlg = new SalvarConfiguração())
			{
				bool loop;

				if (formato != null)
					dlg.Formato = formato.Formato;

				do
				{
					loop = false;

					if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
					{
						// Verificar se é um novo formato
						if (formato == null || formato.Formato != dlg.Formato)
						{
							try
							{
								formato = EtiquetaFormato.Cadastrar(dlg.Formato, configuração);
							}
							catch (Acesso.Comum.Exceções.EntidadeJáExistente exceção)
							{
								switch (MessageBox.Show(this.ParentForm,
									"Este formato já existe, deseja sobrescrevê-lo?",
									"Configuração de etiqueta",
									MessageBoxButtons.YesNoCancel,
									MessageBoxIcon.Question,
									MessageBoxDefaultButton.Button2))
								{
									case DialogResult.Yes:
										((EtiquetaFormato) exceção.Entidade).Atualizar();
										break;

									case DialogResult.No:
										loop = true;
										break;

									case DialogResult.Cancel:
										return;
								}
							}
						}
						else // Formato já existe
						{
							formato.Configuração = configuração;
							formato.Atualizar();
						}
					}
				} while (loop);
			}

			SubstituirBase(new ListaEtiquetas());
		}

		/// <summary>
		/// Gera string de configuração da etiqueta
		/// </summary>
		/// <returns>Configuração da etiqueta</returns>
		private string GerarConfiguração()
		{
			XmlDocument doc;

			doc = labelLayout.SaveToXml();

			return doc.OuterXml;
		}

		/// <summary>
		/// Ocorre ao clicar em cancelar
		/// </summary>
		private void opçãoCancelar_Click(object sender, System.EventArgs e)
		{
			SubstituirBase(new ListaEtiquetas());
		}

		/// <summary>
		/// Carrega formato de etiqueta
		/// </summary>
		/// <param name="formato">Formato a ser editado</param>
		private void CarregarFormato(EtiquetaFormato formato)
		{
			XmlDocument      doc;
			this.formato = formato;

			doc = new XmlDocument();

			doc.LoadXml(formato.Configuração);

			labelLayout.Items.Clear();
			labelLayout.ImportType(typeof(Entidades.Mercadoria.Mercadoria));
			labelLayout.LoadFromXml(doc, false);
			
			layoutDesign.Layout = labelLayout.Items[0];

			layoutEtiqueta.Dispose();
			layoutEtiqueta = labelLayout.Items[0];
		}
	}
}

