using System;
namespace Apresentação.Usuário.Funcionários
{
    partial class Ramais
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
            this.lst = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRamal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colRamal});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.GridLines = true;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(416, 352);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            this.lst.Resize += new System.EventHandler(this.lst_Resize);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 68;
            // 
            // colRamal
            // 
            this.colRamal.Text = "Ramal";
            this.colRamal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRecuperação_RunWorkerCompleted);
            // 
            // Ramais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst);
            this.Name = "Ramais";
            this.Size = new System.Drawing.Size(416, 352);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colRamal;
        private System.ComponentModel.BackgroundWorker bgRecuperação;
    }
}
