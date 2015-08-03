using System;
using System.Collections;

namespace Neg�cio.Estoque
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

		#region Adi��o/Remo��o/Consulta de impostos

		/// <summary>
		/// Adiciona imposto � mercadoria
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
		/// Obt�m lista de impostos
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
		public void AdicionarMercadoria(Refer�ncia refer�ncia)
		{
			Mercadoria mercadoria = refer�ncia.ConstruirMercadoria();
			
			mercadorias.Add(refer�ncia, mercadoria);
			mercadoria.setEstoque(this);
		}

		/// <summary>
		/// Remove mercadoria do estoque
		/// </summary>
		/// <param name="mercadoria">Mercadoria a ser removida</param>
		public void RemoverMercadoria(Refer�ncia refer�ncia)
		{
			lock (mercadorias.SyncRoot)
			{
				/* A mercadoria passada n�o necessariamente � o mesmo objeto
				 * contido na tabela hash, apesar de representar o mesmo tipo
				 * de mercadoria (c�digo/refer�ncia). Portanto, ser� necess�rio
				 * verificar o objeto com o mesmo hashcode contido dentro da
				 * tabela hash, verificando se n�o existe nenhum unidade.
				 */
				Mercadoria local = (Mercadoria) mercadorias[refer�ncia];

				if (local == null)
					throw new Exce��oRefer�nciaN�oEncontrada(refer�ncia, this);

				if (local.Unidades > 0)
					throw new Exce��oUnidadesNoEstoque(local);

				mercadorias.Remove(refer�ncia);
			}
		}

		/// <summary>
		/// Subtrai a mercadoria do estoque
		/// </summary>
		/// <param name="mercadoria">Mercadoria a ser subtra�da</param>
		public void SubstrairMercadoria(Mercadoria mercadoria)
		{
			lock (mercadoria)
			{
				Mercadoria local;

				if (mercadoria.Estoque != this)
					throw new Exce��oMercadoriaEmOutroEstoque(mercadoria);
				
				local = (Mercadoria) mercadorias[mercadoria];

				lock (local)
				{
					// Verificar se estoque n�o ficar� negativo
					if (mercadoria.Unidades > local.Unidades)
						throw new Exce��oEstoqueInsuficiente(local);

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
				// Garantir que a mercadoria n�o est� em outro estoque
				if (mercadoria.Estoque != null)
					throw new Exce��oMercadoriaEmOutroEstoque(mercadoria);

				lock (mercadorias.SyncRoot)
				{
					Mercadoria local = (Mercadoria) mercadorias[mercadoria];

					// Garantir a exist�ncia da refer�ncia de mercadoria neste estoque
					if (local == null)
					{
						/* Neste ponto existem duas pol�ticas poss�veis:
						 * 1) Lan�ar uma exce��o informando que a mercadoria n�o
						 *    pertence ao estoque.
						 * 2) Adicionar a mercadoria no estoque.
						 * A primeira foi preferida, pois permite maior controle ao
						 * programa servidor.
						 */
						throw new Exce��oMercadoriaForaEstoque(mercadoria, this);
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
		/// Obt�m uma unidade da mercadoria
		/// </summary>
		/// <param name="c�digo"></param>
		public Mercadoria ObterUnidade(Refer�ncia refer�ncia)
		{
			// Verificar se existe a refer�ncia na tabela hash
			if (mercadorias[refer�ncia] == null)
				throw new Exce��oRefer�nciaN�oEncontrada(refer�ncia, this);

			Mercadoria mercadoria = refer�ncia.ConstruirMercadoria();

			mercadoria.setEstoque(this);

			return mercadoria;
		}

		/// <summary>
		/// Transfere mercadorias entre estoques
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia da mercadoria a ser transferida</param>
		/// <param name="unidades">Unidades a serem transferidas</param>
		/// <param name="destino">Estoque de estino que receber� as mercadorias</param>
		public void TransferirMercadoria(Refer�ncia refer�ncia, long unidades, Estoque destino)
		{
			// Verificar par�metros
			if (unidades < 1)
				throw new ArgumentOutOfRangeException("unidades");

			// Verificar se ambos estoques pertem a mesma empresa
			// TODO: Verificar
			if (destino.empresa != this.empresa)
				throw new Exception("N�o � poss�vel realizar transfer�ncias entre estoques de empresas diferentes");

			lock (mercadorias.SyncRoot)
			{
				Mercadoria local, externo;
				
				// Obter mercadorias de ambos estoques
				local = (Mercadoria) mercadorias[refer�ncia];
				externo = destino.ObterUnidade(refer�ncia);

				if (local == null)
					throw new Exce��oRefer�nciaN�oEncontrada(refer�ncia, this);

				lock (local)
				{
					// Verificar sufici�ncia de estoque
					if (local.Unidades < unidades)
						throw new Exce��oEstoqueInsuficiente(local);

					// Realizar opera��o
					externo.Unidades = unidades;
					destino.AcrescentarMercadoria(externo);
					local.Unidades -= unidades;
				}
			}
		}
	}
}
