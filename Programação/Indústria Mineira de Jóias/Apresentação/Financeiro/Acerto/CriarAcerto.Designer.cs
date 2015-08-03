namespace Apresentação.Financeiro.Acerto
{
    partial class CriarAcerto
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
            this.dtPrevisão = new System.Windows.Forms.DateTimePicker();
            this.lblPrevisão = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtDias = new AMS.TextBox.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.botãoLiberarRecurso = new Apresentação.Formulários.BotãoLiberarRecurso();
            this.chkSemPrevisão = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaAcertoHorário = new Apresentação.Financeiro.Acerto.ListaAcertoHorário();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(184, 20);
            this.lblTítulo.Text = "Acerto de consignado";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(554, 48);
            this.lblDescrição.Text = "Entre com a previsão do acerto desta pessoa.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Acerto;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // dtPrevisão
            // 
            this.dtPrevisão.CustomFormat = "ddd, dd \'de\' MMMM \'de\' yyyy \'às\' HH:mm";
            this.dtPrevisão.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPrevisão.Location = new System.Drawing.Point(96, 143);
            this.dtPrevisão.Name = "dtPrevisão";
            this.dtPrevisão.Size = new System.Drawing.Size(232, 20);
            this.dtPrevisão.TabIndex = 17;
            this.dtPrevisão.ValueChanged += new System.EventHandler(this.dtPrevisão_ValueChanged);
            // 
            // lblPrevisão
            // 
            this.lblPrevisão.AutoSize = true;
            this.lblPrevisão.Location = new System.Drawing.Point(39, 146);
            this.lblPrevisão.Name = "lblPrevisão";
            this.lblPrevisão.Size = new System.Drawing.Size(51, 13);
            this.lblPrevisão.TabIndex = 16;
            this.lblPrevisão.Text = "Previsão:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(39, 116);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(45, 13);
            this.lblCliente.TabIndex = 14;
            this.lblCliente.Text = "Pessoa:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(96, 113);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(232, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // txtDias
            // 
            this.txtDias.AllowNegative = true;
            this.txtDias.DigitsInGroup = 0;
            this.txtDias.Flags = 0;
            this.txtDias.Location = new System.Drawing.Point(96, 169);
            this.txtDias.MaxDecimalPlaces = 4;
            this.txtDias.MaxWholeDigits = 9;
            this.txtDias.Name = "txtDias";
            this.txtDias.Prefix = "";
            this.txtDias.RangeMax = 1.7976931348623157E+308D;
            this.txtDias.RangeMin = -1.7976931348623157E+308D;
            this.txtDias.Size = new System.Drawing.Size(66, 20);
            this.txtDias.TabIndex = 18;
            this.txtDias.Text = "1";
            this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDias.TextChanged += new System.EventHandler(this.txtDias_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "dia(s)";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(381, 291);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(300, 291);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // botãoLiberarRecurso
            // 
            this.botãoLiberarRecurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botãoLiberarRecurso.AutoSize = true;
            this.botãoLiberarRecurso.Descrição = "Permite ao funcionário escolher um prazo maior que o padrão definido no sistema.";
            this.botãoLiberarRecurso.Location = new System.Drawing.Point(12, 291);
            this.botãoLiberarRecurso.Name = "botãoLiberarRecurso";
            this.botãoLiberarRecurso.Privilégios = Entidades.Privilégio.Permissão.AlterarDataAcerto;
            this.botãoLiberarRecurso.Recurso = "Liberar maior prazo para acerto";
            this.botãoLiberarRecurso.Size = new System.Drawing.Size(115, 23);
            this.botãoLiberarRecurso.TabIndex = 22;
            this.botãoLiberarRecurso.Texto = "Liberar mais prazo";
            this.botãoLiberarRecurso.LiberarRecurso += new System.EventHandler(this.botãoLiberarRecurso_LiberarRecurso);
            // 
            // chkSemPrevisão
            // 
            this.chkSemPrevisão.AutoSize = true;
            this.chkSemPrevisão.Location = new System.Drawing.Point(238, 172);
            this.chkSemPrevisão.Name = "chkSemPrevisão";
            this.chkSemPrevisão.Size = new System.Drawing.Size(90, 17);
            this.chkSemPrevisão.TabIndex = 23;
            this.chkSemPrevisão.Text = "Sem previsão";
            this.chkSemPrevisão.UseVisualStyleBackColor = true;
            this.chkSemPrevisão.Visible = false;
            this.chkSemPrevisão.CheckedChanged += new System.EventHandler(this.chkSemPrevisão_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listaAcertoHorário);
            this.groupBox1.Location = new System.Drawing.Point(474, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 220);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acertos para esta data";
            // 
            // listaAcertoHorário
            // 
            this.listaAcertoHorário.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaAcertoHorário.AutoScroll = true;
            this.listaAcertoHorário.Clicável = false;
            this.listaAcertoHorário.Location = new System.Drawing.Point(6, 19);
            this.listaAcertoHorário.Name = "listaAcertoHorário";
            this.listaAcertoHorário.Size = new System.Drawing.Size(142, 195);
            this.listaAcertoHorário.TabIndex = 0;
            // 
            // CriarAcerto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 326);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkSemPrevisão);
            this.Controls.Add(this.botãoLiberarRecurso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dtPrevisão);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblPrevisão);
            this.Name = "CriarAcerto";
            this.Text = "";
            this.Controls.SetChildIndex(this.lblPrevisão, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.dtPrevisão, 0);
            this.Controls.SetChildIndex(this.lblCliente, 0);
            this.Controls.SetChildIndex(this.txtDias, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.botãoLiberarRecurso, 0);
            this.Controls.SetChildIndex(this.chkSemPrevisão, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPrevisão;
        private System.Windows.Forms.Label lblPrevisão;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private AMS.TextBox.NumericTextBox txtDias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarRecurso;
        private System.Windows.Forms.CheckBox chkSemPrevisão;
        private System.Windows.Forms.GroupBox groupBox1;
        private ListaAcertoHorário listaAcertoHorário;
    }
}