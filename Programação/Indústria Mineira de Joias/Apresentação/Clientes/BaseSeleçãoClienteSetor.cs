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
        protected Setor[] setores;

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
            this.SuspendLayout();
            // 
            // BaseSele��oClienteSetor
            // 
            this.Name = "BaseSele��oClienteSetor";
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

            CarregarDados();
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
            //pr�ximaCarga = DateTime.Now.Add(validadeCarga);
        }

        ///// <summary>
        ///// Ocorre ao clicar no bot�o recarregar.
        ///// </summary>
        //private void op��oRecarregar_Click(object sender, System.EventArgs e)
        //{
        //    CarregarDados();
        //}

        ///// <summary>
        ///// Ocorre ao clicar em reconfigurar.
        ///// </summary>
        //private void op��oReconfigurar_Click(object sender, System.EventArgs e)
        //{
        //    if (Configurar())
        //        CarregarDados();
        //}

        //private void timerRecarregarLista_Tick(object sender, EventArgs e)
        //{
        //    CarregarDados();
        //}
	}
}