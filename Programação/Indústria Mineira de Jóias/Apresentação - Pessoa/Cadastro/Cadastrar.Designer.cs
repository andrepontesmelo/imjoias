namespace Apresenta��o.Pessoa.Cadastro
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
            this.assistenteControle = new Apresenta��o.Formul�rios.Assistente.AssistenteControle();
            this.painelTipoPessoa = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
            this.radioPF�sica = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioPJur�dica = new System.Windows.Forms.RadioButton();
            this.painelV�nculo = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
            this.radioCliente = new System.Windows.Forms.RadioButton();
            this.radioRepresentante = new System.Windows.Forms.RadioButton();
            this.radioFuncion�rio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.assistenteControle.SuspendLayout();
            this.painelTipoPessoa.SuspendLayout();
            this.painelV�nculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(124, 20);
            this.lblT�tulo.Text = "Novo cadastro";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(231, 48);
            this.lblDescri��o.Text = "Informe o tipo de cadastro que deseja fazer.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Pessoa.Properties.Resources.bot�o___pessoas;
            // 
            // assistenteControle
            // 
            this.assistenteControle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assistenteControle.Controls.Add(this.painelTipoPessoa);
            this.assistenteControle.Controls.Add(this.painelV�nculo);
            this.assistenteControle.Itens = new Apresenta��o.Formul�rios.Assistente.PainelAssistente[] {
        this.painelTipoPessoa,
        this.painelV�nculo};
            this.assistenteControle.Location = new System.Drawing.Point(11, 100);
            this.assistenteControle.Name = "assistenteControle";
            this.assistenteControle.Size = new System.Drawing.Size(298, 138);
            this.assistenteControle.TabIndex = 3;
            this.assistenteControle.Mudan�aPainel += new Apresenta��o.Formul�rios.Assistente.ConjuntoPain�is.PainelHandler(this.assistenteControle_Mudan�aPainel);
            this.assistenteControle.Terminado += new System.EventHandler(this.assistenteControle_Terminado);
            // 
            // painelTipoPessoa
            // 
            this.painelTipoPessoa.AutoScroll = true;
            this.painelTipoPessoa.Controls.Add(this.radioPF�sica);
            this.painelTipoPessoa.Controls.Add(this.label1);
            this.painelTipoPessoa.Controls.Add(this.radioPJur�dica);
            this.painelTipoPessoa.Location = new System.Drawing.Point(0, 0);
            this.painelTipoPessoa.Name = "painelTipoPessoa";
            this.painelTipoPessoa.Size = new System.Drawing.Size(298, 106);
            this.painelTipoPessoa.TabIndex = 1;
            this.painelTipoPessoa.ValidandoTransi��o += new System.ComponentModel.CancelEventHandler(this.painelTipoPessoa_ValidandoTransi��o);
            // 
            // radioPF�sica
            // 
            this.radioPF�sica.AutoSize = true;
            this.radioPF�sica.Location = new System.Drawing.Point(43, 47);
            this.radioPF�sica.Name = "radioPF�sica";
            this.radioPF�sica.Size = new System.Drawing.Size(89, 17);
            this.radioPF�sica.TabIndex = 10;
            this.radioPF�sica.TabStop = true;
            this.radioPF�sica.Text = "Pessoa-f�sica";
            this.radioPF�sica.UseVisualStyleBackColor = true;
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
            // radioPJur�dica
            // 
            this.radioPJur�dica.AutoSize = true;
            this.radioPJur�dica.Location = new System.Drawing.Point(43, 70);
            this.radioPJur�dica.Name = "radioPJur�dica";
            this.radioPJur�dica.Size = new System.Drawing.Size(98, 17);
            this.radioPJur�dica.TabIndex = 11;
            this.radioPJur�dica.TabStop = true;
            this.radioPJur�dica.Text = "Pessoa-jur�dica";
            this.radioPJur�dica.UseVisualStyleBackColor = true;
            // 
            // painelV�nculo
            // 
            this.painelV�nculo.AutoScroll = true;
            this.painelV�nculo.Controls.Add(this.radioCliente);
            this.painelV�nculo.Controls.Add(this.radioRepresentante);
            this.painelV�nculo.Controls.Add(this.radioFuncion�rio);
            this.painelV�nculo.Controls.Add(this.label2);
            this.painelV�nculo.Location = new System.Drawing.Point(0, 0);
            this.painelV�nculo.Name = "painelV�nculo";
            this.painelV�nculo.Size = new System.Drawing.Size(298, 106);
            this.painelV�nculo.TabIndex = 2;
            this.painelV�nculo.ValidandoTransi��o += new System.ComponentModel.CancelEventHandler(this.painelV�nculo_ValidandoTransi��o);
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
            // radioFuncion�rio
            // 
            this.radioFuncion�rio.AutoSize = true;
            this.radioFuncion�rio.Location = new System.Drawing.Point(58, 38);
            this.radioFuncion�rio.Name = "radioFuncion�rio";
            this.radioFuncion�rio.Size = new System.Drawing.Size(80, 17);
            this.radioFuncion�rio.TabIndex = 1;
            this.radioFuncion�rio.Text = "Funcion�rio";
            this.radioFuncion�rio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Escolha o tipo de v�nculo da pessoa:";
            // 
            // Cadastrar
            // 
            this.ClientSize = new System.Drawing.Size(319, 245);
            this.Controls.Add(this.assistenteControle);
            this.Name = "Cadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Cadastro";
            this.Controls.SetChildIndex(this.assistenteControle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.assistenteControle.ResumeLayout(false);
            this.painelTipoPessoa.ResumeLayout(false);
            this.painelTipoPessoa.PerformLayout();
            this.painelV�nculo.ResumeLayout(false);
            this.painelV�nculo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.Assistente.AssistenteControle assistenteControle;
        private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelTipoPessoa;
        private System.Windows.Forms.RadioButton radioPF�sica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioPJur�dica;
        private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelV�nculo;
        private System.Windows.Forms.RadioButton radioCliente;
        private System.Windows.Forms.RadioButton radioRepresentante;
        private System.Windows.Forms.RadioButton radioFuncion�rio;
        private System.Windows.Forms.Label label2;
    }
}
