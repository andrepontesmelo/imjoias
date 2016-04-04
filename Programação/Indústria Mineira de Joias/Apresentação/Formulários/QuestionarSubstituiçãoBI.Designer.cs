namespace Apresentação.Formulários
{
    partial class QuestionarSubstituiçãoBI
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
            this.txtTítulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(199, 20);
            this.lblTítulo.Text = "Confirmação de usuário";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "A janela está sendo alterada para exibição de uma nova tela.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.eventlogInfo1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Título:";
            // 
            // txtTítulo
            // 
            this.txtTítulo.Location = new System.Drawing.Point(90, 105);
            this.txtTítulo.Name = "txtTítulo";
            this.txtTítulo.ReadOnly = true;
            this.txtTítulo.Size = new System.Drawing.Size(275, 20);
            this.txtTítulo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição:";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Location = new System.Drawing.Point(90, 131);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.ReadOnly = true;
            this.txtDescrição.Size = new System.Drawing.Size(275, 55);
            this.txtDescrição.TabIndex = 6;
            // 
            // btnExibir
            // 
            this.btnExibir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExibir.Location = new System.Drawing.Point(224, 208);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(75, 23);
            this.btnExibir.TabIndex = 7;
            this.btnExibir.Text = "&Exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 208);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // QuestionarSubstituiçãoBI
            // 
            this.AcceptButton = this.btnExibir;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 243);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExibir);
            this.Controls.Add(this.txtDescrição);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTítulo);
            this.Name = "QuestionarSubstituiçãoBI";
            this.Text = "Substituição de tela";
            this.Controls.SetChildIndex(this.txtTítulo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDescrição, 0);
            this.Controls.SetChildIndex(this.btnExibir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTítulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnCancelar;
    }
}
