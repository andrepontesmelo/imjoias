using Apresentação.Fiscal.Combobox;

namespace Apresentação.Fiscal
{
    partial class QuadroTipo
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
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.cmbTipo = new Apresentação.Fiscal.Combobox.ComboTipoDocumento();
            this.chkTipo = new System.Windows.Forms.CheckBox();
            this.quadro3.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.cmbTipo);
            this.quadro3.Controls.Add(this.chkTipo);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(0, 0);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(168, 86);
            this.quadro3.TabIndex = 10;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Enabled = false;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(29, 53);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(104, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // chkTipo
            // 
            this.chkTipo.AutoSize = true;
            this.chkTipo.Location = new System.Drawing.Point(7, 30);
            this.chkTipo.Name = "chkTipo";
            this.chkTipo.Size = new System.Drawing.Size(126, 17);
            this.chkTipo.TabIndex = 2;
            this.chkTipo.Text = "Exibir apenas um tipo";
            this.chkTipo.UseVisualStyleBackColor = true;
            this.chkTipo.CheckedChanged += new System.EventHandler(this.chkTipo_CheckedChanged);
            // 
            // QuadroTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro3);
            this.Name = "QuadroTipo";
            this.Size = new System.Drawing.Size(168, 86);
            this.quadro3.ResumeLayout(false);
            this.quadro3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro3;
        private ComboTipoDocumento cmbTipo;
        private System.Windows.Forms.CheckBox chkTipo;
    }
}
