namespace Apresentação.Financeiro.Coaf
{
    partial class BaseNotificação
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseNotificação));
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listaNotificações = new Apresentação.Financeiro.Coaf.Notificações.ListaNotificações();
            this.listaSaída1 = new Apresentação.Financeiro.Coaf.Lista.ListaSaída();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericTextBox1 = new AMS.TextBox.NumericTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxCPF1 = new Apresentação.Pessoa.TextBoxCPF();
            this.textBoxCNPJ1 = new Apresentação.Pessoa.TextBoxCNPJ();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.currencyTextBox1 = new AMS.TextBox.CurrencyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 478);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Documentos de notificação";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.notificacao;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(705, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Notificações";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chamando atenção.gif");
            this.imageList1.Images.SetKeyName(1, "info.png");
            // 
            // listaNotificações1
            // 
            this.listaNotificações.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaNotificações.Location = new System.Drawing.Point(0, 0);
            this.listaNotificações.Name = "listaNotificações1";
            this.listaNotificações.Size = new System.Drawing.Size(705, 199);
            this.listaNotificações.TabIndex = 7;
            // 
            // listaSaída1
            // 
            this.listaSaída1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaSaída1.Location = new System.Drawing.Point(0, 0);
            this.listaSaída1.Name = "listaSaída1";
            this.listaSaída1.Size = new System.Drawing.Size(705, 78);
            this.listaSaída1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(193, 176);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listaNotificações);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listaSaída1);
            this.splitContainer1.Size = new System.Drawing.Size(705, 281);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.currencyTextBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.textBoxCNPJ1);
            this.groupBox1.Controls.Add(this.textBoxCPF1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.numericTextBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(196, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 91);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notificação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CPF:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CNPJ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Início:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fim:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(502, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Valor:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Alterar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(606, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowNegative = true;
            this.numericTextBox1.DigitsInGroup = 0;
            this.numericTextBox1.Flags = 0;
            this.numericTextBox1.Location = new System.Drawing.Point(76, 19);
            this.numericTextBox1.MaxDecimalPlaces = 4;
            this.numericTextBox1.MaxWholeDigits = 9;
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Prefix = "";
            this.numericTextBox1.RangeMax = 1.7976931348623157E+308D;
            this.numericTextBox1.RangeMin = -1.7976931348623157E+308D;
            this.numericTextBox1.Size = new System.Drawing.Size(82, 20);
            this.numericTextBox1.TabIndex = 9;
            this.numericTextBox1.Text = "1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(76, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(82, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // textBoxCPF1
            // 
            this.textBoxCPF1.Location = new System.Drawing.Point(207, 19);
            this.textBoxCPF1.Name = "textBoxCPF1";
            this.textBoxCPF1.Size = new System.Drawing.Size(150, 21);
            this.textBoxCPF1.TabIndex = 11;
            // 
            // textBoxCNPJ1
            // 
            this.textBoxCNPJ1.Location = new System.Drawing.Point(207, 47);
            this.textBoxCNPJ1.Name = "textBoxCNPJ1";
            this.textBoxCNPJ1.Size = new System.Drawing.Size(150, 23);
            this.textBoxCNPJ1.TabIndex = 12;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(403, 19);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(82, 20);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(403, 47);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(82, 20);
            this.dateTimePicker3.TabIndex = 14;
            // 
            // currencyTextBox1
            // 
            this.currencyTextBox1.AllowNegative = true;
            this.currencyTextBox1.Flags = 7680;
            this.currencyTextBox1.Location = new System.Drawing.Point(504, 47);
            this.currencyTextBox1.MaxWholeDigits = 9;
            this.currencyTextBox1.Name = "currencyTextBox1";
            this.currencyTextBox1.RangeMax = 1.7976931348623157E+308D;
            this.currencyTextBox1.RangeMin = -1.7976931348623157E+308D;
            this.currencyTextBox1.Size = new System.Drawing.Size(77, 20);
            this.currencyTextBox1.TabIndex = 15;
            this.currencyTextBox1.Text = "R$ 1,00";
            // 
            // BaseNotificação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.título);
            this.Name = "BaseNotificação";
            this.Size = new System.Drawing.Size(916, 478);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Formulários.TítuloBaseInferior título;
        private System.Windows.Forms.ImageList imageList1;
        private Notificações.ListaNotificações listaNotificações;
        private Lista.ListaSaída listaSaída1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private AMS.TextBox.CurrencyTextBox currencyTextBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Pessoa.TextBoxCNPJ textBoxCNPJ1;
        private Pessoa.TextBoxCPF textBoxCPF1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private AMS.TextBox.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
