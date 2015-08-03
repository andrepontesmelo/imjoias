namespace Apresentação.Pessoa.Endereço
{
    partial class ComboBoxRegião
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
            this.btnAdicionarRegião = new System.Windows.Forms.Button();
            this.cmbRegião = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAdicionarRegião
            // 
            this.btnAdicionarRegião.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarRegião.Location = new System.Drawing.Point(238, -1);
            this.btnAdicionarRegião.Name = "btnAdicionarRegião";
            this.btnAdicionarRegião.Size = new System.Drawing.Size(20, 22);
            this.btnAdicionarRegião.TabIndex = 21;
            this.btnAdicionarRegião.Text = "+";
            this.btnAdicionarRegião.UseVisualStyleBackColor = true;
            this.btnAdicionarRegião.Click += new System.EventHandler(this.btnAdicionarRegião_Click);
            // 
            // cmbRegião
            // 
            this.cmbRegião.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRegião.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegião.FormattingEnabled = true;
            this.cmbRegião.Location = new System.Drawing.Point(0, 0);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Size = new System.Drawing.Size(232, 21);
            this.cmbRegião.TabIndex = 20;
            // 
            // ComboBoxRegião
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdicionarRegião);
            this.Controls.Add(this.cmbRegião);
            this.Name = "ComboBoxRegião";
            this.Size = new System.Drawing.Size(257, 21);
            this.Load += new System.EventHandler(this.ComboBoxRegião_Load);
            this.Resize += new System.EventHandler(this.ComboBoxRegião_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionarRegião;
        private System.Windows.Forms.ComboBox cmbRegião;
    }
}
