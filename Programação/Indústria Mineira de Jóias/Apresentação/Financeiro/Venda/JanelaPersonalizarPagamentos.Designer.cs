namespace Apresentação.Financeiro.Venda
{
    partial class JanelaPersonalizarPagamentos
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
            this.listaPagamento = new Apresentação.Financeiro.Pagamento.ListaPagamento();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.botãoLiberarRecurso1 = new Apresentação.Formulários.BotãoLiberarRecurso();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(191, 20);
            this.lblTítulo.Text = "Confirme o pagamento";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(480, 48);
            this.lblDescrição.Text = "Receba os pagamentos antes de concluir com esta tela.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.giveMoney;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // listaPagamento
            // 
            this.listaPagamento.Location = new System.Drawing.Point(12, 101);
            this.listaPagamento.Name = "listaPagamento";
            this.listaPagamento.Size = new System.Drawing.Size(544, 208);
            this.listaPagamento.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(400, 321);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(481, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // botãoLiberarRecurso1
            // 
            this.botãoLiberarRecurso1.AutoSize = true;
            this.botãoLiberarRecurso1.Descrição = "Permite ao funcionário escolher a forma que quiser para um pagamento, com prazo f" +
                "lexível.";
            this.botãoLiberarRecurso1.Location = new System.Drawing.Point(12, 321);
            this.botãoLiberarRecurso1.Name = "botãoLiberarRecurso1";
            this.botãoLiberarRecurso1.Privilégios = Entidades.Privilégio.Permissão.PersonalizarVenda;
            this.botãoLiberarRecurso1.Recurso = "Personalizar pagamentos";
            this.botãoLiberarRecurso1.Size = new System.Drawing.Size(148, 23);
            this.botãoLiberarRecurso1.TabIndex = 6;
            this.botãoLiberarRecurso1.Texto = "Personalizar pagamentos";
            this.botãoLiberarRecurso1.LiberarRecurso += new System.EventHandler(this.botãoLiberarRecurso1_LiberarRecurso);
            // 
            // JanelaPersonalizarPagamentos
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(568, 356);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.botãoLiberarRecurso1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.listaPagamento);
            this.Name = "JanelaPersonalizarPagamentos";
            this.Text = "Conclusão da venda";
            this.Controls.SetChildIndex(this.listaPagamento, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.botãoLiberarRecurso1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apresentação.Financeiro.Pagamento.ListaPagamento listaPagamento;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarRecurso1;
    }
}