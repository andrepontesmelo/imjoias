using System;
using Acesso.Comum;
using Microsoft.Win32;

namespace Entidades.Configuração
{
	/// <summary>
	/// Registro de configuração do usuário
	/// </summary>
    [Obsolete("Use ConfiguraçãoUsuário.", true)]
	public class ChaveUsuário : Chave
	{
		private const string prefixo = "Usuário \"";
		private const string sufixo  = "\"";
		private string nome;
		protected RegistryKey registroUsuário;

		/// <summary>
		/// Abre a chave do usuário.
		/// </summary>
		public ChaveUsuário() : base()
		{
			nome = Usuários.UsuárioAtual.Nome;

			registroUsuário = regIMJ.OpenSubKey(prefixo + nome + sufixo);

			if (registroUsuário == null)
				throw new ChaveInexistente("Indústria Mineira de Joias\\" + prefixo + nome + sufixo);
		}

		/// <summary>
		/// Abre uma chave para o usuário.
		/// </summary>
		/// <param name="chave">Chave.</param>
		public ChaveUsuário(string chave) : this()
		{
			registro = registroUsuário.OpenSubKey(chave, true);

			if (registro == null)
				throw new ChaveInexistente("Indústria Mineira de Joias\\" + prefixo + nome + sufixo + "\\" + chave);
		}

		/// <summary>
		/// Constrói uma chave para o usuário.
		/// </summary>
		/// <param name="chave">Chave a ser construída.</param>
		/// <returns>Chave do usuário.</returns>
		public static ChaveUsuário CriarChave(string chave)
		{
			RegistryKey regSoftware, regIMJ, regUsuário;
			string nome;

			nome        = Usuários.UsuárioAtual.Nome;
			regSoftware = Registry.LocalMachine.OpenSubKey("Software", true);
			regIMJ      = regSoftware.OpenSubKey("Indústria Mineira de Joias", true);

			if (regIMJ == null)
				regIMJ = regSoftware.CreateSubKey("Indústria Mineira de Joias");

			regUsuário = regIMJ.OpenSubKey(prefixo + nome + sufixo, true);

			if (regUsuário == null)
				regUsuário = regIMJ.CreateSubKey(prefixo + nome + sufixo);

			regUsuário.CreateSubKey(chave).Close();
			regUsuário.Close();
			regIMJ.Close();
			regSoftware.Close();

			return new ChaveUsuário(chave);
		}

		/// <summary>
		/// Recursos liberados
		/// </summary>
		public override void Dispose()
		{
			if (registro != null)
			{
				registro.Close();
				registro = null;
			}

			registroUsuário.Close();

			base.Dispose();
		}

	}
}
