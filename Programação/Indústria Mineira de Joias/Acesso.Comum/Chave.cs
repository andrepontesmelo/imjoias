using System;
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;

namespace Acesso.Comum
{
	/// <summary>
	/// Chave para identifica��o de usu�rio
	/// </summary>
	/// <example>
	/// A valida��o � feita conforme exemplo:
	/// 
	/// public bool ValidarChave(Chave a, Chave b)
	/// {
	///    return a == b;
	/// }
	/// </example>
	[Serializable]
	public struct Chave : ILogicalThreadAffinative
	{
		private byte [] c�digo;

		/// <summary>
		/// Constr�i uma chave
		/// </summary>
		/// <param name="usu�rio">Usu�rio</param>
		/// <param name="senha">Senha</param>
		public Chave(string usu�rio, string senha)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
			byte [] dados;

			dados = ascii.GetBytes(DateTime.Now.Ticks.ToString() + usu�rio + senha);

			c�digo = md5.ComputeHash(dados);
		}

		/// <summary>
		/// Verifica equival�ncia de chaves
		/// </summary>
		public static bool operator == (Chave a, Chave b)
		{
			bool v�lido = true;

			if (a.c�digo.Length == b.c�digo.Length)
				for (int i = 0; i < a.c�digo.Length; i++)
					v�lido &= a.c�digo[i] == b.c�digo[i];
			else
				return false;

			return v�lido;
		}

		/// <summary>
		/// Verifica inequival�ncia entre chaves
		/// </summary>
		public static bool operator != (Chave a, Chave b)
		{
			bool v�lido = false;

			if (a.c�digo.Length == b.c�digo.Length)
				for (int i = 0; i < a.c�digo.Length; i++)
					v�lido |= a.c�digo[i] == b.c�digo[i];
			else
				return true;

			return !v�lido;
		}

		/// <summary>
		/// Compara objetos
		/// </summary>
		public override bool Equals(object obj)
		{
			if (obj.GetType() != typeof(Chave))
				return false;

			return this == (Chave) obj;
		}

		/// <summary>
		/// Obt�m o c�digo hash
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 0;
			int aux  = 0;

			foreach (byte b in c�digo)
			{
				hash ^= b << aux;
				aux = (aux + 3) % 25;
			}

			return hash;
		}
	}
}
