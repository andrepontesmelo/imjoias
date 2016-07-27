namespace Apresentação.Atendente
{
    partial class BaseInfoAtendimentosCliente
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
            this.quadroLista.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadroLista
            // 
            this.quadroLista.Size = new System.Drawing.Size(160, 51);
            this.quadroLista.Controls.SetChildIndex(this.opçãoRecarregar, 0);
            this.quadroLista.Controls.SetChildIndex(this.opçãoAlterarPeríodo, 0);
            // 
            // opçãoAlterarPeríodo
            // 
            this.opçãoAlterarPeríodo.Location = new System.Drawing.Point(-7, 13);
            this.opçãoAlterarPeríodo.Visible = false;
            // 
            // opçãoRecarregar
            // 
            this.opçãoRecarregar.Location = new System.Drawing.Point(7, 30);
            // 
            // BaseInfoAtendimentosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "BaseInfoAtendimentosCliente";
            this.quadroLista.ResumeLayout(false);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
