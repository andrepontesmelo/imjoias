namespace Apresenta��o.Mercadoria.Manuten��o.ComponentesDeCusto
{
    partial class ListaComponentesMercadoria
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
            this.SuspendLayout();
            // 
            // colC�digo
            // 
            this.colC�digo.Width = 38;
            // 
            // ListaComponentesMercadoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ListaComponentesMercadoria";
            this.ClicouAlterar += new System.EventHandler(this.ListaComponentesMercadoria_ClicouAlterar);
            this.ClicouExcluir += new System.EventHandler(this.ListaComponentesMercadoria_ClicouExcluir);
            this.ClicouAdicionar += new System.EventHandler(this.ListaComponentesMercadoria_ClicouAdicionar);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
