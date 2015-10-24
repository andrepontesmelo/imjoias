namespace Apresentação.Pessoa.Cadastro
{
    partial class Classificador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Classificador));
            this.chkLst = new System.Windows.Forms.CheckedListBox();
            this.barraFerramentas = new System.Windows.Forms.ToolStrip();
            this.btnMostrarTodos = new System.Windows.Forms.ToolStripButton();
            this.btnSomenteAtribuídos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNova = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnRemover = new System.Windows.Forms.ToolStripButton();
            this.barraFerramentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLst
            // 
            this.chkLst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLst.IntegralHeight = false;
            this.chkLst.Location = new System.Drawing.Point(0, 25);
            this.chkLst.Name = "chkLst";
            this.chkLst.Size = new System.Drawing.Size(502, 170);
            this.chkLst.Sorted = true;
            this.chkLst.TabIndex = 4;
            this.chkLst.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.AoMudarMarcação);
            // 
            // barraFerramentas
            // 
            this.barraFerramentas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.barraFerramentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMostrarTodos,
            this.btnSomenteAtribuídos,
            this.toolStripSeparator1,
            this.btnNova,
            this.btnEditar,
            this.btnRemover});
            this.barraFerramentas.Location = new System.Drawing.Point(0, 0);
            this.barraFerramentas.Name = "barraFerramentas";
            this.barraFerramentas.Size = new System.Drawing.Size(502, 25);
            this.barraFerramentas.TabIndex = 3;
            this.barraFerramentas.Text = "Barra de Ferramentas";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.CheckOnClick = true;
            this.btnMostrarTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMostrarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarTodos.Image")));
            this.btnMostrarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(85, 22);
            this.btnMostrarTodos.Text = "Mostrar todos";
            this.btnMostrarTodos.CheckedChanged += new System.EventHandler(this.AoMudarExibição);
            // 
            // btnSomenteAtribuídos
            // 
            this.btnSomenteAtribuídos.Checked = true;
            this.btnSomenteAtribuídos.CheckOnClick = true;
            this.btnSomenteAtribuídos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnSomenteAtribuídos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSomenteAtribuídos.Image = ((System.Drawing.Image)(resources.GetObject("btnSomenteAtribuídos.Image")));
            this.btnSomenteAtribuídos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSomenteAtribuídos.Name = "btnSomenteAtribuídos";
            this.btnSomenteAtribuídos.Size = new System.Drawing.Size(114, 22);
            this.btnSomenteAtribuídos.Text = "Somente atribuídos";
            this.btnSomenteAtribuídos.Click += new System.EventHandler(this.AoMudarExibição);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNova
            // 
            this.btnNova.Image = ((System.Drawing.Image)(resources.GetObject("btnNova.Image")));
            this.btnNova.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNova.Name = "btnNova";
            this.btnNova.Size = new System.Drawing.Size(55, 22);
            this.btnNova.Text = "Nova";
            this.btnNova.Click += new System.EventHandler(this.CriarNova);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::Apresentação.Resource.EditTableHS;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(57, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.EditarClassificação);
            // 
            // btnRemover
            // 
            this.btnRemover.Image = global::Apresentação.Resource.delete;
            this.btnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(61, 22);
            this.btnRemover.Text = "Excluir";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // Classificador
            // 
            this.Controls.Add(this.chkLst);
            this.Controls.Add(this.barraFerramentas);
            this.Name = "Classificador";
            this.Size = new System.Drawing.Size(502, 195);
            this.barraFerramentas.ResumeLayout(false);
            this.barraFerramentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraFerramentas;
        private System.Windows.Forms.ToolStripButton btnMostrarTodos;
        private System.Windows.Forms.ToolStripButton btnSomenteAtribuídos;
        private System.Windows.Forms.CheckedListBox chkLst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNova;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnRemover;

    }
}
