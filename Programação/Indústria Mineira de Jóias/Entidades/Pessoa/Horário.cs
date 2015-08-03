using System;
using Acesso.Comum;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Horário de trabalho.
	/// </summary>
	[DbTabela("horariofuncionario"), Serializable]
	public class Horário : DbManipulaçãoAutomática, IComparable
	{
		/// <summary>
		/// Funcionáio.
		/// </summary>
		[DbRelacionamento(true, "codigo", "funcionario")]
		private Funcionário funcionario;

		/// <summary>
		/// Dia de semana.
		/// </summary>
		[DbChavePrimária(false)]
		private DayOfWeek diaSemana;

		/// <summary>
		/// Hora inicial do dia.
		/// </summary>
		[DbChavePrimária(false)]
		private ushort iniHora;

		/// <summary>
		/// Minuto da hora inicial.
		/// </summary>
		[DbChavePrimária(false)]
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
		/// Constrói o horário vazio.
		/// </summary>
		public Horário() {}

		/// <summary>
		/// Constrói o horário para um funcionário específico.
		/// </summary>
		/// <param name="funcionário">Funcionário.</param>
		public Horário(Funcionário funcionário)
		{
            if (funcionário == null)
                throw new ArgumentNullException();

			this.funcionario = funcionário;
		}

		/// <summary>
		/// Constrói um horário.
		/// </summary>
		public Horário(Entidades.Pessoa.Funcionário funcionário, DayOfWeek diaSemana, ushort iniHora, ushort iniMinuto, ushort fimHora, ushort fimMinuto)
		{
			this.funcionario = funcionário;
			this.diaSemana   = diaSemana;
			this.iniHora     = iniHora;
			this.iniMinuto   = iniMinuto;
			this.fimHora     = fimHora;
			this.fimMinuto   = fimMinuto;
		}

        /// <summary>
        /// Constrói um horário já cadastrado.
        /// </summary>
        internal static Horário CriarHorárioCadastrado(Entidades.Pessoa.Funcionário funcionário, DayOfWeek diaSemana, ushort iniHora, ushort iniMinuto, ushort fimHora, ushort fimMinuto)
        {
            Horário horário = new Horário(funcionário, diaSemana, iniHora, iniMinuto, fimHora, fimMinuto);

            horário.DefinirCadastrado();
            horário.DefinirAtualizado();

            return horário;
        }

		#region Operadores de comparação

		public static bool operator < (Horário a, Horário b)
		{
			return (a.diaSemana < b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora < b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto < b.iniMinuto)));
		}

		public static bool operator <= (Horário a, Horário b)
		{
			return (a.diaSemana < b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora < b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto <= b.iniMinuto)));
		}

		public static bool operator > (Horário a, Horário b)
		{
			return (a.diaSemana > b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora > b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto > b.iniMinuto)));
		}

		public static bool operator >= (Horário a, Horário b)
		{
			return (a.diaSemana > b.diaSemana) || (a.diaSemana == b.diaSemana && ((a.iniHora > b.iniHora) || (a.iniHora == b.iniHora && a.iniMinuto >= b.iniMinuto)));
		}

		// --- DateTime ---

		public static bool operator < (Horário a, DateTime b)
		{
			return (a.diaSemana < b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora < b.Hour) || (a.iniHora == b.Hour && a.iniMinuto < b.Minute)));
		}

		public static bool operator <= (Horário a, DateTime b)
		{
			return (a.diaSemana < b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora < b.Hour) || (a.iniHora == b.Hour && a.iniMinuto <= b.Minute)));
		}

		public static bool operator > (Horário a, DateTime b)
		{
			return (a.diaSemana > b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora > b.Hour) || (a.iniHora == b.Hour && a.iniMinuto > b.Minute)));
		}

		public static bool operator >= (Horário a, DateTime b)
		{
			return (a.diaSemana > b.DayOfWeek) || (a.diaSemana == b.DayOfWeek && ((a.iniHora > b.Hour) || (a.iniHora == b.Hour && a.iniMinuto >= b.Minute)));
		}

		#endregion

		#region Propriedades

		/// <summary>
		/// Funcionário relacionado.
		/// </summary>
		public Funcionário Funcionário
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
			Horário b = (Horário) obj;

			if (this < b)
				return -1;

			if (this > b)
				return 1;

			return 0;
		}

		#endregion

		/// <summary>
		/// Verifica se horário compreende um momento.
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
				"{0}, {1:00}:{2:00} às {3:00}:{4:00}",
				TraduzirDiaSemana(diaSemana), iniHora, iniMinuto, FimHora, FimMinuto);
		}

		/// <summary>
		/// Traduz o dia da semana para o português.
		/// </summary>
		/// <param name="diaSemana">Dia da semana a ser traduzido.</param>
		/// <returns>Tradução do dia da semana para o português.</returns>
		private static string TraduzirDiaSemana(DayOfWeek diaSemana)
		{
			string [] dias = { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" };

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
