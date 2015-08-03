using System;

namespace Transformador2.Entidades.Antigo
{

	public class ComponenteCusto
	{
		public ComponenteCusto()
		{}


/*		public static ArrayList ObterComponenteCustos(Acesso.Dbf dbf)
		{
			ArrayList lista;
			ComponenteCusto ccAtual;

			double dolarDouble=0;

			dbf.cmd.CommandText = "select CC_COD,CC_nome,CC_data,CC_valor,CC_dolar from ccusto";
			dbf.leitor = dbf.cmd.ExecuteReader();
			while ( dbf.leitor.Read() ) 
			{
					novo.InserirComponenteDeCusto(leitor.GetString(0),leitor.GetString(1));
					dolarDouble = leitor.GetDouble(4);

					//Se é dolar ou se o preço não está em dolar
					if ((leitor.GetString(0).Trim() == "10") || (dolarDouble ==0) )
						novo.InserirValorComponenteDeCusto(leitor.GetString(0),leitor.GetDateTime(2),leitor.GetDouble(3),"");
					else 
						//Caso do preço estar em dolar.
						novo.InserirValorComponenteDeCusto(leitor.GetString(0),leitor.GetDateTime(2),dolarDouble,"10");
					pb.Value+=1;


			}
			leitor.Close();
			

		}

		public static ComponenteCusto ObterComponenteCusto(ByteFX.Data.MySqlClient.MySqlDataReader leitor)
		{
			ComponenteCusto novo;
			//dbf.cmd.CommandText = "select CC_COD,CC_nome,CC_data,CC_valor,CC_dolar from ccusto";
			
			novo = new ComponenteCusto();
			

		}
		*/
	}
}
