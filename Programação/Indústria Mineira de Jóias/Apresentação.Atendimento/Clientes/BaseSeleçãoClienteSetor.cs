using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Configuração;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Base para seleção de clientes de setores.
	/// 
	/// Entende-se por carga a reobtenção dos dados no banco de dados,
	/// que é feita somente assim que o AoAbrir() é chamado,
	/// e mesmo assim, apenas de tempos em tempos.
	/// </summary>
	public class BaseSeleçãoClienteSetor : Apresentação.Atendimento.Clientes.BaseSeleçãoCliente
	{
		// Atributos
		protected DateTime próximaCarga = DateTime.MinValue;
		protected TimeSpan validadeCarga = new TimeSpan(3, 0, 0);
		protected Setor [] setores;
		private Apresentação.Formulários.Quadro quadroListaClientes;
		private Apresentação.Formulários.Opção opçãoRecarregar;
        private Apresentação.Formulários.Opção opçãoReconfigurar;

		// Componentes
		private System.ComponentModel.IContainer components = null;

		public BaseSeleçãoClienteSetor()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSeleçãoClienteSetor));
            this.quadroListaClientes = new Apresentação.Formulários.Quadro();
            this.opçãoRecarregar = new Apresentação.Formulários.Opção();
            this.opçãoReconfigurar = new Apresentação.Formulários.Opção();
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
            this.quadroListaClientes.Controls.Add(this.opçãoRecarregar);
            this.quadroListaClientes.Controls.Add(this.opçãoReconfigurar);
            this.quadroListaClientes.Cor = System.Drawing.Color.Black;
            this.quadroListaClientes.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroListaClientes.LetraTítulo = System.Drawing.Color.White;
            this.quadroListaClientes.Location = new System.Drawing.Point(7, 172);
            this.quadroListaClientes.MostrarBotãoMinMax = false;
            this.quadroListaClientes.Name = "quadroListaClientes";
            this.quadroListaClientes.Size = new System.Drawing.Size(160, 80);
            this.quadroListaClientes.TabIndex = 2;
            this.quadroListaClientes.Tamanho = 30;
            this.quadroListaClientes.Título = "Lista de Pessoas";
            // 
            // opçãoRecarregar
            // 
            this.opçãoRecarregar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRecarregar.Descrição = "Recarregar lista";
            this.opçãoRecarregar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRecarregar.Imagem")));
            this.opçãoRecarregar.Location = new System.Drawing.Point(8, 56);
            this.opçãoRecarregar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRecarregar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRecarregar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRecarregar.Name = "opçãoRecarregar";
            this.opçãoRecarregar.Size = new System.Drawing.Size(150, 24);
            this.opçãoRecarregar.TabIndex = 3;
            this.opçãoRecarregar.Click += new System.EventHandler(this.opçãoRecarregar_Click);
            // 
            // opçãoReconfigurar
            // 
            this.opçãoReconfigurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoReconfigurar.Descrição = "Configurar exibição...";
            this.opçãoReconfigurar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoReconfigurar.Imagem")));
            this.opçãoReconfigurar.Location = new System.Drawing.Point(8, 32);
            this.opçãoReconfigurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoReconfigurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoReconfigurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoReconfigurar.Name = "opçãoReconfigurar";
            this.opçãoReconfigurar.Size = new System.Drawing.Size(150, 24);
            this.opçãoReconfigurar.TabIndex = 2;
            this.opçãoReconfigurar.Click += new System.EventHandler(this.opçãoReconfigurar_Click);
            // 
            // BaseSeleçãoClienteSetor
            // 
            this.Name = "BaseSeleçãoClienteSetor";
            this.esquerda.ResumeLayout(false);
            this.quadroListaClientes.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Momento em que ocorrerá próxima carga de dados.
		/// </summary>
		[Browsable(false)]
		public DateTime PróximaCarga
		{
			get { return próximaCarga; }
			set { próximaCarga = value; }
		}

		/// <summary>
		/// Tempo de validade de uma carga, até que outra ocorra.
		/// </summary>
		public TimeSpan ValidadeCarga
		{
			get { return validadeCarga; }
			set { validadeCarga = value; }
		}

		/// <summary>
		/// Setores que serão exibidos.
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
			CarregarConfigurações();

			base.AoExibirDaPrimeiraVez ();
		}

		/// <summary>
		/// Ocorre ao exibir a base inferior.
		/// </summary>
		protected override void AoExibir()
		{
			base.AoExibir();

			if (próximaCarga <= DateTime.Now)
				CarregarDados();

            opçãoProcurar_Click(this, new EventArgs());

            //timerRecarregarLista.Enabled = true;
		}

		/// <summary>
		/// Carrega os setores e verifica quais o usuário
		/// deseja utilizar.
		/// </summary>
		private void CarregarConfigurações()
		{
			Setor []     atendimento;
			ArrayList    setores;
			ConfiguraçãoUsuário<bool> registro;
            ConfiguraçãoUsuário<int> prazo;
            ConfiguraçãoUsuário<bool> bSetor;
            Setor setorNE = Setor.ObterSetor(Setor.SetorSistema.NãoEspecificado);

			atendimento = Setor.ObterSetoresAtendimento();
			setores     = new ArrayList(atendimento.Length + 1);
            setores.Add(setorNE);

            registro = new ConfiguraçãoUsuário<bool>("BaseSeleçãoClienteSetor: configurado", false);

            if (!registro.Valor)
			{
				if (!Configurar(atendimento))
                    this.setores = new Setor[0];
                return;
			}

            prazo = new ConfiguraçãoUsuário<int>("BaseSeleçãoClienteSetor: prazo", 90);
            Prazo = prazo.Valor;

            foreach (Setor setor in atendimento)
            {
                bSetor = new ConfiguraçãoUsuário<bool>("BaseSeleçãoClienteSetor: setor " + setor.Nome, setor.Código == setorNE.Código);

                if (bSetor.Valor)
                    setores.Add(setor);
            }

			this.setores = (Setor []) setores.ToArray(typeof(Setor));
		}

		/// <summary>
		/// Exibe janela de configuração.
		/// </summary>
		private bool Configurar()
		{
			Setor [] setores;

			setores = Setor.ObterSetoresAtendimento();

			return Configurar(setores);
		}

		/// <summary>
		/// Exibe janela de configuração.
		/// </summary>
		/// <returns>Se foram realizadas modificações.</returns>
		private bool Configurar(Setor [] setores)
		{
			using (DlgConfigSeleçãoClienteSetor dlg =
					   new DlgConfigSeleçãoClienteSetor(this, "BaseSeleçãoClienteSetor", setores))
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
			próximaCarga = DateTime.Now.Add(validadeCarga);
		}

		/// <summary>
		/// Ocorre ao clicar no botão recarregar.
		/// </summary>
		private void opçãoRecarregar_Click(object sender, System.EventArgs e)
		{
			CarregarDados();
		}

		/// <summary>
		/// Ocorre ao clicar em reconfigurar.
		/// </summary>
		private void opçãoReconfigurar_Click(object sender, System.EventArgs e)
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