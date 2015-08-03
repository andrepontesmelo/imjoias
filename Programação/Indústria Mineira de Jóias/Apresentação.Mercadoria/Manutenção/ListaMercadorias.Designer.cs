namespace Apresentação.Mercadoria.Manutenção
{
    partial class ListaMercadorias
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("De Linha", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("De Peso", System.Windows.Forms.HorizontalAlignment.Left);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLocalizar = new System.Windows.Forms.ToolStripButton();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lista = new System.Windows.Forms.ListView();
            this.colReferência = new System.Windows.Forms.ColumnHeader();
            this.colPeso = new System.Windows.Forms.ColumnHeader();
            this.colDescrição = new System.Windows.Forms.ColumnHeader();
            this.colFaixa = new System.Windows.Forms.ColumnHeader();
            this.colGrupo = new System.Windows.Forms.ColumnHeader();
            this.colTeor = new System.Windows.Forms.ColumnHeader();
            this.colForaDeLinha = new System.Windows.Forms.ColumnHeader();
            this.localizador = new Apresentação.Formulários.Localizador();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(413, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Image = global::Apresentação.Mercadoria.Properties.Resources.Lupa;
            this.btnLocalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(73, 22);
            this.btnLocalizar.Text = "Localizar";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Apresentação.Mercadoria.Properties.Resources.iconeNovo;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(78, 22);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = global::Apresentação.Mercadoria.Properties.Resources.EditTableHS;
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(62, 22);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = global::Apresentação.Mercadoria.Properties.Resources.Excluir;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(61, 22);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lista);
            this.panel1.Controls.Add(this.localizador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 227);
            this.panel1.TabIndex = 1;
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colPeso,
            this.colDescrição,
            this.colFaixa,
            this.colGrupo,
            this.colTeor,
            this.colForaDeLinha});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            listViewGroup1.Header = "De Linha";
            listViewGroup1.Name = "grupoLinha";
            listViewGroup2.Header = "De Peso";
            listViewGroup2.Name = "grupoPeso";
            this.lista.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lista.HideSelection = false;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(413, 197);
            this.lista.TabIndex = 6;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 87;
            // 
            // colPeso
            // 
            this.colPeso.Text = "Peso";
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 83;
            // 
            // colFaixa
            // 
            this.colFaixa.Text = "Faixa";
            // 
            // colGrupo
            // 
            this.colGrupo.Text = "Grupo";
            // 
            // colTeor
            // 
            this.colTeor.Text = "Teor";
            // 
            // colForaDeLinha
            // 
            this.colForaDeLinha.Text = "Excluida";
            this.colForaDeLinha.Width = 92;
            // 
            // localizador
            // 
            this.localizador.BotãoPesquisar = this.btnLocalizar;
            this.localizador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.localizador.Location = new System.Drawing.Point(0, 197);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(413, 30);
            this.localizador.TabIndex = 5;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            // 
            // ListaMercadorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ListaMercadorias";
            this.Size = new System.Drawing.Size(413, 252);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLocalizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colPeso;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colFaixa;
        private System.Windows.Forms.ColumnHeader colGrupo;
        private System.Windows.Forms.ColumnHeader colTeor;
        private System.Windows.Forms.ColumnHeader colForaDeLinha;
        private Apresentação.Formulários.Localizador localizador;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
    }
}
