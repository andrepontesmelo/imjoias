namespace Apresentação.Pessoa.Histórico
{
    partial class Alerta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alerta));
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.txtPessoa = new System.Windows.Forms.TextBox();
            this.txtDigitadoPor = new System.Windows.Forms.TextBox();
            this.lblAutor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDesligar = new System.Windows.Forms.CheckBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(155, 20);
            this.lblTítulo.Text = "Alerta de histórico";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Um funcionário registrou um histórico com alerta para esta operação que você está" +
                " realizando.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // txtTexto
            // 
            this.txtTexto.AcceptsReturn = true;
            this.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexto.Location = new System.Drawing.Point(98, 189);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.ReadOnly = true;
            this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTexto.Size = new System.Drawing.Size(246, 124);
            this.txtTexto.TabIndex = 12;
            // 
            // txtPessoa
            // 
            this.txtPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPessoa.Location = new System.Drawing.Point(98, 111);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.ReadOnly = true;
            this.txtPessoa.Size = new System.Drawing.Size(246, 20);
            this.txtPessoa.TabIndex = 14;
            // 
            // txtDigitadoPor
            // 
            this.txtDigitadoPor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDigitadoPor.Location = new System.Drawing.Point(98, 137);
            this.txtDigitadoPor.Name = "txtDigitadoPor";
            this.txtDigitadoPor.ReadOnly = true;
            this.txtDigitadoPor.Size = new System.Drawing.Size(246, 20);
            this.txtDigitadoPor.TabIndex = 16;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(57, 140);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(35, 13);
            this.lblAutor.TabIndex = 15;
            this.lblAutor.Text = "Autor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pessoa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Texto:";
            // 
            // chkDesligar
            // 
            this.chkDesligar.AutoSize = true;
            this.chkDesligar.Location = new System.Drawing.Point(98, 319);
            this.chkDesligar.Name = "chkDesligar";
            this.chkDesligar.Size = new System.Drawing.Size(119, 17);
            this.chkDesligar.TabIndex = 17;
            this.chkDesligar.Text = "Desligar este alerta.";
            this.chkDesligar.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(98, 163);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(246, 20);
            this.txtData.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Data:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(305, 328);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Alerta
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(392, 363);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkDesligar);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.txtPessoa);
            this.Controls.Add(this.txtDigitadoPor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Alerta";
            this.Text = "Alerta de histórico";
            this.Shown += new System.EventHandler(this.Alerta_Shown);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblAutor, 0);
            this.Controls.SetChildIndex(this.txtDigitadoPor, 0);
            this.Controls.SetChildIndex(this.txtPessoa, 0);
            this.Controls.SetChildIndex(this.txtTexto, 0);
            this.Controls.SetChildIndex(this.chkDesligar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtData, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.TextBox txtPessoa;
        private System.Windows.Forms.TextBox txtDigitadoPor;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDesligar;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Timer timer;
    }
}
