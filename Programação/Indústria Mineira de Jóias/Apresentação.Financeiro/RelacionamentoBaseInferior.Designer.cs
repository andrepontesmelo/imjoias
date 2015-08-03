using System;
namespace Apresentação.Financeiro
{
    partial class RelacionamentoBaseInferior
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);

        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.integerTextBox1 = new AMS.TextBox.IntegerTextBox();
            this.quadroRelacionamento = new Apresentação.Formulários.Quadro();
            this.bandejaHistórico = new Apresentação.Mercadoria.Bandeja.BandejaHistóricoRelacionamento();
            this.quadroAgrupado = new Apresentação.Formulários.Quadro();
            this.bandejaAgrupada = new Apresentação.Mercadoria.Bandeja.BandejaConsignado();
            this.quadroAlternaBandeja = new Apresentação.Formulários.Quadro();
            this.lblExplicaçãoRelacionamento = new System.Windows.Forms.Label();
            this.optRelacionamento = new System.Windows.Forms.RadioButton();
            this.lblExplicaçãoPedido = new System.Windows.Forms.Label();
            this.optConsignado = new System.Windows.Forms.RadioButton();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroOpçãoPedido = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoOutro = new Apresentação.Formulários.Opção();
            this.opçãoDestravar = new Apresentação.Formulários.Opção();
            this.quadroMercadoria = new Apresentação.Mercadoria.QuadroMercadoria();
            this.quadroFoto = new Apresentação.Mercadoria.QuadroFoto();
            this.button1 = new System.Windows.Forms.Button();
            this.quadroDestravar = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.esquerda.SuspendLayout();
            this.quadroRelacionamento.SuspendLayout();
            this.quadroAgrupado.SuspendLayout();
            this.quadroAlternaBandeja.SuspendLayout();
            this.quadroOpçãoPedido.SuspendLayout();
            this.quadroMercadoria.SuspendLayout();
            this.quadroDestravar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroDestravar);
            this.esquerda.Controls.Add(this.quadroOpçãoPedido);
            this.esquerda.Controls.Add(this.quadroAlternaBandeja);
            this.esquerda.Size = new System.Drawing.Size(187, 648);
            // 
            // integerTextBox1
            // 
            this.integerTextBox1.AllowNegative = true;
            this.integerTextBox1.DigitsInGroup = 0;
            this.integerTextBox1.Flags = 0;
            this.integerTextBox1.Location = new System.Drawing.Point(144, 112);
            this.integerTextBox1.MaxDecimalPlaces = 0;
            this.integerTextBox1.MaxWholeDigits = 9;
            this.integerTextBox1.Name = "integerTextBox1";
            this.integerTextBox1.Prefix = "";
            this.integerTextBox1.RangeMax = 1.7976931348623157E+308;
            this.integerTextBox1.RangeMin = -1.7976931348623157E+308;
            this.integerTextBox1.Size = new System.Drawing.Size(56, 20);
            this.integerTextBox1.TabIndex = 7;
            // 
            // quadroRelacionamento
            // 
            this.quadroRelacionamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroRelacionamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroRelacionamento.bInfDirArredondada = false;
            this.quadroRelacionamento.bInfEsqArredondada = false;
            this.quadroRelacionamento.bSupDirArredondada = true;
            this.quadroRelacionamento.bSupEsqArredondada = true;
            this.quadroRelacionamento.Controls.Add(this.bandejaHistórico);
            this.quadroRelacionamento.Cor = System.Drawing.Color.Black;
            this.quadroRelacionamento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRelacionamento.LetraTítulo = System.Drawing.Color.White;
            this.quadroRelacionamento.Location = new System.Drawing.Point(200, 240);
            this.quadroRelacionamento.MostrarBotãoMinMax = false;
            this.quadroRelacionamento.Name = "quadroRelacionamento";
            this.quadroRelacionamento.Size = new System.Drawing.Size(590, 392);
            this.quadroRelacionamento.TabIndex = 16;
            this.quadroRelacionamento.Tamanho = 30;
            this.quadroRelacionamento.Título = "Histórico do Relacionamento";
            this.quadroRelacionamento.Visible = false;
            // 
            // bandejaHistórico
            // 
            this.bandejaHistórico.Agrupar = false;
            this.bandejaHistórico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaHistórico.AutoGravação = false;
            this.bandejaHistórico.Cotação = 0;
            this.bandejaHistórico.Location = new System.Drawing.Point(1, 23);
            this.bandejaHistórico.MostrarBarraFerramentas = false;
            this.bandejaHistórico.MostrarSalvarAbrir = false;
            this.bandejaHistórico.MostrarStatus = false;
            this.bandejaHistórico.Name = "bandejaHistórico";
            this.bandejaHistórico.OrdenaçãoReferência = false;
            this.bandejaHistórico.PerguntarSeQuerAgrupar = false;
            this.bandejaHistórico.PermitirExclusão = false;
            this.bandejaHistórico.PermitirGravaçãoManual = false;
            this.bandejaHistórico.Size = new System.Drawing.Size(587, 369);
            this.bandejaHistórico.StrIdentificadorNomeArqXml = null;
            this.bandejaHistórico.TabIndex = 2;
            this.bandejaHistórico.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaRelacionada_SeleçãoMudou);
            // 
            // quadroAgrupado
            // 
            this.quadroAgrupado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroAgrupado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroAgrupado.bInfDirArredondada = false;
            this.quadroAgrupado.bInfEsqArredondada = false;
            this.quadroAgrupado.bSupDirArredondada = true;
            this.quadroAgrupado.bSupEsqArredondada = true;
            this.quadroAgrupado.Controls.Add(this.bandejaAgrupada);
            this.quadroAgrupado.Cor = System.Drawing.Color.Black;
            this.quadroAgrupado.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgrupado.LetraTítulo = System.Drawing.Color.White;
            this.quadroAgrupado.Location = new System.Drawing.Point(200, 240);
            this.quadroAgrupado.MostrarBotãoMinMax = false;
            this.quadroAgrupado.Name = "quadroAgrupado";
            this.quadroAgrupado.Size = new System.Drawing.Size(590, 392);
            this.quadroAgrupado.TabIndex = 19;
            this.quadroAgrupado.Tamanho = 30;
            this.quadroAgrupado.Título = "Resumo do relacionamento";
            // 
            // bandejaAgrupada
            // 
            this.bandejaAgrupada.Agrupar = true;
            this.bandejaAgrupada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaAgrupada.AutoGravação = false;
            this.bandejaAgrupada.Cotação = 0;
            this.bandejaAgrupada.Location = new System.Drawing.Point(1, 23);
            this.bandejaAgrupada.MostrarBarraFerramentas = true;
            this.bandejaAgrupada.MostrarSalvarAbrir = false;
            this.bandejaAgrupada.MostrarStatus = true;
            this.bandejaAgrupada.Name = "bandejaAgrupada";
            this.bandejaAgrupada.PerguntarSeQuerAgrupar = false;
            this.bandejaAgrupada.PermitirGravaçãoManual = false;
            this.bandejaAgrupada.Size = new System.Drawing.Size(587, 367);
            this.bandejaAgrupada.StrIdentificadorNomeArqXml = null;
            this.bandejaAgrupada.TabIndex = 2;
            this.bandejaAgrupada.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaPedido_SeleçãoMudou);
            this.bandejaAgrupada.SaquinhosExcluídos += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhosHandler(this.bandejaAgrupada_SaquinhosExcluídos);
            this.bandejaAgrupada.AntesExclusão += new Apresentação.Mercadoria.Bandeja.Bandeja.AntesExclusãoDelegate(this.bandejaAgrupada_AntesExcusão);
            // 
            // quadroAlternaBandeja
            // 
            this.quadroAlternaBandeja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAlternaBandeja.bInfDirArredondada = true;
            this.quadroAlternaBandeja.bInfEsqArredondada = true;
            this.quadroAlternaBandeja.bSupDirArredondada = true;
            this.quadroAlternaBandeja.bSupEsqArredondada = true;
            this.quadroAlternaBandeja.Controls.Add(this.lblExplicaçãoRelacionamento);
            this.quadroAlternaBandeja.Controls.Add(this.optRelacionamento);
            this.quadroAlternaBandeja.Controls.Add(this.lblExplicaçãoPedido);
            this.quadroAlternaBandeja.Controls.Add(this.optConsignado);
            this.quadroAlternaBandeja.Cor = System.Drawing.Color.Black;
            this.quadroAlternaBandeja.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAlternaBandeja.LetraTítulo = System.Drawing.Color.White;
            this.quadroAlternaBandeja.Location = new System.Drawing.Point(8, 119);
            this.quadroAlternaBandeja.MostrarBotãoMinMax = false;
            this.quadroAlternaBandeja.Name = "quadroAlternaBandeja";
            this.quadroAlternaBandeja.Size = new System.Drawing.Size(160, 136);
            this.quadroAlternaBandeja.TabIndex = 2;
            this.quadroAlternaBandeja.Tamanho = 30;
            this.quadroAlternaBandeja.Título = "Modo de exibição";
            // 
            // lblExplicaçãoRelacionamento
            // 
            this.lblExplicaçãoRelacionamento.BackColor = System.Drawing.Color.Transparent;
            this.lblExplicaçãoRelacionamento.Location = new System.Drawing.Point(16, 96);
            this.lblExplicaçãoRelacionamento.Name = "lblExplicaçãoRelacionamento";
            this.lblExplicaçãoRelacionamento.Size = new System.Drawing.Size(136, 32);
            this.lblExplicaçãoRelacionamento.TabIndex = 7;
            this.lblExplicaçãoRelacionamento.Text = "Mostra mercadorias por ordem do relacionamento. ";
            // 
            // optRelacionamento
            // 
            this.optRelacionamento.BackColor = System.Drawing.Color.Transparent;
            this.optRelacionamento.Location = new System.Drawing.Point(8, 80);
            this.optRelacionamento.Name = "optRelacionamento";
            this.optRelacionamento.Size = new System.Drawing.Size(112, 16);
            this.optRelacionamento.TabIndex = 6;
            this.optRelacionamento.Text = "Relacionamento";
            this.optRelacionamento.UseVisualStyleBackColor = false;
            // 
            // lblExplicaçãoPedido
            // 
            this.lblExplicaçãoPedido.BackColor = System.Drawing.Color.Transparent;
            this.lblExplicaçãoPedido.Location = new System.Drawing.Point(16, 48);
            this.lblExplicaçãoPedido.Name = "lblExplicaçãoPedido";
            this.lblExplicaçãoPedido.Size = new System.Drawing.Size(136, 40);
            this.lblExplicaçãoPedido.TabIndex = 5;
            this.lblExplicaçãoPedido.Text = "Mostra todo o pedido agrupado pela referência";
            // 
            // optConsignado
            // 
            this.optConsignado.BackColor = System.Drawing.Color.Transparent;
            this.optConsignado.Checked = true;
            this.optConsignado.Location = new System.Drawing.Point(8, 32);
            this.optConsignado.Name = "optConsignado";
            this.optConsignado.Size = new System.Drawing.Size(112, 16);
            this.optConsignado.TabIndex = 3;
            this.optConsignado.TabStop = true;
            this.optConsignado.Text = "Agrupado";
            this.optConsignado.UseVisualStyleBackColor = false;
            this.optConsignado.CheckedChanged += new System.EventHandler(this.MudarBandeja);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "para Cliente";
            this.título.Imagem = null;
            this.título.Location = new System.Drawing.Point(282, 8);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(584, 70);
            this.título.TabIndex = 21;
            this.título.Título = "Relacionar saída nr. ";
            // 
            // quadroOpçãoPedido
            // 
            this.quadroOpçãoPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOpçãoPedido.bInfDirArredondada = true;
            this.quadroOpçãoPedido.bInfEsqArredondada = true;
            this.quadroOpçãoPedido.bSupDirArredondada = true;
            this.quadroOpçãoPedido.bSupEsqArredondada = true;
            this.quadroOpçãoPedido.Controls.Add(this.opçãoImprimir);
            this.quadroOpçãoPedido.Controls.Add(this.opçãoOutro);
            this.quadroOpçãoPedido.Cor = System.Drawing.Color.Black;
            this.quadroOpçãoPedido.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOpçãoPedido.LetraTítulo = System.Drawing.Color.White;
            this.quadroOpçãoPedido.Location = new System.Drawing.Point(8, 16);
            this.quadroOpçãoPedido.MostrarBotãoMinMax = false;
            this.quadroOpçãoPedido.Name = "quadroOpçãoPedido";
            this.quadroOpçãoPedido.Size = new System.Drawing.Size(160, 97);
            this.quadroOpçãoPedido.TabIndex = 3;
            this.quadroOpçãoPedido.Tamanho = 30;
            this.quadroOpçãoPedido.Título = "Saída";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir...";
            this.opçãoImprimir.Imagem = global::Apresentação.Financeiro.Properties.Resources.impressora___16;
            this.opçãoImprimir.Location = new System.Drawing.Point(8, 32);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 3;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoOutro
            // 
            this.opçãoOutro.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOutro.Descrição = "Escolher outro documento";
            this.opçãoOutro.Imagem = global::Apresentação.Financeiro.Properties.Resources.ok;
            this.opçãoOutro.Location = new System.Drawing.Point(8, 58);
            this.opçãoOutro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoOutro.Name = "opçãoOutro";
            this.opçãoOutro.Size = new System.Drawing.Size(150, 29);
            this.opçãoOutro.TabIndex = 2;
            this.opçãoOutro.Click += new System.EventHandler(this.opçãoOutro_Click);
            // 
            // opçãoDestravar
            // 
            this.opçãoDestravar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoDestravar.Descrição = "Destravar";
            this.opçãoDestravar.Imagem = global::Apresentação.Financeiro.Properties.Resources.cadeado_aberto;
            this.opçãoDestravar.Location = new System.Drawing.Point(13, 105);
            this.opçãoDestravar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoDestravar.Name = "opçãoDestravar";
            this.opçãoDestravar.Privilégio = Entidades.Privilégio.Permissão.ConsignadoDestravar;
            this.opçãoDestravar.Size = new System.Drawing.Size(80, 24);
            this.opçãoDestravar.TabIndex = 5;
            this.opçãoDestravar.Click += new System.EventHandler(this.opçãoDestravar_Click);
            // 
            // quadroMercadoria
            // 
            this.quadroMercadoria.AtualizarFotoNaSeleção = true;
            this.quadroMercadoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroMercadoria.bInfDirArredondada = true;
            this.quadroMercadoria.bInfEsqArredondada = true;
            this.quadroMercadoria.bSupDirArredondada = true;
            this.quadroMercadoria.bSupEsqArredondada = true;
            this.quadroMercadoria.ControleFoto = this.quadroFoto;
            this.quadroMercadoria.Controls.Add(this.button1);
            this.quadroMercadoria.Cor = System.Drawing.Color.Black;
            this.quadroMercadoria.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMercadoria.LetraTítulo = System.Drawing.Color.White;
            this.quadroMercadoria.Location = new System.Drawing.Point(200, 80);
            this.quadroMercadoria.MostrarBotãoMinMax = false;
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.PosicionamentoAutomático = false;
            this.quadroMercadoria.Size = new System.Drawing.Size(320, 152);
            this.quadroMercadoria.TabIndex = 14;
            this.quadroMercadoria.Tamanho = 30;
            this.quadroMercadoria.Título = "Escolha da mercadoria";
            this.quadroMercadoria.EventoAdicionou += new Apresentação.Mercadoria.QuadroMercadoria.AdicionouDelegate(this.quadroMercadoria_EventoAdicionou);
            this.quadroMercadoria.EventoAlterou += new Apresentação.Mercadoria.QuadroMercadoria.AlterouDelegate(this.quadroMercadoria_EventoAlterou);
            // 
            // quadroFoto
            // 
            this.quadroFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.quadroFoto.bInfDirArredondada = true;
            this.quadroFoto.bInfEsqArredondada = true;
            this.quadroFoto.bSupDirArredondada = true;
            this.quadroFoto.bSupEsqArredondada = true;
            this.quadroFoto.Cor = System.Drawing.Color.Black;
            this.quadroFoto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto.LetraTítulo = System.Drawing.Color.White;
            this.quadroFoto.Location = new System.Drawing.Point(528, 80);
            this.quadroFoto.MostrarBotãoMinMax = false;
            this.quadroFoto.Name = "quadroFoto";
            this.quadroFoto.ReportarErros = false;
            this.quadroFoto.Size = new System.Drawing.Size(264, 152);
            this.quadroFoto.TabIndex = 17;
            this.quadroFoto.Tamanho = 30;
            this.quadroFoto.Título = "Mercadoria";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            // 
            // quadroDestravar
            // 
            this.quadroDestravar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDestravar.bInfDirArredondada = true;
            this.quadroDestravar.bInfEsqArredondada = true;
            this.quadroDestravar.bSupDirArredondada = true;
            this.quadroDestravar.bSupEsqArredondada = true;
            this.quadroDestravar.Controls.Add(this.opçãoDestravar);
            this.quadroDestravar.Controls.Add(this.label1);
            this.quadroDestravar.Controls.Add(this.pictureBox1);
            this.quadroDestravar.Cor = System.Drawing.Color.Black;
            this.quadroDestravar.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDestravar.LetraTítulo = System.Drawing.Color.White;
            this.quadroDestravar.Location = new System.Drawing.Point(8, 263);
            this.quadroDestravar.MostrarBotãoMinMax = false;
            this.quadroDestravar.Name = "quadroDestravar";
            this.quadroDestravar.Size = new System.Drawing.Size(160, 129);
            this.quadroDestravar.TabIndex = 4;
            this.quadroDestravar.Tamanho = 30;
            this.quadroDestravar.Título = "Documento Impresso";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 70);
            this.label1.TabIndex = 2;
            this.label1.Text = "Este documento já foi impresso e portanto ele encontra-se travado para que não se" +
                "ja alterado.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Apresentação.Financeiro.Properties.Resources.cadeado_fechado;
            this.pictureBox1.Location = new System.Drawing.Point(130, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 52);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // RelacionamentoBaseInferior
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.título);
            this.Controls.Add(this.quadroRelacionamento);
            this.Controls.Add(this.quadroMercadoria);
            this.Controls.Add(this.quadroFoto);
            this.Controls.Add(this.quadroAgrupado);
            this.Name = "RelacionamentoBaseInferior";
            this.Size = new System.Drawing.Size(800, 648);
            this.Controls.SetChildIndex(this.quadroAgrupado, 0);
            this.Controls.SetChildIndex(this.quadroFoto, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroMercadoria, 0);
            this.Controls.SetChildIndex(this.quadroRelacionamento, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroRelacionamento.ResumeLayout(false);
            this.quadroAgrupado.ResumeLayout(false);
            this.quadroAlternaBandeja.ResumeLayout(false);
            this.quadroOpçãoPedido.ResumeLayout(false);
            this.quadroMercadoria.ResumeLayout(false);
            this.quadroMercadoria.PerformLayout();
            this.quadroDestravar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadroDestravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
