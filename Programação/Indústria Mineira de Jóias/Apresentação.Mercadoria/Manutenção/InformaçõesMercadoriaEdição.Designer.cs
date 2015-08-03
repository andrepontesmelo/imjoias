namespace Apresentação.Mercadoria.Manutenção
{
    partial class InformaçõesMercadoriaEdição
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkForaDeLinha = new System.Windows.Forms.CheckBox();
            this.chkDePeso = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReferência = new Apresentação.Mercadoria.TxtMercadoria();
            this.txtPeso = new Apresentação.Mercadoria.TxtPeso();
            this.txtTeor = new AMS.TextBox.IntegerTextBox();
            this.txtGrupo = new AMS.TextBox.IntegerTextBox();
            this.cmbFaixa = new Apresentação.Mercadoria.CmbFaixa();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Descrição:";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(17, 61);
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(442, 20);
            this.txtDescrição.TabIndex = 11;
            this.txtDescrição.Validated += new System.EventHandler(this.txtDescrição_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Grupo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Faixa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Teor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Peso:";
            // 
            // chkForaDeLinha
            // 
            this.chkForaDeLinha.AutoSize = true;
            this.chkForaDeLinha.Location = new System.Drawing.Point(156, 25);
            this.chkForaDeLinha.Name = "chkForaDeLinha";
            this.chkForaDeLinha.Size = new System.Drawing.Size(87, 17);
            this.chkForaDeLinha.TabIndex = 19;
            this.chkForaDeLinha.Text = "Fora de linha";
            this.chkForaDeLinha.UseVisualStyleBackColor = true;
            this.chkForaDeLinha.CheckedChanged += new System.EventHandler(this.chkForaDeLinha_CheckedChanged);
            // 
            // chkDePeso
            // 
            this.chkDePeso.AutoSize = true;
            this.chkDePeso.Location = new System.Drawing.Point(249, 25);
            this.chkDePeso.Name = "chkDePeso";
            this.chkDePeso.Size = new System.Drawing.Size(67, 17);
            this.chkDePeso.TabIndex = 20;
            this.chkDePeso.Text = "De Peso";
            this.chkDePeso.UseVisualStyleBackColor = true;
            this.chkDePeso.CheckedChanged += new System.EventHandler(this.chkDePeso_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Referência";
            // 
            // txtReferência
            // 
            this.txtReferência.Enabled = false;
            this.txtReferência.Location = new System.Drawing.Point(17, 22);
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Referência = "";
            this.txtReferência.Size = new System.Drawing.Size(133, 20);
            this.txtReferência.TabIndex = 24;
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = true;
            this.txtPeso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Flags = 0;
            this.txtPeso.Location = new System.Drawing.Point(156, 140);
            this.txtPeso.MaxDecimalPlaces = 4;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308;
            this.txtPeso.RangeMin = -1.7976931348623157E+308;
            this.txtPeso.Size = new System.Drawing.Size(303, 20);
            this.txtPeso.TabIndex = 25;
            this.txtPeso.Validated += new System.EventHandler(this.txtPeso_Validated);
            // 
            // txtTeor
            // 
            this.txtTeor.AllowNegative = true;
            this.txtTeor.DigitsInGroup = 0;
            this.txtTeor.Flags = 0;
            this.txtTeor.Location = new System.Drawing.Point(18, 140);
            this.txtTeor.MaxDecimalPlaces = 0;
            this.txtTeor.MaxWholeDigits = 9;
            this.txtTeor.Name = "txtTeor";
            this.txtTeor.Prefix = "";
            this.txtTeor.RangeMax = 1.7976931348623157E+308;
            this.txtTeor.RangeMin = -1.7976931348623157E+308;
            this.txtTeor.Size = new System.Drawing.Size(132, 20);
            this.txtTeor.TabIndex = 26;
            this.txtTeor.Validated += new System.EventHandler(this.txtTeor_Validated);
            // 
            // txtGrupo
            // 
            this.txtGrupo.AllowNegative = true;
            this.txtGrupo.DigitsInGroup = 0;
            this.txtGrupo.Flags = 0;
            this.txtGrupo.Location = new System.Drawing.Point(18, 101);
            this.txtGrupo.MaxDecimalPlaces = 0;
            this.txtGrupo.MaxWholeDigits = 9;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Prefix = "";
            this.txtGrupo.RangeMax = 1.7976931348623157E+308;
            this.txtGrupo.RangeMin = -1.7976931348623157E+308;
            this.txtGrupo.Size = new System.Drawing.Size(132, 20);
            this.txtGrupo.TabIndex = 27;
            this.txtGrupo.TextChanged += new System.EventHandler(this.txtGrupo_TextChanged);
            // 
            // cmbFaixa
            // 
            this.cmbFaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaixa.FormattingEnabled = true;
            this.cmbFaixa.Location = new System.Drawing.Point(156, 100);
            this.cmbFaixa.Name = "cmbFaixa";
            this.cmbFaixa.Size = new System.Drawing.Size(303, 21);
            this.cmbFaixa.TabIndex = 28;
            this.cmbFaixa.SelectedIndexChanged += new System.EventHandler(cmbFaixa_SelectedIndexChanged);
            // 
            // InformaçõesMercadoriaEdição
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbFaixa);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.txtTeor);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtReferência);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkDePeso);
            this.Controls.Add(this.chkForaDeLinha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescrição);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "InformaçõesMercadoriaEdição";
            this.Size = new System.Drawing.Size(472, 177);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkForaDeLinha;
        private System.Windows.Forms.CheckBox chkDePeso;
        private System.Windows.Forms.Label label6;
        private TxtMercadoria txtReferência;
        private TxtPeso txtPeso;
        private AMS.TextBox.IntegerTextBox txtTeor;
        private AMS.TextBox.IntegerTextBox txtGrupo;
        private CmbFaixa cmbFaixa;
    }
}
