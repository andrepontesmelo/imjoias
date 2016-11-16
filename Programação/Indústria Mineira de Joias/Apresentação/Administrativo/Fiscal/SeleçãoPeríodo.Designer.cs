namespace Apresentação.Administrativo.Fiscal
{
    partial class SeleçãoPeríodo
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataFinal = new AMS.TextBox.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataInicial = new AMS.TextBox.DateTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fim:";
            // 
            // dataFinal
            // 
            this.dataFinal.Flags = 65536;
            this.dataFinal.Location = new System.Drawing.Point(171, 0);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dataFinal.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dataFinal.Size = new System.Drawing.Size(72, 20);
            this.dataFinal.TabIndex = 19;
            this.dataFinal.Text = "04/11/2016";
            this.dataFinal.Validating += new System.ComponentModel.CancelEventHandler(this.dataFinal_Validating);
            this.dataFinal.Validated += new System.EventHandler(this.dataFinal_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Início:";
            // 
            // dataInicial
            // 
            this.dataInicial.Flags = 65536;
            this.dataInicial.Location = new System.Drawing.Point(43, 0);
            this.dataInicial.Name = "dataInicial";
            this.dataInicial.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dataInicial.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dataInicial.Size = new System.Drawing.Size(72, 20);
            this.dataInicial.TabIndex = 17;
            this.dataInicial.Text = "04/11/2016";
            this.dataInicial.Validating += new System.ComponentModel.CancelEventHandler(this.dataInicial_Validating);
            this.dataInicial.Validated += new System.EventHandler(this.dataInicial_Validated);
            // 
            // SeleçãoPeríodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataInicial);
            this.Name = "SeleçãoPeríodo";
            this.Size = new System.Drawing.Size(246, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private AMS.TextBox.DateTextBox dataFinal;
        private System.Windows.Forms.Label label2;
        private AMS.TextBox.DateTextBox dataInicial;
    }
}
