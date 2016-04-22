using System;

namespace Apresenta��o.Mercadoria.Resumo
{
	/// <summary>
	/// Entidade usada para computar o resumo. 
	/// Ver coment�rios no controle resumo.
	/// </summary>
	public class ResumoItem
	{
		string faixa;
		double quantidade, peso, �ndice;

		public double Quantidade
		{
			get { return quantidade; }
		}
		public double Peso
		{ 
			get { return peso; }
		}
		public double �ndice
		{
			get { return �ndice; } 
		}
		public string Faixa
		{
			get { return faixa; } 
		}
	

		public ResumoItem(double quantidade, double peso, double �ndice, string faixa)
		{
			this.quantidade = quantidade; 
			this.peso = peso;
			this.�ndice = �ndice;
			this.faixa = faixa;
		}

		public void Acrescentar(double quantidade, double peso, double �ndice)
		{
			this.quantidade += quantidade;
			this.peso += peso;
			this.�ndice += �ndice;
		}

	}
}
