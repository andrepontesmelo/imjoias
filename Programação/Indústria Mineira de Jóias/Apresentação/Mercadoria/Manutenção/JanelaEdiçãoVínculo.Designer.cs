namespace Apresentação.Mercadoria.Manutenção
{
    partial class JanelaEdiçãoVínculo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxComponenteCusto = new Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.CmbComponenteCusto();
            this.txtQuantidade = new AMS.TextBox.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(153, 20);
            this.lblTítulo.Text = "Novo componente";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(157, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.diamond;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxComponenteCusto);
            this.groupBox1.Controls.Add(this.txtQuantidade);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // comboBoxComponenteCusto
            // 
            this.comboBoxComponenteCusto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxComponenteCusto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxComponenteCusto.Componente = null;
            this.comboBoxComponenteCusto.FormattingEnabled = true;
            this.comboBoxComponenteCusto.Location = new System.Drawing.Point(18, 46);
            this.comboBoxComponenteCusto.Name = "comboBoxComponenteCusto";
            this.comboBoxComponenteCusto.Size = new System.Drawing.Size(195, 21);
            this.comboBoxComponenteCusto.TabIndex = 1;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.AllowNegative = true;
            this.txtQuantidade.DigitsInGroup = 0;
            this.txtQuantidade.Flags = 0;
            this.txtQuantidade.Location = new System.Drawing.Point(18, 86);
            this.txtQuantidade.MaxDecimalPlaces = 4;
            this.txtQuantidade.MaxWholeDigits = 9;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Prefix = "";
            this.txtQuantidade.RangeMax = 1.7976931348623157E+308;
            this.txtQuantidade.RangeMin = -1.7976931348623157E+308;
            this.txtQuantidade.Size = new System.Drawing.Size(195, 20);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Componente de custo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(162, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(81, 235);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // JanelaEdiçãoVínculo
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(245, 265);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "JanelaEdiçãoVínculo";
            this.Text = "Componente de Custo";
            this.Load += new System.EventHandler(this.JanelaEdiçãoVínculo_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.CmbComponenteCusto comboBoxComponenteCusto;
        private AMS.TextBox.NumericTextBox txtQuantidade;
    }
}
