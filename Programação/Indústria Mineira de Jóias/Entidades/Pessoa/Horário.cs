using System;
using Acesso.Comum;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Hor�rio de trabalho.
	/// </summary>
	[DbTabela("horariofuncionario"), Serializable]
	public class Hor�rio : DbManipula��oAutom�tica, IComparable
	{
		/// <summary>
		/// Funcion�io.
		/// </summary>
		[DbRelacionamento(true, "codigo", "funcionario")]
		private Funcion�rio funcionario;

		/// <summary>
		/// Dia de semana.
		/// </summary>
		[DbChavePrim�ria(false)]
		private DayOfWeek diaSemana;

		/// <summary>
		/// Hora inicial do dia.
		/// </summary>
		[DbChavePrim�ria(false)]
		private ushort iniHora;

		/// <summary>
		/// Minuto da hora inicial.
		/// </summary>
		[DbChavePrim�ria(false)]
		private ushort iniMinuto;

		/// <summary>
		/// Hora final do dia.
		/// </summary>
		private ushort fimHora;

		/// <summary>
		/// Minuto da hora final.
		/// </summary>
		private ushort fimMinuto;

		/// <summary>
		/// Constr�i o hor�rio vazio.
		/// </summary>
		public Hor�rio() {}

		/// <summary>
		/// Constr�i o hor�rio para um funcion�rio espec�fico.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio.</param>
		public Hor�rio(Funcion�rio funcion�rio)
		{
            if (funcion�rio == null)
                throw new ArgumentNullException();

			this.funcionario = funcion�rio;
		}

		/// <summary>
		/// Constr�i um hor�rio.
		/// </summary>
		public Hor�rio(Entidades.Pessoa.Funcion�rio funcion�rio, DayOfWeek diaSemana, ushort iniHora, ushort iniMinuto, ushort fimHora, ushort fimMinuto)
		{
			this.funcionario = funcion�rio;
			this.diaSemana   = diaSemana;
			this.iniHora     = iniHora;
			this.iniMinuto   = iniMinuto;
			this.fimHora     = fimHora;
			this.fimMinuto   = fimMinuto;
		}

        /// <summary>
        /// Constr�i um hor�rio j� cadastrado.
        /// </summary>
        internal static Hor�rio CriarHor�rioCadastrado(Entidades.Pessoa.Funcion�rio funcion�rio, DayOfWeek diaSemana, ushort iniHora, ushort iniMinuto, ushort fimHora, ushort fimMinuto)
        {
            Hor�rio hor�rio = new Hor�rio(funcion�rio, diaSemana, iniHora, iniMinuto, fimHora, fimMinuto);

            hor�rio.DefinirCadastrado();
            hor�rio.DefinirAtualizado();

            return hor�rio;
        }

		#region Operadores de compara��o

		public static bool operator < (Hor�rio a, Hor�rio b)
		{
			return (a.diaSemana < b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora < b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto < b.iniMinuto)));
		}

		public static bool operator <= (Hor�rio a, Hor�rio b)
		{
			return (a.diaSemana < b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora < b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto <= b.iniMinuto)));
		}

		public static bool operator > (Hor�rio a, Hor�rio b)
		{
			return (a.diaSemana > b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora > b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto > b.iniMinuto)));
		}

		public static bool operator >= (Hor�rio a, Hor�rio b)
		{
			return (a.diaSemana > b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora > b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto >= b.iniMinuto)));
		}

		// --- DateTime ---

		public static bool operator < (Hor�rio a, DateTime b)
		{
			return (a.diaSemana < b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora < b.Hour) || (a.iniHora == b.Hour && a.iniMinuto < b.Minute)));
		}

		public static bool operator <= (Hor�rio a, DateTime b)
		{
			return (a.diaSemana < b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora < b.Hour) || (a.iniHora == b.Hour && a.iniMinuto <= b.Minute)));
		}

		public static bool operator > (Hor�rio a, DateTime b)
		{
			return (a.diaSemana > b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora > b.Hour) || (a.iniHora == b.Hour && a.iniMinuto > b.Minute)));
		}

		public static bool operator >= (Hor�rio a, DateTime b)
		{
			return (a.diaSemana > b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora > b.Hour) || (a.iniHora == b.Hour && a.iniMinuto >= b.Minute)));
		}

		#endregion

		#region Propriedades

		/// <summary>
		/// Funcion�rio relacionado.
		/// </summary>
		public Funcion�rio Funcion�rio
		{
			get { return this.funcionario; }
		}

		/// <summary>
		/// Dia da semana.
		/// </summary>
		public DayOfWeek DiaSemana
		{
			get { return this.diaSemana; }
            set { diaSemana = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Hora inicial.
		/// </summary>
		public ushort IniHora
		{
			get { return iniHora; }
            set { iniHora = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Minuto da hora inicial.
		/// </summary>
		public ushort IniMinuto
		{
			get { return iniMinuto; }
            set { iniMinuto = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Hora final.
		/// </summary>
		public ushort FimHora
		{
			get { return fimHora; }
            set { fimHora = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Minuto da hora final.
		/// </summary>
		public ushort FimMinuto
		{
			get { return fimMinuto; }
            set { fimMinuto = value; DefinirDesatualizado(); }
		}

		#endregion

		#region IComparable Members

		public int CompareTo(object obj)
		{
			Hor�rio b = (Hor�rio) obj;

			if (this < b)
				return -1;

			if (this > b)
				return 1;

			return 0;
		}

		#endregion

		/// <summary>
		/// Verifica se hor�rio compreende um momento.
		/// </summary>
		/// <param name="momento">Momento a ser verificado.</param>
		/// <returns>Se compreende o momento.</returns>
		public bool Compreende(DateTime momento)
		{
			return diaSemana == momento.DayOfWeek
				&& (iniHora < momento.Hour || (iniHora == momento.Hour && iniMinuto <= momento.Minute))
				&& (fimHora > momento.Hour || (fimHora == momento.Hour && fimMinuto >= momento.Minute));
		}

		public override string ToString()
		{
			return string.Format(
				"{0}, {1:00}:{2:00} �s {3:00}:{4:00}",
				TraduzirDiaSemana(diaSemana), iniHora, iniMinuto, FimHora, FimMinuto);
		}

		/// <summary>
		/// Traduz o dia da semana para o portugu�s.
		/// </summary>
		/// <param name="diaSemana">Dia da semana a ser traduzido.</param>
		/// <returns>Tradu��o do dia da semana para o portugu�s.</returns>
		private static string TraduzirDiaSemana(DayOfWeek diaSemana)
		{
			string [] dias = { "Domingo", "Segunda", "Ter�a", "Quarta", "Quinta", "Sexta", "S�bado" };

			return dias[(int) diaSemana];
		}

        /// <summary>
        /// Calcula total de minutos.
        /// </summary>
        /// <returns>Minutos.</returns>
        public uint CalcularMinutos()
        {
            int minutos = (fimHora - iniHora) * 60 + fimMinuto - iniMinuto;

            // Corrige 59 minutos para 1 hora.
            return (uint)(minutos % 60 == 1 ? minutos + 1 : minutos);
        }
	}
}
