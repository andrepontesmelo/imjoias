namespace Apresentação.Álbum.Edição.Fotos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaFotos));
            this.lst = new System.Windows.Forms.ListView();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagens = new System.Windows.Forms.ImageList(this.components);
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            //this.progresso = new System.Windows.Forms.ProgressBar();
            this.bgCarregarTudo = new System.ComponentModel.BackgroundWorker();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.ContextMenuStrip = this.menu;
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.LargeImageList = this.imagens;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(150, 150);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.VirtualMode = true;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lst_RetrieveVirtualItem);
            this.lst.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.lst_CacheVirtualItems);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarToolStripMenuItem,
            this.editarToolStripMenuItem1,
            this.excluirToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(202, 70);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualizarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visualizarToolStripMenuItem.Image")));
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.visualizarToolStripMenuItem.Text = "Consultar mercadoria...";
            this.visualizarToolStripMenuItem.Click += new System.EventHandler(this.visualizarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Image = global::Apresentação.Resource.propriedades;
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.editarToolStripMenuItem1.Text = "Editar fotografia...";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem1_Click);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Image = global::Apresentação.Resource.Excluir;
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
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
            //// 
            //// progresso
            //// 
            //this.progresso.Location = new System.Drawing.Point(22, 134);
            //this.progresso.Name = "progresso";
            //this.progresso.Size = new System.Drawing.Size(107, 13);
            //this.progresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            //this.progresso.TabIndex = 1;
            //this.progresso.Visible = false;
            // 
            // bgCarregarTudo
            // 
            this.bgCarregarTudo.WorkerSupportsCancellation = true;
            this.bgCarregarTudo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CarregarTudo);
            this.bgCarregarTudo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AoCarregarTudo);
            // 
            // ListaFotos
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Controls.Add(this.progresso);
            this.Controls.Add(this.lst);
            this.Name = "ListaFotos";
            this.Load += new System.EventHandler(this.ListaFotos_Load);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imagens;
        private System.ComponentModel.BackgroundWorker bgRecuperação;
        //private System.Windows.Forms.ProgressBar progresso;
        protected System.Windows.Forms.ListView lst;
        private System.ComponentModel.BackgroundWorker bgCarregarTudo;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
    }
}
