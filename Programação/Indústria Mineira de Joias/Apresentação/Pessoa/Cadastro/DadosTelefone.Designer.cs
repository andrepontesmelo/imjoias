namespace Apresentação.Pessoa.Cadastro
{
    partial class DadosTelefone
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelefone = new Apresentação.Pessoa.TxtTelefone();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDescrição = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.txtObs);
            this.grp.Controls.Add(this.label9);
            this.grp.Controls.Add(this.txtTelefone);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.cmbDescrição);
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(324, 120);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Location = new System.Drawing.Point(86, 72);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(232, 42);
            this.txtObs.TabIndex = 20;
            this.txtObs.Enter += new System.EventHandler(this.AoFocarControle);
            this.txtObs.Validated += new System.EventHandler(this.txtObs_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Observações:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefone.BackColor = System.Drawing.Color.White;
            this.txtTelefone.Location = new System.Drawing.Point(86, 46);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(232, 20);
            this.txtTelefone.TabIndex = 3;
            this.txtTelefone.Enter += new System.EventHandler(this.AoFocarControle);
            this.txtTelefone.Validated += new System.EventHandler(this.txtTelefone_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Telefone:";
            // 
            // cmbDescrição
            // 
            this.cmbDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDescrição.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDescrição.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDescrição.FormattingEnabled = true;
            this.cmbDescrição.Items.AddRange(new object[] {
            "Residencial",
            "Trabalho",
            "Celular"});
            this.cmbDescrição.Location = new System.Drawing.Point(86, 19);
            this.cmbDescrição.Name = "cmbDescrição";
            this.cmbDescrição.Size = new System.Drawing.Size(232, 21);
            this.cmbDescrição.TabIndex = 1;
            this.cmbDescrição.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDescrição_Validating);
            this.cmbDescrição.Validated += new System.EventHandler(this.cmbDescrição_Validated);
            this.cmbDescrição.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição:";
            // 
            // DadosTelefone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.grp);
            this.MaximumSize = new System.Drawing.Size(640, 120);
            this.MinimumSize = new System.Drawing.Size(324, 120);
            this.Name = "DadosTelefone";
            this.Size = new System.Drawing.Size(324, 120);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.ComboBox cmbDescrição;
        private System.Windows.Forms.Label label1;
        private TxtTelefone txtTelefone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label9;
    }
}
