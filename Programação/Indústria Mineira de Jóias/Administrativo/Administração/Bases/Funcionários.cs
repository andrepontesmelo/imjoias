using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negócio;
using Negócio.Controle;
using Apresentação.Formulários;
using Administração.Formulários;
using Indústria_Mineira_de_Jóias.Controles.Cadastro;
using Indústria_Mineira_de_Jóias.Controles.Contexto;

using InterfaceUsuário;

namespace Administração.Bases
{
	public class Funcionários : Apresentação.Formulários.BaseInferior
	{
		private Indústria_Mineira_de_Jóias.Controles.Consultas.ListViewFuncionários lstFuncionários;
		private System.Windows.Forms.ContextMenu menuFuncionários;
		private System.Windows.Forms.MenuItem menuAbrirFuncionário;
		private Apresentação.Formulários.Quadro quadroOpções;
		private Apresentação.Formulários.Opção optCadastrarFuncionário;
		private System.Windows.Forms.MenuItem menuDiv;
		private System.Windows.Forms.MenuItem menuAlterarEstadoFuncionário;
		private Apresentação.Formulários.Quadro quadroFuncionário;
		private Apresentação.Formulários.Opção optAbrirFicha;
		private Apresentação.Formulários.Opção opçãoAlterarEstado;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuTelefonemas;
		private Apresentação.Formulários.Opção opçãoTelefonemas;
		private System.Windows.Forms.MenuItem menuAtendimentos;
		private Apresentação.Formulários.Opção opçãoListarAtendimentos;
		private System.ComponentModel.IContainer components = null;

		public Funcionários()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			lstFuncionários.Funcionários = ((IControle) Principal.Controle).ObterFuncionários();
			lstFuncionários.PermitirObservação((IControle) Principal.Controle);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Funcionários));
			this.lstFuncionários = new Indústria_Mineira_de_Jóias.Controles.Consultas.ListViewFuncionários();
			this.menuFuncionários = new System.Windows.Forms.ContextMenu();
			this.menuAbrirFuncionário = new System.Windows.Forms.MenuItem();
			this.menuDiv = new System.Windows.Forms.MenuItem();
			this.menuAlterarEstadoFuncionário = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuTelefonemas = new System.Windows.Forms.MenuItem();
			this.menuAtendimentos = new System.Windows.Forms.MenuItem();
			this.quadroOpções = new Apresentação.Formulários.Quadro();
			this.optCadastrarFuncionário = new Apresentação.Formulários.Opção();
			this.quadroFuncionário = new Apresentação.Formulários.Quadro();
			this.opçãoListarAtendimentos = new Apresentação.Formulários.Opção();
			this.opçãoTelefonemas = new Apresentação.Formulários.Opção();
			this.opçãoAlterarEstado = new Apresentação.Formulários.Opção();
			this.optAbrirFicha = new Apresentação.Formulários.Opção();
			this.esquerda.SuspendLayout();
			this.quadroOpções.SuspendLayout();
			this.quadroFuncionário.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Controls.Add(this.quadroFuncionário);
			this.esquerda.Controls.Add(this.quadroOpções);
			this.esquerda.Name = "esquerda";
			// 
			// lstFuncionários
			// 
			this.lstFuncionários.AdicionarNovosFuncionários = true;
			this.lstFuncionários.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstFuncionários.ContextMenu = this.menuFuncionários;
			this.lstFuncionários.ÊnfaseSetor = null;
			this.lstFuncionários.Funcionários = null;
			this.lstFuncionários.ImeMode = System.Windows.Forms.ImeMode.On;
			this.lstFuncionários.Location = new System.Drawing.Point(192, 8);
			this.lstFuncionários.Name = "lstFuncionários";
			this.lstFuncionários.Size = new System.Drawing.Size(448, 344);
			this.lstFuncionários.TabIndex = 6;
			this.lstFuncionários.DoubleClick += new System.EventHandler(this.optAbrirFicha_Click);
			this.lstFuncionários.SelectedIndexChanged += new System.EventHandler(this.lstFuncionários_SelectedIndexChanged);
			// 
			// menuFuncionários
			// 
			this.menuFuncionários.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuAbrirFuncionário,
																							 this.menuDiv,
																							 this.menuAlterarEstadoFuncionário,
																							 this.menuItem1,
																							 this.menuTelefonemas,
																							 this.menuAtendimentos});
			// 
			// menuAbrirFuncionário
			// 
			this.menuAbrirFuncionário.DefaultItem = true;
			this.menuAbrirFuncionário.Enabled = false;
			this.menuAbrirFuncionário.Index = 0;
			this.menuAbrirFuncionário.Text = "Abrir ficha...";
			this.menuAbrirFuncionário.Click += new System.EventHandler(this.optAbrirFicha_Click);
			// 
			// menuDiv
			// 
			this.menuDiv.Index = 1;
			this.menuDiv.Text = "-";
			// 
			// menuAlterarEstadoFuncionário
			// 
			this.menuAlterarEstadoFuncionário.Enabled = false;
			this.menuAlterarEstadoFuncionário.Index = 2;
			this.menuAlterarEstadoFuncionário.Text = "Alterar estado...";
			this.menuAlterarEstadoFuncionário.Click += new System.EventHandler(this.opçãoAlterarEstado_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// menuTelefonemas
			// 
			this.menuTelefonemas.Enabled = false;
			this.menuTelefonemas.Index = 4;
			this.menuTelefonemas.Text = "Listar telefonemas...";
			this.menuTelefonemas.Click += new System.EventHandler(this.opçãoTelefonemas_Click);
			// 
			// menuAtendimentos
			// 
			this.menuAtendimentos.Enabled = false;
			this.menuAtendimentos.Index = 5;
			this.menuAtendimentos.Text = "Listar atendimentos...";
			this.menuAtendimentos.Click += new System.EventHandler(this.opçãoListarAtendimentos_Click);
			// 
			// quadroOpções
			// 
			this.quadroOpções.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroOpções.bInfDirArredondada = true;
			this.quadroOpções.bInfEsqArredondada = true;
			this.quadroOpções.bSupDirArredondada = true;
			this.quadroOpções.bSupEsqArredondada = true;
			this.quadroOpções.Controls.Add(this.optCadastrarFuncionário);
			this.quadroOpções.Cor = System.Drawing.Color.Black;
			this.quadroOpções.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroOpções.LetraTítulo = System.Drawing.Color.White;
			this.quadroOpções.Location = new System.Drawing.Point(8, 16);
			this.quadroOpções.Name = "quadroOpções";
			this.quadroOpções.Size = new System.Drawing.Size(160, 56);
			this.quadroOpções.TabIndex = 0;
			this.quadroOpções.Tamanho = 30;
			this.quadroOpções.Título = "Opções Gerais";
			// 
			// optCadastrarFuncionário
			// 
			this.optCadastrarFuncionário.BackColor = System.Drawing.Color.Transparent;
			this.optCadastrarFuncionário.Descrição = "Cadastrar funcionário";
			this.optCadastrarFuncionário.Imagem = ((System.Drawing.Image)(resources.GetObject("optCadastrarFuncionário.Imagem")));
			this.optCadastrarFuncionário.Location = new System.Drawing.Point(8, 32);
			this.optCadastrarFuncionário.Name = "optCadastrarFuncionário";
			this.optCadastrarFuncionário.Size = new System.Drawing.Size(136, 24);
			this.optCadastrarFuncionário.TabIndex = 1;
			this.optCadastrarFuncionário.Click += new System.EventHandler(this.optCadastrarFuncionário_Click);
			// 
			// quadroFuncionário
			// 
			this.quadroFuncionário.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroFuncionário.bInfDirArredondada = true;
			this.quadroFuncionário.bInfEsqArredondada = true;
			this.quadroFuncionário.bSupDirArredondada = true;
			this.quadroFuncionário.bSupEsqArredondada = true;
			this.quadroFuncionário.Controls.Add(this.opçãoListarAtendimentos);
			this.quadroFuncionário.Controls.Add(this.opçãoTelefonemas);
			this.quadroFuncionário.Controls.Add(this.opçãoAlterarEstado);
			this.quadroFuncionário.Controls.Add(this.optAbrirFicha);
			this.quadroFuncionário.Cor = System.Drawing.Color.Black;
			this.quadroFuncionário.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroFuncionário.LetraTítulo = System.Drawing.Color.White;
			this.quadroFuncionário.Location = new System.Drawing.Point(8, 88);
			this.quadroFuncionário.Name = "quadroFuncionário";
			this.quadroFuncionário.Size = new System.Drawing.Size(160, 128);
			this.quadroFuncionário.TabIndex = 1;
			this.quadroFuncionário.Tamanho = 30;
			this.quadroFuncionário.Título = "Funcionário";
			this.quadroFuncionário.Visible = false;
			// 
			// opçãoListarAtendimentos
			// 
			this.opçãoListarAtendimentos.BackColor = System.Drawing.Color.Transparent;
			this.opçãoListarAtendimentos.Descrição = "Listar atendimentos";
			this.opçãoListarAtendimentos.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoListarAtendimentos.Imagem")));
			this.opçãoListarAtendimentos.Location = new System.Drawing.Point(8, 104);
			this.opçãoListarAtendimentos.Name = "opçãoListarAtendimentos";
			this.opçãoListarAtendimentos.Size = new System.Drawing.Size(144, 24);
			this.opçãoListarAtendimentos.TabIndex = 4;
			this.opçãoListarAtendimentos.Click += new System.EventHandler(this.opçãoListarAtendimentos_Click);
			// 
			// opçãoTelefonemas
			// 
			this.opçãoTelefonemas.BackColor = System.Drawing.Color.Transparent;
			this.opçãoTelefonemas.Descrição = "Listar telefonemas";
			this.opçãoTelefonemas.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoTelefonemas.Imagem")));
			this.opçãoTelefonemas.Location = new System.Drawing.Point(8, 80);
			this.opçãoTelefonemas.Name = "opçãoTelefonemas";
			this.opçãoTelefonemas.Size = new System.Drawing.Size(144, 24);
			this.opçãoTelefonemas.TabIndex = 3;
			this.opçãoTelefonemas.Click += new System.EventHandler(this.opçãoTelefonemas_Click);
			// 
			// opçãoAlterarEstado
			// 
			this.opçãoAlterarEstado.BackColor = System.Drawing.Color.Transparent;
			this.opçãoAlterarEstado.Descrição = "Alterar estado";
			this.opçãoAlterarEstado.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAlterarEstado.Imagem")));
			this.opçãoAlterarEstado.Location = new System.Drawing.Point(8, 56);
			this.opçãoAlterarEstado.Name = "opçãoAlterarEstado";
			this.opçãoAlterarEstado.Size = new System.Drawing.Size(144, 24);
			this.opçãoAlterarEstado.TabIndex = 2;
			this.opçãoAlterarEstado.Click += new System.EventHandler(this.opçãoAlterarEstado_Click);
			// 
			// optAbrirFicha
			// 
			this.optAbrirFicha.BackColor = System.Drawing.Color.Transparent;
			this.optAbrirFicha.Descrição = "Abrir ficha";
			this.optAbrirFicha.Imagem = ((System.Drawing.Image)(resources.GetObject("optAbrirFicha.Imagem")));
			this.optAbrirFicha.Location = new System.Drawing.Point(8, 32);
			this.optAbrirFicha.Name = "optAbrirFicha";
			this.optAbrirFicha.Size = new System.Drawing.Size(144, 24);
			this.optAbrirFicha.TabIndex = 1;
			this.optAbrirFicha.Click += new System.EventHandler(this.optAbrirFicha_Click);
			// 
			// Funcionários
			// 
			this.Controls.Add(this.lstFuncionários);
			this.Name = "Funcionários";
			this.Size = new System.Drawing.Size(656, 368);
			this.Controls.SetChildIndex(this.lstFuncionários, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.esquerda.ResumeLayout(false);
			this.quadroOpções.ResumeLayout(false);
			this.quadroFuncionário.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void lstFuncionários_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool ok = lstFuncionários.FuncionárioSelecionado != null;

			// Ligar/Desligar menus
			menuAbrirFuncionário.Enabled = ok;
			menuAlterarEstadoFuncionário.Enabled = ok;
			menuTelefonemas.Enabled = ok;
			menuAtendimentos.Enabled = ok;

			// Mostrar/Ocultar caixa de opções
			quadroFuncionário.Visible = ok;
		}

		/// <summary>
		/// Cadastrar funcionário
		/// </summary>
		private void optCadastrarFuncionário_Click(object sender, System.EventArgs e)
		{
			CadastroFuncionário cadFunc;

			// Preparar formulário
			cadFunc = new CadastroFuncionário(Principal.Controle.ObterSetores());
			
			if (cadFunc.ShowDialog() == DialogResult.OK)
			{
				Entidades.Pessoa.Funcionário fEntidade;

				fEntidade = cadFunc.Funcionário;

				// Tentar cadastro
				try
				{
					Principal.Controle.CadastrarFuncionário(fEntidade);
				}
				catch (Exception erro)
				{
					MessageBox.Show(this.ParentForm, "Não foi possível efetuar cadastro. Ocorreu o seguinte erro: " + erro.ToString(),
						"Cadastrar funcionário",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			cadFunc.Dispose();
		}

		/// <summary>
		/// Abre a ficha para consulta/alteração de um determinado funcionário
		/// </summary>
		private void optAbrirFicha_Click(object sender, System.EventArgs e)
		{
			IFuncionário		funcionário;
			CadastroFuncionário	dlg;

			// Obter funcionário
			funcionário = lstFuncionários.FuncionárioSelecionado;

			// Verificar se há funcinoário selecionado
			if (funcionário == null)
				return;

			// Construir diálogo
			dlg = new CadastroFuncionário(Principal.Controle.ObterSetores());
			dlg.Funcionário = funcionário.Dados;
			
			// Mostrar caixa
			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				try
				{
					Principal.Controle.AtualizarFuncionário(dlg.Funcionário);
				}
				catch (Exception erro)
				{
					MessageBox.Show(this.ParentForm, "Não foi possível atualizar funcionário. O seguinte erro ocorreu: " + erro.ToString(),
						"Atualizar cadastro de funcionário",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Alterar estado de um funcionário
		/// </summary>
		private void opçãoAlterarEstado_Click(object sender, System.EventArgs e)
		{
			FuncionárioPropriedades dlg;

			dlg = new FuncionárioPropriedades(lstFuncionários.FuncionárioSelecionado);

			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
				lstFuncionários.FuncionárioSelecionado.Estado = dlg.Estado;

			dlg.Dispose();
		}

		/// <summary>
		/// Lista telefonemas realizados pelo funcionário
		/// </summary>
		private void opçãoTelefonemas_Click(object sender, System.EventArgs e)
		{
			SeleçãoPeríodo dlg;
			DateTime mêsAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			DateTime mêsAnterior = DateTime.Now.Subtract(new TimeSpan(31, 0, 0, 0));

			dlg = new SeleçãoPeríodo(
                "Lista de telefonemas",
				"Selecione o período para mostrar os telefonemas de " +
				lstFuncionários.FuncionárioSelecionado.Dados.Nome + 
				".",
				new DateTime(mêsAnterior.Year, mêsAnterior.Month, 1),
				mêsAtual.Subtract(new TimeSpan(0, 0, 1)));

			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				FuncionárioTelefonemas resultado;

				resultado = new FuncionárioTelefonemas(lstFuncionários.FuncionárioSelecionado.Dados,
					dlg.PeríodoInicial, dlg.PeríodoFinal);

//				resultado.Owner = this.ParentForm;
				resultado.Show();
			}

			dlg.Dispose();
		}

		/// <summary>
		/// Lista atendimentos realizados por funcionários
		/// </summary>
		private void opçãoListarAtendimentos_Click(object sender, System.EventArgs e)
		{
			SeleçãoPeríodo dlg;
			DateTime mêsAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			DateTime mêsAnterior = DateTime.Now.Subtract(new TimeSpan(31, 0, 0, 0));

			dlg = new SeleçãoPeríodo(
				"Lista de atendimentos",
				"Selecione o período para mostrar os atendimentos realizados pelo(a) funcionário(a) " +
				lstFuncionários.FuncionárioSelecionado.Dados.Nome + 
				".",
				new DateTime(mêsAnterior.Year, mêsAnterior.Month, 1),
				mêsAtual.Subtract(new TimeSpan(0, 0, 1)));

			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				FuncionárioAtendimentos resultado;

				resultado = new FuncionárioAtendimentos(
					Principal.Controle,
					lstFuncionários.FuncionárioSelecionado.Dados,
					dlg.PeríodoInicial,
					dlg.PeríodoFinal);

				resultado.Show();
			}

			dlg.Dispose();		
		}
	}
}

