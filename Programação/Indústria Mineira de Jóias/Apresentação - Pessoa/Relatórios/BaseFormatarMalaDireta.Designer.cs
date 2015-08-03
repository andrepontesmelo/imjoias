namespace Apresentação.Pessoa.Relatórios
{
    partial class BaseFormatarMalaDireta
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPonteiro = new System.Windows.Forms.ToolStripButton();
            this.btnNome = new System.Windows.Forms.ToolStripButton();
            this.btnLogradouro = new System.Windows.Forms.ToolStripButton();
            this.btnCEP = new System.Windows.Forms.ToolStripButton();
            this.btnCidade = new System.Windows.Forms.ToolStripButton();
            this.painelElementos.SuspendLayout();
            this.quadroElementos.SuspendLayout();
            this.esquerda.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // painelElementos
            // 
            this.painelElementos.Controls.Add(this.toolStrip1);
            this.painelElementos.Size = new System.Drawing.Size(144, 32767);
            // 
            // quadroElementos
            // 
            this.quadroElementos.Size = new System.Drawing.Size(160, 17188);
            this.quadroElementos.Controls.SetChildIndex(this.painelElementos, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPonteiro,
            this.btnNome,
            this.btnLogradouro,
            this.btnCEP,
            this.btnCidade});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(144, 136);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPonteiro
            // 
            this.btnPonteiro.Checked = true;
            this.btnPonteiro.CheckOnClick = true;
            this.btnPonteiro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnPonteiro.Image = global::Apresentação.Pessoa.Properties.Resources.POINT13;
            this.btnPonteiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPonteiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPonteiro.Name = "btnPonteiro";
            this.btnPonteiro.Size = new System.Drawing.Size(142, 20);
            this.btnPonteiro.Text = "Ponteiro";
            this.btnPonteiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPonteiro.Click += new System.EventHandler(this.btnPonteiro_Click);
            // 
            // btnNome
            // 
            this.btnNome.CheckOnClick = true;
            this.btnNome.Image = global::Apresentação.Pessoa.Properties.Resources.MISC27;
            this.btnNome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(142, 20);
            this.btnNome.Text = "Nome";
            this.btnNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNome.Click += new System.EventHandler(this.btnNome_Click);
            // 
            // btnLogradouro
            // 
            this.btnLogradouro.CheckOnClick = true;
            this.btnLogradouro.Image = global::Apresentação.Pessoa.Properties.Resources.placa_de_rua;
            this.btnLogradouro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogradouro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogradouro.Name = "btnLogradouro";
            this.btnLogradouro.Size = new System.Drawing.Size(142, 20);
            this.btnLogradouro.Text = "Endereço";
            this.btnLogradouro.Click += new System.EventHandler(this.btnLogradouro_Click);
            // 
            // btnCEP
            // 
            this.btnCEP.CheckOnClick = true;
            this.btnCEP.Image = global::Apresentação.Pessoa.Properties.Resources.MAIL12;
            this.btnCEP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCEP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCEP.Name = "btnCEP";
            this.btnCEP.Size = new System.Drawing.Size(142, 20);
            this.btnCEP.Text = "CEP";
            this.btnCEP.Click += new System.EventHandler(this.btnCEP_Click);
            // 
            // btnCidade
            // 
            this.btnCidade.CheckOnClick = true;
            this.btnCidade.Image = global::Apresentação.Pessoa.Properties.Resources.Belo_Horizonte;
            this.btnCidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCidade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCidade.Name = "btnCidade";
            this.btnCidade.Size = new System.Drawing.Size(142, 20);
            this.btnCidade.Text = "Cidade, Estado, País";
            this.btnCidade.Click += new System.EventHandler(this.btnCidade_Click);
            // 
            // BaseFormatarMalaDireta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseFormatarMalaDireta";
            this.painelElementos.ResumeLayout(false);
            this.painelElementos.PerformLayout();
            this.quadroElementos.ResumeLayout(false);
            this.quadroElementos.PerformLayout();
            this.esquerda.ResumeLayout(false);
            this.esquerda.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPonteiro;
        private System.Windows.Forms.ToolStripButton btnNome;
        private System.Windows.Forms.ToolStripButton btnLogradouro;
        private System.Windows.Forms.ToolStripButton btnCEP;
        private System.Windows.Forms.ToolStripButton btnCidade;
    }
}
