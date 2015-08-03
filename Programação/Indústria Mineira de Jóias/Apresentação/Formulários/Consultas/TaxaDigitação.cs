using System;

namespace Apresenta��o.Formul�rios.Consultas
{
	/// <summary>
	/// Taxa de digita��o do usu�rio.
	/// </summary>
	class TaxaDigita��o
	{
		private const int tamanho = 5;
		private const int limite  = 2000;					// milissegundo

		/// <summary>
		/// Intervalos de digita��o.
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
		/// Momento do �ltimo registro.
		/// </summary>
		private DateTime �ltimo;

		/// <summary>
		/// Soma de intervalos.
		/// </summary>
		private double soma;

		/// <summary>
		/// Constr�i a taxa de digita��o.
		/// </summary>
		public TaxaDigita��o()
		{
			intervalos = new double[tamanho];
			atual      = 0;
			registros  = 0;
			soma       = 0;
		}

		/// <summary>
		/// Registra um d�gito.
		/// </summary>
		public void Registrar()
		{
			TimeSpan dif = DateTime.Now - �ltimo;

			�ltimo       = DateTime.Now;

			if (dif.TotalMilliseconds >= limite)
			{
                // Usu�rio parou.
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
		/// �ltimo registro de digita��o.
		/// </summary>
		public DateTime �ltimoRegistro
		{
			get { return �ltimo; }
		}

		/// <summary>
		/// N�mero de registros.
		/// </summary>
		public int Registros
		{
			get { return registros; }
		}
	}
}
