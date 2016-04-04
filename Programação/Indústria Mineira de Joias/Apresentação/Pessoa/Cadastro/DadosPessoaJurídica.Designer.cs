namespace Apresentação.Pessoa.Cadastro
{
    partial class DadosPessoaJurídica
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
            this.components = new System.ComponentModel.Container();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCódigo = new AMS.TextBox.IntegerTextBox();
            this.cmbNumeraçãoAutomática = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInscMunicipal = new System.Windows.Forms.TextBox();
            this.lblInscMunicipal = new System.Windows.Forms.Label();
            this.txtInscEstadual = new System.Windows.Forms.TextBox();
            this.lblInscEstadual = new System.Windows.Forms.Label();
            this.txtCNPJ = new Apresentação.Pessoa.TextBoxCNPJ();
            this.lblCNPJ = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.lblFantasia = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.abrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.formatadorRazãoSocial = new Apresentação.Pessoa.FormatadorNome(this.components);
            this.formatadorNomeFantasia = new Apresentação.Pessoa.FormatadorNome(this.components);
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtCódigo);
            this.groupBox4.Controls.Add(this.cmbNumeraçãoAutomática);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtInscMunicipal);
            this.groupBox4.Controls.Add(this.lblInscMunicipal);
            this.groupBox4.Controls.Add(this.txtInscEstadual);
            this.groupBox4.Controls.Add(this.lblInscEstadual);
            this.groupBox4.Controls.Add(this.txtCNPJ);
            this.groupBox4.Controls.Add(this.lblCNPJ);
            this.groupBox4.Controls.Add(this.txtFantasia);
            this.groupBox4.Controls.Add(this.lblFantasia);
            this.groupBox4.Controls.Add(this.lblNome);
            this.groupBox4.Controls.Add(this.txtNome);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 390);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Identificação";
            // 
            // txtCódigo
            // 
            this.txtCódigo.AllowNegative = true;
            this.txtCódigo.DigitsInGroup = 0;
            this.txtCódigo.Enabled = false;
            this.txtCódigo.Flags = 0;
            this.txtCódigo.Location = new System.Drawing.Point(88, 18);
            this.txtCódigo.MaxDecimalPlaces = 0;
            this.txtCódigo.MaxWholeDigits = 9;
            this.txtCódigo.Name = "txtCódigo";
            this.txtCódigo.Prefix = "";
            this.txtCódigo.RangeMax = 1.7976931348623157E+308D;
            this.txtCódigo.RangeMin = -1.7976931348623157E+308D;
            this.txtCódigo.Size = new System.Drawing.Size(117, 20);
            this.txtCódigo.TabIndex = 18;
            this.txtCódigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCódigo_Validating);
            this.txtCódigo.Validated += new System.EventHandler(this.txtCódigo_Validated);
            // 
            // cmbNumeraçãoAutomática
            // 
            this.cmbNumeraçãoAutomática.AutoSize = true;
            this.cmbNumeraçãoAutomática.Checked = true;
            this.cmbNumeraçãoAutomática.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmbNumeraçãoAutomática.Location = new System.Drawing.Point(213, 18);
            this.cmbNumeraçãoAutomática.Name = "cmbNumeraçãoAutomática";
            this.cmbNumeraçãoAutomática.Size = new System.Drawing.Size(140, 17);
            this.cmbNumeraçãoAutomática.TabIndex = 16;
            this.cmbNumeraçãoAutomática.Text = " Numeração Automática";
            this.cmbNumeraçãoAutomática.UseVisualStyleBackColor = true;
            this.cmbNumeraçãoAutomática.CheckedChanged += new System.EventHandler(this.cmbNumeraçãoAutomática_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Código:";
            // 
            // txtInscMunicipal
            // 
            this.txtInscMunicipal.Location = new System.Drawing.Point(88, 145);
            this.txtInscMunicipal.MaxLength = 15;
            this.txtInscMunicipal.Name = "txtInscMunicipal";
            this.txtInscMunicipal.Size = new System.Drawing.Size(117, 20);
            this.txtInscMunicipal.TabIndex = 9;
            this.txtInscMunicipal.Validated += new System.EventHandler(this.txtInscMunicipal_Validated);
            // 
            // lblInscMunicipal
            // 
            this.lblInscMunicipal.AutoSize = true;
            this.lblInscMunicipal.Location = new System.Drawing.Point(5, 148);
            this.lblInscMunicipal.Name = "lblInscMunicipal";
            this.lblInscMunicipal.Size = new System.Drawing.Size(81, 13);
            this.lblInscMunicipal.TabIndex = 8;
            this.lblInscMunicipal.Text = "Insc. Municipal:";
            // 
            // txtInscEstadual
            // 
            this.txtInscEstadual.Location = new System.Drawing.Point(88, 119);
            this.txtInscEstadual.Name = "txtInscEstadual";
            this.txtInscEstadual.Size = new System.Drawing.Size(117, 20);
            this.txtInscEstadual.TabIndex = 7;
            this.txtInscEstadual.Validated += new System.EventHandler(this.txtInscEstadual_Validated);
            // 
            // lblInscEstadual
            // 
            this.lblInscEstadual.AutoSize = true;
            this.lblInscEstadual.Location = new System.Drawing.Point(5, 122);
            this.lblInscEstadual.Name = "lblInscEstadual";
            this.lblInscEstadual.Size = new System.Drawing.Size(77, 13);
            this.lblInscEstadual.TabIndex = 6;
            this.lblInscEstadual.Text = "Insc. Estadual:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(88, 93);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(117, 20);
            this.txtCNPJ.TabIndex = 5;
            this.txtCNPJ.Validating += new System.ComponentModel.CancelEventHandler(this.txtCNPJ_Validating);
            this.txtCNPJ.Validated += new System.EventHandler(this.txtCNPJ_Validated);
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.Location = new System.Drawing.Point(4, 96);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(37, 13);
            this.lblCNPJ.TabIndex = 4;
            this.lblCNPJ.Text = "CNPJ:";
            // 
            // txtFantasia
            // 
            this.txtFantasia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorNomeFantasia.SetFormatarNome(this.txtFantasia, true);
            this.txtFantasia.Location = new System.Drawing.Point(88, 67);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(296, 20);
            this.txtFantasia.TabIndex = 3;
            this.txtFantasia.Validated += new System.EventHandler(this.txtFantasia_Validated);
            // 
            // lblFantasia
            // 
            this.lblFantasia.AutoSize = true;
            this.lblFantasia.Location = new System.Drawing.Point(4, 70);
            this.lblFantasia.Name = "lblFantasia";
            this.lblFantasia.Size = new System.Drawing.Size(78, 13);
            this.lblFantasia.TabIndex = 2;
            this.lblFantasia.Text = "Nome fantasia:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(4, 44);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Razão social:";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorRazãoSocial.SetFormatarNome(this.txtNome, true);
            this.txtNome.Location = new System.Drawing.Point(88, 41);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(296, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            // 
            // abrirArquivo
            // 
            this.abrirArquivo.Filter = "Todas as imagens|*.bmp; *.gif; *.jpg; *.jpeg; *.png; *.ico; *.emf; *.wmf";
            this.abrirArquivo.Title = "Inserir foto para pessoa física";
            // 
            // DadosPessoaJurídica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "DadosPessoaJurídica";
            this.Size = new System.Drawing.Size(392, 393);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        //private System.Windows.Forms.PictureBox picFoto;
        private TextBoxCNPJ txtCNPJ;
        private System.Windows.Forms.Label lblCNPJ;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label lblFantasia;
        private System.Windows.Forms.TextBox txtInscEstadual;
        private System.Windows.Forms.Label lblInscEstadual;
        private System.Windows.Forms.TextBox txtInscMunicipal;
        private System.Windows.Forms.Label lblInscMunicipal;
        private System.Windows.Forms.OpenFileDialog abrirArquivo;
        private AMS.TextBox.IntegerTextBox txtCódigo;
        private System.Windows.Forms.CheckBox cmbNumeraçãoAutomática;
        private System.Windows.Forms.Label label4;
        private FormatadorNome formatadorNomeFantasia;
        private FormatadorNome formatadorRazãoSocial;
    }
}
