namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    partial class ListaComponentesCusto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lst = new System.Windows.Forms.ListView();
            this.colCódigo = new System.Windows.Forms.ColumnHeader();
            this.colNome = new System.Windows.Forms.ColumnHeader();
            this.colRelativo = new System.Windows.Forms.ColumnHeader();
            this.colValor = new System.Windows.Forms.ColumnHeader();
            this.colValorAbsoluto = new System.Windows.Forms.ColumnHeader();
            this.localizador = new Apresentação.Formulários.Localizador();
            this.btnLocalizar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lst);
            this.panel1.Controls.Add(this.localizador);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 319);
            this.panel1.TabIndex = 1;
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigo,
            this.colNome,
            this.colRelativo,
            this.colValor,
            this.colValorAbsoluto});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.HideSelection = false;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(445, 289);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            this.colCódigo.Width = 64;
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            // 
            // colRelativo
            // 
            this.colRelativo.Text = "Relativo ao";
            this.colRelativo.Width = 94;
            // 
            // colValor
            // 
            this.colValor.Text = "Valor Relativo";
            this.colValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValor.Width = 94;
            // 
            // colValorAbsoluto
            // 
            this.colValorAbsoluto.Text = "Valor Absoluto";
            this.colValorAbsoluto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValorAbsoluto.Width = 106;
            // 
            // localizador
            // 
            this.localizador.BotãoPesquisar = this.btnLocalizar;
            this.localizador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.localizador.Location = new System.Drawing.Point(0, 289);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(445, 30);
            this.localizador.TabIndex = 1;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLocalizar.Image = global::Apresentação.Resource.Lupa;
            this.btnLocalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(23, 22);
            this.btnLocalizar.Text = "Localizar";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLocalizar,
            this.btnAdicionar,
            this.btnAlterar,
            this.btnExcluir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(448, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "Localizar";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionar.Image = global::Apresentação.Resource.iconeNovo;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(23, 22);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = global::Apresentação.Resource.EditTableHS;
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(23, 22);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = global::Apresentação.Resource.Excluir;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(23, 22);
            this.btnExcluir.Text = "Exluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "Lista";
            this.Size = new System.Drawing.Size(448, 347);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Apresentação.Formulários.Localizador localizador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnLocalizar;
        protected System.Windows.Forms.ListView lst;
        protected System.Windows.Forms.ColumnHeader colCódigo;
        protected System.Windows.Forms.ColumnHeader colValor;
        protected System.Windows.Forms.ColumnHeader colRelativo;
        protected System.Windows.Forms.ColumnHeader colValorAbsoluto;
        protected System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ToolStripButton btnAlterar;
    }
}
