namespace Apresenta��o.Pessoa.Endere�o
{
    partial class ProcurarLocalidade
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
            this.cmbPa�s = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblRegi�o = new System.Windows.Forms.Label();
            this.cmbRegi�o = new System.Windows.Forms.ComboBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(194, 20);
            this.lblT�tulo.Text = "Procurar por localidade";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Entre com os dados que desejar para que se realize a procura por localidade.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Pessoa.Properties.Resources.Lupa;
            // 
            // lblPa�s
            // 
            this.lblPa�s.AutoSize = true;
            this.lblPa�s.Location = new System.Drawing.Point(27, 112);
            this.lblPa�s.Name = "lblPa�s";
            this.lblPa�s.Size = new System.Drawing.Size(32, 13);
            this.lblPa�s.TabIndex = 3;
            this.lblPa�s.Text = "Pa�s:";
            // 
            // cmbPa�s
            // 
            this.cmbPa�s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPa�s.FormattingEnabled = true;
            this.cmbPa�s.Location = new System.Drawing.Point(78, 109);
            this.cmbPa�s.Name = "cmbPa�s";
            this.cmbPa�s.Size = new System.Drawing.Size(266, 21);
            this.cmbPa�s.TabIndex = 4;
            this.cmbPa�s.SelectedIndexChanged += new System.EventHandler(this.cmbPa�s_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Enabled = false;
            this.lblEstado.Location = new System.Drawing.Point(27, 139);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Enabled = false;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(78, 136);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(266, 21);
            this.cmbEstado.TabIndex = 6;
            // 
            // lblRegi�o
            // 
            this.lblRegi�o.AutoSize = true;
            this.lblRegi�o.Location = new System.Drawing.Point(27, 166);
            this.lblRegi�o.Name = "lblRegi�o";
            this.lblRegi�o.Size = new System.Drawing.Size(44, 13);
            this.lblRegi�o.TabIndex = 7;
            this.lblRegi�o.Text = "Regi�o:";
            // 
            // cmbRegi�o
            // 
            this.cmbRegi�o.FormattingEnabled = true;
            this.cmbRegi�o.Location = new System.Drawing.Point(77, 163);
            this.cmbRegi�o.Name = "cmbRegi�o";
            this.cmbRegi�o.Size = new System.Drawing.Size(267, 21);
            this.cmbRegi�o.TabIndex = 8;
            // 
            // btnProcurar
            // 
            this.btnProcurar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProcurar.Location = new System.Drawing.Point(224, 199);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 9;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ProcurarLocalidade
            // 
            this.AcceptButton = this.btnProcurar;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 234);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.cmbRegi�o);
            this.Controls.Add(this.lblRegi�o);
            this.Controls.Add(this.lblPa�s);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbPa�s);
            this.Controls.Add(this.lblEstado);
            this.Name = "ProcurarLocalidade";
            this.Text = "Procurar por localidade";
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.cmbPa�s, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.lblPa�s, 0);
            this.Controls.SetChildIndex(this.lblRegi�o, 0);
            this.Controls.SetChildIndex(this.cmbRegi�o, 0);
            this.Controls.SetChildIndex(this.btnProcurar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPa�s;
        private System.Windows.Forms.ComboBox cmbPa�s;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblRegi�o;
        private System.Windows.Forms.ComboBox cmbRegi�o;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
