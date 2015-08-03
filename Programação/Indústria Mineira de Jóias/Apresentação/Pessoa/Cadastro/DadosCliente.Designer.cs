namespace Apresentação.Pessoa.Cadastro
{
    partial class DadosCliente
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
            this.grpInfTemporais = new System.Windows.Forms.GroupBox();
            this.txtÚltimaVenda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCadastro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAtendimento = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.optVarejo = new System.Windows.Forms.RadioButton();
            this.optAtacado = new System.Windows.Forms.RadioButton();
            this.optAltoAtacado = new System.Windows.Forms.RadioButton();
            this.optOutro = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.grpHistórico = new System.Windows.Forms.GroupBox();
            this.classificador = new Apresentação.Pessoa.Cadastro.Classificador();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCrédito = new AMS.TextBox.CurrencyTextBox();
            this.txtMaiorVenda = new AMS.TextBox.CurrencyTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.controlePermissão = new Apresentação.Formulários.ControlePermissão();
            this.grpInfTemporais.SuspendLayout();
            this.grpAtendimento.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.grpHistórico.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfTemporais
            // 
            this.grpInfTemporais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInfTemporais.Controls.Add(this.txtÚltimaVenda);
            this.grpInfTemporais.Controls.Add(this.label2);
            this.grpInfTemporais.Controls.Add(this.txtCadastro);
            this.grpInfTemporais.Controls.Add(this.label1);
            this.grpInfTemporais.Location = new System.Drawing.Point(0, 0);
            this.grpInfTemporais.Name = "grpInfTemporais";
            this.grpInfTemporais.Size = new System.Drawing.Size(215, 73);
            this.grpInfTemporais.TabIndex = 0;
            this.grpInfTemporais.TabStop = false;
            this.grpInfTemporais.Text = "Informações temporais";
            // 
            // txtÚltimaVenda
            // 
            this.txtÚltimaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtÚltimaVenda.Location = new System.Drawing.Point(86, 45);
            this.txtÚltimaVenda.Name = "txtÚltimaVenda";
            this.txtÚltimaVenda.ReadOnly = true;
            this.txtÚltimaVenda.Size = new System.Drawing.Size(123, 20);
            this.txtÚltimaVenda.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Última venda:";
            // 
            // txtCadastro
            // 
            this.txtCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCadastro.Location = new System.Drawing.Point(86, 19);
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.ReadOnly = true;
            this.txtCadastro.Size = new System.Drawing.Size(123, 20);
            this.txtCadastro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente desde:";
            // 
            // grpAtendimento
            // 
            this.grpAtendimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAtendimento.Controls.Add(this.flowLayoutPanel1);
            this.grpAtendimento.Controls.Add(this.label7);
            this.grpAtendimento.Location = new System.Drawing.Point(0, 79);
            this.grpAtendimento.Name = "grpAtendimento";
            this.grpAtendimento.Size = new System.Drawing.Size(392, 53);
            this.grpAtendimento.TabIndex = 2;
            this.grpAtendimento.TabStop = false;
            this.grpAtendimento.Text = "Setor";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.optVarejo);
            this.flowLayoutPanel1.Controls.Add(this.optAtacado);
            this.flowLayoutPanel1.Controls.Add(this.optAltoAtacado);
            this.flowLayoutPanel1.Controls.Add(this.optOutro);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(86, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 24);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // optVarejo
            // 
            this.optVarejo.AutoSize = true;
            this.optVarejo.Location = new System.Drawing.Point(3, 3);
            this.optVarejo.Name = "optVarejo";
            this.optVarejo.Size = new System.Drawing.Size(55, 17);
            this.optVarejo.TabIndex = 0;
            this.optVarejo.TabStop = true;
            this.optVarejo.Text = "Varejo";
            this.optVarejo.UseVisualStyleBackColor = true;
            this.optVarejo.CheckedChanged += new System.EventHandler(this.optVarejo_CheckedChanged);
            // 
            // optAtacado
            // 
            this.optAtacado.AutoSize = true;
            this.optAtacado.Location = new System.Drawing.Point(64, 3);
            this.optAtacado.Name = "optAtacado";
            this.optAtacado.Size = new System.Drawing.Size(65, 17);
            this.optAtacado.TabIndex = 1;
            this.optAtacado.TabStop = true;
            this.optAtacado.Text = "Atacado";
            this.optAtacado.UseVisualStyleBackColor = true;
            this.optAtacado.CheckedChanged += new System.EventHandler(this.optAtacado_CheckedChanged);
            // 
            // optAltoAtacado
            // 
            this.optAltoAtacado.AutoSize = true;
            this.optAltoAtacado.Location = new System.Drawing.Point(135, 3);
            this.optAltoAtacado.Name = "optAltoAtacado";
            this.optAltoAtacado.Size = new System.Drawing.Size(85, 17);
            this.optAltoAtacado.TabIndex = 2;
            this.optAltoAtacado.TabStop = true;
            this.optAltoAtacado.Text = "Alto-atacado";
            this.optAltoAtacado.UseVisualStyleBackColor = true;
            this.optAltoAtacado.CheckedChanged += new System.EventHandler(this.optAltoAtacado_CheckedChanged);
            // 
            // optOutro
            // 
            this.optOutro.AutoSize = true;
            this.optOutro.Location = new System.Drawing.Point(226, 3);
            this.optOutro.Name = "optOutro";
            this.optOutro.Size = new System.Drawing.Size(51, 17);
            this.optOutro.TabIndex = 3;
            this.optOutro.TabStop = true;
            this.optOutro.Text = "Outro";
            this.optOutro.UseVisualStyleBackColor = true;
            this.optOutro.CheckedChanged += new System.EventHandler(this.optOutro_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cliente de:";
            // 
            // grpHistórico
            // 
            this.grpHistórico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHistórico.Controls.Add(this.classificador);
            this.grpHistórico.Location = new System.Drawing.Point(3, 138);
            this.grpHistórico.Name = "grpHistórico";
            this.grpHistórico.Size = new System.Drawing.Size(389, 247);
            this.grpHistórico.TabIndex = 4;
            this.grpHistórico.TabStop = false;
            this.grpHistórico.Text = "Classificações";
            // 
            // classificador
            // 
            this.classificador.AutoAtualizarBD = false;
            this.classificador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classificador.Location = new System.Drawing.Point(3, 16);
            this.classificador.Name = "classificador";
            this.classificador.Pessoa = null;
            this.classificador.Size = new System.Drawing.Size(383, 228);
            this.classificador.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCrédito);
            this.groupBox1.Controls.Add(this.txtMaiorVenda);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(221, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atendimento";
            // 
            // txtCrédito
            // 
            this.txtCrédito.AllowNegative = true;
            this.txtCrédito.Flags = 7680;
            this.txtCrédito.Location = new System.Drawing.Point(83, 45);
            this.txtCrédito.MaxWholeDigits = 9;
            this.txtCrédito.Name = "txtCrédito";
            this.controlePermissão.SetPermissãoEdição(this.txtCrédito, Entidades.Privilégio.Permissão.VendasRemoverControle);
            this.txtCrédito.RangeMax = 1.7976931348623157E+308D;
            this.txtCrédito.RangeMin = -1.7976931348623157E+308D;
            this.txtCrédito.Size = new System.Drawing.Size(82, 20);
            this.txtCrédito.TabIndex = 3;
            this.txtCrédito.Validated += new System.EventHandler(this.txtCrédito_Validated);
            // 
            // txtMaiorVenda
            // 
            this.txtMaiorVenda.AllowNegative = true;
            this.txtMaiorVenda.BackColor = System.Drawing.SystemColors.Control;
            this.txtMaiorVenda.Enabled = false;
            this.txtMaiorVenda.Flags = 7680;
            this.txtMaiorVenda.Location = new System.Drawing.Point(83, 19);
            this.txtMaiorVenda.MaxWholeDigits = 9;
            this.txtMaiorVenda.Name = "txtMaiorVenda";
            this.controlePermissão.SetPermissãoEdição(this.txtMaiorVenda, Entidades.Privilégio.Permissão.VendasRemoverControle);
            this.controlePermissão.SetPermissãoVisualização(this.txtMaiorVenda, Entidades.Privilégio.Permissão.VendasLeitura);
            this.txtMaiorVenda.RangeMax = 1.7976931348623157E+308D;
            this.txtMaiorVenda.RangeMin = -1.7976931348623157E+308D;
            this.txtMaiorVenda.Size = new System.Drawing.Size(82, 20);
            this.txtMaiorVenda.TabIndex = 1;
            this.txtMaiorVenda.Validated += new System.EventHandler(this.txtMaiorVenda_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Crédito:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 23);
            this.label8.Name = "label8";
            this.controlePermissão.SetPermissãoVisualização(this.label8, Entidades.Privilégio.Permissão.VendasLeitura);
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Maior venda:";
            // 
            // DadosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpHistórico);
            this.Controls.Add(this.grpAtendimento);
            this.Controls.Add(this.grpInfTemporais);
            this.Name = "DadosCliente";
            this.Size = new System.Drawing.Size(392, 385);
            this.grpInfTemporais.ResumeLayout(false);
            this.grpInfTemporais.PerformLayout();
            this.grpAtendimento.ResumeLayout(false);
            this.grpAtendimento.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grpHistórico.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfTemporais;
        private System.Windows.Forms.TextBox txtCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtÚltimaVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpAtendimento;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton optVarejo;
        private System.Windows.Forms.RadioButton optAtacado;
        private System.Windows.Forms.RadioButton optAltoAtacado;
        private System.Windows.Forms.RadioButton optOutro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpHistórico;
        private Classificador classificador;
        private System.Windows.Forms.GroupBox groupBox1;
        private AMS.TextBox.CurrencyTextBox txtCrédito;
        private AMS.TextBox.CurrencyTextBox txtMaiorVenda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Apresentação.Formulários.ControlePermissão controlePermissão;
    }
}
