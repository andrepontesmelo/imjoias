using System;

namespace Apresentação.Formulários.Consultas
{
	/// <summary>
	/// Taxa de digitação do usuário.
	/// </summary>
	class TaxaDigitação
	{
		private const int tamanho = 5;
		private const int limite  = 2000;					// milissegundo

		/// <summary>
		/// Intervalos de digitação.
		/// </summary>
		private double []   intervalos;

		/// <summary>
		/// Registro atual.
		/// </summary>
		private int      atual;

		/// <summary>
		/// Registros utilizados.
		/// </summary>
		private int registros;

		/// <summary>
		/// Momento do último registro.
		/// </summary>
		private DateTime último;

		/// <summary>
		/// Soma de intervalos.
		/// </summary>
		private double soma;

		/// <summary>
		/// Constrói a taxa de digitação.
		/// </summary>
		public TaxaDigitação()
		{
			intervalos = new double[tamanho];
			atual      = 0;
			registros  = 0;
			soma       = 0;
		}

		/// <summary>
		/// Registra um dígito.
		/// </summary>
		public void Registrar()
		{
			TimeSpan dif = DateTime.Now - último;

			último       = DateTime.Now;

			if (dif.TotalMilliseconds >= limite)
			{
                // Usuário parou.
				atual     = 0;
				registros = 0;
				soma      = 0;
			}
			else
			{
				atual = (atual + 1) % tamanho;

				if (registros++ >= tamanho)
					soma -= intervalos[atual];

				intervalos[atual] = dif.TotalMilliseconds;

				soma += dif.TotalMilliseconds;
			}
		}

		/// <summary>
		/// Calcula intervalo entre teclas.
		/// </summary>
		/// <returns>Intervalo em milissegundos.</returns>
		public double CalcularIntervalo()
		{
			return registros >= 2 ? soma / Math.Min(tamanho, registros) : double.PositiveInfinity;
		}

		/// <summary>
		/// Último registro de digitação.
		/// </summary>
		public DateTime ÚltimoRegistro
		{
			get { return último; }
		}

		/// <summary>
		/// Número de registros.
		/// </summary>
		public int Registros
		{
			get { return registros; }
		}
	}
}
