using System;
using System.Threading;

namespace Apresenta��o.Usu�rio
{
	/// <summary>
	/// Utilizado para constru��o de controles que dependam
	/// de usu�rio.
	/// </summary>
	public abstract class Controle
	{
        protected Timer temporizador;
        
		/// <summary>
		/// Constr�i o controle.
		/// </summary>
		public Controle()
		{
            temporizador = new Timer(new TimerCallback(TemporizadorDisparou),
                null,
                AtrasoParaPrimeiraVerifica��o,
                IntervaloTemporizador);
		}

		#region Propriedades

		/// <summary>
		/// Usu�rio atual.
		/// </summary>
		protected Acesso.Comum.Usu�rio Usu�rioAtual
		{
			get { return Acesso.Comum.Usu�rios.Usu�rioAtual; }
		}

        protected virtual int AtrasoParaPrimeiraVerifica��o
        {
            get { return Entidades.Configura��o.DadosGlobais.Inst�ncia.ControleUsu�rioIntervalo; }
        }

        protected virtual int IntervaloTemporizador
        {
            get { return Entidades.Configura��o.DadosGlobais.Inst�ncia.ControleUsu�rioIntervalo; }
        }

		#endregion

        protected abstract void TemporizadorDisparou(object obj);
	}
}
