namespace Apresentação.Financeiro.Acerto
{
    partial class DadosAcerto
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
            this.lblMarcação = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.lblPrevisão = new System.Windows.Forms.Label();
            this.dtPrevisão = new System.Windows.Forms.DateTimePicker();
            this.lblEfetivação = new System.Windows.Forms.Label();
            this.dtRealização = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTabela = new Apresentação.Financeiro.ComboTabela();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMarcação
            // 
            this.lblMarcação.AutoSize = true;
            this.lblMarcação.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcação.Location = new System.Drawing.Point(3, 29);
            this.lblMarcação.Name = "lblMarcação";
            this.lblMarcação.Size = new System.Drawing.Size(41, 13);
            this.lblMarcação.TabIndex = 2;
            this.lblMarcação.Text = "Desde:";
            // 
            // dtDesde
            // 
            this.dtDesde.Enabled = false;
            this.dtDesde.Location = new System.Drawing.Point(6, 46);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(209, 20);
            this.dtDesde.TabIndex = 3;
            // 
            // lblPrevisão
            // 
            this.lblPrevisão.AutoSize = true;
            this.lblPrevisão.BackColor = System.Drawing.Color.Transparent;
            this.lblPrevisão.Location = new System.Drawing.Point(3, 69);
            this.lblPrevisão.Name = "lblPrevisão";
            this.lblPrevisão.Size = new System.Drawing.Size(51, 13);
            this.lblPrevisão.TabIndex = 6;
            this.lblPrevisão.Text = "Previsão:";
            // 
            // dtPrevisão
            // 
            this.dtPrevisão.CustomFormat = "ddd, dd \'de\' MMM \'de\' yyyy, \'às\' HH:mm";
            this.dtPrevisão.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPrevisão.Location = new System.Drawing.Point(6, 85);
            this.dtPrevisão.Name = "dtPrevisão";
            this.dtPrevisão.Size = new System.Drawing.Size(209, 20);
            this.dtPrevisão.TabIndex = 7;
            this.dtPrevisão.Validating += new System.ComponentModel.CancelEventHandler(this.dtPrevisão_Validating);
            this.dtPrevisão.Validated += new System.EventHandler(this.dtPrevisão_Validated);
            // 
            // lblEfetivação
            // 
            this.lblEfetivação.AutoSize = true;
            this.lblEfetivação.BackColor = System.Drawing.Color.Transparent;
            this.lblEfetivação.Location = new System.Drawing.Point(3, 108);
            this.lblEfetivação.Name = "lblEfetivação";
            this.lblEfetivação.Size = new System.Drawing.Size(147, 13);
            this.lblEfetivação.TabIndex = 10;
            this.lblEfetivação.Text = "Data de realização do acerto:";
            // 
            // dtRealização
            // 
            this.dtRealização.Enabled = false;
            this.dtRealização.Location = new System.Drawing.Point(6, 124);
            this.dtRealização.Name = "dtRealização";
            this.dtRealização.Size = new System.Drawing.Size(209, 20);
            this.dtRealização.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tabela:";
            // 
            // cmbTabela
            // 
            this.cmbTabela.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTabela.Cotação = this.txtCotação;
            this.cmbTabela.DisplayMember = "Nome";
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.Enabled = false;
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.Location = new System.Drawing.Point(7, 202);
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(208, 21);
            this.cmbTabela.TabIndex = 13;
            // 
            // txtCotação
            // 
            this.txtCotação.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCotação.Cotação = null;
            this.txtCotação.Enabled = false;
            this.txtCotação.IniciarValorAtual = false;
            this.txtCotação.Location = new System.Drawing.Point(7, 163);
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(208, 20);
            this.txtCotação.TabIndex = 15;
            this.txtCotação.Valor = 0D;
            this.txtCotação.EscolheuCotação += new Apresentação.Mercadoria.Cotação.TxtCotação.Escolha(this.txtCotação_EscolheuCotação);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cotação:";
            // 
            // DadosAcerto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCotação);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTabela);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtRealização);
            this.Controls.Add(this.lblMarcação);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.lblEfetivação);
            this.Controls.Add(this.dtPrevisão);
            this.Controls.Add(this.lblPrevisão);
            this.Name = "DadosAcerto";
            this.Size = new System.Drawing.Size(221, 229);
            this.Título = "Informações - Acerto";
            this.Controls.SetChildIndex(this.lblPrevisão, 0);
            this.Controls.SetChildIndex(this.dtPrevisão, 0);
            this.Controls.SetChildIndex(this.lblEfetivação, 0);
            this.Controls.SetChildIndex(this.dtDesde, 0);
            this.Controls.SetChildIndex(this.lblMarcação, 0);
            this.Controls.SetChildIndex(this.dtRealização, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbTabela, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCotação, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarcação;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label lblPrevisão;
        private System.Windows.Forms.DateTimePicker dtPrevisão;
        private System.Windows.Forms.Label lblEfetivação;
        private System.Windows.Forms.DateTimePicker dtRealização;
        private System.Windows.Forms.Label label1;
        private ComboTabela cmbTabela;
        private System.Windows.Forms.Label label2;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
    }
}
