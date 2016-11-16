namespace Apresentação.Financeiro.Acerto
{
    partial class JanelaImpressão : Apresentação.Formulários.JanelaImpressão
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
            this.optResumido = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(302, 20);
            this.lblTítulo.Text = "Impressão do acerto de mercadorias";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(633, 48);
            this.lblDescrição.Text = "É o resumo demercadorias relacionadas para <Pessoa>";
            // 
            // optResumido
            // 
            this.optResumido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optResumido.AutoSize = true;
            this.optResumido.Location = new System.Drawing.Point(12, 339);
            this.optResumido.Name = "optResumido";
            this.optResumido.Size = new System.Drawing.Size(181, 17);
            this.optResumido.TabIndex = 5;
            this.optResumido.Text = "Imprimir apenas itens para acerto";
            this.optResumido.UseVisualStyleBackColor = true;
            this.optResumido.CheckedChanged += new System.EventHandler(this.optResumido_CheckedChanged);
            // 
            // JanelaImpressão
            // 
            this.ClientSize = new System.Drawing.Size(721, 368);
            this.Controls.Add(this.optResumido);
            this.Name = "JanelaImpressão";
            this.Controls.SetChildIndex(this.optResumido, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox optResumido;
    }
}
