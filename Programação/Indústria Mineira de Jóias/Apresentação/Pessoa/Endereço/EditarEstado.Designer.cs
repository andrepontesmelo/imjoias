namespace Apresenta��o.Pessoa.Endere�o
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
            this.cmbPa�s = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.formatadorNome = new Apresenta��o.Pessoa.FormatadorNome(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRegi�o = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(146, 20);
            this.lblT�tulo.Text = "Dados do estado";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Entre com os dados do estado.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Resource.globo;
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.label3.Text = "Pa�s:";
            // 
            // cmbPa�s
            // 
            this.cmbPa�s.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPa�s.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPa�s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPa�s.FormattingEnabled = true;
            this.cmbPa�s.Location = new System.Drawing.Point(92, 159);
            this.cmbPa�s.Name = "cmbPa�s";
            this.cmbPa�s.Size = new System.Drawing.Size(271, 21);
            this.cmbPa�s.TabIndex = 8;
            this.cmbPa�s.SelectedIndexChanged += new System.EventHandler(this.cmbPa�s_SelectedIndexChanged);
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
            this.label4.Text = "Regi�o padr�o:";
            // 
            // cmbRegi�o
            // 
            this.cmbRegi�o.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegi�o.FormattingEnabled = true;
            this.cmbRegi�o.Location = new System.Drawing.Point(92, 186);
            this.cmbRegi�o.Name = "cmbRegi�o";
            this.cmbRegi�o.Size = new System.Drawing.Size(271, 21);
            this.cmbRegi�o.TabIndex = 12;
            this.cmbRegi�o.SelectedIndexChanged += new System.EventHandler(this.cmbRegi�o_SelectedIndexChanged);
            // 
            // EditarEstado
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 259);
            this.Controls.Add(this.cmbRegi�o);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbPa�s);
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
            this.Controls.SetChildIndex(this.cmbPa�s, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbRegi�o, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPa�s;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private FormatadorNome formatadorNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRegi�o;
    }
}
