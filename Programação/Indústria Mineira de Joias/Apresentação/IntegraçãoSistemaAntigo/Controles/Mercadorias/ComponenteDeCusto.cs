using System;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{
	public class ComponenteDeCusto
	{
		private DataSet		dsVelho;
		private DataSet		dsNovo;
		private Dbf	dbf;
        private double valorDólar; 
        		
		public ComponenteDeCusto(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
			dbf = dbfOrigem;
			dsVelho = dataSetVelho;
			dsNovo = dataSetNovo;
		}

        private DataRow ObterItemNovoEquivalalenteAoAntigo(DataRow antigo)
        {
            DataRow novo;

            foreach (DataRow itemMySql in dsNovo.Tables["componentecusto"].Rows)
            {
                if (itemMySql["codigo"].ToString().CompareTo(antigo["CC_COD"].ToString()) == 0)
                    return itemMySql;
            }

            novo = dsNovo.Tables["componentecusto"].NewRow();
            novo["codigo"] = antigo["CC_COD"];
            dsNovo.Tables["componentecusto"].Rows.Add(novo);

            return novo;
        }

		private void TransporItem(DataRow itemAtual)
		{
			DataRow novoItem;

			novoItem = ObterItemNovoEquivalalenteAoAntigo(itemAtual);
			novoItem["nome"] = itemAtual["CC_NOME"];
            novoItem["valor"] = itemAtual["CC_VALOR"];
            novoItem["multiplicarcomponentecusto"] = null;

            bool transpondoDólar = itemAtual["CC_COD"].ToString() == "10";

            if (transpondoDólar)
				valorDólar = Double.Parse(itemAtual["CC_VALOR"].ToString());
			else 
			{
                bool itemCotadoEmDólar = ObterValorEmDolar(itemAtual) != 0;

				if (itemCotadoEmDólar)
                    TransporComponenteCotadoEmDólar(itemAtual, novoItem);
			}
		}

        private static void TransporComponenteCotadoEmDólar(DataRow itemAtual, DataRow novoItem)
        {
            novoItem["valor"] = itemAtual["CC_DOLAR"];
            novoItem["multiplicarcomponentecusto"] = "10";
        }
		
		public void Transpor()
		{
			foreach(DataRow itemAtual in dsVelho.Tables["ccusto"].Rows)
			    TransporItem(itemAtual);
		}

		private static double ObterValorEmDolar(DataRow antigo)
		{
			return Double.Parse(antigo["CC_DOLAR"].ToString());
		}
	}
}
