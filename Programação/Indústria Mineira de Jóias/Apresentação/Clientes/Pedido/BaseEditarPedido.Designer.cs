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
            this.components = new System.ComponentModel.Container();
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
            this.txtValor = new AMS.TextBox.CurrencyTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRegião = new System.Windows.Forms.TextBox();
            this.grpRecepção = new System.Windows.Forms.GroupBox();
            this.btnRemoverEnvioParaOficina = new System.Windows.Forms.Button();
            this.btnOficina = new System.Windows.Forms.Button();
            this.dtOficina = new System.Windows.Forms.DateTimePicker();
            this.lblOficina = new System.Windows.Forms.Label();
            this.optPertenceEmpresa = new System.Windows.Forms.RadioButton();
            this.optPertenceCliente = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.dtRecepção = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.grpEntrega = new System.Windows.Forms.GroupBox();
            this.btnRemoverDataEntrega = new System.Windows.Forms.Button();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.btnRemoverDataConclusão = new System.Windows.Forms.Button();
            this.lblInfoOficina = new System.Windows.Forms.Label();
            this.chkLevar = new System.Windows.Forms.RadioButton();
            this.chkDespachar = new System.Windows.Forms.RadioButton();
            this.lblEntrega = new System.Windows.Forms.Label();
            this.btnConclusao = new System.Windows.Forms.Button();
            this.dtConclusão = new System.Windows.Forms.DateTimePicker();
            this.lblDataConclusão = new System.Windows.Forms.Label();
            this.dtPrevisão = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtEntrega = new System.Windows.Forms.TextBox();
            this.grpObservações = new System.Windows.Forms.GroupBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.quadroManutenção = new Apresentação.Formulários.Quadro();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.grpItens = new System.Windows.Forms.GroupBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.esquerda.SuspendLayout();
            this.grpIdentificação.SuspendLayout();
            this.grpRecepção.SuspendLayout();
            this.grpEntrega.SuspendLayout();
            this.grpObservações.SuspendLayout();
            this.quadroManutenção.SuspendLayout();
            this.grpItens.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroManutenção);
            this.esquerda.Size = new System.Drawing.Size(187, 670);
            this.esquerda.TabIndex = 3;
            this.esquerda.Controls.SetChildIndex(this.quadroManutenção, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Pedido tal";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.Pedido1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(753, 70);
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
            this.label2.Location = new System.Drawing.Point(6, 41);
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
            this.txtCliente.Location = new System.Drawing.Point(100, 37);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Pessoa = null;
            this.txtCliente.Size = new System.Drawing.Size(632, 20);
            this.txtCliente.TabIndex = 6;
            this.txtCliente.Selecionado += new System.EventHandler(this.txtCliente_Selecionado);
            this.txtCliente.Deselecionado += new System.EventHandler(this.txtCliente_Deselecionado);
            this.txtCliente.TxtChanged += new System.EventHandler(this.txtCliente_TxtChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 16);
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
            this.txtFuncionário.Size = new System.Drawing.Size(206, 20);
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
            this.grpIdentificação.Controls.Add(this.txtValor);
            this.grpIdentificação.Controls.Add(this.label12);
            this.grpIdentificação.Controls.Add(this.txtRegião);
            this.grpIdentificação.Controls.Add(this.label3);
            this.grpIdentificação.Controls.Add(this.label1);
            this.grpIdentificação.Controls.Add(this.radioEncomenda);
            this.grpIdentificação.Controls.Add(this.radioConserto);
            this.grpIdentificação.Controls.Add(this.label2);
            this.grpIdentificação.Controls.Add(this.txtCliente);
            this.grpIdentificação.Location = new System.Drawing.Point(193, 79);
            this.grpIdentificação.Name = "grpIdentificação";
            this.grpIdentificação.Size = new System.Drawing.Size(739, 65);
            this.grpIdentificação.TabIndex = 0;
            this.grpIdentificação.TabStop = false;
            this.grpIdentificação.Text = "Identificação";
            // 
            // txtValor
            // 
            this.txtValor.AllowNegative = true;
            this.txtValor.Flags = 7680;
            this.txtValor.Location = new System.Drawing.Point(560, 12);
            this.txtValor.MaxWholeDigits = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.RangeMax = 1.7976931348623157E+308D;
            this.txtValor.RangeMin = -1.7976931348623157E+308D;
            this.txtValor.Size = new System.Drawing.Size(131, 20);
            this.txtValor.TabIndex = 10;
            this.txtValor.Text = "R$ ,00";
            this.txtValor.Validated += new System.EventHandler(this.txtValor_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Valor:";
            // 
            // txtRegião
            // 
            this.txtRegião.Location = new System.Drawing.Point(319, 14);
            this.txtRegião.Name = "txtRegião";
            this.txtRegião.ReadOnly = true;
            this.txtRegião.Size = new System.Drawing.Size(182, 20);
            this.txtRegião.TabIndex = 8;
            this.txtRegião.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpRecepção
            // 
            this.grpRecepção.Controls.Add(this.btnRemoverEnvioParaOficina);
            this.grpRecepção.Controls.Add(this.btnOficina);
            this.grpRecepção.Controls.Add(this.dtOficina);
            this.grpRecepção.Controls.Add(this.lblOficina);
            this.grpRecepção.Controls.Add(this.optPertenceEmpresa);
            this.grpRecepção.Controls.Add(this.optPertenceCliente);
            this.grpRecepção.Controls.Add(this.label11);
            this.grpRecepção.Controls.Add(this.dtRecepção);
            this.grpRecepção.Controls.Add(this.label5);
            this.grpRecepção.Controls.Add(this.label4);
            this.grpRecepção.Controls.Add(this.txtFuncionário);
            this.grpRecepção.Location = new System.Drawing.Point(193, 150);
            this.grpRecepção.Name = "grpRecepção";
            this.grpRecepção.Size = new System.Drawing.Size(313, 128);
            this.grpRecepção.TabIndex = 1;
            this.grpRecepção.TabStop = false;
            this.grpRecepção.Text = "Recepção";
            // 
            // btnRemoverEnvioParaOficina
            // 
            this.btnRemoverEnvioParaOficina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverEnvioParaOficina.Image = global::Apresentação.Resource.Edit_UndoHS;
            this.btnRemoverEnvioParaOficina.Location = new System.Drawing.Point(280, 75);
            this.btnRemoverEnvioParaOficina.Name = "btnRemoverEnvioParaOficina";
            this.btnRemoverEnvioParaOficina.Size = new System.Drawing.Size(26, 22);
            this.btnRemoverEnvioParaOficina.TabIndex = 18;
            this.btnRemoverEnvioParaOficina.UseVisualStyleBackColor = true;
            this.btnRemoverEnvioParaOficina.Visible = false;
            this.btnRemoverEnvioParaOficina.Click += new System.EventHandler(this.btnRemoverEnvioParaOficina_Click);
            // 
            // btnOficina
            // 
            this.btnOficina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOficina.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOficina.Location = new System.Drawing.Point(100, 74);
            this.btnOficina.Name = "btnOficina";
            this.btnOficina.Size = new System.Drawing.Size(174, 23);
            this.btnOficina.TabIndex = 17;
            this.btnOficina.Text = "Registrar envio para oficina";
            this.btnOficina.UseVisualStyleBackColor = true;
            this.btnOficina.Click += new System.EventHandler(this.btnOficina_Click);
            // 
            // dtOficina
            // 
            this.dtOficina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtOficina.Location = new System.Drawing.Point(100, 74);
            this.dtOficina.Name = "dtOficina";
            this.dtOficina.Size = new System.Drawing.Size(174, 20);
            this.dtOficina.TabIndex = 16;
            this.dtOficina.Validated += new System.EventHandler(this.dtOficina_Validated);
            // 
            // lblOficina
            // 
            this.lblOficina.Location = new System.Drawing.Point(6, 72);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(80, 28);
            this.lblOficina.TabIndex = 15;
            this.lblOficina.Text = "Enviado para oficina:";
            // 
            // optPertenceEmpresa
            // 
            this.optPertenceEmpresa.AutoSize = true;
            this.optPertenceEmpresa.Checked = true;
            this.optPertenceEmpresa.Location = new System.Drawing.Point(188, 101);
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
            this.optPertenceCliente.Location = new System.Drawing.Point(100, 101);
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
            this.label11.Location = new System.Drawing.Point(6, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Pertence:";
            // 
            // dtRecepção
            // 
            this.dtRecepção.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRecepção.Enabled = false;
            this.dtRecepção.Location = new System.Drawing.Point(100, 46);
            this.dtRecepção.Name = "dtRecepção";
            this.dtRecepção.Size = new System.Drawing.Size(206, 20);
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
            this.grpEntrega.Controls.Add(this.btnRemoverDataEntrega);
            this.grpEntrega.Controls.Add(this.btnEntregar);
            this.grpEntrega.Controls.Add(this.btnRemoverDataConclusão);
            this.grpEntrega.Controls.Add(this.lblInfoOficina);
            this.grpEntrega.Controls.Add(this.chkLevar);
            this.grpEntrega.Controls.Add(this.chkDespachar);
            this.grpEntrega.Controls.Add(this.lblEntrega);
            this.grpEntrega.Controls.Add(this.btnConclusao);
            this.grpEntrega.Controls.Add(this.dtConclusão);
            this.grpEntrega.Controls.Add(this.lblDataConclusão);
            this.grpEntrega.Controls.Add(this.dtPrevisão);
            this.grpEntrega.Controls.Add(this.label6);
            this.grpEntrega.Controls.Add(this.dtEntrega);
            this.grpEntrega.Location = new System.Drawing.Point(512, 150);
            this.grpEntrega.Name = "grpEntrega";
            this.grpEntrega.Size = new System.Drawing.Size(420, 128);
            this.grpEntrega.TabIndex = 2;
            this.grpEntrega.TabStop = false;
            this.grpEntrega.Text = "Entrega";
            // 
            // btnRemoverDataEntrega
            // 
            this.btnRemoverDataEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverDataEntrega.Image = global::Apresentação.Resource.Edit_UndoHS;
            this.btnRemoverDataEntrega.Location = new System.Drawing.Point(387, 102);
            this.btnRemoverDataEntrega.Name = "btnRemoverDataEntrega";
            this.btnRemoverDataEntrega.Size = new System.Drawing.Size(26, 26);
            this.btnRemoverDataEntrega.TabIndex = 20;
            this.btnRemoverDataEntrega.UseVisualStyleBackColor = true;
            this.btnRemoverDataEntrega.Visible = false;
            this.btnRemoverDataEntrega.Click += new System.EventHandler(this.btnRemoverDataEntrega_Click);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntregar.Location = new System.Drawing.Point(100, 105);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(281, 20);
            this.btnEntregar.TabIndex = 6;
            this.btnEntregar.Text = "Registrar entrega";
            this.btnEntregar.UseVisualStyleBackColor = true;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // btnRemoverDataConclusão
            // 
            this.btnRemoverDataConclusão.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverDataConclusão.Image = global::Apresentação.Resource.Edit_UndoHS;
            this.btnRemoverDataConclusão.Location = new System.Drawing.Point(387, 75);
            this.btnRemoverDataConclusão.Name = "btnRemoverDataConclusão";
            this.btnRemoverDataConclusão.Size = new System.Drawing.Size(26, 26);
            this.btnRemoverDataConclusão.TabIndex = 19;
            this.btnRemoverDataConclusão.UseVisualStyleBackColor = true;
            this.btnRemoverDataConclusão.Visible = false;
            this.btnRemoverDataConclusão.Click += new System.EventHandler(this.btnRemoverDataConclusão_Click);
            // 
            // lblInfoOficina
            // 
            this.lblInfoOficina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoOficina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInfoOficina.Location = new System.Drawing.Point(6, 61);
            this.lblInfoOficina.Name = "lblInfoOficina";
            this.lblInfoOficina.Size = new System.Drawing.Size(408, 13);
            this.lblInfoOficina.TabIndex = 11;
            this.lblInfoOficina.Text = "A oficina não trabalha neste dia.";
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
            // lblEntrega
            // 
            this.lblEntrega.AutoSize = true;
            this.lblEntrega.Location = new System.Drawing.Point(3, 109);
            this.lblEntrega.Name = "lblEntrega";
            this.lblEntrega.Size = new System.Drawing.Size(87, 13);
            this.lblEntrega.TabIndex = 5;
            this.lblEntrega.Text = "Data de entrega:";
            // 
            // btnConclusao
            // 
            this.btnConclusao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConclusao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConclusao.Location = new System.Drawing.Point(100, 77);
            this.btnConclusao.Name = "btnConclusao";
            this.btnConclusao.Size = new System.Drawing.Size(281, 23);
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
            this.dtConclusão.Size = new System.Drawing.Size(281, 20);
            this.dtConclusão.TabIndex = 4;
            this.dtConclusão.Visible = false;
            this.dtConclusão.Validated += new System.EventHandler(this.dtConclusão_Validated);
            // 
            // lblDataConclusão
            // 
            this.lblDataConclusão.AutoSize = true;
            this.lblDataConclusão.Location = new System.Drawing.Point(3, 82);
            this.lblDataConclusão.Name = "lblDataConclusão";
            this.lblDataConclusão.Size = new System.Drawing.Size(100, 13);
            this.lblDataConclusão.TabIndex = 2;
            this.lblDataConclusão.Text = "Data de conclusão:";
            // 
            // dtPrevisão
            // 
            this.dtPrevisão.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPrevisão.Location = new System.Drawing.Point(100, 38);
            this.dtPrevisão.Name = "dtPrevisão";
            this.dtPrevisão.Size = new System.Drawing.Size(313, 20);
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
            // dtEntrega
            // 
            this.dtEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEntrega.BackColor = System.Drawing.SystemColors.Control;
            this.dtEntrega.Location = new System.Drawing.Point(100, 107);
            this.dtEntrega.Name = "dtEntrega";
            this.dtEntrega.Size = new System.Drawing.Size(281, 20);
            this.dtEntrega.TabIndex = 21;
            // 
            // grpObservações
            // 
            this.grpObservações.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpObservações.Controls.Add(this.txtDescrição);
            this.grpObservações.Location = new System.Drawing.Point(193, 284);
            this.grpObservações.Name = "grpObservações";
            this.grpObservações.Size = new System.Drawing.Size(313, 368);
            this.grpObservações.TabIndex = 5;
            this.grpObservações.TabStop = false;
            this.grpObservações.Text = "Observações";
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
            this.txtDescrição.Size = new System.Drawing.Size(301, 343);
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
            this.quadroManutenção.Controls.Add(this.opçãoExcluir);
            this.quadroManutenção.Controls.Add(this.opçãoImprimir);
            this.quadroManutenção.Cor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quadroManutenção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quadroManutenção.LetraTítulo = System.Drawing.Color.White;
            this.quadroManutenção.Location = new System.Drawing.Point(7, 13);
            this.quadroManutenção.MostrarBotãoMinMax = false;
            this.quadroManutenção.Name = "quadroManutenção";
            this.quadroManutenção.Size = new System.Drawing.Size(160, 75);
            this.quadroManutenção.TabIndex = 1;
            this.quadroManutenção.Tamanho = 30;
            this.quadroManutenção.Título = "Manutenção";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.delete;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 30);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.PermitirLiberaçãoRecurso = true;
            this.opçãoExcluir.Privilégio = Entidades.Privilégio.Permissão.EditarPedidosConsertos;
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 17);
            this.opçãoExcluir.TabIndex = 4;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Gerar recibo";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 50);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Privilégio = Entidades.Privilégio.Permissão.EditarPedidosConsertos;
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 5;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // grpItens
            // 
            this.grpItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItens.Controls.Add(this.btnAdicionarItem);
            this.grpItens.Controls.Add(this.flow);
            this.grpItens.Location = new System.Drawing.Point(512, 284);
            this.grpItens.Name = "grpItens";
            this.grpItens.Size = new System.Drawing.Size(420, 368);
            this.grpItens.TabIndex = 6;
            this.grpItens.TabStop = false;
            this.grpItens.Text = "Itens de Referência";
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarItem.Image = global::Apresentação.Resource.AddTableHS;
            this.btnAdicionarItem.Location = new System.Drawing.Point(387, 19);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(26, 26);
            this.btnAdicionarItem.TabIndex = 21;
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // flow
            // 
            this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow.AutoScroll = true;
            this.flow.Location = new System.Drawing.Point(6, 19);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(375, 339);
            this.flow.TabIndex = 1;
            // 
            // BaseEditarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpItens);
            this.Controls.Add(this.grpObservações);
            this.Controls.Add(this.grpEntrega);
            this.Controls.Add(this.grpRecepção);
            this.Controls.Add(this.grpIdentificação);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseEditarPedido";
            this.Size = new System.Drawing.Size(949, 670);
            this.Resize += new System.EventHandler(this.BaseEditarPedido_Resize);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.grpIdentificação, 0);
            this.Controls.SetChildIndex(this.grpRecepção, 0);
            this.Controls.SetChildIndex(this.grpEntrega, 0);
            this.Controls.SetChildIndex(this.grpObservações, 0);
            this.Controls.SetChildIndex(this.grpItens, 0);
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
            this.grpItens.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblDataConclusão;
        private System.Windows.Forms.DateTimePicker dtPrevisão;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConclusao;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Label lblEntrega;
        private System.Windows.Forms.GroupBox grpObservações;
        private System.Windows.Forms.TextBox txtDescrição;
        private Apresentação.Formulários.Quadro quadroManutenção;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private System.Windows.Forms.TextBox txtRegião;
        private System.Windows.Forms.RadioButton chkLevar;
        private System.Windows.Forms.RadioButton chkDespachar;
        private System.Windows.Forms.Label lblInfoOficina;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private System.Windows.Forms.RadioButton optPertenceEmpresa;
        private System.Windows.Forms.RadioButton optPertenceCliente;
        private System.Windows.Forms.Label label11;
        private AMS.TextBox.CurrencyTextBox txtValor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOficina;
        private System.Windows.Forms.Button btnOficina;
        private System.Windows.Forms.DateTimePicker dtOficina;
        private System.Windows.Forms.Button btnRemoverEnvioParaOficina;
        private System.Windows.Forms.Button btnRemoverDataEntrega;
        private System.Windows.Forms.Button btnRemoverDataConclusão;
        private System.Windows.Forms.GroupBox grpItens;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.TextBox dtEntrega;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
