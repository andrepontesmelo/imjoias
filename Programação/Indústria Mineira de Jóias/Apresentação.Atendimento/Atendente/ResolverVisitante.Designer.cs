namespace Apresentação.Atendimento.Atendente
{
    partial class ResolverVisitante
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.listaPessoas = new Apresentação.Atendimento.Comum.ListaPessoas();
            this.SuspendLayout();
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Existe mais de uma pessoa nesse atendimento. Escolha com quem trabalhar.";
            this.títuloBaseInferior.Imagem = global::Apresentação.Atendimento.Properties.Resources.atendimento;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(574, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Atendimento";
            // 
            // listaPessoas
            // 
            this.listaPessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaPessoas.AutoScroll = true;
            this.listaPessoas.Location = new System.Drawing.Point(193, 92);
            this.listaPessoas.Name = "listaPessoas";
            this.listaPessoas.Size = new System.Drawing.Size(585, 195);
            this.listaPessoas.TabIndex = 7;
            this.listaPessoas.PessoaSelecionada += new Apresentação.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaSelecionada);
            // 
            // ResolverVisitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.listaPessoas);
            this.Name = "ResolverVisitante";
            this.Controls.SetChildIndex(this.listaPessoas, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Atendimento.Comum.ListaPessoas listaPessoas;
    }
}
