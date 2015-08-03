namespace Apresentação.Importação
{
    partial class Ranking
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
            this.lista = new System.Windows.Forms.ListView();
            this.colFuncionário = new System.Windows.Forms.ColumnHeader();
            this.colIntervenções = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFuncionário,
            this.colIntervenções});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(283, 290);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Colaborador";
            this.colFuncionário.Width = 171;
            // 
            // colIntervenções
            // 
            this.colIntervenções.Text = "Intervenções";
            this.colIntervenções.Width = 97;
            // 
            // Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 290);
            this.Controls.Add(this.lista);
            this.Name = "Ranking";
            this.Text = "Ranking";
            this.Resize += new System.EventHandler(this.Ranking_Resize);
            this.Load += new System.EventHandler(this.Ranking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colFuncionário;
        private System.Windows.Forms.ColumnHeader colIntervenções;
    }
}