namespace Apresentação.Álbum.Edição.Impressão
{
    partial class VisualizarPáginaVirtual
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
            this.páginaVirtual = new Apresentação.Álbum.Edição.Álbuns.PáginaVirtual();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(222, 20);
            this.lblTítulo.Text = "Visualização de impressão";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(400, 48);
            this.lblDescrição.Text = "Visualização aproximada da impressão do álbum.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Impressora_3D;
            // 
            // páginaVirtual
            // 
            this.páginaVirtual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.páginaVirtual.BackColor = System.Drawing.Color.White;
            this.páginaVirtual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.páginaVirtual.Fotos = new Entidades.Álbum.Foto[0];
            this.páginaVirtual.Location = new System.Drawing.Point(21, 107);
            this.páginaVirtual.Name = "páginaVirtual";
            this.páginaVirtual.Size = new System.Drawing.Size(445, 260);
            this.páginaVirtual.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(320, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(401, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // VisualizarPáginaVirtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 420);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.páginaVirtual);
            this.Name = "VisualizarPáginaVirtual";
            this.Text = "Visualização de impressão";
            this.Controls.SetChildIndex(this.páginaVirtual, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Álbum.Edição.Álbuns.PáginaVirtual páginaVirtual;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}