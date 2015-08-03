using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using System.Collections.Generic;
using Entidades.Configuração;

namespace Apresentação.Pessoa.Cadastro
{
	public class CadastroFuncionário : Apresentação.Pessoa.Cadastro.CadastroPessoa
	{
		private System.Windows.Forms.TabPage tabTrabalho;
		private Apresentação.Pessoa.Cadastro.DadosFuncionário funcionário;
		private System.Windows.Forms.Button btnImprimir;
		private Report.Layout.DocumentLayout documentLayout;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.PrintDialog printDialog;
        private TabPage tabPrivilégios;
        private Permissões permissões;
        private TabPage tabHorárioTrabalho;
        private HorárioTrabalho horárioTrabalho;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói o cadastro de funcionário, considerando
		/// uma lista de funcionários.
		/// </summary>
		/// <remarks>
		/// O funcionário NÃO é cadastrado/atualizado no
		/// banco de dados.
		/// </remarks>
		public CadastroFuncionário()
		{
            Entidades.Pessoa.Funcionário funcionário;

			CarregarSetores();

            funcionário = new Entidades.Pessoa.Funcionário();

            // Construir horário padrão.
            foreach (DayOfWeek dia in new DayOfWeek[] {
                DayOfWeek.Monday, DayOfWeek.Tuesday,
                DayOfWeek.Wednesday, DayOfWeek.Thursday,
                DayOfWeek.Friday })
            {
                funcionário.TabelaHorário.Adicionar(
                    new Entidades.Pessoa.Horário(
                    funcionário,
                    dia,
                    08, 00,
                    11, 59));

                funcionário.TabelaHorário.Adicionar(
                    new Entidades.Pessoa.Horário(
                    funcionário,
                    dia,
                    13, 00,
                    17, 59));
            }

            funcionário.DataAdmissão = DadosGlobais.Instância.HoraDataAtual.Date;

            this.Funcionário = funcionário;
		}

		/// <remarks>
		/// A pessoa física NÃO é cadastrada/atualizada no
		/// banco de dados.
		/// </remarks>
		/// <remarks>
		/// O funcionário NÃO é cadastrada/atualizada no
		/// banco de dados.
		/// </remarks>
		public CadastroFuncionário(Entidades.Pessoa.Funcionário funcionário)
		{
            CarregarSetores();

			this.Funcionário = funcionário;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroFuncionário));
            this.tabTrabalho = new System.Windows.Forms.TabPage();
            this.funcionário = new Apresentação.Pessoa.Cadastro.DadosFuncionário();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.documentLayout = new Report.Layout.DocumentLayout(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.tabPrivilégios = new System.Windows.Forms.TabPage();
            this.permissões = new Apresentação.Pessoa.Cadastro.Permissões();
            this.tabHorárioTrabalho = new System.Windows.Forms.TabPage();
            this.horárioTrabalho = new Apresentação.Pessoa.Cadastro.HorárioTrabalho();
            this.tab.SuspendLayout();
            this.tabTrabalho.SuspendLayout();
            this.tabPrivilégios.SuspendLayout();
            this.tabHorárioTrabalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabTrabalho);
            this.tab.Controls.Add(this.tabPrivilégios);
            this.tab.Size = new System.Drawing.Size(408, 484);
            this.tab.Controls.SetChildIndex(this.tabPrivilégios, 0);
            this.tab.Controls.SetChildIndex(this.tabTrabalho, 0);
            // 
            // ícones
            // 
            this.ícones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ícones.ImageStream")));
            this.ícones.Images.SetKeyName(0, "Dados pessoais");
            this.ícones.Images.SetKeyName(1, "Endereço");
            this.ícones.Images.SetKeyName(2, "Observações");
            this.ícones.Images.SetKeyName(3, "Grupos");
            this.ícones.Images.SetKeyName(4, "Telefone");
            this.ícones.Images.SetKeyName(5, "Calendário");
            this.ícones.Images.SetKeyName(6, "Trabalho");
            this.ícones.Images.SetKeyName(7, "Relógio");
            this.ícones.Images.SetKeyName(8, "Privilégios");
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(256, 498);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(337, 498);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(8, 498);
            // 
            // tabTrabalho
            // 
            this.tabTrabalho.Controls.Add(this.funcionário);
            this.tabTrabalho.ImageKey = "Trabalho";
            this.tabTrabalho.Location = new System.Drawing.Point(4, 42);
            this.tabTrabalho.Name = "tabTrabalho";
            this.tabTrabalho.Size = new System.Drawing.Size(400, 435);
            this.tabTrabalho.TabIndex = 2;
            this.tabTrabalho.Text = "Trabalho";
            this.tabTrabalho.UseVisualStyleBackColor = true;
            // 
            // funcionário
            // 
            this.funcionário.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionário.Location = new System.Drawing.Point(8, 8);
            this.funcionário.Name = "funcionário";
            this.funcionário.Size = new System.Drawing.Size(384, 422);
            this.funcionário.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(89, 498);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // documentLayout
            // 
            this.documentLayout.Document = this.printDocument;
            this.documentLayout.Objects = null;
            this.documentLayout.XmlFileName = "RelatórioFichaFuncionário.xml";
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "Ficha de Funcionário";
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.UseAntiAlias = true;
            this.printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.AllowSomePages = true;
            this.printDialog.Document = this.printDocument;
            // 
            // tabPrivilégios
            // 
            this.tabPrivilégios.Controls.Add(this.permissões);
            this.tabPrivilégios.ImageKey = "Privilégios";
            this.tabPrivilégios.Location = new System.Drawing.Point(4, 42);
            this.tabPrivilégios.Name = "tabPrivilégios";
            this.tabPrivilégios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivilégios.Size = new System.Drawing.Size(400, 438);
            this.tabPrivilégios.TabIndex = 3;
            this.tabPrivilégios.Text = "Privilégios";
            this.tabPrivilégios.UseVisualStyleBackColor = true;
            // 
            // permissões
            // 
            this.permissões.AutoScroll = true;
            this.permissões.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissões.Location = new System.Drawing.Point(3, 3);
            this.permissões.Name = "permissões";
            this.permissões.Size = new System.Drawing.Size(394, 432);
            this.permissões.TabIndex = 0;
            // 
            // tabHorárioTrabalho
            // 
            this.tabHorárioTrabalho.Controls.Add(this.horárioTrabalho);
            this.tabHorárioTrabalho.ImageKey = "Relógio";
            this.tabHorárioTrabalho.Location = new System.Drawing.Point(4, 61);
            this.tabHorárioTrabalho.Name = "tabHorárioTrabalho";
            this.tabHorárioTrabalho.Padding = new System.Windows.Forms.Padding(3);
            this.tabHorárioTrabalho.Size = new System.Drawing.Size(400, 375);
            this.tabHorárioTrabalho.TabIndex = 4;
            this.tabHorárioTrabalho.Text = "Horário";
            this.tabHorárioTrabalho.UseVisualStyleBackColor = true;
            // 
            // horárioTrabalho
            // 
            this.horárioTrabalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horárioTrabalho.Location = new System.Drawing.Point(3, 3);
            this.horárioTrabalho.MinimumSize = new System.Drawing.Size(392, 408);
            this.horárioTrabalho.Name = "horárioTrabalho";
            this.horárioTrabalho.Size = new System.Drawing.Size(394, 408);
            this.horárioTrabalho.TabIndex = 0;
            // 
            // CadastroFuncionário
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(426, 530);
            this.Controls.Add(this.btnImprimir);
            this.Name = "CadastroFuncionário";
            this.Text = "Cadastro [Funcionário]";
            this.Load += new System.EventHandler(this.CadastroFuncionário_Load);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.tab.ResumeLayout(false);
            this.tabTrabalho.ResumeLayout(false);
            this.tabPrivilégios.ResumeLayout(false);
            this.tabHorárioTrabalho.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Carrega lista de setores a serem exibidos.
		/// </summary>
		/// <param name="setores">Lista de setores.</param>
		private void CarregarSetores()
		{
            Setor[] setores = Setor.ObterSetores();
			List<ulong> empresas = new List<ulong>();

			InitializeComponent();

			foreach (Setor setor in setores)
			{
				funcionário.AdicionarSetor(setor.Nome, setor.Código);

				if (setor.Empresa >= 0 && !empresas.Contains(setor.Empresa))
				{
					funcionário.AdicionarEmpresa(Entidades.Pessoa.PessoaJurídica.ObterPessoa(setor.Empresa));
					empresas.Add(setor.Empresa);
				}
			}
		}

		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{
            documentLayout.Objects = new ArrayList(
                new object[] { this.Funcionário, new Relatórios.ImpressãoHorário(Funcionário.TabelaHorário) });

			printPreviewDialog.ShowDialog(this);
		}

        [Browsable(false)]
		public Entidades.Pessoa.Funcionário Funcionário
		{
			get
			{
				return (Entidades.Pessoa.Funcionário)base.Pessoa;
			}
			set
			{
				base.Pessoa = value;
				funcionário.Pessoa = value;
                permissões.Entidade = value;
                horárioTrabalho.MostrarEntidade(value);
			}
		}

        public override Entidades.Pessoa.Pessoa Pessoa
        {
            get
            {
                return base.Pessoa;
            }
            set
            {
                Funcionário = (Entidades.Pessoa.Funcionário)value;
            }
        }

        private void CadastroFuncionário_Load(object sender, EventArgs e)
        {
            bool ligar = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroEditar);

            funcionário.Enabled = ligar;
        }

        protected override bool Validar()
        {
            if (Funcionário.Empresa == 0)
            {
                tab.SelectTab(tabTrabalho);
                funcionário.FocarEmpresa();

                MessageBox.Show(
                    this,
                    "A empresa do funcionário não foi definida.",
                    "Cadastro de funcionário",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (Funcionário.Setor == null)
            {
                tab.SelectTab(tabTrabalho);
                funcionário.FocarSetor();

                MessageBox.Show(
                    this,
                    "O setor do funcionário não foi definido.",
                    "Cadastro de funcionário",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!Pessoa.Cadastrado)
            {
                if (String.IsNullOrEmpty(permissões.Usuário))
                {
                    tab.SelectTab(tabPrivilégios);
                    permissões.FocarTxtUsuário();

                    MessageBox.Show(
                        this,
                        "Defina um nome do usuário para acesso ao sistema",
                        "Cadastro de funcionário",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    return false;
            }

                if (!Entidades.Pessoa.Funcionário.ValidarUsuário(permissões.Usuário))
                {
                    tabPrivilégios.Focus();
                    permissões.FocarTxtUsuário();

                    MessageBox.Show(
                        this,
                        "O nome de usuário está inválido ou já encontra-se cadastrado pra outra pessoa.",
                        "Cadastro de funcionário",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }
            return base.Validar();
        }
	}
}

