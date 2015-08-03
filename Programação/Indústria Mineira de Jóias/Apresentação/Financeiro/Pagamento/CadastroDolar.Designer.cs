namespace Apresentação.Financeiro.Pagamento
{
    partial class CadastroDolar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroDolar));
            this.label4 = new System.Windows.Forms.Label();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorEmDolares = new AMS.TextBox.NumericTextBox();
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
            this.txtValor.Size = new System.Drawing.Size(214, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtValorEmDolares);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCotação);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Size = new System.Drawing.Size(231, 338);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.Controls.SetChildIndex(this.data, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtDescrição, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkCobrarJuros, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtValor, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkPagamentoPendente, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtCotação, 0);
            this.groupBox1.Controls.SetChildIndex(this.label6, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtValorEmDolares, 0);
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
            this.btnOk.Location = new System.Drawing.Point(65, 439);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(146, 439);
            // 
            // data
            // 
            this.data.Size = new System.Drawing.Size(214, 20);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Size = new System.Drawing.Size(211, 91);
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(52, 20);
            this.lblTítulo.Text = "Dólar";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(145, 48);
            this.lblDescrição.Text = "Pagamento em dólares";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 210);
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
            this.txtCotação.Location = new System.Drawing.Point(9, 226);
            this.txtCotação.MoedaSistema = Entidades.Moeda.MoedaSistema.DólarParalelo;
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(208, 20);
            this.txtCotação.TabIndex = 19;
            this.txtCotação.Valor = 0D;
            this.txtCotação.Validated += new System.EventHandler(this.txtCotação_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dólares:";
            // 
            // txtValorEmDolares
            // 
            this.txtValorEmDolares.AllowNegative = true;
            this.txtValorEmDolares.DigitsInGroup = 0;
            this.txtValorEmDolares.Flags = 0;
            this.txtValorEmDolares.Location = new System.Drawing.Point(6, 263);
            this.txtValorEmDolares.MaxDecimalPlaces = 4;
            this.txtValorEmDolares.MaxWholeDigits = 9;
            this.txtValorEmDolares.Name = "txtValorEmDolares";
            this.txtValorEmDolares.Prefix = "";
            this.txtValorEmDolares.RangeMax = 1.7976931348623157E+308D;
            this.txtValorEmDolares.RangeMin = -1.7976931348623157E+308D;
            this.txtValorEmDolares.Size = new System.Drawing.Size(211, 20);
            this.txtValorEmDolares.TabIndex = 21;
            this.txtValorEmDolares.Text = "1";
            this.txtValorEmDolares.Validated += new System.EventHandler(this.txtValorEmDolares_Validated);
            // 
            // CadastroDolar
            // 
            this.ClientSize = new System.Drawing.Size(233, 474);
            this.Name = "CadastroDolar";
            this.Text = "Dólar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label label4;
        private AMS.TextBox.NumericTextBox txtValorEmDolares;
        private System.Windows.Forms.Label label6;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
    }
}
