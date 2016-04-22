using System;

using Apresenta��o.Formul�rios;
using Apresenta��o.Usu�rio.Agendamentos;
using Apresenta��o.Usu�rio.Visitantes;

namespace Apresenta��o.Usu�rio.InterForm
{
	/// <summary>
	/// Controlador das bases inferiores referentes ao usu�rio.
	/// </summary>
	public class ControladorUsu�rio : ControladorBaseInferior
	{
		/// <summary>
		/// Bot�o do usu�rio.
		/// </summary>
		private Bot�oUsu�rio bot�o;

		/// <summary>
		/// Funcion�rio atual.
		/// </summary>
		private Entidades.Pessoa.Funcion�rio funcion�rio;

        /// <summary>
        /// Controla a��es sobre agendamentos.
        /// </summary>
        private ControleAgendamento controleAgendamento;

        /// <summary>
        /// Controla entrada e sa�da de visitantes.
        /// </summary>
        private ControleVisitantes controleVisitantes;

        /// <summary>
        /// Base inferior de agendamentos.
        /// </summary>
        private BaseAgendamentos baseAgendamentos;

		/// <summary>
		/// Constr�i o controlador das bases inferiores referentes ao usua'rio.
		/// </summary>
		/// <param name="bot�o">Bot�o do usu�rio.</param>
		public ControladorUsu�rio(Bot�oUsu�rio bot�o)
		{
			this.bot�o = bot�o;
		}

		/// <summary>
		/// Ocorre ao carregar o programa completamente.
		/// </summary>
        protected internal override void AoCarregarCompletamente(Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            //if (splash != null)
            //    splash.Mensagem = "Carregando controlador de usu�rio...";

			RecuperarUsu�rio();

            //if (this.funcion�rio.Setor.Atendimento)
            //    InserirBaseInferior(new Apresenta��o.Usu�rio.InterForm.BaseUsu�rio..Atendimento.BaseClientes(funcion�rio));
            //else
                //InserirBaseInferior(new Apresenta��o.Atendimento.Clientes.BaseSele��oCliente());
            InserirBaseInferior(new Apresenta��o.Usu�rio.InterForm.BaseUsu�rio(funcion�rio));

            if (Acesso.Comum.Usu�rios.Usu�rioAtual.GerenciadorConex�es.SenhaRuim)
            {
                using (Funcion�rios.GuiaNovato dlg = new Apresenta��o.Usu�rio.Funcion�rios.GuiaNovato())
                {
                    dlg.ShowDialog();
                }
            }
        
            controleAgendamento = new ControleAgendamento(this);

            if (funcion�rio.Setor.Atendimento)
                controleVisitantes = new ControleVisitantes();

            Exibir();
        }

		/// <summary>
		/// Recupera dados do usu�rio, atualizando interface
		/// do bot�o.
		/// </summary>
		private void RecuperarUsu�rio()
		{
			Acesso.Comum.Usu�rio usu�rio   = Acesso.Comum.Usu�rios.Usu�rioAtual;

			funcion�rio = Entidades.Pessoa.Funcion�rio.ObterFuncion�rioPorUsu�rio(usu�rio);

			if (funcion�rio == null)
			{
                string msgErro = "O nome-de-usu�rio " + usu�rio.Nome + " n�o est� atribu�do a um funcion�rio na tabela de funcion�rios.";

                //Console.WriteLine(msgErro);

                //System.Windows.Forms.MessageBox.Show(msgErro,
                //    "Conex�o com o banco de dados.",
                //    System.Windows.Forms.MessageBoxButtons.OK,
                //    System.Windows.Forms.MessageBoxIcon.Error);

                //throw new ApplicationException(msgErro);

                throw new Exce��oBot�oN�oSuportado(msgErro);
			}

			bot�o.AtualizarAssincronamente(funcion�rio);
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
            MostrarBaseFormul�rio(baseAgendamentos);
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
