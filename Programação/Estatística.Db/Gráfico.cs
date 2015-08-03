using System;
using System.Collections;
using System.Data;
using System.Xml;

namespace Estatística.Db
{
	/// <summary>
	/// Construtor de gráficos
	/// </summary>
	public class Gráfico
	{
		private XmlDocument			definições;
		private XmlNamespaceManager nsmgr;

		/// <summary>
		/// Carrega definições de um arquivo XML
		/// </summary>
		/// <param name="arquivo">Arquivo contendo definições</param>
		public void CarregarDefinições(string arquivo)
		{
			definições = new XmlDocument();
			definições.Load(arquivo);

			nsmgr = new XmlNamespaceManager(definições.NameTable);
			nsmgr.AddNamespace("grafico", definições.DocumentElement.NamespaceURI);
		}

		/// <summary>
		/// Carrega definições de uma stream XML
		/// </summary>
		/// <param name="stream">Stream contendo definições em XML</param>
		public void CarregarDefinições(System.IO.Stream stream)
		{
			definições = new XmlDocument();
			definições.Load(stream);

			nsmgr = new XmlNamespaceManager(definições.NameTable);
			nsmgr.AddNamespace("grafico", definições.DocumentElement.NamespaceURI);
		}

		/// <summary>
		/// Lista de gráficos (referências)
		/// </summary>
		public string [] Gráficos
		{
			get
			{
				string []   referências;
				int         i;

				XmlNodeList nodos = definições.DocumentElement.SelectNodes("grafico:Gráfico/@referência", nsmgr);
				
				referências = new string[nodos.Count];
				i       = 0;

				foreach (XmlNode nodo in nodos)	
					referências[i++] = nodo.Value;

				return referências;
			}
		}

		/// <summary>
		/// Obtém lista de requisitos de um gráfico
		/// </summary>
		/// <param name="referência">Referência do gráfico</param>
		/// <returns>Lista de requisitos</returns>
		public string [] ObterRequisitos(string referência)
		{
			string [] requisitos;
			int       i = 0;

			XmlNodeList nodos = definições.DocumentElement.SelectNodes("grafico:Gráfico[@referência='" + referência + "']/grafico:Requisito/@entrada", nsmgr);

			requisitos = new string[nodos.Count];

			foreach (XmlNode nodo in nodos)
				requisitos[i++] = nodo.Value;

			return requisitos;
		}

		/// <summary>
		/// Obtém título de um gráfico
		/// </summary>
		/// <param name="referência">Referência do gráfico</param>
		/// <returns>Título do gráfico</returns>
		public string ObterTítulo(string referência)
		{
			XmlNode definição;

			definição = definições.DocumentElement.SelectSingleNode("grafico:Gráfico[@referência = '" + referência + "']", nsmgr);

			return definição.Attributes["título"].Value;
		}

		/// <summary>
		/// Constrói um gráfico
		/// </summary>
		/// <param name="referência">Referência do gráfico a ser construído</param>
		public void ConfigurarGráfico(IDbCommand cmd, string referência, Estatística.IDesenhista gráfico)
		{
			XmlNode		definição;
			string []	legendas;
			Hashtable	seqüências;
			int			quantidade;
			double [][] dados;
			string []	rótulosX;

			// Recuperação das definições
			definição = definições.DocumentElement.SelectSingleNode("grafico:Gráfico[@referência = '" + referência + "']", nsmgr);
			
			// Preparação das consultas SQL
			// Obter a quantidade de dados
			quantidade = ObterQuantidade(definição["Quantidade"], cmd);

			// Obter as seqüências e preparar vetor de dados
			ObterSeqüências(definição["Seqüência"], cmd, out legendas, out seqüências, quantidade, out dados);

			// Obter os dados
			if (definição["Query"].Attributes["seqüência"] == null)
				ObterDados(definição["Query"], cmd, dados[0], quantidade, out rótulosX);
			else
				ObterDados(definição["Query"], cmd, seqüências, quantidade, out rótulosX);

			// Construir gráfico
			ConfigurarGráfico(gráfico, definição, dados, legendas, rótulosX);
		}

		/// <summary>
		/// Configura gráfico desenhista
		/// </summary>
		/// <param name="gráfico">Desenhista</param>
		/// <param name="definição">Nodo da definição</param>
		/// <param name="dados">Dados a serem utilizados</param>
		/// <param name="legendas">Legendas</param>
		private void ConfigurarGráfico(Estatística.IDesenhista gráfico, XmlNode definição,
			double [][] dados, string [] legendas,
			string [] rótulosX)
		{
			gráfico.EstiloDesenho = (Estatística.Estilo) Enum.Parse(typeof(Estatística.Estilo), definição.Attributes["tipo"].Value, true);
			gráfico.Dados = dados;
			gráfico.Legendas = legendas;
			gráfico.EixoX = definição.Attributes["eixoX"] != null ? definição.Attributes["eixoX"].Value : null;
			gráfico.EixoY = definição.Attributes["eixoY"] != null ? definição.Attributes["eixoY"].Value : null;
			gráfico.RótulosX = rótulosX;
		}

		/// <summary>
		/// Obtém a quantidade de dados
		/// </summary>
		/// <param name="defQtd">Definição da consulta de dados</param>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <returns>Quantidade de dados</returns>
		private int ObterQuantidade(XmlNode defQtd, IDbCommand cmd)
		{
			if (defQtd == null)
				throw new ExceçãoDefiniçãoIncorreta("Não existe definição de quantidade. A TAG <Quantidade> é obrigatória!");

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
				throw new ExceçãoDefiniçãoIncorreta("Não foi possível executar a consulta SQL para obtenção de quantidade de dados. Verifique a TAG <Quantidade>.");
			}
		}

		/// <summary>
		/// Obtém seqüências de uma definição de gráfico
		/// </summary>
		/// <param name="definição">Definição da seqüência</param>
		/// <param name="legenda">Legendas</param>
		/// <param name="seqüências">Seqüências</param>
		/// <param name="quantidade">Quantidade de dados</param>
		private void ObterSeqüências(XmlNode defSeqüência, IDbCommand cmd, out string [] legendas, out Hashtable seqüências, int quantidade, out double [][] dados)
		{
			if (defSeqüência == null)
			{
				legendas   = null;
				seqüências = null;
				dados	   = new double[1][];
				dados[0]   = new double[quantidade];
			}
			else
			{
				ArrayList lista = new ArrayList();
				IDataReader leitor = null;
				ArrayList lDados = new ArrayList();
				
				seqüências = new Hashtable();

				try
				{
					cmd.CommandText = defSeqüência.InnerText;

					lock (cmd.Connection)
					{
						leitor = cmd.ExecuteReader();

						while (leitor.Read())
						{
							double [] vetor = new double[quantidade];

							seqüências[leitor[0]] = vetor;
							lDados.Add(vetor);
							lista.Add(leitor.GetString(1));
						}
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw new ExceçãoDefiniçãoIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seqüência>. Provavelmente não estão sendo recuperadas 2 colunas do banco de dados.");
				}
				catch
				{
					throw new ExceçãoDefiniçãoIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seqüência>.");
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
		/// Obtém dados com seqüência realizando consulta
		/// </summary>
		/// <param name="defQuery">Definição da query</param>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <param name="seqüências">Tabela de seqüências</param>
		/// <param name="rótulosX">Rótulos do eixo X</param>
		private void ObterDados(XmlNode defQuery, IDbCommand cmd, Hashtable seqüências, int quantidade, out string [] rótulosX)
		{
			IDataReader leitor = null;
			ArrayList lEixoX = new ArrayList();
			Hashtable hEixoX = new Hashtable();

			cmd.CommandText = defQuery.InnerText;

			lock (cmd.Connection)
			{
				try
				{
					int colSeqüência, colRótulosX = 0;

					leitor = cmd.ExecuteReader();

					/* Esta função só é utilizada para recuperação de dados
					 * com seqüência, logo não é necessário verificar se o
					 * atributo seqüência possui valor atribuído.
					 */
					colSeqüência = leitor.GetOrdinal(defQuery.Attributes["seqüência"].Value);
					
					if (defQuery.Attributes["rótuloX"] != null)
					{
						colRótulosX = leitor.GetOrdinal(defQuery.Attributes["rótuloX"].Value);
						rótulosX = new string[quantidade];
					}
					else
						rótulosX = null;

					while (leitor.Read())
					{
						double [] seq;
						int x, iColuna;

						// Obter seqüência
						seq = (double []) seqüências[leitor[colSeqüência]];

						if (seq != null)
						{
							x = Convert.ToInt32(leitor[defQuery.Attributes["valorX"].Value]);
							iColuna = leitor.GetOrdinal(defQuery.Attributes["valorY"].Value);

							seq[x] = leitor.GetDouble(iColuna);
						}
						else
							throw new ExceçãoDefiniçãoIncorreta("Seqüência não encontrada!");

						if (rótulosX != null)
							rótulosX[x] = leitor.GetString(colRótulosX);
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw new ExceçãoDefiniçãoIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Query>. Provavelmente o valorX não está dentro do limite de 0 ao valor retornado pela consulta da TAG <Quantidade> ou a coluna seqüência não contém um valor retornado na consulta da TAG <Seqüência>.");
				}
				catch (ExceçãoDefiniçãoIncorreta e)
				{
					throw e;
				}
				catch
				{
					throw new ExceçãoDefiniçãoIncorreta("Não foi possível recuperar os dados da consulta na TAG <Query>.");
				}
				finally
				{
					if (leitor != null && !leitor.IsClosed)
						leitor.Close();
				}
			}
		}

		/// <summary>
		/// Obtém dados realizando consulta (sem seqüência)
		/// </summary>
		/// <param name="defQuery">Definição da query</param>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <param name="vetor">Vetor de dados</param>
		/// <param name="rótulosX">Rótulos do eixo X</param>
		private void ObterDados(XmlNode defQuery, IDbCommand cmd, double [] vetor, int quantidade, out string [] rótulosX)
		{
			IDataReader leitor = null;
			ArrayList lEixoX = new ArrayList();
			Hashtable hEixoX = new Hashtable();

			cmd.CommandText = defQuery.InnerText;

			lock (cmd.Connection)
			{
				try
				{
					int colRótulosX = 0;

					leitor = cmd.ExecuteReader();

					if (defQuery.Attributes["rótuloX"] != null)
					{
						colRótulosX = leitor.GetOrdinal(defQuery.Attributes["rótuloX"].Value);
						rótulosX    = new string[quantidade];
					}
					else
						rótulosX = null;

					while (leitor.Read())
					{
						int x, iColuna;

						x = Convert.ToInt32(leitor[defQuery.Attributes["valorX"].Value]);
						iColuna = leitor.GetOrdinal(defQuery.Attributes["valorY"].Value);

						vetor[x] = leitor.GetDouble(iColuna);

						if (rótulosX != null)
							rótulosX[x] = leitor.GetString(colRótulosX);
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw new ExceçãoDefiniçãoIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Query>. Provavelmente o valorX não está dentro do limite de 0 ao valor retornado pela consulta da TAG <Quantidade>.");
				}
				catch
				{
					throw new ExceçãoDefiniçãoIncorreta("Não foi possível recuperar os dados da consulta na TAG <Query>.");
				}
				finally
				{
					if (leitor != null && !leitor.IsClosed)
						leitor.Close();
				}
			}
		}

		/// <summary>
		/// Obtém legendas para um gráfico específico
		/// </summary>
		/// <param name="referência">Referência do gráfico</param>
		/// <returns>Legendas</returns>
		public string [] ObterLegendas(IDbCommand cmd, string referência)
		{
			XmlNode		defSeqüência;

			defSeqüência = definições.DocumentElement.SelectSingleNode("grafico:Gráfico[@referência = '" + referência + "']/grafico:Seqüência", nsmgr);

			if (defSeqüência == null)
				return null;

			ArrayList lista = new ArrayList();
			IDataReader leitor = null;
				
			try
			{
				cmd.CommandText = defSeqüência.InnerText;

				lock (cmd.Connection)
				{
					leitor = cmd.ExecuteReader();

					while (leitor.Read())
						lista.Add(leitor.GetString(1));
				}
			}
			catch (IndexOutOfRangeException)
			{
				throw new ExceçãoDefiniçãoIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seqüência>. Provavelmente não estão sendo recuperadas 2 colunas do banco de dados.");
			}
			catch
			{
				throw new ExceçãoDefiniçãoIncorreta("Ocorreu um erro recuperando os dados da consulta na TAG <Seqüência>.");
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
