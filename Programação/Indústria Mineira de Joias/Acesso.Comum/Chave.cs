using System;
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;

namespace Acesso.Comum
{
	/// <summary>
	/// Chave para identificação de usuário
	/// </summary>
	/// <example>
	/// A validação é feita conforme exemplo:
	/// 
	/// public bool ValidarChave(Chave a, Chave b)
	/// {
	///    return a == b;
	/// }
	/// </example>
	[Serializable]
	public struct Chave : ILogicalThreadAffinative
	{
		private byte [] código;

		/// <summary>
		/// Constrói uma chave
		/// </summary>
		/// <param name="usuário">Usuário</param>
		/// <param name="senha">Senha</param>
		public Chave(string usuário, string senha)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
			byte [] dados;

			dados = ascii.GetBytes(DateTime.Now.Ticks.ToString() + usuário + senha);

			código = md5.ComputeHash(dados);
		}

		/// <summary>
		/// Verifica equivalência de chaves
		/// </summary>
		public static bool operator == (Chave a, Chave b)
		{
			bool válido = true;

			if (a.código.Length == b.código.Length)
				for (int i = 0; i < a.código.Length; i++)
					válido &= a.código[i] == b.código[i];
			else
				return false;

			return válido;
		}

		/// <summary>
		/// Verifica inequivalência entre chaves
		/// </summary>
		public static bool operator != (Chave a, Chave b)
		{
			bool válido = false;

			if (a.código.Length == b.código.Length)
				for (int i = 0; i < a.código.Length; i++)
					válido |= a.código[i] == b.código[i];
			else
				return true;

			return !válido;
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
		/// Obtém o código hash
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 0;
			int aux  = 0;

			foreach (byte b in código)
			{
				hash ^= b << aux;
				aux = (aux + 3) % 25;
			}

			return hash;
		}
	}
}
