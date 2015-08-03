namespace Apresentação.Estoque.Entrada
{
    partial class BaseEditarEntrada
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
            this.tabs.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroTravamento.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Imagem = global::Apresentação.Resource.VariaçãoPositiva;
            this.título.Título = "Relacionar entrada nr. ";
            // 
            // tabs
            // 
            this.tabs.Location = new System.Drawing.Point(193, 76);
            this.tabs.Size = new System.Drawing.Size(590, 400);
            // 
            // tabItens
            // 
            this.tabItens.Size = new System.Drawing.Size(582, 374);
            this.quadroTravamento.Controls.SetChildIndex(this.lblTravamento, 0);
            this.quadroTravamento.Controls.SetChildIndex(this.opçãoDestravar, 0);
            // 
            // digitação
            // 
            this.digitação.Size = new System.Drawing.Size(576, 368);
            // 
            // tabObservações
            // 
            this.tabObservações.Size = new System.Drawing.Size(596, 374);
            // 
            // txtObservação
            // 
            this.txtObservação.Size = new System.Drawing.Size(590, 368);
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 476);
            // 
            // BaseEditarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseEditarEntrada";
            this.Size = new System.Drawing.Size(800, 476);
            this.tabs.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroTravamento.ResumeLayout(false);
            this.tabObservações.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
