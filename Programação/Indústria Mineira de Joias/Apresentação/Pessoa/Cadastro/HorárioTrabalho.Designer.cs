namespace Apresentação.Pessoa.Cadastro
{
    partial class HorárioTrabalho
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
            this.tabelaHorário = new Apresentação.Pessoa.Horário.TabelaHorário();
            this.SuspendLayout();
            // 
            // tabelaHorário
            // 
            this.tabelaHorário.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaHorário.Location = new System.Drawing.Point(0, 0);
            this.tabelaHorário.Name = "tabelaHorário";
            this.tabelaHorário.Size = new System.Drawing.Size(392, 408);
            this.tabelaHorário.TabIndex = 0;
            // 
            // HorárioTrabalho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabelaHorário);
            this.MinimumSize = new System.Drawing.Size(392, 408);
            this.Name = "HorárioTrabalho";
            this.Size = new System.Drawing.Size(392, 408);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Pessoa.Horário.TabelaHorário tabelaHorário;
    }
}
