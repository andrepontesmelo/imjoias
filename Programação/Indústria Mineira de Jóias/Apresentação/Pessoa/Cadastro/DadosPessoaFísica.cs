using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Apresenta��o.Pessoa.Consultas;
using Entidades.Configura��o;

namespace Apresenta��o.Pessoa.Cadastro
{
	public class DadosPessoaF�sica : System.Windows.Forms.UserControl
	{
        private Entidades.Pessoa.PessoaF�sica pessoa;
        private DateTime hoje;

        // Designer
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Label label1;
		private AMS.TextBox.MultiMaskedTextBox txtCPF;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRG;
		private System.Windows.Forms.Label lblEmissor;
        private System.Windows.Forms.TextBox txtRGEmissor;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton optMasculino;
		private System.Windows.Forms.RadioButton optFeminino;
		private System.Windows.Forms.RadioButton optSolteiro;
		private System.Windows.Forms.RadioButton optCasado;
		private System.Windows.Forms.RadioButton optDivorciado;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private AMS.TextBox.DateTextBox txtNascimento;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton optViuvo;
        private System.Windows.Forms.RadioButton optOutro;
        private System.Windows.Forms.OpenFileDialog abrirArquivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private FormatadorNome formatadorNome;
        private Label lblM�e;
        private TextBoxPessoa txtM�e;
        private Label lblPai;
        private TextBoxPessoa txtPai;
        private GroupBox groupBox4;
        private Apresenta��o.Pessoa.Endere�o.TextBoxPa�s txtPa�s;
        private Apresenta��o.Pessoa.Endere�o.TextBoxEstado txtEstado;
        private Apresenta��o.Pessoa.Endere�o.TextBoxLocalidade txtLocalidade;
        private TextBox txtProfiss�o;
        private Label label3;
        private Label label4;
        private CheckBox cmbNumera��oAutom�tica;
        private AMS.TextBox.IntegerTextBox txtC�digo;
        private IContainer components;

		public DadosPessoaF�sica()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            pessoa = new Entidades.Pessoa.PessoaF�sica();

            try
            {
                hoje = DadosGlobais.Inst�ncia.HoraDataAtual.Date;
            }
            catch
            {
                hoje = DadosGlobais.Inst�ncia.HoraDataAtual;
            }
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPF = new AMS.TextBox.MultiMaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblEmissor = new System.Windows.Forms.Label();
            this.txtRGEmissor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optFeminino = new System.Windows.Forms.RadioButton();
            this.optMasculino = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optOutro = new System.Windows.Forms.RadioButton();
            this.optViuvo = new System.Windows.Forms.RadioButton();
            this.optDivorciado = new System.Windows.Forms.RadioButton();
            this.optCasado = new System.Windows.Forms.RadioButton();
            this.optSolteiro = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPa�s = new Apresenta��o.Pessoa.Endere�o.TextBoxPa�s();
            this.txtEstado = new Apresenta��o.Pessoa.Endere�o.TextBoxEstado();
            this.txtLocalidade = new Apresenta��o.Pessoa.Endere�o.TextBoxLocalidade();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNascimento = new AMS.TextBox.DateTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.abrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.formatadorNome = new Apresenta��o.Pessoa.FormatadorNome(this.components);
            this.txtProfiss�o = new System.Windows.Forms.TextBox();
            this.lblM�e = new System.Windows.Forms.Label();
            this.txtM�e = new Apresenta��o.Pessoa.Consultas.TextBoxPessoa();
            this.lblPai = new System.Windows.Forms.Label();
            this.txtPai = new Apresenta��o.Pessoa.Consultas.TextBoxPessoa();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtC�digo = new AMS.TextBox.IntegerTextBox();
            this.cmbNumera��oAutom�tica = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(5, 49);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "&Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorNome.SetFormatarNome(this.txtNome, true);
            this.txtNome.Location = new System.Drawing.Point(65, 46);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(314, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "&CPF:";
            // 
            // txtCPF
            // 
            this.txtCPF.Flags = 0;
            this.txtCPF.Location = new System.Drawing.Point(65, 99);
            this.txtCPF.Mask = "###.###.###-##";
            this.txtCPF.MaxLength = 14;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(91, 20);
            this.txtCPF.TabIndex = 6;
            this.txtCPF.Validated += new System.EventHandler(this.txtCPF_Validated);
            this.txtCPF.Validating += new System.ComponentModel.CancelEventHandler(this.txtCPF_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&DI:";
            // 
            // txtRG
            // 
            this.txtRG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRG.Location = new System.Drawing.Point(65, 73);
            this.txtRG.MaxLength = 15;
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(91, 20);
            this.txtRG.TabIndex = 4;
            this.txtRG.Validated += new System.EventHandler(this.txtRG_Validated);
            // 
            // lblEmissor
            // 
            this.lblEmissor.AutoSize = true;
            this.lblEmissor.Location = new System.Drawing.Point(162, 76);
            this.lblEmissor.Name = "lblEmissor";
            this.lblEmissor.Size = new System.Drawing.Size(78, 13);
            this.lblEmissor.TabIndex = 4;
            this.lblEmissor.Text = "&�rg�o Emissor:";
            // 
            // txtRGEmissor
            // 
            this.txtRGEmissor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRGEmissor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRGEmissor.Location = new System.Drawing.Point(246, 73);
            this.txtRGEmissor.MaxLength = 10;
            this.txtRGEmissor.Name = "txtRGEmissor";
            this.txtRGEmissor.Size = new System.Drawing.Size(133, 20);
            this.txtRGEmissor.TabIndex = 5;
            this.txtRGEmissor.Validated += new System.EventHandler(this.txtRGEmissor_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.optFeminino);
            this.groupBox1.Controls.Add(this.optMasculino);
            this.groupBox1.Location = new System.Drawing.Point(217, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 227);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Se&xo";
            // 
            // optFeminino
            // 
            this.optFeminino.BackColor = System.Drawing.Color.Transparent;
            this.optFeminino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optFeminino.Location = new System.Drawing.Point(8, 48);
            this.optFeminino.Name = "optFeminino";
            this.optFeminino.Size = new System.Drawing.Size(136, 16);
            this.optFeminino.TabIndex = 15;
            this.optFeminino.Text = "Feminino";
            this.optFeminino.UseVisualStyleBackColor = false;
            this.optFeminino.CheckedChanged += new System.EventHandler(this.optFeminino_CheckedChanged);
            // 
            // optMasculino
            // 
            this.optMasculino.BackColor = System.Drawing.Color.Transparent;
            this.optMasculino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optMasculino.Location = new System.Drawing.Point(8, 24);
            this.optMasculino.Name = "optMasculino";
            this.optMasculino.Size = new System.Drawing.Size(136, 16);
            this.optMasculino.TabIndex = 14;
            this.optMasculino.Text = "Masculino";
            this.optMasculino.UseVisualStyleBackColor = false;
            this.optMasculino.CheckedChanged += new System.EventHandler(this.optMasculino_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.optOutro);
            this.groupBox2.Controls.Add(this.optViuvo);
            this.groupBox2.Controls.Add(this.optDivorciado);
            this.groupBox2.Controls.Add(this.optCasado);
            this.groupBox2.Controls.Add(this.optSolteiro);
            this.groupBox2.Location = new System.Drawing.Point(3, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 93);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado Civi&l";
            // 
            // optOutro
            // 
            this.optOutro.BackColor = System.Drawing.Color.Transparent;
            this.optOutro.Checked = true;
            this.optOutro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optOutro.Location = new System.Drawing.Point(105, 47);
            this.optOutro.Name = "optOutro";
            this.optOutro.Size = new System.Drawing.Size(97, 16);
            this.optOutro.TabIndex = 19;
            this.optOutro.TabStop = true;
            this.optOutro.Text = "Desconhecido";
            this.optOutro.UseVisualStyleBackColor = false;
            this.optOutro.CheckedChanged += new System.EventHandler(this.optOutro_CheckedChanged);
            // 
            // optViuvo
            // 
            this.optViuvo.BackColor = System.Drawing.Color.Transparent;
            this.optViuvo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optViuvo.Location = new System.Drawing.Point(105, 25);
            this.optViuvo.Name = "optViuvo";
            this.optViuvo.Size = new System.Drawing.Size(97, 16);
            this.optViuvo.TabIndex = 17;
            this.optViuvo.Text = "Viuvo(a)";
            this.optViuvo.UseVisualStyleBackColor = false;
            this.optViuvo.CheckedChanged += new System.EventHandler(this.optViuvo_CheckedChanged);
            // 
            // optDivorciado
            // 
            this.optDivorciado.BackColor = System.Drawing.Color.Transparent;
            this.optDivorciado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optDivorciado.Location = new System.Drawing.Point(8, 69);
            this.optDivorciado.Name = "optDivorciado";
            this.optDivorciado.Size = new System.Drawing.Size(136, 16);
            this.optDivorciado.TabIndex = 20;
            this.optDivorciado.Text = "Divorciado(a)";
            this.optDivorciado.UseVisualStyleBackColor = false;
            this.optDivorciado.CheckedChanged += new System.EventHandler(this.optDivorciado_CheckedChanged);
            // 
            // optCasado
            // 
            this.optCasado.BackColor = System.Drawing.Color.Transparent;
            this.optCasado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optCasado.Location = new System.Drawing.Point(8, 47);
            this.optCasado.Name = "optCasado";
            this.optCasado.Size = new System.Drawing.Size(91, 16);
            this.optCasado.TabIndex = 18;
            this.optCasado.Text = "Casado(a)";
            this.optCasado.UseVisualStyleBackColor = false;
            this.optCasado.CheckedChanged += new System.EventHandler(this.optCasado_CheckedChanged);
            // 
            // optSolteiro
            // 
            this.optSolteiro.BackColor = System.Drawing.Color.Transparent;
            this.optSolteiro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optSolteiro.Location = new System.Drawing.Point(8, 25);
            this.optSolteiro.Name = "optSolteiro";
            this.optSolteiro.Size = new System.Drawing.Size(91, 16);
            this.optSolteiro.TabIndex = 16;
            this.optSolteiro.Text = "Solteiro(a)";
            this.optSolteiro.UseVisualStyleBackColor = false;
            this.optSolteiro.CheckedChanged += new System.EventHandler(this.optSolteiro_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtPa�s);
            this.groupBox3.Controls.Add(this.txtEstado);
            this.groupBox3.Controls.Add(this.txtLocalidade);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtNascimento);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(3, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 128);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nascimento";
            // 
            // txtPa�s
            // 
            this.txtPa�s.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPa�s.Location = new System.Drawing.Point(66, 97);
            this.txtPa�s.Name = "txtPa�s";
            this.txtPa�s.Size = new System.Drawing.Size(133, 20);
            this.txtPa�s.TabIndex = 13;
            this.txtPa�s.TxtEstado = this.txtEstado;
            this.txtPa�s.TxtLocalidade = this.txtLocalidade;
            this.txtPa�s.TxtPa�s = this.txtPa�s;
            this.txtPa�s.Validated += new System.EventHandler(this.txtLocalidade_Validated);
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.Location = new System.Drawing.Point(66, 71);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(133, 20);
            this.txtEstado.TabIndex = 12;
            this.txtEstado.TxtEstado = this.txtEstado;
            this.txtEstado.TxtLocalidade = this.txtLocalidade;
            this.txtEstado.TxtPa�s = this.txtPa�s;
            this.txtEstado.Validated += new System.EventHandler(this.txtLocalidade_Validated);
            // 
            // txtLocalidade
            // 
            this.txtLocalidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalidade.Location = new System.Drawing.Point(66, 45);
            this.txtLocalidade.Name = "txtLocalidade";
            this.txtLocalidade.Size = new System.Drawing.Size(134, 20);
            this.txtLocalidade.TabIndex = 11;
            this.txtLocalidade.TxtEstado = this.txtEstado;
            this.txtLocalidade.TxtPa�s = this.txtPa�s;
            this.txtLocalidade.AoAlterar += new System.EventHandler(this.txtLocalidade_Validated);
            this.txtLocalidade.Validated += new System.EventHandler(this.txtLocalidade_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Pa�&s:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "&Estado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "C&idade:";
            // 
            // txtNascimento
            // 
            this.txtNascimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNascimento.Flags = 65536;
            this.txtNascimento.Location = new System.Drawing.Point(66, 19);
            this.txtNascimento.Name = "txtNascimento";
            this.txtNascimento.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtNascimento.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtNascimento.Size = new System.Drawing.Size(134, 20);
            this.txtNascimento.TabIndex = 10;
            this.txtNascimento.Validated += new System.EventHandler(this.txtNascimento_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Da&ta:";
            // 
            // abrirArquivo
            // 
            this.abrirArquivo.Filter = "Todas as imagens|*.bmp; *.gif; *.jpg; *.jpeg; *.png; *.ico; *.emf; *.wmf";
            this.abrirArquivo.Title = "Inserir foto para pessoa f�sica";
            // 
            // txtProfiss�o
            // 
            this.formatadorNome.SetFormatarNome(this.txtProfiss�o, true);
            this.txtProfiss�o.Location = new System.Drawing.Point(246, 99);
            this.txtProfiss�o.MaxLength = 45;
            this.txtProfiss�o.Name = "txtProfiss�o";
            this.txtProfiss�o.Size = new System.Drawing.Size(133, 20);
            this.txtProfiss�o.TabIndex = 7;
            this.txtProfiss�o.Validated += new System.EventHandler(this.txtProfiss�o_Validated);
            // 
            // lblM�e
            // 
            this.lblM�e.AutoSize = true;
            this.lblM�e.Location = new System.Drawing.Point(162, 129);
            this.lblM�e.Name = "lblM�e";
            this.lblM�e.Size = new System.Drawing.Size(31, 13);
            this.lblM�e.TabIndex = 12;
            this.lblM�e.Text = "&M�e:";
            // 
            // txtM�e
            // 
            this.txtM�e.AlturaProposta = 60;
            this.txtM�e.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtM�e.Location = new System.Drawing.Point(246, 129);
            this.txtM�e.Name = "txtM�e";
            this.txtM�e.Pessoa = null;
            this.txtM�e.Size = new System.Drawing.Size(133, 20);
            this.txtM�e.TabIndex = 9;
            this.txtM�e.Validated += new System.EventHandler(this.txtM�e_Validated);
            // 
            // lblPai
            // 
            this.lblPai.AutoSize = true;
            this.lblPai.Location = new System.Drawing.Point(5, 129);
            this.lblPai.Name = "lblPai";
            this.lblPai.Size = new System.Drawing.Size(25, 13);
            this.lblPai.TabIndex = 10;
            this.lblPai.Text = "P&ai:";
            // 
            // txtPai
            // 
            this.txtPai.AlturaProposta = 60;
            this.txtPai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPai.Location = new System.Drawing.Point(65, 126);
            this.txtPai.Name = "txtPai";
            this.txtPai.Pessoa = null;
            this.txtPai.Size = new System.Drawing.Size(91, 20);
            this.txtPai.TabIndex = 8;
            this.txtPai.Validated += new System.EventHandler(this.txtPai_Validated);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtC�digo);
            this.groupBox4.Controls.Add(this.cmbNumera��oAutom�tica);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtProfiss�o);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lblNome);
            this.groupBox4.Controls.Add(this.txtM�e);
            this.groupBox4.Controls.Add(this.txtNome);
            this.groupBox4.Controls.Add(this.lblM�e);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtPai);
            this.groupBox4.Controls.Add(this.txtCPF);
            this.groupBox4.Controls.Add(this.lblPai);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtRG);
            this.groupBox4.Controls.Add(this.txtRGEmissor);
            this.groupBox4.Controls.Add(this.lblEmissor);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 153);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Identifica��o";
            // 
            // txtC�digo
            // 
            this.txtC�digo.AllowNegative = true;
            this.txtC�digo.DigitsInGroup = 0;
            this.txtC�digo.Enabled = false;
            this.txtC�digo.Flags = 0;
            this.txtC�digo.Location = new System.Drawing.Point(66, 19);
            this.txtC�digo.MaxDecimalPlaces = 0;
            this.txtC�digo.MaxWholeDigits = 9;
            this.txtC�digo.Name = "txtC�digo";
            this.txtC�digo.Prefix = "";
            this.txtC�digo.RangeMax = 1.7976931348623157E+308;
            this.txtC�digo.RangeMin = -1.7976931348623157E+308;
            this.txtC�digo.Size = new System.Drawing.Size(90, 20);
            this.txtC�digo.TabIndex = 15;
            this.txtC�digo.Validated += new System.EventHandler(this.txtC�digo_Validated);
            this.txtC�digo.Validating += new System.ComponentModel.CancelEventHandler(this.txtC�digo_Validating);
            // 
            // cmbNumera��oAutom�tica
            // 
            this.cmbNumera��oAutom�tica.AutoSize = true;
            this.cmbNumera��oAutom�tica.Checked = true;
            this.cmbNumera��oAutom�tica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmbNumera��oAutom�tica.Location = new System.Drawing.Point(165, 23);
            this.cmbNumera��oAutom�tica.Name = "cmbNumera��oAutom�tica";
            this.cmbNumera��oAutom�tica.Size = new System.Drawing.Size(140, 17);
            this.cmbNumera��oAutom�tica.TabIndex = 2;
            this.cmbNumera��oAutom�tica.Text = " Numera��o Autom�tica";
            this.cmbNumera��oAutom�tica.UseVisualStyleBackColor = true;
            this.cmbNumera��oAutom�tica.CheckedChanged += new System.EventHandler(this.cmbNumera��oAutom�tica_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "C�digo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Profiss�o:";
            // 
            // DadosPessoaF�sica
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DadosPessoaF�sica";
            this.Size = new System.Drawing.Size(392, 393);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public Entidades.Pessoa.PessoaF�sica Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;

                if (pessoa != null)
                {
                    this.txtNome.Text = pessoa.Nome;

                    try
                    {
                        this.txtCPF.Text = pessoa.CPF;
                    }
                    catch (Exception)
                    {
                    }

                    if (pessoa.Cadastrado)
                    {
                        this.txtC�digo.Text = pessoa.C�digo.ToString();
                        this.cmbNumera��oAutom�tica.Enabled = false;
                    }
                    else
                    {
                        txtC�digo.Text = "";
                        cmbNumera��oAutom�tica.Enabled = true;
                    }

                    this.txtC�digo.Enabled = false;

                    this.txtRG.Text = pessoa.DI;
                    this.txtRGEmissor.Text = pessoa.DIEmissor;
                    this.txtLocalidade.Localidade = pessoa.Naturalidade;
                    this.txtProfiss�o.Text = pessoa.Profiss�o;

                    if (pessoa.Nascimento > DateTime.MinValue)
                        this.txtNascimento.Text = pessoa.Nascimento.ToString();

                    switch (pessoa.Sexo)
                    {
                        case Entidades.Pessoa.Sexo.Masculino:
                            this.optMasculino.Checked = true;
                            break;

                        case Entidades.Pessoa.Sexo.Feminino:
                            this.optFeminino.Checked = true;
                            break;

                        default:
                            this.optMasculino.Checked = false;
                            this.optFeminino.Checked = false;
                            break;
                    }

                    switch (pessoa.EstadoCivil)
                    {
                        case Entidades.Pessoa.EstadoCivil.Solteiro:
                            this.optSolteiro.Checked = true;
                            break;

                        case Entidades.Pessoa.EstadoCivil.Casado:
                            this.optCasado.Checked = true;
                            break;

                        case Entidades.Pessoa.EstadoCivil.Divorciado:
                            this.optDivorciado.Checked = true;
                            break;

                        case Entidades.Pessoa.EstadoCivil.Viuvo:
                            this.optViuvo.Checked = true;
                            break;

                        default:
                            this.optOutro.Checked = true;
                            break;
                    }

                    txtPai.Text = pessoa.NomePai;
                    txtM�e.Text = pessoa.NomeM�e;

                    //if (pessoa.Foto != null)
                    //    try
                    //    {
                    //        picFoto.Image = pessoa.Foto;
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Apresenta��o.Formul�rios.Notifica��oSimples.Mostrar(
                    //            "Cadastro de pessoa",
                    //            "N�o foi poss�vel carregar a foto da pessoa.");

                    //        Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                    //    }
                }
            }
        }


		/*** M�todos ***************************************************/

		/// <summary>
		/// Valida o CPF
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtCPF_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            Entidades.Pessoa.PessoaF�sica p = null;

			if (txtCPF.Text.Length == 0 || Entidades.Pessoa.PessoaF�sica.ValidarCPF(txtCPF.Text))
			{
                p = Entidades.Pessoa.PessoaF�sica.ObterPessoaPorCPF(txtCPF.Text);
                if (p == null || p.C�digo == pessoa.C�digo)
                {
                    txtCPF.ForeColor = SystemColors.ControlText;
                    txtCPF.Refresh();
                    e.Cancel = false;
                    return;
                }
			}

            if (p != null)
                MessageBox.Show("O cpf " + txtCPF.Text + " j� est� associado ao segunte cliente\n\nC�digo:" + p.C�digo.ToString() + "\nNome:" + (p.Nome != null ? p.Nome : ""), "CPF j� cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtCPF.ForeColor = Color.Red;
			txtCPF.Refresh();
			e.Cancel = true;
		}

        //private void lnkAlterarFoto_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        //{
        //    in�cio:
        //    if (abrirArquivo.ShowDialog(this.ParentForm) == DialogResult.OK)
        //    {
        //        UseWaitCursor = true;

        //        try
        //        {
        //            FileStream f = File.OpenRead(abrirArquivo.FileName);

        //            picFoto.Image = Image.FromStream(f);
        //            picFoto.Refresh();

        //            f.Close();
        //        }
        //        catch (Exception erro)
        //        {
        //            MessageBox.Show(
        //                ParentForm,
        //                "N�o foi poss�vel carregar a foto. O seguinte erro ocorreu:\n\n" + erro.Message,
        //                "Cadastro de pessoa f�sica", MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);

        //            picFoto.Image = null;
        //        }
        //    }
        //    else if (MessageBox.Show(this.ParentForm,
        //        "Deseja excluir a foto atual?",
        //        "Cadastro de Pessoa F�sica",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        picFoto.Image = null;
        //    }

        //    //try
        //    //{
        //    //    pessoa.Foto = picFoto.Image;
        //    //}
        //    //catch
        //    //{
        //    //    if (MessageBox.Show(
        //    //        ParentForm,
        //    //        "N�o foi poss�vel importar a foto atual.",
        //    //        "Cadastro de pessoa",
        //    //        MessageBoxButtons.RetryCancel,
        //    //        MessageBoxIcon.Error) == DialogResult.Retry)
        //    //        goto in�cio;
        //    //}

        //    UseWaitCursor = false;
        //}

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = txtNome.Text.Trim().Length == 0;
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            pessoa.Nome = txtNome.Text.Trim();
        }

        private void txtRG_Validated(object sender, EventArgs e)
        {
            string str = txtRG.Text.Trim();

            if (str.Length > 0)
                pessoa.DI = str;
            else
                pessoa.DI = null;
        }

        private void txtRGEmissor_Validated(object sender, EventArgs e)
        {
            string str = txtRGEmissor.Text.Trim();

            if (str.Length > 0)
                pessoa.DIEmissor = txtRGEmissor.Text.Trim();
            else
                pessoa.DIEmissor = null;
        }

        private void txtCPF_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtCPF.Text.Length > 0)
                    pessoa.CPF = txtCPF.Text;
                else
                    pessoa.CPF = null;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Cadastro de Pessoa F�sica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPai_Validated(object sender, EventArgs e)
        {
            string nomePai = txtPai.Text.Trim();

            if (nomePai.Length > 0)
                pessoa.NomePai = nomePai;
            else
                pessoa.NomePai = null;
        }

        private void txtM�e_Validated(object sender, EventArgs e)
        {
            string nomeM�e = txtM�e.Text.Trim();

            if (nomeM�e.Length > 0)
                pessoa.NomeM�e = nomeM�e;
            else
                pessoa.NomeM�e = null;
        }

        private void txtNascimento_Validated(object sender, EventArgs e)
        {
            if (txtNascimento.Text.Length > 0)
                try
                {
                    pessoa.Nascimento = new DateTime(this.txtNascimento.Year, this.txtNascimento.Month, this.txtNascimento.Day);

                    if (pessoa.Nascimento.Value.Year == hoje.Year)
                    {
                        if (MessageBox.Show(
                            this.ParentForm,
                            "A data de nascimento foi entrada com o ano atual! Deseja alter�-la?",
                            "Cadastro de pessoa f�sica",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            txtNascimento.Focus();
                    }
                    else if (pessoa.Nascimento > hoje)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "A data de nascimento entrada encontra-se no futuro.",
                            "Cadastro de pessoa f�sica",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNascimento.Focus();
                    }
                    else if (hoje.Year - pessoa.Nascimento.Value.Year < 18)
                    {
                        if (MessageBox.Show(
                            this.ParentForm,
                            "A data de nascimento est� bastante recente. A pessoa teria apenas " +
                            Convert.ToString(Math.Floor(((TimeSpan)(hoje - pessoa.Nascimento)).TotalDays / 365)) +
                            " anos. Isso est� correto?",
                            "Cadastro de pessoa f�sica",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            txtNascimento.Focus();
                    }
                }
                catch
                {
                    pessoa.Nascimento = null;

                    MessageBox.Show(
                        this.ParentForm,
                        "A data de nascimento foi entrada incorretamente.",
                        "Cadastro de pessoa f�sica",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                pessoa.Nascimento = null;
        }

        private void txtLocalidade_Validated(object sender, EventArgs e)
        {
            pessoa.Naturalidade = txtLocalidade.Localidade;
        }

        private void optSolteiro_CheckedChanged(object sender, EventArgs e)
        {
            if (optSolteiro.Checked)
                pessoa.EstadoCivil = Entidades.Pessoa.EstadoCivil.Solteiro;
        }

        private void optCasado_CheckedChanged(object sender, EventArgs e)
        {
            if (optCasado.Checked)
                pessoa.EstadoCivil = Entidades.Pessoa.EstadoCivil.Casado;
        }

        private void optDivorciado_CheckedChanged(object sender, EventArgs e)
        {
            if (optDivorciado.Checked)
                pessoa.EstadoCivil = Entidades.Pessoa.EstadoCivil.Divorciado;
        }

        private void optViuvo_CheckedChanged(object sender, EventArgs e)
        {
            if (optViuvo.Checked)
                pessoa.EstadoCivil = Entidades.Pessoa.EstadoCivil.Viuvo;
        }

        private void optOutro_CheckedChanged(object sender, EventArgs e)
        {
            if (optOutro.Checked)
                pessoa.EstadoCivil = Entidades.Pessoa.EstadoCivil.Desconhecido;
        }

        private void optMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (optMasculino.Checked)
                pessoa.Sexo = Entidades.Pessoa.Sexo.Masculino;
        }

        private void optFeminino_CheckedChanged(object sender, EventArgs e)
        {
            if (optFeminino.Checked)
                pessoa.Sexo = Entidades.Pessoa.Sexo.Feminino;
        }

        //private void picFoto_Click(object sender, EventArgs e)
        //{
        //    lnkAlterarFoto_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkAlterarFoto.Links[0], MouseButtons.Left));
        //}

        private void txtProfiss�o_Validated(object sender, EventArgs e)
        {
            string str;

            str = txtProfiss�o.Text.Trim();

            if (str.Length > 0)
                pessoa.Profiss�o = str;
            else
                pessoa.Profiss�o = null;
        }

        private void cmbNumera��oAutom�tica_CheckedChanged(object sender, EventArgs e)
        {
            txtC�digo.Enabled = !cmbNumera��oAutom�tica.Checked;
        }

        private void txtC�digo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel =
                Entidades.Pessoa.Pessoa.ObterPessoa((ulong) txtC�digo.Long) != null;
         }

        private void txtC�digo_Validated(object sender, EventArgs e)
        {
            if (txtC�digo.Enabled)
                pessoa.C�digo = (ulong) txtC�digo.Long;
        }
	}
}
