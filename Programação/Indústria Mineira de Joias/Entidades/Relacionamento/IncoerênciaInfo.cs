using System;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Summary description for IncoerênciaInfo.
	/// </summary>
	public class IncoerênciaInfo
	{
		string curtaMensagem;
		string descrição;

		public string CurtaMensagem
		{
			get
			{
				return curtaMensagem;
			}
		}

		public string Descrição
		{
			get 
			{
				return descrição;
			}
		}

		public IncoerênciaInfo(Incoerência.TipoEnum tipo)
		{
			switch (tipo)
			{
				case Incoerência.TipoEnum.ReferênciaInexistente:
					curtaMensagem = "Ref. não existe na empresa";
					descrição = "zzz";
					break;

				case Incoerência.TipoEnum.RetornouOQueNãoLevou:
					curtaMensagem = "Ref. retornada não foi levada";
					descrição = "zzz";
					break;

				case Incoerência.TipoEnum.VendeuOQueNãoLevou:
					curtaMensagem = "Ref. vendida não foi levada";
					descrição = "zzz";
					break;
			}
		}
	}
}
