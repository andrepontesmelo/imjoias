using System;
namespace Apresentação.Financeiro
{
    partial class BaseEditarRelacionamento
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
            this.components = new System.ComponentModel.Container();
            this.verificadorMercadoria = new Apresentação.Financeiro.VerificadorMercadoria(this.components);
            this.digitação = new Apresentação.Financeiro.DigitaçãoComum();
            this.integerTextBox1 = new AMS.TextBox.IntegerTextBox();
            this.quadroAlternaBandeja = new Apresentação.Formulários.Quadro();
            this.optAgrupado = new System.Windows.Forms.RadioButton();
            this.optHistórico = new System.Windows.Forms.RadioButton();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroOpçãoPedido = new Apresentação.Formulários.Quadro();
            this.btnExcluir = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoDestravar = new Apresentação.Formulários.Opção();
            this.quadroDestravar = new Apresentação.Formulários.Quadro();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabItens = new System.Windows.Forms.TabPage();
            this.tabObservações = new System.Windows.Forms.TabPage();
            this.txtObservação = new System.Windows.Forms.RichTextBox();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroAlternaBandeja.SuspendLayout();
            this.quadroOpçãoPedido.SuspendLayout();
            this.quadroDestravar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.Add(this.quadroDestravar);
            this.esquerda.Controls.Add(this.quadroOpçãoPedido);
            this.esquerda.Controls.Add(this.quadroAlternaBandeja);
            this.esquerda.Size = new System.Drawing.Size(187, 648);
            this.esquerda.Controls.SetChildIndex(this.quadroAlternaBandeja, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroOpçãoPedido, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroDestravar, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // verificadorMercadoria
            // 
            this.verificadorMercadoria.Enabled = true;
            // 
            // digitação
            // 
            this.digitação.BackColor = System.Drawing.Color.Transparent;
            this.digitação.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digitação.Location = new System.Drawing.Point(3, 3);
            this.digitação.MinimumSize = new System.Drawing.Size(350, 300);
            this.digitação.MostrarPreço = false;
            this.digitação.Name = "digitação";
            this.digitação.PermitirSeleçãoTabela = false;
            this.digitação.Size = new System.Drawing.Size(576, 542);
            this.digitação.TabIndex = 23;
            this.digitação.TipoExibiçãoAtual = Apresentação.Financeiro.DigitaçãoComum.TipoExibição.TipoAgrupado;
            this.verificadorMercadoria.SetVerificarMercadoria(this.digitação, true);
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
            // quadroAlternaBandeja
            // 
            this.quadroAlternaBandeja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAlternaBandeja.bInfDirArredondada = true;
            this.quadroAlternaBandeja.bInfEsqArredondada = true;
            this.quadroAlternaBandeja.bSupDirArredondada = true;
            this.quadroAlternaBandeja.bSupEsqArredondada = true;
            this.quadroAlternaBandeja.Controls.Add(this.optAgrupado);
            this.quadroAlternaBandeja.Controls.Add(this.optHistórico);
            this.quadroAlternaBandeja.Cor = System.Drawing.Color.Black;
            this.quadroAlternaBandeja.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAlternaBandeja.LetraTítulo = System.Drawing.Color.White;
            this.quadroAlternaBandeja.Location = new System.Drawing.Point(7, 173);
            this.quadroAlternaBandeja.MostrarBotãoMinMax = false;
            this.quadroAlternaBandeja.Name = "quadroAlternaBandeja";
            this.quadroAlternaBandeja.Size = new System.Drawing.Size(160, 93);
            this.quadroAlternaBandeja.TabIndex = 2;
            this.quadroAlternaBandeja.Tamanho = 30;
            this.quadroAlternaBandeja.Título = "Aparência";
            // 
            // optAgrupado
            // 
            this.optAgrupado.BackColor = System.Drawing.Color.Transparent;
            this.optAgrupado.Checked = true;
            this.optAgrupado.Location = new System.Drawing.Point(8, 32);
            this.optAgrupado.Name = "optAgrupado";
            this.optAgrupado.Size = new System.Drawing.Size(145, 16);
            this.optAgrupado.TabIndex = 3;
            this.optAgrupado.TabStop = true;
            this.optAgrupado.Text = "Mercadorias agrupadas";
            this.optAgrupado.UseVisualStyleBackColor = false;
            this.optAgrupado.CheckedChanged += new System.EventHandler(this.AlternarBandeja);
            // 
            // optHistórico
            // 
            this.optHistórico.BackColor = System.Drawing.Color.Transparent;
            this.optHistórico.Location = new System.Drawing.Point(8, 45);
            this.optHistórico.Name = "optHistórico";
            this.optHistórico.Size = new System.Drawing.Size(145, 45);
            this.optHistórico.TabIndex = 6;
            this.optHistórico.Text = "Histórico do relacionamento";
            this.optHistórico.UseVisualStyleBackColor = false;
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "para Cliente";
            this.título.Imagem = global::Apresentação.Financeiro.Properties.Resources.moedaunica;
            this.título.Location = new System.Drawing.Point(199, 0);
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
            this.quadroOpçãoPedido.Controls.Add(this.btnExcluir);
            this.quadroOpçãoPedido.Controls.Add(this.opçãoImprimir);
            this.quadroOpçãoPedido.Cor = System.Drawing.Color.Black;
            this.quadroOpçãoPedido.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOpçãoPedido.LetraTítulo = System.Drawing.Color.White;
            this.quadroOpçãoPedido.Location = new System.Drawing.Point(7, 96);
            this.quadroOpçãoPedido.MostrarBotãoMinMax = false;
            this.quadroOpçãoPedido.Name = "quadroOpçãoPedido";
            this.quadroOpçãoPedido.Size = new System.Drawing.Size(160, 71);
            this.quadroOpçãoPedido.TabIndex = 3;
            this.quadroOpçãoPedido.Tamanho = 30;
            this.quadroOpçãoPedido.Título = "Documento";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btnExcluir.Descrição = "Excluir documento";
            this.btnExcluir.Imagem = global::Apresentação.Financeiro.Properties.Resources.Excluir;
            this.btnExcluir.Location = new System.Drawing.Point(5, 49);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Privilégio = Entidades.Privilégio.Permissão.VendasDestravar;
            this.btnExcluir.Size = new System.Drawing.Size(150, 24);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir...";
            this.opçãoImprimir.Imagem = global::Apresentação.Financeiro.Properties.Resources.impressora___16;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 27);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(0, 20);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 20);
            this.opçãoImprimir.TabIndex = 3;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoDestravar
            // 
            this.opçãoDestravar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoDestravar.Descrição = "Destravar";
            this.opçãoDestravar.Imagem = global::Apresentação.Financeiro.Properties.Resources.cadeado_aberto;
            this.opçãoDestravar.Location = new System.Drawing.Point(13, 105);
            this.opçãoDestravar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoDestravar.MaximumSize = new System.Drawing.Size(100, 100);
            this.opçãoDestravar.MinimumSize = new System.Drawing.Size(100, 16);
            this.opçãoDestravar.Name = "opçãoDestravar";
            this.opçãoDestravar.Privilégio = Entidades.Privilégio.Permissão.ConsignadoDestravar;
            this.opçãoDestravar.Size = new System.Drawing.Size(100, 24);
            this.opçãoDestravar.TabIndex = 5;
            this.opçãoDestravar.Click += new System.EventHandler(this.opçãoDestravar_Click);
            // 
            // quadroDestravar
            // 
            this.quadroDestravar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDestravar.bInfDirArredondada = true;
            this.quadroDestravar.bInfEsqArredondada = true;
            this.quadroDestravar.bSupDirArredondada = true;
            this.quadroDestravar.bSupEsqArredondada = true;
            this.quadroDestravar.Controls.Add(this.pictureBox1);
            this.quadroDestravar.Controls.Add(this.opçãoDestravar);
            this.quadroDestravar.Controls.Add(this.label1);
            this.quadroDestravar.Cor = System.Drawing.Color.Black;
            this.quadroDestravar.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDestravar.LetraTítulo = System.Drawing.Color.White;
            this.quadroDestravar.Location = new System.Drawing.Point(7, 272);
            this.quadroDestravar.MostrarBotãoMinMax = false;
            this.quadroDestravar.Name = "quadroDestravar";
            this.quadroDestravar.Size = new System.Drawing.Size(160, 129);
            this.quadroDestravar.TabIndex = 4;
            this.quadroDestravar.Tamanho = 30;
            this.quadroDestravar.Título = "Documento Impresso";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Apresentação.Financeiro.Properties.Resources.cadeado_fechado;
            this.pictureBox1.Location = new System.Drawing.Point(130, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 53);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
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
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabItens);
            this.tabs.Controls.Add(this.tabObservações);
            this.tabs.Location = new System.Drawing.Point(193, 74);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(590, 574);
            this.tabs.TabIndex = 24;
            // 
            // tabItens
            // 
            this.tabItens.Controls.Add(this.digitação);
            this.tabItens.Location = new System.Drawing.Point(4, 22);
            this.tabItens.Name = "tabItens";
            this.tabItens.Padding = new System.Windows.Forms.Padding(3);
            this.tabItens.Size = new System.Drawing.Size(582, 548);
            this.tabItens.TabIndex = 0;
            this.tabItens.Text = "Itens";
            this.tabItens.UseVisualStyleBackColor = true;
            // 
            // tabObservações
            // 
            this.tabObservações.Controls.Add(this.txtObservação);
            this.tabObservações.Location = new System.Drawing.Point(4, 22);
            this.tabObservações.Name = "tabObservações";
            this.tabObservações.Padding = new System.Windows.Forms.Padding(3);
            this.tabObservações.Size = new System.Drawing.Size(582, 548);
            this.tabObservações.TabIndex = 1;
            this.tabObservações.Text = "Observações";
            this.tabObservações.UseVisualStyleBackColor = true;
            // 
            // txtObservação
            // 
            this.txtObservação.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservação.Location = new System.Drawing.Point(3, 3);
            this.txtObservação.Name = "txtObservação";
            this.txtObservação.Size = new System.Drawing.Size(576, 542);
            this.txtObservação.TabIndex = 0;
            this.txtObservação.Text = "";
            this.txtObservação.Validated += new System.EventHandler(this.txtObservação_Validated);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label2);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 77);
            this.quadro1.TabIndex = 5;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Gravação automática";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Este documento será gravado automáticamente a cada alteração.";
            // 
            // BaseEditarRelacionamento
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.título);
            this.Controls.Add(this.tabs);
            this.Name = "BaseEditarRelacionamento";
            this.Size = new System.Drawing.Size(800, 648);
            this.Controls.SetChildIndex(this.tabs, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroAlternaBandeja.ResumeLayout(false);
            this.quadroOpçãoPedido.ResumeLayout(false);
            this.quadroDestravar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.tabObservações.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected VerificadorMercadoria verificadorMercadoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.TabControl tabs;
        protected System.Windows.Forms.TabPage tabItens;
        private Apresentação.Formulários.Quadro quadro1;
        private System.Windows.Forms.Label label2;
        protected Apresentação.Formulários.Opção opçãoDestravar;
        protected Apresentação.Formulários.Quadro quadroDestravar;
        protected DigitaçãoComum digitação;
        private Apresentação.Formulários.Opção btnExcluir;
        protected System.Windows.Forms.TabPage tabObservações;
        protected System.Windows.Forms.RichTextBox txtObservação;
    }
}
