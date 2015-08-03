using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Configura��o;

namespace Apresenta��o.Atendimento.Clientes
{
	/// <summary>
	/// Base para sele��o de clientes de setores.
	/// 
	/// Entende-se por carga a reobten��o dos dados no banco de dados,
	/// que � feita somente assim que o AoAbrir() � chamado,
	/// e mesmo assim, apenas de tempos em tempos.
	/// </summary>
	public class BaseSele��oClienteSetor : Apresenta��o.Atendimento.Clientes.BaseSele��oCliente
	{
		// Atributos
		protected DateTime pr�ximaCarga = DateTime.MinValue;
		protected TimeSpan validadeCarga = new TimeSpan(3, 0, 0);
		protected Setor [] setores;
		private Apresenta��o.Formul�rios.Quadro quadroListaClientes;
		private Apresenta��o.Formul�rios.Op��o op��oRecarregar;
        private Apresenta��o.Formul�rios.Op��o op��oReconfigurar;

		// Componentes
		private System.ComponentModel.IContainer components = null;

		public BaseSele��oClienteSetor()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			setores = null;
		}

		#region Dispose

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

		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSele��oClienteSetor));
            this.quadroListaClientes = new Apresenta��o.Formul�rios.Quadro();
            this.op��oRecarregar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oReconfigurar = new Apresenta��o.Formul�rios.Op��o();
            this.esquerda.SuspendLayout();
            this.quadroListaClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroListaClientes);
            this.esquerda.Controls.SetChildIndex(this.quadroListaClientes, 0);
            // 
            // quadroListaClientes
            // 
            this.quadroListaClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroListaClientes.bInfDirArredondada = true;
            this.quadroListaClientes.bInfEsqArredondada = true;
            this.quadroListaClientes.bSupDirArredondada = true;
            this.quadroListaClientes.bSupEsqArredondada = true;
            this.quadroListaClientes.Controls.Add(this.op��oRecarregar);
            this.quadroListaClientes.Controls.Add(this.op��oReconfigurar);
            this.quadroListaClientes.Cor = System.Drawing.Color.Black;
            this.quadroListaClientes.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroListaClientes.LetraT�tulo = System.Drawing.Color.White;
            this.quadroListaClientes.Location = new System.Drawing.Point(7, 172);
            this.quadroListaClientes.MostrarBot�oMinMax = false;
            this.quadroListaClientes.Name = "quadroListaClientes";
            this.quadroListaClientes.Size = new System.Drawing.Size(160, 80);
            this.quadroListaClientes.TabIndex = 2;
            this.quadroListaClientes.Tamanho = 30;
            this.quadroListaClientes.T�tulo = "Lista de Pessoas";
            // 
            // op��oRecarregar
            // 
            this.op��oRecarregar.BackColor = System.Drawing.Color.Transparent;
            this.op��oRecarregar.Descri��o = "Recarregar lista";
            this.op��oRecarregar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oRecarregar.Imagem")));
            this.op��oRecarregar.Location = new System.Drawing.Point(8, 56);
            this.op��oRecarregar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oRecarregar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRecarregar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRecarregar.Name = "op��oRecarregar";
            this.op��oRecarregar.Size = new System.Drawing.Size(150, 24);
            this.op��oRecarregar.TabIndex = 3;
            this.op��oRecarregar.Click += new System.EventHandler(this.op��oRecarregar_Click);
            // 
            // op��oReconfigurar
            // 
            this.op��oReconfigurar.BackColor = System.Drawing.Color.Transparent;
            this.op��oReconfigurar.Descri��o = "Configurar exibi��o...";
            this.op��oReconfigurar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oReconfigurar.Imagem")));
            this.op��oReconfigurar.Location = new System.Drawing.Point(8, 32);
            this.op��oReconfigurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oReconfigurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oReconfigurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oReconfigurar.Name = "op��oReconfigurar";
            this.op��oReconfigurar.Size = new System.Drawing.Size(150, 24);
            this.op��oReconfigurar.TabIndex = 2;
            this.op��oReconfigurar.Click += new System.EventHandler(this.op��oReconfigurar_Click);
            // 
            // BaseSele��oClienteSetor
            // 
            this.Name = "BaseSele��oClienteSetor";
            this.esquerda.ResumeLayout(false);
            this.quadroListaClientes.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Momento em que ocorrer� pr�xima carga de dados.
		/// </summary>
		[Browsable(false)]
		public DateTime Pr�ximaCarga
		{
			get { return pr�ximaCarga; }
			set { pr�ximaCarga = value; }
		}

		/// <summary>
		/// Tempo de validade de uma carga, at� que outra ocorra.
		/// </summary>
		public TimeSpan ValidadeCarga
		{
			get { return validadeCarga; }
			set { validadeCarga = value; }
		}

		/// <summary>
		/// Setores que ser�o exibidos.
		/// </summary>
		public Setor [] Setores
		{
			get { return setores; }
			set { setores = value; }
		}

		#endregion

		/// <summary>
		/// Ocorre ao exibir pela primeira vez.
		/// </summary>
		protected override void AoExibirDaPrimeiraVez()
		{
			CarregarConfigura��es();

			base.AoExibirDaPrimeiraVez ();
		}

		/// <summary>
		/// Ocorre ao exibir a base inferior.
		/// </summary>
		protected override void AoExibir()
		{
			base.AoExibir();

			if (pr�ximaCarga <= DateTime.Now)
				CarregarDados();

            op��oProcurar_Click(this, new EventArgs());

            //timerRecarregarLista.Enabled = true;
		}

		/// <summary>
		/// Carrega os setores e verifica quais o usu�rio
		/// deseja utilizar.
		/// </summary>
		private void CarregarConfigura��es()
		{
			Setor []     atendimento;
			ArrayList    setores;
			Configura��oUsu�rio<bool> registro;
            Configura��oUsu�rio<int> prazo;
            Configura��oUsu�rio<bool> bSetor;
            Setor setorNE = Setor.ObterSetor(Setor.SetorSistema.N�oEspecificado);

			atendimento = Setor.ObterSetoresAtendimento();
			setores     = new ArrayList(atendimento.Length + 1);
            setores.Add(setorNE);

            registro = new Configura��oUsu�rio<bool>("BaseSele��oClienteSetor: configurado", false);

            if (!registro.Valor)
			{
				if (!Configurar(atendimento))
                    this.setores = new Setor[0];
                return;
			}

            prazo = new Configura��oUsu�rio<int>("BaseSele��oClienteSetor: prazo", 90);
            Prazo = prazo.Valor;

            foreach (Setor setor in atendimento)
            {
                bSetor = new Configura��oUsu�rio<bool>("BaseSele��oClienteSetor: setor " + setor.Nome, setor.C�digo == setorNE.C�digo);

                if (bSetor.Valor)
                    setores.Add(setor);
            }

			this.setores = (Setor []) setores.ToArray(typeof(Setor));
		}

		/// <summary>
		/// Exibe janela de configura��o.
		/// </summary>
		private bool Configurar()
		{
			Setor [] setores;

			setores = Setor.ObterSetoresAtendimento();

			return Configurar(setores);
		}

		/// <summary>
		/// Exibe janela de configura��o.
		/// </summary>
		/// <returns>Se foram realizadas modifica��es.</returns>
		private bool Configurar(Setor [] setores)
		{
			using (DlgConfigSele��oClienteSetor dlg =
					   new DlgConfigSele��oClienteSetor(this, "BaseSele��oClienteSetor", setores))
			{
				return dlg.ShowDialog(this.ParentForm) == DialogResult.OK;
			}
		}

		/// <summary>
		/// Carrega dados do banco de dados.
		/// </summary>
		protected virtual void CarregarDados()
		{
			CarregarDeSetores(setores);
			pr�ximaCarga = DateTime.Now.Add(validadeCarga);
		}

		/// <summary>
		/// Ocorre ao clicar no bot�o recarregar.
		/// </summary>
		private void op��oRecarregar_Click(object sender, System.EventArgs e)
		{
			CarregarDados();
		}

		/// <summary>
		/// Ocorre ao clicar em reconfigurar.
		/// </summary>
		private void op��oReconfigurar_Click(object sender, System.EventArgs e)
		{
			if (Configurar())
				CarregarDados();
		}

        //private void timerRecarregarLista_Tick(object sender, EventArgs e)
        //{
        //    CarregarDados();
        //}
	}
}