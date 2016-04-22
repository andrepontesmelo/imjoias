namespace Apresentação.Financeiro.Cotação
{
    partial class RegistrarCotação
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResponsável = new System.Windows.Forms.TextBox();
            this.txtCotação = new AMS.TextBox.CurrencyTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(218, 20);
            this.lblTítulo.Text = "Registrar cotação do ouro";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(273, 48);
            this.lblDescrição.Text = "Entre com a nova cotação a ser cadastrada.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.botão___ouro;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Responsável:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cotação:";
            // 
            // txtResponsável
            // 
            this.txtResponsável.Location = new System.Drawing.Point(109, 103);
            this.txtResponsável.Name = "txtResponsável";
            this.txtResponsável.ReadOnly = true;
            this.txtResponsável.Size = new System.Drawing.Size(219, 20);
            this.txtResponsável.TabIndex = 1;
            // 
            // txtCotação
            // 
            this.txtCotação.AllowNegative = true;
            this.txtCotação.Flags = 7680;
            this.txtCotação.Location = new System.Drawing.Point(109, 154);
            this.txtCotação.MaxWholeDigits = 9;
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.RangeMax = 1.7976931348623157E+308;
            this.txtCotação.RangeMin = -1.7976931348623157E+308;
            this.txtCotação.Size = new System.Drawing.Size(219, 20);
            this.txtCotação.TabIndex = 7;
            this.txtCotação.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCotação_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(193, 197);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(274, 197);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // data
            // 
            this.data.CustomFormat = "dd\'/\'MM\'/\'yyyy HH\':\'mm";
            this.data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.data.Location = new System.Drawing.Point(109, 129);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(219, 20);
            this.data.TabIndex = 3;
            // 
            // RegistrarCotação
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(361, 232);
            this.Controls.Add(this.data);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCotação);
            this.Controls.Add(this.txtResponsável);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "RegistrarCotação";
            this.Text = "Cotação do Ouro";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtResponsável, 0);
            this.Controls.SetChildIndex(this.txtCotação, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.data, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResponsável;
        private AMS.TextBox.CurrencyTextBox txtCotação;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker data;
    }
}
