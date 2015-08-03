using System;
using System.Threading;

namespace Apresentação.Usuário
{
	/// <summary>
	/// Utilizado para construção de controles que dependam
	/// de usuário.
	/// </summary>
	public abstract class Controle
	{
        protected Timer temporizador;
        
		/// <summary>
		/// Constrói o controle.
		/// </summary>
		public Controle()
		{
            temporizador = new Timer(new TimerCallback(TemporizadorDisparou),
                null,
                AtrasoParaPrimeiraVerificação,
                IntervaloTemporizador);
		}

		#region Propriedades

		/// <summary>
		/// Usuário atual.
		/// </summary>
		protected Acesso.Comum.Usuário UsuárioAtual
		{
			get { return Acesso.Comum.Usuários.UsuárioAtual; }
		}

        protected virtual int AtrasoParaPrimeiraVerificação
        {
            get { return Entidades.Configuração.DadosGlobais.Instância.ControleUsuárioIntervalo; }
        }

        protected virtual int IntervaloTemporizador
        {
            get { return Entidades.Configuração.DadosGlobais.Instância.ControleUsuárioIntervalo; }
        }

		#endregion

        protected abstract void TemporizadorDisparou(object obj);
	}
}
