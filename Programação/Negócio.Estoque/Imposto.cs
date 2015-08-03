using System;

namespace Negócio.Estoque
{
	/// <summary>
	/// Imposto sobre mercadorias
	/// </summary>
	public class Imposto
	{
		private string	nome;
		private double	valor;
		private bool	acrescentar;

		/// <summary>
		/// Constrói um novo imposto
		/// </summary>
		/// <param name="nome">Nome do imposto</param>
		/// <param name="valor">Valor em % do imposto</param>
		/// <param name="acrescentar">Se deve acrescentar ao valor da mercadoria</param>
		public Imposto(string nome, double valor, bool acrescentar)
		{
			this.nome = nome;
			this.valor = valor;
			this.acrescentar = acrescentar;
		}

		/// <summary>
		/// Calcula o valor do imposto sobre um determinado
		/// valor de mercadoria
		/// </summary>
		/// <param name="valor">Valor da mercadoria</param>
		/// <returns>Valor do imposto sobre a mercadoria</returns>
		public double CalcularImposto(double valor)
		{
			return checked(valor * this.valor);
		}

		/// <summary>
		/// Acrescenta o valor do imposto no
		/// preço da mercadoria
		/// </summary>
		/// <param name="valor">Valor da mercadoria</param>
		/// <returns>Valor da mercadoria com o imposto agregado</returns>
		public double AcrescentarImposto(ref double valor)
		{
			if (!acrescentar)
				throw new ExceçãoImpostoNãoAgregável(this);

			return checked(valor + CalcularImposto(valor));
		}

		/// <summary>
		/// Nome do imposto.
		/// </summary>
		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		/// <summary>
		/// Valor do imposto (em porcentagem)
		/// </summary>
		/// <example>15 (% implícito)</example>
		public double Valor
		{
			get { return valor * 100; }
			set { valor = value / 100; }
		}

		/// <summary>
		/// Se deve ser acrescido ao preço de venda
		/// da mercadoria.
		/// </summary>
		public bool Acrescentar
		{
			get { return acrescentar; }
			set { acrescentar = value; }
		}
	}
}
