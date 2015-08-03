namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class ListaPedidos
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(419, 188);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRecuperação_RunWorkerCompleted);
            // 
            // ListaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "ListaPedidos";
            this.Size = new System.Drawing.Size(419, 188);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.ComponentModel.BackgroundWorker bgRecuperação;

    }
}
