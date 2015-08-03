namespace Apresentação.Atendimento.Clientes
{
    partial class JanelaEtiquetaSedexEdicao
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
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkAlterar = new System.Windows.Forms.LinkLabel();
            this.txtEndereço = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optRemetente = new System.Windows.Forms.RadioButton();
            this.optDestinatario = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(166, 20);
            this.lblTítulo.Text = "Opções de etiqueta";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(517, 48);
            this.lblDescrição.Text = "O tipo da etiqueta pode ser alterado aqui";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.sedex;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(518, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtQuantidade);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lnkAlterar);
            this.groupBox1.Controls.Add(this.txtEndereço);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.optRemetente);
            this.groupBox1.Controls.Add(this.optDestinatario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(498, 66);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(77, 20);
            this.txtQuantidade.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quantidade:";
            // 
            // lnkAlterar
            // 
            this.lnkAlterar.AutoSize = true;
            this.lnkAlterar.Location = new System.Drawing.Point(351, 88);
            this.lnkAlterar.Name = "lnkAlterar";
            this.lnkAlterar.Size = new System.Drawing.Size(37, 13);
            this.lnkAlterar.TabIndex = 5;
            this.lnkAlterar.TabStop = true;
            this.lnkAlterar.Text = "Alterar";
            this.lnkAlterar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlterar_LinkClicked);
            // 
            // txtEndereço
            // 
            this.txtEndereço.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEndereço.Location = new System.Drawing.Point(68, 16);
            this.txtEndereço.Multiline = true;
            this.txtEndereço.Name = "txtEndereço";
            this.txtEndereço.Size = new System.Drawing.Size(320, 70);
            this.txtEndereço.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Endereço:";
            // 
            // optRemetente
            // 
            this.optRemetente.AutoSize = true;
            this.optRemetente.Location = new System.Drawing.Point(498, 34);
            this.optRemetente.Name = "optRemetente";
            this.optRemetente.Size = new System.Drawing.Size(77, 17);
            this.optRemetente.TabIndex = 2;
            this.optRemetente.Text = "Remetente";
            this.optRemetente.UseVisualStyleBackColor = true;
            // 
            // optDestinatario
            // 
            this.optDestinatario.AutoSize = true;
            this.optDestinatario.Checked = true;
            this.optDestinatario.Location = new System.Drawing.Point(498, 19);
            this.optDestinatario.Name = "optDestinatario";
            this.optDestinatario.Size = new System.Drawing.Size(81, 17);
            this.optDestinatario.TabIndex = 1;
            this.optDestinatario.TabStop = true;
            this.optDestinatario.Text = "Destinatário";
            this.optDestinatario.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo da etiqueta:";
            // 
            // JanelaEtiquetaSedexEdicao
            // 
            this.ClientSize = new System.Drawing.Size(605, 240);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Name = "JanelaEtiquetaSedexEdicao";
            this.Text = "Opções de etiqueta";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkAlterar;
        private System.Windows.Forms.TextBox txtEndereço;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optRemetente;
        private System.Windows.Forms.RadioButton optDestinatario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtQuantidade;
        private System.Windows.Forms.Label label3;
    }
}
