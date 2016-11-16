namespace Apresentação.Mercadoria.Janela
{
    partial class JanelaPesquisaReferência
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
            this.lista = new System.Windows.Forms.ListView();
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.localizador = new Apresentação.Formulários.Localizador();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(193, 20);
            this.lblTítulo.Text = "Pesquisa de referência";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(720, 48);
            this.lblDescrição.Text = "Pesquisa uma mercadoria por referência";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.search;
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colDescrição});
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(2, 122);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(806, 199);
            this.lista.TabIndex = 3;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 204;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 558;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(719, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(638, 327);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // localizador
            // 
            this.localizador.BotãoPesquisar = null;
            this.localizador.Location = new System.Drawing.Point(-25, 93);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(819, 30);
            this.localizador.TabIndex = 8;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            this.localizador.EncontrarItemÚnico += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItemÚnico);
            // 
            // JanelaPesquisaReferência
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 362);
            this.Controls.Add(this.localizador);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lista);
            this.MaximizeBox = true;
            this.Name = "JanelaPesquisaReferência";
            this.Text = "Pesquisa de referência";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.lista, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.localizador, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private Formulários.Localizador localizador;
    }
}