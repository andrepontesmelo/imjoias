namespace Apresentação.Financeiro.Venda
{
    partial class JanelaPeríodo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataFim = new System.Windows.Forms.DateTimePicker();
            this.dataInício = new System.Windows.Forms.DateTimePicker();
            this.optParcial = new System.Windows.Forms.RadioButton();
            this.optTotal = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(164, 20);
            this.lblTítulo.Text = "Seleção do período";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(238, 48);
            this.lblDescrição.Text = "Só serão exibidas as vendas dentro do período especificado";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.calendário___inclinado;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataFim);
            this.groupBox1.Controls.Add(this.dataInício);
            this.groupBox1.Controls.Add(this.optParcial);
            this.groupBox1.Controls.Add(this.optTotal);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 120);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exibir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Início:";
            // 
            // dataFim
            // 
            this.dataFim.Enabled = false;
            this.dataFim.Location = new System.Drawing.Point(60, 91);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(236, 20);
            this.dataFim.TabIndex = 3;
            // 
            // dataInício
            // 
            this.dataInício.Enabled = false;
            this.dataInício.Location = new System.Drawing.Point(60, 65);
            this.dataInício.Name = "dataInício";
            this.dataInício.Size = new System.Drawing.Size(236, 20);
            this.dataInício.TabIndex = 2;
            // 
            // optParcial
            // 
            this.optParcial.AutoSize = true;
            this.optParcial.Location = new System.Drawing.Point(6, 42);
            this.optParcial.Name = "optParcial";
            this.optParcial.Size = new System.Drawing.Size(158, 17);
            this.optParcial.TabIndex = 1;
            this.optParcial.Text = "Somente dentro do período:";
            this.optParcial.UseVisualStyleBackColor = true;
            this.optParcial.CheckedChanged += new System.EventHandler(this.optParcial_CheckedChanged);
            // 
            // optTotal
            // 
            this.optTotal.AutoSize = true;
            this.optTotal.Checked = true;
            this.optTotal.Location = new System.Drawing.Point(6, 19);
            this.optTotal.Name = "optTotal";
            this.optTotal.Size = new System.Drawing.Size(107, 17);
            this.optTotal.TabIndex = 0;
            this.optTotal.TabStop = true;
            this.optTotal.Text = "Todas as vendas";
            this.optTotal.UseVisualStyleBackColor = true;
            this.optTotal.CheckedChanged += new System.EventHandler(this.optTotal_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(158, 222);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(239, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // JanelaPeríodo
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(326, 251);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Name = "JanelaPeríodo";
            this.Text = "Parâmetros de exibição";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optParcial;
        private System.Windows.Forms.RadioButton optTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dataFim;
        private System.Windows.Forms.DateTimePicker dataInício;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}
