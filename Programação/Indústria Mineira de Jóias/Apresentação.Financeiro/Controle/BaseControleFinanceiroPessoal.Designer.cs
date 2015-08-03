namespace Apresentação.Financeiro.Controle
{
    partial class BaseControleFinanceiroPessoal
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
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.lista = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Aqui deverá ser fácil visualizar os debitos e creditos do cliente e ver quanto el" +
                "e efetivamente deve. Sugestoes sao bem vindas";
            this.título.Imagem = null;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(515, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Esboço do controle financeiro";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista.FormattingEnabled = true;
            this.lista.ItemHeight = 15;
            this.lista.Location = new System.Drawing.Point(209, 90);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(398, 154);
            this.lista.TabIndex = 7;
            // 
            // BaseControleFinanceiroPessoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.título);
            this.Controls.Add(this.lista);
            this.Name = "BaseControleFinanceiroPessoal";
            this.Load += new System.EventHandler(this.BaseControleFinanceiroPessoal_Load);
            this.Controls.SetChildIndex(this.lista, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior título;
        private System.Windows.Forms.ListBox lista;
    }
}
