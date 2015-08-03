namespace Apresentação.Atendimento.Clientes.Impressão
{
    partial class JanelaOpçõesImpressão
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaOpçõesImpressão));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optOrdemCódigoCliente = new System.Windows.Forms.RadioButton();
            this.optOrdemEndereço = new System.Windows.Forms.RadioButton();
            this.optOrdemAlfabetica = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optRegiao = new System.Windows.Forms.RadioButton();
            this.optTodosClientes = new System.Windows.Forms.RadioButton();
            this.cmbRegião = new Apresentação.Pessoa.Endereço.ComboBoxRegião();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(189, 20);
            this.lblTítulo.Text = "Configure a impressão";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(190, 48);
            this.lblDescrição.Text = "Quais clientes deseja imprimir ? ";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(110, 333);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(191, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.optOrdemCódigoCliente);
            this.groupBox1.Controls.Add(this.optOrdemEndereço);
            this.groupBox1.Controls.Add(this.optOrdemAlfabetica);
            this.groupBox1.Location = new System.Drawing.Point(8, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 129);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Em qual ordem ? ";
            // 
            // optOrdemCódigoCliente
            // 
            this.optOrdemCódigoCliente.AutoSize = true;
            this.optOrdemCódigoCliente.Location = new System.Drawing.Point(9, 65);
            this.optOrdemCódigoCliente.Name = "optOrdemCódigoCliente";
            this.optOrdemCódigoCliente.Size = new System.Drawing.Size(107, 17);
            this.optOrdemCódigoCliente.TabIndex = 2;
            this.optOrdemCódigoCliente.Text = "Código do cliente";
            this.optOrdemCódigoCliente.UseVisualStyleBackColor = true;
            // 
            // optOrdemEndereço
            // 
            this.optOrdemEndereço.AutoSize = true;
            this.optOrdemEndereço.Location = new System.Drawing.Point(9, 42);
            this.optOrdemEndereço.Name = "optOrdemEndereço";
            this.optOrdemEndereço.Size = new System.Drawing.Size(193, 17);
            this.optOrdemEndereço.TabIndex = 1;
            this.optOrdemEndereço.Text = "Cidade, Endereço, Nome do cliente";
            this.optOrdemEndereço.UseVisualStyleBackColor = true;
            // 
            // optOrdemAlfabetica
            // 
            this.optOrdemAlfabetica.AutoSize = true;
            this.optOrdemAlfabetica.Checked = true;
            this.optOrdemAlfabetica.Location = new System.Drawing.Point(9, 19);
            this.optOrdemAlfabetica.Name = "optOrdemAlfabetica";
            this.optOrdemAlfabetica.Size = new System.Drawing.Size(236, 17);
            this.optOrdemAlfabetica.TabIndex = 0;
            this.optOrdemAlfabetica.TabStop = true;
            this.optOrdemAlfabetica.Text = "Alfabética (Estado, Cidade, Nome do cliente)";
            this.optOrdemAlfabetica.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.optRegiao);
            this.groupBox2.Controls.Add(this.optTodosClientes);
            this.groupBox2.Controls.Add(this.cmbRegião);
            this.groupBox2.Location = new System.Drawing.Point(8, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 99);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "O que imprimir?";
            // 
            // optRegiao
            // 
            this.optRegiao.AutoSize = true;
            this.optRegiao.Location = new System.Drawing.Point(13, 46);
            this.optRegiao.Name = "optRegiao";
            this.optRegiao.Size = new System.Drawing.Size(135, 17);
            this.optRegiao.TabIndex = 2;
            this.optRegiao.Text = "Clientes de uma região:";
            this.optRegiao.UseVisualStyleBackColor = true;
            this.optRegiao.CheckedChanged += new System.EventHandler(this.optRegiao_CheckedChanged);
            // 
            // optTodosClientes
            // 
            this.optTodosClientes.AutoSize = true;
            this.optTodosClientes.Checked = true;
            this.optTodosClientes.Location = new System.Drawing.Point(13, 23);
            this.optTodosClientes.Name = "optTodosClientes";
            this.optTodosClientes.Size = new System.Drawing.Size(108, 17);
            this.optTodosClientes.TabIndex = 1;
            this.optTodosClientes.TabStop = true;
            this.optTodosClientes.Text = "Todos os clientes";
            this.optTodosClientes.UseVisualStyleBackColor = true;
            // 
            // cmbRegião
            // 
            this.cmbRegião.Enabled = false;
            this.cmbRegião.Location = new System.Drawing.Point(9, 69);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Região = null;
            this.cmbRegião.Size = new System.Drawing.Size(209, 21);
            this.cmbRegião.TabIndex = 0;
            // 
            // JanelaOpçõesImpressão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 364);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.KeyPreview = true;
            this.Name = "JanelaOpçõesImpressão";
            this.Text = "Impressão";
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optOrdemAlfabetica;
        private System.Windows.Forms.RadioButton optOrdemEndereço;
        private System.Windows.Forms.RadioButton optOrdemCódigoCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optRegiao;
        private System.Windows.Forms.RadioButton optTodosClientes;
        private Pessoa.Endereço.ComboBoxRegião cmbRegião;
    }
}