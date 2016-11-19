using System;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{
	/// <summary>
	/// Apenas serve para vericar consistencia
	/// e evitar erro de chave estrangeira
	/// </summary>
	public class Faixas
	{
		public static bool ExiteFaixa(string faixa, DataSet dsNovo)
		{
			foreach(DataRow itemMySql in dsNovo.Tables["faixa"].Rows)
			{
				if (itemMySql["faixa"].ToString().ToUpper().CompareTo(faixa.ToUpper()) == 0)
					return true;
			}
			
			return false;
		}
	}
}
