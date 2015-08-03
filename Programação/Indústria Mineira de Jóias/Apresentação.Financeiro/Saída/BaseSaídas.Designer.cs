namespace Apresentação.Financeiro.Saída
{
    partial class BaseSaídas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ListaSaídas listaSaídas;

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
            this.listaSaídas = new Apresentação.Financeiro.Saída.ListaSaídas();
            this.quadroRelacionamentos.SuspendLayout();
            this.quadro.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Descrição = "São listados os documentos que registram as mercadorias que sairam da empresa, po" +
                "is foram deixadas em consignação para <p>";
            this.título.Imagem = global::Apresentação.Financeiro.Properties.Resources.saída;
            this.título.Título = "Relação de consignado de saída";
            // 
            // quadroRelacionamentos
            // 
            this.quadroRelacionamentos.Título = "Documentos";
            this.quadroRelacionamentos.Controls.SetChildIndex(this.opçãoNovoRelacionamento, 0);
            // 
            // quadro
            // 
            this.quadro.Controls.Add(this.listaSaídas);
            this.quadro.Título = "Documentos de saída";
            // 
            // listaSaídas
            // 
            this.listaSaídas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSaídas.Location = new System.Drawing.Point(0, 24);
            this.listaSaídas.Name = "listaSaídas";
            this.listaSaídas.Size = new System.Drawing.Size(604, 263);
            this.listaSaídas.TabIndex = 8;
            // 
            // BaseSaídas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseSaídas";
            this.quadroRelacionamentos.ResumeLayout(false);
            this.quadro.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
