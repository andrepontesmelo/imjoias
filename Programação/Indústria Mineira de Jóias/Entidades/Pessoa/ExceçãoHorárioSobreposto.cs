using System;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Ocorre quando um horário sobrepõe outro.
	/// </summary>
	public class ExceçãoHorárioSobreposto : System.ApplicationException
	{
		private Horário [] horários;
        private Funcionário funcionário;

		/// <summary>
		/// Constrói a exceção.
		/// </summary>
		public ExceçãoHorárioSobreposto(Funcionário funcionário, Horário a, Horário b)
		{
            this.funcionário = funcionário;
			this.horários = new Horário [] { a, b };
		}

		/// <summary>
		/// Horários conflitantes.
		/// </summary>
		public Horário [] Horários
		{
			get { return horários; }
		}

        public Funcionário Funcionário
        {
            get { return funcionário; }
        }

		public override string Message
		{
			get
			{
				return "Existe sobreposição de horários.";
			}
		}
	}
}
