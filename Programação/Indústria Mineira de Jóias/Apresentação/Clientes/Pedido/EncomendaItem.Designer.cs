namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class EncomendaItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReferênciaFornecedor = new System.Windows.Forms.TextBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.txtFornecedor = new Apresentação.Formulários.Fornecedor.TxtFornecedor();
            this.txtMercadoria = new Apresentação.Mercadoria.TxtMercadoria();
            this.btnRastrear = new Apresentação.Formulários.Opção();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 9);
            this.label1.TabIndex = 1;
            this.label1.Text = "Referência";
            this.label1.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 9);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fornecedor";
            this.label2.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 9);
            this.label3.TabIndex = 4;
            this.label3.Text = "Referência do Fornecedor";
            this.label3.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // txtReferênciaFornecedor
            // 
            this.txtReferênciaFornecedor.Enabled = false;
            this.txtReferênciaFornecedor.Location = new System.Drawing.Point(53, 54);
            this.txtReferênciaFornecedor.Name = "txtReferênciaFornecedor";
            this.txtReferênciaFornecedor.Size = new System.Drawing.Size(164, 20);
            this.txtReferênciaFornecedor.TabIndex = 5;
            this.txtReferênciaFornecedor.Leave += new System.EventHandler(this.txtReferênciaFornecedor_Leave);
            this.txtReferênciaFornecedor.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.txtReferênciaFornecedor.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(223, 15);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrição.Size = new System.Drawing.Size(196, 102);
            this.txtDescrição.TabIndex = 6;
            this.txtDescrição.Leave += new System.EventHandler(this.txtDescrição_Leave);
            this.txtDescrição.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.txtDescrição.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(4, 15);
            this.txtQuantidade.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(43, 20);
            this.txtQuantidade.TabIndex = 7;
            this.txtQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantidade.ValueChanged += new System.EventHandler(this.txtQuantidade_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 9);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantidade";
            this.label4.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(221, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 9);
            this.label5.TabIndex = 11;
            this.label5.Text = "Detalhes";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.delete;
            this.opçãoExcluir.Location = new System.Drawing.Point(4, 83);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.TabIndex = 12;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.Location = new System.Drawing.Point(4, 54);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Referência = "";
            this.txtFornecedor.Size = new System.Drawing.Size(43, 20);
            this.txtFornecedor.TabIndex = 3;
            this.txtFornecedor.Leave += new System.EventHandler(this.txtFornecedor_Leave);
            this.txtFornecedor.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.txtFornecedor.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.Location = new System.Drawing.Point(53, 15);
            this.txtMercadoria.MostrarBalãoRefNãoEncontrada = false;
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Referência = "";
            this.txtMercadoria.Size = new System.Drawing.Size(164, 20);
            this.txtMercadoria.SomenteCadastrado = true;
            this.txtMercadoria.TabIndex = 0;
            this.txtMercadoria.ReferênciaAlterada += new System.EventHandler(this.txtMercadoria_ReferênciaAlterada);
            this.txtMercadoria.Leave += new System.EventHandler(this.txtMercadoria_Leave);
            this.txtMercadoria.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.txtMercadoria.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            // 
            // btnRastrear
            // 
            this.btnRastrear.BackColor = System.Drawing.Color.Transparent;
            this.btnRastrear.Descrição = "Rastrear";
            this.btnRastrear.Imagem = global::Apresentação.Resource.Lupa11;
            this.btnRastrear.Location = new System.Drawing.Point(4, 101);
            this.btnRastrear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRastrear.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnRastrear.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnRastrear.Name = "btnRastrear";
            this.btnRastrear.Size = new System.Drawing.Size(150, 16);
            this.btnRastrear.TabIndex = 10;
            this.btnRastrear.Click += new System.EventHandler(this.btnRastrear_Click);
            // 
            // EncomendaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.opçãoExcluir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtDescrição);
            this.Controls.Add(this.txtReferênciaFornecedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMercadoria);
            this.Controls.Add(this.btnRastrear);
            this.Name = "EncomendaItem";
            this.Size = new System.Drawing.Size(422, 123);
            this.MouseEnter += new System.EventHandler(this.EncomendaItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.EncomendaItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Mercadoria.TxtMercadoria txtMercadoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Apresentação.Formulários.Fornecedor.TxtFornecedor txtFornecedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReferênciaFornecedor;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.NumericUpDown txtQuantidade;
        private System.Windows.Forms.Label label4;
        private Formulários.Opção btnRastrear;
        private System.Windows.Forms.Label label5;
        private Formulários.Opção opçãoExcluir;
    }
}
