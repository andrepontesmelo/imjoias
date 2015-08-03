using System;
using System.Collections;
using System.Data;
using System.Xml;

namespace Estat�stica.Db
{
	/// <summary>
	/// Construtor de gr�ficos
	/// </summary>
	public class Gr�fico
	{
		private XmlDocument			defini��es;
		private XmlNamespaceManager nsmgr;

		/// <summary>
		/// Carrega defini��es de um arquivo XML
		/// </summary>
		/// <param name="arquivo">Arquivo contendo defini��es</param>
		public void CarregarDefini��es(string arquivo)
		{
			defini��es = new XmlDocument();
			defini��es.Load(arquivo);

			nsmgr = new XmlNamespaceManager(defini��es.NameTable);
			nsmgr.AddNamespace("grafico", defini��es.DocumentElement.NamespaceURI);
		}

		/// <summary>
		/// Carrega defini��es de uma stream XML
		/// </summary>
		/// <param name="stream">Stream contendo defini��es em XML</param>
		public void CarregarDefini��es(System.IO.Stream stream)
		{
			defini��es = new XmlDocument();
			defini��es.Load(stream);

			nsmgr = new XmlNamespaceManager(defini��es.NameTable);
			nsmgr.AddNamespace("grafico", defini��es.DocumentElement.NamespaceURI);
		}

		/// <summary>
		/// Lista de gr�ficos (refer�ncias)
		/// </summary>
		public string [] Gr�ficos
		{
			get
			{
				string []   refer�ncias;
				int         i;

				XmlNodeList nodos = defini��es.DocumentElement.SelectNodes("grafico:Gr�fico/@refer�ncia", nsmgr);
				
				refer�ncias = new string[nodos.Count];
				i       = 0;

				foreach (XmlNode nodo in nodos)	
					refer�ncias[i++] = nodo.Value;

				return refer�ncias;
			}
		}

		/// <summary>
		/// Obt�m lista de requisitos de um gr�fico
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia do gr�fico</param>
		/// <returns>Lista de requisitos</returns>
		public string [] ObterRequisitos(string refer�ncia)
		{
			string [] requisitos;
			int       i = 0;

			XmlNodeList nodos = defini��es.DocumentElement.SelectNodes("grafico:Gr�fico[@refer�ncia='" + refer�ncia + "']/grafico:Requisito/@entrada", nsmgr);

			requisitos = new string[nodos.Count];

			foreach (XmlNode nodo in nodos)
				requisitos[i++] = nodo.Value;

			return requisitos;
		}

		/// <summary>
		/// Obt�m t�tulo de um gr�fico
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia do gr�fico</param>
		/// <returns>T�tulo do gr�fico</returns>
		public string ObterT�tulo(string refer�ncia)
		{
			XmlNode defini��o;

			defini��o = defini��es.DocumentElement.SelectSingleNode("grafico:Gr�fico[@refer�ncia = '" + refer�ncia + "']", nsmgr);

			return defini��o.Attributes["t�tulo"].Value;
		}

		/// <summary>
		/// Constr�i um gr�fico
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia do gr�fico a ser constru�do</param>
		public void ConfigurarGr�fico(IDbCommand cmd, string refer�ncia, Estat�stica.IDesenhista gr�fico)
		{
			XmlNode		defini��o;
			string []	legendas;
			Hashtable	seq��ncias;
			int			quantidade;
			double [][] dados;
			string []	r�tulosX;

			// Recupera��o das defini��es
			defini��o = defini��es.DocumentElement.SelectSingleNode("grafico:Gr�fico[@refer�ncia = '" + refer�ncia + "']", nsmgr);
			
			// Prepara��o das consultas SQL
			// Obter a quantidade de dados
			quantidade = ObterQuantidade(defini��o["Quantidade"], cmd);

			// Obter as seq��ncias e preparar vetor de dados
			ObterSeq��ncias(defini��o["Seq��ncia"], cmd, out legendas, out seq��ncias, quantidade, out dados);

			// Obter os dados
			if (defini��o["Query"].Attributes["seq��ncia"] == null)
				ObterDados(defini��o["Query"], cmd, dados[0], quantidade, out r�tulosX);
			else
				ObterDados(defini��o["Query"], cmd, seq��ncias, quantidade, out r�tulosX);

			// Construir gr�fico
			ConfigurarGr�fico(gr�fico, defini��o, dados, legendas, r�tulosX);
		}

		/// <summary>
		/// Configura gr�fico desenhista
		/// </summary>
		/// <param name="gr�fico">Desenhista</param>
		/// <param name="defini��o">Nodo da defini��o</param>
		/// <param name="dados">Dados a serem utilizados</param>
		/// <param name="legendas">Legendas</param>
		private void ConfigurarGr�fico(Estat�stica.IDesenhista gr�fico, XmlNode defini��o,
			double [][] dados, string [] legendas,
			string [] r�tulosX)
		{
			gr�fico.EstiloDesenho = (Estat�stica.Estilo) Enum.Parse(typeof(Estat�stica.Estilo), defini��o.Attributes["tipo"].Value, true);
			gr�fico.Dados = dados;
			gr�fico.Legendas = legendas;
			gr�fico.EixoX = defini��o.Attributes["eixoX"] != null ? defini��o.Attributes["eixoX"].Value : null;
			gr�fico.EixoY = defini��o.Attributes["eixoY"] != null ? defini��o.Attributes["eixoY"].Value : null;
			gr�fico.R�tulosX = r�tulosX;
		}

		/// <summary>
		/// Obt�m a quantidade de dados
		/// </summary>
		/// <param name="defQtd">Defini��o da consulta de dados</param>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <returns>Quantidade de dados</returns>
		private int ObterQuantidade(XmlNode defQtd, IDbCommand cmd)
		{
			if (defQtd == null)
				throw new Exce��oDefini��oIncorreta("N�o existe defini��o de quantidade. A TAG <Quantidade> � obrigat�ria!");

			try
			{
				cmd.CommandText = defQtd.InnerText;

				lock (cmd.Connection)
				{
					object obj = cmd.ExecuteScalar();

					return Convert.ToInt32(obj);
				}
			}
			catch
			{
				throw new Exce��oDefini��oIncorreta("N�o foi poss�vel executar a consulta SQL para obten��o de quantidade de dados. Verifique a TAG <Quantidade>.");
			}
		}

		/// <summary>
		/// Obt�m seq��ncias de uma defini��o de gr�fico
		/// </summary>
		/// <param name="defini��o">Defini��o da seq��ncia</param>
		/// <param name="legenda">Legendas</param>
		/// <param name="seq��ncias">Seq��ncias</param>
		/// <param name="quantidade">Quantidade de dados</param>
		private void ObterSeq��ncias(XmlNode defSeq��ncia, IDbCommand cmd, out string [] legendas, out Hashtable seq��ncias, int quantidade, out double [][] dados)
		{
			if (defSeq��ncia == null)
			{
				legendas   = null;
				seq��ncias = null;
				dados	   = new double[1][];
				dados[0]   = new double[quantidade];
			}
			else
			{
				ArrayList lista = new ArrayList();
				IDataReader leitor = null;
				ArrayList lDados = new ArrayList();
				
				seq��ncias = new Hashtable();

				try
				{
					cmd.CommandText = defSeq��ncia.InnerText;

					lock (cmd.Connection)
					{
						leitor = cmd.ExecuteReader();

						while (leitor.Read())
						{
							double [] vetor = new double[quantidade];

							seq��ncias[leitor[0]] = vetor;
							lDados.Add(vetor);
							lista.Add(leitor.GetString(1));
						}
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw new Exce��oDefini��oIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seq��ncia>. Provavelmente n�o est�o sendo recuperadas 2 colunas do banco de dados.");
				}
				catch
				{
					throw new Exce��oDefini��oIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seq��ncia>.");
				}
				finally
				{
					if (leitor != null && !leitor.IsClosed)
						leitor.Close();
				}

				legendas = (string []) lista.ToArray(typeof(string));
				dados = (double [][]) lDados.ToArray(typeof(double []));
			}
		}

		/// <summary>
		/// Obt�m dados com seq��ncia realizando consulta
		/// </summary>
		/// <param name="defQuery">Defini��o da query</param>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <param name="seq��ncias">Tabela de seq��ncias</param>
		/// <param name="r�tulosX">R�tulos do eixo X</param>
		private void ObterDados(XmlNode defQuery, IDbCommand cmd, Hashtable seq��ncias, int quantidade, out string [] r�tulosX)
		{
			IDataReader leitor = null;
			ArrayList lEixoX = new ArrayList();
			Hashtable hEixoX = new Hashtable();

			cmd.CommandText = defQuery.InnerText;

			lock (cmd.Connection)
			{
				try
				{
					int colSeq��ncia, colR�tulosX = 0;

					leitor = cmd.ExecuteReader();

					/* Esta fun��o s� � utilizada para recupera��o de dados
					 * com seq��ncia, logo n�o � necess�rio verificar se o
					 * atributo seq��ncia possui valor atribu�do.
					 */
					colSeq��ncia = leitor.GetOrdinal(defQuery.Attributes["seq��ncia"].Value);
					
					if (defQuery.Attributes["r�tuloX"] != null)
					{
						colR�tulosX = leitor.GetOrdinal(defQuery.Attributes["r�tuloX"].Value);
						r�tulosX = new string[quantidade];
					}
					else
						r�tulosX = null;

					while (leitor.Read())
					{
						double [] seq;
						int x, iColuna;

						// Obter seq��ncia
						seq = (double []) seq��ncias[leitor[colSeq��ncia]];

						if (seq != null)
						{
							x = Convert.ToInt32(leitor[defQuery.Attributes["valorX"].Value]);
							iColuna = leitor.GetOrdinal(defQuery.Attributes["valorY"].Value);

							seq[x] = leitor.GetDouble(iColuna);
						}
						else
							throw new Exce��oDefini��oIncorreta("Seq��ncia n�o encontrada!");

						if (r�tulosX != null)
							r�tulosX[x] = leitor.GetString(colR�tulosX);
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw new Exce��oDefini��oIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Query>. Provavelmente o valorX n�o est� dentro do limite de 0 ao valor retornado pela consulta da TAG <Quantidade> ou a coluna seq��ncia n�o cont�m um valor retornado na consulta da TAG <Seq��ncia>.");
				}
				catch (Exce��oDefini��oIncorreta e)
				{
					throw e;
				}
				catch
				{
					throw new Exce��oDefini��oIncorreta("N�o foi poss�vel recuperar os dados da consulta na TAG <Query>.");
				}
				finally
				{
					if (leitor != null && !leitor.IsClosed)
						leitor.Close();
				}
			}
		}

		/// <summary>
		/// Obt�m dados realizando consulta (sem seq��ncia)
		/// </summary>
		/// <param name="defQuery">Defini��o da query</param>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <param name="vetor">Vetor de dados</param>
		/// <param name="r�tulosX">R�tulos do eixo X</param>
		private void ObterDados(XmlNode defQuery, IDbCommand cmd, double [] vetor, int quantidade, out string [] r�tulosX)
		{
			IDataReader leitor = null;
			ArrayList lEixoX = new ArrayList();
			Hashtable hEixoX = new Hashtable();

			cmd.CommandText = defQuery.InnerText;

			lock (cmd.Connection)
			{
				try
				{
					int colR�tulosX = 0;

					leitor = cmd.ExecuteReader();

					if (defQuery.Attributes["r�tuloX"] != null)
					{
						colR�tulosX = leitor.GetOrdinal(defQuery.Attributes["r�tuloX"].Value);
						r�tulosX    = new string[quantidade];
					}
					else
						r�tulosX = null;

					while (leitor.Read())
					{
						int x, iColuna;

						x = Convert.ToInt32(leitor[defQuery.Attributes["valorX"].Value]);
						iColuna = leitor.GetOrdinal(defQuery.Attributes["valorY"].Value);

						vetor[x] = leitor.GetDouble(iColuna);

						if (r�tulosX != null)
							r�tulosX[x] = leitor.GetString(colR�tulosX);
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw new Exce��oDefini��oIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Query>. Provavelmente o valorX n�o est� dentro do limite de 0 ao valor retornado pela consulta da TAG <Quantidade>.");
				}
				catch
				{
					throw new Exce��oDefini��oIncorreta("N�o foi poss�vel recuperar os dados da consulta na TAG <Query>.");
				}
				finally
				{
					if (leitor != null && !leitor.IsClosed)
						leitor.Close();
				}
			}
		}

		/// <summary>
		/// Obt�m legendas para um gr�fico espec�fico
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia do gr�fico</param>
		/// <returns>Legendas</returns>
		public string [] ObterLegendas(IDbCommand cmd, string refer�ncia)
		{
			XmlNode		defSeq��ncia;

			defSeq��ncia = defini��es.DocumentElement.SelectSingleNode("grafico:Gr�fico[@refer�ncia = '" + refer�ncia + "']/grafico:Seq��ncia", nsmgr);

			if (defSeq��ncia == null)
				return null;

			ArrayList lista = new ArrayList();
			IDataReader leitor = null;
				
			try
			{
				cmd.CommandText = defSeq��ncia.InnerText;

				lock (cmd.Connection)
				{
					leitor = cmd.ExecuteReader();

					while (leitor.Read())
						lista.Add(leitor.GetString(1));
				}
			}
			catch (IndexOutOfRangeException)
			{
				throw new Exce��oDefini��oIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seq��ncia>. Provavelmente n�o est�o sendo recuperadas 2 colunas do banco de dados.");
			}
			catch
			{
				throw new Exce��oDefini��oIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seq��ncia>.");
			}
			finally
			{
				if (leitor != null && !leitor.IsClosed)
					leitor.Close();
			}

			return (string []) lista.ToArray(typeof(string));
		}
	}
}
