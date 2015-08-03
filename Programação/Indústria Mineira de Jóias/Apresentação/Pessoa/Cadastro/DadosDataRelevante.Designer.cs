namespace Apresentação.Pessoa.Cadastro
{
    partial class DadosDataRelevante
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
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.chkAlerta = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtData
            // 
            this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData.Location = new System.Drawing.Point(0, 0);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(95, 20);
            this.dtData.TabIndex = 0;
            this.dtData.Enter += new System.EventHandler(this.AoFocarControle);
            this.dtData.Validated += new System.EventHandler(this.dtData_Validated);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(101, 0);
            this.txtDescrição.MaxLength = 100;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(203, 20);
            this.txtDescrição.TabIndex = 1;
            this.txtDescrição.Enter += new System.EventHandler(this.AoFocarControle);
            this.txtDescrição.Validated += new System.EventHandler(this.txtDescrição_Validated);
            this.txtDescrição.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescrição_Validating);
            // 
            // chkAlerta
            // 
            this.chkAlerta.AutoSize = true;
            this.chkAlerta.Checked = true;
            this.chkAlerta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlerta.Location = new System.Drawing.Point(0, 26);
            this.chkAlerta.Name = "chkAlerta";
            this.chkAlerta.Size = new System.Drawing.Size(270, 17);
            this.chkAlerta.TabIndex = 2;
            this.chkAlerta.Text = "Mostrar esta data como relevante para vendedores.";
            this.chkAlerta.UseVisualStyleBackColor = true;
            this.chkAlerta.Enter += new System.EventHandler(this.AoFocarControle);
            this.chkAlerta.CheckedChanged += new System.EventHandler(this.chkAlerta_CheckedChanged);
            // 
            // DadosDataRelevante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAlerta);
            this.Controls.Add(this.txtDescrição);
            this.Controls.Add(this.dtData);
            this.Name = "DadosDataRelevante";
            this.Size = new System.Drawing.Size(304, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.CheckBox chkAlerta;
    }
}
