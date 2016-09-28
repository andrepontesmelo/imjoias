namespace Apresentação.Fiscal
{
    partial class JanelaNFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaNFe));
            this.btnFechar = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtAliquota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroFatura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUltimaVenda = new System.Windows.Forms.TextBox();
            this.lnkBuscarCFOP = new System.Windows.Forms.LinkLabel();
            this.txtCFOPDesc = new System.Windows.Forms.TextBox();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNfe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCódigoVenda = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(147, 20);
            this.lblTítulo.Text = "Geração de NF-e";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(551, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(557, 435);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Location = new System.Drawing.Point(2, 96);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(637, 337);
            this.tab.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtAliquota);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtNumeroFatura);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtUltimaVenda);
            this.tabPage1.Controls.Add(this.lnkBuscarCFOP);
            this.tabPage1.Controls.Add(this.txtCFOPDesc);
            this.tabPage1.Controls.Add(this.flow);
            this.tabPage1.Controls.Add(this.txtCFOP);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtNfe);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCódigoVenda);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(629, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados de entrada";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtAliquota
            // 
            this.txtAliquota.Location = new System.Drawing.Point(229, 67);
            this.txtAliquota.Multiline = true;
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Size = new System.Drawing.Size(52, 20);
            this.txtAliquota.TabIndex = 5;
            this.txtAliquota.Text = "3,95";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Alíquota:";
            // 
            // txtNumeroFatura
            // 
            this.txtNumeroFatura.Location = new System.Drawing.Point(111, 93);
            this.txtNumeroFatura.Multiline = true;
            this.txtNumeroFatura.Name = "txtNumeroFatura";
            this.txtNumeroFatura.Size = new System.Drawing.Size(58, 20);
            this.txtNumeroFatura.TabIndex = 6;
            this.txtNumeroFatura.Text = "301";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Número da fatura:";
            // 
            // txtUltimaVenda
            // 
            this.txtUltimaVenda.Location = new System.Drawing.Point(176, 14);
            this.txtUltimaVenda.Name = "txtUltimaVenda";
            this.txtUltimaVenda.ReadOnly = true;
            this.txtUltimaVenda.Size = new System.Drawing.Size(391, 20);
            this.txtUltimaVenda.TabIndex = 14;
            // 
            // lnkBuscarCFOP
            // 
            this.lnkBuscarCFOP.AutoSize = true;
            this.lnkBuscarCFOP.Location = new System.Drawing.Point(578, 44);
            this.lnkBuscarCFOP.Name = "lnkBuscarCFOP";
            this.lnkBuscarCFOP.Size = new System.Drawing.Size(40, 13);
            this.lnkBuscarCFOP.TabIndex = 3;
            this.lnkBuscarCFOP.TabStop = true;
            this.lnkBuscarCFOP.Text = "Buscar";
            this.lnkBuscarCFOP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBuscarCFOP_LinkClicked);
            // 
            // txtCFOPDesc
            // 
            this.txtCFOPDesc.Location = new System.Drawing.Point(176, 41);
            this.txtCFOPDesc.Name = "txtCFOPDesc";
            this.txtCFOPDesc.ReadOnly = true;
            this.txtCFOPDesc.Size = new System.Drawing.Size(391, 20);
            this.txtCFOPDesc.TabIndex = 12;
            // 
            // flow
            // 
            this.flow.AutoScroll = true;
            this.flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flow.Location = new System.Drawing.Point(0, 119);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(626, 186);
            this.flow.TabIndex = 11;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Location = new System.Drawing.Point(112, 41);
            this.txtCFOP.Multiline = true;
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(58, 20);
            this.txtCFOP.TabIndex = 2;
            this.txtCFOP.Text = "5101";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Código CFOP MG:";
            // 
            // txtNfe
            // 
            this.txtNfe.Location = new System.Drawing.Point(112, 67);
            this.txtNfe.Multiline = true;
            this.txtNfe.Name = "txtNfe";
            this.txtNfe.Size = new System.Drawing.Size(58, 20);
            this.txtNfe.TabIndex = 4;
            this.txtNfe.Text = "301";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Número da NF-e:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código da venda:";
            // 
            // txtCódigoVenda
            // 
            this.txtCódigoVenda.Location = new System.Drawing.Point(112, 12);
            this.txtCódigoVenda.MaxLength = 7;
            this.txtCódigoVenda.Name = "txtCódigoVenda";
            this.txtCódigoVenda.Size = new System.Drawing.Size(58, 20);
            this.txtCódigoVenda.TabIndex = 1;
            this.txtCódigoVenda.Enter += new System.EventHandler(this.txtCódigoVenda_Enter);
            this.txtCódigoVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCódigoVenda_KeyDown);
            this.txtCódigoVenda.Validating += new System.ComponentModel.CancelEventHandler(this.txtCódigoVenda_Validating);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(476, 436);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // JanelaNFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 471);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnFechar);
            this.Name = "JanelaNFe";
            this.Text = "";
            this.Controls.SetChildIndex(this.btnFechar, 0);
            this.Controls.SetChildIndex(this.btnSalvar, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtCódigoVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtNfe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.TextBox txtUltimaVenda;
        private System.Windows.Forms.LinkLabel lnkBuscarCFOP;
        private System.Windows.Forms.TextBox txtCFOPDesc;
        private System.Windows.Forms.TextBox txtNumeroFatura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAliquota;
        private System.Windows.Forms.Label label5;
    }
}