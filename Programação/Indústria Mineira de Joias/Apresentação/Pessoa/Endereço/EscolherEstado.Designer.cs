namespace Apresenta��o.Pessoa.Endere�o
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
            this.lblPa�s = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbPa�s = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(158, 20);
            this.lblT�tulo.Text = "Escolha de estado";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Escolha o estado desejado.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Resource.globo;
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // lblPa�s
            // 
            this.lblPa�s.AutoSize = true;
            this.lblPa�s.Location = new System.Drawing.Point(38, 116);
            this.lblPa�s.Name = "lblPa�s";
            this.lblPa�s.Size = new System.Drawing.Size(32, 13);
            this.lblPa�s.TabIndex = 7;
            this.lblPa�s.Text = "Pa�s:";
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
            // cmbPa�s
            // 
            this.cmbPa�s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPa�s.FormattingEnabled = true;
            this.cmbPa�s.Location = new System.Drawing.Point(89, 113);
            this.cmbPa�s.Name = "cmbPa�s";
            this.cmbPa�s.Size = new System.Drawing.Size(266, 21);
            this.cmbPa�s.TabIndex = 8;
            this.cmbPa�s.SelectedIndexChanged += new System.EventHandler(this.cmbPa�s_SelectedIndexChanged);
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
            this.Controls.Add(this.lblPa�s);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbPa�s);
            this.Controls.Add(this.lblEstado);
            this.Name = "EscolherEstado";
            this.Text = "Escolher estado";
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.cmbPa�s, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.lblPa�s, 0);
            this.Controls.SetChildIndex(this.btnProcurar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPa�s;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbPa�s;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcurar;
    }
}
