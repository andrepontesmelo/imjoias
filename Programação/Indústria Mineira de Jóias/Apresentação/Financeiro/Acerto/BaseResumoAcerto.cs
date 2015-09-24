using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Acerto;
using Apresentação.Financeiro.Venda;
using Apresentação.Financeiro.Saída;
using Apresentação.Financeiro.Retorno;
using Apresentação.Impressão;
using Apresentação.Formulários.Impressão;
using Entidades.Privilégio;
using Entidades.Pessoa;

namespace Apresentação.Financeiro.Acerto
{
    public class BaseResumoAcerto : Apresentação.Formulários.BaseInferior 
    {
        private AcertoConsignado acerto;

        private Apresentação.Formulários.Quadro quadro1;
        private BandejaAcerto bandejaAcerto;
        private Apresentação.Formulários.Quadro quadroImpressão;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Opção opçãoZerarAcerto;
        private Apresentação.Formulários.Quadro quadroRastro;
        private System.Windows.Forms.Label label1;
        private Apresentação.Formulários.Opção opçãoRastro;
        private Opção opçãoLançarVendas;
        private TableLayoutPanel tableLayoutPanel1;
        private QuadroSimples quadroBateu;
        private PictureBox pictureBox1;
        private Label label2;
        private LinkLabel lnkZerar;
        private Label label3;
        private Label lblFecharBateu;
        private Quadro quadroCorreção;
        private Opção opçãoRetorno;
        private Quadro quadroFórmula;
        private Label lblFórmula;
        private Opção opçãoAlterarFórmula;
        private Apresentação.Formulários.TítuloBaseInferior título;

        private void InitializeComponent()
        {
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.bandejaAcerto = new Apresentação.Financeiro.Acerto.BandejaAcerto();
            this.quadroImpressão = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoZerarAcerto = new Apresentação.Formulários.Opção();
            this.opçãoLançarVendas = new Apresentação.Formulários.Opção();
            this.quadroRastro = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoRastro = new Apresentação.Formulários.Opção();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quadroBateu = new Apresentação.Formulários.QuadroSimples();
            this.lblFecharBateu = new System.Windows.Forms.Label();
            this.lnkZerar = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.quadroCorreção = new Apresentação.Formulários.Quadro();
            this.opçãoRetorno = new Apresentação.Formulários.Opção();
            this.quadroFórmula = new Apresentação.Formulários.Quadro();
            this.lblFórmula = new System.Windows.Forms.Label();
            this.opçãoAlterarFórmula = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroImpressão.SuspendLayout();
            this.quadroRastro.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.quadroBateu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.quadroCorreção.SuspendLayout();
            this.quadroFórmula.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroFórmula);
            this.esquerda.Controls.Add(this.quadroCorreção);
            this.esquerda.Controls.Add(this.quadroRastro);
            this.esquerda.Controls.Add(this.quadroImpressão);
            this.esquerda.Size = new System.Drawing.Size(187, 410);
            this.esquerda.Controls.SetChildIndex(this.quadroImpressão, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroRastro, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroCorreção, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroFórmula, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Abaixo consta a contabilização das mercadorias levadas, retornadas e vendidas.";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.Acerto;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(604, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Acerto de Mercadorias de Gilberto";
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = false;
            this.quadro1.bInfEsqArredondada = false;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.bandejaAcerto);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(3, 69);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(581, 238);
            this.quadro1.TabIndex = 7;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Resumo";
            // 
            // bandejaAcerto
            // 
            this.bandejaAcerto.AbrirInformaçõesAoDuploClique = false;
            this.bandejaAcerto.Acerto = null;
            this.bandejaAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaAcerto.FiltragemAcerto = true;
            this.bandejaAcerto.Location = new System.Drawing.Point(1, 23);
            this.bandejaAcerto.MostrarAgrupar = false;
            this.bandejaAcerto.MostrarAlterarÍndice = false;
            this.bandejaAcerto.MostrarBarraFerramentas = true;
            this.bandejaAcerto.MostrarExcluir = false;
            this.bandejaAcerto.MostrarPreço = false;
            this.bandejaAcerto.MostrarSeleçãoTabela = false;
            this.bandejaAcerto.MostrarStatus = false;
            this.bandejaAcerto.Name = "bandejaAcerto";
            this.bandejaAcerto.OrdenaçãoReferência = true;
            this.bandejaAcerto.PermitirExclusão = false;
            this.bandejaAcerto.PermitirSeleçãoTabela = false;
            this.bandejaAcerto.SepararPeçaPeso = true;
            this.bandejaAcerto.Size = new System.Drawing.Size(579, 214);
            this.bandejaAcerto.TabIndex = 3;
            this.bandejaAcerto.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAcerto_SeleçãoMudou);
            this.bandejaAcerto.DuploClique += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAcerto_DuploClique);
            // 
            // quadroImpressão
            // 
            this.quadroImpressão.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroImpressão.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quadroImpressão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpressão.bInfDirArredondada = true;
            this.quadroImpressão.bInfEsqArredondada = true;
            this.quadroImpressão.bSupDirArredondada = true;
            this.quadroImpressão.bSupEsqArredondada = true;
            this.quadroImpressão.Controls.Add(this.opçãoImprimir);
            this.quadroImpressão.Controls.Add(this.opçãoZerarAcerto);
            this.quadroImpressão.Cor = System.Drawing.Color.Black;
            this.quadroImpressão.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpressão.LetraTítulo = System.Drawing.Color.White;
            this.quadroImpressão.Location = new System.Drawing.Point(7, 13);
            this.quadroImpressão.MostrarBotãoMinMax = false;
            this.quadroImpressão.Name = "quadroImpressão";
            this.quadroImpressão.Size = new System.Drawing.Size(160, 75);
            this.quadroImpressão.TabIndex = 5;
            this.quadroImpressão.Tamanho = 30;
            this.quadroImpressão.Título = "Finalização";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir...";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___161;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 30);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 0;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoZerarAcerto
            // 
            this.opçãoZerarAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoZerarAcerto.Descrição = "Zerar acerto";
            this.opçãoZerarAcerto.Imagem = global::Apresentação.Resource.none;
            this.opçãoZerarAcerto.Location = new System.Drawing.Point(7, 50);
            this.opçãoZerarAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoZerarAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoZerarAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoZerarAcerto.Name = "opçãoZerarAcerto";
            this.opçãoZerarAcerto.Size = new System.Drawing.Size(150, 25);
            this.opçãoZerarAcerto.TabIndex = 2;
            this.opçãoZerarAcerto.Click += new System.EventHandler(this.opçãoZerarAcerto_Click);
            // 
            // opçãoLançarVendas
            // 
            this.opçãoLançarVendas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoLançarVendas.Descrição = "Gerar venda...";
            this.opçãoLançarVendas.Imagem = global::Apresentação.Resource.pagar_em_dólares__pequeno_1;
            this.opçãoLançarVendas.Location = new System.Drawing.Point(7, 30);
            this.opçãoLançarVendas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoLançarVendas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoLançarVendas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoLançarVendas.Name = "opçãoLançarVendas";
            this.opçãoLançarVendas.Size = new System.Drawing.Size(150, 16);
            this.opçãoLançarVendas.TabIndex = 3;
            this.opçãoLançarVendas.Click += new System.EventHandler(this.opçãoLançarVendas_Click);
            // 
            // quadroRastro
            // 
            this.quadroRastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroRastro.bInfDirArredondada = true;
            this.quadroRastro.bInfEsqArredondada = true;
            this.quadroRastro.bSupDirArredondada = true;
            this.quadroRastro.bSupEsqArredondada = true;
            this.quadroRastro.Controls.Add(this.label1);
            this.quadroRastro.Controls.Add(this.opçãoRastro);
            this.quadroRastro.Cor = System.Drawing.Color.Black;
            this.quadroRastro.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRastro.LetraTítulo = System.Drawing.Color.White;
            this.quadroRastro.Location = new System.Drawing.Point(7, 277);
            this.quadroRastro.MostrarBotãoMinMax = false;
            this.quadroRastro.Name = "quadroRastro";
            this.quadroRastro.Size = new System.Drawing.Size(160, 114);
            this.quadroRastro.TabIndex = 6;
            this.quadroRastro.Tamanho = 30;
            this.quadroRastro.Título = "Item selecionado";
            this.quadroRastro.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "Você pode rastrear a referência selecionada a fim de solucionar inconsistências d" +
    "o acerto.";
            // 
            // opçãoRastro
            // 
            this.opçãoRastro.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRastro.Descrição = "Rastrear";
            this.opçãoRastro.Imagem = global::Apresentação.Resource.search;
            this.opçãoRastro.Location = new System.Drawing.Point(7, 90);
            this.opçãoRastro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRastro.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRastro.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRastro.Name = "opçãoRastro";
            this.opçãoRastro.Size = new System.Drawing.Size(150, 24);
            this.opçãoRastro.TabIndex = 2;
            this.opçãoRastro.Click += new System.EventHandler(this.opçãoRastro_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.quadro1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadroBateu, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(193, 89);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(587, 310);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // quadroBateu
            // 
            this.quadroBateu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroBateu.Borda = System.Drawing.Color.OliveDrab;
            this.quadroBateu.Controls.Add(this.lblFecharBateu);
            this.quadroBateu.Controls.Add(this.lnkZerar);
            this.quadroBateu.Controls.Add(this.label3);
            this.quadroBateu.Controls.Add(this.label2);
            this.quadroBateu.Controls.Add(this.pictureBox1);
            this.quadroBateu.Cor1 = System.Drawing.Color.DarkKhaki;
            this.quadroBateu.Cor2 = System.Drawing.Color.DarkOliveGreen;
            this.quadroBateu.Location = new System.Drawing.Point(3, 3);
            this.quadroBateu.Name = "quadroBateu";
            this.quadroBateu.Size = new System.Drawing.Size(581, 60);
            this.quadroBateu.TabIndex = 8;
            this.quadroBateu.Visible = false;
            // 
            // lblFecharBateu
            // 
            this.lblFecharBateu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecharBateu.AutoSize = true;
            this.lblFecharBateu.BackColor = System.Drawing.Color.Transparent;
            this.lblFecharBateu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFecharBateu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFecharBateu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFecharBateu.ForeColor = System.Drawing.Color.LightGray;
            this.lblFecharBateu.Location = new System.Drawing.Point(561, 4);
            this.lblFecharBateu.Name = "lblFecharBateu";
            this.lblFecharBateu.Size = new System.Drawing.Size(16, 15);
            this.lblFecharBateu.TabIndex = 4;
            this.lblFecharBateu.Text = "X";
            this.lblFecharBateu.Click += new System.EventHandler(this.lblFecharBateu_Click);
            // 
            // lnkZerar
            // 
            this.lnkZerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkZerar.AutoSize = true;
            this.lnkZerar.BackColor = System.Drawing.Color.Transparent;
            this.lnkZerar.LinkColor = System.Drawing.Color.LightBlue;
            this.lnkZerar.Location = new System.Drawing.Point(513, 41);
            this.lnkZerar.Name = "lnkZerar";
            this.lnkZerar.Size = new System.Drawing.Size(65, 13);
            this.lnkZerar.TabIndex = 3;
            this.lnkZerar.TabStop = true;
            this.lnkZerar.Text = "Zerar acerto";
            this.lnkZerar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lnkZerar.Click += new System.EventHandler(this.opçãoZerarAcerto_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.OldLace;
            this.label3.Location = new System.Drawing.Point(61, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(517, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Todas as mercadorias levadas ou foram retornadas ou vendidas.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(61, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Acerto bateu!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Apresentação.Resource.Shaking_Hands;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // quadroCorreção
            // 
            this.quadroCorreção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroCorreção.bInfDirArredondada = true;
            this.quadroCorreção.bInfEsqArredondada = true;
            this.quadroCorreção.bSupDirArredondada = true;
            this.quadroCorreção.bSupEsqArredondada = true;
            this.quadroCorreção.Controls.Add(this.opçãoRetorno);
            this.quadroCorreção.Controls.Add(this.opçãoLançarVendas);
            this.quadroCorreção.Cor = System.Drawing.Color.Black;
            this.quadroCorreção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroCorreção.LetraTítulo = System.Drawing.Color.White;
            this.quadroCorreção.Location = new System.Drawing.Point(7, 94);
            this.quadroCorreção.MostrarBotãoMinMax = false;
            this.quadroCorreção.Name = "quadroCorreção";
            this.quadroCorreção.Size = new System.Drawing.Size(160, 77);
            this.quadroCorreção.TabIndex = 7;
            this.quadroCorreção.Tamanho = 30;
            this.quadroCorreção.Título = "Correção";
            // 
            // opçãoRetorno
            // 
            this.opçãoRetorno.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRetorno.Descrição = "Novo retorno...";
            this.opçãoRetorno.Imagem = global::Apresentação.Resource.Retorno__Ícone_;
            this.opçãoRetorno.Location = new System.Drawing.Point(7, 50);
            this.opçãoRetorno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRetorno.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRetorno.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRetorno.Name = "opçãoRetorno";
            this.opçãoRetorno.Size = new System.Drawing.Size(150, 16);
            this.opçãoRetorno.TabIndex = 4;
            this.opçãoRetorno.Click += new System.EventHandler(this.opçãoRetorno_Click);
            // 
            // quadroFórmula
            // 
            this.quadroFórmula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroFórmula.bInfDirArredondada = true;
            this.quadroFórmula.bInfEsqArredondada = true;
            this.quadroFórmula.bSupDirArredondada = true;
            this.quadroFórmula.bSupEsqArredondada = true;
            this.quadroFórmula.Controls.Add(this.lblFórmula);
            this.quadroFórmula.Controls.Add(this.opçãoAlterarFórmula);
            this.quadroFórmula.Cor = System.Drawing.Color.Black;
            this.quadroFórmula.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFórmula.LetraTítulo = System.Drawing.Color.White;
            this.quadroFórmula.Location = new System.Drawing.Point(7, 177);
            this.quadroFórmula.MostrarBotãoMinMax = false;
            this.quadroFórmula.Name = "quadroFórmula";
            this.quadroFórmula.Size = new System.Drawing.Size(160, 94);
            this.quadroFórmula.TabIndex = 8;
            this.quadroFórmula.Tamanho = 30;
            this.quadroFórmula.Título = "Coluna Acerto";
            // 
            // lblFórmula
            // 
            this.lblFórmula.BackColor = System.Drawing.Color.Transparent;
            this.lblFórmula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFórmula.Location = new System.Drawing.Point(3, 30);
            this.lblFórmula.Name = "lblFórmula";
            this.lblFórmula.Size = new System.Drawing.Size(154, 31);
            this.lblFórmula.TabIndex = 3;
            this.lblFórmula.Text = "=\r\nSaída - Venda - Retorno";
            this.lblFórmula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // opçãoAlterarFórmula
            // 
            this.opçãoAlterarFórmula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.opçãoAlterarFórmula.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAlterarFórmula.Descrição = "Alterar fórmula";
            this.opçãoAlterarFórmula.Imagem = global::Apresentação.Resource.propriedades;
            this.opçãoAlterarFórmula.Location = new System.Drawing.Point(5, 73);
            this.opçãoAlterarFórmula.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoAlterarFórmula.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAlterarFórmula.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAlterarFórmula.Name = "opçãoAlterarFórmula";
            this.opçãoAlterarFórmula.Size = new System.Drawing.Size(150, 24);
            this.opçãoAlterarFórmula.TabIndex = 2;
            this.opçãoAlterarFórmula.Click += new System.EventHandler(this.opçãoAlterarFórmula_Click);
            // 
            // BaseResumoAcerto
            // 
            this.Controls.Add(this.título);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BaseResumoAcerto";
            this.Size = new System.Drawing.Size(800, 410);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroImpressão.ResumeLayout(false);
            this.quadroRastro.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.quadroBateu.ResumeLayout(false);
            this.quadroBateu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.quadroCorreção.ResumeLayout(false);
            this.quadroFórmula.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void bandejaAcerto_DuploClique(Apresentação.Mercadoria.Bandeja.Bandeja bandeja, Entidades.ISaquinho saquinho)
        {
            Rastrear();
        }

        public BaseResumoAcerto()
        {
            InitializeComponent();
        }

        private void opçãoZerarAcerto_Click(object sender, EventArgs e)
        {
            bool válido = bandejaAcerto.Acerto.Validar();

            //MessageBox.Show("Apesar desta operação não apagar os documentos, as saídas e retornos não serão mais exibidos nem computados em futuro acerto. As vendas também não serão computadas em novo acerto, no entanto continuarão presentes no histórico de vendas.", "Operação irreversível", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))

            if (!válido && !PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.ZerarAcerto))
            {
                MessageBox.Show(
                    ParentForm,
                    "O acerto não bateu. Você não tem permissão para zerar o acerto.",
                    "Acerto - " + acerto.Cliente.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (!válido)
            {
                if (MessageBox.Show(
                    ParentForm,
                    "ATENÇÃO!\n\nO acerto não bateu! Deseja mesmo zerar o acerto?",
                    "Acerto - " + acerto.Cliente.Nome,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                if (MessageBox.Show(
                    ParentForm,
                    "ATENÇÃO!\n\nESTA É UMA OPERAÇÃO IRREVERSÍVEL!!!\n\nVocê tem certeza mesmo de que deseja continuar?",
                    "Acerto - " + acerto.Cliente.Nome,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                if (MessageBox.Show(
                    ParentForm,
                    "Esta operação será armazenada no histórico do cliente ou representante.",
                    "Acerto - " + acerto.Cliente.Nome,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                if (!Login.ExigirIdentificação(
                    ParentForm, Permissão.ZerarAcerto,
                    acerto.Cliente,
                    "Zerar acerto",
                    "zerar acerto " + acerto.Código.ToString(),
                    string.Format("Confirmando a sua senha, você irá zerar o acerto {0} de {1} que no momento encontra-se incompleto.",
                    acerto.Código, acerto.Cliente.Nome)))
                    return;
            }

            AguardeDB.Mostrar();

            try
            {
                /* Se o acerto estiver OK, entendo que qualquer um possa
                 * zerar o acerto.
                 * -- Júlio, 17/11/2006
                 */
                //Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.ZerarAcerto);

                bandejaAcerto.Acerto.Acertar();

                AguardeDB.Fechar();

                MessageBox.Show(
                ParentForm,
                "O processo de zerar acerto para " + acerto.Cliente.Nome + " foi concluído com êxito.",
                "Zerar acerto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                SubstituirBaseParaInicial();
                Dispose();
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        public void Carregar(AcertoConsignado acerto)
        {
            this.acerto = acerto;

            if (Representante.ÉRepresentante(acerto.Cliente))
                opçãoLançarVendas.Enabled = false;
            else
                opçãoLançarVendas.Enabled &= !acerto.Acertado;

            opçãoZerarAcerto.Enabled &= !acerto.Acertado;
        }

        private void Recarregar()
        {
            // Apresentação.Formulários.AguardeDB.Mostrar();
            título.Título = "Acerto de Mercadorias (cod " + this.acerto.Código.ToString() + ") de " + this.acerto.Cliente.Nome;

            ControleAcertoMercadorias acerto = new ControleAcertoMercadorias(this.acerto); 
            bandejaAcerto.Abrir(acerto);

            quadroBateu.Visible = !this.acerto.Acertado && bandejaAcerto.Acerto.Validar();
            
            opçãoLançarVendas.Enabled = !acerto.Acerto.Acertado;
            opçãoRetorno.Enabled = !acerto.Acerto.Acertado;
            quadroCorreção.Visible = !acerto.Acerto.Acertado;
            lblFórmula.Text =
                (this.acerto.FórmulaAcerto == FórmulaAcerto.Padrão) ?
                "=\nSaída - Retorno - Venda" : "=\nVenda - Devolução";

            //Apresentação.Formulários.AguardeDB.Fechar();
        }

        private void opçãoRastro_Click(object sender, EventArgs e)
        {
            Rastrear();
        }

        private void Rastrear()
        {
            JanelaRastro janela = new JanelaRastro();

            AguardeDB.Mostrar();

            Entidades.Mercadoria.Mercadoria mercadoria = bandejaAcerto.SaquinhoSelecionado.Mercadoria;
            
            if (mercadoria.DePeso)
                mercadoria.Peso = bandejaAcerto.SaquinhoSelecionado.Peso;
            
            janela.EditarDocumento += new JanelaRastro.EditarDocumentoDelegate(janela_EditarDocumento);
            janela.Abrir(mercadoria, bandejaAcerto.Acerto, this.ParentForm);
            
            AguardeDB.Fechar();
        }

        private void janela_EditarDocumento(JanelaRastro janela, RastroItem rastro)
        {
            if (rastro == null)
            {
                MessageBox.Show(
                    ParentForm,
                    "Por favor, antes de escolher editar documento, selecione o documento a ser editado.",
                    "Editar documento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UseWaitCursor = true;
                AguardeDB.Mostrar();
                Application.DoEvents();

                try
                {
                    Entidades.Relacionamento.RelacionamentoAcerto relacionamento = rastro.ObterRelacionamento();

                    if (relacionamento == null)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "Não foi possível carregar o relacionamento do item selecionado.",
                            "Editar documento",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    switch (rastro.Tipo)
                    {
                        case RastroItem.TipoEnum.Venda:
                            BaseEditarVenda baseInferiorVenda = new BaseEditarVenda();
                            baseInferiorVenda.Abrir(relacionamento);
                            SubstituirBase(baseInferiorVenda);
                            break;

                        case RastroItem.TipoEnum.Saída:
                            SaídaBaseInferior baseInferiorSaída = new SaídaBaseInferior();
                            baseInferiorSaída.Abrir(relacionamento);
                            SubstituirBase(baseInferiorSaída);
                            break;
                        case RastroItem.TipoEnum.Retorno:
                            RetornoBaseInferior baseInferiorRetorno = new RetornoBaseInferior();
                            baseInferiorRetorno.Abrir(relacionamento);
                            SubstituirBase(baseInferiorRetorno);
                            break;
                        default:
                            throw new Exception("Tipo inexistente");
                    }
                }
                finally
                {
                    Apresentação.Formulários.AguardeDB.Fechar();
                    UseWaitCursor = false;
                }
            }
        }

        private void bandejaAcerto_SeleçãoMudou(Apresentação.Mercadoria.Bandeja.Bandeja bandeja, Entidades.ISaquinho saquinho)
        {
            quadroRastro.Visible = saquinho != null;
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            //JanelaImpressão j = new Apresentação.Financeiro.Acerto.JanelaImpressão(bandejaAcerto.Acerto);
            //j.Abrir(this);

            if (!acerto.Cotação.HasValue)
            {
                MessageBox.Show("Por favor, atribua uma cotação ao acerto", "Operação cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento.Acerto))
            {
                dlg.PermitirEscolherPágina = true;

                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    FilaImpressão fila = FilaImpressão.ObterFila(dlg.ControleImpressão, dlg.Impressora);
                
                    fila.Imprimir(bandejaAcerto.Acerto, dlg.PáginaInicial, dlg.PáginaFinal, dlg.NúmeroCópias);
                }
            }
        }


        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void opçãoLançarVendas_Click(object sender, EventArgs e)
        {
            Entidades.Relacionamento.Venda.Venda venda;
            Venda.BaseEditarVenda baseInferior;

            if (!acerto.Cotação.HasValue)
            {
                MessageBox.Show(this,
                    "Favor escolher uma cotação para o acerto primeiro.",
                    "Acerto sem cotação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }
            if (MessageBox.Show(
                ParentForm,
                "Deseja mesmo lançar automaticamente a venda para todos as mercadorias que estão faltando?",
                "Lançar venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AguardeDB.Mostrar();

                try
                {
                    venda = bandejaAcerto.Acerto.LançarVenda();
                    baseInferior = new BaseEditarVenda();
                    baseInferior.Abrir(venda);
                    baseInferior.MostrarItens();
                    SubstituirBase(baseInferior);
                }
                catch (NotSupportedException err)
                {
                    AguardeDB.Fechar();

                    MessageBox.Show(this, err.Message,
                        "Operação não suportada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }

        private void lblFecharBateu_Click(object sender, EventArgs e)
        {
            quadroBateu.Visible = false;
        }

        private void opçãoRetorno_Click(object sender, EventArgs e)
        {
            Entidades.Relacionamento.Retorno.Retorno retorno;
            Retorno.RetornoBaseInferior baseInferior = null;

            // Gerar retorno.
            retorno = new Entidades.Relacionamento.Retorno.Retorno(acerto.Cliente);
            retorno.DigitadoPor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            retorno.TabelaPreço = acerto.TabelaPreço;

            acerto.Retornos.Adicionar(retorno);

            // Mudar interface gráfica.
            try
            {
                baseInferior = new Apresentação.Financeiro.Retorno.RetornoBaseInferior();
                baseInferior.Abrir(retorno);
            }
            catch (ExceçãoTabelaVazia)
            {
                acerto.Retornos.Remover(retorno);

                if (baseInferior != null)
                    baseInferior.Dispose();

                return;
            }

            SubstituirBase(baseInferior);
        }

        private void opçãoAlterarFórmula_Click(object sender, EventArgs e)
        {
            JanelaEscolhaFórmula janela = new JanelaEscolhaFórmula();
            janela.Fórmula = acerto.FórmulaAcerto;

            if ((janela.ShowDialog() == DialogResult.OK)
                && (acerto.FórmulaAcerto != janela.Fórmula))
            {
                acerto.FórmulaAcerto = janela.Fórmula;
                Apresentação.Formulários.AguardeDB.Mostrar();
                acerto.Atualizar();
                Recarregar();
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }
    }
}
