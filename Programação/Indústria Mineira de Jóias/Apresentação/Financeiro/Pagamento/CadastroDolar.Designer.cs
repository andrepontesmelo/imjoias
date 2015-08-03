namespace Apresenta��o.Financeiro.Pagamento
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
            this.txtCota��o = new Apresenta��o.Mercadoria.Cota��o.TxtCota��o();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorEmDolares = new AMS.TextBox.NumericTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
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
            this.groupBox1.Controls.Add(this.txtCota��o);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Size = new System.Drawing.Size(231, 338);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.Controls.SetChildIndex(this.data, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtDescri��o, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkCobrarJuros, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtValor, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkPagamentoPendente, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtCota��o, 0);
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
            // txtDescri��o
            // 
            this.txtDescri��o.Size = new System.Drawing.Size(211, 91);
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(52, 20);
            this.lblT�tulo.Text = "D�lar";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(145, 48);
            this.lblDescri��o.Text = "Pagamento em d�lares";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cota��o:";
            // 
            // txtCota��o
            // 
            this.txtCota��o.AvisarCota��esDesatualizadas = false;
            this.txtCota��o.AvisarCota��esN�oCadastradas = false;
            this.txtCota��o.AvisarNovaCota��o = false;
            this.txtCota��o.Cota��o = null;
            this.txtCota��o.IniciarValorAtual = false;
            this.txtCota��o.Location = new System.Drawing.Point(9, 226);
            this.txtCota��o.MoedaSistema = Entidades.Moeda.MoedaSistema.D�larParalelo;
            this.txtCota��o.Name = "txtCota��o";
            this.txtCota��o.Size = new System.Drawing.Size(208, 20);
            this.txtCota��o.TabIndex = 19;
            this.txtCota��o.Valor = 0D;
            this.txtCota��o.Validated += new System.EventHandler(this.txtCota��o_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "D�lares:";
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
            this.Text = "D�lar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label label4;
        private AMS.TextBox.NumericTextBox txtValorEmDolares;
        private System.Windows.Forms.Label label6;
        private Apresenta��o.Mercadoria.Cota��o.TxtCota��o txtCota��o;
    }
}
