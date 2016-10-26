namespace Apresentação.Formulários
{
    partial class TextBoxPesquisável
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
            this.txt = new System.Windows.Forms.TextBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(341, 20);
            this.txt.TabIndex = 1;
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            this.txt.Resize += new System.EventHandler(this.txt_Resize);
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcurar.BackgroundImage = global::Apresentação.Resource.search;
            this.btnProcurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcurar.Location = new System.Drawing.Point(340, 0);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(20, 20);
            this.btnProcurar.TabIndex = 0;
            this.btnProcurar.TabStop = false;
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.VisibleChanged += new System.EventHandler(this.AoMudarVisibilidadeProcura);
            this.btnProcurar.Click += new System.EventHandler(this.AoClicarBtnProcurar);
            // 
            // TextBoxPesquisável
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.txt);
            this.Name = "TextBoxPesquisável";
            this.Size = new System.Drawing.Size(360, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.TextBox txt;
    }
}
