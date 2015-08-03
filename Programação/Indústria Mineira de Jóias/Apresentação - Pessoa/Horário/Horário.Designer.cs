namespace Apresentação.Pessoa.Horário
{
    partial class Horário
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
            this.painelTopo = new System.Windows.Forms.Panel();
            this.painelFundo = new System.Windows.Forms.Panel();
            this.lblHorário = new System.Windows.Forms.Label();
            this.txtHorário = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // painelTopo
            // 
            this.painelTopo.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.painelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelTopo.Location = new System.Drawing.Point(0, 0);
            this.painelTopo.Name = "painelTopo";
            this.painelTopo.Size = new System.Drawing.Size(150, 10);
            this.painelTopo.TabIndex = 0;
            this.painelTopo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AoPressionarMouse);
            this.painelTopo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AoMoverMouseTopo);
            // 
            // painelFundo
            // 
            this.painelFundo.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.painelFundo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.painelFundo.Location = new System.Drawing.Point(0, 140);
            this.painelFundo.Name = "painelFundo";
            this.painelFundo.Size = new System.Drawing.Size(150, 10);
            this.painelFundo.TabIndex = 1;
            this.painelFundo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AoPressionarMouse);
            this.painelFundo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AoMoverMouseFundo);
            // 
            // lblHorário
            // 
            this.lblHorário.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorário.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHorário.Location = new System.Drawing.Point(0, 10);
            this.lblHorário.Name = "lblHorário";
            this.lblHorário.Size = new System.Drawing.Size(150, 130);
            this.lblHorário.TabIndex = 2;
            this.lblHorário.Text = "Horário";
            this.lblHorário.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHorário.Click += new System.EventHandler(this.EditarHorário);
            this.lblHorário.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AoPressionarMouse);
            this.lblHorário.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AoMoverMouse);
            // 
            // txtHorário
            // 
            this.txtHorário.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHorário.Location = new System.Drawing.Point(3, 57);
            this.txtHorário.Multiline = true;
            this.txtHorário.Name = "txtHorário";
            this.txtHorário.Size = new System.Drawing.Size(144, 39);
            this.txtHorário.TabIndex = 3;
            this.txtHorário.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHorário.Visible = false;
            this.txtHorário.Leave += new System.EventHandler(this.FinalizarEdição);
            this.txtHorário.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHorário_KeyUp);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = global::Apresentação.Pessoa.Properties.Resources.Excluir;
            this.btnExcluir.Location = new System.Drawing.Point(127, 0);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(23, 24);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // Horário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.txtHorário);
            this.Controls.Add(this.lblHorário);
            this.Controls.Add(this.painelFundo);
            this.Controls.Add(this.painelTopo);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Name = "Horário";
            this.Enter += new System.EventHandler(this.EditarHorário);
            this.Resize += new System.EventHandler(this.AtualizarHorário);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel painelTopo;
        private System.Windows.Forms.Panel painelFundo;
        private System.Windows.Forms.Label lblHorário;
        private System.Windows.Forms.TextBox txtHorário;
        private System.Windows.Forms.Button btnExcluir;
    }
}
