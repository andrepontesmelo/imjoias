namespace Apresentação.Álbum.Edição.Fotos
{
    partial class SeleçãoOrigemVídeo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstOrigem = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(157, 20);
            this.lblTítulo.Text = "Origem de captura";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Selecione a origem de captura de sua câmera de vídeo.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Álbum.Edição.Properties.Resources.camera1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Origem:";
            // 
            // lstOrigem
            // 
            this.lstOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOrigem.FormattingEnabled = true;
            this.lstOrigem.IntegralHeight = false;
            this.lstOrigem.Location = new System.Drawing.Point(34, 122);
            this.lstOrigem.Name = "lstOrigem";
            this.lstOrigem.Size = new System.Drawing.Size(320, 108);
            this.lstOrigem.TabIndex = 4;
            this.lstOrigem.SelectedIndexChanged += new System.EventHandler(this.lstOrigem_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(305, 244);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // SeleçãoOrigemVídeo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 279);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstOrigem);
            this.Controls.Add(this.btnOK);
            this.Name = "SeleçãoOrigemVídeo";
            this.Text = "Seleção de origem de captura";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.lstOrigem, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstOrigem;
        private System.Windows.Forms.Button btnOK;
    }
}