namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseSaída
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
            this.opçãoAbrirVenda = new Apresentação.Formulários.Opção();
            this.grpDados.SuspendLayout();
            this.quadroDocumento.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Descrição = "Edição de uma saída fiscal";
            this.título.Título = "Editar saída fiscal";
            // 
            // grpDados
            // 
            this.grpDados.Text = "Dados da saída";
            // 
            // quadroDocumento
            // 
            this.quadroDocumento.Controls.Add(this.opçãoAbrirVenda);
            this.quadroDocumento.Size = new System.Drawing.Size(160, 70);
            this.quadroDocumento.Controls.SetChildIndex(this.opçãoAbrirVenda, 0);
            // 
            // quadroPDF
            // 
            this.quadroPDF.Location = new System.Drawing.Point(7, 91);
            // 
            // opçãoAbrirVenda
            // 
            this.opçãoAbrirVenda.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrirVenda.Descrição = "Abrir Venda";
            this.opçãoAbrirVenda.Imagem = global::Apresentação.Resource.folderopen1;
            this.opçãoAbrirVenda.Location = new System.Drawing.Point(7, 50);
            this.opçãoAbrirVenda.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrirVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrirVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrirVenda.Name = "opçãoAbrirVenda";
            this.opçãoAbrirVenda.Size = new System.Drawing.Size(150, 16);
            this.opçãoAbrirVenda.TabIndex = 1;
            this.opçãoAbrirVenda.Click += new System.EventHandler(this.opçãoAbrirVenda_Click);
            // 
            // BaseSaída
            // 
            this.Name = "BaseSaída";
            this.grpDados.ResumeLayout(false);
            this.quadroDocumento.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Opção opçãoAbrirVenda;
    }
}
