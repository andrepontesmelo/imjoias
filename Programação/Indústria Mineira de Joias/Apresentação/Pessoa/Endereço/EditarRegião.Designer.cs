namespace Apresentação.Pessoa.Endereço
{
    partial class EditarRegião
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstEstados = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdEstadoAdicionar = new System.Windows.Forms.ToolStripButton();
            this.cmdEstadoRemover = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstLocalidades = new System.Windows.Forms.ListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cmdLocalidadeAdicionar = new System.Windows.Forms.ToolStripButton();
            this.cmdLocalidadeRemover = new System.Windows.Forms.ToolStripButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCódigo = new System.Windows.Forms.TextBox();
            this.grpPessoas = new System.Windows.Forms.GroupBox();
            this.lstPessoas = new System.Windows.Forms.ListBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.cmdPessoaAdicionar = new System.Windows.Forms.ToolStripButton();
            this.cmdPessoaRemover = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.grpPessoas.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(141, 20);
            this.lblTítulo.Text = "Dados da região";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Entre com os dados da região.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.globo;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(102, 130);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 20);
            this.txtNome.TabIndex = 4;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Observações:";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(102, 156);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(261, 73);
            this.txtObs.TabIndex = 6;
            this.txtObs.Validated += new System.EventHandler(this.txtObs_Validated);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(25, 237);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(337, 94);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstEstados);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estados";
            // 
            // lstEstados
            // 
            this.lstEstados.DisplayMember = "Nome";
            this.lstEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEstados.FormattingEnabled = true;
            this.lstEstados.IntegralHeight = false;
            this.lstEstados.Location = new System.Drawing.Point(3, 16);
            this.lstEstados.Name = "lstEstados";
            this.lstEstados.Size = new System.Drawing.Size(139, 75);
            this.lstEstados.TabIndex = 1;
            this.lstEstados.SelectedIndexChanged += new System.EventHandler(this.lstEstados_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdEstadoAdicionar,
            this.cmdEstadoRemover});
            this.toolStrip1.Location = new System.Drawing.Point(142, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 75);
            this.toolStrip1.TabIndex = 0;
            // 
            // cmdEstadoAdicionar
            // 
            this.cmdEstadoAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdEstadoAdicionar.Image = global::Apresentação.Resource.AddTableHS;
            this.cmdEstadoAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEstadoAdicionar.Name = "cmdEstadoAdicionar";
            this.cmdEstadoAdicionar.Size = new System.Drawing.Size(21, 20);
            this.cmdEstadoAdicionar.Text = "Adicionar";
            this.cmdEstadoAdicionar.Click += new System.EventHandler(this.cmdEstadoAdicionar_Click);
            // 
            // cmdEstadoRemover
            // 
            this.cmdEstadoRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdEstadoRemover.Enabled = false;
            this.cmdEstadoRemover.Image = global::Apresentação.Resource.Excluir;
            this.cmdEstadoRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEstadoRemover.Name = "cmdEstadoRemover";
            this.cmdEstadoRemover.Size = new System.Drawing.Size(21, 20);
            this.cmdEstadoRemover.Text = "Remover";
            this.cmdEstadoRemover.Click += new System.EventHandler(this.cmdEstadoRemover_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstLocalidades);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 94);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Localidades";
            // 
            // lstLocalidades
            // 
            this.lstLocalidades.DisplayMember = "Nome";
            this.lstLocalidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLocalidades.FormattingEnabled = true;
            this.lstLocalidades.IntegralHeight = false;
            this.lstLocalidades.Location = new System.Drawing.Point(3, 16);
            this.lstLocalidades.Name = "lstLocalidades";
            this.lstLocalidades.Size = new System.Drawing.Size(134, 75);
            this.lstLocalidades.TabIndex = 2;
            this.lstLocalidades.SelectedIndexChanged += new System.EventHandler(this.lstLocalidades_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLocalidadeAdicionar,
            this.cmdLocalidadeRemover});
            this.toolStrip2.Location = new System.Drawing.Point(137, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 75);
            this.toolStrip2.TabIndex = 1;
            // 
            // cmdLocalidadeAdicionar
            // 
            this.cmdLocalidadeAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLocalidadeAdicionar.Image = global::Apresentação.Resource.AddTableHS;
            this.cmdLocalidadeAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLocalidadeAdicionar.Name = "cmdLocalidadeAdicionar";
            this.cmdLocalidadeAdicionar.Size = new System.Drawing.Size(29, 20);
            this.cmdLocalidadeAdicionar.Text = "Adicionar";
            this.cmdLocalidadeAdicionar.Click += new System.EventHandler(this.cmdLocalidadeAdicionar_Click);
            // 
            // cmdLocalidadeRemover
            // 
            this.cmdLocalidadeRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLocalidadeRemover.Enabled = false;
            this.cmdLocalidadeRemover.Image = global::Apresentação.Resource.Excluir;
            this.cmdLocalidadeRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLocalidadeRemover.Name = "cmdLocalidadeRemover";
            this.cmdLocalidadeRemover.Size = new System.Drawing.Size(29, 20);
            this.cmdLocalidadeRemover.Text = "Remover";
            this.cmdLocalidadeRemover.Click += new System.EventHandler(this.cmdLocalidadeRemover_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(224, 422);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 422);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Código:";
            // 
            // txtCódigo
            // 
            this.txtCódigo.Location = new System.Drawing.Point(102, 104);
            this.txtCódigo.Name = "txtCódigo";
            this.txtCódigo.ReadOnly = true;
            this.txtCódigo.Size = new System.Drawing.Size(65, 20);
            this.txtCódigo.TabIndex = 11;
            this.txtCódigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCódigo.Validated += new System.EventHandler(this.txtCódigo_Validated);
            this.txtCódigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCódigo_Validating);
            // 
            // grpPessoas
            // 
            this.grpPessoas.Controls.Add(this.lstPessoas);
            this.grpPessoas.Controls.Add(this.toolStrip3);
            this.grpPessoas.Location = new System.Drawing.Point(26, 338);
            this.grpPessoas.Name = "grpPessoas";
            this.grpPessoas.Size = new System.Drawing.Size(336, 78);
            this.grpPessoas.TabIndex = 12;
            this.grpPessoas.TabStop = false;
            this.grpPessoas.Text = "Pessoas";
            // 
            // lstPessoas
            // 
            this.lstPessoas.DisplayMember = "Nome";
            this.lstPessoas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPessoas.FormattingEnabled = true;
            this.lstPessoas.IntegralHeight = false;
            this.lstPessoas.Location = new System.Drawing.Point(3, 16);
            this.lstPessoas.Name = "lstPessoas";
            this.lstPessoas.Size = new System.Drawing.Size(306, 59);
            this.lstPessoas.TabIndex = 3;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdPessoaAdicionar,
            this.cmdPessoaRemover});
            this.toolStrip3.Location = new System.Drawing.Point(309, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(24, 59);
            this.toolStrip3.TabIndex = 2;
            // 
            // cmdPessoaAdicionar
            // 
            this.cmdPessoaAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdPessoaAdicionar.Image = global::Apresentação.Resource.AddTableHS;
            this.cmdPessoaAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPessoaAdicionar.Name = "cmdPessoaAdicionar";
            this.cmdPessoaAdicionar.Size = new System.Drawing.Size(29, 20);
            this.cmdPessoaAdicionar.Text = "Adicionar";
            this.cmdPessoaAdicionar.Click += new System.EventHandler(this.cmdPessoaAdicionar_Click);
            // 
            // cmdPessoaRemover
            // 
            this.cmdPessoaRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdPessoaRemover.Enabled = false;
            this.cmdPessoaRemover.Image = global::Apresentação.Resource.Excluir;
            this.cmdPessoaRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPessoaRemover.Name = "cmdPessoaRemover";
            this.cmdPessoaRemover.Size = new System.Drawing.Size(21, 20);
            this.cmdPessoaRemover.Text = "Remover";
            // 
            // EditarRegião
            // 
            this.ClientSize = new System.Drawing.Size(392, 457);
            this.Controls.Add(this.grpPessoas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCódigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Name = "EditarRegião";
            this.Text = "Editar região";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.txtObs, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtCódigo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.grpPessoas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.grpPessoas.ResumeLayout(false);
            this.grpPessoas.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdEstadoAdicionar;
        private System.Windows.Forms.ToolStripButton cmdEstadoRemover;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton cmdLocalidadeAdicionar;
        private System.Windows.Forms.ToolStripButton cmdLocalidadeRemover;
        private System.Windows.Forms.ListBox lstEstados;
        private System.Windows.Forms.ListBox lstLocalidades;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCódigo;
        private System.Windows.Forms.GroupBox grpPessoas;
        private System.Windows.Forms.ListBox lstPessoas;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton cmdPessoaAdicionar;
        private System.Windows.Forms.ToolStripButton cmdPessoaRemover;
    }
}
