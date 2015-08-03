namespace Apresentação.Pessoa.Endereço
{
    partial class EditarEstado
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
            this.cmbPaís = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.formatadorNome = new Apresentação.Pessoa.FormatadorNome(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRegião = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(146, 20);
            this.lblTítulo.Text = "Dados do estado";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Entre com os dados do estado.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.globo;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.formatadorNome.SetFormatarNome(this.txtNome, true);
            this.txtNome.Location = new System.Drawing.Point(92, 107);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(271, 20);
            this.txtNome.TabIndex = 4;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sigla:";
            // 
            // txtSigla
            // 
            this.txtSigla.Location = new System.Drawing.Point(92, 133);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Size = new System.Drawing.Size(88, 20);
            this.txtSigla.TabIndex = 6;
            this.txtSigla.Validated += new System.EventHandler(this.txtSigla_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "País:";
            // 
            // cmbPaís
            // 
            this.cmbPaís.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPaís.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaís.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaís.FormattingEnabled = true;
            this.cmbPaís.Location = new System.Drawing.Point(92, 159);
            this.cmbPaís.Name = "cmbPaís";
            this.cmbPaís.Size = new System.Drawing.Size(271, 21);
            this.cmbPaís.TabIndex = 8;
            this.cmbPaís.SelectedIndexChanged += new System.EventHandler(this.cmbPaís_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(224, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 224);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(36, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 38);
            this.label4.TabIndex = 11;
            this.label4.Text = "Região padrão:";
            // 
            // cmbRegião
            // 
            this.cmbRegião.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegião.FormattingEnabled = true;
            this.cmbRegião.Location = new System.Drawing.Point(92, 186);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Size = new System.Drawing.Size(271, 21);
            this.cmbRegião.TabIndex = 12;
            this.cmbRegião.SelectedIndexChanged += new System.EventHandler(this.cmbRegião_SelectedIndexChanged);
            // 
            // EditarEstado
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 259);
            this.Controls.Add(this.cmbRegião);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbPaís);
            this.Controls.Add(this.txtSigla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Name = "EditarEstado";
            this.Text = "Editar Estado";
            this.Load += new System.EventHandler(this.EditarEstado_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSigla, 0);
            this.Controls.SetChildIndex(this.cmbPaís, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbRegião, 0);
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
        private System.Windows.Forms.ComboBox cmbPaís;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private FormatadorNome formatadorNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRegião;
    }
}
