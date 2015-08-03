namespace Apresentação.Importação.Intervenção
{
    partial class QuestionarTipoPessoa
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
            this.lblDescrição = new System.Windows.Forms.Label();
            this.optFísica = new System.Windows.Forms.RadioButton();
            this.optJurídica = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.painel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Size = new System.Drawing.Size(471, 367);
            // 
            // painel
            // 
            this.painel.Controls.Add(this.textBox1);
            this.painel.Controls.Add(this.label1);
            this.painel.Controls.Add(this.optJurídica);
            this.painel.Controls.Add(this.optFísica);
            this.painel.Controls.Add(this.lblDescrição);
            this.painel.Size = new System.Drawing.Size(288, 252);
            // 
            // lblDescrição
            // 
            this.lblDescrição.Location = new System.Drawing.Point(14, 12);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(260, 90);
            this.lblDescrição.TabIndex = 0;
            this.lblDescrição.Text = "Não foi possível determinar se o cliente ao lado é pessoa física ou jurídica.\r\n\r\n" +
                "Por favor, verifique o tipo de pessoa a ser cadastrado.";
            // 
            // optFísica
            // 
            this.optFísica.AutoSize = true;
            this.optFísica.Location = new System.Drawing.Point(34, 105);
            this.optFísica.Name = "optFísica";
            this.optFísica.Size = new System.Drawing.Size(89, 17);
            this.optFísica.TabIndex = 1;
            this.optFísica.TabStop = true;
            this.optFísica.Text = "Pessoa física";
            this.optFísica.UseVisualStyleBackColor = true;
            // 
            // optJurídica
            // 
            this.optJurídica.AutoSize = true;
            this.optJurídica.Location = new System.Drawing.Point(34, 128);
            this.optJurídica.Name = "optJurídica";
            this.optJurídica.Size = new System.Drawing.Size(98, 17);
            this.optJurídica.TabIndex = 2;
            this.optJurídica.TabStop = true;
            this.optJurídica.Text = "Pessoa jurídica";
            this.optJurídica.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 211);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(213, 20);
            this.textBox1.TabIndex = 6;
            // 
            // QuestionarTipoPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 367);
            this.Name = "QuestionarTipoPessoa";
            this.Text = "QuestionarTipoPessoa";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.painel.ResumeLayout(false);
            this.painel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescrição;
        private System.Windows.Forms.RadioButton optJurídica;
        private System.Windows.Forms.RadioButton optFísica;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}