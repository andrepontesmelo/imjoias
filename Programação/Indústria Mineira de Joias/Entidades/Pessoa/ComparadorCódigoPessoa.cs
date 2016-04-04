using System;
using System.Collections;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Compara pessoa pelo c�digo.
	/// </summary>
	public class ComparadorC�digoPessoa : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((Pessoa) x).C�digo.CompareTo(((Pessoa) y).C�digo);
		}
	}
}
