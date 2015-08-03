using System;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Interface para implementação de rotinas após a carga
	/// completa do sistema. Neste instante, o banco de dados
	/// já está conectado e o usuário já autenticado no sistema,
	/// contendo conexões já estabelecidas com a fachada da camada
	/// de negócio.
	/// </summary>
	public interface IPósCargaSistema
	{
		/// <summary>
		/// Ocorre uma única vez ao carregar complemente o sistema.
		/// </summary>
		void AoCarregarCompletamente(Splash splash);
	}
}
