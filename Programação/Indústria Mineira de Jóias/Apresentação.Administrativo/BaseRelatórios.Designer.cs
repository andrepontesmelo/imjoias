namespace Apresentação.Administrativo
{
    partial class BaseRelatórios
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.quadroOpçãoBalanço = new Apresentação.Formulários.QuadroOpção();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Escolha o relatório que deseja visualizar.";
            this.títuloBaseInferior.Imagem = global::Apresentação.Administrativo.Properties.Resources.gravata;
            this.títuloBaseInferior.Location = new System.Drawing.Point(207, 12);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(569, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Administrativo";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.quadroOpçãoBalanço);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(207, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(590, 160);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // quadroOpçãoBalanço
            // 
            this.quadroOpçãoBalanço.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroOpçãoBalanço.Descrição = "Exibe relatório com o resumo de mercadorias de consignado.";
            this.quadroOpçãoBalanço.Ícone = global::Apresentação.Administrativo.Properties.Resources.balança_pequena;
            this.quadroOpçãoBalanço.Location = new System.Drawing.Point(3, 3);
            this.quadroOpçãoBalanço.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroOpçãoBalanço.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroOpçãoBalanço.Name = "quadroOpçãoBalanço";
            this.quadroOpçãoBalanço.Size = new System.Drawing.Size(295, 70);
            this.quadroOpçãoBalanço.TabIndex = 0;
            this.quadroOpçãoBalanço.Título = "Balanço";
            this.quadroOpçãoBalanço.Click += new System.EventHandler(this.quadroOpçãoBalanço_Click);
            // 
            // BaseRelatórios
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.títuloBaseInferior);
            this.Imagem = global::Apresentação.Administrativo.Properties.Resources.gravata;
            this.Name = "BaseRelatórios";
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Apresentação.Formulários.QuadroOpção quadroOpçãoBalanço;
    }
}
