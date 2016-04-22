namespace Apresentação.Pessoa.Histórico
{
    partial class EditarHistórico
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
            this.txtPessoa = new System.Windows.Forms.TextBox();
            this.lblAutor = new System.Windows.Forms.Label();
            this.txtDigitadoPor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpComportamento = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkAlertarVenda = new System.Windows.Forms.CheckBox();
            this.chkAlertarSaída = new System.Windows.Forms.CheckBox();
            this.chkAlertarCorreio = new System.Windows.Forms.CheckBox();
            this.chkAlertarConserto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.grpComportamento.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(214, 20);
            this.lblTítulo.Text = "Nova entrada no histórico";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Digite os dados para a nova entrada no histórico.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.NewCardHS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pessoa:";
            // 
            // txtPessoa
            // 
            this.txtPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPessoa.Location = new System.Drawing.Point(96, 106);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.ReadOnly = true;
            this.txtPessoa.Size = new System.Drawing.Size(246, 20);
            this.txtPessoa.TabIndex = 8;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(55, 135);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(35, 13);
            this.lblAutor.TabIndex = 9;
            this.lblAutor.Text = "Autor:";
            // 
            // txtDigitadoPor
            // 
            this.txtDigitadoPor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDigitadoPor.Location = new System.Drawing.Point(96, 132);
            this.txtDigitadoPor.Name = "txtDigitadoPor";
            this.txtDigitadoPor.ReadOnly = true;
            this.txtDigitadoPor.Size = new System.Drawing.Size(246, 20);
            this.txtDigitadoPor.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto:";
            // 
            // txtTexto
            // 
            this.txtTexto.AcceptsReturn = true;
            this.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexto.Location = new System.Drawing.Point(96, 158);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTexto.Size = new System.Drawing.Size(246, 98);
            this.txtTexto.TabIndex = 4;
            this.txtTexto.Validated += new System.EventHandler(this.txtTexto_Validated);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(224, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 401);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpComportamento
            // 
            this.grpComportamento.Controls.Add(this.flowLayoutPanel1);
            this.grpComportamento.Location = new System.Drawing.Point(33, 268);
            this.grpComportamento.Name = "grpComportamento";
            this.grpComportamento.Size = new System.Drawing.Size(333, 118);
            this.grpComportamento.TabIndex = 11;
            this.grpComportamento.TabStop = false;
            this.grpComportamento.Text = "Comportamento";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarVenda);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarSaída);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarCorreio);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarConserto);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 94);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkAlertarVenda
            // 
            this.chkAlertarVenda.AutoSize = true;
            this.chkAlertarVenda.Location = new System.Drawing.Point(3, 3);
            this.chkAlertarVenda.Name = "chkAlertarVenda";
            this.chkAlertarVenda.Size = new System.Drawing.Size(222, 17);
            this.chkAlertarVenda.TabIndex = 16;
            this.chkAlertarVenda.Text = "Alertar funcionário ao registrar uma venda";
            this.chkAlertarVenda.UseVisualStyleBackColor = true;
            this.chkAlertarVenda.CheckedChanged += new System.EventHandler(this.chkAlertarVenda_CheckedChanged);
            // 
            // chkAlertarSaída
            // 
            this.chkAlertarSaída.AutoSize = true;
            this.chkAlertarSaída.Location = new System.Drawing.Point(3, 26);
            this.chkAlertarSaída.Name = "chkAlertarSaída";
            this.chkAlertarSaída.Size = new System.Drawing.Size(292, 17);
            this.chkAlertarSaída.TabIndex = 17;
            this.chkAlertarSaída.Text = "Alertar funcionário ao registrar uma saída de consignado";
            this.chkAlertarSaída.UseVisualStyleBackColor = true;
            this.chkAlertarSaída.CheckedChanged += new System.EventHandler(this.chkAlertarSaída_CheckedChanged);
            // 
            // chkAlertarCorreio
            // 
            this.chkAlertarCorreio.AutoSize = true;
            this.chkAlertarCorreio.Location = new System.Drawing.Point(3, 49);
            this.chkAlertarCorreio.Name = "chkAlertarCorreio";
            this.chkAlertarCorreio.Size = new System.Drawing.Size(293, 17);
            this.chkAlertarCorreio.TabIndex = 18;
            this.chkAlertarCorreio.Text = "Alertar funcionário ao iniciar despachamento pelo correio";
            this.chkAlertarCorreio.UseVisualStyleBackColor = true;
            this.chkAlertarCorreio.CheckedChanged += new System.EventHandler(this.chkAlertarCorreio_CheckedChanged);
            // 
            // chkAlertarConserto
            // 
            this.chkAlertarConserto.AutoSize = true;
            this.chkAlertarConserto.Location = new System.Drawing.Point(3, 72);
            this.chkAlertarConserto.Name = "chkAlertarConserto";
            this.chkAlertarConserto.Size = new System.Drawing.Size(227, 17);
            this.chkAlertarConserto.TabIndex = 19;
            this.chkAlertarConserto.Text = "Alertar funcionário ao registrar um conserto";
            this.chkAlertarConserto.UseVisualStyleBackColor = true;
            this.chkAlertarConserto.CheckedChanged += new System.EventHandler(this.chkAlertarConserto_CheckedChanged);
            // 
            // EditarHistórico
            // 
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 436);
            this.Controls.Add(this.grpComportamento);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPessoa);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDigitadoPor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "EditarHistórico";
            this.Text = "Editar histórico";
            this.Load += new System.EventHandler(this.EditarHistórico_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblAutor, 0);
            this.Controls.SetChildIndex(this.txtDigitadoPor, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.txtPessoa, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtTexto, 0);
            this.Controls.SetChildIndex(this.grpComportamento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.grpComportamento.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPessoa;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtDigitadoPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpComportamento;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkAlertarVenda;
        private System.Windows.Forms.CheckBox chkAlertarSaída;
        private System.Windows.Forms.CheckBox chkAlertarCorreio;
        private System.Windows.Forms.CheckBox chkAlertarConserto;
    }
}
