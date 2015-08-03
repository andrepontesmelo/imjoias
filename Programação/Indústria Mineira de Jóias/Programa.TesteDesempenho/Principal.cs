using System;
using System.Collections.Generic;
using System.Text;

namespace Programa.TesteDesempenho
{
    class Principal : Apresenta��o.Formul�rios.BaseFormul�rio
    {
        public Principal()
        {
            InitializeComponent();

            if (this.DesignMode) return;

            SubstituirBase(new TesteQuadro(), this);
        }

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
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // Principal
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "Principal";
            this.topo.ResumeLayout(false);
            this.barraBot�es.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
