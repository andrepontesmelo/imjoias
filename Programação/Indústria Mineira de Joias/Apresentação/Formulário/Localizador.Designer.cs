namespace Apresentação.Formulários
{
    partial class Localizador
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
            this.btnFecharBusca = new System.Windows.Forms.PictureBox();
            this.chkRealçar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharBusca)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFecharBusca
            // 
            this.btnFecharBusca.Image = global::Apresentação.Resource.fechar_busca;
            this.btnFecharBusca.Location = new System.Drawing.Point(3, 3);
            this.btnFecharBusca.Name = "btnFecharBusca";
            this.btnFecharBusca.Size = new System.Drawing.Size(21, 20);
            this.btnFecharBusca.TabIndex = 13;
            this.btnFecharBusca.TabStop = false;
            this.btnFecharBusca.Click += new System.EventHandler(this.btnFecharBusca_Click);
            // 
            // chkRealçar
            // 
            this.chkRealçar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRealçar.AutoSize = true;
            this.chkRealçar.Location = new System.Drawing.Point(230, 3);
            this.chkRealçar.Name = "chkRealçar";
            this.chkRealçar.Size = new System.Drawing.Size(54, 23);
            this.chkRealçar.TabIndex = 16;
            this.chkRealçar.Text = "Realçar";
            this.chkRealçar.UseVisualStyleBackColor = true;
            this.chkRealçar.CheckStateChanged += new System.EventHandler(this.chkRealçar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Localizar:";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(88, 3);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(126, 20);
            this.txtBusca.TabIndex = 14;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // Localizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFecharBusca);
            this.Controls.Add(this.chkRealçar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBusca);
            this.Name = "Localizador";
            this.Size = new System.Drawing.Size(510, 30);
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharBusca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnFecharBusca;
        private System.Windows.Forms.CheckBox chkRealçar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusca;

    }
}
