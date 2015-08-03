using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Neg�cio;
using Neg�cio.Controle;
using Apresenta��o.Formul�rios;
using Administra��o.Formul�rios;
using Ind�stria_Mineira_de_J�ias.Controles.Cadastro;
using Ind�stria_Mineira_de_J�ias.Controles.Contexto;

using InterfaceUsu�rio;

namespace Administra��o.Bases
{
	public class Funcion�rios : Apresenta��o.Formul�rios.BaseInferior
	{
		private Ind�stria_Mineira_de_J�ias.Controles.Consultas.ListViewFuncion�rios lstFuncion�rios;
		private System.Windows.Forms.ContextMenu menuFuncion�rios;
		private System.Windows.Forms.MenuItem menuAbrirFuncion�rio;
		private Apresenta��o.Formul�rios.Quadro quadroOp��es;
		private Apresenta��o.Formul�rios.Op��o optCadastrarFuncion�rio;
		private System.Windows.Forms.MenuItem menuDiv;
		private System.Windows.Forms.MenuItem menuAlterarEstadoFuncion�rio;
		private Apresenta��o.Formul�rios.Quadro quadroFuncion�rio;
		private Apresenta��o.Formul�rios.Op��o optAbrirFicha;
		private Apresenta��o.Formul�rios.Op��o op��oAlterarEstado;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuTelefonemas;
		private Apresenta��o.Formul�rios.Op��o op��oTelefonemas;
		private System.Windows.Forms.MenuItem menuAtendimentos;
		private Apresenta��o.Formul�rios.Op��o op��oListarAtendimentos;
		private System.ComponentModel.IContainer components = null;

		public Funcion�rios()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			lstFuncion�rios.Funcion�rios = ((IControle) Principal.Controle).ObterFuncion�rios();
			lstFuncion�rios.PermitirObserva��o((IControle) Principal.Controle);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Funcion�rios));
			this.lstFuncion�rios = new Ind�stria_Mineira_de_J�ias.Controles.Consultas.ListViewFuncion�rios();
			this.menuFuncion�rios = new System.Windows.Forms.ContextMenu();
			this.menuAbrirFuncion�rio = new System.Windows.Forms.MenuItem();
			this.menuDiv = new System.Windows.Forms.MenuItem();
			this.menuAlterarEstadoFuncion�rio = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuTelefonemas = new System.Windows.Forms.MenuItem();
			this.menuAtendimentos = new System.Windows.Forms.MenuItem();
			this.quadroOp��es = new Apresenta��o.Formul�rios.Quadro();
			this.optCadastrarFuncion�rio = new Apresenta��o.Formul�rios.Op��o();
			this.quadroFuncion�rio = new Apresenta��o.Formul�rios.Quadro();
			this.op��oListarAtendimentos = new Apresenta��o.Formul�rios.Op��o();
			this.op��oTelefonemas = new Apresenta��o.Formul�rios.Op��o();
			this.op��oAlterarEstado = new Apresenta��o.Formul�rios.Op��o();
			this.optAbrirFicha = new Apresenta��o.Formul�rios.Op��o();
			this.esquerda.SuspendLayout();
			this.quadroOp��es.SuspendLayout();
			this.quadroFuncion�rio.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Controls.Add(this.quadroFuncion�rio);
			this.esquerda.Controls.Add(this.quadroOp��es);
			this.esquerda.Name = "esquerda";
			// 
			// lstFuncion�rios
			// 
			this.lstFuncion�rios.AdicionarNovosFuncion�rios = true;
			this.lstFuncion�rios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstFuncion�rios.ContextMenu = this.menuFuncion�rios;
			this.lstFuncion�rios.�nfaseSetor = null;
			this.lstFuncion�rios.Funcion�rios = null;
			this.lstFuncion�rios.ImeMode = System.Windows.Forms.ImeMode.On;
			this.lstFuncion�rios.Location = new System.Drawing.Point(192, 8);
			this.lstFuncion�rios.Name = "lstFuncion�rios";
			this.lstFuncion�rios.Size = new System.Drawing.Size(448, 344);
			this.lstFuncion�rios.TabIndex = 6;
			this.lstFuncion�rios.DoubleClick += new System.EventHandler(this.optAbrirFicha_Click);
			this.lstFuncion�rios.SelectedIndexChanged += new System.EventHandler(this.lstFuncion�rios_SelectedIndexChanged);
			// 
			// menuFuncion�rios
			// 
			this.menuFuncion�rios.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuAbrirFuncion�rio,
																							 this.menuDiv,
																							 this.menuAlterarEstadoFuncion�rio,
																							 this.menuItem1,
																							 this.menuTelefonemas,
																							 this.menuAtendimentos});
			// 
			// menuAbrirFuncion�rio
			// 
			this.menuAbrirFuncion�rio.DefaultItem = true;
			this.menuAbrirFuncion�rio.Enabled = false;
			this.menuAbrirFuncion�rio.Index = 0;
			this.menuAbrirFuncion�rio.Text = "Abrir ficha...";
			this.menuAbrirFuncion�rio.Click += new System.EventHandler(this.optAbrirFicha_Click);
			// 
			// menuDiv
			// 
			this.menuDiv.Index = 1;
			this.menuDiv.Text = "-";
			// 
			// menuAlterarEstadoFuncion�rio
			// 
			this.menuAlterarEstadoFuncion�rio.Enabled = false;
			this.menuAlterarEstadoFuncion�rio.Index = 2;
			this.menuAlterarEstadoFuncion�rio.Text = "Alterar estado...";
			this.menuAlterarEstadoFuncion�rio.Click += new System.EventHandler(this.op��oAlterarEstado_Click);
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
			this.menuTelefonemas.Click += new System.EventHandler(this.op��oTelefonemas_Click);
			// 
			// menuAtendimentos
			// 
			this.menuAtendimentos.Enabled = false;
			this.menuAtendimentos.Index = 5;
			this.menuAtendimentos.Text = "Listar atendimentos...";
			this.menuAtendimentos.Click += new System.EventHandler(this.op��oListarAtendimentos_Click);
			// 
			// quadroOp��es
			// 
			this.quadroOp��es.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroOp��es.bInfDirArredondada = true;
			this.quadroOp��es.bInfEsqArredondada = true;
			this.quadroOp��es.bSupDirArredondada = true;
			this.quadroOp��es.bSupEsqArredondada = true;
			this.quadroOp��es.Controls.Add(this.optCadastrarFuncion�rio);
			this.quadroOp��es.Cor = System.Drawing.Color.Black;
			this.quadroOp��es.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroOp��es.LetraT�tulo = System.Drawing.Color.White;
			this.quadroOp��es.Location = new System.Drawing.Point(8, 16);
			this.quadroOp��es.Name = "quadroOp��es";
			this.quadroOp��es.Size = new System.Drawing.Size(160, 56);
			this.quadroOp��es.TabIndex = 0;
			this.quadroOp��es.Tamanho = 30;
			this.quadroOp��es.T�tulo = "Op��es Gerais";
			// 
			// optCadastrarFuncion�rio
			// 
			this.optCadastrarFuncion�rio.BackColor = System.Drawing.Color.Transparent;
			this.optCadastrarFuncion�rio.Descri��o = "Cadastrar funcion�rio";
			this.optCadastrarFuncion�rio.Imagem = ((System.Drawing.Image)(resources.GetObject("optCadastrarFuncion�rio.Imagem")));
			this.optCadastrarFuncion�rio.Location = new System.Drawing.Point(8, 32);
			this.optCadastrarFuncion�rio.Name = "optCadastrarFuncion�rio";
			this.optCadastrarFuncion�rio.Size = new System.Drawing.Size(136, 24);
			this.optCadastrarFuncion�rio.TabIndex = 1;
			this.optCadastrarFuncion�rio.Click += new System.EventHandler(this.optCadastrarFuncion�rio_Click);
			// 
			// quadroFuncion�rio
			// 
			this.quadroFuncion�rio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroFuncion�rio.bInfDirArredondada = true;
			this.quadroFuncion�rio.bInfEsqArredondada = true;
			this.quadroFuncion�rio.bSupDirArredondada = true;
			this.quadroFuncion�rio.bSupEsqArredondada = true;
			this.quadroFuncion�rio.Controls.Add(this.op��oListarAtendimentos);
			this.quadroFuncion�rio.Controls.Add(this.op��oTelefonemas);
			this.quadroFuncion�rio.Controls.Add(this.op��oAlterarEstado);
			this.quadroFuncion�rio.Controls.Add(this.optAbrirFicha);
			this.quadroFuncion�rio.Cor = System.Drawing.Color.Black;
			this.quadroFuncion�rio.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroFuncion�rio.LetraT�tulo = System.Drawing.Color.White;
			this.quadroFuncion�rio.Location = new System.Drawing.Point(8, 88);
			this.quadroFuncion�rio.Name = "quadroFuncion�rio";
			this.quadroFuncion�rio.Size = new System.Drawing.Size(160, 128);
			this.quadroFuncion�rio.TabIndex = 1;
			this.quadroFuncion�rio.Tamanho = 30;
			this.quadroFuncion�rio.T�tulo = "Funcion�rio";
			this.quadroFuncion�rio.Visible = false;
			// 
			// op��oListarAtendimentos
			// 
			this.op��oListarAtendimentos.BackColor = System.Drawing.Color.Transparent;
			this.op��oListarAtendimentos.Descri��o = "Listar atendimentos";
			this.op��oListarAtendimentos.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oListarAtendimentos.Imagem")));
			this.op��oListarAtendimentos.Location = new System.Drawing.Point(8, 104);
			this.op��oListarAtendimentos.Name = "op��oListarAtendimentos";
			this.op��oListarAtendimentos.Size = new System.Drawing.Size(144, 24);
			this.op��oListarAtendimentos.TabIndex = 4;
			this.op��oListarAtendimentos.Click += new System.EventHandler(this.op��oListarAtendimentos_Click);
			// 
			// op��oTelefonemas
			// 
			this.op��oTelefonemas.BackColor = System.Drawing.Color.Transparent;
			this.op��oTelefonemas.Descri��o = "Listar telefonemas";
			this.op��oTelefonemas.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oTelefonemas.Imagem")));
			this.op��oTelefonemas.Location = new System.Drawing.Point(8, 80);
			this.op��oTelefonemas.Name = "op��oTelefonemas";
			this.op��oTelefonemas.Size = new System.Drawing.Size(144, 24);
			this.op��oTelefonemas.TabIndex = 3;
			this.op��oTelefonemas.Click += new System.EventHandler(this.op��oTelefonemas_Click);
			// 
			// op��oAlterarEstado
			// 
			this.op��oAlterarEstado.BackColor = System.Drawing.Color.Transparent;
			this.op��oAlterarEstado.Descri��o = "Alterar estado";
			this.op��oAlterarEstado.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oAlterarEstado.Imagem")));
			this.op��oAlterarEstado.Location = new System.Drawing.Point(8, 56);
			this.op��oAlterarEstado.Name = "op��oAlterarEstado";
			this.op��oAlterarEstado.Size = new System.Drawing.Size(144, 24);
			this.op��oAlterarEstado.TabIndex = 2;
			this.op��oAlterarEstado.Click += new System.EventHandler(this.op��oAlterarEstado_Click);
			// 
			// optAbrirFicha
			// 
			this.optAbrirFicha.BackColor = System.Drawing.Color.Transparent;
			this.optAbrirFicha.Descri��o = "Abrir ficha";
			this.optAbrirFicha.Imagem = ((System.Drawing.Image)(resources.GetObject("optAbrirFicha.Imagem")));
			this.optAbrirFicha.Location = new System.Drawing.Point(8, 32);
			this.optAbrirFicha.Name = "optAbrirFicha";
			this.optAbrirFicha.Size = new System.Drawing.Size(144, 24);
			this.optAbrirFicha.TabIndex = 1;
			this.optAbrirFicha.Click += new System.EventHandler(this.optAbrirFicha_Click);
			// 
			// Funcion�rios
			// 
			this.Controls.Add(this.lstFuncion�rios);
			this.Name = "Funcion�rios";
			this.Size = new System.Drawing.Size(656, 368);
			this.Controls.SetChildIndex(this.lstFuncion�rios, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.esquerda.ResumeLayout(false);
			this.quadroOp��es.ResumeLayout(false);
			this.quadroFuncion�rio.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void lstFuncion�rios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool ok = lstFuncion�rios.Funcion�rioSelecionado != null;

			// Ligar/Desligar menus
			menuAbrirFuncion�rio.Enabled = ok;
			menuAlterarEstadoFuncion�rio.Enabled = ok;
			menuTelefonemas.Enabled = ok;
			menuAtendimentos.Enabled = ok;

			// Mostrar/Ocultar caixa de op��es
			quadroFuncion�rio.Visible = ok;
		}

		/// <summary>
		/// Cadastrar funcion�rio
		/// </summary>
		private void optCadastrarFuncion�rio_Click(object sender, System.EventArgs e)
		{
			CadastroFuncion�rio cadFunc;

			// Preparar formul�rio
			cadFunc = new CadastroFuncion�rio(Principal.Controle.ObterSetores());
			
			if (cadFunc.ShowDialog() == DialogResult.OK)
			{
				Entidades.Pessoa.Funcion�rio fEntidade;

				fEntidade = cadFunc.Funcion�rio;

				// Tentar cadastro
				try
				{
					Principal.Controle.CadastrarFuncion�rio(fEntidade);
				}
				catch (Exception erro)
				{
					MessageBox.Show(this.ParentForm, "N�o foi poss�vel efetuar cadastro. Ocorreu o seguinte erro: " + erro.ToString(),
						"Cadastrar funcion�rio",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			cadFunc.Dispose();
		}

		/// <summary>
		/// Abre a ficha para consulta/altera��o de um determinado funcion�rio
		/// </summary>
		private void optAbrirFicha_Click(object sender, System.EventArgs e)
		{
			IFuncion�rio		funcion�rio;
			CadastroFuncion�rio	dlg;

			// Obter funcion�rio
			funcion�rio = lstFuncion�rios.Funcion�rioSelecionado;

			// Verificar se h� funcino�rio selecionado
			if (funcion�rio == null)
				return;

			// Construir di�logo
			dlg = new CadastroFuncion�rio(Principal.Controle.ObterSetores());
			dlg.Funcion�rio = funcion�rio.Dados;
			
			// Mostrar caixa
			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				try
				{
					Principal.Controle.AtualizarFuncion�rio(dlg.Funcion�rio);
				}
				catch (Exception erro)
				{
					MessageBox.Show(this.ParentForm, "N�o foi poss�vel atualizar funcion�rio. O seguinte erro ocorreu: " + erro.ToString(),
						"Atualizar cadastro de funcion�rio",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Alterar estado de um funcion�rio
		/// </summary>
		private void op��oAlterarEstado_Click(object sender, System.EventArgs e)
		{
			Funcion�rioPropriedades dlg;

			dlg = new Funcion�rioPropriedades(lstFuncion�rios.Funcion�rioSelecionado);

			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
				lstFuncion�rios.Funcion�rioSelecionado.Estado = dlg.Estado;

			dlg.Dispose();
		}

		/// <summary>
		/// Lista telefonemas realizados pelo funcion�rio
		/// </summary>
		private void op��oTelefonemas_Click(object sender, System.EventArgs e)
		{
			Sele��oPer�odo dlg;
			DateTime m�sAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			DateTime m�sAnterior = DateTime.Now.Subtract(new TimeSpan(31, 0, 0, 0));

			dlg = new Sele��oPer�odo(
                "Lista de telefonemas",
				"Selecione o per�odo para mostrar os telefonemas de " +
				lstFuncion�rios.Funcion�rioSelecionado.Dados.Nome + 
				".",
				new DateTime(m�sAnterior.Year, m�sAnterior.Month, 1),
				m�sAtual.Subtract(new TimeSpan(0, 0, 1)));

			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				Funcion�rioTelefonemas resultado;

				resultado = new Funcion�rioTelefonemas(lstFuncion�rios.Funcion�rioSelecionado.Dados,
					dlg.Per�odoInicial, dlg.Per�odoFinal);

//				resultado.Owner = this.ParentForm;
				resultado.Show();
			}

			dlg.Dispose();
		}

		/// <summary>
		/// Lista atendimentos realizados por funcion�rios
		/// </summary>
		private void op��oListarAtendimentos_Click(object sender, System.EventArgs e)
		{
			Sele��oPer�odo dlg;
			DateTime m�sAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			DateTime m�sAnterior = DateTime.Now.Subtract(new TimeSpan(31, 0, 0, 0));

			dlg = new Sele��oPer�odo(
				"Lista de atendimentos",
				"Selecione o per�odo para mostrar os atendimentos realizados pelo(a) funcion�rio(a) " +
				lstFuncion�rios.Funcion�rioSelecionado.Dados.Nome + 
				".",
				new DateTime(m�sAnterior.Year, m�sAnterior.Month, 1),
				m�sAtual.Subtract(new TimeSpan(0, 0, 1)));

			if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				Funcion�rioAtendimentos resultado;

				resultado = new Funcion�rioAtendimentos(
					Principal.Controle,
					lstFuncion�rios.Funcion�rioSelecionado.Dados,
					dlg.Per�odoInicial,
					dlg.Per�odoFinal);

				resultado.Show();
			}

			dlg.Dispose();		
		}
	}
}

