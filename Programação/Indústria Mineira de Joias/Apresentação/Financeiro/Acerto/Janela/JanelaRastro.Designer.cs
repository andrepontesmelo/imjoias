namespace Apresentação.Financeiro.Acerto
{
    partial class JanelaRastro
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExibir = new System.Windows.Forms.Button();
            this.lstRastro = new Apresentação.Financeiro.Acerto.LstRastro();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(125, 20);
            this.lblTítulo.Text = "10100101-101";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(370, 48);
            this.lblDescrição.Text = "Atribuído em runtime";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.lupa_papéis;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(371, 332);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Fechar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExibir
            // 
            this.btnExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibir.Enabled = false;
            this.btnExibir.Location = new System.Drawing.Point(290, 332);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(75, 23);
            this.btnExibir.TabIndex = 5;
            this.btnExibir.Text = "&Exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // lstRastro
            // 
            this.lstRastro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRastro.Location = new System.Drawing.Point(12, 96);
            this.lstRastro.Name = "lstRastro";
            this.lstRastro.Size = new System.Drawing.Size(434, 230);
            this.lstRastro.TabIndex = 3;
            this.lstRastro.ItemSelecionado += new System.EventHandler(this.lstRastro_ItemSelecionado);
            this.lstRastro.ItemDeselecionado += new System.EventHandler(this.lstRastro_ItemDeselecionado);
            this.lstRastro.DuploClique += new System.EventHandler(this.lstRastro_DuploClique);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(209, 332);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "E&ditar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // JanelaRastro
            // 
            this.ClientSize = new System.Drawing.Size(458, 363);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExibir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lstRastro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.Name = "JanelaRastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerto";
            this.Controls.SetChildIndex(this.lstRastro, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExibir, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LstRastro lstRastro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnEditar;
    }
}
