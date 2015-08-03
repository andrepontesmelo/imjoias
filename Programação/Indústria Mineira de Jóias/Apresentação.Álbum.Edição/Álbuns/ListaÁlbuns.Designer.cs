namespace Apresentação.Álbum.Edição.Álbuns
{
    partial class ListaÁlbuns
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
            this.lista = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCriar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.CheckOnClick = true;
            this.lista.FormattingEnabled = true;
            this.lista.IntegralHeight = false;
            this.lista.Location = new System.Drawing.Point(0, 28);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(320, 236);
            this.lista.Sorted = true;
            this.lista.TabIndex = 0;
            this.lista.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lista_ItemCheck);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCriar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(320, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCriar
            // 
            this.btnCriar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCriar.Image = global::Apresentação.Álbum.Edição.Properties.Resources.iconeNovo1;
            this.btnCriar.ImageTransparentColor = System.Drawing.Color.White;
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(23, 22);
            this.btnCriar.Text = "toolStripButton1";
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // ListaÁlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lista);
            this.Name = "ListaÁlbum";
            this.Size = new System.Drawing.Size(320, 264);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lista;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCriar;

    }
}
