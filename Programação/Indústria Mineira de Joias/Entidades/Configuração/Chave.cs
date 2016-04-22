using System;
using Microsoft.Win32;

namespace Entidades.Configura��o
{
	/// <summary>
	/// Registro de configura��o
	/// </summary>
    [Obsolete]
	public class Chave : IDisposable
	{
		private   RegistryKey regSoftware;
		protected RegistryKey regIMJ;
		protected RegistryKey registro;

		/// <summary>
		/// Abre a chave principal da firma.
		/// </summary>
		protected Chave()
		{
			regSoftware = Registry.LocalMachine.OpenSubKey("Software");
			regIMJ      = regSoftware.OpenSubKey("Ind�stria Mineira de Joias", true);

			if (regIMJ == null)
				throw new ChaveInexistente("Ind�stria Mineira de Joias");
		}

		/// <summary>
		/// Abre a chave no registro.
		/// </summary>
		/// <param name="nome">Chave.</param>
		public Chave(string nome) : this()
		{
			registro = regIMJ.OpenSubKey(nome, true);

			if (registro == null)
				throw new ChaveInexistente("Ind�stria Mineira de Joias\\" + nome);
		}

		/// <summary>
		/// Valor na chave.
		/// </summary>
		public object this[string chave]
		{
			get
			{
				return registro.GetValue(chave);
			}
			set
			{
				registro.SetValue(chave, value);
			}
		}

		/// <summary>
		/// Obt�m valor do registro.
		/// </summary>
		/// <param name="chave">Chave do item.</param>
		/// <param name="valorPadr�o">Valor padr�o do item.</param>
		/// <returns>Valor no registro.</returns>
		public object ObterValor(string chave, object valorPadr�o)
		{
			return registro.GetValue(chave, valorPadr�o);
		}

		#region IDisposable Members

		public virtual void Dispose()
		{
			regSoftware.Close();
			regIMJ.Close();

			if (registro != null)
				registro.Close();
		}

		#endregion
	}
}
