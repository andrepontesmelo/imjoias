using Apresentação.Formulário.Componente;

namespace Apresentação.Financeiro.Coaf
{
    partial class JanelaConfiguração
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaConfiguração));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotificaçãoDemaisPessoas = new AMS.TextBox.CurrencyTextBox();
            this.txtNotificaçãoPEP = new AMS.TextBox.CurrencyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grupoPeríodo = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lnkAjustarDataÚltimosMeses = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.dataFim = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dataInício = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.NumericUpDown();
            this.btnRestaurarPadrão = new System.Windows.Forms.Button();
            this.trackBarVerificação = new Apresentação.Formulário.Componente.TrackBarProporcional();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVerificaçãoDemaisPessoas = new AMS.TextBox.CurrencyTextBox();
            this.txtVerificaçãoPEP = new AMS.TextBox.CurrencyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grupoPeríodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVerificação)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(116, 20);
            this.lblTítulo.Text = "Configuração";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(367, 48);
            this.lblDescrição.Text = resources.GetString("lblDescrição.Text");
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtNotificaçãoDemaisPessoas);
            this.groupBox1.Controls.Add(this.txtNotificaçãoPEP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limiar de notificação";
            // 
            // txtNotificaçãoDemaisPessoas
            // 
            this.txtNotificaçãoDemaisPessoas.AllowNegative = true;
            this.txtNotificaçãoDemaisPessoas.Flags = 7680;
            this.txtNotificaçãoDemaisPessoas.Location = new System.Drawing.Point(56, 48);
            this.txtNotificaçãoDemaisPessoas.MaxWholeDigits = 9;
            this.txtNotificaçãoDemaisPessoas.Name = "txtNotificaçãoDemaisPessoas";
            this.txtNotificaçãoDemaisPessoas.RangeMax = 1.7976931348623157E+308D;
            this.txtNotificaçãoDemaisPessoas.RangeMin = -1.7976931348623157E+308D;
            this.txtNotificaçãoDemaisPessoas.Size = new System.Drawing.Size(143, 20);
            this.txtNotificaçãoDemaisPessoas.TabIndex = 8;
            this.txtNotificaçãoDemaisPessoas.Text = "R$ 30.000,00";
            // 
            // txtNotificaçãoPEP
            // 
            this.txtNotificaçãoPEP.AllowNegative = true;
            this.txtNotificaçãoPEP.Flags = 7680;
            this.txtNotificaçãoPEP.Location = new System.Drawing.Point(56, 25);
            this.txtNotificaçãoPEP.MaxWholeDigits = 9;
            this.txtNotificaçãoPEP.Name = "txtNotificaçãoPEP";
            this.txtNotificaçãoPEP.RangeMax = 1.7976931348623157E+308D;
            this.txtNotificaçãoPEP.RangeMin = -1.7976931348623157E+308D;
            this.txtNotificaçãoPEP.Size = new System.Drawing.Size(143, 20);
            this.txtNotificaçãoPEP.TabIndex = 7;
            this.txtNotificaçãoPEP.Text = "R$ 10.000,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Demais:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PEP:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(366, 260);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(285, 260);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grupoPeríodo
            // 
            this.grupoPeríodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grupoPeríodo.Controls.Add(this.label8);
            this.grupoPeríodo.Controls.Add(this.lnkAjustarDataÚltimosMeses);
            this.grupoPeríodo.Controls.Add(this.label7);
            this.grupoPeríodo.Controls.Add(this.dataFim);
            this.grupoPeríodo.Controls.Add(this.label6);
            this.grupoPeríodo.Controls.Add(this.dataInício);
            this.grupoPeríodo.Controls.Add(this.label3);
            this.grupoPeríodo.Controls.Add(this.txtMeses);
            this.grupoPeríodo.Location = new System.Drawing.Point(232, 96);
            this.grupoPeríodo.Name = "grupoPeríodo";
            this.grupoPeríodo.Size = new System.Drawing.Size(214, 129);
            this.grupoPeríodo.TabIndex = 9;
            this.grupoPeríodo.TabStop = false;
            this.grupoPeríodo.Text = "Data de Apuração";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "datas p/ últimos ";
            // 
            // lnkAjustarDataÚltimosMeses
            // 
            this.lnkAjustarDataÚltimosMeses.AutoSize = true;
            this.lnkAjustarDataÚltimosMeses.Location = new System.Drawing.Point(10, 90);
            this.lnkAjustarDataÚltimosMeses.Name = "lnkAjustarDataÚltimosMeses";
            this.lnkAjustarDataÚltimosMeses.Size = new System.Drawing.Size(39, 13);
            this.lnkAjustarDataÚltimosMeses.TabIndex = 6;
            this.lnkAjustarDataÚltimosMeses.TabStop = true;
            this.lnkAjustarDataÚltimosMeses.Text = "Ajustar";
            this.lnkAjustarDataÚltimosMeses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAjustarDataÚltimosMeses_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fim:";
            // 
            // dataFim
            // 
            this.dataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFim.Location = new System.Drawing.Point(53, 49);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(141, 20);
            this.dataFim.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Início:";
            // 
            // dataInício
            // 
            this.dataInício.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInício.Location = new System.Drawing.Point(53, 26);
            this.dataInício.Name = "dataInício";
            this.dataInício.Size = new System.Drawing.Size(141, 20);
            this.dataInício.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "meses.";
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(131, 88);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(35, 20);
            this.txtMeses.TabIndex = 0;
            this.txtMeses.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.txtMeses.ValueChanged += new System.EventHandler(this.txtMeses_ValueChanged);
            // 
            // btnRestaurarPadrão
            // 
            this.btnRestaurarPadrão.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurarPadrão.Image = global::Apresentação.Resource.Edit_UndoHS;
            this.btnRestaurarPadrão.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRestaurarPadrão.Location = new System.Drawing.Point(285, 231);
            this.btnRestaurarPadrão.Name = "btnRestaurarPadrão";
            this.btnRestaurarPadrão.Size = new System.Drawing.Size(156, 23);
            this.btnRestaurarPadrão.TabIndex = 10;
            this.btnRestaurarPadrão.Text = "Restaurar Padrão";
            this.btnRestaurarPadrão.UseVisualStyleBackColor = true;
            this.btnRestaurarPadrão.Click += new System.EventHandler(this.btnRestaurarPadrão_Click);
            // 
            // trackBarVerificação
            // 
            this.trackBarVerificação.AutoSize = false;
            this.trackBarVerificação.Location = new System.Drawing.Point(6, 19);
            this.trackBarVerificação.Name = "trackBarVerificação";
            this.trackBarVerificação.Size = new System.Drawing.Size(197, 31);
            this.trackBarVerificação.TabIndex = 12;
            this.trackBarVerificação.Scroll += new System.EventHandler(this.trackBarVerificação_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtVerificaçãoDemaisPessoas);
            this.groupBox2.Controls.Add(this.txtVerificaçãoPEP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.trackBarVerificação);
            this.groupBox2.Location = new System.Drawing.Point(12, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 107);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Limiar de verificação";
            // 
            // txtVerificaçãoDemaisPessoas
            // 
            this.txtVerificaçãoDemaisPessoas.AllowNegative = true;
            this.txtVerificaçãoDemaisPessoas.Flags = 7680;
            this.txtVerificaçãoDemaisPessoas.Location = new System.Drawing.Point(56, 79);
            this.txtVerificaçãoDemaisPessoas.MaxWholeDigits = 9;
            this.txtVerificaçãoDemaisPessoas.Name = "txtVerificaçãoDemaisPessoas";
            this.txtVerificaçãoDemaisPessoas.RangeMax = 1.7976931348623157E+308D;
            this.txtVerificaçãoDemaisPessoas.RangeMin = -1.7976931348623157E+308D;
            this.txtVerificaçãoDemaisPessoas.Size = new System.Drawing.Size(143, 20);
            this.txtVerificaçãoDemaisPessoas.TabIndex = 16;
            this.txtVerificaçãoDemaisPessoas.Text = "R$ 30.000,00";
            this.txtVerificaçãoDemaisPessoas.Validated += new System.EventHandler(this.txtVerificaçãoDemaisPessoas_Validated);
            // 
            // txtVerificaçãoPEP
            // 
            this.txtVerificaçãoPEP.AllowNegative = true;
            this.txtVerificaçãoPEP.Flags = 7680;
            this.txtVerificaçãoPEP.Location = new System.Drawing.Point(56, 56);
            this.txtVerificaçãoPEP.MaxWholeDigits = 9;
            this.txtVerificaçãoPEP.Name = "txtVerificaçãoPEP";
            this.txtVerificaçãoPEP.RangeMax = 1.7976931348623157E+308D;
            this.txtVerificaçãoPEP.RangeMin = -1.7976931348623157E+308D;
            this.txtVerificaçãoPEP.Size = new System.Drawing.Size(143, 20);
            this.txtVerificaçãoPEP.TabIndex = 15;
            this.txtVerificaçãoPEP.Text = "R$ 10.000,00";
            this.txtVerificaçãoPEP.Validated += new System.EventHandler(this.txtVerificaçãoPEP_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Demais:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "PEP:";
            // 
            // JanelaConfiguração
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 292);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRestaurarPadrão);
            this.Controls.Add(this.grupoPeríodo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "JanelaConfiguração";
            this.Text = "Configuração";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.grupoPeríodo, 0);
            this.Controls.SetChildIndex(this.btnRestaurarPadrão, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grupoPeríodo.ResumeLayout(false);
            this.grupoPeríodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVerificação)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AMS.TextBox.CurrencyTextBox txtNotificaçãoDemaisPessoas;
        private AMS.TextBox.CurrencyTextBox txtNotificaçãoPEP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grupoPeríodo;
        private System.Windows.Forms.Button btnRestaurarPadrão;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMeses;
        private TrackBarProporcional trackBarVerificação;
        private System.Windows.Forms.GroupBox groupBox2;
        private AMS.TextBox.CurrencyTextBox txtVerificaçãoDemaisPessoas;
        private AMS.TextBox.CurrencyTextBox txtVerificaçãoPEP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkAjustarDataÚltimosMeses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dataFim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dataInício;
        private System.Windows.Forms.Label label8;
    }
}