using System;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Summary description for Incoer�nciaInfo.
	/// </summary>
	public class Incoer�nciaInfo
	{
		string curtaMensagem;
		string descri��o;

		public string CurtaMensagem
		{
			get
			{
				return curtaMensagem;
			}
		}

		public string Descri��o
		{
			get 
			{
				return descri��o;
			}
		}

		public Incoer�nciaInfo(Incoer�ncia.TipoEnum tipo)
		{
			switch (tipo)
			{
				case Incoer�ncia.TipoEnum.Refer�nciaInexistente:
					curtaMensagem = "Ref. n�o existe na empresa";
					descri��o = "zzz";
					break;

				case Incoer�ncia.TipoEnum.RetornouOQueN�oLevou:
					curtaMensagem = "Ref. retornada n�o foi levada";
					descri��o = "zzz";
					break;

				case Incoer�ncia.TipoEnum.VendeuOQueN�oLevou:
					curtaMensagem = "Ref. vendida n�o foi levada";
					descri��o = "zzz";
					break;
			}
		}
	}
}
