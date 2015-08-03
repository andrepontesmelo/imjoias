namespace Apresentação.Financeiro.Acerto
{
    partial class JanelaDesconto
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
            this.txtPorcentagemDesconto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtÍndiceVendido = new System.Windows.Forms.TextBox();
            this.txtPorcentagemVendida = new System.Windows.Forms.TextBox();
            this.txtÍndiceVendidoPeça = new System.Windows.Forms.TextBox();
            this.txtÍndiceLevado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAtualizarDescontoVenda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(86, 20);
            this.lblTítulo.Text = "Desconto";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(323, 48);
            this.lblDescrição.Text = "Esta tela computa o índice dos documentos relacionados ao acerto. O desconto fina" +
                "l pode ser de 15% ou 10% em função da porcentagem vendida ser maior que 20%.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.CalculatorHS;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPorcentagemDesconto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDesconto);
            this.groupBox1.Controls.Add(this.txtÍndiceVendido);
            this.groupBox1.Controls.Add(this.txtPorcentagemVendida);
            this.groupBox1.Controls.Add(this.txtÍndiceVendidoPeça);
            this.groupBox1.Controls.Add(this.txtÍndiceLevado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 148);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Desconto";
            // 
            // txtPorcentagemDesconto
            // 
            this.txtPorcentagemDesconto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPorcentagemDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentagemDesconto.Location = new System.Drawing.Point(209, 122);
            this.txtPorcentagemDesconto.Name = "txtPorcentagemDesconto";
            this.txtPorcentagemDesconto.ReadOnly = true;
            this.txtPorcentagemDesconto.Size = new System.Drawing.Size(170, 20);
            this.txtPorcentagemDesconto.TabIndex = 11;
            this.txtPorcentagemDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Porcentagem de desconto:";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(211, 83);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ReadOnly = true;
            this.txtDesconto.Size = new System.Drawing.Size(170, 20);
            this.txtDesconto.TabIndex = 9;
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtÍndiceVendido
            // 
            this.txtÍndiceVendido.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtÍndiceVendido.Location = new System.Drawing.Point(7, 83);
            this.txtÍndiceVendido.Name = "txtÍndiceVendido";
            this.txtÍndiceVendido.ReadOnly = true;
            this.txtÍndiceVendido.Size = new System.Drawing.Size(175, 20);
            this.txtÍndiceVendido.TabIndex = 8;
            this.txtÍndiceVendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPorcentagemVendida
            // 
            this.txtPorcentagemVendida.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPorcentagemVendida.Location = new System.Drawing.Point(5, 122);
            this.txtPorcentagemVendida.Name = "txtPorcentagemVendida";
            this.txtPorcentagemVendida.ReadOnly = true;
            this.txtPorcentagemVendida.Size = new System.Drawing.Size(175, 20);
            this.txtPorcentagemVendida.TabIndex = 7;
            this.txtPorcentagemVendida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtÍndiceVendidoPeça
            // 
            this.txtÍndiceVendidoPeça.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtÍndiceVendidoPeça.Location = new System.Drawing.Point(209, 42);
            this.txtÍndiceVendidoPeça.Name = "txtÍndiceVendidoPeça";
            this.txtÍndiceVendidoPeça.ReadOnly = true;
            this.txtÍndiceVendidoPeça.Size = new System.Drawing.Size(172, 20);
            this.txtÍndiceVendidoPeça.TabIndex = 6;
            this.txtÍndiceVendidoPeça.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtÍndiceLevado
            // 
            this.txtÍndiceLevado.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtÍndiceLevado.Location = new System.Drawing.Point(7, 42);
            this.txtÍndiceLevado.Name = "txtÍndiceLevado";
            this.txtÍndiceLevado.ReadOnly = true;
            this.txtÍndiceLevado.Size = new System.Drawing.Size(175, 20);
            this.txtÍndiceLevado.TabIndex = 5;
            this.txtÍndiceLevado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Desconto em R$:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Índice vendido (apenas peça):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Porcentagem vendida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total em índice vendido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total em índice levado (nas saídas):";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(322, 250);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Fechar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAtualizarDescontoVenda
            // 
            this.btnAtualizarDescontoVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarDescontoVenda.Location = new System.Drawing.Point(12, 250);
            this.btnAtualizarDescontoVenda.Name = "btnAtualizarDescontoVenda";
            this.btnAtualizarDescontoVenda.Size = new System.Drawing.Size(304, 23);
            this.btnAtualizarDescontoVenda.TabIndex = 5;
            this.btnAtualizarDescontoVenda.Text = "Atualizar desconto na venda";
            this.btnAtualizarDescontoVenda.UseVisualStyleBackColor = true;
            this.btnAtualizarDescontoVenda.Click += new System.EventHandler(this.btnAtualizarDescontoVenda_Click);
            // 
            // JanelaDesconto
            // 
            this.AcceptButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(411, 279);
            this.Controls.Add(this.btnAtualizarDescontoVenda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Name = "JanelaDesconto";
            this.Text = "Cálculo do desconto";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnAtualizarDescontoVenda, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.TextBox txtÍndiceVendido;
        private System.Windows.Forms.TextBox txtPorcentagemVendida;
        private System.Windows.Forms.TextBox txtÍndiceVendidoPeça;
        private System.Windows.Forms.TextBox txtÍndiceLevado;
        private System.Windows.Forms.Button btnAtualizarDescontoVenda;
        private System.Windows.Forms.TextBox txtPorcentagemDesconto;
        private System.Windows.Forms.Label label6;
    }
}
