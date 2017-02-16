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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMínimoDemais = new AMS.TextBox.CurrencyTextBox();
            this.txtMínimoPEP = new AMS.TextBox.CurrencyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grupoPeríodo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.NumericUpDown();
            this.btnRestaurarPadrão = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grupoPeríodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.lblDescrição.Size = new System.Drawing.Size(154, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Logo_COAF;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtMínimoDemais);
            this.groupBox1.Controls.Add(this.txtMínimoPEP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limites mínimos";
            // 
            // txtMínimoDemais
            // 
            this.txtMínimoDemais.AllowNegative = true;
            this.txtMínimoDemais.Flags = 7680;
            this.txtMínimoDemais.Location = new System.Drawing.Point(56, 48);
            this.txtMínimoDemais.MaxWholeDigits = 9;
            this.txtMínimoDemais.Name = "txtMínimoDemais";
            this.txtMínimoDemais.RangeMax = 1.7976931348623157E+308D;
            this.txtMínimoDemais.RangeMin = -1.7976931348623157E+308D;
            this.txtMínimoDemais.Size = new System.Drawing.Size(143, 20);
            this.txtMínimoDemais.TabIndex = 8;
            this.txtMínimoDemais.Text = "R$ 30.000,00";
            // 
            // txtMínimoPEP
            // 
            this.txtMínimoPEP.AllowNegative = true;
            this.txtMínimoPEP.Flags = 7680;
            this.txtMínimoPEP.Location = new System.Drawing.Point(56, 25);
            this.txtMínimoPEP.MaxWholeDigits = 9;
            this.txtMínimoPEP.Name = "txtMínimoPEP";
            this.txtMínimoPEP.RangeMax = 1.7976931348623157E+308D;
            this.txtMínimoPEP.RangeMin = -1.7976931348623157E+308D;
            this.txtMínimoPEP.Size = new System.Drawing.Size(143, 20);
            this.txtMínimoPEP.TabIndex = 7;
            this.txtMínimoPEP.Text = "R$ 10.000,00";
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
            this.btnCancelar.Location = new System.Drawing.Point(153, 403);
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
            this.btnOk.Location = new System.Drawing.Point(72, 403);
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
            this.grupoPeríodo.Controls.Add(this.label3);
            this.grupoPeríodo.Controls.Add(this.txtMeses);
            this.grupoPeríodo.Location = new System.Drawing.Point(12, 184);
            this.grupoPeríodo.Name = "grupoPeríodo";
            this.grupoPeríodo.Size = new System.Drawing.Size(216, 71);
            this.grupoPeríodo.TabIndex = 9;
            this.grupoPeríodo.TabStop = false;
            this.grupoPeríodo.Text = "Período: Últimos 6 meses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Meses:";
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(56, 23);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(141, 20);
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
            this.btnRestaurarPadrão.Location = new System.Drawing.Point(72, 374);
            this.btnRestaurarPadrão.Name = "btnRestaurarPadrão";
            this.btnRestaurarPadrão.Size = new System.Drawing.Size(156, 23);
            this.btnRestaurarPadrão.TabIndex = 10;
            this.btnRestaurarPadrão.Text = "Restaurar Padrão";
            this.btnRestaurarPadrão.UseVisualStyleBackColor = true;
            this.btnRestaurarPadrão.Click += new System.EventHandler(this.btnRestaurarPadrão_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 19);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(197, 45);
            this.trackBar1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 78);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Limiar de conferência";
            // 
            // JanelaConfiguração
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 438);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AMS.TextBox.CurrencyTextBox txtMínimoDemais;
        private AMS.TextBox.CurrencyTextBox txtMínimoPEP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grupoPeríodo;
        private System.Windows.Forms.Button btnRestaurarPadrão;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMeses;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}