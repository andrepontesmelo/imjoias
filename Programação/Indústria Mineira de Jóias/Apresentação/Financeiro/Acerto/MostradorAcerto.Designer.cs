﻿namespace Apresentação.Financeiro.Acerto
{
    partial class MostradorAcerto
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
            this.SuspendLayout();
            // 
            // MostradorAcerto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DoubleBuffered = true;
            this.Name = "MostradorAcerto";
            this.Size = new System.Drawing.Size(278, 84);
            this.Resize += new System.EventHandler(this.MostradorAcerto_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MostradorAcerto_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
