using System;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Interface para implementa��o de rotinas ap�s a carga
	/// completa do sistema. Neste instante, o banco de dados
	/// j� est� conectado e o usu�rio j� autenticado no sistema,
	/// contendo conex�es j� estabelecidas com a fachada da camada
	/// de neg�cio.
	/// </summary>
	public interface IP�sCargaSistema
	{
		/// <summary>
		/// Ocorre uma �nica vez ao carregar complemente o sistema.
		/// </summary>
		void AoCarregarCompletamente(Splash splash);
	}
}
