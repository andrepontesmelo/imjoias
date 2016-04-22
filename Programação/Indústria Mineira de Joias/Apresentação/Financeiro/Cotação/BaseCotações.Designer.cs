namespace Apresentação.Financeiro.Cotação
{
    partial class BaseCotações
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.quadroMoeda = new Apresentação.Formulários.Quadro();
            this.opçãoEditar = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroMoeda.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroMoeda);
            this.esquerda.Controls.SetChildIndex(this.quadroMoeda, 0);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.Location = new System.Drawing.Point(192, 11);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(526, 268);
            this.flowLayoutPanel.TabIndex = 6;
            // 
            // quadroMoeda
            // 
            this.quadroMoeda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroMoeda.bInfDirArredondada = true;
            this.quadroMoeda.bInfEsqArredondada = true;
            this.quadroMoeda.bSupDirArredondada = true;
            this.quadroMoeda.bSupEsqArredondada = true;
            this.quadroMoeda.Controls.Add(this.opçãoEditar);
            this.quadroMoeda.Cor = System.Drawing.Color.Black;
            this.quadroMoeda.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMoeda.LetraTítulo = System.Drawing.Color.White;
            this.quadroMoeda.Location = new System.Drawing.Point(7, 13);
            this.quadroMoeda.MostrarBotãoMinMax = false;
            this.quadroMoeda.Name = "quadroMoeda";
            this.quadroMoeda.Size = new System.Drawing.Size(160, 56);
            this.quadroMoeda.TabIndex = 1;
            this.quadroMoeda.Tamanho = 30;
            this.quadroMoeda.Título = "Moeda";
            // 
            // opçãoEditar
            // 
            this.opçãoEditar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEditar.Descrição = "Iniciar manutenção...";
            this.opçãoEditar.Imagem = global::Apresentação.Resource.propriedades;
            this.opçãoEditar.Location = new System.Drawing.Point(7, 30);
            this.opçãoEditar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEditar.Name = "opçãoEditar";
            this.opçãoEditar.Privilégio = Entidades.Privilégio.Permissão.EditarCotação;
            this.opçãoEditar.Size = new System.Drawing.Size(150, 24);
            this.opçãoEditar.TabIndex = 3;
            this.opçãoEditar.Click += new System.EventHandler(this.opçãoEditar_Click);
            // 
            // BaseCotações
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Imagem = global::Apresentação.Resource.Cotação;
            this.Name = "BaseCotações";
            this.Size = new System.Drawing.Size(729, 296);
            this.Controls.SetChildIndex(this.flowLayoutPanel, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroMoeda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private Apresentação.Formulários.Quadro quadroMoeda;
        private Apresentação.Formulários.Opção opçãoEditar;
    }
}
