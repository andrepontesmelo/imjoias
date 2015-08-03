using System;
using System.Data;
using System.Collections;
using Acesso.Comum;
using Entidades.Venda;
using Entidades.Relacionamento;

namespace Entidades.Pedido
{
	/// <summary>
	/// Um pedido � uma monitora��o de mercadorias que foram relacionadas para alguem.
	/// N�o existe um hist�rico de quando que a mercadoria saiu ou entrou na firma.
	/// Mas sim o n�mero de quantas mercadorias j� sairam, e quantas j� retornaram.
	/// 
	/// O pedido pode ser relacionado para
	///		- um cliente de atacado
	///		- um cliente de auto-atacado
	///		- um funcion�rio representante
	///		
	/// Todo contexto pedido possui uma entidade pedido correspondente.
	/// 
	/// Todo: Documentar serializa��o
	/// </summary>
	[Serializable]
	public class Pedido : Relacionamento.Relacionamento
	{
		// Atributos
		private DateTime			dataAbertura;
		private DateTime			dataAcerto;
		private double				valorMinimoVenda;
		private double				cotacao;
		private	DateTime			ultimaImpressaoData;
		private bool				acertado;			// Explica��o em PedidoBaseInferior.
		private bool				fechado;
		
		[DbRelacionamento("codigo", "ultimaImpressaoFuncionario")]
		private Pessoa.Funcion�rio	ultimaImpressaoFuncionario;
		
//		[DbAtributo(TipoAtributo.Ignorar)]
//		private Cole��oItemPedido	itens = null;

        [DbRelacionamento("codigo", "pessoa")]
        protected Pessoa.Pessoa pessoa;

		#region Propriedades 

		//		/// <summary>
		//		/// Obtem a lista de ItemRetorno.
		//		/// Obt�m no banco de dados apenas na primeira vez que solicitado.
		//		/// 
		//		/// � solicitado pelo Acerto() do contexto Pedidos.
		//		/// </summary>
		//		public ItemRetorno [] ItensRetorno
		//		{
		//			get
		//			{
		//				if (itensRetorno == null)
		//				{
		//					itensRetorno = Entidades.Pedido.ItemRetorno.ObterItensRetorno(codigo);
		//#if DEBUG
		//					if (itensRetorno == null)
		//						throw new Exception("Entidades.Pedido.ItemRetorno.ObterItensRetorno n�o deveria retornar null, no caso de n�o ter itens, deve retornar vetor vazio.");
		//#endif
		//				}
		//
		//				return itensRetorno;
		//			}
		//		}
		//
		//		
		//		/// <summary>
		//		/// Obtem a lista de ItemVenda.
		//		/// Obt�m no banco de dados apenas na primeira vez que solicitado.
		//		///
		//		/// � solicitado pelo Acerto() do contexto Pedidos.
		//		/// </summary>
		//		public ItemVenda [] ItensVenda
		//		{
		//			get
		//			{
		//				if (itensVenda == null)
		//				{
		//					itensVenda = Entidades.Venda.ItemVenda.ObterItensVenda(codigo);
		//#if DEBUG
		//					if (itensVenda == null)
		//						throw new Exception("Entidades.Venda.ItemVenda.ObterItensVenda() n�o deveria retornar null, no caso de n�o ter itens, deve retornar vetor vazio.");
		//#endif
		//				}
		//
		//				return itensVenda;
		//			}
		//		}

		public DateTime �ltimaImpress�oData
		{
			get	{ return ultimaImpressaoData; }
			set
			{
				atualizado = false;
				ultimaImpressaoData = value;
			}
		}
		
		public Entidades.Pessoa.Funcion�rio �ltimaImpress�oFuncion�rio
		{
			get { return ultimaImpressaoFuncionario;  }
			set
			{
				atualizado = false;
				ultimaImpressaoFuncionario = value;
			}
		}
			
		public DateTime DataAbertura
		{
			get { return dataAbertura; }
			set
			{
				atualizado = false;
				dataAbertura = value;
			}
		}

		public DateTime DataAcerto
		{
			get { return dataAcerto; }
			set
			{
				atualizado = false;
				dataAcerto = value;
			}
		}
		
		public double ValorM�nimoVenda
		{
			get { return valorMinimoVenda; }
			set
			{
				atualizado = false;
				valorMinimoVenda = value;
			}
		}

		/// <summary>
		/// Valor da cota��o utilizada no pedido.
		/// </summary>
		public double Cota��o
		{
			get { return cotacao; }
			set
			{
				atualizado = false;
				cotacao = value;
			}
		}

		public bool Acertado
		{
			get { return acertado; }
			set
			{
				atualizado = false;
				acertado = value;
			}
		}

		public bool Fechado
		{
			get { return fechado; }
			set
			{
				atualizado = false;
				fechado = value;
			}
		}

		public new Cole��oItemPedido Itens
		{
			get { return (Cole��oItemPedido) itens;  }
		}

        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                atualizado = false;
                pessoa = value;
            }
        }

		#endregion

		public Pedido()
		{
			itens = new Cole��oItemPedido(this);
		}

		// Ordem das colunas da consulta ObterPedidosAbertos()
		[Flags]
        private enum Ordem 
		{
			C�digo, Refer�ncia, PesoPedido, Quantidade, Referencia, Nome, Teor, Peso, Faixa, Grupo, Digito, ForaDeLinha, DePeso, Coeficiente
		}

		/// <summary>
		/// Determina se o pedido est� atualizado no banco de dados.
		/// </summary>
		public override bool Atualizado
		{
			get
			{
				return base.Atualizado && itens.Atualizado;
			}
		}

//		public System.Data.DataSet ObterDataSetImpress�o()
//		{
//			/* O CriarAdaptador est� gerando a excess�o que n�o consegue achar assembly. 
//			 * Adicionei no references do Entidades o MysqlConnector enquanto o problema n�o � resolvido.
//			 */
//
//			#region ideal
//
////			IDbConnection conex�o = Conex�o;
////			System.Data.DataSet ds = new System.Data.DataSet();
////
////			IDbDataAdapter adaptador = CriarAdaptador(conex�o);
////			
////			
////			string c = "select concat(substr(itempedido.referencia, 1, 3), '.',  substr(itempedido.referencia, 4, 3), '.', substr(itempedido.referencia, 7, 2), '.', substr(itempedido.referencia, 9, 3), '-', mercadoria.digito) as referencia, ";
////				c += "itempedido.peso, itempedido.indice, itempedido.quantidade ";
////				c += "from itempedido, mercadoria WHERE ";
////				c += "itempedido.referencia = mercadoria.referencia AND ";
////				c += "itempedido.pedido = " + DbTransformar(this.C�digo);
////
////
////			lock (conex�o)
////			{
////				using (IDbCommand cmd = conex�o.CreateCommand())
////				{
////					cmd.CommandText = c;
////					
////					adaptador.Fill(ds, "Pedido");
////				}
////			}
////
////			return ds;
////			
//			#endregion
//
//			#region tempor�rio mas funciona
//			
//			System.Data.DataSet ds = new System.Data.DataSet();
//			MySql.Data.MySqlClient.MySqlConnection conex�o = null;
//			MySql.Data.MySqlClient.MySqlDataAdapter adaptador;
//
//			string strConex�o  = "Data Source=127.0.0.1";
//			strConex�o += ";Database=imjoias";
//			strConex�o += ";User Id=imjoias";
//			strConex�o += ";Password=***REMOVED***";
//		
//			conex�o = new MySql.Data.MySqlClient.MySqlConnection(strConex�o);
//
//			conex�o.Open();
//
//			MySql.Data.MySqlClient.MySqlCommand cmd = conex�o.CreateCommand();
//		
//			string c = "select concat(substr(itempedido.referencia, 1, 3), '.',  substr(itempedido.referencia, 4, 3), '.', substr(itempedido.referencia, 7, 2), '.', substr(itempedido.referencia, 9, 3), '-', mercadoria.digito) as referencia, ";
//			c += "itempedido.peso, itempedido.indice, itempedido.quantidade ";
//			c += "from itempedido, mercadoria WHERE ";
//			c += "itempedido.referencia = mercadoria.referencia AND ";
//			c += "itempedido.pedido = " + DbTransformar(this.C�digo);
//
//			cmd.CommandText = c;
//
//			adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
//			adaptador.Fill(ds, "Pedido");
//		
//			return ds;
//			
//			#endregion
//		}

		// Recupera��o de dados

		/// <summary>
		/// Esta lista preenche 3 entidades de uma s� vez:
		///		- Pedido, ItemPedido, Mercadoria (do itemPedido)
		///	
		///	Basicamente recupera todos os pedidos abertos n�o acertados.
		///	Observe que existe uma cole��o 'itens', atributo desta entidade.
		///	a lista de itens � obtida tamb�m por essa consulta.
		///	Cada pedidoitem possui uma mercadoria, que alias, � o que diferencia um item de outro.
		///	A mercadoria tamb�m � criada nesta consulta.
		/// </summary>
		/// <returns> lista de Entidade.Pedido </returns>
		public static Pedido [] ObterPedidosN�oAcertados()
		{
			// Obt�m os pedidos sem os itens, e cria uma hash para auxiliar futuramente
			ArrayList pedidos = ObterPedidosN�oAcertadosSemItens();

			IDbConnection conex�o = Conex�o;
			IDataReader leitor = null;
			
			Hashtable pedidosC�digo = new Hashtable();
			foreach (Pedido p in pedidos)
				pedidosC�digo.Add(p.C�digo, p);

			lock (conex�o)
			{
				using (IDbCommand cmd = conex�o.CreateCommand())
				{
					cmd.CommandText = 
						"SELECT pedido.codigo, itempedido.referencia, itempedido.peso, itempedido.quantidade, mercadoria.* from pedido, itemPedido LEFT JOIN mercadoria ON itempedido.referencia = mercadoria.referencia where itempedido.pedido = pedido.codigo AND pedido.acertado = 0 order by pedido.codigo, itempedido.referencia";

					try
					{
						long        c�digo�ltimoPedido = -1;
						long        c�digoAtualPedido;
						bool        novoPedido;
						Pedido		pedido  = null;
						ItemPedido	item	= null;
						Mercadoria	merc	= null;

						leitor = cmd.ExecuteReader();
						
						while (leitor.Read())
						{
							c�digoAtualPedido = leitor.GetInt32((int) Ordem.C�digo);
							novoPedido = (c�digoAtualPedido != c�digo�ltimoPedido);

							if (novoPedido)
							{
								pedido = (Pedido) pedidosC�digo[c�digoAtualPedido];

								c�digo�ltimoPedido = c�digoAtualPedido;

								pedido.cadastrado = true;
								pedido.atualizado = true;
							}
							
							// A cada item lido, existe uma nova mercadoria e um novo itempedido

							#region Recupera a mercadoria deste itempedido

							/* n�o deve-se fazer hash da mercadoria obtida,
							 * uma vez que ser�o o mesmo objeto para v�rios pedidos, 
							 * da� uma altera��o em um acarreta em altera��o nos outros!
							 */
							string refer�ncia = leitor.GetString((int) Ordem.Referencia);
							double peso = leitor.GetDouble((int) Ordem.PesoPedido);
							//							string hash = refer�ncia + peso.ToString();
 								
							if (refer�ncia != null)
							{
								if (!leitor.IsDBNull((int) Ordem.Digito))
									merc = new Mercadoria(refer�ncia, Convert.ToInt32(leitor.GetValue((int) Ordem.Digito)), peso);
								else
									merc = new Mercadoria(refer�ncia, -1, peso);

								merc.Coeficiente = leitor.GetDouble((int) Ordem.Coeficiente);

								if (!leitor.IsDBNull((int) Ordem.DePeso))
									merc.DePeso = leitor.GetBoolean((int) Ordem.DePeso);
									
								merc.Descri��o = leitor.GetString((int) Ordem.Nome);
									
								if (!leitor.IsDBNull((int) Ordem.Faixa))
									merc.Faixa = leitor.GetChar((int) Ordem.Faixa);

								if (!leitor.IsDBNull((int) Ordem.ForaDeLinha))
									merc.ForaDeLinha = leitor.GetBoolean((int) Ordem.ForaDeLinha);

								if (!leitor.IsDBNull((int) Ordem.Grupo))
									merc.Grupo = leitor.GetInt32((int) Ordem.Grupo);

								if (!leitor.IsDBNull((int) Ordem.Teor))
									merc.Teor = Convert.ToSingle(leitor.GetInt32((int) Ordem.Teor));

								merc.For�arCadastrada();
							}
							else
							{
								merc = new Mercadoria(refer�ncia);
								merc.Peso = peso;
							}

							#endregion

							item = new ItemPedido(
								pedido,
								merc,
								leitor.GetDouble((int) Ordem.Quantidade),
								true);

							pedido.Itens.Adicionar(item);
						}
					}
					finally
					{
						if (leitor != null)
							leitor.Close();
					}
				}
			}
			
			return (Pedido []) pedidos.ToArray(typeof(Pedido));
		}

		[Flags]
		private enum OrdemSemItens 
		{ 
			C�digo, DataAbertura, Pessoa, Funcion�rio, Fechado, UltimaImpressaoData, UltimaImpressaoFuncinario, DataAcerto, ValorMinimoVenda, Cota��o, Acertado 
		}

		private static ArrayList ObterPedidosN�oAcertadosSemItens()
		{
			// Lista de interios, utilizado para carregar posteriormente as pessoas.
			ArrayList   pessoas;		
			long []     vPessoas;

			pessoas = new ArrayList();

			IDbConnection conex�o;
			IDataReader leitor = null;
			ArrayList pedidos = new ArrayList();

			conex�o = Conex�o;

			try
			{

				using (IDbCommand cmd = conex�o.CreateCommand())
				{
					lock (conex�o)
					{
						cmd.CommandText = "SELECT * from pedido where acertado=0";
					
						leitor = cmd.ExecuteReader();
					
						while (leitor.Read())
						{
							Pedido pedido = new Pedido();
						
							pedido.DataAbertura = leitor.GetDateTime((int) OrdemSemItens.DataAbertura);
								
							pessoas.Add(Convert.ToInt64(leitor.GetValue((int) OrdemSemItens.Pessoa)));
							pedido.Acertado = leitor.GetBoolean((int) OrdemSemItens.Acertado);
							pedido.Fechado = leitor.GetBoolean((int) OrdemSemItens.Fechado);
						
							pessoas.Add(Convert.ToInt64(leitor.GetValue((int) OrdemSemItens.Funcion�rio)));
							pedido.C�digo = leitor.GetInt32((int) OrdemSemItens.C�digo);
								
							if (leitor.IsDBNull((int) OrdemSemItens.UltimaImpressaoData))
							{
								pedido.ultimaImpressaoData = DateTime.MinValue;
								pessoas.Add((long) -1);
							}
							else
							{
								pedido.ultimaImpressaoData = leitor.GetDateTime((int)OrdemSemItens.UltimaImpressaoData);
								pessoas.Add((long) -1);
							}

							pedido.cadastrado = true;

							pedidos.Add(pedido);
						}
					}
				}
			} finally
			{
				if (leitor != null)
				leitor.Close();
			}
		
			vPessoas = (long []) pessoas.ToArray(typeof(long));

			for (int i = 0; i < vPessoas.Length; i += 3)
			{
				Entidades.Pedido.Pedido pedido = (Pedido) pedidos[i/3];
							
				pedido.Pessoa					  = vPessoas[i];
				pedido.Funcion�rio                = vPessoas[i + 1];

				if (vPessoas[i + 2] >= 0)
					pedido.ultimaImpressaoFuncionario = vPessoas[i + 2];
				else
					pedido.ultimaImpressaoFuncionario = null;
			}

			return pedidos;
		}

        /// <summary>
        /// Conta quantos pedidos do cliente ainda n�o foram acertados.
        /// </summary>
        /// <param name="pessoa">Cliente.</param>
        /// <returns>N�mero de pedidos n�o acertados.</returns>
        public static uint ContarPedidosN�oAcertados(Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM pedido WHERE acertado=0 AND pessoa="
                    + DbTransformar(pessoa.C�digo);

                lock (conex�o)
                    return Convert.ToUInt32(cmd.ExecuteScalar());
            }
        }
    }
}
