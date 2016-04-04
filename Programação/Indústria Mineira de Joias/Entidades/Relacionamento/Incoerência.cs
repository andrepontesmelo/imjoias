using System;
using System.Collections;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Na medida usuário adiciona venda ou retorno, podem surgir incoerências.
	/// O processo custoso de detecção de uma incoerência é feita no método Adicionar() dos respectivos contextos,
	/// após sua chamada assíncrona. Assim que o usuário corrige, o servidor dispara uma ação de Incoerência corrijida,
	/// cujo objeto 'dados' deve ser ser desta classe. 
	/// </summary>
	/// <remarks>
	/// Porquê é associada à referência ?
	///		Porque o usuário relaciona é referência.
	///		(tanto para retorno quanto para venda)
	///		Assim, possibilita-se a tranferência de Incoerência dados de observação.
	/// Porquê é associada à referência Numérica e não formatada ?
	///		Porque trata-se a ref. pose ser inválida, e não não há sentido numa formatação de ref inválida.
	/// </remarks>
	public class Incoerência
	{
		// Atributos
		private string referênciaNumérica;
		private IncoerênciaInfo info;
		private TipoEnum tipo;		

		#region Propriedades
		public string ReferênciaNumérica
		{
			get 
			{
				return referênciaNumérica;
			}
		}

		public IncoerênciaInfo Info
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

		// Enumerações
		public enum TipoEnum
		{ 
			ReferênciaInexistente,
			VendeuOQueNãoLevou,
			RetornouOQueNãoLevou
		}

		/// <param name="tipo">enumeração da Incoerência</param>
		public Incoerência(string referênciaNumérica, TipoEnum tipo)
		{	
			this.info = new IncoerênciaInfo(tipo);
			this.referênciaNumérica = referênciaNumérica;
			this.tipo = tipo;
		}
	}
}
