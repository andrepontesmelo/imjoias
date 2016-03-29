namespace Apresentação.Formulários
{
    partial class ItemExpandível
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
            this.tabela = new System.Windows.Forms.TableLayoutPanel();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.picExpandir = new System.Windows.Forms.PictureBox();
            this.tabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExpandir)).BeginInit();
            this.SuspendLayout();
            // 
            // tabela
            // 
            this.tabela.AutoSize = true;
            this.tabela.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabela.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tabela.ColumnCount = 3;
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tabela.Controls.Add(this.lblItem, 0, 0);
            this.tabela.Controls.Add(this.lblValor, 1, 0);
            this.tabela.Controls.Add(this.picExpandir, 2, 0);
            this.tabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela.Location = new System.Drawing.Point(0, 0);
            this.tabela.Name = "tabela";
            this.tabela.RowCount = 1;
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tabela.Size = new System.Drawing.Size(150, 19);
            this.tabela.TabIndex = 0;
            // 
            // lblItem
            // 
            this.lblItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItem.AutoSize = true;
            this.lblItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(3, 3);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(31, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItem.Click += new System.EventHandler(this.AjustarTamanho);
            // 
            // lblValor
            // 
            this.lblValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(40, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(88, 19);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "Valor";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValor.Click += new System.EventHandler(this.AjustarTamanho);
            // 
            // picExpandir
            // 
            this.picExpandir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExpandir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExpandir.Image = global::Apresentação.Resource.Expand_large;
            this.picExpandir.Location = new System.Drawing.Point(134, 3);
            this.picExpandir.Name = "picExpandir";
            this.picExpandir.Size = new System.Drawing.Size(13, 13);
            this.picExpandir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picExpandir.TabIndex = 2;
            this.picExpandir.TabStop = false;
            this.picExpandir.Click += new System.EventHandler(this.AjustarTamanho);
            // 
            // ItemExpandível
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tabela);
            this.Name = "ItemExpandível";
            this.Size = new System.Drawing.Size(150, 19);
            this.tabela.ResumeLayout(false);
            this.tabela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExpandir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabela;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.PictureBox picExpandir;
    }
}
