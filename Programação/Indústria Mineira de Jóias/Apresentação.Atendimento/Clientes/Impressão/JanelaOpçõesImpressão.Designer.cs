namespace Apresentação.Atendimento.Clientes.Impressão
{
    partial class JanelaOpçõesImpressão
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaOpçõesImpressão));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optEndereco = new System.Windows.Forms.RadioButton();
            this.optNome = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbRegião = new Apresentação.Pessoa.Endereço.ComboBoxRegião();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(189, 20);
            this.lblTítulo.Text = "Configure a impressão";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(218, 48);
            this.lblDescrição.Text = "Quais clientes deseja imprimir ? ";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(138, 227);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(219, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.optEndereco);
            this.groupBox1.Controls.Add(this.optNome);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordem dos clientes";
            // 
            // optEndereco
            // 
            this.optEndereco.AutoSize = true;
            this.optEndereco.Location = new System.Drawing.Point(9, 42);
            this.optEndereco.Name = "optEndereco";
            this.optEndereco.Size = new System.Drawing.Size(71, 17);
            this.optEndereco.TabIndex = 1;
            this.optEndereco.Text = "Endereço";
            this.optEndereco.UseVisualStyleBackColor = true;
            // 
            // optNome
            // 
            this.optNome.AutoSize = true;
            this.optNome.Checked = true;
            this.optNome.Location = new System.Drawing.Point(9, 19);
            this.optNome.Name = "optNome";
            this.optNome.Size = new System.Drawing.Size(53, 17);
            this.optNome.TabIndex = 0;
            this.optNome.TabStop = true;
            this.optNome.Text = "Nome";
            this.optNome.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbRegião);
            this.groupBox2.Location = new System.Drawing.Point(12, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 51);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Região";
            // 
            // cmbRegião
            // 
            this.cmbRegião.Location = new System.Drawing.Point(9, 19);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Região = null;
            this.cmbRegião.Size = new System.Drawing.Size(209, 21);
            this.cmbRegião.TabIndex = 0;
            // 
            // JanelaOpçõesImpressão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 258);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Name = "JanelaOpçõesImpressão";
            this.Text = "Impressão";
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optNome;
        private System.Windows.Forms.RadioButton optEndereco;
        private System.Windows.Forms.GroupBox groupBox2;
        private Apresentação.Pessoa.Endereço.ComboBoxRegião cmbRegião;
    }
}