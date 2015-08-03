namespace Apresentação.Financeiro
{
    partial class BalãoMercadoriaInconsistente
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
            this.picAlerta = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAlerta)).BeginInit();
            this.SuspendLayout();
            // 
            // picAlerta
            // 
            this.picAlerta.Image = global::Apresentação.Financeiro.Properties.Resources.warning;
            this.picAlerta.Location = new System.Drawing.Point(12, 12);
            this.picAlerta.Name = "picAlerta";
            this.picAlerta.Size = new System.Drawing.Size(32, 32);
            this.picAlerta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAlerta.TabIndex = 0;
            this.picAlerta.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Referência não relacionada na saída";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 57);
            this.label2.TabIndex = 2;
            this.label2.Text = "Atenção! A referência abaixo não se encontra relacionada na saída desta pessoa. C" +
                "ertifique-se de que ela foi digitada corretamente.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Referência:";
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Location = new System.Drawing.Point(124, 103);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(66, 13);
            this.lblRef.TabIndex = 4;
            this.lblRef.Text = "<referência>";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Location = new System.Drawing.Point(209, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Peso:";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(124, 125);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(42, 13);
            this.lblPeso.TabIndex = 7;
            this.lblPeso.Text = "<peso>";
            // 
            // BalãoMercadoriaInconsistente
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(287, 171);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picAlerta);
            this.Name = "BalãoMercadoriaInconsistente";
            ((System.ComponentModel.ISupportInitialize)(this.picAlerta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAlerta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPeso;
    }
}
