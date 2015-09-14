using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Privilégio;
using Entidades.Pessoa;
using Apresentação.Formulários;
using System.Collections.Generic;

namespace Apresentação.Pessoa.Cadastro
{
	/// <summary>
	/// Tela para cadastro de pessoa.
	/// </summary>
	public class CadastroPessoa : System.Windows.Forms.Form, Apresentação.Formulários.IRequerPrivilégio
	{
		private Entidades.Pessoa.Pessoa entidade;
        protected TabControl tab;

        // Designer
		private System.Windows.Forms.TabPage tabDadosPessoais;
		protected System.Windows.Forms.ImageList ícones;
        private System.Windows.Forms.TabPage tabEndereço;
        protected Button cmdOK;
        protected System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.TabPage tabObservações;
        private System.Windows.Forms.TextBox txtObservações;
        private GroupBox grpEletrônico;
        private TextBox txtEmail;
        private Label label1;
        private TabPage tabTelefone;
        private GroupBox grpFísico;
        private EditorEndereços endereços;
        private GroupBox grpTelefone;
        private EditorTelefones telefones;
        private TabPage tabDatas;
        private EditorDataRelevante datasRelevantes;
        private GroupBox groupBox1;
        private Label label2;
        private Apresentação.Pessoa.Endereço.ComboBoxRegião cmbRegião;
        protected Button btnExcluir;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Constrói o formlário de cadastro de pessoa física.
		/// </summary>
		/// <remarks>
		/// A pessoa física NÃO é cadastrada/atualizada no
		/// banco de dados.
		/// </remarks>
		public CadastroPessoa()
		{
			InitializeComponent();

            btnExcluir.Visible = btnExcluir.Enabled = PermissãoFuncionário.ValidarPermissão(Permissão.CadastroRemover);
		}

		/// <summary>
		/// Constrói o cadastro de pessoa a partir de dados
		/// já definidos.
		/// </summary>
		/// <param name="pessoa">Pessoa física ou jurídica.</param>
		public CadastroPessoa(Entidades.Pessoa.Pessoa pessoa) : this()
		{
            AguardeDB.Mostrar();

			this.Pessoa = pessoa;

            AguardeDB.Fechar();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroPessoa));
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDadosPessoais = new System.Windows.Forms.TabPage();
            this.tabEndereço = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpFísico = new System.Windows.Forms.GroupBox();
            this.grpEletrônico = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTelefone = new System.Windows.Forms.TabPage();
            this.grpTelefone = new System.Windows.Forms.GroupBox();
            this.tabObservações = new System.Windows.Forms.TabPage();
            this.txtObservações = new System.Windows.Forms.TextBox();
            this.tabDatas = new System.Windows.Forms.TabPage();
            this.ícones = new System.Windows.Forms.ImageList(this.components);
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.cmbRegião = new Apresentação.Pessoa.Endereço.ComboBoxRegião();
            this.endereços = new Apresentação.Pessoa.Cadastro.EditorEndereços();
            this.telefones = new Apresentação.Pessoa.Cadastro.EditorTelefones();
            this.datasRelevantes = new Apresentação.Pessoa.Cadastro.EditorDataRelevante();
            this.tab.SuspendLayout();
            this.tabEndereço.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpFísico.SuspendLayout();
            this.grpEletrônico.SuspendLayout();
            this.tabTelefone.SuspendLayout();
            this.grpTelefone.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.tabDatas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabDadosPessoais);
            this.tab.Controls.Add(this.tabEndereço);
            this.tab.Controls.Add(this.tabTelefone);
            this.tab.Controls.Add(this.tabObservações);
            this.tab.Controls.Add(this.tabDatas);
            this.tab.ImageList = this.ícones;
            this.tab.Location = new System.Drawing.Point(8, 8);
            this.tab.Multiline = true;
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(408, 481);
            this.tab.TabIndex = 0;
            // 
            // tabDadosPessoais
            // 
            this.tabDadosPessoais.BackColor = System.Drawing.Color.Transparent;
            this.tabDadosPessoais.ImageKey = "Dados Pessoais";
            this.tabDadosPessoais.Location = new System.Drawing.Point(4, 42);
            this.tabDadosPessoais.Name = "tabDadosPessoais";
            this.tabDadosPessoais.Size = new System.Drawing.Size(400, 435);
            this.tabDadosPessoais.TabIndex = 0;
            this.tabDadosPessoais.Text = "Dados pessoais";
            this.tabDadosPessoais.UseVisualStyleBackColor = true;
            // 
            // tabEndereço
            // 
            this.tabEndereço.BackColor = System.Drawing.Color.Transparent;
            this.tabEndereço.Controls.Add(this.groupBox1);
            this.tabEndereço.Controls.Add(this.grpFísico);
            this.tabEndereço.Controls.Add(this.grpEletrônico);
            this.tabEndereço.ImageKey = "Endereço";
            this.tabEndereço.Location = new System.Drawing.Point(4, 23);
            this.tabEndereço.Name = "tabEndereço";
            this.tabEndereço.Size = new System.Drawing.Size(400, 454);
            this.tabEndereço.TabIndex = 1;
            this.tabEndereço.Text = "Endereço";
            this.tabEndereço.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRegião);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atendimento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Região:";
            // 
            // grpFísico
            // 
            this.grpFísico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFísico.Controls.Add(this.endereços);
            this.grpFísico.Location = new System.Drawing.Point(3, 108);
            this.grpFísico.Name = "grpFísico";
            this.grpFísico.Size = new System.Drawing.Size(394, 347);
            this.grpFísico.TabIndex = 2;
            this.grpFísico.TabStop = false;
            this.grpFísico.Text = "Endereço físico";
            // 
            // grpEletrônico
            // 
            this.grpEletrônico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEletrônico.Controls.Add(this.txtEmail);
            this.grpEletrônico.Controls.Add(this.label1);
            this.grpEletrônico.Location = new System.Drawing.Point(3, 57);
            this.grpEletrônico.Name = "grpEletrônico";
            this.grpEletrônico.Size = new System.Drawing.Size(394, 45);
            this.grpEletrônico.TabIndex = 0;
            this.grpEletrônico.TabStop = false;
            this.grpEletrônico.Text = "Endereço Eletrônico";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(59, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(329, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Validated += new System.EventHandler(this.txtEmail_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail:";
            // 
            // tabTelefone
            // 
            this.tabTelefone.Controls.Add(this.grpTelefone);
            this.tabTelefone.ImageKey = "Telefone";
            this.tabTelefone.Location = new System.Drawing.Point(4, 23);
            this.tabTelefone.Name = "tabTelefone";
            this.tabTelefone.Size = new System.Drawing.Size(400, 454);
            this.tabTelefone.TabIndex = 4;
            this.tabTelefone.Text = "Telefone";
            this.tabTelefone.UseVisualStyleBackColor = true;
            // 
            // grpTelefone
            // 
            this.grpTelefone.Controls.Add(this.telefones);
            this.grpTelefone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTelefone.Location = new System.Drawing.Point(0, 0);
            this.grpTelefone.Name = "grpTelefone";
            this.grpTelefone.Size = new System.Drawing.Size(400, 454);
            this.grpTelefone.TabIndex = 1;
            this.grpTelefone.TabStop = false;
            this.grpTelefone.Text = "Telefone";
            // 
            // tabObservações
            // 
            this.tabObservações.BackColor = System.Drawing.Color.Transparent;
            this.tabObservações.Controls.Add(this.txtObservações);
            this.tabObservações.ImageKey = "Observações";
            this.tabObservações.Location = new System.Drawing.Point(4, 23);
            this.tabObservações.Name = "tabObservações";
            this.tabObservações.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tabObservações.Size = new System.Drawing.Size(400, 454);
            this.tabObservações.TabIndex = 2;
            this.tabObservações.Text = "Observações";
            this.tabObservações.UseVisualStyleBackColor = true;
            // 
            // txtObservações
            // 
            this.txtObservações.AcceptsReturn = true;
            this.txtObservações.AcceptsTab = true;
            this.txtObservações.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtObservações.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservações.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txtObservações.Location = new System.Drawing.Point(0, 3);
            this.txtObservações.Multiline = true;
            this.txtObservações.Name = "txtObservações";
            this.txtObservações.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservações.Size = new System.Drawing.Size(400, 448);
            this.txtObservações.TabIndex = 0;
            this.txtObservações.Validated += new System.EventHandler(this.txtObservações_Validated);
            // 
            // tabDatas
            // 
            this.tabDatas.Controls.Add(this.datasRelevantes);
            this.tabDatas.ImageKey = "Calendário";
            this.tabDatas.Location = new System.Drawing.Point(4, 42);
            this.tabDatas.Name = "tabDatas";
            this.tabDatas.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatas.Size = new System.Drawing.Size(400, 435);
            this.tabDatas.TabIndex = 5;
            this.tabDatas.Text = "Datas relevantes";
            this.tabDatas.UseVisualStyleBackColor = true;
            // 
            // ícones
            // 
            this.ícones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ícones.ImageStream")));
            this.ícones.TransparentColor = System.Drawing.Color.Transparent;
            this.ícones.Images.SetKeyName(0, "Dados Pessoais");
            this.ícones.Images.SetKeyName(1, "Endereço");
            this.ícones.Images.SetKeyName(2, "Observações");
            this.ícones.Images.SetKeyName(3, "Grupos");
            this.ícones.Images.SetKeyName(4, "Telefone");
            this.ícones.Images.SetKeyName(5, "Calendário");
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(260, 495);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.CausesValidation = false;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(341, 495);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 2;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Image = global::Apresentação.Resource.Excluir;
            this.btnExcluir.Location = new System.Drawing.Point(8, 495);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // cmbRegião
            // 
            this.cmbRegião.Location = new System.Drawing.Point(59, 19);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Região = null;
            this.cmbRegião.Size = new System.Drawing.Size(329, 21);
            this.cmbRegião.TabIndex = 1;
            this.cmbRegião.Validated += new System.EventHandler(this.cmbRegião_Validated);
            // 
            // endereços
            // 
            this.endereços.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endereços.Location = new System.Drawing.Point(3, 16);
            this.endereços.Name = "endereços";
            this.endereços.Size = new System.Drawing.Size(388, 328);
            this.endereços.TabIndex = 2;
            // 
            // telefones
            // 
            this.telefones.AutoSize = true;
            this.telefones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telefones.Location = new System.Drawing.Point(3, 16);
            this.telefones.Name = "telefones";
            this.telefones.Size = new System.Drawing.Size(394, 435);
            this.telefones.TabIndex = 0;
            // 
            // datasRelevantes
            // 
            this.datasRelevantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datasRelevantes.Location = new System.Drawing.Point(3, 3);
            this.datasRelevantes.Name = "datasRelevantes";
            this.datasRelevantes.Size = new System.Drawing.Size(394, 429);
            this.datasRelevantes.TabIndex = 0;
            // 
            // CadastroPessoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(426, 527);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroPessoa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro [Pessoa Física]";
            this.Load += new System.EventHandler(this.CadastroPessoaFísica_Load);
            this.tab.ResumeLayout(false);
            this.tabEndereço.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpFísico.ResumeLayout(false);
            this.grpEletrônico.ResumeLayout(false);
            this.grpEletrônico.PerformLayout();
            this.tabTelefone.ResumeLayout(false);
            this.grpTelefone.ResumeLayout(false);
            this.grpTelefone.PerformLayout();
            this.tabObservações.ResumeLayout(false);
            this.tabObservações.PerformLayout();
            this.tabDatas.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Dados da pessoa física
		/// </summary>
        [Browsable(false), DefaultValue(null), ReadOnly(true)]
		public virtual Entidades.Pessoa.Pessoa Pessoa
		{
			get
			{
                return entidade;
			}
			set
			{
                Control controle;

                entidade = value;


                if (value is PessoaFísica)
                {
                    DadosPessoaFísica pessoaFísica;

                    pessoaFísica = new DadosPessoaFísica();
                    pessoaFísica.Pessoa = (PessoaFísica)value;

                    controle = pessoaFísica;

                    Text = "Cadastro [Pessoa Física]";
                }
                else if (value is PessoaJurídica)
                {
                    DadosPessoaJurídica pessoaJurídica;

                    pessoaJurídica = new DadosPessoaJurídica();
                    pessoaJurídica.Pessoa = (PessoaJurídica)value;

                    controle = pessoaJurídica;

                    Text = "Cadastro [Pessoa Jurídica]";
                }
                else
                    throw new NotSupportedException("Tipo de pessoa não suportado para cadastro.");

                if (Pessoa.Cadastrado)
                {
                    TimeSpan TempoDesatualizado = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual - Pessoa.DataAlteração.Value;
                    double dias = Math.Round(TempoDesatualizado.TotalDays);

                    if (dias <= 1)
                        Text = "Ultima alteração na cadastro foi em " + Pessoa.DataAlteração.Value.ToShortDateString() + ", às " + Pessoa.DataAlteração.Value.ToShortTimeString();
                    else
                        Text = "Ultima alteração na cadastro tem " + dias + " dias";
                }

                // Prepara e adiciona controle na aba de dados pessoais.
                controle.Padding = new Padding(3);
                controle.Dock = DockStyle.Fill;

                tabDadosPessoais.Controls.Clear();
                tabDadosPessoais.Controls.Add(controle);

                endereços.Pessoa = value;
                telefones.Pessoa = value;
                datasRelevantes.Pessoa = value;

                txtObservações.Text = value.Observações;
                txtEmail.Text = value.EMail;

                cmbRegião.Região = value.Região;
            }
		}

        public Entidades.Privilégio.Permissão Privilégio
        {
            get
            {
                return Entidades.Privilégio.Permissão.CadastroAcesso;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Ocorre ao carregar a janela, ligando/desligando
        /// controles conforme privilégios do usuário.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CadastroPessoaFísica_Load(object sender, EventArgs e)
        {
            bool ligar;

            if (DesignMode)
                ligar = false;
            else
            {
                PermissãoFuncionário.AssegurarPermissão(Permissão.CadastroAcesso);

                ligar = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroEditar);
            }

            tabDadosPessoais.Enabled = ligar;
            grpEletrônico.Enabled = ligar;
            grpFísico.Enabled = ligar;
            endereços.Enabled = ligar;
            txtObservações.Enabled = ligar;
        }

        /// <summary>
        /// Inicia processo de cadastramento de novo cliente,
        /// funcionário ou representante.
        /// </summary>
        public static Entidades.Pessoa.Pessoa MostrarCadastrar()
        {
            using (Apresentação.Pessoa.Cadastro.Cadastrar dlg = new Cadastrar())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    switch (dlg.TipoPessoa)
                    {
                        case Entidades.Pessoa.TipoPessoa.Física:
                            return CadastrarNovaPessoaFísica(dlg.TipoPessoaFísica);

                        case Entidades.Pessoa.TipoPessoa.Jurídica:
                            return CadastrarNovaPessoaJurídica();

                        default:
                            throw new NotSupportedException("Tipo de pessoa não suportado para cadastrar.");
                    }
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Cadastra nova pessoa-física.
        /// </summary>
        private static Entidades.Pessoa.PessoaFísica CadastrarNovaPessoaFísica(Entidades.Pessoa.TipoPessoaFísica tipoPessoaFísica)
        {
            Entidades.Pessoa.PessoaFísica entidade = null;
            CadastroPessoa dlg;
            bool insistir;

            // Constrói a janela.
            switch (tipoPessoaFísica)
            {
                case Entidades.Pessoa.TipoPessoaFísica.Outro:
                    dlg = new CadastroCliente(new PessoaFísica());
                    break;

                case Entidades.Pessoa.TipoPessoaFísica.Funcionário:
                    dlg = new CadastroFuncionário(new Funcionário());
                    break;

                case Entidades.Pessoa.TipoPessoaFísica.Representante:
                    dlg = new CadastroRepresentante(new Representante());
                    break;

                default:
                    throw new NotSupportedException("Tipo de pessoa-física não suportado.");
            }

            try
            {
                // Tenta cadastrar.
                do
                {
                    insistir = false;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        switch (tipoPessoaFísica)
                        {
                            case Entidades.Pessoa.TipoPessoaFísica.Outro:
                                entidade = (PessoaFísica)dlg.Pessoa;
                                break;

                            case Entidades.Pessoa.TipoPessoaFísica.Funcionário:
                                entidade = ((CadastroFuncionário)dlg).Funcionário;
                                break;

                            case Entidades.Pessoa.TipoPessoaFísica.Representante:
                                entidade = (PessoaFísica)((CadastroRepresentante)dlg).Pessoa;
                                break;

                            default:
                                throw new NotSupportedException("Tipo de pessoa-física não suportado.");
                        }

                        Apresentação.Formulários.AguardeDB.Mostrar();

                        if (entidade.CPF != null && Entidades.Pessoa.PessoaFísica.VerificarExistênciaCPF(entidade.CPF))
                        {
                            Apresentação.Formulários.AguardeDB.Fechar();

                            insistir = MessageBox.Show(
                                "O CPF " + entidade.CPF + " já encontra-se cadastrado no banco de dados.",
                                "Cadastro de Pessoa Física",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry;
                        }
                        else
                        {
                            try
                            {
                                entidade.Cadastrar();
                                Apresentação.Formulários.AguardeDB.Fechar();
                            }
                            catch (Exception e)
                            {
                                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                                Apresentação.Formulários.AguardeDB.Fechar();

                                insistir = MessageBox.Show(
                                    "Não foi possível cadastrar a pessoa física. Por favor, verifique se os dados estão corretos.",
                                    "Erro cadastrando pessoa física",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry;
                            }
                        }
                    }
                } while (insistir);
            }
            finally
            {
                dlg.Dispose();
            }

            return entidade;
        }

        /// <summary>
        /// Cadastro de pessoa jurídica.
        /// </summary>
        public static Entidades.Pessoa.PessoaJurídica CadastrarNovaPessoaJurídica()
        {
            bool insistir;
            CadastroPessoa dlg;
            PessoaJurídica entidade;

            using (dlg = new CadastroCliente(new PessoaJurídica()))
            {
                // Tenta cadastrar.
                do
                {
                    insistir = false;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Apresentação.Formulários.AguardeDB.Mostrar();

                        entidade = (PessoaJurídica)dlg.Pessoa;

                        if (Entidades.Pessoa.PessoaJurídica.VerificarExistênciaCNPJ(entidade))
                        {
                            Apresentação.Formulários.AguardeDB.Fechar();

                            insistir = MessageBox.Show(
                                "O CNPJ " + entidade.CNPJ + " já encontra-se cadastrado no banco de dados.",
                                "Cadastro de Pessoa Jurídica",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry;
                        }
                        else
                        {
                            try
                            {
                                entidade.Cadastrar();
                                Apresentação.Formulários.AguardeDB.Fechar();
                            }
                            catch (Exception e)
                            {
                                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                                Apresentação.Formulários.AguardeDB.Fechar();

                                insistir = MessageBox.Show(
                                    "Não foi possível cadastrar a pessoa jurídica. Por favor, verifique se os dados estão corretos.",
                                    "Erro cadastrando pessoa jurídica",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry;
                            }
                        }
                    }
                    else
                        entidade = null;
                } while (insistir);
            }

            return entidade;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Visible | ValidationConstraints.Enabled);

            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        protected virtual bool Validar()
        {
            return true;
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (email.Length > 0)
                entidade.EMail = email;
            else
                entidade.EMail = null;
        }

        private void txtObservações_Validated(object sender, EventArgs e)
        {
            string obs = txtObservações.Text.Trim();

            if (obs.Length > 0)
                entidade.Observações = obs;
            else
                entidade.Observações = null;
        }

        private void cmbRegião_Validated(object sender, EventArgs e)
        {
            Pessoa.Região = cmbRegião.Região;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PermissãoFuncionário.AssegurarPermissão(Permissão.CadastroRemover);

            if (MessageBox.Show(
                this,
                "Deseja mesmo excluir toda a ficha desta pessoa?",
                "Exclusão de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            if (MessageBox.Show(
                this,
                "Um cadastro só deveria ser desfeito se ele estiver duplicado. Você tem certeza mesmo de que deseja continuar?",
                "Exclusão de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            if (MessageBox.Show(
                this,
                "Após a exclusão do cadastro não será possível recuperar nenhum dado acerca desta pessoa!",
                "Exclusão de cadastro",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            if (MessageBox.Show(
                this,
                "Você está removendo do banco de dados todas as informações referentes a " + Pessoa.Nome + " (código " + Pessoa.Código.ToString() + ")\n\nDeseja interromper esta exclusão?",
                "Exclusão de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.No)
                return;

            if (!Login.ExigirIdentificação(
                this,
                Permissão.CadastroRemover,
                Funcionário.FuncionárioAtual,
                "Exclusão de cadastro",
                "Exclusão de cadastro de " + Pessoa.Nome,
                "O cadastro de " + Pessoa.Nome + " está para ser descadastrado, bem como todos os seus vínculos (pagamentos, vendas, consignado, consertos, etc.)"))
                return;

            if (MessageBox.Show(
                this,
                "Ao excluir uma ficha de uma pessoa, todos os dados de saída de consignado, vendas e consertos pendentes, além de todo o seu histórico será perdido.\n\nLembre-se que esta é uma operação irreversível.",
                "Exclusão de cadastro",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            if (MessageBox.Show(
                this,
                "O cadastro de " + Pessoa.Nome + " (código " + Pessoa.Código.ToString() + ") será removido agora.",
                "Exclusão de cadastro",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            AguardeDB.Mostrar();

            try
            {
                Pessoa.Descadastrar();
            }
            catch (ExceçãoClientePossuiPendências erro)
            {
                AguardeDB.Fechar();
                MessageBox.Show(
                    this,
                    "Não foi possível descadatrar a pessoa, pois ela possui pendências no sistema:\n\n"
                    + erro.Message,
                    "Exclusão de cadastro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                AguardeDB.Fechar();

                this.DialogResult = DialogResult.Abort;
                Close();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
