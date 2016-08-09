namespace Apresentação.Financeiro
{
    partial class PesquisaMercadoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorMáximo = new AMS.TextBox.CurrencyTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTipo = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkMetal = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPedras = new System.Windows.Forms.CheckedListBox();
            this.btnPesqusiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbTabela = new Apresentação.Financeiro.ComboTabela();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(182, 20);
            this.lblTítulo.Text = "Pesquisar mercadoria";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(359, 48);
            this.lblDescrição.Text = "Escolha os critérios para pesquisa de mercadoria.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.ConsultarMercadoria;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tabela:";
            // 
            // txtCotação
            // 
            this.txtCotação.AvisarCotaçõesDesatualizadas = false;
            this.txtCotação.AvisarCotaçõesNãoCadastradas = false;
            this.txtCotação.Cotação = null;
            this.txtCotação.Location = new System.Drawing.Point(78, 131);
            this.txtCotação.MostrarListaCotações = false;
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(145, 20);
            this.txtCotação.TabIndex = 5;
            this.txtCotação.Valor = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cotação:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Valor máximo:";
            // 
            // txtValorMáximo
            // 
            this.txtValorMáximo.AllowNegative = true;
            this.txtValorMáximo.Flags = 7680;
            this.txtValorMáximo.Location = new System.Drawing.Point(78, 157);
            this.txtValorMáximo.MaxWholeDigits = 9;
            this.txtValorMáximo.Name = "txtValorMáximo";
            this.txtValorMáximo.RangeMax = 1.7976931348623157E+308;
            this.txtValorMáximo.RangeMin = -1.7976931348623157E+308;
            this.txtValorMáximo.Size = new System.Drawing.Size(145, 20);
            this.txtValorMáximo.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTipo);
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 88);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Joia";
            // 
            // chkTipo
            // 
            this.chkTipo.CheckOnClick = true;
            this.chkTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTipo.FormattingEnabled = true;
            this.chkTipo.Location = new System.Drawing.Point(3, 16);
            this.chkTipo.Name = "chkTipo";
            this.chkTipo.Size = new System.Drawing.Size(205, 64);
            this.chkTipo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkMetal);
            this.groupBox2.Location = new System.Drawing.Point(229, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 88);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Metal";
            // 
            // chkMetal
            // 
            this.chkMetal.CheckOnClick = true;
            this.chkMetal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMetal.FormattingEnabled = true;
            this.chkMetal.Location = new System.Drawing.Point(3, 16);
            this.chkMetal.Name = "chkMetal";
            this.chkMetal.Size = new System.Drawing.Size(199, 64);
            this.chkMetal.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkPedras);
            this.groupBox3.Location = new System.Drawing.Point(12, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 88);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pedras";
            // 
            // chkPedras
            // 
            this.chkPedras.CheckOnClick = true;
            this.chkPedras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPedras.FormattingEnabled = true;
            this.chkPedras.HorizontalScrollbar = true;
            this.chkPedras.Location = new System.Drawing.Point(3, 16);
            this.chkPedras.MultiColumn = true;
            this.chkPedras.Name = "chkPedras";
            this.chkPedras.Size = new System.Drawing.Size(413, 64);
            this.chkPedras.Sorted = true;
            this.chkPedras.TabIndex = 1;
            // 
            // btnPesqusiar
            // 
            this.btnPesqusiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesqusiar.Location = new System.Drawing.Point(279, 381);
            this.btnPesqusiar.Name = "btnPesqusiar";
            this.btnPesqusiar.Size = new System.Drawing.Size(75, 23);
            this.btnPesqusiar.TabIndex = 12;
            this.btnPesqusiar.Text = "Pesquisar";
            this.btnPesqusiar.UseVisualStyleBackColor = true;
            this.btnPesqusiar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(360, 381);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbTabela
            // 
            this.cmbTabela.Cotação = this.txtCotação;
            this.cmbTabela.DisplayMember = "Nome";
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.Location = new System.Drawing.Point(78, 104);
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(350, 21);
            this.cmbTabela.TabIndex = 4;
            // 
            // PesquisaMercadoria
            // 
            this.AcceptButton = this.btnPesqusiar;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(447, 413);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPesqusiar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtValorMáximo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCotação);
            this.Controls.Add(this.cmbTabela);
            this.Controls.Add(this.label1);
            this.Name = "PesquisaMercadoria";
            this.ShowInTaskbar = true;
            this.Text = "Pesquisar mercadoria";
            this.Load += new System.EventHandler(this.PesquisaMercadoria_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbTabela, 0);
            this.Controls.SetChildIndex(this.txtCotação, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtValorMáximo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnPesqusiar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ComboTabela cmbTabela;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private AMS.TextBox.CurrencyTextBox txtValorMáximo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chkTipo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chkMetal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chkPedras;
        private System.Windows.Forms.Button btnPesqusiar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
