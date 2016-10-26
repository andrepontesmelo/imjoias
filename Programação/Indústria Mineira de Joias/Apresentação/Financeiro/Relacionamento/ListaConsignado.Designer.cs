namespace Apresentação.Financeiro
{
    partial class ListaConsignado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaConsignado));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLocalizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelecionarTudo = new System.Windows.Forms.ToolStripButton();
            this.btnDesselecionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgrupar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lista = new System.Windows.Forms.ListView();
            this.colCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAcerto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncionário = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPessoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObservações = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localizador = new Apresentação.Formulários.Localizador();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLocalizar,
            this.toolStripSeparator,
            this.btnSelecionarTudo,
            this.btnDesselecionar,
            this.toolStripSeparator1,
            this.btnAgrupar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(635, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLocalizar.Image = global::Apresentação.Resource.search;
            this.btnLocalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(23, 22);
            this.btnLocalizar.Text = "Localizar";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelecionarTudo
            // 
            this.btnSelecionarTudo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelecionarTudo.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarTudo.Image")));
            this.btnSelecionarTudo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelecionarTudo.Name = "btnSelecionarTudo";
            this.btnSelecionarTudo.Size = new System.Drawing.Size(93, 22);
            this.btnSelecionarTudo.Text = "Selecionar tudo";
            this.btnSelecionarTudo.Click += new System.EventHandler(this.btnSelecionarTudo_Click);
            // 
            // btnDesselecionar
            // 
            this.btnDesselecionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDesselecionar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesselecionar.Image")));
            this.btnDesselecionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesselecionar.Name = "btnDesselecionar";
            this.btnDesselecionar.Size = new System.Drawing.Size(94, 22);
            this.btnDesselecionar.Text = "Selecionar nada";
            this.btnDesselecionar.Click += new System.EventHandler(this.btnDesselecionar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.Checked = true;
            this.btnAgrupar.CheckOnClick = true;
            this.btnAgrupar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAgrupar.Image = global::Apresentação.Resource.Acerto__Pequeno_;
            this.btnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(127, 22);
            this.btnAgrupar.Text = "Agrupar por acerto";
            this.btnAgrupar.CheckedChanged += new System.EventHandler(this.btnAgrupar_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lista);
            this.panel1.Controls.Add(this.localizador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 305);
            this.panel1.TabIndex = 17;
            // 
            // lista
            // 
            this.lista.CheckBoxes = true;
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigo,
            this.colAcerto,
            this.colFuncionário,
            this.colPessoa,
            this.colStatus,
            this.colData,
            this.colObservações});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.HideSelection = false;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(635, 275);
            this.lista.TabIndex = 15;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lista_ItemChecked);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lista_KeyDown);
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            // 
            // colAcerto
            // 
            this.colAcerto.Text = "Acerto";
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Digitado Por";
            // 
            // colPessoa
            // 
            this.colPessoa.Text = "Digitado para";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Estado";
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colObservações
            // 
            this.colObservações.Text = "Observações";
            this.colObservações.Width = 150;
            // 
            // localizador
            // 
            this.localizador.BotãoPesquisar = this.btnLocalizar;
            this.localizador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.localizador.Location = new System.Drawing.Point(0, 275);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(635, 30);
            this.localizador.TabIndex = 14;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            // 
            // ListaConsignado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ListaConsignado";
            this.Size = new System.Drawing.Size(635, 330);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private Apresentação.Formulários.Localizador localizador;
        private System.Windows.Forms.ToolStripButton btnLocalizar;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colCódigo;
        private System.Windows.Forms.ColumnHeader colFuncionário;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ToolStripButton btnSelecionarTudo;
        private System.Windows.Forms.ToolStripButton btnDesselecionar;
        private System.Windows.Forms.ColumnHeader colPessoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ColumnHeader colAcerto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAgrupar;
        private System.Windows.Forms.ColumnHeader colObservações;

    }
}
