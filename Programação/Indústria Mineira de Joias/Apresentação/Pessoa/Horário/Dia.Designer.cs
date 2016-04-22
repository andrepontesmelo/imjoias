namespace Apresentação.Pessoa.Horário
{
    partial class Dia
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
            this.lblDia = new System.Windows.Forms.Label();
            this.controleHorário = new Apresentação.Pessoa.Horário.ControleHorário();
            this.SuspendLayout();
            // 
            // lblDia
            // 
            this.lblDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDia.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDia.Location = new System.Drawing.Point(3, 2);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(144, 28);
            this.lblDia.TabIndex = 0;
            this.lblDia.Text = "Dia da semana";
            this.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDia.UseMnemonic = false;
            // 
            // controleHorário
            // 
            this.controleHorário.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.controleHorário.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controleHorário.HoraFinal = ((ushort)(19));
            this.controleHorário.HoraInicial = ((ushort)(7));
            this.controleHorário.Location = new System.Drawing.Point(3, 35);
            this.controleHorário.Name = "controleHorário";
            this.controleHorário.Size = new System.Drawing.Size(143, 112);
            this.controleHorário.TabIndex = 1;
            // 
            // Dia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controleHorário);
            this.Controls.Add(this.lblDia);
            this.Name = "Dia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDia;
        private ControleHorário controleHorário;
    }
}
