using System;
using System.Collections;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Na medida usu�rio adiciona venda ou retorno, podem surgir incoer�ncias.
	/// O processo custoso de detec��o de uma incoer�ncia � feita no m�todo Adicionar() dos respectivos contextos,
	/// ap�s sua chamada ass�ncrona. Assim que o usu�rio corrige, o servidor dispara uma a��o de Incoer�ncia corrijida,
	/// cujo objeto 'dados' deve ser ser desta classe. 
	/// </summary>
	/// <remarks>
	/// Porqu� � associada � refer�ncia ?
	///		Porque o usu�rio relaciona � refer�ncia.
	///		(tanto para retorno quanto para venda)
	///		Assim, possibilita-se a tranfer�ncia de Incoer�ncia dados de observa��o.
	/// Porqu� � associada � refer�ncia Num�rica e n�o formatada ?
	///		Porque trata-se a ref. pose ser inv�lida, e n�o n�o h� sentido numa formata��o de ref inv�lida.
	/// </remarks>
	public class Incoer�ncia
	{
		// Atributos
		private string refer�nciaNum�rica;
		private Incoer�nciaInfo info;
		private TipoEnum tipo;		

		#region Propriedades
		public string Refer�nciaNum�rica
		{
			get 
			{
				return refer�nciaNum�rica;
			}
		}

		public Incoer�nciaInfo Info
		{
			get
			{
				return info;
			}
		}

		public TipoEnum Tipo
		{
			get
			{
				return tipo;
			}
		}

		#endregion

		// Enumera��es
		public enum TipoEnum
		{ 
			Refer�nciaInexistente,
			VendeuOQueN�oLevou,
			RetornouOQueN�oLevou
		}

		/// <param name="tipo">enumera��o da Incoer�ncia</param>
		public Incoer�ncia(string refer�nciaNum�rica, TipoEnum tipo)
		{	
			this.info = new Incoer�nciaInfo(tipo);
			this.refer�nciaNum�rica = refer�nciaNum�rica;
			this.tipo = tipo;
		}
	}
}
