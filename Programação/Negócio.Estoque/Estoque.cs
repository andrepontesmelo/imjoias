using System;
using System.Collections;

namespace Negócio.Estoque
{
	/// <summary>
	/// Estoque de uma empresa
	/// </summary>
	public class Estoque : System.Collections.IEnumerable, ISujeitoImposto
	{
		private string			nome;
		private IEstocador		empresa;
		private Hashtable		mercadorias;
		private Hashtable		impostos;

		/// <summary>
		/// Construtora de Estoque
		/// </summary>
		public Estoque(IEstocador empresa)
		{
			this.empresa = empresa;
			mercadorias = new Hashtable();
			impostos = new Hashtable();
		}

		/// <summary>
		/// Nome do estoque
		/// </summary>
		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		public IEnumerator GetEnumerator()
		{
			return mercadorias.GetEnumerator();
		}

		#region Adição/Remoção/Consulta de impostos

		/// <summary>
		/// Adiciona imposto à mercadoria
		/// </summary>
		/// <param name="imposto">Imposto a ser adicionado</param>
		public void AdicionarImposto(Imposto imposto)
		{
			lock (impostos.SyncRoot)
			{
				impostos.Add(imposto.Nome, imposto);
			}
		}

		/// <summary>
		/// Remove imposto da mercadoria
		/// </summary>
		/// <param name="imposto">Imposto a ser removido</param>
		public void RemoverImposto(Imposto imposto)
		{
			lock (impostos.SyncRoot)
			{
				impostos.Remove(imposto.Nome);
			}
		}

		/// <summary>
		/// Obtém lista de impostos
		/// </summary>
		public Imposto[] Impostos
		{
			get
			{
				Imposto[] vetor = new Imposto[impostos.Count];
				int i = 0;

				foreach (Imposto imposto in impostos)
					vetor[i] = imposto;

				return vetor;
			}
		}

		#endregion

		/// <summary>
		/// Adiciona mercadoria ao estoque
		/// </summary>
		/// <param name="mercadoria">Mercadoria a ser inserida</param>
		public void AdicionarMercadoria(Referência referência)
		{
			Mercadoria mercadoria = referência.ConstruirMercadoria();
			
			mercadorias.Add(referência, mercadoria);
			mercadoria.setEstoque(this);
		}

		/// <summary>
		/// Remove mercadoria do estoque
		/// </summary>
		/// <param name="mercadoria">Mercadoria a ser removida</param>
		public void RemoverMercadoria(Referência referência)
		{
			lock (mercadorias.SyncRoot)
			{
				/* A mercadoria passada não necessariamente é o mesmo objeto
				 * contido na tabela hash, apesar de representar o mesmo tipo
				 * de mercadoria (código/referência). Portanto, será necessário
				 * verificar o objeto com o mesmo hashcode contido dentro da
				 * tabela hash, verificando se não existe nenhum unidade.
				 */
				Mercadoria local = (Mercadoria) mercadorias[referência];

				if (local == null)
					throw new ExceçãoReferênciaNãoEncontrada(referência, this);

				if (local.Unidades > 0)
					throw new ExceçãoUnidadesNoEstoque(local);

				mercadorias.Remove(referência);
			}
		}

		/// <summary>
		/// Subtrai a mercadoria do estoque
		/// </summary>
		/// <param name="mercadoria">Mercadoria a ser subtraída</param>
		public void SubstrairMercadoria(Mercadoria mercadoria)
		{
			lock (mercadoria)
			{
				Mercadoria local;

				if (mercadoria.Estoque != this)
					throw new ExceçãoMercadoriaEmOutroEstoque(mercadoria);
				
				local = (Mercadoria) mercadorias[mercadoria];

				lock (local)
				{
					// Verificar se estoque não ficará negativo
					if (mercadoria.Unidades > local.Unidades)
						throw new ExceçãoEstoqueInsuficiente(local);

					local.Unidades -= mercadoria.Unidades;
				}
			}
		}

		/// <summary>
		/// Acrescenta unidades de mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria a ser acrescentada</param>
		public void AcrescentarMercadoria(Mercadoria mercadoria)
		{
			lock (mercadoria)
			{
				// Garantir que a mercadoria não está em outro estoque
				if (mercadoria.Estoque != null)
					throw new ExceçãoMercadoriaEmOutroEstoque(mercadoria);

				lock (mercadorias.SyncRoot)
				{
					Mercadoria local = (Mercadoria) mercadorias[mercadoria];

					// Garantir a existência da referência de mercadoria neste estoque
					if (local == null)
					{
						/* Neste ponto existem duas políticas possíveis:
						 * 1) Lançar uma exceção informando que a mercadoria não
						 *    pertence ao estoque.
						 * 2) Adicionar a mercadoria no estoque.
						 * A primeira foi preferida, pois permite maior controle ao
						 * programa servidor.
						 */
						throw new ExceçãoMercadoriaForaEstoque(mercadoria, this);
					}

					lock (local)
					{
						checked
						{
							local.Unidades += mercadoria.Unidades;
						}
					}

					mercadoria.setEstoque(this);
				}
			}
		}

		/// <summary>
		/// Obtém uma unidade da mercadoria
		/// </summary>
		/// <param name="código"></param>
		public Mercadoria ObterUnidade(Referência referência)
		{
			// Verificar se existe a referência na tabela hash
			if (mercadorias[referência] == null)
				throw new ExceçãoReferênciaNãoEncontrada(referência, this);

			Mercadoria mercadoria = referência.ConstruirMercadoria();

			mercadoria.setEstoque(this);

			return mercadoria;
		}

		/// <summary>
		/// Transfere mercadorias entre estoques
		/// </summary>
		/// <param name="referência">Referência da mercadoria a ser transferida</param>
		/// <param name="unidades">Unidades a serem transferidas</param>
		/// <param name="destino">Estoque de estino que receberá as mercadorias</param>
		public void TransferirMercadoria(Referência referência, long unidades, Estoque destino)
		{
			// Verificar parâmetros
			if (unidades < 1)
				throw new ArgumentOutOfRangeException("unidades");

			// Verificar se ambos estoques pertem a mesma empresa
			// TODO: Verificar
			if (destino.empresa != this.empresa)
				throw new Exception("Não é possível realizar transferências entre estoques de empresas diferentes");

			lock (mercadorias.SyncRoot)
			{
				Mercadoria local, externo;
				
				// Obter mercadorias de ambos estoques
				local = (Mercadoria) mercadorias[referência];
				externo = destino.ObterUnidade(referência);

				if (local == null)
					throw new ExceçãoReferênciaNãoEncontrada(referência, this);

				lock (local)
				{
					// Verificar suficiência de estoque
					if (local.Unidades < unidades)
						throw new ExceçãoEstoqueInsuficiente(local);

					// Realizar operação
					externo.Unidades = unidades;
					destino.AcrescentarMercadoria(externo);
					local.Unidades -= unidades;
				}
			}
		}
	}
}
