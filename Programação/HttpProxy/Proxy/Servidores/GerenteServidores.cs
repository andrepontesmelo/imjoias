using System;

namespace Proxy.Servidores
{
	/// <summary>
	/// Coleção de servidores
	/// </summary>
	public class GerenteServidores
	{
		#region Singleton

		/// <summary>
		/// Torna a construtora privada para que ninguém possa instanciá-la.
		/// </summary>
		private GerenteServidores() {}

		/// <summary>
		/// Instância única
		/// </summary>
		private static GerenteServidores instância = new GerenteServidores();

		/// <summary>
		/// Acesso à instância única
		/// </summary>
		public static GerenteServidores Instância
		{
			get { return instância; }
		}

		#endregion

		/// <summary>
		/// Obtém o servidor a partir de seu host
		/// </summary>
		public Servidor this[string nome, int porta]
		{
			get
			{
				// TODO: Verificar se já existe uma conexão aberta para ser usada
				// caso o protocolo seja 1.1. Isso será feito implementando duas
				// classes que herdam de Servidor: as classes ServidorHTTP10 e
				// ServidorHTTP11.
				return new ServidorExclusivo(nome, porta);
			}
		}
	}
}
