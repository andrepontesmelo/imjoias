namespace Apresentação.Álbum
{
    partial class ListViewÁlbuns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewÁlbuns));
            this.lst = new System.Windows.Forms.ListView();
            this.colÁlbum = new System.Windows.Forms.ColumnHeader();
            this.colDescrição = new System.Windows.Forms.ColumnHeader();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colÁlbum,
            this.colDescrição,
            this.colData});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.LargeImageList = this.imageList1;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(393, 150);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.Resize += new System.EventHandler(this.AoRedimensionar);
            this.lst.SelectedIndexChanged += new System.EventHandler(this.AoSelecionar);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // colÁlbum
            // 
            this.colÁlbum.Text = "Álbum";
            this.colÁlbum.Width = 161;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 95;
            // 
            // colData
            // 
            this.colData.Text = "Última modificação";
            this.colData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colData.Width = 130;
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RecuperarÁlbuns);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AoRecuperarÁlbuns);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "album.tif");
            // 
            // ListViewÁlbuns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst);
            this.Name = "ListViewÁlbuns";
            this.Size = new System.Drawing.Size(393, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colÁlbum;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colData;
        private System.ComponentModel.BackgroundWorker bgRecuperação;
        private System.Windows.Forms.ImageList imageList1;
    }
}
