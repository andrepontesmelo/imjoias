namespace Apresentação.Importação.Intervenção
{
    partial class EditarNossoNúmero
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNossoNúmero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optAltoAtacado = new System.Windows.Forms.RadioButton();
            this.optAtacado = new System.Windows.Forms.RadioButton();
            this.optVarejo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCrédito = new AMS.TextBox.CurrencyTextBox();
            this.txtMaiorVenda = new AMS.TextBox.CurrencyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataRegistro = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.classificador = new Apresentação.Pessoa.Cadastro.Classificador();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.painel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Size = new System.Drawing.Size(477, 473);
            this.splitContainer.SplitterDistance = 177;
            // 
            // painel
            // 
            this.painel.Controls.Add(this.groupBox3);
            this.painel.Controls.Add(this.groupBox2);
            this.painel.Controls.Add(this.groupBox1);
            this.painel.Size = new System.Drawing.Size(296, 358);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNossoNúmero);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campo original";
            this.groupBox1.Controls.SetChildIndex(this.txtNossoNúmero, 0);
            // 
            // txtNossoNúmero
            // 
            this.txtNossoNúmero.Location = new System.Drawing.Point(94, 19);
            this.txtNossoNúmero.Name = "txtNossoNúmero";
            this.txtNossoNúmero.ReadOnly = true;
            this.txtNossoNúmero.Size = new System.Drawing.Size(180, 20);
            this.txtNossoNúmero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nosso número:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optAltoAtacado);
            this.groupBox2.Controls.Add(this.optAtacado);
            this.groupBox2.Controls.Add(this.optVarejo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCrédito);
            this.groupBox2.Controls.Add(this.txtMaiorVenda);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDataRegistro);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interpretação";
            // 
            // optAltoAtacado
            // 
            this.optAltoAtacado.AutoSize = true;
            this.optAltoAtacado.Location = new System.Drawing.Point(94, 146);
            this.optAltoAtacado.Name = "optAltoAtacado";
            this.optAltoAtacado.Size = new System.Drawing.Size(85, 17);
            this.optAltoAtacado.TabIndex = 10;
            this.optAltoAtacado.TabStop = true;
            this.optAltoAtacado.Text = "Alto-atacado";
            this.optAltoAtacado.UseVisualStyleBackColor = true;
            this.optAltoAtacado.Validated += new System.EventHandler(this.optSetor_Validated);
            // 
            // optAtacado
            // 
            this.optAtacado.AutoSize = true;
            this.optAtacado.Location = new System.Drawing.Point(94, 123);
            this.optAtacado.Name = "optAtacado";
            this.optAtacado.Size = new System.Drawing.Size(65, 17);
            this.optAtacado.TabIndex = 9;
            this.optAtacado.TabStop = true;
            this.optAtacado.Text = "Atacado";
            this.optAtacado.UseVisualStyleBackColor = true;
            this.optAtacado.Validated += new System.EventHandler(this.optSetor_Validated);
            // 
            // optVarejo
            // 
            this.optVarejo.AutoSize = true;
            this.optVarejo.Location = new System.Drawing.Point(94, 100);
            this.optVarejo.Name = "optVarejo";
            this.optVarejo.Size = new System.Drawing.Size(55, 17);
            this.optVarejo.TabIndex = 8;
            this.optVarejo.TabStop = true;
            this.optVarejo.Text = "Varejo";
            this.optVarejo.UseVisualStyleBackColor = true;
            this.optVarejo.Validated += new System.EventHandler(this.optSetor_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Setor:";
            // 
            // txtCrédito
            // 
            this.txtCrédito.AllowNegative = true;
            this.txtCrédito.Flags = 7680;
            this.txtCrédito.Location = new System.Drawing.Point(94, 71);
            this.txtCrédito.MaxWholeDigits = 9;
            this.txtCrédito.Name = "txtCrédito";
            this.txtCrédito.RangeMax = 1.7976931348623157E+308;
            this.txtCrédito.RangeMin = -1.7976931348623157E+308;
            this.txtCrédito.Size = new System.Drawing.Size(180, 20);
            this.txtCrédito.TabIndex = 6;
            this.txtCrédito.Validated += new System.EventHandler(this.txtCrédito_Validated);
            // 
            // txtMaiorVenda
            // 
            this.txtMaiorVenda.AllowNegative = true;
            this.txtMaiorVenda.Flags = 7680;
            this.txtMaiorVenda.Location = new System.Drawing.Point(94, 45);
            this.txtMaiorVenda.MaxWholeDigits = 9;
            this.txtMaiorVenda.Name = "txtMaiorVenda";
            this.txtMaiorVenda.RangeMax = 1.7976931348623157E+308;
            this.txtMaiorVenda.RangeMin = -1.7976931348623157E+308;
            this.txtMaiorVenda.Size = new System.Drawing.Size(180, 20);
            this.txtMaiorVenda.TabIndex = 5;
            this.txtMaiorVenda.Validated += new System.EventHandler(this.txtMaiorVenda_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Crédito:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Maior venda:";
            // 
            // txtDataRegistro
            // 
            this.txtDataRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataRegistro.Location = new System.Drawing.Point(94, 19);
            this.txtDataRegistro.Name = "txtDataRegistro";
            this.txtDataRegistro.Size = new System.Drawing.Size(180, 20);
            this.txtDataRegistro.TabIndex = 1;
            this.txtDataRegistro.Validated += new System.EventHandler(this.txtDataRegistro_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data de registro:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.classificador);
            this.groupBox3.Location = new System.Drawing.Point(3, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 99);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classificações";
            // 
            // classificador
            // 
            this.classificador.AutoAtualizarBD = true;
            this.classificador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classificador.Location = new System.Drawing.Point(3, 16);
            this.classificador.Name = "classificador";
            this.classificador.Pessoa = null;
            this.classificador.Size = new System.Drawing.Size(277, 80);
            this.classificador.TabIndex = 0;
            // 
            // EditarNossoNúmero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 473);
            this.Name = "EditarNossoNúmero";
            this.Text = "Importação de cadastro - Nosso número";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.painel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNossoNúmero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker txtDataRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private AMS.TextBox.CurrencyTextBox txtCrédito;
        private AMS.TextBox.CurrencyTextBox txtMaiorVenda;
        private System.Windows.Forms.RadioButton optAltoAtacado;
        private System.Windows.Forms.RadioButton optAtacado;
        private System.Windows.Forms.RadioButton optVarejo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private Apresentação.Pessoa.Cadastro.Classificador classificador;
    }
}