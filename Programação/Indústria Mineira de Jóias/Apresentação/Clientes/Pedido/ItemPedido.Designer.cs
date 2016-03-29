namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class ItemPedido
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
            this.tbl = new System.Windows.Forms.TableLayoutPanel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCódigo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRecepção = new System.Windows.Forms.Label();
            this.lblFuncionário = new System.Windows.Forms.Label();
            this.lblRegião = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPrevisão = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblConclusão = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.lblEntrega = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl
            // 
            this.tbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl.AutoSize = true;
            this.tbl.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbl.ColumnCount = 3;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Controls.Add(this.lblCliente, 0, 0);
            this.tbl.Controls.Add(this.label2, 0, 1);
            this.tbl.Controls.Add(this.lblCódigo, 1, 1);
            this.tbl.Controls.Add(this.label10, 0, 6);
            this.tbl.Controls.Add(this.label8, 0, 5);
            this.tbl.Controls.Add(this.label6, 0, 4);
            this.tbl.Controls.Add(this.label13, 0, 2);
            this.tbl.Controls.Add(this.lblRecepção, 1, 6);
            this.tbl.Controls.Add(this.lblFuncionário, 1, 5);
            this.tbl.Controls.Add(this.lblRegião, 1, 4);
            this.tbl.Controls.Add(this.lblTipo, 1, 2);
            this.tbl.Controls.Add(this.lblPrevisão, 2, 6);
            this.tbl.Controls.Add(this.label16, 0, 7);
            this.tbl.Controls.Add(this.lblConclusão, 1, 7);
            this.tbl.Controls.Add(this.lblDescrição, 2, 1);
            this.tbl.Controls.Add(this.lblEntrega, 2, 7);
            this.tbl.Location = new System.Drawing.Point(34, 3);
            this.tbl.Margin = new System.Windows.Forms.Padding(0);
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 8;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl.Size = new System.Drawing.Size(363, 160);
            this.tbl.TabIndex = 0;
            this.tbl.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.tbl.SetColumnSpan(this.lblCliente, 3);
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(99, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Nome do cliente";
            this.lblCliente.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código:";
            this.label2.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblCódigo
            // 
            this.lblCódigo.AutoSize = true;
            this.lblCódigo.Location = new System.Drawing.Point(115, 20);
            this.lblCódigo.Name = "lblCódigo";
            this.lblCódigo.Size = new System.Drawing.Size(50, 13);
            this.lblCódigo.TabIndex = 2;
            this.lblCódigo.Text = "lblCódigo";
            this.lblCódigo.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Recepção | Previsão";
            this.label10.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Recebido por:";
            this.label8.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Região:";
            this.label6.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Tipo:";
            this.label13.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblRecepção
            // 
            this.lblRecepção.AutoSize = true;
            this.lblRecepção.Location = new System.Drawing.Point(115, 120);
            this.lblRecepção.Name = "lblRecepção";
            this.lblRecepção.Size = new System.Drawing.Size(67, 13);
            this.lblRecepção.TabIndex = 10;
            this.lblRecepção.Text = "lblRecepção";
            this.lblRecepção.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblFuncionário
            // 
            this.lblFuncionário.AutoSize = true;
            this.lblFuncionário.Location = new System.Drawing.Point(115, 100);
            this.lblFuncionário.Name = "lblFuncionário";
            this.lblFuncionário.Size = new System.Drawing.Size(72, 13);
            this.lblFuncionário.TabIndex = 8;
            this.lblFuncionário.Text = "lblFuncionário";
            this.lblFuncionário.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblRegião
            // 
            this.lblRegião.AutoSize = true;
            this.lblRegião.Location = new System.Drawing.Point(115, 80);
            this.lblRegião.Name = "lblRegião";
            this.lblRegião.Size = new System.Drawing.Size(51, 13);
            this.lblRegião.TabIndex = 6;
            this.lblRegião.Text = "lblRegião";
            this.lblRegião.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(115, 39);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(38, 13);
            this.lblTipo.TabIndex = 13;
            this.lblTipo.Text = "lblTipo";
            this.lblTipo.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblPrevisão
            // 
            this.lblPrevisão.AutoSize = true;
            this.lblPrevisão.Location = new System.Drawing.Point(220, 120);
            this.lblPrevisão.Name = "lblPrevisão";
            this.lblPrevisão.Size = new System.Drawing.Size(58, 13);
            this.lblPrevisão.TabIndex = 14;
            this.lblPrevisão.Text = "lblPrevisão";
            this.lblPrevisão.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 140);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Conclusão | Entrega";
            this.label16.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblConclusão
            // 
            this.lblConclusão.AutoSize = true;
            this.lblConclusão.Location = new System.Drawing.Point(115, 140);
            this.lblConclusão.Name = "lblConclusão";
            this.lblConclusão.Size = new System.Drawing.Size(67, 13);
            this.lblConclusão.TabIndex = 16;
            this.lblConclusão.Text = "lblConclusão";
            this.lblConclusão.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblDescrição
            // 
            this.lblDescrição.AutoSize = true;
            this.lblDescrição.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrição.Location = new System.Drawing.Point(220, 20);
            this.lblDescrição.Name = "lblDescrição";
            this.tbl.SetRowSpan(this.lblDescrição, 5);
            this.lblDescrição.Size = new System.Drawing.Size(40, 9);
            this.lblDescrição.TabIndex = 19;
            this.lblDescrição.Text = "Descrição";
            this.lblDescrição.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // lblEntrega
            // 
            this.lblEntrega.AutoSize = true;
            this.lblEntrega.Location = new System.Drawing.Point(220, 140);
            this.lblEntrega.Name = "lblEntrega";
            this.lblEntrega.Size = new System.Drawing.Size(54, 13);
            this.lblEntrega.TabIndex = 18;
            this.lblEntrega.Text = "lblEntrega";
            this.lblEntrega.Click += new System.EventHandler(this.ItemPedido_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Apresentação.Resource.Impressora_3D;
            this.btnImprimir.Location = new System.Drawing.Point(3, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(29, 24);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // ItemPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Borda = System.Drawing.Color.Goldenrod;
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.tbl);
            this.Cor1 = System.Drawing.Color.Brown;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ItemPedido";
            this.Size = new System.Drawing.Size(400, 164);
            this.Click += new System.EventHandler(this.ItemPedido_Click);
            this.tbl.ResumeLayout(false);
            this.tbl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCódigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRegião;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRecepção;
        private System.Windows.Forms.Label lblFuncionário;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPrevisão;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblConclusão;
        private System.Windows.Forms.Label lblEntrega;
        private System.Windows.Forms.Label lblDescrição;
        private System.Windows.Forms.Button btnImprimir;
    }
}
