using System;
using Microsoft.Win32;

namespace Entidades.Configuração
{
	/// <summary>
	/// Registro de configuração
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
			regIMJ      = regSoftware.OpenSubKey("Indústria Mineira de Joias", true);

			if (regIMJ == null)
				throw new ChaveInexistente("Indústria Mineira de Joias");
		}

		/// <summary>
		/// Abre a chave no registro.
		/// </summary>
		/// <param name="nome">Chave.</param>
		public Chave(string nome) : this()
		{
			registro = regIMJ.OpenSubKey(nome, true);

			if (registro == null)
				throw new ChaveInexistente("Indústria Mineira de Joias\\" + nome);
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
		/// Obtém valor do registro.
		/// </summary>
		/// <param name="chave">Chave do item.</param>
		/// <param name="valorPadrão">Valor padrão do item.</param>
		/// <returns>Valor no registro.</returns>
		public object ObterValor(string chave, object valorPadrão)
		{
			return registro.GetValue(chave, valorPadrão);
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
