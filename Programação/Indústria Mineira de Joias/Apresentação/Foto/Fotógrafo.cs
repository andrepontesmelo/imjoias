using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Entidades.�lbum;
using Apresenta��o.�lbum;
using Apresenta��o.Formul�rios;
using Entidades.Configura��o;
using System.Collections.Generic;

namespace Apresenta��o.�lbum.Edi��o.Fotos
{
    /// <summary>
    /// Base inferior para captura de foto da c�mera
    /// e armazenamento no banco de dados.
    /// </summary>
	public class Fot�grafo : Apresenta��o.Formul�rios.BaseInferior
	{
        // Formul�rio
        private System.Windows.Forms.Button btnCapturar;
        private Button btnEscolherC�mera;
        private ContextMenuStrip mnuC�meras;
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private BackgroundWorker bgTratamento;
        private Button btnCadastrar;
        private Quadro quadroOp��es;
        private Op��o op��oProcurar;
        private OpenFileDialog openFileDialog;
        private Button btnFundo;
        private TabControl tabs;
        private TabPage tabFotografe;
        private Quadro quadroFoto;
        private PictureBox picFoto;
        private TabPage tabEscolha;
        private TabPage tabCadastre;
        private Quadro btnCapturarFundo;
        private PainelFotos painelFotos;
        private Quadro quadro�lbum;
        private Op��o op��oApagarFoto;
        public Apresenta��o.�lbum.Edi��o.�lbuns.Lista�lbuns lista�lbuns;
        private Apresenta��o.Mercadoria.QuadroFoto quadroExibi��o;
        private Apresenta��o.Fotos.Identifica��oMercadoria quadroMercadoria;
        private Op��o btnImportar;
        private Op��o op��oRemoverFundo;
		private System.ComponentModel.IContainer components = null;

		public Fot�grafo()
		{
			InitializeComponent();
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnEscolherC�mera = new System.Windows.Forms.Button();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.mnuC�meras = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.bgTratamento = new System.ComponentModel.BackgroundWorker();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.quadroOp��es = new Apresenta��o.Formul�rios.Quadro();
            this.op��oRemoverFundo = new Apresenta��o.Formul�rios.Op��o();
            this.btnImportar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oProcurar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oApagarFoto = new Apresenta��o.Formul�rios.Op��o();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnFundo = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabFotografe = new System.Windows.Forms.TabPage();
            this.tabEscolha = new System.Windows.Forms.TabPage();
            this.btnCapturarFundo = new Apresenta��o.Formul�rios.Quadro();
            this.painelFotos = new Apresenta��o.�lbum.Edi��o.Fotos.PainelFotos();
            this.tabCadastre = new System.Windows.Forms.TabPage();
            this.quadroFoto = new Apresenta��o.Formul�rios.Quadro();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.quadro�lbum = new Apresenta��o.Formul�rios.Quadro();
            this.lista�lbuns = new Apresenta��o.�lbum.Edi��o.�lbuns.Lista�lbuns();
            this.quadroMercadoria = new Apresenta��o.Fotos.Identifica��oMercadoria();
            this.quadroExibi��o = new Apresenta��o.Mercadoria.QuadroFoto();
            this.esquerda.SuspendLayout();
            this.quadroOp��es.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabFotografe.SuspendLayout();
            this.tabEscolha.SuspendLayout();
            this.btnCapturarFundo.SuspendLayout();
            this.quadroFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.quadro�lbum.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroOp��es);
            this.esquerda.Size = new System.Drawing.Size(187, 604);
            this.esquerda.Controls.SetChildIndex(this.quadroOp��es, 0);
            // 
            // btnEscolherC�mera
            // 
            this.btnEscolherC�mera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEscolherC�mera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEscolherC�mera.Image = global::Apresenta��o.Resource.camera;
            this.btnEscolherC�mera.Location = new System.Drawing.Point(6, 44);
            this.btnEscolherC�mera.Name = "btnEscolherC�mera";
            this.btnEscolherC�mera.Size = new System.Drawing.Size(91, 37);
            this.btnEscolherC�mera.TabIndex = 2;
            this.btnEscolherC�mera.Text = "Escolher c�mera";
            this.btnEscolherC�mera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherC�mera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEscolherC�mera.UseVisualStyleBackColor = true;
            this.btnEscolherC�mera.Click += new System.EventHandler(this.btnEscolherC�mera_Click);
            // 
            // btnCapturar
            // 
            this.btnCapturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapturar.BackColor = System.Drawing.Color.Linen;
            this.btnCapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapturar.Location = new System.Drawing.Point(-119, 44);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(168, 37);
            this.btnCapturar.TabIndex = 10;
            this.btnCapturar.Text = "Fotografar!";
            this.btnCapturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapturar.UseVisualStyleBackColor = false;
            this.btnCapturar.Visible = false;
            // 
            // mnuC�meras
            // 
            this.mnuC�meras.Name = "mnuC�meras";
            this.mnuC�meras.Size = new System.Drawing.Size(61, 4);
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Importe uma foto para m�ltiplos �lbuns.";
            this.t�tuloBaseInferior.�coneArredondado = false;
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.Resource.camera;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(210, 0);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(710, 70);
            this.t�tuloBaseInferior.TabIndex = 8;
            this.t�tuloBaseInferior.T�tulo = "Importa��o de foto";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrar.Image = global::Apresenta��o.Resource.saveHS;
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(836, 532);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(104, 37);
            this.btnCadastrar.TabIndex = 11;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // quadroOp��es
            // 
            this.quadroOp��es.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOp��es.bInfDirArredondada = true;
            this.quadroOp��es.bInfEsqArredondada = true;
            this.quadroOp��es.bSupDirArredondada = true;
            this.quadroOp��es.bSupEsqArredondada = true;
            this.quadroOp��es.Controls.Add(this.op��oRemoverFundo);
            this.quadroOp��es.Controls.Add(this.btnImportar);
            this.quadroOp��es.Controls.Add(this.op��oProcurar);
            this.quadroOp��es.Controls.Add(this.op��oApagarFoto);
            this.quadroOp��es.Cor = System.Drawing.Color.Black;
            this.quadroOp��es.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOp��es.LetraT�tulo = System.Drawing.Color.White;
            this.quadroOp��es.Location = new System.Drawing.Point(7, 13);
            this.quadroOp��es.MostrarBot�oMinMax = false;
            this.quadroOp��es.Name = "quadroOp��es";
            this.quadroOp��es.Size = new System.Drawing.Size(160, 81);
            this.quadroOp��es.TabIndex = 2;
            this.quadroOp��es.Tamanho = 30;
            this.quadroOp��es.T�tulo = "Op��es";
            // 
            // op��oRemoverFundo
            // 
            this.op��oRemoverFundo.BackColor = System.Drawing.Color.Transparent;
            this.op��oRemoverFundo.Descri��o = "Remover o fundo...";
            this.op��oRemoverFundo.Imagem = global::Apresenta��o.Resource.Excluir;
            this.op��oRemoverFundo.Location = new System.Drawing.Point(10, 81);
            this.op��oRemoverFundo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oRemoverFundo.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRemoverFundo.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRemoverFundo.Name = "op��oRemoverFundo";
            this.op��oRemoverFundo.Size = new System.Drawing.Size(150, 16);
            this.op��oRemoverFundo.TabIndex = 5;
            this.op��oRemoverFundo.Visible = false;
            this.op��oRemoverFundo.Click += new System.EventHandler(this.op��oRemoverFundo_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Transparent;
            this.btnImportar.Descri��o = "Escolher arquivo...";
            this.btnImportar.Imagem = global::Apresenta��o.Resource.openfolderHS;
            this.btnImportar.Location = new System.Drawing.Point(10, 57);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnImportar.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnImportar.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(150, 16);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // op��oProcurar
            // 
            this.op��oProcurar.BackColor = System.Drawing.Color.Transparent;
            this.op��oProcurar.Descri��o = "Alterar outra fotografia";
            this.op��oProcurar.Imagem = global::Apresenta��o.Resource.Lupa;
            this.op��oProcurar.Location = new System.Drawing.Point(10, 98);
            this.op��oProcurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oProcurar.Name = "op��oProcurar";
            this.op��oProcurar.Size = new System.Drawing.Size(150, 16);
            this.op��oProcurar.TabIndex = 2;
            this.op��oProcurar.Visible = false;
            this.op��oProcurar.Click += new System.EventHandler(this.op��oProcurar_Click);
            // 
            // op��oApagarFoto
            // 
            this.op��oApagarFoto.BackColor = System.Drawing.Color.Transparent;
            this.op��oApagarFoto.Descri��o = "Excluir";
            this.op��oApagarFoto.Enabled = false;
            this.op��oApagarFoto.Imagem = global::Apresenta��o.Resource.Excluir;
            this.op��oApagarFoto.Location = new System.Drawing.Point(10, 33);
            this.op��oApagarFoto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oApagarFoto.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oApagarFoto.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oApagarFoto.Name = "op��oApagarFoto";
            this.op��oApagarFoto.Size = new System.Drawing.Size(150, 24);
            this.op��oApagarFoto.TabIndex = 3;
            this.op��oApagarFoto.Click += new System.EventHandler(this.op��oApagarFoto_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Formatos comuns de imagens (jpg, gif, png e bmp)|*.jpg;*.png;*.gif;*.bmp|Todos os" +
    " arquivos|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Importar foto de arquivo";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnFundo
            // 
            this.btnFundo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFundo.BackColor = System.Drawing.Color.Linen;
            this.btnFundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFundo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFundo.Location = new System.Drawing.Point(-293, 44);
            this.btnFundo.Name = "btnFundo";
            this.btnFundo.Size = new System.Drawing.Size(168, 37);
            this.btnFundo.TabIndex = 15;
            this.btnFundo.Text = "Informar fundo";
            this.btnFundo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFundo.UseVisualStyleBackColor = false;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabFotografe);
            this.tabs.Controls.Add(this.tabEscolha);
            this.tabs.Controls.Add(this.tabCadastre);
            this.tabs.Location = new System.Drawing.Point(936, 432);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(66, 111);
            this.tabs.TabIndex = 16;
            this.tabs.Visible = false;
            // 
            // tabFotografe
            // 
            this.tabFotografe.Controls.Add(this.btnFundo);
            this.tabFotografe.Controls.Add(this.btnCapturar);
            this.tabFotografe.Controls.Add(this.btnEscolherC�mera);
            this.tabFotografe.Location = new System.Drawing.Point(4, 22);
            this.tabFotografe.Name = "tabFotografe";
            this.tabFotografe.Padding = new System.Windows.Forms.Padding(3);
            this.tabFotografe.Size = new System.Drawing.Size(58, 85);
            this.tabFotografe.TabIndex = 0;
            this.tabFotografe.Text = "1. Fotografe";
            this.tabFotografe.UseVisualStyleBackColor = true;
            // 
            // tabEscolha
            // 
            this.tabEscolha.Controls.Add(this.btnCapturarFundo);
            this.tabEscolha.Location = new System.Drawing.Point(4, 22);
            this.tabEscolha.Name = "tabEscolha";
            this.tabEscolha.Padding = new System.Windows.Forms.Padding(3);
            this.tabEscolha.Size = new System.Drawing.Size(58, 85);
            this.tabEscolha.TabIndex = 1;
            this.tabEscolha.Text = "2. Escolha";
            this.tabEscolha.UseVisualStyleBackColor = true;
            // 
            // btnCapturarFundo
            // 
            this.btnCapturarFundo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapturarFundo.AutoScroll = true;
            this.btnCapturarFundo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.btnCapturarFundo.bInfDirArredondada = true;
            this.btnCapturarFundo.bInfEsqArredondada = true;
            this.btnCapturarFundo.bSupDirArredondada = true;
            this.btnCapturarFundo.bSupEsqArredondada = true;
            this.btnCapturarFundo.Controls.Add(this.painelFotos);
            this.btnCapturarFundo.Cor = System.Drawing.Color.Black;
            this.btnCapturarFundo.FundoT�tulo = System.Drawing.Color.IndianRed;
            this.btnCapturarFundo.LetraT�tulo = System.Drawing.Color.White;
            this.btnCapturarFundo.Location = new System.Drawing.Point(6, 6);
            this.btnCapturarFundo.MostrarBot�oMinMax = false;
            this.btnCapturarFundo.Name = "btnCapturarFundo";
            this.btnCapturarFundo.Size = new System.Drawing.Size(58, 85);
            this.btnCapturarFundo.TabIndex = 8;
            this.btnCapturarFundo.Tamanho = 30;
            this.btnCapturarFundo.T�tulo = "Tratamento de fotos";
            // 
            // painelFotos
            // 
            this.painelFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.painelFotos.AutoScroll = true;
            this.painelFotos.FotoSelecionada = null;
            this.painelFotos.Location = new System.Drawing.Point(10, 29);
            this.painelFotos.Name = "painelFotos";
            this.painelFotos.Orienta��oFotos = Apresenta��o.�lbum.Edi��o.Fotos.PainelFotos.Orienta��o.Vertical;
            this.painelFotos.Size = new System.Drawing.Size(58, 157);
            this.painelFotos.TabIndex = 1;
            this.painelFotos.FotoFoiSelecionada += new System.EventHandler(this.painelFotos_FotoFoiSelecionada);
            // 
            // tabCadastre
            // 
            this.tabCadastre.Location = new System.Drawing.Point(4, 22);
            this.tabCadastre.Name = "tabCadastre";
            this.tabCadastre.Size = new System.Drawing.Size(58, 85);
            this.tabCadastre.TabIndex = 2;
            this.tabCadastre.Text = "3. Cadastre";
            this.tabCadastre.UseVisualStyleBackColor = true;
            // 
            // quadroFoto
            // 
            this.quadroFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroFoto.bInfDirArredondada = false;
            this.quadroFoto.bInfEsqArredondada = false;
            this.quadroFoto.bSupDirArredondada = true;
            this.quadroFoto.bSupEsqArredondada = true;
            this.quadroFoto.Controls.Add(this.picFoto);
            this.quadroFoto.Cor = System.Drawing.Color.Black;
            this.quadroFoto.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto.LetraT�tulo = System.Drawing.Color.White;
            this.quadroFoto.Location = new System.Drawing.Point(326, 263);
            this.quadroFoto.MostrarBot�oMinMax = false;
            this.quadroFoto.Name = "quadroFoto";
            this.quadroFoto.Size = new System.Drawing.Size(25, 34);
            this.quadroFoto.TabIndex = 7;
            this.quadroFoto.Tamanho = 30;
            this.quadroFoto.T�tulo = "C�mera";
            // 
            // picFoto
            // 
            this.picFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFoto.Location = new System.Drawing.Point(0, 24);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(25, 34);
            this.picFoto.TabIndex = 1;
            this.picFoto.TabStop = false;
            // 
            // quadro�lbum
            // 
            this.quadro�lbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro�lbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro�lbum.bInfDirArredondada = false;
            this.quadro�lbum.bInfEsqArredondada = false;
            this.quadro�lbum.bSupDirArredondada = true;
            this.quadro�lbum.bSupEsqArredondada = true;
            this.quadro�lbum.Controls.Add(this.quadroFoto);
            this.quadro�lbum.Controls.Add(this.lista�lbuns);
            this.quadro�lbum.Cor = System.Drawing.Color.Black;
            this.quadro�lbum.FundoT�tulo = System.Drawing.Color.IndianRed;
            this.quadro�lbum.LetraT�tulo = System.Drawing.Color.White;
            this.quadro�lbum.Location = new System.Drawing.Point(680, 289);
            this.quadro�lbum.MostrarBot�oMinMax = false;
            this.quadro�lbum.Name = "quadro�lbum";
            this.quadro�lbum.Size = new System.Drawing.Size(260, 229);
            this.quadro�lbum.TabIndex = 13;
            this.quadro�lbum.Tamanho = 30;
            this.quadro�lbum.T�tulo = "Inserir esta foto nestes �lbuns";
            // 
            // lista�lbuns
            // 
            this.lista�lbuns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista�lbuns.Location = new System.Drawing.Point(0, 28);
            this.lista�lbuns.Name = "lista�lbuns";
            this.lista�lbuns.Size = new System.Drawing.Size(260, 201);
            this.lista�lbuns.TabIndex = 4;
            this.lista�lbuns.Alterado += new System.EventHandler(this.lista�lbuns_Alterado);
            // 
            // quadroMercadoria
            // 
            this.quadroMercadoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroMercadoria.BackColor = System.Drawing.Color.Transparent;
            this.quadroMercadoria.Lista�lbuns = this.lista�lbuns;
            this.quadroMercadoria.Location = new System.Drawing.Point(680, 70);
            this.quadroMercadoria.MaximumSize = new System.Drawing.Size(1024, 193);
            this.quadroMercadoria.MinimumSize = new System.Drawing.Size(216, 213);
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.Size = new System.Drawing.Size(260, 213);
            this.quadroMercadoria.TabIndex = 19;
            this.quadroMercadoria.TxtRefer�nciaEnabled = true;
            this.quadroMercadoria.Alterado += QuadroMercadoria_Alterado;
            // 
            // quadroExibi��o
            // 
            this.quadroExibi��o.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroExibi��o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.quadroExibi��o.bInfDirArredondada = true;
            this.quadroExibi��o.bInfEsqArredondada = true;
            this.quadroExibi��o.bSupDirArredondada = true;
            this.quadroExibi��o.bSupEsqArredondada = true;
            this.quadroExibi��o.Cor = System.Drawing.Color.Black;
            this.quadroExibi��o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroExibi��o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroExibi��o.Location = new System.Drawing.Point(208, 70);
            this.quadroExibi��o.MostrarBot�oMinMax = false;
            this.quadroExibi��o.Name = "quadroExibi��o";
            this.quadroExibi��o.Size = new System.Drawing.Size(466, 448);
            this.quadroExibi��o.TabIndex = 18;
            this.quadroExibi��o.Tamanho = 30;
            this.quadroExibi��o.T�tulo = "Foto";
            // 
            // Fot�grafo
            // 
            this.Controls.Add(this.quadroExibi��o);
            this.Controls.Add(this.quadroMercadoria);
            this.Controls.Add(this.quadro�lbum);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Imagem = global::Apresenta��o.Resource.camera;
            this.Name = "Fot�grafo";
            this.Privil�gio = Entidades.Privil�gio.Permiss�o.�lbum;
            this.Size = new System.Drawing.Size(943, 604);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.btnCadastrar, 0);
            this.Controls.SetChildIndex(this.tabs, 0);
            this.Controls.SetChildIndex(this.quadro�lbum, 0);
            this.Controls.SetChildIndex(this.quadroMercadoria, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroExibi��o, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroOp��es.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabFotografe.ResumeLayout(false);
            this.tabEscolha.ResumeLayout(false);
            this.btnCapturarFundo.ResumeLayout(false);
            this.quadroFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.quadro�lbum.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private void QuadroMercadoria_Alterado(string refer�nciaAnterior, string refer�nciaNova)
        {
            if (quadroMercadoria.Foto != null && quadroMercadoria.Foto.Cadastrado)
                Gravar(refer�nciaAnterior, refer�nciaNova);
        }
        #endregion

        /// <summary>
        /// Abre o controle para cadastro de foto, 
        /// j� deixa um album selecionado.
        /// </summary>
        /// <param name="albumSelecionado"></param>
        public void AbrirParaCadastro(Entidades.�lbum.�lbum �lbumSelecionado)
        {
            Limpar();

            if (�lbumSelecionado != null)
                lista�lbuns.Marcar(�lbumSelecionado);
        }

        private void btnEscolherC�mera_Click(object sender, EventArgs e)
        {
            Point p;

            p = PointToScreen(new Point(btnEscolherC�mera.Left, btnEscolherC�mera.Bottom));
            mnuC�meras.Show(p);
        }

        /// <summary>
        /// Inicia tratamento de foto.
        /// </summary>
        private Image TratarFoto(Image imagem)
        {
            TratamentoCores tratamento = new TratamentoCores();

            imagem = tratamento.CorrigirBorda(new Bitmap(imagem));
            Image resultado = tratamento.ProcessarImagem(imagem);
            
            //AoTratarFoto(resultado);
            return resultado;
        }

        /// <summary>
        /// Ocorre ao terminar o tratamento da foto.
        /// </summary>
        private void AoTratarFoto(object sender, RunWorkerCompletedEventArgs e)
        {
            painelFotos.AdicionarFoto((Image)e.Result);
            painelFotos.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Ao selecionar uma foto.
        /// </summary>
        private void painelFotos_FotoFoiSelecionada(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = true;
        }

        private bool ValidarDados()
        {
            return ValidarDados(quadroMercadoria.Foto.Refer�nciaNum�rica, quadroMercadoria.Foto.Refer�nciaNum�rica);
        }

        /// <summary>
        /// Valida dados entrados pelo usu�rio.
        /// </summary>
        /// <returns>Se os dados est�o v�lidos.</returns>
        private bool ValidarDados(string refer�nciaAnterior, string novaRefer�ncia)
        {
            bool ok = quadroMercadoria.ValidarDados();
            bool altera��oRefer�ncia = !refer�nciaAnterior.Equals(novaRefer�ncia);

            if (ok && altera��oRefer�ncia && Foto.ObterFotos(novaRefer�ncia).Length > 0)
                ok = QuestionarUsu�rioExclus�o(novaRefer�ncia);

            return ok;
        }

        private bool QuestionarUsu�rioExclus�o(string refer�ncia)
        {
            return MessageBox.Show(this,
                string.Format("Refer�ncia {0} possui foto que ser� exclu�da. Confirma ?",
                Entidades.Mercadoria.Mercadoria.MascararRefer�ncia(refer�ncia, true)),
                "Confirma��o de exclus�o de foto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        private void Gravar()
        {
            Gravar(quadroMercadoria.Foto.Refer�nciaNum�rica, quadroMercadoria.Foto.Refer�nciaNum�rica);
        }

        private void Gravar(string refer�nciaAntiga, string refer�nciaNova)
        {
            if (ValidarDados(refer�nciaAntiga, refer�nciaNova))
            {
                AguardeDB.Mostrar();

                Cursor.Current = Cursors.WaitCursor;

                bool refer�nciaAlterada = !refer�nciaAntiga.Equals(refer�nciaNova);

                if (refer�nciaAlterada)
                    Foto.Excluir(refer�nciaNova);

                quadroMercadoria.Foto.Imagem = painelFotos.FotoSelecionada;

                // Refaz lista de �lbuns da foto conforme o que est� na tela
                lock (quadroMercadoria.Foto.�lbuns)
                {
                    quadroMercadoria.Foto.�lbuns.Clear();
                    Entidades.�lbum.�lbum[] albuns = lista�lbuns.�lbunsMarcados;

                    foreach (Entidades.�lbum.�lbum �lbum in albuns)
                        quadroMercadoria.Foto.�lbuns.Add(�lbum);
                }
                try
                {
                    if (!quadroMercadoria.Foto.Cadastrado)
                        quadroMercadoria.Foto.Cadastrar();
                    else
                        quadroMercadoria.Foto.Atualizar();
                }
                catch (Exception erro)
                {
                    AguardeDB.Fechar();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("N�o foi poss�vel cadastrar a foto no banco de dados!\n\n" + erro.ToString());
                    return;
                }
                finally
                {
                    AguardeDB.Fechar();
                    Cursor.Current = Cursors.Default;
                }
            }
            else {
                quadroMercadoria.Foto.Refer�nciaNum�rica = refer�nciaAntiga;
                quadroMercadoria.Recarregar();
            }
        }

        /// <summary>
        /// Cadastra a foto no banco de dados.
        /// </summary>
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            {
                if (painelFotos.FotoSelecionada == null)
                {
                    DialogResult resultado = openFileDialog.ShowDialog(ParentForm);
                    if (resultado != DialogResult.OK)
                    {
                        // Cancelou
                        return;
                    }
                }

                Gravar();
                quadroExibi��o.MostrarLogoIMJ();

                if (Foto.ContarFotos(quadroMercadoria.Foto.Refer�nciaNum�rica) > 1)
                    SubstituirBase(new EditarMercadoria(quadroMercadoria.Mercadoria));

                Limpar();

                SubstituirBaseParaAnterior();
            }
            else
                MessageBox.Show("Preencha todos os dados e escolha uma foto para poder efetuar o cadastro.", "Cadastro de foto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Prepara formul�rio para nova inser��o de dados.
        /// </summary>
        private void Limpar()
        {
            painelFotos.Limpar();
            quadroMercadoria.Limpar();
            quadroMercadoria.TxtRefer�nciaEnabled = true;
            btnCadastrar.Visible = true;
            btnImportar.Visible = true;
            op��oApagarFoto.Enabled = false;
        }

        /// <summary>
        /// Ocorre ao clicar em procurar mercadoria.
        /// </summary>
        private void op��oProcurar_Click(object sender, EventArgs e)
        {
            using (ProcurarMercadoria dlg = new ProcurarMercadoria())
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    if (dlg.Mercadoria != null)
                        SubstituirBase(new EditarMercadoria(dlg.Mercadoria));
                    else
                        MessageBox.Show(
                            ParentForm,
                            "Mercadoria n�o encontrada.",
                            "�lbum de fotos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Prepara edi��o de foto.
        /// </summary>
        /// <param name="foto">Foto a ser editada.</param>
        public void Editar(Foto foto)
        {
            painelFotos.Limpar();

            painelFotos.AdicionarFoto(foto.Imagem);
            quadroMercadoria.TxtRefer�nciaEnabled = true;
            quadroMercadoria.Foto = foto;
            quadroExibi��o.MostrarFoto(foto);
            
            painelFotos.Selecionar(0);

            btnCadastrar.Visible = false;
            btnImportar.Visible = false;

            if (!Exibindo)
                Exibir();

            op��oApagarFoto.Enabled = true;
            
        }

        /// <summary>
        /// Usu�rio requisita importa��o de fotos e o sistema
        /// adiciona as fotos escolhidas pelo usu�rio no painel
        /// de fotos.
        /// </summary>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string arquivo in openFileDialog.FileNames)
                try
                {
                    Image imagem;

                    imagem = Image.FromFile(arquivo);
                    painelFotos.AdicionarFoto(imagem);
                    painelFotos.Selecionar(0);

                    Foto f = new Foto();
                    f.Imagem = imagem;

                    quadroExibi��o.MostrarFoto(f);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(
                        this.ParentForm,
                        "N�o foi poss�vel importar o arquivo " + arquivo + ".\n"
                        + "Ocorreu o seguinte erro:\n\n" + erro.Message,
                        "Importar foto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// Ocorre ao clicar em importar foto.
        /// </summary>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(ParentForm);
        }

        internal void AoTratarFoto(Bitmap imagemTratada)
        {
            painelFotos.AdicionarFoto(imagemTratada);
            painelFotos.Cursor = Cursors.Default;
        }
 
        private void op��oApagarFoto_Click(object sender, EventArgs e)
        {
            if (
             MessageBox.Show(
                    this.ParentForm,
                    "Confirma exclus�o?",
                    "�lbum de fotos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                quadroMercadoria.Foto.Descadastrar();
                Controlador.Exibi��o.SubstituirBaseParaAnterior();
            }
        }

        private void lista�lbuns_Alterado(object sender, EventArgs e)
        {
            if (quadroMercadoria.Foto != null && quadroMercadoria.Foto.Cadastrado)
                Gravar();
        }

        private void op��oRemoverFundo_Click(object sender, EventArgs e)
        {
            BaseRemoverFundo novaBase = new BaseRemoverFundo(this);
            novaBase.AoProsseguirRemo��oFundo += novaBase_AoProsseguirRemo��oFundo;
            SubstituirBase(novaBase);
            Bitmap bmp = (Bitmap) quadroMercadoria.Foto.Imagem;
            novaBase.RemoverFundo(bmp);
        }

        void novaBase_AoProsseguirRemo��oFundo(object sender, EventArgs e)
        {
            BaseRemoverFundo baseRemover = (BaseRemoverFundo)sender;
            painelFotos.Limpar();
            painelFotos.AdicionarFoto(baseRemover.ImagemTratada);
            quadroMercadoria.Foto.Imagem = baseRemover.ImagemTratada;
            quadroMercadoria.Foto.Atualizar();
            Entidades.�lbum.CacheMiniaturas.Inst�ncia.Remover(quadroMercadoria.Mercadoria);
            quadroExibi��o.MostrarFoto(quadroMercadoria.Foto);
        }
    }
}
