namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class BaseEditarPedido
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEditarPedido));
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.label1 = new System.Windows.Forms.Label();
            this.radioEncomenda = new System.Windows.Forms.RadioButton();
            this.radioConserto = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFuncionário = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.label4 = new System.Windows.Forms.Label();
            this.grpIdentificação = new System.Windows.Forms.GroupBox();
            this.txtRegião = new System.Windows.Forms.TextBox();
            this.txtControle = new AMS.TextBox.IntegerTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpRecepção = new System.Windows.Forms.GroupBox();
            this.dtRecepção = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.grpEntrega = new System.Windows.Forms.GroupBox();
            this.lblInfoOficina = new System.Windows.Forms.Label();
            this.chkLevar = new System.Windows.Forms.RadioButton();
            this.chkDespachar = new System.Windows.Forms.RadioButton();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.dtEntrega = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConclusao = new System.Windows.Forms.Button();
            this.dtConclusão = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtPrevisão = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.grpObservações = new System.Windows.Forms.GroupBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.quadroManutenção = new Apresentação.Formulários.Quadro();
            this.opçãoRemoverConclusão = new Apresentação.Formulários.Opção();
            this.opçãoRemoverEntrega = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.quadroPrivilégio = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.label10 = new System.Windows.Forms.Label();
            this.optPertenceEmpresa = new System.Windows.Forms.RadioButton();
            this.optPertenceCliente = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.grpIdentificação.SuspendLayout();
            this.grpRecepção.SuspendLayout();
            this.grpEntrega.SuspendLayout();
            this.grpObservações.SuspendLayout();
            this.quadroManutenção.SuspendLayout();
            this.quadroPrivilégio.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPrivilégio);
            this.esquerda.Controls.Add(this.quadroManutenção);
            this.esquerda.Size = new System.Drawing.Size(187, 542);
            this.esquerda.TabIndex = 3;
            this.esquerda.Controls.SetChildIndex(this.quadroManutenção, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPrivilégio, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Pedido tal";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Atendimento.Properties.Resources.Pedido;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(527, 70);
            this.títuloBaseInferior1.TabIndex = 4;
            this.títuloBaseInferior1.Título = "Nome do cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // radioEncomenda
            // 
            this.radioEncomenda.AutoSize = true;
            this.radioEncomenda.Location = new System.Drawing.Point(100, 15);
            this.radioEncomenda.Name = "radioEncomenda";
            this.radioEncomenda.Size = new System.Drawing.Size(58, 17);
            this.radioEncomenda.TabIndex = 1;
            this.radioEncomenda.TabStop = true;
            this.radioEncomenda.Text = "Pedido";
            this.radioEncomenda.UseVisualStyleBackColor = true;
            this.radioEncomenda.CheckedChanged += new System.EventHandler(this.radioEncomenda_CheckedChanged);
            // 
            // radioConserto
            // 
            this.radioConserto.AutoSize = true;
            this.radioConserto.Location = new System.Drawing.Point(188, 15);
            this.radioConserto.Name = "radioConserto";
            this.radioConserto.Size = new System.Drawing.Size(67, 17);
            this.radioConserto.TabIndex = 2;
            this.radioConserto.TabStop = true;
            this.radioConserto.Text = "Conserto";
            this.radioConserto.UseVisualStyleBackColor = true;
            this.radioConserto.CheckedChanged += new System.EventHandler(this.radioConserto_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.AlturaProposta = 60;
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(100, 64);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Pessoa = null;
            this.txtCliente.Size = new System.Drawing.Size(384, 20);
            this.txtCliente.SomenteCadastrado = true;
            this.txtCliente.TabIndex = 6;
            this.txtCliente.Selecionado += new System.EventHandler(this.txtCliente_Selecionado);
            this.txtCliente.Deselecionado += new System.EventHandler(this.txtCliente_Deselecionado);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Região:";
            // 
            // txtFuncionário
            // 
            this.txtFuncionário.AlturaProposta = 60;
            this.txtFuncionário.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuncionário.Funcionários = true;
            this.txtFuncionário.Location = new System.Drawing.Point(100, 16);
            this.txtFuncionário.Name = "txtFuncionário";
            this.txtFuncionário.Pessoa = null;
            this.txtFuncionário.ReadOnly = true;
            this.txtFuncionário.Size = new System.Drawing.Size(384, 20);
            this.txtFuncionário.SomenteCadastrado = true;
            this.txtFuncionário.TabIndex = 1;
            this.txtFuncionário.Validated += new System.EventHandler(this.txtFuncionário_Validated);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Funcionário que recebeu:";
            // 
            // grpIdentificação
            // 
            this.grpIdentificação.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIdentificação.Controls.Add(this.txtRegião);
            this.grpIdentificação.Controls.Add(this.txtControle);
            this.grpIdentificação.Controls.Add(this.label8);
            this.grpIdentificação.Controls.Add(this.label3);
            this.grpIdentificação.Controls.Add(this.label1);
            this.grpIdentificação.Controls.Add(this.radioEncomenda);
            this.grpIdentificação.Controls.Add(this.radioConserto);
            this.grpIdentificação.Controls.Add(this.label2);
            this.grpIdentificação.Controls.Add(this.txtCliente);
            this.grpIdentificação.Location = new System.Drawing.Point(205, 79);
            this.grpIdentificação.Name = "grpIdentificação";
            this.grpIdentificação.Size = new System.Drawing.Size(490, 120);
            this.grpIdentificação.TabIndex = 0;
            this.grpIdentificação.TabStop = false;
            this.grpIdentificação.Text = "Identificação";
            // 
            // txtRegião
            // 
            this.txtRegião.Location = new System.Drawing.Point(100, 90);
            this.txtRegião.Name = "txtRegião";
            this.txtRegião.ReadOnly = true;
            this.txtRegião.Size = new System.Drawing.Size(173, 20);
            this.txtRegião.TabIndex = 8;
            this.txtRegião.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtControle
            // 
            this.txtControle.AllowNegative = true;
            this.txtControle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControle.DigitsInGroup = 0;
            this.txtControle.Flags = 0;
            this.txtControle.Location = new System.Drawing.Point(100, 38);
            this.txtControle.MaxDecimalPlaces = 0;
            this.txtControle.MaxWholeDigits = 9;
            this.txtControle.Name = "txtControle";
            this.txtControle.Prefix = "";
            this.txtControle.RangeMax = 1.7976931348623157E+308;
            this.txtControle.RangeMin = -1.7976931348623157E+308;
            this.txtControle.Size = new System.Drawing.Size(384, 20);
            this.txtControle.TabIndex = 4;
            this.txtControle.Validated += new System.EventHandler(this.txtControle_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Controle:";
            // 
            // grpRecepção
            // 
            this.grpRecepção.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRecepção.Controls.Add(this.optPertenceEmpresa);
            this.grpRecepção.Controls.Add(this.optPertenceCliente);
            this.grpRecepção.Controls.Add(this.label11);
            this.grpRecepção.Controls.Add(this.dtRecepção);
            this.grpRecepção.Controls.Add(this.label5);
            this.grpRecepção.Controls.Add(this.label4);
            this.grpRecepção.Controls.Add(this.txtFuncionário);
            this.grpRecepção.Location = new System.Drawing.Point(205, 205);
            this.grpRecepção.Name = "grpRecepção";
            this.grpRecepção.Size = new System.Drawing.Size(490, 97);
            this.grpRecepção.TabIndex = 1;
            this.grpRecepção.TabStop = false;
            this.grpRecepção.Text = "Recepção";
            this.grpRecepção.Visible = false;
            // 
            // dtRecepção
            // 
            this.dtRecepção.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRecepção.Enabled = false;
            this.dtRecepção.Location = new System.Drawing.Point(100, 46);
            this.dtRecepção.Name = "dtRecepção";
            this.dtRecepção.Size = new System.Drawing.Size(384, 20);
            this.dtRecepção.TabIndex = 3;
            this.dtRecepção.Validated += new System.EventHandler(this.dtRecepção_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data de recepção:";
            // 
            // grpEntrega
            // 
            this.grpEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEntrega.Controls.Add(this.lblInfoOficina);
            this.grpEntrega.Controls.Add(this.chkLevar);
            this.grpEntrega.Controls.Add(this.chkDespachar);
            this.grpEntrega.Controls.Add(this.btnEntregar);
            this.grpEntrega.Controls.Add(this.dtEntrega);
            this.grpEntrega.Controls.Add(this.label9);
            this.grpEntrega.Controls.Add(this.btnConclusao);
            this.grpEntrega.Controls.Add(this.dtConclusão);
            this.grpEntrega.Controls.Add(this.label7);
            this.grpEntrega.Controls.Add(this.dtPrevisão);
            this.grpEntrega.Controls.Add(this.label6);
            this.grpEntrega.Location = new System.Drawing.Point(205, 308);
            this.grpEntrega.Name = "grpEntrega";
            this.grpEntrega.Size = new System.Drawing.Size(490, 135);
            this.grpEntrega.TabIndex = 2;
            this.grpEntrega.TabStop = false;
            this.grpEntrega.Text = "Entrega";
            this.grpEntrega.Visible = false;
            // 
            // lblInfoOficina
            // 
            this.lblInfoOficina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoOficina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInfoOficina.Location = new System.Drawing.Point(6, 61);
            this.lblInfoOficina.Name = "lblInfoOficina";
            this.lblInfoOficina.Size = new System.Drawing.Size(478, 13);
            this.lblInfoOficina.TabIndex = 11;
            this.lblInfoOficina.Text = "A data de previsão está marcada para <>. No entanto, a oficina não trabalha neste" +
                " dia.";
            this.lblInfoOficina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfoOficina.Visible = false;
            // 
            // chkLevar
            // 
            this.chkLevar.AutoSize = true;
            this.chkLevar.Location = new System.Drawing.Point(226, 15);
            this.chkLevar.Name = "chkLevar";
            this.chkLevar.Size = new System.Drawing.Size(103, 17);
            this.chkLevar.TabIndex = 9;
            this.chkLevar.TabStop = true;
            this.chkLevar.Text = "Levar (em mãos)";
            this.chkLevar.UseVisualStyleBackColor = true;
            this.chkLevar.CheckedChanged += new System.EventHandler(this.chkLevar_CheckedChanged);
            // 
            // chkDespachar
            // 
            this.chkDespachar.AutoSize = true;
            this.chkDespachar.Location = new System.Drawing.Point(100, 16);
            this.chkDespachar.Name = "chkDespachar";
            this.chkDespachar.Size = new System.Drawing.Size(112, 17);
            this.chkDespachar.TabIndex = 8;
            this.chkDespachar.TabStop = true;
            this.chkDespachar.Text = "Despachar pedido";
            this.chkDespachar.UseVisualStyleBackColor = true;
            this.chkDespachar.CheckedChanged += new System.EventHandler(this.chkDespachar_CheckedChanged);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntregar.Location = new System.Drawing.Point(100, 104);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(384, 23);
            this.btnEntregar.TabIndex = 6;
            this.btnEntregar.Text = "Registrar entrega";
            this.btnEntregar.UseVisualStyleBackColor = true;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // dtEntrega
            // 
            this.dtEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEntrega.Location = new System.Drawing.Point(100, 107);
            this.dtEntrega.Name = "dtEntrega";
            this.dtEntrega.Size = new System.Drawing.Size(384, 20);
            this.dtEntrega.TabIndex = 7;
            this.dtEntrega.Visible = false;
            this.dtEntrega.Validated += new System.EventHandler(this.dtEntrega_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Data de entrega:";
            // 
            // btnConclusao
            // 
            this.btnConclusao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConclusao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConclusao.Location = new System.Drawing.Point(100, 77);
            this.btnConclusao.Name = "btnConclusao";
            this.btnConclusao.Size = new System.Drawing.Size(384, 23);
            this.btnConclusao.TabIndex = 3;
            this.btnConclusao.Text = "Registrar conclusão (Pronto da oficina)";
            this.btnConclusao.UseVisualStyleBackColor = true;
            this.btnConclusao.Click += new System.EventHandler(this.btnConclusao_Click);
            // 
            // dtConclusão
            // 
            this.dtConclusão.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtConclusão.Location = new System.Drawing.Point(100, 80);
            this.dtConclusão.Name = "dtConclusão";
            this.dtConclusão.Size = new System.Drawing.Size(384, 20);
            this.dtConclusão.TabIndex = 4;
            this.dtConclusão.Visible = false;
            this.dtConclusão.Validated += new System.EventHandler(this.dtConclusão_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Data de conclusão:";
            // 
            // dtPrevisão
            // 
            this.dtPrevisão.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPrevisão.Location = new System.Drawing.Point(100, 38);
            this.dtPrevisão.Name = "dtPrevisão";
            this.dtPrevisão.Size = new System.Drawing.Size(384, 20);
            this.dtPrevisão.TabIndex = 1;
            this.dtPrevisão.ValueChanged += new System.EventHandler(this.dtPrevisão_ValueChanged);
            this.dtPrevisão.Validated += new System.EventHandler(this.dtPrevisão_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Previsão:";
            // 
            // grpObservações
            // 
            this.grpObservações.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpObservações.Controls.Add(this.txtDescrição);
            this.grpObservações.Location = new System.Drawing.Point(205, 449);
            this.grpObservações.Name = "grpObservações";
            this.grpObservações.Size = new System.Drawing.Size(490, 146);
            this.grpObservações.TabIndex = 5;
            this.grpObservações.TabStop = false;
            this.grpObservações.Text = "Descrição";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescrição.Location = new System.Drawing.Point(6, 19);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrição.Size = new System.Drawing.Size(478, 121);
            this.txtDescrição.TabIndex = 0;
            this.txtDescrição.Validated += new System.EventHandler(this.txtDescrição_Validated);
            // 
            // quadroManutenção
            // 
            this.quadroManutenção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroManutenção.bInfDirArredondada = true;
            this.quadroManutenção.bInfEsqArredondada = true;
            this.quadroManutenção.bSupDirArredondada = true;
            this.quadroManutenção.bSupEsqArredondada = true;
            this.quadroManutenção.Controls.Add(this.opçãoRemoverConclusão);
            this.quadroManutenção.Controls.Add(this.opçãoRemoverEntrega);
            this.quadroManutenção.Controls.Add(this.opçãoExcluir);
            this.quadroManutenção.Cor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quadroManutenção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quadroManutenção.LetraTítulo = System.Drawing.Color.White;
            this.quadroManutenção.Location = new System.Drawing.Point(7, 13);
            this.quadroManutenção.MostrarBotãoMinMax = false;
            this.quadroManutenção.Name = "quadroManutenção";
            this.quadroManutenção.Size = new System.Drawing.Size(160, 114);
            this.quadroManutenção.TabIndex = 1;
            this.quadroManutenção.Tamanho = 30;
            this.quadroManutenção.Título = "Manutenção";
            // 
            // opçãoRemoverConclusão
            // 
            this.opçãoRemoverConclusão.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRemoverConclusão.Descrição = "Remover registro de conclusão";
            this.opçãoRemoverConclusão.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRemoverConclusão.Imagem")));
            this.opçãoRemoverConclusão.Location = new System.Drawing.Point(5, 28);
            this.opçãoRemoverConclusão.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRemoverConclusão.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRemoverConclusão.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRemoverConclusão.Name = "opçãoRemoverConclusão";
            this.opçãoRemoverConclusão.Size = new System.Drawing.Size(150, 33);
            this.opçãoRemoverConclusão.TabIndex = 2;
            this.opçãoRemoverConclusão.Click += new System.EventHandler(this.opçãoRemoverConclusão_Click);
            // 
            // opçãoRemoverEntrega
            // 
            this.opçãoRemoverEntrega.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRemoverEntrega.Descrição = "Remover registro de entrega";
            this.opçãoRemoverEntrega.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRemoverEntrega.Imagem")));
            this.opçãoRemoverEntrega.Location = new System.Drawing.Point(5, 60);
            this.opçãoRemoverEntrega.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRemoverEntrega.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRemoverEntrega.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRemoverEntrega.Name = "opçãoRemoverEntrega";
            this.opçãoRemoverEntrega.PermitirLiberaçãoRecurso = true;
            this.opçãoRemoverEntrega.Privilégio = Entidades.Privilégio.Permissão.CadastroEditar;
            this.opçãoRemoverEntrega.Size = new System.Drawing.Size(150, 30);
            this.opçãoRemoverEntrega.TabIndex = 3;
            this.opçãoRemoverEntrega.Click += new System.EventHandler(this.opçãoRemoverEntrega_Click);
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir pedido";
            this.opçãoExcluir.Imagem = global::Apresentação.Atendimento.Properties.Resources.delete_16x;
            this.opçãoExcluir.Location = new System.Drawing.Point(5, 90);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.PermitirLiberaçãoRecurso = true;
            this.opçãoExcluir.Privilégio = Entidades.Privilégio.Permissão.CadastroRemover;
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluir.TabIndex = 4;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // quadroPrivilégio
            // 
            this.quadroPrivilégio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPrivilégio.bInfDirArredondada = true;
            this.quadroPrivilégio.bInfEsqArredondada = true;
            this.quadroPrivilégio.bSupDirArredondada = true;
            this.quadroPrivilégio.bSupEsqArredondada = true;
            this.quadroPrivilégio.Controls.Add(this.opçãoImprimir);
            this.quadroPrivilégio.Controls.Add(this.label10);
            this.quadroPrivilégio.Cor = System.Drawing.Color.Black;
            this.quadroPrivilégio.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPrivilégio.LetraTítulo = System.Drawing.Color.White;
            this.quadroPrivilégio.Location = new System.Drawing.Point(7, 139);
            this.quadroPrivilégio.MostrarBotãoMinMax = false;
            this.quadroPrivilégio.Name = "quadroPrivilégio";
            this.quadroPrivilégio.Size = new System.Drawing.Size(160, 97);
            this.quadroPrivilégio.TabIndex = 3;
            this.quadroPrivilégio.Tamanho = 30;
            this.quadroPrivilégio.Título = "Geral";
            this.quadroPrivilégio.Visible = false;
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir recibo";
            this.opçãoImprimir.Imagem = global::Apresentação.Atendimento.Properties.Resources.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 72);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.PermitirLiberaçãoRecurso = true;
            this.opçãoImprimir.Privilégio = Entidades.Privilégio.Permissão.CadastroRemover;
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 5;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(5, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 41);
            this.label10.TabIndex = 2;
            this.label10.Text = "Solicite a um gerente para alteração dos dados.";
            // 
            // optPertenceEmpresa
            // 
            this.optPertenceEmpresa.AutoSize = true;
            this.optPertenceEmpresa.Checked = true;
            this.optPertenceEmpresa.Location = new System.Drawing.Point(188, 70);
            this.optPertenceEmpresa.Name = "optPertenceEmpresa";
            this.optPertenceEmpresa.Size = new System.Drawing.Size(75, 17);
            this.optPertenceEmpresa.TabIndex = 14;
            this.optPertenceEmpresa.TabStop = true;
            this.optPertenceEmpresa.Text = "À empresa";
            this.optPertenceEmpresa.UseVisualStyleBackColor = true;
            this.optPertenceEmpresa.CheckedChanged += new System.EventHandler(this.optPertenceEmpresa_CheckedChanged);
            // 
            // optPertenceCliente
            // 
            this.optPertenceCliente.AutoSize = true;
            this.optPertenceCliente.Location = new System.Drawing.Point(100, 70);
            this.optPertenceCliente.Name = "optPertenceCliente";
            this.optPertenceCliente.Size = new System.Drawing.Size(72, 17);
            this.optPertenceCliente.TabIndex = 13;
            this.optPertenceCliente.TabStop = true;
            this.optPertenceCliente.Text = "Ao cliente";
            this.optPertenceCliente.UseVisualStyleBackColor = true;
            this.optPertenceCliente.CheckedChanged += new System.EventHandler(this.optPertenceCliente_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Pertence:";
            // 
            // BaseEditarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpObservações);
            this.Controls.Add(this.grpEntrega);
            this.Controls.Add(this.grpRecepção);
            this.Controls.Add(this.grpIdentificação);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseEditarPedido";
            this.Size = new System.Drawing.Size(723, 542);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.grpIdentificação, 0);
            this.Controls.SetChildIndex(this.grpRecepção, 0);
            this.Controls.SetChildIndex(this.grpEntrega, 0);
            this.Controls.SetChildIndex(this.grpObservações, 0);
            this.esquerda.ResumeLayout(false);
            this.grpIdentificação.ResumeLayout(false);
            this.grpIdentificação.PerformLayout();
            this.grpRecepção.ResumeLayout(false);
            this.grpRecepção.PerformLayout();
            this.grpEntrega.ResumeLayout(false);
            this.grpEntrega.PerformLayout();
            this.grpObservações.ResumeLayout(false);
            this.grpObservações.PerformLayout();
            this.quadroManutenção.ResumeLayout(false);
            this.quadroPrivilégio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioEncomenda;
        private System.Windows.Forms.RadioButton radioConserto;
        private System.Windows.Forms.Label label2;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtCliente;
        private System.Windows.Forms.Label label3;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtFuncionário;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpIdentificação;
        private System.Windows.Forms.GroupBox grpRecepção;
        private System.Windows.Forms.DateTimePicker dtRecepção;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpEntrega;
        private System.Windows.Forms.DateTimePicker dtConclusão;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtPrevisão;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConclusao;
        private AMS.TextBox.IntegerTextBox txtControle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.DateTimePicker dtEntrega;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpObservações;
        private System.Windows.Forms.TextBox txtDescrição;
        private Apresentação.Formulários.Quadro quadroManutenção;
        private Apresentação.Formulários.Opção opçãoRemoverConclusão;
        private Apresentação.Formulários.Opção opçãoRemoverEntrega;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private System.Windows.Forms.TextBox txtRegião;
        private Apresentação.Formulários.Quadro quadroPrivilégio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton chkLevar;
        private System.Windows.Forms.RadioButton chkDespachar;
        private System.Windows.Forms.Label lblInfoOficina;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private System.Windows.Forms.RadioButton optPertenceEmpresa;
        private System.Windows.Forms.RadioButton optPertenceCliente;
        private System.Windows.Forms.Label label11;
    }
}
