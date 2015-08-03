using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using System.Collections.Generic;
using Entidades.Configura��o;

namespace Apresenta��o.Pessoa.Cadastro
{
	public class CadastroFuncion�rio : Apresenta��o.Pessoa.Cadastro.CadastroPessoa
	{
		private System.Windows.Forms.TabPage tabTrabalho;
		private Apresenta��o.Pessoa.Cadastro.DadosFuncion�rio funcion�rio;
		private System.Windows.Forms.Button btnImprimir;
		private Report.Layout.DocumentLayout documentLayout;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.PrintDialog printDialog;
        private TabPage tabPrivil�gios;
        private Permiss�es permiss�es;
        private TabPage tabHor�rioTrabalho;
        private Hor�rioTrabalho hor�rioTrabalho;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i o cadastro de funcion�rio, considerando
		/// uma lista de funcion�rios.
		/// </summary>
		/// <remarks>
		/// O funcion�rio N�O � cadastrado/atualizado no
		/// banco de dados.
		/// </remarks>
		public CadastroFuncion�rio()
		{
            Entidades.Pessoa.Funcion�rio funcion�rio;

			CarregarSetores();

            funcion�rio = new Entidades.Pessoa.Funcion�rio();

            // Construir hor�rio padr�o.
            foreach (DayOfWeek dia in new DayOfWeek[] {
                DayOfWeek.Monday, DayOfWeek.Tuesday,
                DayOfWeek.Wednesday, DayOfWeek.Thursday,
                DayOfWeek.Friday })
            {
                funcion�rio.TabelaHor�rio.Adicionar(
                    new Entidades.Pessoa.Hor�rio(
                    funcion�rio,
                    dia,
                    08, 00,
                    11, 59));

                funcion�rio.TabelaHor�rio.Adicionar(
                    new Entidades.Pessoa.Hor�rio(
                    funcion�rio,
                    dia,
                    13, 00,
                    17, 59));
            }

            funcion�rio.DataAdmiss�o = DadosGlobais.Inst�ncia.HoraDataAtual.Date;

            this.Funcion�rio = funcion�rio;
		}

		/// <remarks>
		/// A pessoa f�sica N�O � cadastrada/atualizada no
		/// banco de dados.
		/// </remarks>
		/// <remarks>
		/// O funcion�rio N�O � cadastrada/atualizada no
		/// banco de dados.
		/// </remarks>
		public CadastroFuncion�rio(Entidades.Pessoa.Funcion�rio funcion�rio)
		{
            CarregarSetores();

			this.Funcion�rio = funcion�rio;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroFuncion�rio));
            this.tabTrabalho = new System.Windows.Forms.TabPage();
            this.funcion�rio = new Apresenta��o.Pessoa.Cadastro.DadosFuncion�rio();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.documentLayout = new Report.Layout.DocumentLayout(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.tabPrivil�gios = new System.Windows.Forms.TabPage();
            this.permiss�es = new Apresenta��o.Pessoa.Cadastro.Permiss�es();
            this.tabHor�rioTrabalho = new System.Windows.Forms.TabPage();
            this.hor�rioTrabalho = new Apresenta��o.Pessoa.Cadastro.Hor�rioTrabalho();
            this.tab.SuspendLayout();
            this.tabTrabalho.SuspendLayout();
            this.tabPrivil�gios.SuspendLayout();
            this.tabHor�rioTrabalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabTrabalho);
            this.tab.Controls.Add(this.tabPrivil�gios);
            this.tab.Size = new System.Drawing.Size(408, 484);
            this.tab.Controls.SetChildIndex(this.tabPrivil�gios, 0);
            this.tab.Controls.SetChildIndex(this.tabTrabalho, 0);
            // 
            // �cones
            // 
            this.�cones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("�cones.ImageStream")));
            this.�cones.Images.SetKeyName(0, "Dados pessoais");
            this.�cones.Images.SetKeyName(1, "Endere�o");
            this.�cones.Images.SetKeyName(2, "Observa��es");
            this.�cones.Images.SetKeyName(3, "Grupos");
            this.�cones.Images.SetKeyName(4, "Telefone");
            this.�cones.Images.SetKeyName(5, "Calend�rio");
            this.�cones.Images.SetKeyName(6, "Trabalho");
            this.�cones.Images.SetKeyName(7, "Rel�gio");
            this.�cones.Images.SetKeyName(8, "Privil�gios");
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
            this.tabTrabalho.Controls.Add(this.funcion�rio);
            this.tabTrabalho.ImageKey = "Trabalho";
            this.tabTrabalho.Location = new System.Drawing.Point(4, 42);
            this.tabTrabalho.Name = "tabTrabalho";
            this.tabTrabalho.Size = new System.Drawing.Size(400, 435);
            this.tabTrabalho.TabIndex = 2;
            this.tabTrabalho.Text = "Trabalho";
            this.tabTrabalho.UseVisualStyleBackColor = true;
            // 
            // funcion�rio
            // 
            this.funcion�rio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcion�rio.Location = new System.Drawing.Point(8, 8);
            this.funcion�rio.Name = "funcion�rio";
            this.funcion�rio.Size = new System.Drawing.Size(384, 422);
            this.funcion�rio.TabIndex = 0;
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
            this.documentLayout.XmlFileName = "Relat�rioFichaFuncion�rio.xml";
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "Ficha de Funcion�rio";
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
            // tabPrivil�gios
            // 
            this.tabPrivil�gios.Controls.Add(this.permiss�es);
            this.tabPrivil�gios.ImageKey = "Privil�gios";
            this.tabPrivil�gios.Location = new System.Drawing.Point(4, 42);
            this.tabPrivil�gios.Name = "tabPrivil�gios";
            this.tabPrivil�gios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivil�gios.Size = new System.Drawing.Size(400, 438);
            this.tabPrivil�gios.TabIndex = 3;
            this.tabPrivil�gios.Text = "Privil�gios";
            this.tabPrivil�gios.UseVisualStyleBackColor = true;
            // 
            // permiss�es
            // 
            this.permiss�es.AutoScroll = true;
            this.permiss�es.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permiss�es.Location = new System.Drawing.Point(3, 3);
            this.permiss�es.Name = "permiss�es";
            this.permiss�es.Size = new System.Drawing.Size(394, 432);
            this.permiss�es.TabIndex = 0;
            // 
            // tabHor�rioTrabalho
            // 
            this.tabHor�rioTrabalho.Controls.Add(this.hor�rioTrabalho);
            this.tabHor�rioTrabalho.ImageKey = "Rel�gio";
            this.tabHor�rioTrabalho.Location = new System.Drawing.Point(4, 61);
            this.tabHor�rioTrabalho.Name = "tabHor�rioTrabalho";
            this.tabHor�rioTrabalho.Padding = new System.Windows.Forms.Padding(3);
            this.tabHor�rioTrabalho.Size = new System.Drawing.Size(400, 375);
            this.tabHor�rioTrabalho.TabIndex = 4;
            this.tabHor�rioTrabalho.Text = "Hor�rio";
            this.tabHor�rioTrabalho.UseVisualStyleBackColor = true;
            // 
            // hor�rioTrabalho
            // 
            this.hor�rioTrabalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hor�rioTrabalho.Location = new System.Drawing.Point(3, 3);
            this.hor�rioTrabalho.MinimumSize = new System.Drawing.Size(392, 408);
            this.hor�rioTrabalho.Name = "hor�rioTrabalho";
            this.hor�rioTrabalho.Size = new System.Drawing.Size(394, 408);
            this.hor�rioTrabalho.TabIndex = 0;
            // 
            // CadastroFuncion�rio
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(426, 530);
            this.Controls.Add(this.btnImprimir);
            this.Name = "CadastroFuncion�rio";
            this.Text = "Cadastro [Funcion�rio]";
            this.Load += new System.EventHandler(this.CadastroFuncion�rio_Load);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.tab.ResumeLayout(false);
            this.tabTrabalho.ResumeLayout(false);
            this.tabPrivil�gios.ResumeLayout(false);
            this.tabHor�rioTrabalho.ResumeLayout(false);
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
				funcion�rio.AdicionarSetor(setor.Nome, setor.C�digo);

				if (setor.Empresa >= 0 && !empresas.Contains(setor.Empresa))
				{
					funcion�rio.AdicionarEmpresa(Entidades.Pessoa.PessoaJur�dica.ObterPessoa(setor.Empresa));
					empresas.Add(setor.Empresa);
				}
			}
		}

		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{
            documentLayout.Objects = new ArrayList(
                new object[] { this.Funcion�rio, new Relat�rios.Impress�oHor�rio(Funcion�rio.TabelaHor�rio) });

			printPreviewDialog.ShowDialog(this);
		}

        [Browsable(false)]
		public Entidades.Pessoa.Funcion�rio Funcion�rio
		{
			get
			{
				return (Entidades.Pessoa.Funcion�rio)base.Pessoa;
			}
			set
			{
				base.Pessoa = value;
				funcion�rio.Pessoa = value;
                permiss�es.Entidade = value;
                hor�rioTrabalho.MostrarEntidade(value);
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
                Funcion�rio = (Entidades.Pessoa.Funcion�rio)value;
            }
        }

        private void CadastroFuncion�rio_Load(object sender, EventArgs e)
        {
            bool ligar = Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.CadastroEditar);

            funcion�rio.Enabled = ligar;
        }

        protected override bool Validar()
        {
            if (Funcion�rio.Empresa == 0)
            {
                tab.SelectTab(tabTrabalho);
                funcion�rio.FocarEmpresa();

                MessageBox.Show(
                    this,
                    "A empresa do funcion�rio n�o foi definida.",
                    "Cadastro de funcion�rio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (Funcion�rio.Setor == null)
            {
                tab.SelectTab(tabTrabalho);
                funcion�rio.FocarSetor();

                MessageBox.Show(
                    this,
                    "O setor do funcion�rio n�o foi definido.",
                    "Cadastro de funcion�rio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!Pessoa.Cadastrado)
            {
                if (String.IsNullOrEmpty(permiss�es.Usu�rio))
                {
                    tab.SelectTab(tabPrivil�gios);
                    permiss�es.FocarTxtUsu�rio();

                    MessageBox.Show(
                        this,
                        "Defina um nome do usu�rio para acesso ao sistema",
                        "Cadastro de funcion�rio",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    return false;
            }

                if (!Entidades.Pessoa.Funcion�rio.ValidarUsu�rio(permiss�es.Usu�rio))
                {
                    tabPrivil�gios.Focus();
                    permiss�es.FocarTxtUsu�rio();

                    MessageBox.Show(
                        this,
                        "O nome de usu�rio est� inv�lido ou j� encontra-se cadastrado pra outra pessoa.",
                        "Cadastro de funcion�rio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }
            return base.Validar();
        }
	}
}

