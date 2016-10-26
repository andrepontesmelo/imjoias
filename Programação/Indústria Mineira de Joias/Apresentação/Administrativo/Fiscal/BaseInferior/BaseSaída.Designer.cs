namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseSaída
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
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSetor = new Apresentação.ComboSetor();
            this.chkCancelada = new System.Windows.Forms.CheckBox();
            this.grpDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Descrição = "Edição de uma saída fiscal";
            this.título.Título = "Editar saída fiscal";
            // 
            // grpDados
            // 
            this.grpDados.Controls.Add(this.chkCancelada);
            this.grpDados.Controls.Add(this.cmbSetor);
            this.grpDados.Controls.Add(this.label13);
            this.grpDados.Text = "Dados da saída";
            this.grpDados.Controls.SetChildIndex(this.lblEntradaSaída, 0);
            this.grpDados.Controls.SetChildIndex(this.lblTipoDocumento, 0);
            this.grpDados.Controls.SetChildIndex(this.txtId, 0);
            this.grpDados.Controls.SetChildIndex(this.dtEntradaSaída, 0);
            this.grpDados.Controls.SetChildIndex(this.cmbTipoDocumento, 0);
            this.grpDados.Controls.SetChildIndex(this.label13, 0);
            this.grpDados.Controls.SetChildIndex(this.cmbSetor, 0);
            this.grpDados.Controls.SetChildIndex(this.chkCancelada, 0);
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Size = new System.Drawing.Size(39, 13);
            this.lblEntradaSaída.Text = "Saída:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Size = new System.Drawing.Size(76, 13);
            this.lblTipoDocumento.Text = "Tipo de saída:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(535, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Setor:";
            // 
            // cmbSetor
            // 
            this.cmbSetor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(643, 51);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Seleção = null;
            this.cmbSetor.Size = new System.Drawing.Size(125, 21);
            this.cmbSetor.TabIndex = 16;
            this.cmbSetor.Validated += new System.EventHandler(this.cmbSetor_Validated);
            // 
            // chkCancelada
            // 
            this.chkCancelada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCancelada.AutoSize = true;
            this.chkCancelada.Location = new System.Drawing.Point(195, 194);
            this.chkCancelada.Name = "chkCancelada";
            this.chkCancelada.Size = new System.Drawing.Size(77, 17);
            this.chkCancelada.TabIndex = 17;
            this.chkCancelada.Text = "Cancelada";
            this.chkCancelada.UseVisualStyleBackColor = true;
            this.chkCancelada.Validated += new System.EventHandler(this.chkCancelada_Validated);
            // 
            // BaseSaída
            // 
            this.Name = "BaseSaída";
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboSetor cmbSetor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkCancelada;
    }
}
