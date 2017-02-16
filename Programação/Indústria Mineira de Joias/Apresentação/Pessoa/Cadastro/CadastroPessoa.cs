using Apresenta��o.Formul�rios;
using Entidades.Pessoa;
using Entidades.Privil�gio;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Cadastro
{
    /// <summary>
    /// Tela para cadastro de pessoa.
    /// </summary>
    public class CadastroPessoa : Form, IRequerPrivil�gio
    {
        private Entidades.Pessoa.Pessoa entidade;
        protected TabControl tab;

        // Designer
        private System.Windows.Forms.TabPage tabDadosPessoais;
        protected System.Windows.Forms.ImageList �cones;
        private System.Windows.Forms.TabPage tabEndere�o;
        protected Button cmdOK;
        protected System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.TabPage tabObserva��es;
        private System.Windows.Forms.TextBox txtObserva��es;
        private GroupBox grpEletr�nico;
        private TextBox txtEmail;
        private Label label1;
        private TabPage tabTelefone;
        private GroupBox grpF�sico;
        private EditorEndere�os endere�os;
        private GroupBox grpTelefone;
        private EditorTelefones telefones;
        private TabPage tabDatas;
        private EditorDataRelevante datasRelevantes;
        private GroupBox groupBox1;
        private Label label2;
        private Apresenta��o.Pessoa.Endere�o.ComboBoxRegi�o cmbRegi�o;
        protected Button btnExcluir;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Constr�i o forml�rio de cadastro de pessoa f�sica.
        /// </summary>
        /// <remarks>
        /// A pessoa f�sica N�O � cadastrada/atualizada no
        /// banco de dados.
        /// </remarks>
        public CadastroPessoa()
        {
            InitializeComponent();

            btnExcluir.Visible = btnExcluir.Enabled = Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.CadastroRemover);
        }

        /// <summary>
        /// Constr�i o cadastro de pessoa a partir de dados
        /// j� definidos.
        /// </summary>
        /// <param name="pessoa">Pessoa f�sica ou jur�dica.</param>
        public CadastroPessoa(Entidades.Pessoa.Pessoa pessoa) : this()
        {
            AguardeDB.Mostrar();

            this.Pessoa = pessoa;

            AguardeDB.Fechar();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroPessoa));
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDadosPessoais = new System.Windows.Forms.TabPage();
            this.tabEndere�o = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRegi�o = new Apresenta��o.Pessoa.Endere�o.ComboBoxRegi�o();
            this.label2 = new System.Windows.Forms.Label();
            this.grpF�sico = new System.Windows.Forms.GroupBox();
            this.endere�os = new Apresenta��o.Pessoa.Cadastro.EditorEndere�os();
            this.grpEletr�nico = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTelefone = new System.Windows.Forms.TabPage();
            this.grpTelefone = new System.Windows.Forms.GroupBox();
            this.telefones = new Apresenta��o.Pessoa.Cadastro.EditorTelefones();
            this.tabObserva��es = new System.Windows.Forms.TabPage();
            this.txtObserva��es = new System.Windows.Forms.TextBox();
            this.tabDatas = new System.Windows.Forms.TabPage();
            this.datasRelevantes = new Apresenta��o.Pessoa.Cadastro.EditorDataRelevante();
            this.�cones = new System.Windows.Forms.ImageList(this.components);
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabEndere�o.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpF�sico.SuspendLayout();
            this.grpEletr�nico.SuspendLayout();
            this.tabTelefone.SuspendLayout();
            this.grpTelefone.SuspendLayout();
            this.tabObserva��es.SuspendLayout();
            this.tabDatas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabDadosPessoais);
            this.tab.Controls.Add(this.tabEndere�o);
            this.tab.Controls.Add(this.tabTelefone);
            this.tab.Controls.Add(this.tabObserva��es);
            this.tab.Controls.Add(this.tabDatas);
            this.tab.ImageList = this.�cones;
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
            // tabEndere�o
            // 
            this.tabEndere�o.BackColor = System.Drawing.Color.Transparent;
            this.tabEndere�o.Controls.Add(this.groupBox1);
            this.tabEndere�o.Controls.Add(this.grpF�sico);
            this.tabEndere�o.Controls.Add(this.grpEletr�nico);
            this.tabEndere�o.ImageKey = "Endere�o";
            this.tabEndere�o.Location = new System.Drawing.Point(4, 42);
            this.tabEndere�o.Name = "tabEndere�o";
            this.tabEndere�o.Size = new System.Drawing.Size(400, 435);
            this.tabEndere�o.TabIndex = 1;
            this.tabEndere�o.Text = "Endere�o";
            this.tabEndere�o.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRegi�o);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atendimento";
            // 
            // cmbRegi�o
            // 
            this.cmbRegi�o.Location = new System.Drawing.Point(59, 19);
            this.cmbRegi�o.Name = "cmbRegi�o";
            this.cmbRegi�o.Regi�o = null;
            this.cmbRegi�o.Size = new System.Drawing.Size(329, 21);
            this.cmbRegi�o.TabIndex = 1;
            this.cmbRegi�o.Validated += new System.EventHandler(this.cmbRegi�o_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Regi�o:";
            // 
            // grpF�sico
            // 
            this.grpF�sico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpF�sico.Controls.Add(this.endere�os);
            this.grpF�sico.Location = new System.Drawing.Point(3, 108);
            this.grpF�sico.Name = "grpF�sico";
            this.grpF�sico.Size = new System.Drawing.Size(394, 328);
            this.grpF�sico.TabIndex = 2;
            this.grpF�sico.TabStop = false;
            this.grpF�sico.Text = "Endere�o f�sico";
            // 
            // endere�os
            // 
            this.endere�os.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endere�os.Location = new System.Drawing.Point(3, 16);
            this.endere�os.Name = "endere�os";
            this.endere�os.Size = new System.Drawing.Size(388, 309);
            this.endere�os.TabIndex = 2;
            // 
            // grpEletr�nico
            // 
            this.grpEletr�nico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEletr�nico.Controls.Add(this.txtEmail);
            this.grpEletr�nico.Controls.Add(this.label1);
            this.grpEletr�nico.Location = new System.Drawing.Point(3, 57);
            this.grpEletr�nico.Name = "grpEletr�nico";
            this.grpEletr�nico.Size = new System.Drawing.Size(394, 45);
            this.grpEletr�nico.TabIndex = 0;
            this.grpEletr�nico.TabStop = false;
            this.grpEletr�nico.Text = "Endere�o Eletr�nico";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(59, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(329, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
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
            // telefones
            // 
            this.telefones.AutoSize = true;
            this.telefones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telefones.Location = new System.Drawing.Point(3, 16);
            this.telefones.Name = "telefones";
            this.telefones.Size = new System.Drawing.Size(394, 435);
            this.telefones.TabIndex = 0;
            // 
            // tabObserva��es
            // 
            this.tabObserva��es.BackColor = System.Drawing.Color.Transparent;
            this.tabObserva��es.Controls.Add(this.txtObserva��es);
            this.tabObserva��es.ImageKey = "Observa��es";
            this.tabObserva��es.Location = new System.Drawing.Point(4, 23);
            this.tabObserva��es.Name = "tabObserva��es";
            this.tabObserva��es.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tabObserva��es.Size = new System.Drawing.Size(400, 454);
            this.tabObserva��es.TabIndex = 2;
            this.tabObserva��es.Text = "Observa��es";
            this.tabObserva��es.UseVisualStyleBackColor = true;
            // 
            // txtObserva��es
            // 
            this.txtObserva��es.AcceptsReturn = true;
            this.txtObserva��es.AcceptsTab = true;
            this.txtObserva��es.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtObserva��es.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObserva��es.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txtObserva��es.Location = new System.Drawing.Point(0, 3);
            this.txtObserva��es.Multiline = true;
            this.txtObserva��es.Name = "txtObserva��es";
            this.txtObserva��es.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObserva��es.Size = new System.Drawing.Size(400, 448);
            this.txtObserva��es.TabIndex = 0;
            this.txtObserva��es.Validated += new System.EventHandler(this.txtObserva��es_Validated);
            // 
            // tabDatas
            // 
            this.tabDatas.Controls.Add(this.datasRelevantes);
            this.tabDatas.ImageKey = "Calend�rio";
            this.tabDatas.Location = new System.Drawing.Point(4, 42);
            this.tabDatas.Name = "tabDatas";
            this.tabDatas.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatas.Size = new System.Drawing.Size(400, 435);
            this.tabDatas.TabIndex = 5;
            this.tabDatas.Text = "Datas relevantes";
            this.tabDatas.UseVisualStyleBackColor = true;
            // 
            // datasRelevantes
            // 
            this.datasRelevantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datasRelevantes.Location = new System.Drawing.Point(3, 3);
            this.datasRelevantes.Name = "datasRelevantes";
            this.datasRelevantes.Size = new System.Drawing.Size(394, 429);
            this.datasRelevantes.TabIndex = 0;
            // 
            // �cones
            // 
            this.�cones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("�cones.ImageStream")));
            this.�cones.TransparentColor = System.Drawing.Color.Transparent;
            this.�cones.Images.SetKeyName(0, "Dados Pessoais");
            this.�cones.Images.SetKeyName(1, "Endere�o");
            this.�cones.Images.SetKeyName(2, "Observa��es");
            this.�cones.Images.SetKeyName(3, "Grupos");
            this.�cones.Images.SetKeyName(4, "Telefone");
            this.�cones.Images.SetKeyName(5, "Calend�rio");
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
            this.btnExcluir.Image = global::Apresenta��o.Resource.Excluir;
            this.btnExcluir.Location = new System.Drawing.Point(8, 495);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
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
            this.Text = "Cadastro [Pessoa F�sica]";
            this.Load += new System.EventHandler(this.CadastroPessoaF�sica_Load);
            this.tab.ResumeLayout(false);
            this.tabEndere�o.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpF�sico.ResumeLayout(false);
            this.grpEletr�nico.ResumeLayout(false);
            this.grpEletr�nico.PerformLayout();
            this.tabTelefone.ResumeLayout(false);
            this.grpTelefone.ResumeLayout(false);
            this.grpTelefone.PerformLayout();
            this.tabObserva��es.ResumeLayout(false);
            this.tabObserva��es.PerformLayout();
            this.tabDatas.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Dados da pessoa f�sica
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


                if (value is PessoaF�sica)
                {
                    DadosPessoaF�sica pessoaF�sica;

                    pessoaF�sica = new DadosPessoaF�sica();
                    pessoaF�sica.Pessoa = (PessoaF�sica)value;

                    controle = pessoaF�sica;

                    Text = "Cadastro [Pessoa F�sica]";
                }
                else if (value is PessoaJur�dica)
                {
                    DadosPessoaJur�dica pessoaJur�dica;

                    pessoaJur�dica = new DadosPessoaJur�dica();
                    pessoaJur�dica.Pessoa = (PessoaJur�dica)value;

                    controle = pessoaJur�dica;

                    Text = "Cadastro [Pessoa Jur�dica]";
                }
                else
                    throw new NotSupportedException("Tipo de pessoa n�o suportado para cadastro.");

                if (Pessoa.Cadastrado)
                {
                    TimeSpan TempoDesatualizado = Entidades.Configura��o.DadosGlobais.Inst�ncia.HoraDataAtual - Pessoa.DataAltera��o.Value;
                    double dias = Math.Round(TempoDesatualizado.TotalDays);

                    if (dias <= 1)
                        Text = "�ltima altera��o na cadastro foi em " + Pessoa.DataAltera��o.Value.ToShortDateString() + ", �s " + Pessoa.DataAltera��o.Value.ToShortTimeString();
                    else
                        Text = "�ltima altera��o na cadastro: " + dias + " dias";
                }

                // Prepara e adiciona controle na aba de dados pessoais.
                controle.Padding = new Padding(3);
                controle.Dock = DockStyle.Fill;

                tabDadosPessoais.Controls.Clear();
                tabDadosPessoais.Controls.Add(controle);

                endere�os.Pessoa = value;
                telefones.Pessoa = value;
                datasRelevantes.Pessoa = value;

                txtObserva��es.Text = value.Observa��es;
                txtEmail.Text = value.EMail;

                cmbRegi�o.Regi�o = value.Regi�o;
            }
        }

        public Permiss�o Privil�gio
        {
            get
            {
                return Permiss�o.CadastroAcesso;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Ocorre ao carregar a janela, ligando/desligando
        /// controles conforme privil�gios do usu�rio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CadastroPessoaF�sica_Load(object sender, EventArgs e)
        {
            bool ligar;

            if (DesignMode)
                ligar = false;
            else
            {
                Permiss�oFuncion�rio.AssegurarPermiss�o(Permiss�o.CadastroAcesso);

                ligar = Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.CadastroEditar);
            }

            tabDadosPessoais.Enabled = ligar;
            grpEletr�nico.Enabled = ligar;
            grpF�sico.Enabled = ligar;
            endere�os.Enabled = ligar;
            txtObserva��es.Enabled = ligar;
        }

        /// <summary>
        /// Inicia processo de cadastramento de novo cliente,
        /// funcion�rio ou representante.
        /// </summary>
        public static Entidades.Pessoa.Pessoa MostrarCadastrar()
        {
            using (Cadastrar dlg = new Cadastrar())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    switch (dlg.TipoPessoa)
                    {
                        case TipoPessoa.F�sica:
                            return CadastrarNovaPessoaF�sica(dlg.TipoPessoaF�sica);

                        case TipoPessoa.Jur�dica:
                            return CadastrarNovaPessoaJur�dica();

                        default:
                            throw new NotSupportedException("Tipo de pessoa n�o suportado para cadastrar.");
                    }
                }
                else
                    return null;
            }
        }

        private static PessoaF�sica CadastrarNovaPessoaF�sica(TipoPessoaF�sica tipoPessoaF�sica)
        {
            PessoaF�sica entidade = null;
            CadastroPessoa dlg = Constr�iJanelaCadastro(tipoPessoaF�sica);

            try
            {
                TentaCadastrarPessoaF�sica(tipoPessoaF�sica, ref entidade, dlg);
            }
            finally
            {
                dlg.Dispose();
            }

            return entidade;
        }

        private static void TentaCadastrarPessoaF�sica(TipoPessoaF�sica tipoPessoaF�sica, ref PessoaF�sica entidade, CadastroPessoa janela)
        {
            bool insistir;

            do
            {
                insistir = false;

                if (janela.ShowDialog() == DialogResult.OK)
                {
                    switch (tipoPessoaF�sica)
                    {
                        case TipoPessoaF�sica.Outro:
                            entidade = (PessoaF�sica)janela.Pessoa;
                            break;

                        case TipoPessoaF�sica.Funcion�rio:
                            entidade = ((CadastroFuncion�rio)janela).Funcion�rio;
                            break;

                        case TipoPessoaF�sica.Representante:
                            entidade = (PessoaF�sica)((CadastroRepresentante)janela).Pessoa;
                            break;

                        default:
                            throw new NotSupportedException("Tipo de pessoa-f�sica n�o suportado.");
                    }

                    AguardeDB.Mostrar();

                    if (entidade.CPF != null && PessoaF�sica.VerificarExist�nciaCPF(entidade.CPF))
                    {
                        AguardeDB.Fechar();

                        insistir = MessageBox.Show(
                            "O CPF " + entidade.CPF + " j� encontra-se cadastrado no banco de dados.",
                            "Cadastro de Pessoa F�sica",
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry;
                    }
                    else
                    {
                        try
                        {
                            entidade.Cadastrar();
                            AguardeDB.Fechar();
                        }
                        catch (Exception e)
                        {
                            Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                            AguardeDB.Fechar();

                            insistir = MessageBox.Show(
                                "N�o foi poss�vel cadastrar a pessoa f�sica. Por favor, verifique se os dados est�o corretos.",
                                "Erro cadastrando pessoa f�sica",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry;
                        }
                    }
                }
            } while (insistir);
        }

        private static CadastroPessoa Constr�iJanelaCadastro(TipoPessoaF�sica tipoPessoaF�sica)
        {
            CadastroPessoa dlg;
            switch (tipoPessoaF�sica)
            {
                case TipoPessoaF�sica.Outro:
                    dlg = new CadastroCliente(new PessoaF�sica());
                    break;

                case TipoPessoaF�sica.Funcion�rio:
                    dlg = new CadastroFuncion�rio(new Funcion�rio());
                    break;

                case TipoPessoaF�sica.Representante:
                    dlg = new CadastroRepresentante(new Representante());
                    break;

                default:
                    throw new NotSupportedException("Tipo de pessoa-f�sica n�o suportado.");
            }

            return dlg;
        }

        public static PessoaJur�dica CadastrarNovaPessoaJur�dica()
        {
            using (CadastroPessoa janela = new CadastroCliente(new PessoaJur�dica()))
            {
                return TentaCadastrarPessoaJur�dica(janela);
            }
        }

        private static PessoaJur�dica TentaCadastrarPessoaJur�dica(CadastroPessoa dlg)
        {
            bool insistir;
            PessoaJur�dica entidade = null;

            do
            {
                insistir = false;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    entidade = (PessoaJur�dica)dlg.Pessoa;

                    if (PessoaJur�dica.VerificarExist�nciaCNPJ(entidade))
                    {
                        AguardeDB.Fechar();

                        insistir = MessageBox.Show(
                            "O CNPJ " + entidade.CNPJ + " j� encontra-se cadastrado no banco de dados.",
                            "Cadastro de Pessoa Jur�dica",
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry;
                    }
                    else
                    {
                        try
                        {
                            entidade.Cadastrar();
                            AguardeDB.Fechar();
                        }
                        catch (Exception e)
                        {
                            Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                            AguardeDB.Fechar();

                            insistir = MessageBox.Show(
                                "N�o foi poss�vel cadastrar a pessoa jur�dica. Por favor, verifique se os dados est�o corretos.",
                                "Erro cadastrando pessoa jur�dica",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry;
                        }
                    }
                }
                else
                    entidade = null;
            } while (insistir);

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
            if (entidade.PossuiAlgumEndere�oInv�lido())
            {
                tab.SelectTab(tabEndere�o);

                MessageBox.Show(
                    this,
                    "Algum endere�o � inv�lido. ",
                    "Cadastro de funcion�rio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

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

        private void txtObserva��es_Validated(object sender, EventArgs e)
        {
            string obs = txtObserva��es.Text.Trim();

            if (obs.Length > 0)
                entidade.Observa��es = obs;
            else
                entidade.Observa��es = null;
        }

        private void cmbRegi�o_Validated(object sender, EventArgs e)
        {
            Pessoa.Regi�o = cmbRegi�o.Regi�o;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Permiss�oFuncion�rio.AssegurarPermiss�o(Permiss�o.CadastroRemover);

            if (MessageBox.Show(
                this,
                "Deseja mesmo excluir toda a ficha desta pessoa?",
                "Exclus�o de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            if (MessageBox.Show(
                this,
                "Um cadastro s� deveria ser desfeito se ele estiver duplicado. Voc� tem certeza mesmo de que deseja continuar?",
                "Exclus�o de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            if (MessageBox.Show(
                this,
                "Ap�s a exclus�o do cadastro n�o ser� poss�vel recuperar nenhum dado acerca desta pessoa!",
                "Exclus�o de cadastro",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            if (MessageBox.Show(
                this,
                "Voc� est� removendo do banco de dados todas as informa��es referentes a " + Pessoa.Nome + " (c�digo " + Pessoa.C�digo.ToString() + ")\n\nDeseja interromper esta exclus�o?",
                "Exclus�o de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.No)
                return;

            if (!Login.ExigirIdentifica��o(
                this,
                Permiss�o.CadastroRemover,
                Funcion�rio.Funcion�rioAtual,
                "Exclus�o de cadastro",
                "Exclus�o de cadastro de " + Pessoa.Nome,
                "O cadastro de " + Pessoa.Nome + " est� para ser descadastrado, bem como todos os seus v�nculos (pagamentos, vendas, consignado, consertos, etc.)"))
                return;

            if (MessageBox.Show(
                this,
                "Ao excluir uma ficha de uma pessoa, todos os dados de sa�da de consignado, vendas e consertos pendentes, al�m de todo o seu hist�rico ser� perdido.\n\nLembre-se que esta � uma opera��o irrevers�vel.",
                "Exclus�o de cadastro",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            if (MessageBox.Show(
                this,
                "O cadastro de " + Pessoa.Nome + " (c�digo " + Pessoa.C�digo.ToString() + ") ser� removido agora.",
                "Exclus�o de cadastro",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            AguardeDB.Mostrar();

            try
            {
                Pessoa.Descadastrar();
            }
            catch (Exce��oClientePossuiPend�ncias erro)
            {
                AguardeDB.Fechar();
                MessageBox.Show(
                    this,
                    "N�o foi poss�vel descadatrar a pessoa, pois ela possui pend�ncias no sistema:\n\n"
                    + erro.Message,
                    "Exclus�o de cadastro",
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim().Length == 0)
            {
                e.Cancel = false;
                return;
            }

            string[] emails = txtEmail.Text.Split(new char[] { ',', ' ', ';' });

            try
            {
                foreach (String email in emails)
                    new MailAddress(email);

                e.Cancel = false;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }


        public static DialogResult Abrir(Entidades.Pessoa.Pessoa pessoa, IWin32Window pai,
        out Entidades.Pessoa.Pessoa pessoaAtualizada)
        {
            DialogResult resultado;

            if (Funcion�rio.�Funcion�rio(pessoa))
            {
                AguardeDB.Mostrar();

                try
                {
                    if (!(pessoa is Funcion�rio))
                        pessoa = Funcion�rio.ObterPessoa(pessoa.C�digo);
                }
                finally
                {
                    AguardeDB.Fechar();
                }

                using (CadastroFuncion�rio frm = new CadastroFuncion�rio((Entidades.Pessoa.Funcion�rio)pessoa))
                {
                    resultado = frm.ShowDialog(pai);
                    pessoaAtualizada = frm.Funcion�rio;
                }
            }
            else if (pessoa is PessoaF�sica)
            {
                using (CadastroCliente frm = new CadastroCliente((PessoaF�sica)pessoa))
                {
                    resultado = frm.ShowDialog(pai);
                    pessoaAtualizada = frm.Pessoa;
                }
            }
            else if (pessoa is PessoaJur�dica)
                using (CadastroCliente frm = new CadastroCliente((PessoaJur�dica)pessoa))
                {
                    resultado = frm.ShowDialog(pai);
                    pessoaAtualizada = frm.Pessoa;
                }
            else if (pessoa is Entidades.Pessoa.Pessoa)
            {
                PessoaJur�dica juridica = PessoaJur�dica.ObterPessoa(pessoa.C�digo);

                if (juridica != null)
                {
                    using (CadastroCliente frm = new CadastroCliente(juridica))
                    {
                        resultado = frm.ShowDialog(pai);
                        pessoaAtualizada = frm.Pessoa;
                    }
                }
                else
                {
                    PessoaF�sica fisica = PessoaF�sica.ObterPessoa(pessoa.C�digo);

                    if (fisica != null)
                    {
                        using (CadastroCliente frm = new CadastroCliente(fisica))
                        {
                            resultado = frm.ShowDialog(pai);
                            pessoaAtualizada = frm.Pessoa;
                        }
                    }
                    else
                    {
                        throw new Exception("A pessoa � do Tipo Entidades.Pessoa, por�m n�o � f�sica nem jur�dica!");
                    }
                }
            }
            else
            {
                throw new NotSupportedException("O tipo de pessoa \"" + pessoa.GetType().Name + "\" n�o � suportado. C�digo:" + pessoa.C�digo.ToString());
            }

            if (resultado == DialogResult.OK)
                pessoaAtualizada.Atualizar();

            return resultado;
        }
    }
}
