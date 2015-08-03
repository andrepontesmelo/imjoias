namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class ListaPedidosSimples
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Cadastrados recentemente", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Na oficina", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Concluídos", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Entregues", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPedidosSimples));
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.lista = new System.Windows.Forms.ListView();
            this.colCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataRegistro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrevisão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepresentante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRecuperação_RunWorkerCompleted);
            // 
            // lista
            // 
            this.lista.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigo,
            this.colDataRegistro,
            this.colPrevisão,
            this.colEntrega,
            this.colRepresentante,
            this.colCliente,
            this.colDescrição});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            listViewGroup1.Header = "Cadastrados recentemente";
            listViewGroup1.Name = "grupoCadastradoRecentemente";
            listViewGroup2.Header = "Na oficina";
            listViewGroup2.Name = "grupoNaOficina";
            listViewGroup3.Header = "Concluídos";
            listViewGroup3.Name = "grupoConcluídos";
            listViewGroup4.Header = "Entregues";
            listViewGroup4.Name = "grupoEntregues";
            this.lista.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(419, 188);
            this.lista.SmallImageList = this.imageList;
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lista_KeyDown);
            this.lista.MouseEnter += new System.EventHandler(this.lista_MouseEnter);
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            this.colCódigo.Width = 53;
            // 
            // colDataRegistro
            // 
            this.colDataRegistro.Text = "Registro";
            this.colDataRegistro.Width = 82;
            // 
            // colPrevisão
            // 
            this.colPrevisão.Text = "Previsão";
            this.colPrevisão.Width = 86;
            // 
            // colEntrega
            // 
            this.colEntrega.Text = "Entrega";
            this.colEntrega.Width = 86;
            // 
            // colRepresentante
            // 
            this.colRepresentante.Text = "Representante";
            this.colRepresentante.Width = 164;
            // 
            // colCliente
            // 
            this.colCliente.Text = "Cliente";
            this.colCliente.Width = 210;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 428;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Error.png");
            this.imageList.Images.SetKeyName(1, "warning.ico");
            this.imageList.Images.SetKeyName(2, "oksimples.gif");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 166);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(419, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::Apresentação.Resource.Error1;
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Atrasados";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::Apresentação.Resource.warning;
            this.toolStripStatusLabel2.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel2.Text = "Para hoje";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::Apresentação.Resource.oksimples1;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel3.Text = "Prontos";
            // 
            // ListaPedidosSimples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lista);
            this.Name = "ListaPedidosSimples";
            this.Size = new System.Drawing.Size(419, 188);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgRecuperação;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colCódigo;
        private System.Windows.Forms.ColumnHeader colCliente;
        private System.Windows.Forms.ColumnHeader colRepresentante;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colDataRegistro;
        private System.Windows.Forms.ColumnHeader colPrevisão;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ColumnHeader colEntrega;

    }
}
