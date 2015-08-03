namespace Apresentação.Álbum.Fotos
{
    partial class ListaFotos
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
            try
            {
                if (bgCarregarTudo.IsBusy)
                    bgCarregarTudo.CancelAsync();

                if (bgRecuperação.IsBusy)
                    bgRecuperação.CancelAsync();

                bgCarregarTudo.Dispose();
                bgRecuperação.Dispose();
            }
            catch { }

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
            this.lst = new System.Windows.Forms.ListView();
            this.imagens = new System.Windows.Forms.ImageList(this.components);
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.progresso = new System.Windows.Forms.ProgressBar();
            this.bgCarregarTudo = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.verSemelhantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout(); 
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.LargeImageList = this.imagens;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(150, 150);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.VirtualMode = true;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lst_MouseMove);
            this.lst.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lst_RetrieveVirtualItem);
            this.lst.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.lst_CacheVirtualItems);
            this.lst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            this.lst.ContextMenuStrip = this.contextMenuStrip;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.toolStripSeparator1,
            this.verSemelhantesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(225, 76);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::Apresentação.Álbum.Properties.Resources.camera;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::Apresentação.Álbum.Properties.Resources.camera;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.editarToolStripMenuItem.Text = "Editar fotografia...";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // verSemelhantesToolStripMenuItem
            // 
            this.verSemelhantesToolStripMenuItem.Name = "verSemelhantesToolStripMenuItem";
            this.verSemelhantesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.verSemelhantesToolStripMenuItem.Text = "Ver/Exportar mercadoria(s)...";
            this.verSemelhantesToolStripMenuItem.Click += new System.EventHandler(this.verSemelhantesToolStripMenuItem_Click);
            // 
            // imagens
            // 
            this.imagens.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagens.ImageSize = new System.Drawing.Size(133, 100);
            this.imagens.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.WorkerReportsProgress = true;
            this.bgRecuperação.WorkerSupportsCancellation = true;
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRecuperação_RunWorkerCompleted);
            // 
            // progresso
            // 
            this.progresso.Location = new System.Drawing.Point(22, 134);
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(107, 13);
            this.progresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progresso.TabIndex = 1;
            this.progresso.Visible = false;
            // 
            // bgCarregarTudo
            // 
            this.bgCarregarTudo.WorkerSupportsCancellation = true;
            this.bgCarregarTudo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CarregarTudo);
            this.bgCarregarTudo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AoCarregarTudo);
            // 
            // ListaFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progresso);
            this.Controls.Add(this.lst);
            this.Name = "ListaFotos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imagens;
        private System.ComponentModel.BackgroundWorker bgRecuperação;
        private System.Windows.Forms.ProgressBar progresso;
        protected System.Windows.Forms.ListView lst;
        private System.ComponentModel.BackgroundWorker bgCarregarTudo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verSemelhantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
