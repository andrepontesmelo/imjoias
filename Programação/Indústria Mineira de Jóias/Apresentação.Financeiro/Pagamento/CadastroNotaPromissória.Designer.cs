namespace Apresenta��o.Financeiro.Pagamento
{
    partial class CadastroNotaPromiss�ria
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
            this.label5 = new System.Windows.Forms.Label();
            this.chkProrrogado = new System.Windows.Forms.CheckBox();
            this.dataProrroga��o = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPagamentoPendente
            // 
            this.chkPagamentoPendente.BackColor = System.Drawing.Color.Yellow;
            this.chkPagamentoPendente.Checked = true;
            this.chkPagamentoPendente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPagamentoPendente.Enabled = false;
            this.chkPagamentoPendente.Location = new System.Drawing.Point(2, 258);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkProrrogado);
            this.groupBox1.Controls.Add(this.dataProrroga��o);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataVencimento);
            this.groupBox1.Size = new System.Drawing.Size(230, 287);
            this.groupBox1.Controls.SetChildIndex(this.txtValor, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkCobrarJuros, 0);
            this.groupBox1.Controls.SetChildIndex(this.dataVencimento, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkPagamentoPendente, 0);
            this.groupBox1.Controls.SetChildIndex(this.label5, 0);
            this.groupBox1.Controls.SetChildIndex(this.dataProrroga��o, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkProrrogado, 0);
            // 
            // chkCobrarJuros
            // 
            this.chkCobrarJuros.Location = new System.Drawing.Point(2, 235);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(67, 383);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(148, 383);
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(144, 20);
            this.lblT�tulo.Text = "Nota promiss�ria";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(147, 48);
            this.lblDescri��o.Text = "As informa��es gerais est�o � esquerda.  � direita voc� pode incluir vendas que e" +
                "stejam relacionas com esta nota promiss�ria.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Financeiro.Properties.Resources.np;
            // 
            // dataVencimento
            // 
            this.dataVencimento.Location = new System.Drawing.Point(5, 155);
            this.dataVencimento.Name = "dataVencimento";
            this.dataVencimento.Size = new System.Drawing.Size(218, 20);
            this.dataVencimento.TabIndex = 3;
            this.dataVencimento.Validated += new System.EventHandler(this.dataVencimento_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vencimento:";
            // 
            // chkProrrogado
            // 
            this.chkProrrogado.AutoSize = true;
            this.chkProrrogado.Location = new System.Drawing.Point(5, 179);
            this.chkProrrogado.Name = "chkProrrogado";
            this.chkProrrogado.Size = new System.Drawing.Size(81, 17);
            this.chkProrrogado.TabIndex = 20;
            this.chkProrrogado.Text = "Prorrogado:";
            this.chkProrrogado.UseVisualStyleBackColor = true;
            this.chkProrrogado.CheckedChanged += new System.EventHandler(this.chkProrrogado_CheckedChanged);
            // 
            // dataProrroga��o
            // 
            this.dataProrroga��o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataProrroga��o.Enabled = false;
            this.dataProrroga��o.Location = new System.Drawing.Point(4, 202);
            this.dataProrroga��o.Name = "dataProrroga��o";
            this.dataProrroga��o.Size = new System.Drawing.Size(219, 20);
            this.dataProrroga��o.TabIndex = 19;
            this.dataProrroga��o.Validated += new System.EventHandler(this.dataProrroga��o_Validated);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Apresenta��o.Financeiro.Properties.Resources.impressora___16;
            this.btnImprimir.Location = new System.Drawing.Point(5, 381);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(34, 24);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // CadastroNotaPromiss�ria
            // 
            this.ClientSize = new System.Drawing.Size(235, 409);
            this.Controls.Add(this.btnImprimir);
            this.Name = "CadastroNotaPromiss�ria";
            this.Text = "Nota Promiss�ria";
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dataVencimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkProrrogado;
        private System.Windows.Forms.DateTimePicker dataProrroga��o;
        private System.Windows.Forms.Button btnImprimir;
    }
}
