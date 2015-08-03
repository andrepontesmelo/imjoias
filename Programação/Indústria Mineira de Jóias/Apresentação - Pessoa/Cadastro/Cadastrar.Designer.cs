namespace Apresentação.Pessoa.Cadastro
{
    partial class Cadastrar
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
            this.assistenteControle = new Apresentação.Formulários.Assistente.AssistenteControle();
            this.painelTipoPessoa = new Apresentação.Formulários.Assistente.PainelAssistente();
            this.radioPFísica = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioPJurídica = new System.Windows.Forms.RadioButton();
            this.painelVínculo = new Apresentação.Formulários.Assistente.PainelAssistente();
            this.radioCliente = new System.Windows.Forms.RadioButton();
            this.radioRepresentante = new System.Windows.Forms.RadioButton();
            this.radioFuncionário = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.assistenteControle.SuspendLayout();
            this.painelTipoPessoa.SuspendLayout();
            this.painelVínculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(124, 20);
            this.lblTítulo.Text = "Novo cadastro";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(231, 48);
            this.lblDescrição.Text = "Informe o tipo de cadastro que deseja fazer.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Pessoa.Properties.Resources.botão___pessoas;
            // 
            // assistenteControle
            // 
            this.assistenteControle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assistenteControle.Controls.Add(this.painelTipoPessoa);
            this.assistenteControle.Controls.Add(this.painelVínculo);
            this.assistenteControle.Itens = new Apresentação.Formulários.Assistente.PainelAssistente[] {
        this.painelTipoPessoa,
        this.painelVínculo};
            this.assistenteControle.Location = new System.Drawing.Point(11, 100);
            this.assistenteControle.Name = "assistenteControle";
            this.assistenteControle.Size = new System.Drawing.Size(298, 138);
            this.assistenteControle.TabIndex = 3;
            this.assistenteControle.MudançaPainel += new Apresentação.Formulários.Assistente.ConjuntoPainéis.PainelHandler(this.assistenteControle_MudançaPainel);
            this.assistenteControle.Terminado += new System.EventHandler(this.assistenteControle_Terminado);
            // 
            // painelTipoPessoa
            // 
            this.painelTipoPessoa.AutoScroll = true;
            this.painelTipoPessoa.Controls.Add(this.radioPFísica);
            this.painelTipoPessoa.Controls.Add(this.label1);
            this.painelTipoPessoa.Controls.Add(this.radioPJurídica);
            this.painelTipoPessoa.Location = new System.Drawing.Point(0, 0);
            this.painelTipoPessoa.Name = "painelTipoPessoa";
            this.painelTipoPessoa.Size = new System.Drawing.Size(298, 106);
            this.painelTipoPessoa.TabIndex = 1;
            this.painelTipoPessoa.ValidandoTransição += new System.ComponentModel.CancelEventHandler(this.painelTipoPessoa_ValidandoTransição);
            // 
            // radioPFísica
            // 
            this.radioPFísica.AutoSize = true;
            this.radioPFísica.Location = new System.Drawing.Point(43, 47);
            this.radioPFísica.Name = "radioPFísica";
            this.radioPFísica.Size = new System.Drawing.Size(89, 17);
            this.radioPFísica.TabIndex = 10;
            this.radioPFísica.TabStop = true;
            this.radioPFísica.Text = "Pessoa-física";
            this.radioPFísica.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Eu desejo cadastrar um(a) novo(a):";
            // 
            // radioPJurídica
            // 
            this.radioPJurídica.AutoSize = true;
            this.radioPJurídica.Location = new System.Drawing.Point(43, 70);
            this.radioPJurídica.Name = "radioPJurídica";
            this.radioPJurídica.Size = new System.Drawing.Size(98, 17);
            this.radioPJurídica.TabIndex = 11;
            this.radioPJurídica.TabStop = true;
            this.radioPJurídica.Text = "Pessoa-jurídica";
            this.radioPJurídica.UseVisualStyleBackColor = true;
            // 
            // painelVínculo
            // 
            this.painelVínculo.AutoScroll = true;
            this.painelVínculo.Controls.Add(this.radioCliente);
            this.painelVínculo.Controls.Add(this.radioRepresentante);
            this.painelVínculo.Controls.Add(this.radioFuncionário);
            this.painelVínculo.Controls.Add(this.label2);
            this.painelVínculo.Location = new System.Drawing.Point(0, 0);
            this.painelVínculo.Name = "painelVínculo";
            this.painelVínculo.Size = new System.Drawing.Size(298, 106);
            this.painelVínculo.TabIndex = 2;
            this.painelVínculo.ValidandoTransição += new System.ComponentModel.CancelEventHandler(this.painelVínculo_ValidandoTransição);
            // 
            // radioCliente
            // 
            this.radioCliente.AutoSize = true;
            this.radioCliente.Checked = true;
            this.radioCliente.Location = new System.Drawing.Point(58, 84);
            this.radioCliente.Name = "radioCliente";
            this.radioCliente.Size = new System.Drawing.Size(99, 17);
            this.radioCliente.TabIndex = 3;
            this.radioCliente.TabStop = true;
            this.radioCliente.Text = "Cliente ou outro";
            this.radioCliente.UseVisualStyleBackColor = true;
            // 
            // radioRepresentante
            // 
            this.radioRepresentante.AutoSize = true;
            this.radioRepresentante.Location = new System.Drawing.Point(58, 61);
            this.radioRepresentante.Name = "radioRepresentante";
            this.radioRepresentante.Size = new System.Drawing.Size(95, 17);
            this.radioRepresentante.TabIndex = 2;
            this.radioRepresentante.Text = "Representante";
            this.radioRepresentante.UseVisualStyleBackColor = true;
            // 
            // radioFuncionário
            // 
            this.radioFuncionário.AutoSize = true;
            this.radioFuncionário.Location = new System.Drawing.Point(58, 38);
            this.radioFuncionário.Name = "radioFuncionário";
            this.radioFuncionário.Size = new System.Drawing.Size(80, 17);
            this.radioFuncionário.TabIndex = 1;
            this.radioFuncionário.Text = "Funcionário";
            this.radioFuncionário.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Escolha o tipo de vínculo da pessoa:";
            // 
            // Cadastrar
            // 
            this.ClientSize = new System.Drawing.Size(319, 245);
            this.Controls.Add(this.assistenteControle);
            this.Name = "Cadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Cadastro";
            this.Controls.SetChildIndex(this.assistenteControle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.assistenteControle.ResumeLayout(false);
            this.painelTipoPessoa.ResumeLayout(false);
            this.painelTipoPessoa.PerformLayout();
            this.painelVínculo.ResumeLayout(false);
            this.painelVínculo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Assistente.AssistenteControle assistenteControle;
        private Apresentação.Formulários.Assistente.PainelAssistente painelTipoPessoa;
        private System.Windows.Forms.RadioButton radioPFísica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioPJurídica;
        private Apresentação.Formulários.Assistente.PainelAssistente painelVínculo;
        private System.Windows.Forms.RadioButton radioCliente;
        private System.Windows.Forms.RadioButton radioRepresentante;
        private System.Windows.Forms.RadioButton radioFuncionário;
        private System.Windows.Forms.Label label2;
    }
}
