namespace Apresentação.Importação.Intervenção
{
    partial class QuestionarInscPF
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInsc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtÓrgão = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.painel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Size = new System.Drawing.Size(473, 402);
            this.splitContainer.SplitterDistance = 184;
            // 
            // painel
            // 
            this.painel.Controls.Add(this.groupBox2);
            this.painel.Controls.Add(this.groupBox1);
            this.painel.Controls.Add(this.label1);
            this.painel.Size = new System.Drawing.Size(285, 303);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Por favor, verifique o documento de identidade.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInsc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro original";
            // 
            // txtInsc
            // 
            this.txtInsc.Location = new System.Drawing.Point(43, 22);
            this.txtInsc.Multiline = true;
            this.txtInsc.Name = "txtInsc";
            this.txtInsc.ReadOnly = true;
            this.txtInsc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInsc.Size = new System.Drawing.Size(218, 44);
            this.txtInsc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Insc:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtÓrgão);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDI);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 81);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interpretação:";
            // 
            // txtÓrgão
            // 
            this.txtÓrgão.Location = new System.Drawing.Point(90, 50);
            this.txtÓrgão.Name = "txtÓrgão";
            this.txtÓrgão.Size = new System.Drawing.Size(171, 20);
            this.txtÓrgão.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Órgão emissor:";
            // 
            // txtDI
            // 
            this.txtDI.Location = new System.Drawing.Point(90, 24);
            this.txtDI.Name = "txtDI";
            this.txtDI.Size = new System.Drawing.Size(171, 20);
            this.txtDI.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Documento de identidade:";
            // 
            // QuestionarInscPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 402);
            this.Name = "QuestionarInscPF";
            this.Text = "Importação de cliente";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.painel.ResumeLayout(false);
            this.painel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInsc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtÓrgão;
    }
}