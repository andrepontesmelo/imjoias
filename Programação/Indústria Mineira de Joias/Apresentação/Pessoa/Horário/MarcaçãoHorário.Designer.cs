namespace Apresentação.Pessoa.Horário
{
    partial class MarcaçãoHorário
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
            this.controleHorário = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.controleHorário)).BeginInit();
            this.SuspendLayout();
            // 
            // controleHorário
            // 
            this.controleHorário.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.controleHorário.Location = new System.Drawing.Point(3, 35);
            this.controleHorário.Name = "controleHorário";
            this.controleHorário.Size = new System.Drawing.Size(143, 112);
            this.controleHorário.TabIndex = 1;
            this.controleHorário.TabStop = false;
            this.controleHorário.Paint += new System.Windows.Forms.PaintEventHandler(this.controleHorário_Paint);
            // 
            // MarcaçãoHorário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controleHorário);
            this.Name = "MarcaçãoHorário";
            ((System.ComponentModel.ISupportInitialize)(this.controleHorário)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox controleHorário;
    }
}
