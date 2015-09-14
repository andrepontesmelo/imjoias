using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;
using System.Threading;
using Entidades.Configura��o;
using Apresenta��o.Formul�rios;

namespace Programa.Recep��o.BaseInferior
{
	sealed class RegistrarVisitante : Apresenta��o.Formul�rios.BaseInferior
	{
        private Setor varejo, atacado, altoAtacado;
		private Pessoa cadastro = null;

        public delegate void AoCadastrarCallback(Visita visita);
        public event AoCadastrarCallback AoCadastrar;
		
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox txtEntrada;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.MaskedTextBox txtSa�da;
		private System.Windows.Forms.ComboBox cmbAOutro;
		private System.Windows.Forms.RadioButton optAAAtacado;
		private System.Windows.Forms.RadioButton optAAtacado;
		private System.Windows.Forms.RadioButton optAVarejo;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.RadioButton optAOutro;
		private Apresenta��o.Formul�rios.Quadro quadroInformativo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton optAPessoa;
		private System.Windows.Forms.ComboBox cmbAPessoa;
		private Apresenta��o.Pessoa.Consultas.TextBoxPessoa txtNome;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolTip dica;
		private System.Windows.Forms.ListBox lstAcompanhantes;
		private System.Windows.Forms.Button cmdAdicionar;
		private System.Windows.Forms.Button cmdExcluir;
		private Apresenta��o.Pessoa.Consultas.TextBoxPessoa txtAcompanhante;
		private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
		private System.ComponentModel.IContainer components = null;

		public RegistrarVisitante()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			if (this.DesignMode)
				return;
		}

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
		{
			base.AoCarregarCompletamente(splash);

			// Funcion�rios
            Funcion�rio[] funcion�rios = Funcion�rio.ObterFuncion�rios(true, false);

			cmbAPessoa.Sorted = false;

			foreach (Funcion�rio funcion�rio in funcion�rios)
				cmbAPessoa.Items.Add(funcion�rio);

			// Setores
            Setor[] setores = Entidades.Setor.ObterSetores();

			foreach (Setor setor in setores)
				cmbAOutro.Items.Add(setor.Nome);

            varejo = Setor.ObterSetor("Varejo");
            atacado = Setor.ObterSetor("Atacado");
            altoAtacado = Setor.ObterSetor("Alto-atacado");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarVisitante));
            this.lblNome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntrada = new System.Windows.Forms.MaskedTextBox();
            this.txtSa�da = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAPessoa = new System.Windows.Forms.ComboBox();
            this.optAOutro = new System.Windows.Forms.RadioButton();
            this.cmbAOutro = new System.Windows.Forms.ComboBox();
            this.optAPessoa = new System.Windows.Forms.RadioButton();
            this.optAAAtacado = new System.Windows.Forms.RadioButton();
            this.optAAtacado = new System.Windows.Forms.RadioButton();
            this.optAVarejo = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.quadroInformativo = new Apresenta��o.Formul�rios.Quadro();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new Apresenta��o.Pessoa.Consultas.TextBoxPessoa();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAcompanhante = new Apresenta��o.Pessoa.Consultas.TextBoxPessoa();
            this.cmdExcluir = new System.Windows.Forms.Button();
            this.cmdAdicionar = new System.Windows.Forms.Button();
            this.lstAcompanhantes = new System.Windows.Forms.ListBox();
            this.dica = new System.Windows.Forms.ToolTip(this.components);
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.esquerda.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.quadroInformativo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroInformativo);
            this.esquerda.Size = new System.Drawing.Size(187, 440);
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(309, 80);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 5;
            this.lblNome.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Entrada:";
            // 
            // txtEntrada
            // 
            this.txtEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEntrada.Location = new System.Drawing.Point(309, 144);
            this.txtEntrada.Mask = "00/00/0000 90:00";
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.ReadOnly = true;
            this.txtEntrada.Size = new System.Drawing.Size(144, 20);
            this.txtEntrada.TabIndex = 10;
            this.txtEntrada.ValidatingType = typeof(System.DateTime);
            // 
            // txtSa�da
            // 
            this.txtSa�da.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSa�da.Location = new System.Drawing.Point(493, 144);
            this.txtSa�da.Name = "txtSa�da";
            this.txtSa�da.ReadOnly = true;
            this.txtSa�da.Size = new System.Drawing.Size(144, 20);
            this.txtSa�da.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Sa�da:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.cmbAPessoa);
            this.groupBox2.Controls.Add(this.optAOutro);
            this.groupBox2.Controls.Add(this.cmbAOutro);
            this.groupBox2.Controls.Add(this.optAPessoa);
            this.groupBox2.Controls.Add(this.optAAAtacado);
            this.groupBox2.Controls.Add(this.optAAtacado);
            this.groupBox2.Controls.Add(this.optAVarejo);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(309, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 104);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Atendimento";
            // 
            // cmbAPessoa
            // 
            this.cmbAPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAPessoa.Enabled = false;
            this.cmbAPessoa.Location = new System.Drawing.Point(216, 26);
            this.cmbAPessoa.Name = "cmbAPessoa";
            this.cmbAPessoa.Size = new System.Drawing.Size(104, 21);
            this.cmbAPessoa.Sorted = true;
            this.cmbAPessoa.TabIndex = 6;
            // 
            // optAOutro
            // 
            this.optAOutro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAOutro.Location = new System.Drawing.Point(120, 56);
            this.optAOutro.Name = "optAOutro";
            this.optAOutro.Size = new System.Drawing.Size(80, 24);
            this.optAOutro.TabIndex = 5;
            this.optAOutro.Text = "Outro setor:";
            this.optAOutro.CheckedChanged += new System.EventHandler(this.optAOutro_CheckedChanged);
            // 
            // cmbAOutro
            // 
            this.cmbAOutro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAOutro.Enabled = false;
            this.cmbAOutro.Location = new System.Drawing.Point(216, 58);
            this.cmbAOutro.Name = "cmbAOutro";
            this.cmbAOutro.Size = new System.Drawing.Size(104, 21);
            this.cmbAOutro.Sorted = true;
            this.cmbAOutro.TabIndex = 4;
            // 
            // optAPessoa
            // 
            this.optAPessoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAPessoa.Location = new System.Drawing.Point(120, 24);
            this.optAPessoa.Name = "optAPessoa";
            this.optAPessoa.Size = new System.Drawing.Size(80, 24);
            this.optAPessoa.TabIndex = 3;
            this.optAPessoa.Text = "Pessoa espec�fica:";
            this.optAPessoa.CheckedChanged += new System.EventHandler(this.optAPessoa_CheckedChanged);
            // 
            // optAAAtacado
            // 
            this.optAAAtacado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAAAtacado.Location = new System.Drawing.Point(16, 72);
            this.optAAAtacado.Name = "optAAAtacado";
            this.optAAAtacado.Size = new System.Drawing.Size(104, 24);
            this.optAAAtacado.TabIndex = 2;
            this.optAAAtacado.Text = "Alto-Atacado";
            // 
            // optAAtacado
            // 
            this.optAAtacado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAAtacado.Location = new System.Drawing.Point(16, 48);
            this.optAAtacado.Name = "optAAtacado";
            this.optAAtacado.Size = new System.Drawing.Size(104, 24);
            this.optAAtacado.TabIndex = 1;
            this.optAAtacado.Text = "Atacado";
            // 
            // optAVarejo
            // 
            this.optAVarejo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAVarejo.Location = new System.Drawing.Point(16, 24);
            this.optAVarejo.Name = "optAVarejo";
            this.optAVarejo.Size = new System.Drawing.Size(104, 24);
            this.optAVarejo.TabIndex = 0;
            this.optAVarejo.Text = "Varejo";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(565, 408);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 16;
            this.cmdOK.Text = "Ok";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(477, 408);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 17;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // quadroInformativo
            // 
            this.quadroInformativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroInformativo.bInfDirArredondada = true;
            this.quadroInformativo.bInfEsqArredondada = true;
            this.quadroInformativo.bSupDirArredondada = true;
            this.quadroInformativo.bSupEsqArredondada = true;
            this.quadroInformativo.Controls.Add(this.label4);
            this.quadroInformativo.Cor = System.Drawing.Color.Black;
            this.quadroInformativo.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroInformativo.LetraT�tulo = System.Drawing.Color.White;
            this.quadroInformativo.Location = new System.Drawing.Point(8, 16);
            this.quadroInformativo.MostrarBot�oMinMax = false;
            this.quadroInformativo.Name = "quadroInformativo";
            this.quadroInformativo.Size = new System.Drawing.Size(160, 128);
            this.quadroInformativo.TabIndex = 0;
            this.quadroInformativo.Tamanho = 30;
            this.quadroInformativo.T�tulo = "Registrando Visitante";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 88);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ao t�rmino do cadastro, ser� poss�vel inserir acompanhantes. Escolhendo o setor d" +
                "e atendimento, automaticamente o cliente ser� inserido no rod�zio de atendimento" +
                ".";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.Location = new System.Drawing.Point(309, 96);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(328, 20);
            this.txtNome.TabIndex = 18;
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            this.txtNome.NomeAlterado += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtAcompanhante);
            this.groupBox1.Controls.Add(this.cmdExcluir);
            this.groupBox1.Controls.Add(this.cmdAdicionar);
            this.groupBox1.Controls.Add(this.lstAcompanhantes);
            this.groupBox1.Location = new System.Drawing.Point(309, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 112);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acompanhantes";
            // 
            // txtAcompanhante
            // 
            this.txtAcompanhante.Location = new System.Drawing.Point(8, 16);
            this.txtAcompanhante.Name = "txtAcompanhante";
            this.txtAcompanhante.Size = new System.Drawing.Size(256, 20);
            this.txtAcompanhante.TabIndex = 19;
            this.txtAcompanhante.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAcompanhante_KeyUp);
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdExcluir.Image = ((System.Drawing.Image)(resources.GetObject("cmdExcluir.Image")));
            this.cmdExcluir.Location = new System.Drawing.Point(296, 16);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.Size = new System.Drawing.Size(20, 20);
            this.cmdExcluir.TabIndex = 3;
            this.cmdExcluir.UseVisualStyleBackColor = false;
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // cmdAdicionar
            // 
            this.cmdAdicionar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdicionar.Image")));
            this.cmdAdicionar.Location = new System.Drawing.Point(272, 16);
            this.cmdAdicionar.Name = "cmdAdicionar";
            this.cmdAdicionar.Size = new System.Drawing.Size(20, 20);
            this.cmdAdicionar.TabIndex = 2;
            this.cmdAdicionar.UseVisualStyleBackColor = false;
            this.cmdAdicionar.Click += new System.EventHandler(this.cmdAdicionar_Click);
            // 
            // lstAcompanhantes
            // 
            this.lstAcompanhantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAcompanhantes.IntegralHeight = false;
            this.lstAcompanhantes.Location = new System.Drawing.Point(8, 40);
            this.lstAcompanhantes.Name = "lstAcompanhantes";
            this.lstAcompanhantes.ScrollAlwaysVisible = true;
            this.lstAcompanhantes.Size = new System.Drawing.Size(312, 64);
            this.lstAcompanhantes.TabIndex = 0;
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Preencha os dados acerca do visitante que est� adentrando na empresa. Estes dados" +
                " ser�o utilizados durante o atendimento.";
            this.t�tuloBaseInferior.Imagem = ((System.Drawing.Image)(resources.GetObject("t�tuloBaseInferior.Imagem")));
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(216, 8);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(537, 70);
            this.t�tuloBaseInferior.TabIndex = 20;
            this.t�tuloBaseInferior.T�tulo = "Registrar entrada de visitante";
            // 
            // RegistrarVisitante
            // 
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(768, 440);
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSa�da);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNome);
            this.Name = "RegistrarVisitante";
            this.Size = new System.Drawing.Size(768, 440);
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtEntrada, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSa�da, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.esquerda.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.quadroInformativo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Ocorre ao exibir.
		/// </summary>
		protected override void AoExibir()
		{
			base.AoExibir();

			Preparar();
		}

		/// <summary>
		/// Prepara o controle para entrada de dados
		/// </summary>
		public void Preparar()
		{
			txtNome.Text = "";
			txtEntrada.Text = DateTime.Now.ToString(DadosGlobais.Inst�ncia.Cultura);
            
			txtSa�da.Text = "";
			txtAcompanhante.Text = "";
			lstAcompanhantes.Items.Clear();
			
			optAVarejo.Checked = true;
			optAVarejo.Checked = false;
			txtNome.Focus();

			cmdOK.Enabled = false;
		}

		/// <summary>
		/// Ocorre quando usu�rio clica em cancelar
		/// </summary>
		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			SubstituirBaseParaInicial();
		}

		/// <summary>
		/// Ocorre quando o usu�rio escolhe outro setor
		/// </summary>
		private void optAOutro_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbAOutro.Enabled = optAOutro.Checked;
		}

		/// <summary>
		/// Ocorre quando o usu�rio clica em OK
		/// </summary>
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
            Visita visita;

            Cursor = Cursors.WaitCursor;

            AguardeDB.Mostrar();

            try
            {
                // Procurar cadastro do visitante
                if (cadastro != null)
                {
                    // Garantir que o cadastro recuperar� o tipo de pessoa correto.
                    cadastro = Entidades.Pessoa.Pessoa.ObterPessoa(cadastro.C�digo);

                    if (!(cadastro is Entidades.Pessoa.PessoaF�sica))
                        cadastro = null;
                }
                else
                {
                    PessoaF�sica[] pessoas = Entidades.Pessoa.PessoaF�sica.ObterPessoas(Nome);

                    if (pessoas.Length > 0)
                    {
                        using (Apresenta��o.Pessoa.Consultas.SelecionarPessoa escolher = new Apresenta��o.Pessoa.Consultas.SelecionarPessoa(pessoas, Nome))
                        {
                            AguardeDB.Suspens�o(true);

                            if (escolher.ShowDialog(this.ParentForm) != DialogResult.OK)
                                return;

                            AguardeDB.Suspens�o(false);

                            if (escolher.PessoaEscolhida != null)
                                cadastro = (PessoaF�sica)escolher.PessoaEscolhida;
                        }
                    }
                }

                try
                {
                    if (cadastro == null)
                    {
                        // Registrar cadastro an�nimo
                        visita = new Visita();
                        visita.Nomes.Adicionar(Nome);
                        visita.Setor = Setor;
                    }
                    else
                    {
                        // Registrar baseado no cadastro
                        visita = new Visita((PessoaF�sica)cadastro);
                        visita.Setor = Setor;

                        if (visita.Setor != null && cadastro.Setor != null &&
                            visita.Setor.C�digo != cadastro.Setor.C�digo)
                        {
                            if (MessageBox.Show(
                                ParentForm,
                                "ATEN��O\n\nO(a) cliente " + cadastro.PrimeiroNome +
                                " est� cadastrado como cliente do setor " + cadastro.Setor.Nome +
                                ". No entanto, voc� marcou o cliente para o setor " + visita.Setor.Nome +
                                ".\n\nDeseja continuar assim mesmo?",
                                "Registro de visitante",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                    visita.Cadastrar();
                }
                catch (Exception erro)
                {
                    AguardeDB.Suspens�o(true);
                    MessageBox.Show("Erro ao adicionar novo visitante.\n\n" + erro.ToString());
                    AguardeDB.Suspens�o(false);
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);

                    Cursor = Cursors.Default;

                    return;
                }

                // Registrar acompanhantes
                foreach (object obj in Acompanhantes)
                    if (obj is string)
                        visita.Nomes.Adicionar((string)obj);
                    else if (obj is PessoaCPFCNPJRG)
                    {
                        PessoaF�sica pessoaF�sica;

                        pessoaF�sica = Entidades.Pessoa.PessoaF�sica.ObterPessoa(((PessoaCPFCNPJRG)obj).C�digo);

                        if (pessoaF�sica != null)
                        {
                            // Registrar baseado no cadastro
                            visita.Pessoas.Adicionar(pessoaF�sica);
                        }
                        else
                            // Registrar acompanhante an�nimo
                            visita.Nomes.Adicionar(((PessoaCPFCNPJRG)obj).Nome);
                    }

                visita.Atualizar();

                AoCadastrar(visita);

                Preparar();

                SubstituirBaseParaInicial();
            }
            finally
            {
                AguardeDB.Fechar();
                Cursor = Cursors.Default;
            }
		}

		/// <summary>
		/// Ocorre quando a op��o de funcion�rio espec�fica � marcado
		/// </summary>
		private void optAPessoa_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbAPessoa.Enabled = optAPessoa.Checked;
		}

		/// <summary>
		/// Ocorre quando o nome muda
		/// </summary>
		private void txtNome_TextChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = txtNome.Text.Length > 0;
		}

		/// <summary>
		/// Terminado de identificar o nome,
		/// atribuir automaticamente o setor de atendimento.
		/// </summary>
		private void txtNome_Leave(object sender, System.EventArgs e)
		{
			if (txtNome.SegurandoLista)
				return;

			Cadastro = txtNome.Pessoa;
		}

		/// <summary>
		/// Adiciona um acompanhante � lista
		/// </summary>
		private void cmdAdicionar_Click(object sender, System.EventArgs e)
		{
			if (txtAcompanhante.Pessoa != null)
				lstAcompanhantes.Items.Add(txtAcompanhante.Pessoa);
			else if (txtAcompanhante.Text.Length > 1)
				lstAcompanhantes.Items.Add(txtAcompanhante.Text);

			txtAcompanhante.Text = "";
			txtAcompanhante.Focus();
		}

		/// <summary>
		/// Remove um acompanhante selecionado
		/// </summary>
		private void cmdExcluir_Click(object sender, System.EventArgs e)
		{
			if (lstAcompanhantes.SelectedIndex < 0)
				txtAcompanhante.Text = "";
			else if (string.Compare(lstAcompanhantes.SelectedItem.ToString(), txtAcompanhante.Text, true) == 0)
			{
				txtAcompanhante.Text = "";
				lstAcompanhantes.Items.RemoveAt(lstAcompanhantes.SelectedIndex);
			}
		}

		/// <summary>
		/// Ocorre quando se pressiona alguma tecla no textbox txtAcompanhante
		/// </summary>
		private void txtAcompanhante_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cmdAdicionar_Click(txtAcompanhante, null);
				e.Handled = true;
			}
		}

		/// <summary>
		/// Obt�m o nome a ser registrado
		/// </summary>
		public string Nome
		{
			get { return txtNome.Text; }
			set { txtNome.Text = value; }
		}

		/// <summary>
		/// Obt�m a data de registro
		/// </summary>
		public DateTime Entrada
		{
			get { return DateTime.Parse(txtEntrada.Text); }
			set { txtEntrada.Text = value.ToString(); } 
		}

		/// <summary>
		/// Obt�m o motivo
		/// </summary>
		public static Entidades.MotivoContato Motivo
		{
			get { return Entidades.MotivoContato.Desconhecido; }
		}

		/// <summary>
		/// Obt�m a data de sa�da
		/// </summary>
		public DateTime Sa�da
		{
			get { return DateTime.Parse(txtSa�da.Text); }
			set { txtSa�da.Text = value.ToString(DadosGlobais.Inst�ncia.Cultura); }
		}

		/// <summary>
		/// Nome do funcin�rio que ir� atend�-lo
		/// </summary>
		public Funcion�rio Funcion�rio
		{
			get
			{
				if (optAPessoa.Checked)
					return cmbAPessoa.SelectedItem as Funcion�rio;
				else
					return null;
			}
			set
			{
				if (value != null)
				{
					optAPessoa.Checked = true;
					cmbAPessoa.Text = value.ToString();
				}
				else
					optAPessoa.Checked = false;
			}
		}

		/// <summary>
		/// Setor de atendimento
		/// </summary>
		public Setor Setor
		{
			get
			{
                if (optAVarejo.Checked)
                    return varejo;

                if (optAAtacado.Checked)
                    return atacado;

				if (optAAAtacado.Checked)
                    return altoAtacado;

				if (optAPessoa.Checked)
					return null;

				return Setor.ObterSetor(cmbAOutro.Text);
			}
			set
			{
				if (value == null)
					optAPessoa.Checked = true;

				else if (value.C�digo == varejo.C�digo)
					optAVarejo.Checked = true;

                else if (value.C�digo == atacado.C�digo)
					optAAtacado.Checked = true;

                else if (value.C�digo == altoAtacado.C�digo)
					optAAAtacado.Checked = true;

				else
				{
					optAOutro.Checked = true;
					cmbAOutro.Text = value.Nome;
				}
			}
		}

		/// <summary>
		/// Cadastro da pessoa f�sica
		/// </summary>
		public Pessoa Cadastro
		{
			get { return cadastro; }
			set
			{
				this.Cursor = Cursors.WaitCursor;

				cadastro = value;

				if (cadastro != null)
				{
					txtNome.Text = cadastro.Nome;

					// Marcar setor de atendimento
					if (value.Setor != null)
                        Setor = value.Setor;
				}

				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Lista de acompanhantes
		/// </summary>
		public object [] Acompanhantes
		{
			get
			{
				object [] valores = new object[lstAcompanhantes.Items.Count];

				for (int i = 0; i < valores.Length; i++)
					valores[i] = lstAcompanhantes.Items[i];

				return valores;
			}
		}
	}
}

