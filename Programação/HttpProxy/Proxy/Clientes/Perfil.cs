using System;
using System.Net;
//using System.Net.Sockets;

namespace Proxy.Clientes
{
	/// <summary>
	/// Caracteriza o perfil de um usu�rio,
	/// classificando-o em grupos conforme perfil.
	/// </summary>
	public class Perfil
	{
		private byte []		ip;
		private byte []		m�scara;
		private Validador	validador;

		/// <summary>
		/// Constr�i um perfil baseado em m�scara
		/// </summary>
		/// <param name="ip">Endere�o IP</param>
		/// <param name="m�scara">M�scara do IP</param>
		/// <param name="validador">Validador para cliente</param>
		public Perfil(string ip, string m�scara, Validador validador)
		{
			this.ip        = InterpretarEndere�o(ip);
			this.m�scara   = InterpretarEndere�o(m�scara);
			this.validador = validador;
		}

		/// <summary>
		/// Constr�i um perfil baseado em m�scara
		/// </summary>
		/// <param name="ip">Endere�o IP</param>
		/// <param name="m�scara">M�scara do IP</param>
		/// <param name="validador">Validador para cliente</param>
		public Perfil(byte [] ip, byte [] m�scara, Validador validador)
		{
			this.ip         = ip;
			this.m�scara    = m�scara;
			this.validador  = validador;
		}

		/// <summary>
		/// Interpreta um endere�o IP
		/// </summary>
		/// <param name="endere�o">Endere�o IP</param>
		/// <returns>Vetor de bytes contendo endere�o</returns>
		private byte [] InterpretarEndere�o(string endere�o)
		{
			string [] n�meros;
			byte []   resultado;
			int       i;

			n�meros   = endere�o.Split('.');
			resultado = new byte[n�meros.Length];
			i         = 0;

			foreach (string n�mero in n�meros)
				resultado[i] = byte.Parse(n�mero);

			return resultado;
		}

		/// <summary>
		/// Valida uma URI para o perfil de cliente
		/// </summary>
		/// <param name="uri">URI a ser validada</param>
		/// <returns>Autoriza��o</returns>
		public bool Validar(Uri uri)
		{
			return validador.Validar(uri);
		}

		/// <summary>
		/// Verifica se um cliente se enquadra neste perfil
		/// </summary>
		/// <param name="ip">IP do cliente</param>
		/// <returns>Se o cliente pertence ao perfil</returns>
		public bool VerificarEnquadramento(byte [] ip)
		{
			bool v�lido;

			if (ip.Length != this.ip.Length)
				return false;

			v�lido = true;

			for (int i = 0; i < ip.Length; i++)
				v�lido &= (ip[i] & m�scara[i]) == (this.ip[i] & m�scara[i]);

			return v�lido;
		}
	}
}
