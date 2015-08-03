namespace Apresentação.Financeiro.Pagamento
{
    partial class CadastroOuro
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPeso = new AMS.TextBox.NumericTextBox();
            this.chkOuroMil = new System.Windows.Forms.RadioButton();
            this.chkOuroFundir = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPagamentoPendente
            // 
            this.chkPagamentoPendente.Location = new System.Drawing.Point(2, 315);
            this.chkPagamentoPendente.TabIndex = 4;
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.LightGray;
            this.txtValor.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkOuroFundir);
            this.groupBox1.Controls.Add(this.chkOuroMil);
            this.groupBox1.Controls.Add(this.txtPeso);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCotação);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Size = new System.Drawing.Size(229, 338);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.Controls.SetChildIndex(this.chkCobrarJuros, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtValor, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkPagamentoPendente, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtCotação, 0);
            this.groupBox1.Controls.SetChildIndex(this.label6, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtPeso, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkOuroMil, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkOuroFundir, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Size = new System.Drawing.Size(192, 206);
            // 
            // chkCobrarJuros
            // 
            this.chkCobrarJuros.Location = new System.Drawing.Point(2, 292);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(65, 435);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(146, 435);
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(48, 20);
            this.lblTítulo.Text = "Ouro";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(145, 48);
            this.lblDescrição.Text = "Se é para fundir, valor = peso * cotacao da venda * 0.750 * 0.9.           Se é o" +
                "uro mil, valor = peso * cotacao da venda.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.botão___ouro;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cotação:";
            // 
            // txtCotação
            // 
            this.txtCotação.AvisarCotaçõesDesatualizadas = false;
            this.txtCotação.AvisarCotaçõesNãoCadastradas = false;
            this.txtCotação.AvisarNovaCotação = false;
            this.txtCotação.Cotação = null;
            this.txtCotação.IniciarValorAtual = false;
            this.txtCotação.Location = new System.Drawing.Point(9, 152);
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(217, 20);
            this.txtCotação.TabIndex = 19;
            this.txtCotação.Valor = 0;
            this.txtCotação.Validated += new System.EventHandler(this.txtCotação_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Peso:";
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = true;
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Flags = 0;
            this.txtPeso.Location = new System.Drawing.Point(6, 189);
            this.txtPeso.MaxDecimalPlaces = 4;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308;
            this.txtPeso.RangeMin = -1.7976931348623157E+308;
            this.txtPeso.Size = new System.Drawing.Size(214, 20);
            this.txtPeso.TabIndex = 21;
            this.txtPeso.Text = "1";
            this.txtPeso.Validated += new System.EventHandler(this.txtPeso_Validated);
            // 
            // chkOuroMil
            // 
            this.chkOuroMil.AutoSize = true;
            this.chkOuroMil.Checked = true;
            this.chkOuroMil.Location = new System.Drawing.Point(12, 225);
            this.chkOuroMil.Name = "chkOuroMil";
            this.chkOuroMil.Size = new System.Drawing.Size(64, 17);
            this.chkOuroMil.TabIndex = 22;
            this.chkOuroMil.TabStop = true;
            this.chkOuroMil.Text = "Ouro Mil";
            this.chkOuroMil.UseVisualStyleBackColor = true;
            this.chkOuroMil.CheckedChanged += new System.EventHandler(this.chkOuroMil_CheckedChanged);
            // 
            // chkOuroFundir
            // 
            this.chkOuroFundir.AutoSize = true;
            this.chkOuroFundir.Location = new System.Drawing.Point(106, 225);
            this.chkOuroFundir.Name = "chkOuroFundir";
            this.chkOuroFundir.Size = new System.Drawing.Size(101, 17);
            this.chkOuroFundir.TabIndex = 23;
            this.chkOuroFundir.Text = "Ouro para fundir";
            this.chkOuroFundir.UseVisualStyleBackColor = true;
            this.chkOuroFundir.CheckedChanged += new System.EventHandler(this.chkOuroMil_CheckedChanged);
            // 
            // CadastroOuro
            // 
            this.ClientSize = new System.Drawing.Size(233, 470);
            this.Name = "CadastroOuro";
            this.Text = "Ouro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton chkOuroFundir;
        private System.Windows.Forms.RadioButton chkOuroMil;
        private AMS.TextBox.NumericTextBox txtPeso;
        private System.Windows.Forms.Label label6;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
    }
}
