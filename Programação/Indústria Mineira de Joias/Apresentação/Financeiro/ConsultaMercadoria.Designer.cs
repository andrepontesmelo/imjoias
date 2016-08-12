namespace Apresentação.Financeiro
{
    partial class ConsultaMercadoria
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
            this.txtPeso = new Apresentação.Mercadoria.TxtPeso();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblReferência = new System.Windows.Forms.Label();
            this.txtMercadoria = new Apresentação.Mercadoria.TxtMercadoria();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lnkHistóricoCotações = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTabela = new Apresentação.Financeiro.ComboTabela();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCotação = new System.Windows.Forms.Label();
            this.linkPesquisaAvançada = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(135, 20);
            this.lblTítulo.Text = "Consulta rápida";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(274, 48);
            this.lblDescrição.Text = "Entre com os dados de alguma mercadoria para consultar seu preço.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.ConsultarMercadoria;
            this.picÍcone.InitialImage = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPeso);
            this.groupBox1.Controls.Add(this.lblPeso);
            this.groupBox1.Controls.Add(this.lblReferência);
            this.groupBox1.Controls.Add(this.txtMercadoria);
            this.groupBox1.Location = new System.Drawing.Point(15, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 257);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da mercadoria";
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = true;
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Flags = 0;
            this.txtPeso.Location = new System.Drawing.Point(5, 71);
            this.txtPeso.MaxDecimalPlaces = 4;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308D;
            this.txtPeso.RangeMin = -1.7976931348623157E+308D;
            this.txtPeso.Size = new System.Drawing.Size(150, 20);
            this.txtPeso.TabIndex = 1;
            this.txtPeso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPeso_KeyDown);
            // 
            // lblPeso
            // 
            this.lblPeso.Location = new System.Drawing.Point(3, 55);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(34, 13);
            this.lblPeso.TabIndex = 5;
            this.lblPeso.Text = "Peso:";
            // 
            // lblReferência
            // 
            this.lblReferência.Location = new System.Drawing.Point(6, 16);
            this.lblReferência.Name = "lblReferência";
            this.lblReferência.Size = new System.Drawing.Size(62, 13);
            this.lblReferência.TabIndex = 4;
            this.lblReferência.Text = "Referência:";
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.ControlePeso = this.txtPeso;
            this.txtMercadoria.Location = new System.Drawing.Point(6, 32);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Referência = "";
            this.txtMercadoria.Size = new System.Drawing.Size(150, 20);
            this.txtMercadoria.SomenteCadastrado = true;
            this.txtMercadoria.TabIndex = 0;
            this.txtMercadoria.ReferênciaConfirmada += new System.EventHandler(this.txtMercadoria_ReferênciaConfirmada);
            this.txtMercadoria.EscPressionado += new System.EventHandler(this.txtMercadoria_EscPressionado);
            this.txtMercadoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMercadoria_KeyDown);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(281, 376);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Location = new System.Drawing.Point(200, 376);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lnkHistóricoCotações
            // 
            this.lnkHistóricoCotações.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkHistóricoCotações.AutoSize = true;
            this.lnkHistóricoCotações.Location = new System.Drawing.Point(12, 382);
            this.lnkHistóricoCotações.Name = "lnkHistóricoCotações";
            this.lnkHistóricoCotações.Size = new System.Drawing.Size(155, 13);
            this.lnkHistóricoCotações.TabIndex = 5;
            this.lnkHistóricoCotações.TabStop = true;
            this.lnkHistóricoCotações.Text = "Consultar histórico de cotações";
            this.lnkHistóricoCotações.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHistóricoCotações_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTabela);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblCotação);
            this.groupBox2.Controls.Add(this.txtCotação);
            this.groupBox2.Location = new System.Drawing.Point(187, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 257);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados financeiros";
            // 
            // cmbTabela
            // 
            this.cmbTabela.Cotação = this.txtCotação;
            this.cmbTabela.DisplayMember = "Nome";
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.Location = new System.Drawing.Point(9, 32);
            this.cmbTabela.Mercadoria = this.txtMercadoria;
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(142, 21);
            this.cmbTabela.TabIndex = 6;
            // 
            // txtCotação
            // 
            this.txtCotação.Cotação = null;
            this.txtCotação.Location = new System.Drawing.Point(9, 71);
            this.txtCotação.MostrarListaCotações = true;
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(145, 20);
            this.txtCotação.TabIndex = 4;
            this.txtCotação.Valor = 0D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tabela:";
            this.label1.Visible = false;
            // 
            // lblCotação
            // 
            this.lblCotação.Location = new System.Drawing.Point(6, 55);
            this.lblCotação.Name = "lblCotação";
            this.lblCotação.Size = new System.Drawing.Size(50, 13);
            this.lblCotação.TabIndex = 3;
            this.lblCotação.Text = "Cotação:";
            // 
            // linkPesquisaAvançada
            // 
            this.linkPesquisaAvançada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkPesquisaAvançada.AutoSize = true;
            this.linkPesquisaAvançada.Location = new System.Drawing.Point(12, 365);
            this.linkPesquisaAvançada.Name = "linkPesquisaAvançada";
            this.linkPesquisaAvançada.Size = new System.Drawing.Size(141, 13);
            this.linkPesquisaAvançada.TabIndex = 7;
            this.linkPesquisaAvançada.TabStop = true;
            this.linkPesquisaAvançada.Text = "Realizar pesquisa avançada";
            this.linkPesquisaAvançada.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPesquisaAvançada_LinkClicked);
            // 
            // ConsultaMercadoria
            // 
            this.ClientSize = new System.Drawing.Size(362, 406);
            this.Controls.Add(this.linkPesquisaAvançada);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lnkHistóricoCotações);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.KeyPreview = true;
            this.Name = "ConsultaMercadoria";
            this.Text = "Consulta de preço";
            this.Shown += new System.EventHandler(this.ConsultaMercadoria_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsultaMercadoria_KeyDown);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            this.Controls.SetChildIndex(this.lnkHistóricoCotações, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.linkPesquisaAvançada, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private Apresentação.Mercadoria.TxtMercadoria txtMercadoria;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblReferência;
        private System.Windows.Forms.Button btnConsultar;
        private Apresentação.Mercadoria.TxtPeso txtPeso;
        private System.Windows.Forms.LinkLabel lnkHistóricoCotações;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComboTabela cmbTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCotação;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
        private System.Windows.Forms.LinkLabel linkPesquisaAvançada;

    }
}
