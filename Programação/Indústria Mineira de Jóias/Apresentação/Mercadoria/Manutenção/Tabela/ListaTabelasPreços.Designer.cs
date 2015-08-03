namespace Apresentação.Mercadoria.Manutenção.Tabela
{
    partial class ListaTabelasPreços
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Varejo", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Varejo Vermelha", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaTabelasPreços));
            this.lista = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnFaixas = new System.Windows.Forms.ToolStripButton();
            this.btnGrupo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lista.LargeImageList = this.imageList;
            this.lista.Location = new System.Drawing.Point(0, 28);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(303, 122);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "appwindow_database_16.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnFaixas,
            this.btnGrupo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(303, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(71, 22);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnFaixas
            // 
            this.btnFaixas.Image = ((System.Drawing.Image)(resources.GetObject("btnFaixas.Image")));
            this.btnFaixas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFaixas.Name = "btnFaixas";
            this.btnFaixas.Size = new System.Drawing.Size(89, 22);
            this.btnFaixas.Text = "Editar Faixas";
            // 
            // btnGrupo
            // 
            this.btnGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnGrupo.Image")));
            this.btnGrupo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(92, 22);
            this.btnGrupo.Text = "Editar Grupos";
            // 
            // ListaTabelasPreços
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lista);
            this.Name = "ListaTabelasPreços";
            this.Size = new System.Drawing.Size(303, 150);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnFaixas;
        private System.Windows.Forms.ToolStripButton btnGrupo;
    }
}
