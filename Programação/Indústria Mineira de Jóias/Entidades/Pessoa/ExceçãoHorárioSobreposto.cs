using System;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Ocorre quando um hor�rio sobrep�e outro.
	/// </summary>
	public class Exce��oHor�rioSobreposto : System.ApplicationException
	{
		private Hor�rio [] hor�rios;
        private Funcion�rio funcion�rio;

		/// <summary>
		/// Constr�i a exce��o.
		/// </summary>
		public Exce��oHor�rioSobreposto(Funcion�rio funcion�rio, Hor�rio a, Hor�rio b)
		{
            this.funcion�rio = funcion�rio;
			this.hor�rios = new Hor�rio [] { a, b };
		}

		/// <summary>
		/// Hor�rios conflitantes.
		/// </summary>
		public Hor�rio [] Hor�rios
		{
			get { return hor�rios; }
		}

        public Funcion�rio Funcion�rio
        {
            get { return funcion�rio; }
        }

		public override string Message
		{
			get
			{
				return "Existe sobreposi��o de hor�rios.";
			}
		}
	}
}
