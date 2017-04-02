using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Entidades.Álbum;
using Apresentação.Álbum;
using Apresentação.Formulários;
using Entidades.Configuração;
using System.Collections.Generic;

namespace Apresentação.Álbum.Edição.Fotos
{
    /// <summary>
    /// Base inferior para captura de foto da câmera
    /// e armazenamento no banco de dados.
    /// </summary>
	public class Fotógrafo : Apresentação.Formulários.BaseInferior
	{
        // Formulário
        private System.Windows.Forms.Button btnCapturar;
        private Button btnEscolherCâmera;
        private ContextMenuStrip mnuCâmeras;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private BackgroundWorker bgTratamento;
        private Button btnCadastrar;
        private Quadro quadroOpções;
        private Opção opçãoProcurar;
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
        private Quadro quadroÁlbum;
        private Opção opçãoApagarFoto;
        public Apresentação.Álbum.Edição.Álbuns.ListaÁlbuns listaÁlbuns;
        private Apresentação.Mercadoria.QuadroFoto quadroExibição;
        private Apresentação.Fotos.IdentificaçãoMercadoria quadroMercadoria;
        private Opção btnImportar;
        private Opção opçãoRemoverFundo;
		private System.ComponentModel.IContainer components = null;

		public Fotógrafo()
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
            this.btnEscolherCâmera = new System.Windows.Forms.Button();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.mnuCâmeras = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.bgTratamento = new System.ComponentModel.BackgroundWorker();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.quadroOpções = new Apresentação.Formulários.Quadro();
            this.opçãoRemoverFundo = new Apresentação.Formulários.Opção();
            this.btnImportar = new Apresentação.Formulários.Opção();
            this.opçãoProcurar = new Apresentação.Formulários.Opção();
            this.opçãoApagarFoto = new Apresentação.Formulários.Opção();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnFundo = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabFotografe = new System.Windows.Forms.TabPage();
            this.tabEscolha = new System.Windows.Forms.TabPage();
            this.btnCapturarFundo = new Apresentação.Formulários.Quadro();
            this.painelFotos = new Apresentação.Álbum.Edição.Fotos.PainelFotos();
            this.tabCadastre = new System.Windows.Forms.TabPage();
            this.quadroFoto = new Apresentação.Formulários.Quadro();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.quadroÁlbum = new Apresentação.Formulários.Quadro();
            this.listaÁlbuns = new Apresentação.Álbum.Edição.Álbuns.ListaÁlbuns();
            this.quadroMercadoria = new Apresentação.Fotos.IdentificaçãoMercadoria();
            this.quadroExibição = new Apresentação.Mercadoria.QuadroFoto();
            this.esquerda.SuspendLayout();
            this.quadroOpções.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabFotografe.SuspendLayout();
            this.tabEscolha.SuspendLayout();
            this.btnCapturarFundo.SuspendLayout();
            this.quadroFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.quadroÁlbum.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroOpções);
            this.esquerda.Size = new System.Drawing.Size(187, 604);
            this.esquerda.Controls.SetChildIndex(this.quadroOpções, 0);
            // 
            // btnEscolherCâmera
            // 
            this.btnEscolherCâmera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEscolherCâmera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEscolherCâmera.Image = global::Apresentação.Resource.camera;
            this.btnEscolherCâmera.Location = new System.Drawing.Point(6, 44);
            this.btnEscolherCâmera.Name = "btnEscolherCâmera";
            this.btnEscolherCâmera.Size = new System.Drawing.Size(91, 37);
            this.btnEscolherCâmera.TabIndex = 2;
            this.btnEscolherCâmera.Text = "Escolher câmera";
            this.btnEscolherCâmera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherCâmera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEscolherCâmera.UseVisualStyleBackColor = true;
            this.btnEscolherCâmera.Click += new System.EventHandler(this.btnEscolherCâmera_Click);
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
            // mnuCâmeras
            // 
            this.mnuCâmeras.Name = "mnuCâmeras";
            this.mnuCâmeras.Size = new System.Drawing.Size(61, 4);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Importe uma foto para múltiplos álbuns.";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.camera;
            this.títuloBaseInferior.Location = new System.Drawing.Point(210, 0);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(710, 70);
            this.títuloBaseInferior.TabIndex = 8;
            this.títuloBaseInferior.Título = "Importação de foto";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrar.Image = global::Apresentação.Resource.saveHS;
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
            // quadroOpções
            // 
            this.quadroOpções.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOpções.bInfDirArredondada = true;
            this.quadroOpções.bInfEsqArredondada = true;
            this.quadroOpções.bSupDirArredondada = true;
            this.quadroOpções.bSupEsqArredondada = true;
            this.quadroOpções.Controls.Add(this.opçãoRemoverFundo);
            this.quadroOpções.Controls.Add(this.btnImportar);
            this.quadroOpções.Controls.Add(this.opçãoProcurar);
            this.quadroOpções.Controls.Add(this.opçãoApagarFoto);
            this.quadroOpções.Cor = System.Drawing.Color.Black;
            this.quadroOpções.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOpções.LetraTítulo = System.Drawing.Color.White;
            this.quadroOpções.Location = new System.Drawing.Point(7, 13);
            this.quadroOpções.MostrarBotãoMinMax = false;
            this.quadroOpções.Name = "quadroOpções";
            this.quadroOpções.Size = new System.Drawing.Size(160, 81);
            this.quadroOpções.TabIndex = 2;
            this.quadroOpções.Tamanho = 30;
            this.quadroOpções.Título = "Opções";
            // 
            // opçãoRemoverFundo
            // 
            this.opçãoRemoverFundo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRemoverFundo.Descrição = "Remover o fundo...";
            this.opçãoRemoverFundo.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoRemoverFundo.Location = new System.Drawing.Point(10, 81);
            this.opçãoRemoverFundo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRemoverFundo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRemoverFundo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRemoverFundo.Name = "opçãoRemoverFundo";
            this.opçãoRemoverFundo.Size = new System.Drawing.Size(150, 16);
            this.opçãoRemoverFundo.TabIndex = 5;
            this.opçãoRemoverFundo.Visible = false;
            this.opçãoRemoverFundo.Click += new System.EventHandler(this.opçãoRemoverFundo_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Transparent;
            this.btnImportar.Descrição = "Escolher arquivo...";
            this.btnImportar.Imagem = global::Apresentação.Resource.openfolderHS;
            this.btnImportar.Location = new System.Drawing.Point(10, 57);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnImportar.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnImportar.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(150, 16);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // opçãoProcurar
            // 
            this.opçãoProcurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoProcurar.Descrição = "Alterar outra fotografia";
            this.opçãoProcurar.Imagem = global::Apresentação.Resource.Lupa;
            this.opçãoProcurar.Location = new System.Drawing.Point(10, 98);
            this.opçãoProcurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.Name = "opçãoProcurar";
            this.opçãoProcurar.Size = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.TabIndex = 2;
            this.opçãoProcurar.Visible = false;
            this.opçãoProcurar.Click += new System.EventHandler(this.opçãoProcurar_Click);
            // 
            // opçãoApagarFoto
            // 
            this.opçãoApagarFoto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoApagarFoto.Descrição = "Excluir";
            this.opçãoApagarFoto.Enabled = false;
            this.opçãoApagarFoto.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoApagarFoto.Location = new System.Drawing.Point(10, 33);
            this.opçãoApagarFoto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoApagarFoto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoApagarFoto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoApagarFoto.Name = "opçãoApagarFoto";
            this.opçãoApagarFoto.Size = new System.Drawing.Size(150, 24);
            this.opçãoApagarFoto.TabIndex = 3;
            this.opçãoApagarFoto.Click += new System.EventHandler(this.opçãoApagarFoto_Click);
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
            this.tabFotografe.Controls.Add(this.btnEscolherCâmera);
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
            this.btnCapturarFundo.FundoTítulo = System.Drawing.Color.IndianRed;
            this.btnCapturarFundo.LetraTítulo = System.Drawing.Color.White;
            this.btnCapturarFundo.Location = new System.Drawing.Point(6, 6);
            this.btnCapturarFundo.MostrarBotãoMinMax = false;
            this.btnCapturarFundo.Name = "btnCapturarFundo";
            this.btnCapturarFundo.Size = new System.Drawing.Size(58, 85);
            this.btnCapturarFundo.TabIndex = 8;
            this.btnCapturarFundo.Tamanho = 30;
            this.btnCapturarFundo.Título = "Tratamento de fotos";
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
            this.painelFotos.OrientaçãoFotos = Apresentação.Álbum.Edição.Fotos.PainelFotos.Orientação.Vertical;
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
            this.quadroFoto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto.LetraTítulo = System.Drawing.Color.White;
            this.quadroFoto.Location = new System.Drawing.Point(326, 263);
            this.quadroFoto.MostrarBotãoMinMax = false;
            this.quadroFoto.Name = "quadroFoto";
            this.quadroFoto.Size = new System.Drawing.Size(25, 34);
            this.quadroFoto.TabIndex = 7;
            this.quadroFoto.Tamanho = 30;
            this.quadroFoto.Título = "Câmera";
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
            // quadroÁlbum
            // 
            this.quadroÁlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroÁlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroÁlbum.bInfDirArredondada = false;
            this.quadroÁlbum.bInfEsqArredondada = false;
            this.quadroÁlbum.bSupDirArredondada = true;
            this.quadroÁlbum.bSupEsqArredondada = true;
            this.quadroÁlbum.Controls.Add(this.quadroFoto);
            this.quadroÁlbum.Controls.Add(this.listaÁlbuns);
            this.quadroÁlbum.Cor = System.Drawing.Color.Black;
            this.quadroÁlbum.FundoTítulo = System.Drawing.Color.IndianRed;
            this.quadroÁlbum.LetraTítulo = System.Drawing.Color.White;
            this.quadroÁlbum.Location = new System.Drawing.Point(680, 289);
            this.quadroÁlbum.MostrarBotãoMinMax = false;
            this.quadroÁlbum.Name = "quadroÁlbum";
            this.quadroÁlbum.Size = new System.Drawing.Size(260, 229);
            this.quadroÁlbum.TabIndex = 13;
            this.quadroÁlbum.Tamanho = 30;
            this.quadroÁlbum.Título = "Inserir esta foto nestes álbuns";
            // 
            // listaÁlbuns
            // 
            this.listaÁlbuns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaÁlbuns.Location = new System.Drawing.Point(0, 28);
            this.listaÁlbuns.Name = "listaÁlbuns";
            this.listaÁlbuns.Size = new System.Drawing.Size(260, 201);
            this.listaÁlbuns.TabIndex = 4;
            this.listaÁlbuns.Alterado += new System.EventHandler(this.listaÁlbuns_Alterado);
            // 
            // quadroMercadoria
            // 
            this.quadroMercadoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroMercadoria.BackColor = System.Drawing.Color.Transparent;
            this.quadroMercadoria.ListaÁlbuns = this.listaÁlbuns;
            this.quadroMercadoria.Location = new System.Drawing.Point(680, 70);
            this.quadroMercadoria.MaximumSize = new System.Drawing.Size(1024, 193);
            this.quadroMercadoria.MinimumSize = new System.Drawing.Size(216, 213);
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.Size = new System.Drawing.Size(260, 213);
            this.quadroMercadoria.TabIndex = 19;
            this.quadroMercadoria.TxtReferênciaEnabled = true;
            this.quadroMercadoria.Alterado += QuadroMercadoria_Alterado;
            // 
            // quadroExibição
            // 
            this.quadroExibição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroExibição.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.quadroExibição.bInfDirArredondada = true;
            this.quadroExibição.bInfEsqArredondada = true;
            this.quadroExibição.bSupDirArredondada = true;
            this.quadroExibição.bSupEsqArredondada = true;
            this.quadroExibição.Cor = System.Drawing.Color.Black;
            this.quadroExibição.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroExibição.LetraTítulo = System.Drawing.Color.White;
            this.quadroExibição.Location = new System.Drawing.Point(208, 70);
            this.quadroExibição.MostrarBotãoMinMax = false;
            this.quadroExibição.Name = "quadroExibição";
            this.quadroExibição.Size = new System.Drawing.Size(466, 448);
            this.quadroExibição.TabIndex = 18;
            this.quadroExibição.Tamanho = 30;
            this.quadroExibição.Título = "Foto";
            // 
            // Fotógrafo
            // 
            this.Controls.Add(this.quadroExibição);
            this.Controls.Add(this.quadroMercadoria);
            this.Controls.Add(this.quadroÁlbum);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.títuloBaseInferior);
            this.Imagem = global::Apresentação.Resource.camera;
            this.Name = "Fotógrafo";
            this.Privilégio = Entidades.Privilégio.Permissão.Álbum;
            this.Size = new System.Drawing.Size(943, 604);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.btnCadastrar, 0);
            this.Controls.SetChildIndex(this.tabs, 0);
            this.Controls.SetChildIndex(this.quadroÁlbum, 0);
            this.Controls.SetChildIndex(this.quadroMercadoria, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroExibição, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroOpções.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabFotografe.ResumeLayout(false);
            this.tabEscolha.ResumeLayout(false);
            this.btnCapturarFundo.ResumeLayout(false);
            this.quadroFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.quadroÁlbum.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private void QuadroMercadoria_Alterado(string referênciaAnterior, string referênciaNova)
        {
            if (quadroMercadoria.Foto != null && quadroMercadoria.Foto.Cadastrado)
                Gravar(referênciaAnterior, referênciaNova);
        }
        #endregion

        /// <summary>
        /// Abre o controle para cadastro de foto, 
        /// já deixa um album selecionado.
        /// </summary>
        /// <param name="albumSelecionado"></param>
        public void AbrirParaCadastro(Entidades.Álbum.Álbum álbumSelecionado)
        {
            Limpar();

            if (álbumSelecionado != null)
                listaÁlbuns.Marcar(álbumSelecionado);
        }

        private void btnEscolherCâmera_Click(object sender, EventArgs e)
        {
            Point p;

            p = PointToScreen(new Point(btnEscolherCâmera.Left, btnEscolherCâmera.Bottom));
            mnuCâmeras.Show(p);
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
            return ValidarDados(quadroMercadoria.Foto.ReferênciaNumérica, quadroMercadoria.Foto.ReferênciaNumérica);
        }

        /// <summary>
        /// Valida dados entrados pelo usuário.
        /// </summary>
        /// <returns>Se os dados estão válidos.</returns>
        private bool ValidarDados(string referênciaAnterior, string novaReferência)
        {
            bool ok = quadroMercadoria.ValidarDados();
            bool alteraçãoReferência = !referênciaAnterior.Equals(novaReferência);

            if (ok && alteraçãoReferência && Foto.ObterFotos(novaReferência).Length > 0)
                ok = QuestionarUsuárioExclusão(novaReferência);

            return ok;
        }

        private bool QuestionarUsuárioExclusão(string referência)
        {
            return MessageBox.Show(this,
                string.Format("Referência {0} possui foto que será excluída. Confirma ?",
                Entidades.Mercadoria.Mercadoria.MascararReferência(referência, true)),
                "Confirmação de exclusão de foto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        private void Gravar()
        {
            Gravar(quadroMercadoria.Foto.ReferênciaNumérica, quadroMercadoria.Foto.ReferênciaNumérica);
        }

        private void Gravar(string referênciaAntiga, string referênciaNova)
        {
            if (ValidarDados(referênciaAntiga, referênciaNova))
            {
                AguardeDB.Mostrar();

                Cursor.Current = Cursors.WaitCursor;

                bool referênciaAlterada = !referênciaAntiga.Equals(referênciaNova);

                if (referênciaAlterada)
                    Foto.Excluir(referênciaNova);

                quadroMercadoria.Foto.Imagem = painelFotos.FotoSelecionada;

                // Refaz lista de álbuns da foto conforme o que está na tela
                lock (quadroMercadoria.Foto.Álbuns)
                {
                    quadroMercadoria.Foto.Álbuns.Clear();
                    Entidades.Álbum.Álbum[] albuns = listaÁlbuns.ÁlbunsMarcados;

                    foreach (Entidades.Álbum.Álbum álbum in albuns)
                        quadroMercadoria.Foto.Álbuns.Add(álbum);
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
                    MessageBox.Show("Não foi possível cadastrar a foto no banco de dados!\n\n" + erro.ToString());
                    return;
                }
                finally
                {
                    AguardeDB.Fechar();
                    Cursor.Current = Cursors.Default;
                }
            }
            else {
                quadroMercadoria.Foto.ReferênciaNumérica = referênciaAntiga;
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
                quadroExibição.MostrarLogoIMJ();

                if (Foto.ContarFotos(quadroMercadoria.Foto.ReferênciaNumérica) > 1)
                    SubstituirBase(new EditarMercadoria(quadroMercadoria.Mercadoria));

                Limpar();

                SubstituirBaseParaAnterior();
            }
            else
                MessageBox.Show("Preencha todos os dados e escolha uma foto para poder efetuar o cadastro.", "Cadastro de foto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Prepara formulário para nova inserção de dados.
        /// </summary>
        private void Limpar()
        {
            painelFotos.Limpar();
            quadroMercadoria.Limpar();
            quadroMercadoria.TxtReferênciaEnabled = true;
            btnCadastrar.Visible = true;
            btnImportar.Visible = true;
            opçãoApagarFoto.Enabled = false;
        }

        /// <summary>
        /// Ocorre ao clicar em procurar mercadoria.
        /// </summary>
        private void opçãoProcurar_Click(object sender, EventArgs e)
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
                            "Mercadoria não encontrada.",
                            "Álbum de fotos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Prepara edição de foto.
        /// </summary>
        /// <param name="foto">Foto a ser editada.</param>
        public void Editar(Foto foto)
        {
            painelFotos.Limpar();

            painelFotos.AdicionarFoto(foto.Imagem);
            quadroMercadoria.TxtReferênciaEnabled = true;
            quadroMercadoria.Foto = foto;
            quadroExibição.MostrarFoto(foto);
            
            painelFotos.Selecionar(0);

            btnCadastrar.Visible = false;
            btnImportar.Visible = false;

            if (!Exibindo)
                Exibir();

            opçãoApagarFoto.Enabled = true;
            
        }

        /// <summary>
        /// Usuário requisita importação de fotos e o sistema
        /// adiciona as fotos escolhidas pelo usuário no painel
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

                    quadroExibição.MostrarFoto(f);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(
                        this.ParentForm,
                        "Não foi possível importar o arquivo " + arquivo + ".\n"
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
 
        private void opçãoApagarFoto_Click(object sender, EventArgs e)
        {
            if (
             MessageBox.Show(
                    this.ParentForm,
                    "Confirma exclusão?",
                    "Álbum de fotos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                quadroMercadoria.Foto.Descadastrar();
                Controlador.Exibição.SubstituirBaseParaAnterior();
            }
        }

        private void listaÁlbuns_Alterado(object sender, EventArgs e)
        {
            if (quadroMercadoria.Foto != null && quadroMercadoria.Foto.Cadastrado)
                Gravar();
        }

        private void opçãoRemoverFundo_Click(object sender, EventArgs e)
        {
            BaseRemoverFundo novaBase = new BaseRemoverFundo(this);
            novaBase.AoProsseguirRemoçãoFundo += novaBase_AoProsseguirRemoçãoFundo;
            SubstituirBase(novaBase);
            Bitmap bmp = (Bitmap) quadroMercadoria.Foto.Imagem;
            novaBase.RemoverFundo(bmp);
        }

        void novaBase_AoProsseguirRemoçãoFundo(object sender, EventArgs e)
        {
            BaseRemoverFundo baseRemover = (BaseRemoverFundo)sender;
            painelFotos.Limpar();
            painelFotos.AdicionarFoto(baseRemover.ImagemTratada);
            quadroMercadoria.Foto.Imagem = baseRemover.ImagemTratada;
            quadroMercadoria.Foto.Atualizar();
            Entidades.Álbum.CacheMiniaturas.Instância.Remover(quadroMercadoria.Mercadoria);
            quadroExibição.MostrarFoto(quadroMercadoria.Foto);
        }
    }
}
