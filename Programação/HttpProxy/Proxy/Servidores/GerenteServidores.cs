using System;

namespace Proxy.Servidores
{
	/// <summary>
	/// Cole��o de servidores
	/// </summary>
	public class GerenteServidores
	{
		#region Singleton

		/// <summary>
		/// Torna a construtora privada para que ningu�m possa instanci�-la.
		/// </summary>
		private GerenteServidores() {}

		/// <summary>
		/// Inst�ncia �nica
		/// </summary>
		private static GerenteServidores inst�ncia = new GerenteServidores();

		/// <summary>
		/// Acesso � inst�ncia �nica
		/// </summary>
		public static GerenteServidores Inst�ncia
		{
			get { return inst�ncia; }
		}

		#endregion

		/// <summary>
		/// Obt�m o servidor a partir de seu host
		/// </summary>
		public Servidor this[string nome, int porta]
		{
			get
			{
				// TODO: Verificar se j� existe uma conex�o aberta para ser usada
				// caso o protocolo seja 1.1. Isso ser� feito implementando duas
				// classes que herdam de Servidor: as classes ServidorHTTP10 e
				// ServidorHTTP11.
				return new ServidorExclusivo(nome, porta);
			}
		}
	}
}
