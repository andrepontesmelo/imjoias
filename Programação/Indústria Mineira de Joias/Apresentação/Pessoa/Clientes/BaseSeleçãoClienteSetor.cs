using Entidades;
using Entidades.Configuração;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Atendimento.Clientes
{
    public class BaseSeleçãoClienteSetor : BaseSeleçãoCliente
	{
		// Atributos
		protected DateTime próximaCarga = DateTime.MinValue;
		protected TimeSpan validadeCarga = new TimeSpan(3, 0, 0);
        protected Setor[] setores;

		// Componentes
		private IContainer components = null;

		public BaseSeleçãoClienteSetor()
		{
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
            // BaseSeleçãoClienteSetor
            // 
            this.Name = "BaseSeleçãoClienteSetor";
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

            CarregarDados();
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
            Setor setorNE = Setor.ObterSetor(SetorSistema.NãoEspecificado);

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

		private bool Configurar(Setor [] setores)
		{
			using (DlgConfigSeleçãoClienteSetor dlg =
					   new DlgConfigSeleçãoClienteSetor(this, "BaseSeleçãoClienteSetor", setores))
			{
				return dlg.ShowDialog(this.ParentForm) == DialogResult.OK;
			}
		}

        protected virtual void CarregarDados()
        {
            CarregarAssíncrono();
        }
	}
}