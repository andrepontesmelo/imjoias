namespace Apresenta��o.�lbum.Edi��o
{
    partial class ProcurarMercadoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMercadoria = new Apresenta��o.Mercadoria.TxtMercadoria();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(202, 20);
            this.lblT�tulo.Text = "Procurar por mercadoria";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(213, 48);
            this.lblDescri��o.Text = "Entre com a refer�ncia da mercadoria para procurar por suas fotos.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.�lbum.Edi��o.Properties.Resources.Lupa;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Refer�ncia:";
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.ControlePeso = null;
            this.txtMercadoria.Location = new System.Drawing.Point(107, 109);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Refer�ncia = "";
            this.txtMercadoria.Size = new System.Drawing.Size(141, 20);
            this.txtMercadoria.SomenteCadastrado = true;
            this.txtMercadoria.TabIndex = 4;
            this.txtMercadoria.Refer�nciaConfirmada += new System.EventHandler(this.txtMercadoria_Refer�nciaConfirmada);
            this.txtMercadoria.Refer�nciaAlterada += new System.EventHandler(this.txtMercadoria_Refer�nciaAlterada);
            this.txtMercadoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMercadoria_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(133, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(214, 142);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ProcurarMercadoria
            // 
            this.ClientSize = new System.Drawing.Size(301, 177);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMercadoria);
            this.Controls.Add(this.label1);
            this.Name = "ProcurarMercadoria";
            this.Text = "Manipula��o de mercadoria";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtMercadoria, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Apresenta��o.Mercadoria.TxtMercadoria txtMercadoria;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
    }
}
