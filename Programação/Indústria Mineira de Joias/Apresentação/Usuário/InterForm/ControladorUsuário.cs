using System;

using Apresentação.Formulários;
using Apresentação.Usuário.Agendamentos;
using Apresentação.Usuário.Visitantes;

namespace Apresentação.Usuário.InterForm
{
	/// <summary>
	/// Controlador das bases inferiores referentes ao usuário.
	/// </summary>
	public class ControladorUsuário : ControladorBaseInferior
	{
		/// <summary>
		/// Botão do usuário.
		/// </summary>
		private BotãoUsuário botão;

		/// <summary>
		/// Funcionário atual.
		/// </summary>
		private Entidades.Pessoa.Funcionário funcionário;

        /// <summary>
        /// Controla ações sobre agendamentos.
        /// </summary>
        private ControleAgendamento controleAgendamento;

        /// <summary>
        /// Controla entrada e saída de visitantes.
        /// </summary>
        private ControleVisitantes controleVisitantes;

        /// <summary>
        /// Base inferior de agendamentos.
        /// </summary>
        private BaseAgendamentos baseAgendamentos;

		/// <summary>
		/// Constrói o controlador das bases inferiores referentes ao usua'rio.
		/// </summary>
		/// <param name="botão">Botão do usuário.</param>
		public ControladorUsuário(BotãoUsuário botão)
		{
			this.botão = botão;
		}

		/// <summary>
		/// Ocorre ao carregar o programa completamente.
		/// </summary>
        protected internal override void AoCarregarCompletamente(Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            //if (splash != null)
            //    splash.Mensagem = "Carregando controlador de usuário...";

			RecuperarUsuário();

            //if (this.funcionário.Setor.Atendimento)
            //    InserirBaseInferior(new Apresentação.Usuário.InterForm.BaseUsuário..Atendimento.BaseClientes(funcionário));
            //else
                //InserirBaseInferior(new Apresentação.Atendimento.Clientes.BaseSeleçãoCliente());
            InserirBaseInferior(new Apresentação.Usuário.InterForm.BaseUsuário(funcionário));

            if (Acesso.Comum.Usuários.UsuárioAtual.GerenciadorConexões.SenhaRuim)
            {
                using (Funcionários.GuiaNovato dlg = new Apresentação.Usuário.Funcionários.GuiaNovato())
                {
                    dlg.ShowDialog();
                }
            }
        
            controleAgendamento = new ControleAgendamento(this);

            if (funcionário.Setor.Atendimento)
                controleVisitantes = new ControleVisitantes();

            Exibir();
        }

		/// <summary>
		/// Recupera dados do usuário, atualizando interface
		/// do botão.
		/// </summary>
		private void RecuperarUsuário()
		{
			Acesso.Comum.Usuário usuário   = Acesso.Comum.Usuários.UsuárioAtual;

			funcionário = Entidades.Pessoa.Funcionário.ObterFuncionárioPorUsuário(usuário);

			if (funcionário == null)
			{
                string msgErro = "O nome-de-usuário " + usuário.Nome + " não está atribuído a um funcionário na tabela de funcionários.";

                //Console.WriteLine(msgErro);

                //System.Windows.Forms.MessageBox.Show(msgErro,
                //    "Conexão com o banco de dados.",
                //    System.Windows.Forms.MessageBoxButtons.OK,
                //    System.Windows.Forms.MessageBoxIcon.Error);

                //throw new ApplicationException(msgErro);

                throw new ExceçãoBotãoNãoSuportado(msgErro);
			}

			botão.AtualizarAssincronamente(funcionário);
		}

        /// <summary>
        /// Mostra base de agendamentos.
        /// </summary>
        public void MostrarAgendamentos()
        {
            if (baseAgendamentos == null)
            {
                baseAgendamentos = new BaseAgendamentos();
                
                InserirBaseInferior(baseAgendamentos);
            }

            SubstituirBaseAtual(baseAgendamentos);
            MostrarBaseFormulário(baseAgendamentos);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (controleAgendamento != null)
                controleAgendamento.Dispose();

            if (baseAgendamentos != null)
                baseAgendamentos.Dispose();
        }
    }
}
