using System;
using Acesso.Comum;
using Microsoft.Win32;

namespace Entidades.Configura��o
{
	/// <summary>
	/// Registro de configura��o do usu�rio
	/// </summary>
    [Obsolete("Use Configura��oUsu�rio.", true)]
	public class ChaveUsu�rio : Chave
	{
		private const string prefixo = "Usu�rio \"";
		private const string sufixo  = "\"";
		private string nome;
		protected RegistryKey registroUsu�rio;

		/// <summary>
		/// Abre a chave do usu�rio.
		/// </summary>
		public ChaveUsu�rio() : base()
		{
			nome = Usu�rios.Usu�rioAtual.Nome;

			registroUsu�rio = regIMJ.OpenSubKey(prefixo + nome + sufixo);

			if (registroUsu�rio == null)
				throw new ChaveInexistente("Ind�stria Mineira de Joias\\" + prefixo + nome + sufixo);
		}

		/// <summary>
		/// Abre uma chave para o usu�rio.
		/// </summary>
		/// <param name="chave">Chave.</param>
		public ChaveUsu�rio(string chave) : this()
		{
			registro = registroUsu�rio.OpenSubKey(chave, true);

			if (registro == null)
				throw new ChaveInexistente("Ind�stria Mineira de Joias\\" + prefixo + nome + sufixo + "\\" + chave);
		}

		/// <summary>
		/// Constr�i uma chave para o usu�rio.
		/// </summary>
		/// <param name="chave">Chave a ser constru�da.</param>
		/// <returns>Chave do usu�rio.</returns>
		public static ChaveUsu�rio CriarChave(string chave)
		{
			RegistryKey regSoftware, regIMJ, regUsu�rio;
			string nome;

			nome        = Usu�rios.Usu�rioAtual.Nome;
			regSoftware = Registry.LocalMachine.OpenSubKey("Software", true);
			regIMJ      = regSoftware.OpenSubKey("Ind�stria Mineira de Joias", true);

			if (regIMJ == null)
				regIMJ = regSoftware.CreateSubKey("Ind�stria Mineira de Joias");

			regUsu�rio = regIMJ.OpenSubKey(prefixo + nome + sufixo, true);

			if (regUsu�rio == null)
				regUsu�rio = regIMJ.CreateSubKey(prefixo + nome + sufixo);

			regUsu�rio.CreateSubKey(chave).Close();
			regUsu�rio.Close();
			regIMJ.Close();
			regSoftware.Close();

			return new ChaveUsu�rio(chave);
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

			registroUsu�rio.Close();

			base.Dispose();
		}

	}
}
