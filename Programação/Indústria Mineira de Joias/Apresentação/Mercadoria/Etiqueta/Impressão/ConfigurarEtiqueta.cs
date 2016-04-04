using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Xml;
using Entidades.Etiqueta;

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o
{
	public class ConfigurarEtiqueta : Apresenta��o.Formul�rios.BaseInferior
	{
		private EtiquetaFormato formato;

		// Formul�rio
		private Report.Layout.Complex.ItemLayout layoutEtiqueta;
		private Apresenta��o.Formul�rios.Quadro quadroEtiqueta;
		private Report.Designer.LayoutDesign layoutDesign;
		private Apresenta��o.Formul�rios.Quadro quadroPropriedades;
		private Apresenta��o.Formul�rios.Quadro quadro1;
		private System.Windows.Forms.Label lblTamanho;
		private Report.Layout.LabelLayout labelLayout;
		private System.Windows.Forms.TextBox txtEspa�amentoVertical;
		private System.Windows.Forms.Label lblEspa�amentoVertical;
		private System.Windows.Forms.TextBox txtAltura;
		private System.Windows.Forms.Label lblAltura;
		private System.Windows.Forms.TextBox txtLargura;
		private System.Windows.Forms.Label lblLargura;
		private System.Windows.Forms.TextBox txtEspa�amentoHorizontal;
		private System.Windows.Forms.Label lblEspa�amentoHorizontal;
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
		private Apresenta��o.Formul�rios.Quadro quadroElementos;
		private System.Windows.Forms.Panel painelElementos;
		private System.Windows.Forms.ToolBar barraElementos;
		private System.Windows.Forms.ToolBarButton elementoRefer�ncia;
		private System.Windows.Forms.ToolBarButton elemento�ndice;
		private System.Windows.Forms.ToolBarButton elementoPeso;
		private System.Windows.Forms.ToolBarButton elementoC�digoBarras;
		private System.Windows.Forms.ToolBarButton elementoFoto;
		private System.Windows.Forms.ImageList �conesElementos;
		private System.Windows.Forms.PropertyGrid propriedades;
		private System.Windows.Forms.ToolBarButton elementoLogo;
		private System.Windows.Forms.Label lblX;
		private System.Windows.Forms.TextBox txtAlturaFolha;
		private System.Windows.Forms.TextBox txtLarguraFolha;
		private Apresenta��o.Formul�rios.Quadro quadroConfigura��o;
		private Apresenta��o.Formul�rios.Op��o op��oSalvar;
		private Apresenta��o.Formul�rios.Op��o op��oCancelar;
		private System.Windows.Forms.ToolBarButton elementoTexto;
		private System.Windows.Forms.ToolBarButton elementoFaixaGrupo;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i a configura��o padr�o
		/// </summary>
		public ConfigurarEtiqueta()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			labelLayout.Items.Add(layoutEtiqueta);

			formato = null;
		}

		/// <summary>
		/// Constr�i configura��o para um formato j� existente
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
			this.quadroEtiqueta = new Apresenta��o.Formul�rios.Quadro();
			this.layoutDesign = new Report.Designer.LayoutDesign();
			this.quadroPropriedades = new Apresenta��o.Formul�rios.Quadro();
			this.propriedades = new System.Windows.Forms.PropertyGrid();
			this.labelLayout = new Report.Layout.LabelLayout(this.components);
			this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
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
			this.txtEspa�amentoVertical = new System.Windows.Forms.TextBox();
			this.lblEspa�amentoVertical = new System.Windows.Forms.Label();
			this.txtAltura = new System.Windows.Forms.TextBox();
			this.lblAltura = new System.Windows.Forms.Label();
			this.txtLargura = new System.Windows.Forms.TextBox();
			this.lblLargura = new System.Windows.Forms.Label();
			this.txtEspa�amentoHorizontal = new System.Windows.Forms.TextBox();
			this.lblEspa�amentoHorizontal = new System.Windows.Forms.Label();
			this.lblTamanho = new System.Windows.Forms.Label();
			this.quadroElementos = new Apresenta��o.Formul�rios.Quadro();
			this.painelElementos = new System.Windows.Forms.Panel();
			this.barraElementos = new System.Windows.Forms.ToolBar();
			this.elementoRefer�ncia = new System.Windows.Forms.ToolBarButton();
			this.elemento�ndice = new System.Windows.Forms.ToolBarButton();
			this.elementoPeso = new System.Windows.Forms.ToolBarButton();
			this.elementoC�digoBarras = new System.Windows.Forms.ToolBarButton();
			this.elementoFoto = new System.Windows.Forms.ToolBarButton();
			this.elementoLogo = new System.Windows.Forms.ToolBarButton();
			this.elementoTexto = new System.Windows.Forms.ToolBarButton();
			this.�conesElementos = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.quadroConfigura��o = new Apresenta��o.Formul�rios.Quadro();
			this.op��oCancelar = new Apresenta��o.Formul�rios.Op��o();
			this.op��oSalvar = new Apresenta��o.Formul�rios.Op��o();
			this.elementoFaixaGrupo = new System.Windows.Forms.ToolBarButton();
			this.esquerda.SuspendLayout();
			this.quadroEtiqueta.SuspendLayout();
			this.quadroPropriedades.SuspendLayout();
			this.quadro1.SuspendLayout();
			this.grpMargens.SuspendLayout();
			this.quadroElementos.SuspendLayout();
			this.painelElementos.SuspendLayout();
			this.quadroConfigura��o.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Controls.Add(this.quadroConfigura��o);
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
			this.quadroEtiqueta.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroEtiqueta.LetraT�tulo = System.Drawing.Color.White;
			this.quadroEtiqueta.Location = new System.Drawing.Point(192, 8);
			this.quadroEtiqueta.Name = "quadroEtiqueta";
			this.quadroEtiqueta.Size = new System.Drawing.Size(392, 158);
			this.quadroEtiqueta.TabIndex = 7;
			this.quadroEtiqueta.Tamanho = 30;
			this.quadroEtiqueta.T�tulo = "Leiaute da Etiqueta";
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
			this.quadroPropriedades.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroPropriedades.LetraT�tulo = System.Drawing.Color.White;
			this.quadroPropriedades.Location = new System.Drawing.Point(600, 8);
			this.quadroPropriedades.Name = "quadroPropriedades";
			this.quadroPropriedades.Size = new System.Drawing.Size(184, 430);
			this.quadroPropriedades.TabIndex = 8;
			this.quadroPropriedades.Tamanho = 30;
			this.quadroPropriedades.T�tulo = "Propriedades da Sele��o";
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
			this.quadro1.Controls.Add(this.txtEspa�amentoVertical);
			this.quadro1.Controls.Add(this.lblEspa�amentoVertical);
			this.quadro1.Controls.Add(this.txtAltura);
			this.quadro1.Controls.Add(this.lblAltura);
			this.quadro1.Controls.Add(this.txtLargura);
			this.quadro1.Controls.Add(this.lblLargura);
			this.quadro1.Controls.Add(this.txtEspa�amentoHorizontal);
			this.quadro1.Controls.Add(this.lblEspa�amentoHorizontal);
			this.quadro1.Controls.Add(this.lblTamanho);
			this.quadro1.Cor = System.Drawing.Color.Black;
			this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadro1.LetraT�tulo = System.Drawing.Color.White;
			this.quadro1.Location = new System.Drawing.Point(192, 182);
			this.quadro1.Name = "quadro1";
			this.quadro1.Size = new System.Drawing.Size(392, 256);
			this.quadro1.TabIndex = 9;
			this.quadro1.Tamanho = 30;
			this.quadro1.T�tulo = "Propriedades da Folha";
			// 
			// txtAlturaFolha
			// 
			this.txtAlturaFolha.Location = new System.Drawing.Point(232, 32);
			this.txtAlturaFolha.Name = "txtAlturaFolha";
			this.txtAlturaFolha.Size = new System.Drawing.Size(88, 20);
			this.txtAlturaFolha.TabIndex = 14;
			this.txtAlturaFolha.Text = "";
			this.txtAlturaFolha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			this.txtLarguraFolha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			this.txtMargemDireita.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			this.txtMargemInferior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			this.txtMargemEsquerda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			this.txtMargemSuperior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			// txtEspa�amentoVertical
			// 
			this.txtEspa�amentoVertical.Location = new System.Drawing.Point(112, 160);
			this.txtEspa�amentoVertical.Name = "txtEspa�amentoVertical";
			this.txtEspa�amentoVertical.Size = new System.Drawing.Size(96, 20);
			this.txtEspa�amentoVertical.TabIndex = 10;
			this.txtEspa�amentoVertical.Text = "";
			this.txtEspa�amentoVertical.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
			this.txtEspa�amentoVertical.Validated += new System.EventHandler(this.txtEspa�amentoVertical_Validated);
			// 
			// lblEspa�amentoVertical
			// 
			this.lblEspa�amentoVertical.BackColor = System.Drawing.Color.Transparent;
			this.lblEspa�amentoVertical.Location = new System.Drawing.Point(8, 154);
			this.lblEspa�amentoVertical.Name = "lblEspa�amentoVertical";
			this.lblEspa�amentoVertical.Size = new System.Drawing.Size(100, 32);
			this.lblEspa�amentoVertical.TabIndex = 9;
			this.lblEspa�amentoVertical.Text = "Espa�amento vertical (cm):";
			// 
			// txtAltura
			// 
			this.txtAltura.Location = new System.Drawing.Point(112, 96);
			this.txtAltura.Name = "txtAltura";
			this.txtAltura.Size = new System.Drawing.Size(96, 20);
			this.txtAltura.TabIndex = 6;
			this.txtAltura.Text = "";
			this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			this.txtLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
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
			// txtEspa�amentoHorizontal
			// 
			this.txtEspa�amentoHorizontal.Location = new System.Drawing.Point(112, 128);
			this.txtEspa�amentoHorizontal.Name = "txtEspa�amentoHorizontal";
			this.txtEspa�amentoHorizontal.Size = new System.Drawing.Size(96, 20);
			this.txtEspa�amentoHorizontal.TabIndex = 8;
			this.txtEspa�amentoHorizontal.Text = "";
			this.txtEspa�amentoHorizontal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoTeclarN�meros);
			this.txtEspa�amentoHorizontal.Validated += new System.EventHandler(this.txtEspa�amentoHorizontal_Validated);
			// 
			// lblEspa�amentoHorizontal
			// 
			this.lblEspa�amentoHorizontal.BackColor = System.Drawing.Color.Transparent;
			this.lblEspa�amentoHorizontal.Location = new System.Drawing.Point(8, 122);
			this.lblEspa�amentoHorizontal.Name = "lblEspa�amentoHorizontal";
			this.lblEspa�amentoHorizontal.Size = new System.Drawing.Size(100, 32);
			this.lblEspa�amentoHorizontal.TabIndex = 7;
			this.lblEspa�amentoHorizontal.Text = "Espa�amento horizontal (cm):";
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
			this.quadroElementos.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroElementos.LetraT�tulo = System.Drawing.Color.White;
			this.quadroElementos.Location = new System.Drawing.Point(8, 104);
			this.quadroElementos.Name = "quadroElementos";
			this.quadroElementos.Size = new System.Drawing.Size(160, 264);
			this.quadroElementos.TabIndex = 0;
			this.quadroElementos.Tamanho = 30;
			this.quadroElementos.T�tulo = "Elementos da etiqueta";
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
																							  this.elementoRefer�ncia,
																							  this.elemento�ndice,
																							  this.elementoFaixaGrupo,
																							  this.elementoPeso,
																							  this.elementoC�digoBarras,
																							  this.elementoFoto,
																							  this.elementoLogo,
																							  this.elementoTexto});
			this.barraElementos.ButtonSize = new System.Drawing.Size(140, 22);
			this.barraElementos.Divider = false;
			this.barraElementos.Dock = System.Windows.Forms.DockStyle.Left;
			this.barraElementos.DropDownArrows = true;
			this.barraElementos.ImageList = this.�conesElementos;
			this.barraElementos.Location = new System.Drawing.Point(0, 0);
			this.barraElementos.Name = "barraElementos";
			this.barraElementos.ShowToolTips = true;
			this.barraElementos.Size = new System.Drawing.Size(141, 176);
			this.barraElementos.TabIndex = 0;
			this.barraElementos.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.barraElementos.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.barraElementos_ButtonClick);
			// 
			// elementoRefer�ncia
			// 
			this.elementoRefer�ncia.ImageIndex = 0;
			this.elementoRefer�ncia.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoRefer�ncia.Text = "Refer�ncia";
			// 
			// elemento�ndice
			// 
			this.elemento�ndice.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elemento�ndice.Text = "�ndice";
			// 
			// elementoPeso
			// 
			this.elementoPeso.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoPeso.Text = "Peso";
			// 
			// elementoC�digoBarras
			// 
			this.elementoC�digoBarras.ImageIndex = 1;
			this.elementoC�digoBarras.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.elementoC�digoBarras.Text = "C�digo de Barras";
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
			// �conesElementos
			// 
			this.�conesElementos.ImageSize = new System.Drawing.Size(16, 16);
			this.�conesElementos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("�conesElementos.ImageStream")));
			this.�conesElementos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "Clique nas op��es abaixo para inserir o elemento no leiaute da etiqueta:";
			// 
			// quadroConfigura��o
			// 
			this.quadroConfigura��o.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroConfigura��o.bInfDirArredondada = true;
			this.quadroConfigura��o.bInfEsqArredondada = true;
			this.quadroConfigura��o.bSupDirArredondada = true;
			this.quadroConfigura��o.bSupEsqArredondada = true;
			this.quadroConfigura��o.Controls.Add(this.op��oCancelar);
			this.quadroConfigura��o.Controls.Add(this.op��oSalvar);
			this.quadroConfigura��o.Cor = System.Drawing.Color.Black;
			this.quadroConfigura��o.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroConfigura��o.LetraT�tulo = System.Drawing.Color.White;
			this.quadroConfigura��o.Location = new System.Drawing.Point(8, 16);
			this.quadroConfigura��o.Name = "quadroConfigura��o";
			this.quadroConfigura��o.Size = new System.Drawing.Size(160, 80);
			this.quadroConfigura��o.TabIndex = 1;
			this.quadroConfigura��o.Tamanho = 30;
			this.quadroConfigura��o.T�tulo = "Configura��o";
			// 
			// op��oCancelar
			// 
			this.op��oCancelar.BackColor = System.Drawing.Color.Transparent;
			this.op��oCancelar.Descri��o = "Cancelar";
			this.op��oCancelar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oCancelar.Imagem")));
			this.op��oCancelar.Location = new System.Drawing.Point(8, 56);
			this.op��oCancelar.Name = "op��oCancelar";
			this.op��oCancelar.Size = new System.Drawing.Size(144, 24);
			this.op��oCancelar.TabIndex = 3;
			this.op��oCancelar.Click += new System.EventHandler(this.op��oCancelar_Click);
			// 
			// op��oSalvar
			// 
			this.op��oSalvar.BackColor = System.Drawing.Color.Transparent;
			this.op��oSalvar.Descri��o = "Salvar configura��o";
			this.op��oSalvar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oSalvar.Imagem")));
			this.op��oSalvar.Location = new System.Drawing.Point(8, 32);
			this.op��oSalvar.Name = "op��oSalvar";
			this.op��oSalvar.Size = new System.Drawing.Size(144, 24);
			this.op��oSalvar.TabIndex = 1;
			this.op��oSalvar.Click += new System.EventHandler(this.op��oSalvar_Click);
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
			this.quadroConfigura��o.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao teclar em campo num�rico. Somente n�meros e
		/// separador de decimais s�o aceitos.
		/// </summary>
		private void AoTeclarN�meros(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
		/// Ocorre ao carregar o controle de configura��o de etiqueta
		/// </summary>
		private void ConfigurarEtiqueta_Load(object sender, System.EventArgs e)
		{
			txtLargura.Text = layoutEtiqueta.Width.ToString(NumberFormatInfo.CurrentInfo);
			txtAltura.Text  = layoutEtiqueta.Height.ToString(NumberFormatInfo.CurrentInfo);

			txtEspa�amentoHorizontal.Text = labelLayout.GapHorizontal.ToString(NumberFormatInfo.CurrentInfo);
			txtEspa�amentoVertical.Text = labelLayout.GapVertical.ToString(NumberFormatInfo.CurrentInfo);

			txtMargemSuperior.Text = labelLayout.MarginTop.ToString(NumberFormatInfo.CurrentInfo);
			txtMargemEsquerda.Text = labelLayout.MarginLeft.ToString(NumberFormatInfo.CurrentInfo);
			txtMargemDireita.Text  = labelLayout.MarginRight.ToString(NumberFormatInfo.CurrentInfo);
			txtMargemInferior.Text = labelLayout.MarginBottom.ToString(NumberFormatInfo.CurrentInfo);

			propriedades.SelectedObject = layoutEtiqueta;

			txtLarguraFolha.Text = (labelLayout.PaperSize.Width * 0.0254f).ToString(NumberFormatInfo.CurrentInfo);
			txtAlturaFolha.Text  = (labelLayout.PaperSize.Height * 0.0254f).ToString(NumberFormatInfo.CurrentInfo);
		}

		/// <summary>
		/// Ocorre ao clicar em um bot�o da barra de elementos
		/// </summary>
		private void barraElementos_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Pushed)
			{
				DesmarcarBot�esElementos(e.Button);

				propriedades.Enabled = false;

				if (e.Button == elementoRefer�ncia)
					layoutDesign.Insert(typeof(Impress�o.Layout.Refer�ncia));
			
				else if (e.Button == elemento�ndice)
					layoutDesign.Insert(typeof(Impress�o.Layout.�ndice));

				else if (e.Button == elementoFaixaGrupo)
					layoutDesign.Insert(typeof(Impress�o.Layout.FaixaGrupo));

				else if (e.Button == elementoPeso)
					layoutDesign.Insert(typeof(Impress�o.Layout.Peso));

				else if (e.Button == elementoC�digoBarras)
					layoutDesign.Insert(typeof(Impress�o.Layout.C�digoDeBarras));

				else if (e.Button == elementoFoto)
					layoutDesign.Insert(typeof(Impress�o.Layout.Foto));

				else if (e.Button == elementoLogo)
					layoutDesign.Insert(typeof(Impress�o.Layout.Logotipo));

				else if (e.Button == elementoTexto)
					layoutDesign.Insert(typeof(Report.Layout.Complex.StaticLabel));

				propriedades.Enabled = true;
			}
			else
				layoutDesign.SetPointer(true);
		}

		/// <summary>
		/// Desmarca todos os bot�es de elementos, com exce��o
		/// de um espec�fico.
		/// </summary>
		/// <param name="exce��o">�nico bot�o a n�o ser desmarcado</param>
		private void DesmarcarBot�esElementos(ToolBarButton exce��o)
		{
			foreach (ToolBarButton bot�o in barraElementos.Buttons)
				if (bot�o != exce��o && bot�o.Pushed)
					bot�o.Pushed = false;
		}

		/// <summary>
		/// Ocorre ao selecionar �tem no designer de leiaute
		/// </summary>
		private void layoutDesign_SelectedItemChanged(Report.Designer.LayoutDesign sender, Report.Layout.Complex.IPrintableItem selection)
		{
			if (propriedades.Enabled)
			{
				if (selection != null)
					propriedades.SelectedObject = selection;
				else
					propriedades.SelectedObject = layoutEtiqueta;

				DesmarcarBot�esElementos(null);
			}
		}

		/// <summary>
		/// Ocorre ao alterar alguma propriedade de algum elemento
		/// </summary>
		private void propriedades_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			layoutDesign.Redraw();
		}

		#region Mapeamento de propriedades do labelLayout para o formul�rio

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

		private void txtEspa�amentoHorizontal_Validated(object sender, System.EventArgs e)
		{
			labelLayout.GapHorizontal = float.Parse(txtEspa�amentoHorizontal.Text, NumberFormatInfo.CurrentInfo);
		}

		private void txtEspa�amentoVertical_Validated(object sender, System.EventArgs e)
		{
			labelLayout.GapVertical = float.Parse(txtEspa�amentoVertical.Text, NumberFormatInfo.CurrentInfo);
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
		/// Ocorre ao solicitar salvamento da configura��o
		/// </summary>
		private void op��oSalvar_Click(object sender, System.EventArgs e)
		{
			string configura��o;

			configura��o = GerarConfigura��o();

			// Mostrar janela para salvar configura��o
			using (SalvarConfigura��o dlg = new SalvarConfigura��o())
			{
				bool loop;

				if (formato != null)
					dlg.Formato = formato.Formato;

				do
				{
					loop = false;

					if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
					{
						// Verificar se � um novo formato
						if (formato == null || formato.Formato != dlg.Formato)
						{
							try
							{
								formato = EtiquetaFormato.Cadastrar(dlg.Formato, configura��o);
							}
							catch (Acesso.Comum.Exce��es.EntidadeJ�Existente exce��o)
							{
								switch (MessageBox.Show(this.ParentForm,
									"Este formato j� existe, deseja sobrescrev�-lo?",
									"Configura��o de etiqueta",
									MessageBoxButtons.YesNoCancel,
									MessageBoxIcon.Question,
									MessageBoxDefaultButton.Button2))
								{
									case DialogResult.Yes:
										((EtiquetaFormato) exce��o.Entidade).Atualizar();
										break;

									case DialogResult.No:
										loop = true;
										break;

									case DialogResult.Cancel:
										return;
								}
							}
						}
						else // Formato j� existe
						{
							formato.Configura��o = configura��o;
							formato.Atualizar();
						}
					}
				} while (loop);
			}

			SubstituirBase(new ListaEtiquetas());
		}

		/// <summary>
		/// Gera string de configura��o da etiqueta
		/// </summary>
		/// <returns>Configura��o da etiqueta</returns>
		private string GerarConfigura��o()
		{
			XmlDocument doc;

			doc = labelLayout.SaveToXml();

			return doc.OuterXml;
		}

		/// <summary>
		/// Ocorre ao clicar em cancelar
		/// </summary>
		private void op��oCancelar_Click(object sender, System.EventArgs e)
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

			doc.LoadXml(formato.Configura��o);

			labelLayout.Items.Clear();
			labelLayout.ImportType(typeof(Entidades.Mercadoria.Mercadoria));
			labelLayout.LoadFromXml(doc, false);
			
			layoutDesign.Layout = labelLayout.Items[0];

			layoutEtiqueta.Dispose();
			layoutEtiqueta = labelLayout.Items[0];
		}
	}
}

