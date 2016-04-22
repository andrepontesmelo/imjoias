using System;
using System.Collections;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Compara pessoa pelo código.
	/// </summary>
	public class ComparadorCódigoPessoa : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((Pessoa) x).Código.CompareTo(((Pessoa) y).Código);
		}
	}
}
