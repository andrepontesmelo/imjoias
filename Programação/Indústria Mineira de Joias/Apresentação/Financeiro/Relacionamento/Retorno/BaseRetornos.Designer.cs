namespace Apresentação.Financeiro.Retorno
{
    partial class BaseRetornos
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
            this.lista = new Apresentação.Financeiro.Retorno.ListaRetornos();
            this.quadroRelacionamentos.SuspendLayout();
            this.quadro.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Descrição = "São listados os documentos que registram as mercadorias em consignação que retorn" +
                "aram para a empresa.";
            this.título.Imagem = global::Apresentação.Resource.retorno;
            this.título.Título = "Consignado de retorno";
            // 
            // quadroRelacionamentos
            // 
            this.quadroRelacionamentos.Título = "Novo retorno";
            this.quadroRelacionamentos.Controls.SetChildIndex(this.opçãoNovoRelacionamento, 0);
            // 
            // quadro
            // 
            this.quadro.Controls.Add(this.lista);
            this.quadro.Título = "Documentos de retorno";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(0, 26);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(604, 264);
            this.lista.TabIndex = 8;
            // 
            // BaseRetornos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseRetornos";
            this.quadroRelacionamentos.ResumeLayout(false);
            this.quadro.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListaRetornos lista;
    }
}
