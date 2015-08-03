namespace Apresentação.Formulários
{
    partial class EditorBase<Item, ControleItem>
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
            this.painel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemover = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnDesfazer = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // painel
            // 
            this.painel.AutoScroll = true;
            this.painel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painel.Location = new System.Drawing.Point(0, 25);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(289, 149);
            this.painel.TabIndex = 4;
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Image = global::Apresentação.Formulários.Properties.Resources.Excluir;
            this.btnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(74, 22);
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnRemover,
            this.btnDesfazer});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(289, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Apresentação.Formulários.Properties.Resources.AddTableHS;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(78, 22);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.Image = global::Apresentação.Formulários.Properties.Resources.Edit_UndoHS;
            this.btnDesfazer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(121, 20);
            this.btnDesfazer.Text = "Desfazer remoção";
            this.btnDesfazer.Visible = false;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // EditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.painel);
            this.Controls.Add(this.toolStrip);
            this.Name = "EditorBase";
            this.Size = new System.Drawing.Size(289, 174);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnDesfazer;
        private System.Windows.Forms.FlowLayoutPanel painel;
        private System.Windows.Forms.ToolStripButton btnRemover;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
    }
}
