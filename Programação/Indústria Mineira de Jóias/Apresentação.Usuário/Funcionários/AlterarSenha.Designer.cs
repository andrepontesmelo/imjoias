namespace Apresentação.Usuário.Funcionários
{
    partial class AlterarSenha
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
            this.txtSenhaAnterior = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.txtConfirmação = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(111, 20);
            this.lblTítulo.Text = "Editar senha";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(189, 48);
            this.lblDescrição.Text = "Entre com os dados necessários para alteração de senha.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Usuário.Properties.Resources.keys;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Senha anterior:";
            // 
            // txtSenhaAnterior
            // 
            this.txtSenhaAnterior.Location = new System.Drawing.Point(110, 108);
            this.txtSenhaAnterior.Name = "txtSenhaAnterior";
            this.txtSenhaAnterior.Size = new System.Drawing.Size(139, 20);
            this.txtSenhaAnterior.TabIndex = 4;
            this.txtSenhaAnterior.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nova senha:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 50);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmação da nova senha:";
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Location = new System.Drawing.Point(110, 134);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(139, 20);
            this.txtNovaSenha.TabIndex = 7;
            this.txtNovaSenha.UseSystemPasswordChar = true;
            // 
            // txtConfirmação
            // 
            this.txtConfirmação.Location = new System.Drawing.Point(110, 160);
            this.txtConfirmação.Name = "txtConfirmação";
            this.txtConfirmação.Size = new System.Drawing.Size(139, 20);
            this.txtConfirmação.TabIndex = 8;
            this.txtConfirmação.UseSystemPasswordChar = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(110, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(190, 198);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // AlterarSenha
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(277, 233);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtConfirmação);
            this.Controls.Add(this.txtNovaSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSenhaAnterior);
            this.Name = "AlterarSenha";
            this.Text = "Editar senha";
            this.Controls.SetChildIndex(this.txtSenhaAnterior, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNovaSenha, 0);
            this.Controls.SetChildIndex(this.txtConfirmação, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenhaAnterior;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.TextBox txtConfirmação;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}
