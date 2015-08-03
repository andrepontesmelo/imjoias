namespace Apresenta��o.Administrativo
{
    partial class BaseRelat�rios
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
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.quadroOp��oBalan�o = new Apresenta��o.Formul�rios.QuadroOp��o();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Escolha o relat�rio que deseja visualizar.";
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.Administrativo.Properties.Resources.gravata;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(207, 12);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(569, 70);
            this.t�tuloBaseInferior.TabIndex = 6;
            this.t�tuloBaseInferior.T�tulo = "Administrativo";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.quadroOp��oBalan�o);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(207, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(590, 160);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // quadroOp��oBalan�o
            // 
            this.quadroOp��oBalan�o.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quadroOp��oBalan�o.Descri��o = "Exibe relat�rio com o resumo de mercadorias de consignado.";
            this.quadroOp��oBalan�o.�cone = global::Apresenta��o.Administrativo.Properties.Resources.balan�a_pequena;
            this.quadroOp��oBalan�o.Location = new System.Drawing.Point(3, 3);
            this.quadroOp��oBalan�o.MaximumSize = new System.Drawing.Size(600, 70);
            this.quadroOp��oBalan�o.MinimumSize = new System.Drawing.Size(200, 70);
            this.quadroOp��oBalan�o.Name = "quadroOp��oBalan�o";
            this.quadroOp��oBalan�o.Size = new System.Drawing.Size(295, 70);
            this.quadroOp��oBalan�o.TabIndex = 0;
            this.quadroOp��oBalan�o.T�tulo = "Balan�o";
            this.quadroOp��oBalan�o.Click += new System.EventHandler(this.quadroOp��oBalan�o_Click);
            // 
            // BaseRelat�rios
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Imagem = global::Apresenta��o.Administrativo.Properties.Resources.gravata;
            this.Name = "BaseRelat�rios";
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Apresenta��o.Formul�rios.QuadroOp��o quadroOp��oBalan�o;
    }
}
