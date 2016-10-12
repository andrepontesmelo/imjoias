namespace Apresentação.Fiscal
{
    partial class BaseEntradas
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
            this.lista = new Apresentação.Fiscal.ListaDocumentoEntrada();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Descrição = "Notas fiscais de entrada de itens de inventário, podem ser importados ou editados" +
    ", e marcados como cancelados.";
            this.títuloBaseInferior1.Título = "Entradas";
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.Descrição = "Nova entrada";
            // 
            // quadroTipo
            // 
            this.quadroTipo.SeleçãoAlterada += new System.EventHandler(this.quadroTipo_SeleçãoAlterada);
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(193, 79);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(592, 204);
            this.lista.TabIndex = 7;
            // 
            // BaseEntradas
            // 
            this.Controls.Add(this.lista);
            this.Name = "BaseEntradas";
            this.Controls.SetChildIndex(this.lista, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListaDocumentoEntrada lista;
    }
}
