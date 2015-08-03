namespace Apresentação.Atendimento.Atendente
{
    partial class QuestionarNomeVisitante
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.grpSolução = new System.Windows.Forms.GroupBox();
            this.optCriar = new System.Windows.Forms.RadioButton();
            this.optProcurar = new System.Windows.Forms.RadioButton();
            this.optConsumidorFinal = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.grpSolução.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(111, 20);
            this.lblTítulo.Text = "Atendimento";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(313, 48);
            this.lblDescrição.Text = "Escolha como proceder com o cadastro da pessoa escolhida.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Atendimento.Properties.Resources.botão___pessoas;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(78, 109);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(288, 20);
            this.txtNome.TabIndex = 4;
            // 
            // grpSolução
            // 
            this.grpSolução.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSolução.Controls.Add(this.optConsumidorFinal);
            this.grpSolução.Controls.Add(this.optProcurar);
            this.grpSolução.Controls.Add(this.optCriar);
            this.grpSolução.Location = new System.Drawing.Point(28, 146);
            this.grpSolução.Name = "grpSolução";
            this.grpSolução.Size = new System.Drawing.Size(347, 90);
            this.grpSolução.TabIndex = 5;
            this.grpSolução.TabStop = false;
            this.grpSolução.Text = "Solução";
            // 
            // optCriar
            // 
            this.optCriar.AutoSize = true;
            this.optCriar.Location = new System.Drawing.Point(6, 19);
            this.optCriar.Name = "optCriar";
            this.optCriar.Size = new System.Drawing.Size(212, 17);
            this.optCriar.TabIndex = 0;
            this.optCriar.TabStop = true;
            this.optCriar.Text = "Criar um novo cadastro pra esta pessoa";
            this.optCriar.UseVisualStyleBackColor = true;
            this.optCriar.Click += new System.EventHandler(this.optCriar_Click);
            // 
            // optProcurar
            // 
            this.optProcurar.AutoSize = true;
            this.optProcurar.Location = new System.Drawing.Point(6, 42);
            this.optProcurar.Name = "optProcurar";
            this.optProcurar.Size = new System.Drawing.Size(204, 17);
            this.optProcurar.TabIndex = 1;
            this.optProcurar.TabStop = true;
            this.optProcurar.Text = "Procurar um cadastro pra esta pessoa";
            this.optProcurar.UseVisualStyleBackColor = true;
            this.optProcurar.Click += new System.EventHandler(this.optCriar_Click);
            // 
            // optConsumidorFinal
            // 
            this.optConsumidorFinal.AutoSize = true;
            this.optConsumidorFinal.Location = new System.Drawing.Point(6, 65);
            this.optConsumidorFinal.Name = "optConsumidorFinal";
            this.optConsumidorFinal.Size = new System.Drawing.Size(333, 17);
            this.optConsumidorFinal.TabIndex = 2;
            this.optConsumidorFinal.TabStop = true;
            this.optConsumidorFinal.Text = "Utilizar cadastro genérico de consumidor final (não recomendado)";
            this.optConsumidorFinal.UseVisualStyleBackColor = true;
            this.optConsumidorFinal.Click += new System.EventHandler(this.optCriar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(233, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(314, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // QuestionarNomeVisitante
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(401, 287);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpSolução);
            this.Controls.Add(this.txtNome);
            this.Name = "QuestionarNomeVisitante";
            this.Text = "Atendimento ao cliente";
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.grpSolução, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.grpSolução.ResumeLayout(false);
            this.grpSolução.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox grpSolução;
        private System.Windows.Forms.RadioButton optConsumidorFinal;
        private System.Windows.Forms.RadioButton optProcurar;
        private System.Windows.Forms.RadioButton optCriar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}