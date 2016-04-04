namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class JanelaImpressão
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaImpressão));
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.lstDocumentos = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(172, 20);
            this.lblTítulo.Text = "Impressão de recibo";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(241, 48);
            this.lblDescrição.Text = "Os seguintes documentos foram selecionados. Deseja adicionar mais algum ?";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Sim, desejo retornar para selecionar mais recibos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::Apresentação.Resource.Impressora_3D;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(169, 150);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(154, 48);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir documentos selecionados";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemover);
            this.groupBox1.Controls.Add(this.lstDocumentos);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recibos para impressão";
            // 
            // btnRemover
            // 
            this.btnRemover.Image = global::Apresentação.Resource.delete;
            this.btnRemover.Location = new System.Drawing.Point(120, 19);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(25, 20);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // lstDocumentos
            // 
            this.lstDocumentos.FormattingEnabled = true;
            this.lstDocumentos.Location = new System.Drawing.Point(6, 19);
            this.lstDocumentos.Name = "lstDocumentos";
            this.lstDocumentos.Size = new System.Drawing.Size(108, 69);
            this.lstDocumentos.TabIndex = 0;
            // 
            // JanelaImpressão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 205);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimir);
            this.Name = "JanelaImpressão";
            this.Text = "Impressão de recibo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JanelaImpressão_FormClosing);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstDocumentos;
        private System.Windows.Forms.Button btnRemover;
    }
}