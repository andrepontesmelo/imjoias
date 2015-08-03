namespace Apresentação.IntegraçãoSistemaAntigo.Cadcli
{
    partial class BaseCadCli
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
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(368, 59);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(100, 20);
            this.txtArquivo.TabIndex = 6;
            this.txtArquivo.Text = "c:\\";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BaseCadCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtArquivo);
            this.Name = "BaseCadCli";
            this.Controls.SetChildIndex(this.txtArquivo, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button button1;
    }
}
