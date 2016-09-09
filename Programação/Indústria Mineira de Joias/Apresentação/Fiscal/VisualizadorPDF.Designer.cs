namespace Apresentação.Fiscal
{
    partial class VisualizadorPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizadorPDF));
            this.axAcroPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(1052, 48);
            // 
            // axAcroPDF
            // 
            this.axAcroPDF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(0, 93);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(1140, 423);
            this.axAcroPDF.TabIndex = 3;
            // 
            // VisualizadorPDF
            // 
            this.ClientSize = new System.Drawing.Size(1140, 516);
            this.Controls.Add(this.axAcroPDF);
            this.Name = "VisualizadorPDF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.axAcroPDF, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
    }
}
