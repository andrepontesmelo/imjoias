namespace Apresentação.Financeiro.Venda
{
    partial class ProcurarVendas
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCliente = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.txtVendedor = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.label3 = new System.Windows.Forms.Label();
            this.dataInício = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dataFim = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(170, 20);
            this.lblTítulo.Text = "Procurar por vendas";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(414, 48);
            this.lblDescrição.Text = "Entre com um ou todos os dados abaixo para que a busca por vendas seja realizada." +
    " Caso um campo seja omitido, a busca considerará qualquer valor que o preencha.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.moeda;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vendedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cliente:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(334, 203);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(415, 203);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.AlturaProposta = 60;
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(82, 133);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Pessoa = null;
            this.txtCliente.Size = new System.Drawing.Size(406, 20);
            this.txtCliente.SomenteCadastrado = true;
            this.txtCliente.TabIndex = 6;
            // 
            // txtVendedor
            // 
            this.txtVendedor.AlturaProposta = 60;
            this.txtVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendedor.Funcionários = true;
            this.txtVendedor.Location = new System.Drawing.Point(82, 107);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Pessoa = null;
            this.txtVendedor.Size = new System.Drawing.Size(406, 20);
            this.txtVendedor.SomenteCadastrado = true;
            this.txtVendedor.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Período:";
            // 
            // dataInício
            // 
            this.dataInício.CustomFormat = "ddd dd/MM/yyyy";
            this.dataInício.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataInício.Location = new System.Drawing.Point(82, 159);
            this.dataInício.Name = "dataInício";
            this.dataInício.Size = new System.Drawing.Size(139, 20);
            this.dataInício.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(221, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "a";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataFim
            // 
            this.dataFim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataFim.CustomFormat = "ddd dd/MM/yyyy";
            this.dataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataFim.Location = new System.Drawing.Point(239, 159);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(249, 20);
            this.dataFim.TabIndex = 12;
            // 
            // ProcurarVendas
            // 
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(502, 238);
            this.Controls.Add(this.dataFim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataInício);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.label1);
            this.Name = "ProcurarVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procurar por vendas";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtVendedor, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dataInício, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dataFim, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtVendedor;
        private System.Windows.Forms.Label label2;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtCliente;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dataInício;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dataFim;
    }
}
