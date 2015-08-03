using System;
using System.Data;

namespace Transformador2
{
	/// <summary>
	/// 
	/// Preenchimento do campo 'indice' de tabela 'mercadoria'
	/// </summary>
	/// 
	/* Esquema para se obter o indíce: (seguindo orientação do hoffman)
	 * 	caso jóia é peso único
			indice = cm_vista
		caso contrário
			olho no cadmer a faixa e grupo.
			olho no gramas acho a faixa e grupo da mercadoria.
			preciso do G_VISTA do gramas.
			indice = G_VISTA * peso_especifico_da_joia
*/
	public class Indice
	{
		private Acesso.Dbf dbf;
		private Acesso.MySql mysql;
		
		public Indice(Acesso.Dbf meuDbf, Acesso.MySql meuMySql)
		{
			dbf = meuDbf;
			mysql = meuMySql;

			dbf.AdicionarTabelaAoObterDataSet("gramas");
		}

		public void Transpor()
		{
			foreach(DataRow itemMercadoria in mysql.ds.Tables["mercadoria"].Rows)
			{
				TransporMercadoria(itemMercadoria);
			}
		}

		private void TransporMercadoria(DataRow itemMercadoria)
		{
			DataRow itemMercadoriaAntiga = ObterItemAntigo(itemMercadoria["referencia"].ToString());
			double gVista;
			double indiceCorreto;

			if (ConferirDePeso(itemMercadoria))
			{
				try
				{
					gVista = 
						ObterGVistaDeGramas(itemMercadoria["faixa"].ToString(), int.Parse(itemMercadoria["grupo"].ToString()));
					
				} 
				catch (Exception e)
				{
					System.Windows.Forms.MessageBox.Show("Erro ao cadastrar Indice de mercadoria '" + itemMercadoria["referencia"].ToString() + "'. O valor padrão para indice será null. Mais informações:" + e.Message);
					itemMercadoria["indice"] = DBNull.Value;
					return;
				}
				indiceCorreto = gVista * double.Parse(itemMercadoria["peso"].ToString());
			}
			
			else //não é de peso. 
			{
				indiceCorreto =  double.Parse(itemMercadoriaAntiga["CM_VISTA"].ToString());
			}

			itemMercadoria["indice"] = indiceCorreto;
		}
		private bool ConferirDePeso(DataRow mercadoria)
		{
			if (mercadoria["depeso"].ToString() == "1") 
				return true;
			else
				return false;
		}

		private DataRow ObterItemAntigo(String referência)
		{
			foreach(DataRow atual in dbf.ds.Tables["cadmer"].Rows)
			{
				if (atual["CM_CODMER"].ToString().Trim().CompareTo(referência) == 0)
				{
					return atual;
				}
			}

			throw new Exception("Erro na programação: a mercadoria " + referência + " não foi encontrada no dbf. Assim, não foi possível re-gerar seu indice");

		}
		
		/// <summary>
		/// Ver no inicio comentário no inicio da classe para saber para quê serve.
		/// </summary>
		/// <param name="faixa"></param>
		/// <param name="grupo"></param>
		/// <returns></returns>
		private double ObterGVistaDeGramas(string faixa, int grupo)
		{
			foreach(DataRow atual in dbf.ds.Tables["gramas"].Rows)
			{
				if ((int.Parse(atual["G_GRUPO"].ToString()) == grupo)
					&&
						(atual["G_FAIXA"].ToString().Trim().CompareTo(faixa) == 0))
					{
						return double.Parse(atual["G_VISTA"].ToString());
					}
			}
			throw new Exception("Não foi possível encontrar no gramas.dbf um item com faixa = " + faixa + "  e grupo = " + grupo.ToString());
		}
	}
}
