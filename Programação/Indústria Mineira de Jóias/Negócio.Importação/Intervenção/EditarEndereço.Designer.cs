namespace Apresentação.Importação.Intervenção
{
    partial class EditarEndereço
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
            this.novoEndereço = new Apresentação.Pessoa.Cadastro.DadosEndereço();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndereço = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.painel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Size = new System.Drawing.Size(565, 517);
            this.splitContainer.SplitterDistance = 175;
            // 
            // painel
            // 
            this.painel.Controls.Add(this.label1);
            this.painel.Controls.Add(this.groupBox1);
            this.painel.Controls.Add(this.novoEndereço);
            this.painel.Size = new System.Drawing.Size(386, 402);
            // 
            // novoEndereço
            // 
            this.novoEndereço.AutoSize = true;
            this.novoEndereço.Location = new System.Drawing.Point(3, 164);
            this.novoEndereço.MaximumSize = new System.Drawing.Size(640, 238);
            this.novoEndereço.MinimumSize = new System.Drawing.Size(365, 238);
            this.novoEndereço.Name = "novoEndereço";
            this.novoEndereço.Size = new System.Drawing.Size(365, 238);
            this.novoEndereço.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUF);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBairro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEndereço);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCEP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 133);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do banco de dados antigo";
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(291, 101);
            this.txtUF.Name = "txtUF";
            this.txtUF.ReadOnly = true;
            this.txtUF.Size = new System.Drawing.Size(68, 20);
            this.txtUF.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "UF:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(75, 101);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(180, 20);
            this.txtCidade.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cidade:";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(75, 75);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.ReadOnly = true;
            this.txtBairro.Size = new System.Drawing.Size(284, 20);
            this.txtBairro.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bairro:";
            // 
            // txtEndereço
            // 
            this.txtEndereço.Location = new System.Drawing.Point(75, 49);
            this.txtEndereço.Name = "txtEndereço";
            this.txtEndereço.ReadOnly = true;
            this.txtEndereço.Size = new System.Drawing.Size(284, 20);
            this.txtEndereço.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Endereço:";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(75, 23);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.ReadOnly = true;
            this.txtCEP.Size = new System.Drawing.Size(121, 20);
            this.txtCEP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CEP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Por favor, confirme os dados do endereço:";
            // 
            // EditarEndereço
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 517);
            this.Name = "EditarEndereço";
            this.Text = "EditarEndereço";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.painel.ResumeLayout(false);
            this.painel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Pessoa.Cadastro.DadosEndereço novoEndereço;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEndereço;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label5;
    }
}