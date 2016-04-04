namespace Apresentação.Financeiro.Cotação
{
    partial class EditarMoeda
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbComponente = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.picMoeda = new System.Windows.Forms.PictureBox();
            this.lnkÍcone = new System.Windows.Forms.LinkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCasasDecimais = new AMS.TextBox.IntegerTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoeda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(116, 20);
            this.lblTítulo.Text = "Editar moeda";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Digite os dados sobre a moeda.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.moeda;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(103, 113);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 20);
            this.txtNome.TabIndex = 4;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "Componente de custo:";
            // 
            // cmbComponente
            // 
            this.cmbComponente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbComponente.DisplayMember = "Nome";
            this.cmbComponente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComponente.FormattingEnabled = true;
            this.cmbComponente.Location = new System.Drawing.Point(103, 139);
            this.cmbComponente.Name = "cmbComponente";
            this.cmbComponente.Size = new System.Drawing.Size(250, 21);
            this.cmbComponente.TabIndex = 8;
            this.toolTip.SetToolTip(this.cmbComponente, "Componente de custo cujo valor será vinculado à cotação vigente desta moeda.");
            this.cmbComponente.SelectedIndexChanged += new System.EventHandler(this.cmbComponente_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(224, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 228);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // picMoeda
            // 
            this.picMoeda.Location = new System.Drawing.Point(103, 192);
            this.picMoeda.Name = "picMoeda";
            this.picMoeda.Size = new System.Drawing.Size(250, 29);
            this.picMoeda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMoeda.TabIndex = 12;
            this.picMoeda.TabStop = false;
            // 
            // lnkÍcone
            // 
            this.lnkÍcone.AutoSize = true;
            this.lnkÍcone.Location = new System.Drawing.Point(27, 199);
            this.lnkÍcone.Name = "lnkÍcone";
            this.lnkÍcone.Size = new System.Drawing.Size(37, 13);
            this.lnkÍcone.TabIndex = 13;
            this.lnkÍcone.TabStop = true;
            this.lnkÍcone.Text = "Ícone:";
            this.lnkÍcone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkÍcone_LinkClicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Imagens|*.jpg;*.gif;*.png;*.bmp;*.ico";
            this.openFileDialog.Title = "Importar ícone para moeda";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "Casas decimais:";
            // 
            // txtCasasDecimais
            // 
            this.txtCasasDecimais.AllowNegative = false;
            this.txtCasasDecimais.DigitsInGroup = 0;
            this.txtCasasDecimais.Flags = 65536;
            this.txtCasasDecimais.Location = new System.Drawing.Point(103, 166);
            this.txtCasasDecimais.MaxDecimalPlaces = 0;
            this.txtCasasDecimais.MaxWholeDigits = 9;
            this.txtCasasDecimais.Name = "txtCasasDecimais";
            this.txtCasasDecimais.Prefix = "";
            this.txtCasasDecimais.RangeMax = 255;
            this.txtCasasDecimais.RangeMin = 0;
            this.txtCasasDecimais.Size = new System.Drawing.Size(43, 20);
            this.txtCasasDecimais.TabIndex = 15;
            this.txtCasasDecimais.Text = "2";
            this.txtCasasDecimais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCasasDecimais.Validated += new System.EventHandler(this.txtCasasDecimais_Validated);
            // 
            // EditarMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 263);
            this.Controls.Add(this.txtCasasDecimais);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkÍcone);
            this.Controls.Add(this.picMoeda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbComponente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Name = "EditarMoeda";
            this.Text = "Editar moeda";
            this.Shown += new System.EventHandler(this.EditarMoeda_Shown);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbComponente, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.picMoeda, 0);
            this.Controls.SetChildIndex(this.lnkÍcone, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCasasDecimais, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoeda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbComponente;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox picMoeda;
        private System.Windows.Forms.LinkLabel lnkÍcone;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private AMS.TextBox.IntegerTextBox txtCasasDecimais;
    }
}