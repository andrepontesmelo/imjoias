namespace Apresentação.Formulários
{
    partial class JustificarLiberaçãoRecursos
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
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtResponsável = new System.Windows.Forms.TextBox();
            this.lblUsuário = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecurso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPessoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(104, 20);
            this.lblTítulo.Text = "Justificativa";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Por favor, justifique por quê você liberou os recursos que o funcionário não tinh" +
                "a acesso.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.chamando_atenção;
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSenha.Location = new System.Drawing.Point(134, 256);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(232, 20);
            this.txtSenha.TabIndex = 9;
            // 
            // lblSenha
            // 
            this.lblSenha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(30, 259);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 8;
            this.lblSenha.Text = "Senha:";
            // 
            // txtResponsável
            // 
            this.txtResponsável.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResponsável.Location = new System.Drawing.Point(134, 155);
            this.txtResponsável.Name = "txtResponsável";
            this.txtResponsável.ReadOnly = true;
            this.txtResponsável.Size = new System.Drawing.Size(232, 20);
            this.txtResponsável.TabIndex = 5;
            // 
            // lblUsuário
            // 
            this.lblUsuário.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsuário.AutoSize = true;
            this.lblUsuário.Location = new System.Drawing.Point(30, 158);
            this.lblUsuário.Name = "lblUsuário";
            this.lblUsuário.Size = new System.Drawing.Size(72, 13);
            this.lblUsuário.TabIndex = 4;
            this.lblUsuário.Text = "Responsável:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recurso liberado:";
            // 
            // txtRecurso
            // 
            this.txtRecurso.Location = new System.Drawing.Point(134, 103);
            this.txtRecurso.Name = "txtRecurso";
            this.txtRecurso.ReadOnly = true;
            this.txtRecurso.Size = new System.Drawing.Size(232, 20);
            this.txtRecurso.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pessoa autorizada:";
            // 
            // txtPessoa
            // 
            this.txtPessoa.Location = new System.Drawing.Point(134, 129);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.ReadOnly = true;
            this.txtPessoa.Size = new System.Drawing.Size(232, 20);
            this.txtPessoa.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.AcceptsReturn = true;
            this.txtMotivo.Location = new System.Drawing.Point(134, 181);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(232, 69);
            this.txtMotivo.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(222, 289);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(303, 289);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // JustificarLiberaçãoRecursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 324);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPessoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRecurso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtResponsável);
            this.Controls.Add(this.lblUsuário);
            this.Name = "JustificarLiberaçãoRecursos";
            this.Text = "Liberação de recursos";
            this.Shown += new System.EventHandler(this.JustificarLiberaçãoRecursos_Shown);
            this.Controls.SetChildIndex(this.lblUsuário, 0);
            this.Controls.SetChildIndex(this.txtResponsável, 0);
            this.Controls.SetChildIndex(this.lblSenha, 0);
            this.Controls.SetChildIndex(this.txtSenha, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRecurso, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPessoa, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtResponsável;
        private System.Windows.Forms.Label lblUsuário;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecurso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPessoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
    }
}