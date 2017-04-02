namespace Apresentação.Álbum.Edição.Álbuns
{
    partial class ListViewEdiçãoFotos
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCapturar = new System.Windows.Forms.ToolStripButton();
            this.btnRemover = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnConsultarMercadoria = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AllowDrop = true;
            this.lst.ContextMenuStrip = this.contextMenuStrip;
            this.lst.Location = new System.Drawing.Point(0, 25);
            this.lst.Size = new System.Drawing.Size(354, 125);
            this.lst.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.lst.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCapturar,
            this.btnRemover,
            this.toolStripSeparator1,
            this.btnEditar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(354, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "Barra de ferramentas";
            // 
            // btnCapturar
            // 
            this.btnCapturar.Image = global::Apresentação.Resource.camera;
            this.btnCapturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(136, 22);
            this.btnCapturar.Text = "Importar foto...";
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Image = global::Apresentação.Resource.Excluir;
            this.btnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(74, 22);
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = global::Apresentação.Resource.propriedades;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(57, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.ToolTipText = "Editar a foto selecionada";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConsultarMercadoria,
            this.editarToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(193, 70);
            // 
            // btnConsultarMercadoria
            // 
            this.btnConsultarMercadoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarMercadoria.Image = global::Apresentação.Resource.Etiqueta;
            this.btnConsultarMercadoria.Name = "btnConsultarMercadoria";
            this.btnConsultarMercadoria.Size = new System.Drawing.Size(192, 22);
            this.btnConsultarMercadoria.Text = "Consultar mercadoria";
            this.btnConsultarMercadoria.Click += new System.EventHandler(this.btnConsultarFotografia_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::Apresentação.Resource.propriedades;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editarToolStripMenuItem.Text = "Editar fotografia...";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::Apresentação.Resource.Excluir;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removerToolStripMenuItem.Text = "Excluir";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // ListViewEdiçãoFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.toolStrip);
            this.Name = "ListViewEdiçãoFotos";
            this.Size = new System.Drawing.Size(354, 150);
            this.AoSelecionar += new Apresentação.Álbum.Edição.Fotos.ListaFotos.FotoHandle(this.ListViewEdiçãoFotos_AoSelecionar);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.lst, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnRemover;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnCapturar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnConsultarMercadoria;
    }
}
