using System;
using System.Data;
using System.Collections;
using Acesso.Comum;
using Entidades.Venda;
using Entidades.Relacionamento;

namespace Entidades.Pedido
{
	/// <summary>
	/// Um pedido é uma monitoração de mercadorias que foram relacionadas para alguem.
	/// Não existe um histórico de quando que a mercadoria saiu ou entrou na firma.
	/// Mas sim o número de quantas mercadorias já sairam, e quantas já retornaram.
	/// 
	/// O pedido pode ser relacionado para
	///		- um cliente de atacado
	///		- um cliente de auto-atacado
	///		- um funcionário representante
	///		
	/// Todo contexto pedido possui uma entidade pedido correspondente.
	/// 
	/// Todo: Documentar serialização
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
		private bool				acertado;			// Explicação em PedidoBaseInferior.
		private bool				fechado;
		
		[DbRelacionamento("codigo", "ultimaImpressaoFuncionario")]
		private Pessoa.Funcionário	ultimaImpressaoFuncionario;
		
//		[DbAtributo(TipoAtributo.Ignorar)]
//		private ColeçãoItemPedido	itens = null;

        [DbRelacionamento("codigo", "pessoa")]
        protected Pessoa.Pessoa pessoa;

		#region Propriedades 

		//		/// <summary>
		//		/// Obtem a lista de ItemRetorno.
		//		/// Obtém no banco de dados apenas na primeira vez que solicitado.
		//		/// 
		//		/// É solicitado pelo Acerto() do contexto Pedidos.
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
		//						throw new Exception("Entidades.Pedido.ItemRetorno.ObterItensRetorno não deveria retornar null, no caso de não ter itens, deve retornar vetor vazio.");
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
		//		/// Obtém no banco de dados apenas na primeira vez que solicitado.
		//		///
		//		/// É solicitado pelo Acerto() do contexto Pedidos.
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
		//						throw new Exception("Entidades.Venda.ItemVenda.ObterItensVenda() não deveria retornar null, no caso de não ter itens, deve retornar vetor vazio.");
		//#endif
		//				}
		//
		//				return itensVenda;
		//			}
		//		}

		public DateTime ÚltimaImpressãoData
		{
			get	{ return ultimaImpressaoData; }
			set
			{
				atualizado = false;
				ultimaImpressaoData = value;
			}
		}
		
		public Entidades.Pessoa.Funcionário ÚltimaImpressãoFuncionário
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
		
		public double ValorMínimoVenda
		{
			get { return valorMinimoVenda; }
			set
			{
				atualizado = false;
				valorMinimoVenda = value;
			}
		}

		/// <summary>
		/// Valor da cotação utilizada no pedido.
		/// </summary>
		public double Cotação
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

		public new ColeçãoItemPedido Itens
		{
			get { return (ColeçãoItemPedido) itens;  }
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
			itens = new ColeçãoItemPedido(this);
		}

		// Ordem das colunas da consulta ObterPedidosAbertos()
		[Flags]
        private enum Ordem 
		{
			Código, Referência, PesoPedido, Quantidade, Referencia, Nome, Teor, Peso, Faixa, Grupo, Digito, ForaDeLinha, DePeso, Coeficiente
		}

		/// <summary>
		/// Determina se o pedido está atualizado no banco de dados.
		/// </summary>
		public override bool Atualizado
		{
			get
			{
				return base.Atualizado && itens.Atualizado;
			}
		}

//		public System.Data.DataSet ObterDataSetImpressão()
//		{
//			/* O CriarAdaptador está gerando a excessão que não consegue achar assembly. 
//			 * Adicionei no references do Entidades o MysqlConnector enquanto o problema não é resolvido.
//			 */
//
//			#region ideal
//
////			IDbConnection conexão = Conexão;
////			System.Data.DataSet ds = new System.Data.DataSet();
////
////			IDbDataAdapter adaptador = CriarAdaptador(conexão);
////			
////			
////			string c = "select concat(substr(itempedido.referencia, 1, 3), '.',  substr(itempedido.referencia, 4, 3), '.', substr(itempedido.referencia, 7, 2), '.', substr(itempedido.referencia, 9, 3), '-', mercadoria.digito) as referencia, ";
////				c += "itempedido.peso, itempedido.indice, itempedido.quantidade ";
////				c += "from itempedido, mercadoria WHERE ";
////				c += "itempedido.referencia = mercadoria.referencia AND ";
////				c += "itempedido.pedido = " + DbTransformar(this.Código);
////
////
////			lock (conexão)
////			{
////				using (IDbCommand cmd = conexão.CreateCommand())
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
//			#region temporário mas funciona
//			
//			System.Data.DataSet ds = new System.Data.DataSet();
//			MySql.Data.MySqlClient.MySqlConnection conexão = null;
//			MySql.Data.MySqlClient.MySqlDataAdapter adaptador;
//
//			string strConexão  = "Data Source=127.0.0.1";
//			strConexão += ";Database=imjoias";
//			strConexão += ";User Id=imjoias";
//			strConexão += ";Password=***REMOVED***";
//		
//			conexão = new MySql.Data.MySqlClient.MySqlConnection(strConexão);
//
//			conexão.Open();
//
//			MySql.Data.MySqlClient.MySqlCommand cmd = conexão.CreateCommand();
//		
//			string c = "select concat(substr(itempedido.referencia, 1, 3), '.',  substr(itempedido.referencia, 4, 3), '.', substr(itempedido.referencia, 7, 2), '.', substr(itempedido.referencia, 9, 3), '-', mercadoria.digito) as referencia, ";
//			c += "itempedido.peso, itempedido.indice, itempedido.quantidade ";
//			c += "from itempedido, mercadoria WHERE ";
//			c += "itempedido.referencia = mercadoria.referencia AND ";
//			c += "itempedido.pedido = " + DbTransformar(this.Código);
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

		// Recuperação de dados

		/// <summary>
		/// Esta lista preenche 3 entidades de uma só vez:
		///		- Pedido, ItemPedido, Mercadoria (do itemPedido)
		///	
		///	Basicamente recupera todos os pedidos abertos não acertados.
		///	Observe que existe uma coleção 'itens', atributo desta entidade.
		///	a lista de itens é obtida também por essa consulta.
		///	Cada pedidoitem possui uma mercadoria, que alias, é o que diferencia um item de outro.
		///	A mercadoria também é criada nesta consulta.
		/// </summary>
		/// <returns> lista de Entidade.Pedido </returns>
		public static Pedido [] ObterPedidosNãoAcertados()
		{
			// Obtém os pedidos sem os itens, e cria uma hash para auxiliar futuramente
			ArrayList pedidos = ObterPedidosNãoAcertadosSemItens();

			IDbConnection conexão = Conexão;
			IDataReader leitor = null;
			
			Hashtable pedidosCódigo = new Hashtable();
			foreach (Pedido p in pedidos)
				pedidosCódigo.Add(p.Código, p);

			lock (conexão)
			{
				using (IDbCommand cmd = conexão.CreateCommand())
				{
					cmd.CommandText = 
						"SELECT pedido.codigo, itempedido.referencia, itempedido.peso, itempedido.quantidade, mercadoria.* from pedido, itemPedido LEFT JOIN mercadoria ON itempedido.referencia = mercadoria.referencia where itempedido.pedido = pedido.codigo AND pedido.acertado = 0 order by pedido.codigo, itempedido.referencia";

					try
					{
						long        códigoÚltimoPedido = -1;
						long        códigoAtualPedido;
						bool        novoPedido;
						Pedido		pedido  = null;
						ItemPedido	item	= null;
						Mercadoria	merc	= null;

						leitor = cmd.ExecuteReader();
						
						while (leitor.Read())
						{
							códigoAtualPedido = leitor.GetInt32((int) Ordem.Código);
							novoPedido = (códigoAtualPedido != códigoÚltimoPedido);

							if (novoPedido)
							{
								pedido = (Pedido) pedidosCódigo[códigoAtualPedido];

								códigoÚltimoPedido = códigoAtualPedido;

								pedido.cadastrado = true;
								pedido.atualizado = true;
							}
							
							// A cada item lido, existe uma nova mercadoria e um novo itempedido

							#region Recupera a mercadoria deste itempedido

							/* não deve-se fazer hash da mercadoria obtida,
							 * uma vez que serão o mesmo objeto para vários pedidos, 
							 * daí uma alteração em um acarreta em alteração nos outros!
							 */
							string referência = leitor.GetString((int) Ordem.Referencia);
							double peso = leitor.GetDouble((int) Ordem.PesoPedido);
							//							string hash = referência + peso.ToString();
 								
							if (referência != null)
							{
								if (!leitor.IsDBNull((int) Ordem.Digito))
									merc = new Mercadoria(referência, Convert.ToInt32(leitor.GetValue((int) Ordem.Digito)), peso);
								else
									merc = new Mercadoria(referência, -1, peso);

								merc.Coeficiente = leitor.GetDouble((int) Ordem.Coeficiente);

								if (!leitor.IsDBNull((int) Ordem.DePeso))
									merc.DePeso = leitor.GetBoolean((int) Ordem.DePeso);
									
								merc.Descrição = leitor.GetString((int) Ordem.Nome);
									
								if (!leitor.IsDBNull((int) Ordem.Faixa))
									merc.Faixa = leitor.GetChar((int) Ordem.Faixa);

								if (!leitor.IsDBNull((int) Ordem.ForaDeLinha))
									merc.ForaDeLinha = leitor.GetBoolean((int) Ordem.ForaDeLinha);

								if (!leitor.IsDBNull((int) Ordem.Grupo))
									merc.Grupo = leitor.GetInt32((int) Ordem.Grupo);

								if (!leitor.IsDBNull((int) Ordem.Teor))
									merc.Teor = Convert.ToSingle(leitor.GetInt32((int) Ordem.Teor));

								merc.ForçarCadastrada();
							}
							else
							{
								merc = new Mercadoria(referência);
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
			Código, DataAbertura, Pessoa, Funcionário, Fechado, UltimaImpressaoData, UltimaImpressaoFuncinario, DataAcerto, ValorMinimoVenda, Cotação, Acertado 
		}

		private static ArrayList ObterPedidosNãoAcertadosSemItens()
		{
			// Lista de interios, utilizado para carregar posteriormente as pessoas.
			ArrayList   pessoas;		
			long []     vPessoas;

			pessoas = new ArrayList();

			IDbConnection conexão;
			IDataReader leitor = null;
			ArrayList pedidos = new ArrayList();

			conexão = Conexão;

			try
			{

				using (IDbCommand cmd = conexão.CreateCommand())
				{
					lock (conexão)
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
						
							pessoas.Add(Convert.ToInt64(leitor.GetValue((int) OrdemSemItens.Funcionário)));
							pedido.Código = leitor.GetInt32((int) OrdemSemItens.Código);
								
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
				pedido.Funcionário                = vPessoas[i + 1];

				if (vPessoas[i + 2] >= 0)
					pedido.ultimaImpressaoFuncionario = vPessoas[i + 2];
				else
					pedido.ultimaImpressaoFuncionario = null;
			}

			return pedidos;
		}

        /// <summary>
        /// Conta quantos pedidos do cliente ainda não foram acertados.
        /// </summary>
        /// <param name="pessoa">Cliente.</param>
        /// <returns>Número de pedidos não acertados.</returns>
        public static uint ContarPedidosNãoAcertados(Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM pedido WHERE acertado=0 AND pessoa="
                    + DbTransformar(pessoa.Código);

                lock (conexão)
                    return Convert.ToUInt32(cmd.ExecuteScalar());
            }
        }
    }
}
