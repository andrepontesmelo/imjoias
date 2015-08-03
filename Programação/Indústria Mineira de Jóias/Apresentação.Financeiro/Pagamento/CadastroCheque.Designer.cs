namespace Apresentação.Financeiro.Pagamento
{
    partial class CadastroCheque
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
            this.dataVencimento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCPF = new Apresentação.Pessoa.TextBoxCPF();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDevolvido = new System.Windows.Forms.CheckBox();
            this.chkTerceiro = new System.Windows.Forms.CheckBox();
            this.dataProrrogação = new System.Windows.Forms.DateTimePicker();
            this.chkProrrogado = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPagamentoPendente
            // 
            this.chkPagamentoPendente.Location = new System.Drawing.Point(6, 325);
            this.chkPagamentoPendente.TabIndex = 4;
            // 
            // txtValor
            // 
            this.txtValor.Size = new System.Drawing.Size(215, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkProrrogado);
            this.groupBox1.Controls.Add(this.dataProrrogação);
            this.groupBox1.Controls.Add(this.chkTerceiro);
            this.groupBox1.Controls.Add(this.chkDevolvido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCPF);
            this.groupBox1.Controls.Add(this.dataVencimento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(2, 93);
            this.groupBox1.Size = new System.Drawing.Size(230, 352);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.Controls.SetChildIndex(this.chkCobrarJuros, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtValor, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.Controls.SetChildIndex(this.dataVencimento, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtCPF, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkPagamentoPendente, 0);
            this.groupBox1.Controls.SetChildIndex(this.label5, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkDevolvido, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkTerceiro, 0);
            this.groupBox1.Controls.SetChildIndex(this.dataProrrogação, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkProrrogado, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Size = new System.Drawing.Size(192, 206);
            // 
            // chkCobrarJuros
            // 
            this.chkCobrarJuros.Location = new System.Drawing.Point(6, 255);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(76, 457);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(157, 457);
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(71, 20);
            this.lblTítulo.Text = "Cheque";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(156, 48);
            this.lblDescrição.Text = "As informações gerais estão à esquerda.  À direita você pode incluir vendas que e" +
                "stejam relacionas com este cheque.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.cheque1;
            // 
            // dataVencimento
            // 
            this.dataVencimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataVencimento.Location = new System.Drawing.Point(6, 152);
            this.dataVencimento.Name = "dataVencimento";
            this.dataVencimento.Size = new System.Drawing.Size(215, 20);
            this.dataVencimento.TabIndex = 2;
            this.dataVencimento.Validated += new System.EventHandler(this.dataVencimento_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vencimento:";
            // 
            // txtCPF
            // 
            this.txtCPF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCPF.Location = new System.Drawing.Point(6, 235);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(218, 20);
            this.txtCPF.TabIndex = 10;
            this.txtCPF.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "CPF:";
            // 
            // chkDevolvido
            // 
            this.chkDevolvido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDevolvido.AutoSize = true;
            this.chkDevolvido.Location = new System.Drawing.Point(6, 278);
            this.chkDevolvido.Name = "chkDevolvido";
            this.chkDevolvido.Size = new System.Drawing.Size(112, 17);
            this.chkDevolvido.TabIndex = 12;
            this.chkDevolvido.TabStop = false;
            this.chkDevolvido.Text = "Cheque devolvido";
            this.chkDevolvido.UseVisualStyleBackColor = true;
            this.chkDevolvido.CheckedChanged += new System.EventHandler(this.chkDevolvido_CheckedChanged);
            // 
            // chkTerceiro
            // 
            this.chkTerceiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTerceiro.AutoSize = true;
            this.chkTerceiro.Location = new System.Drawing.Point(6, 301);
            this.chkTerceiro.Name = "chkTerceiro";
            this.chkTerceiro.Size = new System.Drawing.Size(116, 17);
            this.chkTerceiro.TabIndex = 4;
            this.chkTerceiro.Text = "Cheque de terceiro";
            this.chkTerceiro.UseVisualStyleBackColor = true;
            this.chkTerceiro.Validated += new System.EventHandler(this.chkTerceiro_Validated);
            // 
            // dataProrrogação
            // 
            this.dataProrrogação.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataProrrogação.Enabled = false;
            this.dataProrrogação.Location = new System.Drawing.Point(6, 196);
            this.dataProrrogação.Name = "dataProrrogação";
            this.dataProrrogação.Size = new System.Drawing.Size(215, 20);
            this.dataProrrogação.TabIndex = 17;
            this.dataProrrogação.TabStop = false;
            this.dataProrrogação.ValueChanged += new System.EventHandler(this.dataProrrogação_ValueChanged);
            this.dataProrrogação.Validated += new System.EventHandler(this.dataProrrogação_Validated);
            // 
            // chkProrrogado
            // 
            this.chkProrrogado.AutoSize = true;
            this.chkProrrogado.Location = new System.Drawing.Point(6, 178);
            this.chkProrrogado.Name = "chkProrrogado";
            this.chkProrrogado.Size = new System.Drawing.Size(81, 17);
            this.chkProrrogado.TabIndex = 18;
            this.chkProrrogado.TabStop = false;
            this.chkProrrogado.Text = "Prorrogado:";
            this.chkProrrogado.UseVisualStyleBackColor = true;
            this.chkProrrogado.CheckedChanged += new System.EventHandler(this.chkProrrogado_CheckedChanged);
            // 
            // CadastroCheque
            // 
            this.ClientSize = new System.Drawing.Size(244, 492);
            this.Name = "CadastroCheque";
            this.Text = "Cheque";
            this.Load += new System.EventHandler(this.CadastroCheque_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DateTimePicker dataVencimento;
        private System.Windows.Forms.Label label4;
        private Apresentação.Pessoa.TextBoxCPF txtCPF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDevolvido;
        private System.Windows.Forms.CheckBox chkTerceiro;
        private System.Windows.Forms.CheckBox chkProrrogado;
        private System.Windows.Forms.DateTimePicker dataProrrogação;
    }
}
