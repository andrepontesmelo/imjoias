namespace Apresenta��o.Pessoa.Hist�rico
{
    partial class Hist�ricoPessoa
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
            this.hist�rico = new Apresenta��o.Formul�rios.Hist�rico.Hist�rico();
            this.barraFerramentas = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.barraFerramentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // hist�rico
            // 
            this.hist�rico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hist�rico.AutoScroll = true;
            this.hist�rico.Location = new System.Drawing.Point(4, 54);
            this.hist�rico.Name = "hist�rico";
            this.hist�rico.Size = new System.Drawing.Size(221, 157);
            this.hist�rico.TabIndex = 2;
            // 
            // barraFerramentas
            // 
            this.barraFerramentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barraFerramentas.AutoSize = false;
            this.barraFerramentas.Dock = System.Windows.Forms.DockStyle.None;
            this.barraFerramentas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.barraFerramentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar});
            this.barraFerramentas.Location = new System.Drawing.Point(2, 26);
            this.barraFerramentas.Name = "barraFerramentas";
            this.barraFerramentas.Size = new System.Drawing.Size(226, 25);
            this.barraFerramentas.TabIndex = 3;
            this.barraFerramentas.Text = "barraFerramentas";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Apresenta��o.Resource.NewCardHS;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(78, 22);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // Hist�ricoPessoa
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.barraFerramentas);
            this.Controls.Add(this.hist�rico);
            this.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.Name = "Hist�ricoPessoa";
            this.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroAcesso;
            this.Size = new System.Drawing.Size(230, 216);
            this.T�tulo = "Hist�rico";
            this.Controls.SetChildIndex(this.hist�rico, 0);
            this.Controls.SetChildIndex(this.barraFerramentas, 0);
            this.barraFerramentas.ResumeLayout(false);
            this.barraFerramentas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.Hist�rico.Hist�rico hist�rico;
        private System.Windows.Forms.ToolStrip barraFerramentas;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
    }
}
