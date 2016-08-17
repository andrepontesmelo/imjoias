namespace Apresenta��o.Financeiro
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
            this.txtPeso = new Apresenta��o.Mercadoria.TxtPeso();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblRefer�ncia = new System.Windows.Forms.Label();
            this.txtMercadoria = new Apresenta��o.Mercadoria.TxtMercadoria();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lnkHist�ricoCota��es = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTabela = new Apresenta��o.Financeiro.ComboTabela();
            this.txtCota��o = new Apresenta��o.Mercadoria.Cota��o.TxtCota��o();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCota��o = new System.Windows.Forms.Label();
            this.linkPesquisaAvan�ada = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(135, 20);
            this.lblT�tulo.Text = "Consulta r�pida";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(274, 48);
            this.lblDescri��o.Text = "Entre com os dados de alguma mercadoria para consultar seu pre�o.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Resource.ConsultarMercadoria;
            this.pic�cone.InitialImage = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPeso);
            this.groupBox1.Controls.Add(this.lblPeso);
            this.groupBox1.Controls.Add(this.lblRefer�ncia);
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
            // lblRefer�ncia
            // 
            this.lblRefer�ncia.Location = new System.Drawing.Point(6, 16);
            this.lblRefer�ncia.Name = "lblRefer�ncia";
            this.lblRefer�ncia.Size = new System.Drawing.Size(62, 13);
            this.lblRefer�ncia.TabIndex = 4;
            this.lblRefer�ncia.Text = "Refer�ncia:";
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.ControlePeso = this.txtPeso;
            this.txtMercadoria.Location = new System.Drawing.Point(6, 32);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Refer�ncia = "";
            this.txtMercadoria.Size = new System.Drawing.Size(150, 20);
            this.txtMercadoria.SomenteCadastrado = true;
            this.txtMercadoria.TabIndex = 0;
            this.txtMercadoria.Refer�nciaConfirmada += new System.EventHandler(this.txtMercadoria_Refer�nciaConfirmada);
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
            // lnkHist�ricoCota��es
            // 
            this.lnkHist�ricoCota��es.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkHist�ricoCota��es.AutoSize = true;
            this.lnkHist�ricoCota��es.Location = new System.Drawing.Point(12, 382);
            this.lnkHist�ricoCota��es.Name = "lnkHist�ricoCota��es";
            this.lnkHist�ricoCota��es.Size = new System.Drawing.Size(155, 13);
            this.lnkHist�ricoCota��es.TabIndex = 5;
            this.lnkHist�ricoCota��es.TabStop = true;
            this.lnkHist�ricoCota��es.Text = "Consultar hist�rico de cota��es";
            this.lnkHist�ricoCota��es.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHist�ricoCota��es_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTabela);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblCota��o);
            this.groupBox2.Controls.Add(this.txtCota��o);
            this.groupBox2.Location = new System.Drawing.Point(187, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 257);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados financeiros";
            // 
            // cmbTabela
            // 
            this.cmbTabela.Cota��o = this.txtCota��o;
            this.cmbTabela.DisplayMember = "Nome";
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.Location = new System.Drawing.Point(9, 32);
            this.cmbTabela.Mercadoria = this.txtMercadoria;
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(142, 21);
            this.cmbTabela.TabIndex = 6;
            // 
            // txtCota��o
            // 
            this.txtCota��o.Cota��o = null;
            this.txtCota��o.Location = new System.Drawing.Point(9, 71);
            this.txtCota��o.MostrarListaCota��es = true;
            this.txtCota��o.Name = "txtCota��o";
            this.txtCota��o.Size = new System.Drawing.Size(145, 20);
            this.txtCota��o.TabIndex = 4;
            this.txtCota��o.Valor = 0D;
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
            // lblCota��o
            // 
            this.lblCota��o.Location = new System.Drawing.Point(6, 55);
            this.lblCota��o.Name = "lblCota��o";
            this.lblCota��o.Size = new System.Drawing.Size(50, 13);
            this.lblCota��o.TabIndex = 3;
            this.lblCota��o.Text = "Cota��o:";
            // 
            // linkPesquisaAvan�ada
            // 
            this.linkPesquisaAvan�ada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkPesquisaAvan�ada.AutoSize = true;
            this.linkPesquisaAvan�ada.Location = new System.Drawing.Point(12, 365);
            this.linkPesquisaAvan�ada.Name = "linkPesquisaAvan�ada";
            this.linkPesquisaAvan�ada.Size = new System.Drawing.Size(141, 13);
            this.linkPesquisaAvan�ada.TabIndex = 7;
            this.linkPesquisaAvan�ada.TabStop = true;
            this.linkPesquisaAvan�ada.Text = "Realizar pesquisa avan�ada";
            this.linkPesquisaAvan�ada.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPesquisaAvan�ada_LinkClicked);
            // 
            // ConsultaMercadoria
            // 
            this.ClientSize = new System.Drawing.Size(362, 406);
            this.Controls.Add(this.linkPesquisaAvan�ada);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lnkHist�ricoCota��es);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.KeyPreview = true;
            this.Name = "ConsultaMercadoria";
            this.Text = "Consulta de pre�o";
            this.Shown += new System.EventHandler(this.ConsultaMercadoria_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsultaMercadoria_KeyDown);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            this.Controls.SetChildIndex(this.lnkHist�ricoCota��es, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.linkPesquisaAvan�ada, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
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
        private Apresenta��o.Mercadoria.TxtMercadoria txtMercadoria;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblRefer�ncia;
        private System.Windows.Forms.Button btnConsultar;
        private Apresenta��o.Mercadoria.TxtPeso txtPeso;
        private System.Windows.Forms.LinkLabel lnkHist�ricoCota��es;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComboTabela cmbTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCota��o;
        private Apresenta��o.Mercadoria.Cota��o.TxtCota��o txtCota��o;
        private System.Windows.Forms.LinkLabel linkPesquisaAvan�ada;

    }
}
