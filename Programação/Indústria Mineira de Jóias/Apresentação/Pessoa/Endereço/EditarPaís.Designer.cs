namespace Apresentação.Pessoa.Endereço
{
    partial class EditarPaís
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDDI = new AMS.TextBox.IntegerTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.formatadorNome = new Apresentação.Pessoa.FormatadorNome(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(124, 20);
            this.lblTítulo.Text = "Dados do país";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Entre com os dados do país.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.globo;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.formatadorNome.SetFormatarNome(this.txtNome, true);
            this.txtNome.Location = new System.Drawing.Point(80, 113);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(281, 20);
            this.txtNome.TabIndex = 4;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sigla:";
            // 
            // txtSigla
            // 
            this.txtSigla.Location = new System.Drawing.Point(80, 139);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Size = new System.Drawing.Size(100, 20);
            this.txtSigla.TabIndex = 6;
            this.txtSigla.Validated += new System.EventHandler(this.txtSigla_Validated);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DDI:";
            // 
            // txtDDI
            // 
            this.txtDDI.AllowNegative = true;
            this.txtDDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDDI.DigitsInGroup = 0;
            this.txtDDI.Flags = 0;
            this.txtDDI.Location = new System.Drawing.Point(261, 139);
            this.txtDDI.MaxDecimalPlaces = 0;
            this.txtDDI.MaxWholeDigits = 9;
            this.txtDDI.Name = "txtDDI";
            this.txtDDI.Prefix = "";
            this.txtDDI.RangeMax = 1.7976931348623157E+308;
            this.txtDDI.RangeMin = -1.7976931348623157E+308;
            this.txtDDI.Size = new System.Drawing.Size(100, 20);
            this.txtDDI.TabIndex = 8;
            this.txtDDI.Validated += new System.EventHandler(this.txtDDI_Validated);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(224, 173);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 173);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // EditarPaís
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSigla);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtDDI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "EditarPaís";
            this.Text = "Editar país";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDDI, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.txtSigla, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.Label label3;
        private AMS.TextBox.IntegerTextBox txtDDI;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private FormatadorNome formatadorNome;
    }
}
