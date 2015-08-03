namespace WindowsFormsApplication1
{
    partial class JanelaPromissória
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaPromissória));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.dataPriVencimento = new System.Windows.Forms.DateTimePicker();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtEmitente = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtCGC = new System.Windows.Forms.TextBox();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.txtAos = new System.Windows.Forms.Label();
            this.txtDiasDoMesDe = new System.Windows.Forms.Label();
            this.txtDoAnoDe = new System.Windows.Forms.Label();
            this.txtQuantia = new System.Windows.Forms.Label();
            this.txtQuantiaL2 = new System.Windows.Forms.Label();
            this.chkContraApresentacao = new System.Windows.Forms.CheckBox();
            this.panelEscondeVencimento = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(557, 377);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtQtd
            // 
            this.txtQtd.BackColor = System.Drawing.Color.White;
            this.txtQtd.Location = new System.Drawing.Point(154, 70);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(51, 20);
            this.txtQtd.TabIndex = 1;
            this.txtQtd.Validated += new System.EventHandler(this.txtQtd_Validated);
            this.txtQtd.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtd_Validating);
            // 
            // dataPriVencimento
            // 
            this.dataPriVencimento.CustomFormat = "dd/MM/YYYY";
            this.dataPriVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataPriVencimento.Location = new System.Drawing.Point(523, 30);
            this.dataPriVencimento.Name = "dataPriVencimento";
            this.dataPriVencimento.Size = new System.Drawing.Size(91, 20);
            this.dataPriVencimento.TabIndex = 0;
            this.dataPriVencimento.ValueChanged += new System.EventHandler(this.dataPriVencimento_ValueChanged);
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.White;
            this.txtValor.Location = new System.Drawing.Point(523, 72);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(91, 20);
            this.txtValor.TabIndex = 2;
            this.txtValor.Validated += new System.EventHandler(this.txtValor_Validated);
            this.txtValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtValor_Validating);
            // 
            // txtEmitente
            // 
            this.txtEmitente.BackColor = System.Drawing.Color.White;
            this.txtEmitente.Location = new System.Drawing.Point(197, 281);
            this.txtEmitente.Name = "txtEmitente";
            this.txtEmitente.Size = new System.Drawing.Size(409, 20);
            this.txtEmitente.TabIndex = 4;
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.White;
            this.txtEndereco.Location = new System.Drawing.Point(197, 307);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(409, 20);
            this.txtEndereco.TabIndex = 5;
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.Color.White;
            this.txtCPF.Location = new System.Drawing.Point(197, 333);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(155, 20);
            this.txtCPF.TabIndex = 6;
            // 
            // txtCGC
            // 
            this.txtCGC.BackColor = System.Drawing.Color.White;
            this.txtCGC.Location = new System.Drawing.Point(396, 333);
            this.txtCGC.Name = "txtCGC";
            this.txtCGC.Size = new System.Drawing.Size(210, 20);
            this.txtCGC.TabIndex = 7;
            // 
            // data
            // 
            this.data.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.data.Location = new System.Drawing.Point(279, 217);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(335, 20);
            this.data.TabIndex = 3;
            this.data.Validated += new System.EventHandler(this.data_Validated);
            // 
            // txtAos
            // 
            this.txtAos.BackColor = System.Drawing.Color.Transparent;
            this.txtAos.Location = new System.Drawing.Point(177, 109);
            this.txtAos.Name = "txtAos";
            this.txtAos.Size = new System.Drawing.Size(141, 21);
            this.txtAos.TabIndex = 9;
            this.txtAos.Text = "txtAos";
            this.txtAos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtAos.Validated += new System.EventHandler(this.txtAos_Validated);
            // 
            // txtDiasDoMesDe
            // 
            this.txtDiasDoMesDe.BackColor = System.Drawing.Color.Transparent;
            this.txtDiasDoMesDe.Location = new System.Drawing.Point(413, 109);
            this.txtDiasDoMesDe.Name = "txtDiasDoMesDe";
            this.txtDiasDoMesDe.Size = new System.Drawing.Size(89, 21);
            this.txtDiasDoMesDe.TabIndex = 10;
            this.txtDiasDoMesDe.Text = "label1";
            this.txtDiasDoMesDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtDiasDoMesDe.Validated += new System.EventHandler(this.txtDiasDoMesDe_Validated);
            // 
            // txtDoAnoDe
            // 
            this.txtDoAnoDe.BackColor = System.Drawing.Color.Transparent;
            this.txtDoAnoDe.Location = new System.Drawing.Point(567, 109);
            this.txtDoAnoDe.Name = "txtDoAnoDe";
            this.txtDoAnoDe.Size = new System.Drawing.Size(47, 21);
            this.txtDoAnoDe.TabIndex = 11;
            this.txtDoAnoDe.Text = "label1";
            this.txtDoAnoDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtDoAnoDe.Validated += new System.EventHandler(this.txtDoAnoDe_Validated);
            // 
            // txtQuantia
            // 
            this.txtQuantia.BackColor = System.Drawing.Color.Transparent;
            this.txtQuantia.Location = new System.Drawing.Point(210, 170);
            this.txtQuantia.Name = "txtQuantia";
            this.txtQuantia.Size = new System.Drawing.Size(404, 21);
            this.txtQuantia.TabIndex = 12;
            this.txtQuantia.Text = "label1";
            this.txtQuantia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantiaL2
            // 
            this.txtQuantiaL2.BackColor = System.Drawing.Color.Transparent;
            this.txtQuantiaL2.Location = new System.Drawing.Point(139, 193);
            this.txtQuantiaL2.Name = "txtQuantiaL2";
            this.txtQuantiaL2.Size = new System.Drawing.Size(467, 21);
            this.txtQuantiaL2.TabIndex = 13;
            this.txtQuantiaL2.Text = "label1";
            this.txtQuantiaL2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkContraApresentacao
            // 
            this.chkContraApresentacao.AutoSize = true;
            this.chkContraApresentacao.BackColor = System.Drawing.Color.Transparent;
            this.chkContraApresentacao.Location = new System.Drawing.Point(339, 30);
            this.chkContraApresentacao.Name = "chkContraApresentacao";
            this.chkContraApresentacao.Size = new System.Drawing.Size(126, 17);
            this.chkContraApresentacao.TabIndex = 14;
            this.chkContraApresentacao.Text = "Contra Apresentação";
            this.chkContraApresentacao.UseVisualStyleBackColor = false;
            this.chkContraApresentacao.CheckedChanged += new System.EventHandler(this.chkContraApresentacao_CheckedChanged);
            // 
            // panelEscondeVencimento
            // 
            this.panelEscondeVencimento.BackColor = System.Drawing.Color.White;
            this.panelEscondeVencimento.Location = new System.Drawing.Point(465, 23);
            this.panelEscondeVencimento.Name = "panelEscondeVencimento";
            this.panelEscondeVencimento.Size = new System.Drawing.Size(166, 43);
            this.panelEscondeVencimento.TabIndex = 15;
            this.panelEscondeVencimento.Visible = false;
            // 
            // JanelaPromissória
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.promissória_colorida;
            this.ClientSize = new System.Drawing.Size(641, 402);
            this.Controls.Add(this.panelEscondeVencimento);
            this.Controls.Add(this.chkContraApresentacao);
            this.Controls.Add(this.txtQuantiaL2);
            this.Controls.Add(this.txtQuantia);
            this.Controls.Add(this.txtDoAnoDe);
            this.Controls.Add(this.txtDiasDoMesDe);
            this.Controls.Add(this.txtAos);
            this.Controls.Add(this.data);
            this.Controls.Add(this.txtCGC);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtEmitente);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.dataPriVencimento);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.btnImprimir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(657, 438);
            this.Name = "JanelaPromissória";
            this.Text = "Impressão de Nota Promissória";
            this.Resize += new System.EventHandler(this.JanelaPromissória_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.DateTimePicker dataPriVencimento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtEmitente;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtCGC;
        private System.Windows.Forms.DateTimePicker data;
        private System.Windows.Forms.Label txtAos;
        private System.Windows.Forms.Label txtDiasDoMesDe;
        private System.Windows.Forms.Label txtDoAnoDe;
        private System.Windows.Forms.Label txtQuantia;
        private System.Windows.Forms.Label txtQuantiaL2;
        private System.Windows.Forms.CheckBox chkContraApresentacao;
        private System.Windows.Forms.Panel panelEscondeVencimento;
    }
}

