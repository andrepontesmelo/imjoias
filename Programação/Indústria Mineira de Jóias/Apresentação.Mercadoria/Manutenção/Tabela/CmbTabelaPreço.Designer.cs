namespace Apresentação.Mercadoria.Manutenção.Tabela
{
    partial class CmbTabelaPreço
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
            this.cmb = new System.Windows.Forms.ComboBox();
            this.btnNovo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cmb
            // 
            this.cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb.FormattingEnabled = true;
            this.cmb.Location = new System.Drawing.Point(0, 0);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(122, 21);
            this.cmb.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNovo.BackgroundImage = global::Apresentação.Mercadoria.Properties.Resources.EditTableHS;
            this.btnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovo.Location = new System.Drawing.Point(128, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(21, 18);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // CmbTabelaPreço
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.cmb);
            this.Name = "CmbTabelaPreço";
            this.Size = new System.Drawing.Size(148, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb;
        private System.Windows.Forms.Panel btnNovo;
    }
}
