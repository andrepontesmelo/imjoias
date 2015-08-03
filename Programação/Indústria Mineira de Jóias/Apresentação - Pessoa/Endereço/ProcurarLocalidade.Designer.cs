namespace Apresentação.Pessoa.Endereço
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
            this.lblPaís = new System.Windows.Forms.Label();
            this.cmbPaís = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblRegião = new System.Windows.Forms.Label();
            this.cmbRegião = new System.Windows.Forms.ComboBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(194, 20);
            this.lblTítulo.Text = "Procurar por localidade";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Entre com os dados que desejar para que se realize a procura por localidade.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Pessoa.Properties.Resources.Lupa;
            // 
            // lblPaís
            // 
            this.lblPaís.AutoSize = true;
            this.lblPaís.Location = new System.Drawing.Point(27, 112);
            this.lblPaís.Name = "lblPaís";
            this.lblPaís.Size = new System.Drawing.Size(32, 13);
            this.lblPaís.TabIndex = 3;
            this.lblPaís.Text = "País:";
            // 
            // cmbPaís
            // 
            this.cmbPaís.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaís.FormattingEnabled = true;
            this.cmbPaís.Location = new System.Drawing.Point(78, 109);
            this.cmbPaís.Name = "cmbPaís";
            this.cmbPaís.Size = new System.Drawing.Size(266, 21);
            this.cmbPaís.TabIndex = 4;
            this.cmbPaís.SelectedIndexChanged += new System.EventHandler(this.cmbPaís_SelectedIndexChanged);
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
            // lblRegião
            // 
            this.lblRegião.AutoSize = true;
            this.lblRegião.Location = new System.Drawing.Point(27, 166);
            this.lblRegião.Name = "lblRegião";
            this.lblRegião.Size = new System.Drawing.Size(44, 13);
            this.lblRegião.TabIndex = 7;
            this.lblRegião.Text = "Região:";
            // 
            // cmbRegião
            // 
            this.cmbRegião.FormattingEnabled = true;
            this.cmbRegião.Location = new System.Drawing.Point(77, 163);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Size = new System.Drawing.Size(267, 21);
            this.cmbRegião.TabIndex = 8;
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
            this.Controls.Add(this.cmbRegião);
            this.Controls.Add(this.lblRegião);
            this.Controls.Add(this.lblPaís);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbPaís);
            this.Controls.Add(this.lblEstado);
            this.Name = "ProcurarLocalidade";
            this.Text = "Procurar por localidade";
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.cmbPaís, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.lblPaís, 0);
            this.Controls.SetChildIndex(this.lblRegião, 0);
            this.Controls.SetChildIndex(this.cmbRegião, 0);
            this.Controls.SetChildIndex(this.btnProcurar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaís;
        private System.Windows.Forms.ComboBox cmbPaís;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblRegião;
        private System.Windows.Forms.ComboBox cmbRegião;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
