using System;
using System.Data;

namespace Transformador2
{
	/// <summary>
	/// 
	/// Preenchimento do campo 'indice' de tabela 'mercadoria'
	/// </summary>
	/// 
	/* Esquema para se obter o ind�ce: (seguindo orienta��o do hoffman)
	 * 	caso j�ia � peso �nico
			indice = cm_vista
		caso contr�rio
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
					System.Windows.Forms.MessageBox.Show("Erro ao cadastrar Indice de mercadoria '" + itemMercadoria["referencia"].ToString() + "'. O valor padr�o para indice ser� null. Mais informa��es:" + e.Message);
					itemMercadoria["indice"] = DBNull.Value;
					return;
				}
				indiceCorreto = gVista * double.Parse(itemMercadoria["peso"].ToString());
			}
			
			else //n�o � de peso. 
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

		private DataRow ObterItemAntigo(String refer�ncia)
		{
			foreach(DataRow atual in dbf.ds.Tables["cadmer"].Rows)
			{
				if (atual["CM_CODMER"].ToString().Trim().CompareTo(refer�ncia) == 0)
				{
					return atual;
				}
			}

			throw new Exception("Erro na programa��o: a mercadoria " + refer�ncia + " n�o foi encontrada no dbf. Assim, n�o foi poss�vel re-gerar seu indice");

		}
		
		/// <summary>
		/// Ver no inicio coment�rio no inicio da classe para saber para qu� serve.
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
			throw new Exception("N�o foi poss�vel encontrar no gramas.dbf um item com faixa = " + faixa + "  e grupo = " + grupo.ToString());
		}
	}
}
