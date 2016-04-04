using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Programa.Recepção
{
	/// <summary>
	/// Janela principal da recepção.
	/// </summary>
	public class Recepção : Apresentação.Formulários.BaseFormulário
	{
        private Apresentação.Usuário.Agendamentos.ControleAgendamento controleAgendamento;

		private Apresentação.Formulários.Botão botãoAgenda;
		private Apresentação.Formulários.Botão botãoLembretes;
		private Apresentação.Formulários.Botão botãoTelefonema;
		private Apresentação.Formulários.Botão botãoEntradaSaída;
		private Apresentação.Formulários.Botão botãoRodízio;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Recepção()
		{
            BaseInferior.EntradaSaída bES;
            BaseInferior.AusênciaAutomática bAA;

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			/* Para que a ausência automática seja mostrada logo que o
			 * programa comece quando há funcionários presentes fora
			 * de seu horário de trabalho, é necessário que o controlador
			 * de entrada e saída permita a exibição sem retornar à primeira,
			 * visto que é executado o método Exibir do controlador logo ao
			 * término da carga.
			 */
			botãoEntradaSaída.Controlador.RetornarÀPrimeira = false;

			botãoAgenda.AdicionarBaseInferior(new BaseInferior.Agenda());
			//botãoLembretes.AdicionarBaseInferior(new BaseInferior.Agendamentos());
			botãoTelefonema.AdicionarBaseInferior(new BaseInferior.Telefonemas());
			botãoEntradaSaída.AdicionarBaseInferior(bES = new BaseInferior.EntradaSaída());
            botãoEntradaSaída.AdicionarBaseInferior(bAA = new BaseInferior.AusênciaAutomática());
			botãoRodízio.Controlador = new ControladorBotãoRodízio();

			botãoEntradaSaída.Controlador.PermitirAutoExibição = true;

            controleAgendamento = new Apresentação.Usuário.Agendamentos.ControleAgendamento(botãoLembretes.Controlador);
            botãoLembretes.AdicionarBaseInferior(new Apresentação.Usuário.Agendamentos.BaseAgendamentos());

            bES.Considerar(bAA);
        }

		protected override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            if (!botãoEntradaSaída.Controlador.Exibindo)
			    botãoEntradaSaída.Controlador.Exibir();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Recepção));
			this.botãoAgenda = new Apresentação.Formulários.Botão();
			this.botãoLembretes = new Apresentação.Formulários.Botão();
			this.botãoTelefonema = new Apresentação.Formulários.Botão();
			this.botãoEntradaSaída = new Apresentação.Formulários.Botão();
			this.botãoRodízio = new Apresentação.Formulários.Botão();
			this.topo.SuspendLayout();
			this.barraBotões.SuspendLayout();
			this.SuspendLayout();
			// 
			// topo
			// 
			this.topo.Name = "topo";
			// 
			// barraBotões
			// 
			this.barraBotões.Botões = new Apresentação.Formulários.Botão[] {
																			   this.botãoAgenda,
																			   this.botãoLembretes,
																			   this.botãoTelefonema,
																			   this.botãoEntradaSaída,
																			   this.botãoRodízio};
			this.barraBotões.Name = "barraBotões";
			// 
			// botãoAgenda
			// 
			this.botãoAgenda.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoAgenda.Imagem")));
			this.botãoAgenda.RetornarÀPrimeira = true;
			this.botãoAgenda.Texto = "Agenda de Telefone";
			// 
			// botãoLembretes
			// 
			this.botãoLembretes.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoLembretes.Imagem")));
			this.botãoLembretes.RetornarÀPrimeira = true;
			this.botãoLembretes.Texto = "Lembretes";
			// 
			// botãoTelefonema
			// 
			this.botãoTelefonema.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoTelefonema.Imagem")));
			this.botãoTelefonema.RetornarÀPrimeira = true;
			this.botãoTelefonema.Texto = "Registrar Telefonema";
			// 
			// botãoEntradaSaída
			// 
			this.botãoEntradaSaída.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoEntradaSaída.Imagem")));
			this.botãoEntradaSaída.RetornarÀPrimeira = true;
			this.botãoEntradaSaída.Texto = "Entrada e Saída";
			// 
			// botãoRodízio
			// 
			this.botãoRodízio.Imagem = ((System.Drawing.Image)(resources.GetObject("botãoRodízio.Imagem")));
			this.botãoRodízio.RetornarÀPrimeira = true;
			this.botãoRodízio.Texto = "Rodízio";
			// 
			// Recepção
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 446);
			this.MinimumSize = new System.Drawing.Size(800, 480);
			this.Name = "Recepção";
			this.Text = "Indústria Mineira de Joias - Recepção";
			this.topo.ResumeLayout(false);
			this.barraBotões.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

        [STAThreadAttribute]
        private static void Main(string [] args)
		{
			Apresentação.Formulários.Aplicação.Executar(typeof(Programa.Recepção.Recepção), new Acesso.MySQL.MySQLUsuários(), false, true);
		}
	}
}
