using System;
using System.Net;
//using System.Net.Sockets;

namespace Proxy.Clientes
{
	/// <summary>
	/// Caracteriza o perfil de um usuário,
	/// classificando-o em grupos conforme perfil.
	/// </summary>
	public class Perfil
	{
		private byte []		ip;
		private byte []		máscara;
		private Validador	validador;

		/// <summary>
		/// Constrói um perfil baseado em máscara
		/// </summary>
		/// <param name="ip">Endereço IP</param>
		/// <param name="máscara">Máscara do IP</param>
		/// <param name="validador">Validador para cliente</param>
		public Perfil(string ip, string máscara, Validador validador)
		{
			this.ip        = InterpretarEndereço(ip);
			this.máscara   = InterpretarEndereço(máscara);
			this.validador = validador;
		}

		/// <summary>
		/// Constrói um perfil baseado em máscara
		/// </summary>
		/// <param name="ip">Endereço IP</param>
		/// <param name="máscara">Máscara do IP</param>
		/// <param name="validador">Validador para cliente</param>
		public Perfil(byte [] ip, byte [] máscara, Validador validador)
		{
			this.ip         = ip;
			this.máscara    = máscara;
			this.validador  = validador;
		}

		/// <summary>
		/// Interpreta um endereço IP
		/// </summary>
		/// <param name="endereço">Endereço IP</param>
		/// <returns>Vetor de bytes contendo endereço</returns>
		private byte [] InterpretarEndereço(string endereço)
		{
			string [] números;
			byte []   resultado;
			int       i;

			números   = endereço.Split('.');
			resultado = new byte[números.Length];
			i         = 0;

			foreach (string número in números)
				resultado[i] = byte.Parse(número);

			return resultado;
		}

		/// <summary>
		/// Valida uma URI para o perfil de cliente
		/// </summary>
		/// <param name="uri">URI a ser validada</param>
		/// <returns>Autorização</returns>
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
			bool válido;

			if (ip.Length != this.ip.Length)
				return false;

			válido = true;

			for (int i = 0; i < ip.Length; i++)
				válido &= (ip[i] & máscara[i]) == (this.ip[i] & máscara[i]);

			return válido;
		}
	}
}
