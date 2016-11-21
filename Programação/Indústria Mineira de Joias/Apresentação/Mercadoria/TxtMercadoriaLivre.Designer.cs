namespace Apresentação.Mercadoria
{
    partial class TxtMercadoriaLivre
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
            this.btnPesquisar = new System.Windows.Forms.Panel();
            this.txtReferência = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPesquisar.BackgroundImage = global::Apresentação.Resource.ZoomHS1;
            this.btnPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Location = new System.Drawing.Point(158, 4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(21, 18);
            this.btnPesquisar.TabIndex = 15;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtReferência
            // 
            this.txtReferência.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferência.Location = new System.Drawing.Point(2, 1);
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Size = new System.Drawing.Size(155, 20);
            this.txtReferência.TabIndex = 14;
            this.txtReferência.Validated += new System.EventHandler(this.txtReferência_Validated);
            // 
            // TxtMercadoriaLivre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtReferência);
            this.Name = "TxtMercadoriaLivre";
            this.Size = new System.Drawing.Size(177, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel btnPesquisar;
        private System.Windows.Forms.TextBox txtReferência;
    }
}
