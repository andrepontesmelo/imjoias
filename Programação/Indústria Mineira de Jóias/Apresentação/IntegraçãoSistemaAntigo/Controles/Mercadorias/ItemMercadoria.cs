using System;
using System.Data;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{
	/// <summary>
	/// Summary description for ItemMercadoria.
	/// </summary>
	public class ItemMercadoria
	{
		private bool novo;
		private DataRow dataRow;

		/// <summary>
		/// Entende-se por novo que a mercadoria esta presente apenas
		/// no DBF, e ainda nao foi adentrado ao sistema.
		/// Portanto, nao se trata de uma modifica��o.
		/// </summary>
		public bool Novo
		{
			get
			{ return novo; }
		}

		public DataRow DataRow
		{
			get { return dataRow; }
		}

		public ItemMercadoria(DataRow dataRow, bool novo)
		{
			this.dataRow = dataRow;
			this.novo = novo;
		}
	}
}
