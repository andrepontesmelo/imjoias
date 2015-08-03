using System;
using System.Collections;

namespace Negócio.Estoque
{
	/// <summary>
	/// Classe abstrata para mercadorias
	/// </summary>
	public abstract class Mercadoria : ISujeitoImposto
	{
		private Hashtable		impostos;
		protected long			unidades;
		protected Referência	referência;
		private Estoque			estoque;

		/// <summary>
		/// Constrói a mercadoria
		/// </summary>
		public Mercadoria()
		{
			impostos = new Hashtable();
		}

		public override int GetHashCode()
		{
			return referência.GetHashCode();
		}

		public abstract override string ToString();

		/// <summary>
		/// Calcula o preço da mercadoria
		/// </summary>
		/// <returns>Preço da mercadoria</returns>
		public abstract double CalcularPreço();

		/// <summary>
		/// Calcula o preço total da mercadoria e impostos
		/// </summary>
		/// <returns>Preço total de venda</returns>
		/// <remarks>Um imposto só é cobrado uma única vez</remarks>
		public double CalcularPreçoImpostos()
		{
			Hashtable impostosCobrados;
			double preço;
			
			// Hashtable usada para verificar se imposto já foi cobrado
			impostosCobrados = new Hashtable();

			checked
			{
				preço = CalcularPreço();

				// Impostos vinculados à mercadoria
				lock (impostos.SyncRoot)
				{
					foreach (Imposto imposto in impostos)
						IncluirImposto(imposto, ref preço, impostosCobrados);
				}

				// Impostos vinculados ao grupo
				foreach (Grupo grupo in referência.Grupos)
					foreach (Imposto imposto in grupo.Impostos)
						IncluirImposto(imposto, ref preço, impostosCobrados);

				// Impostos vinculados ao estoque
				foreach (Imposto imposto in estoque.Impostos)
					IncluirImposto(imposto, ref preço, impostosCobrados);
			}

			return preço;
		}

		/// <summary>
		/// Inclui valor de um imposto no preço
		/// </summary>
		private void IncluirImposto(Imposto imposto, ref double preço, IDictionary impostosCobrados)
		{
			checked
			{
				// Verificar se imposto é agregável
				if (imposto.Acrescentar)
				{
					// Verificar se imposto já foi cobrado
					if (impostosCobrados.Contains(imposto.Nome))
						return;

					// Incluir imposto
					imposto.AcrescentarImposto(ref preço);
					impostosCobrados.Add(imposto.Nome, imposto);
				}
			}
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
		/// Unidades da mercadoria
		/// </summary>
		public long Unidades
		{
			get { return unidades; }
			set { unidades = value; }
		}

		/// <summary>
		/// Estoque ao qual à mercadoria pertence
		/// </summary>
		public Estoque Estoque
		{
			get { return estoque; }
		}

		internal void setEstoque(Estoque estoque)
		{
			this.estoque = estoque;
		}
	}
}
