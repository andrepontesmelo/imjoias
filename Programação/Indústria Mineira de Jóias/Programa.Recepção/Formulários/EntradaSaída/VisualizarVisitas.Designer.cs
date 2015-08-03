namespace Programa.Recepção.Formulários.EntradaSaída
{
    partial class VisualizarVisitas
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
            this.lst = new Apresentação.Atendimento.Clientes.ListViewVisitantes();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(142, 20);
            this.lblTítulo.Text = "Visualizar visitas";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(480, 48);
            this.lblDescrição.Text = "Visualize as visitas dos últimos 3 dias.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Programa.Recepção.Properties.Resources.botão___pessoas;
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Location = new System.Drawing.Point(12, 96);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(542, 245);
            this.lst.TabIndex = 3;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFechar.Location = new System.Drawing.Point(481, 347);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // VisualizarVisitas
            // 
            this.AcceptButton = this.btnFechar;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(568, 382);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lst);
            this.Name = "VisualizarVisitas";
            this.Text = "Visualizar Visitas";
            this.Controls.SetChildIndex(this.lst, 0);
            this.Controls.SetChildIndex(this.btnFechar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Atendimento.Clientes.ListViewVisitantes lst;
        private System.Windows.Forms.Button btnFechar;
    }
}
