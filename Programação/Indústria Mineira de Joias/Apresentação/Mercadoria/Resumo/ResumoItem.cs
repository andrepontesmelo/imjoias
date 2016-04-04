using System;

namespace Apresentação.Mercadoria.Resumo
{
	/// <summary>
	/// Entidade usada para computar o resumo. 
	/// Ver comentários no controle resumo.
	/// </summary>
	public class ResumoItem
	{
		string faixa;
		double quantidade, peso, índice;

		public double Quantidade
		{
			get { return quantidade; }
		}
		public double Peso
		{ 
			get { return peso; }
		}
		public double Índice
		{
			get { return índice; } 
		}
		public string Faixa
		{
			get { return faixa; } 
		}
	

		public ResumoItem(double quantidade, double peso, double índice, string faixa)
		{
			this.quantidade = quantidade; 
			this.peso = peso;
			this.índice = índice;
			this.faixa = faixa;
		}

		public void Acrescentar(double quantidade, double peso, double índice)
		{
			this.quantidade += quantidade;
			this.peso += peso;
			this.índice += índice;
		}

	}
}
