namespace Apresentação.Pessoa.Cadastro
{
    partial class CadastroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroCliente));
            this.tabCliente = new System.Windows.Forms.TabPage();
            this.cliente = new Apresentação.Pessoa.Cadastro.DadosCliente();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabCliente);
            this.tab.Size = new System.Drawing.Size(408, 442);
            this.tab.Controls.SetChildIndex(this.tabCliente, 0);
            // 
            // ícones
            // 
            this.ícones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ícones.ImageStream")));
            this.ícones.Images.SetKeyName(0, "Dados pessoais");
            this.ícones.Images.SetKeyName(1, "Endereço");
            this.ícones.Images.SetKeyName(2, "Observações");
            this.ícones.Images.SetKeyName(3, "Grupos");
            this.ícones.Images.SetKeyName(4, "Telefone");
            this.ícones.Images.SetKeyName(5, "Calendário");
            this.ícones.Images.SetKeyName(6, "cliente");
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(260, 456);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(341, 456);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(8, 456);
            // 
            // tabCliente
            // 
            this.tabCliente.Controls.Add(this.cliente);
            this.tabCliente.ImageKey = "cliente";
            this.tabCliente.Location = new System.Drawing.Point(4, 42);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.Size = new System.Drawing.Size(400, 435);
            this.tabCliente.TabIndex = 4;
            this.tabCliente.Text = "Informações sobre cliente";
            this.tabCliente.UseVisualStyleBackColor = true;
            // 
            // cliente
            // 
            this.cliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cliente.Location = new System.Drawing.Point(0, 0);
            this.cliente.Name = "cliente";
            this.cliente.Padding = new System.Windows.Forms.Padding(3);
            this.cliente.Size = new System.Drawing.Size(400, 435);
            this.cliente.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(89, 456);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // CadastroCliente
            // 
            this.ClientSize = new System.Drawing.Size(426, 488);
            this.Controls.Add(this.btnImprimir);
            this.Name = "CadastroCliente";
            this.Load += new System.EventHandler(this.CadastroCliente_Load);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.tab.ResumeLayout(false);
            this.tabCliente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCliente;
        private DadosCliente cliente;
        private System.Windows.Forms.Button btnImprimir;
    }
}
