namespace Apresentação.Pessoa.Endereço
{
    partial class EscolherEstado
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
            this.lblPaís = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbPaís = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(158, 20);
            this.lblTítulo.Text = "Escolha de estado";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Escolha o estado desejado.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.globo;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // lblPaís
            // 
            this.lblPaís.AutoSize = true;
            this.lblPaís.Location = new System.Drawing.Point(38, 116);
            this.lblPaís.Name = "lblPaís";
            this.lblPaís.Size = new System.Drawing.Size(32, 13);
            this.lblPaís.TabIndex = 7;
            this.lblPaís.Text = "País:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Enabled = false;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(89, 140);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(266, 21);
            this.cmbEstado.TabIndex = 10;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // cmbPaís
            // 
            this.cmbPaís.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaís.FormattingEnabled = true;
            this.cmbPaís.Location = new System.Drawing.Point(89, 113);
            this.cmbPaís.Name = "cmbPaís";
            this.cmbPaís.Size = new System.Drawing.Size(266, 21);
            this.cmbPaís.TabIndex = 8;
            this.cmbPaís.SelectedIndexChanged += new System.EventHandler(this.cmbPaís_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Enabled = false;
            this.lblEstado.Location = new System.Drawing.Point(38, 143);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Estado:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 182);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnProcurar
            // 
            this.btnProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcurar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProcurar.Enabled = false;
            this.btnProcurar.Location = new System.Drawing.Point(224, 182);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 11;
            this.btnProcurar.Text = "OK";
            this.btnProcurar.UseVisualStyleBackColor = true;
            // 
            // EscolherEstado
            // 
            this.ClientSize = new System.Drawing.Size(392, 217);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.lblPaís);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbPaís);
            this.Controls.Add(this.lblEstado);
            this.Name = "EscolherEstado";
            this.Text = "Escolher estado";
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.cmbPaís, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.lblPaís, 0);
            this.Controls.SetChildIndex(this.btnProcurar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaís;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbPaís;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcurar;
    }
}
