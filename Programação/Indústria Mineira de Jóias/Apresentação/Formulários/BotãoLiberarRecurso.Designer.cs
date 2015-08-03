namespace Apresentação.Formulários
{
    partial class BotãoLiberarRecurso
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
            this.btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.AutoSize = true;
            this.btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn.Image = global::Apresentação.Resource.cadeado_aberto__pequeno_;
            this.btn.Location = new System.Drawing.Point(0, 0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(100, 23);
            this.btn.TabIndex = 0;
            this.btn.Text = "Liberar recurso";
            this.btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // BotãoLiberarRecurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btn);
            this.Name = "BotãoLiberarRecurso";
            this.Size = new System.Drawing.Size(100, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
    }
}
