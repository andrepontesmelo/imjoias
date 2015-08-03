using System;
using System.Collections;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Classe abstrata para mercadorias
	/// </summary>
	public abstract class Mercadoria : ISujeitoImposto
	{
		private Hashtable		impostos;
		protected long			unidades;
		protected Refer�ncia	refer�ncia;
		private Estoque			estoque;

		/// <summary>
		/// Constr�i a mercadoria
		/// </summary>
		public Mercadoria()
		{
			impostos = new Hashtable();
		}

		public override int GetHashCode()
		{
			return refer�ncia.GetHashCode();
		}

		public abstract override string ToString();

		/// <summary>
		/// Calcula o pre�o da mercadoria
		/// </summary>
		/// <returns>Pre�o da mercadoria</returns>
		public abstract double CalcularPre�o();

		/// <summary>
		/// Calcula o pre�o total da mercadoria e impostos
		/// </summary>
		/// <returns>Pre�o total de venda</returns>
		/// <remarks>Um imposto s� � cobrado uma �nica vez</remarks>
		public double CalcularPre�oImpostos()
		{
			Hashtable impostosCobrados;
			double pre�o;
			
			// Hashtable usada para verificar se imposto j� foi cobrado
			impostosCobrados = new Hashtable();

			checked
			{
				pre�o = CalcularPre�o();

				// Impostos vinculados � mercadoria
				lock (impostos.SyncRoot)
				{
					foreach (Imposto imposto in impostos)
						IncluirImposto(imposto, ref pre�o, impostosCobrados);
				}

				// Impostos vinculados ao grupo
				foreach (Grupo grupo in refer�ncia.Grupos)
					foreach (Imposto imposto in grupo.Impostos)
						IncluirImposto(imposto, ref pre�o, impostosCobrados);

				// Impostos vinculados ao estoque
				foreach (Imposto imposto in estoque.Impostos)
					IncluirImposto(imposto, ref pre�o, impostosCobrados);
			}

			return pre�o;
		}

		/// <summary>
		/// Inclui valor de um imposto no pre�o
		/// </summary>
		private void IncluirImposto(Imposto imposto, ref double pre�o, IDictionary impostosCobrados)
		{
			checked
			{
				// Verificar se imposto � agreg�vel
				if (imposto.Acrescentar)
				{
					// Verificar se imposto j� foi cobrado
					if (impostosCobrados.Contains(imposto.Nome))
						return;

					// Incluir imposto
					imposto.AcrescentarImposto(ref pre�o);
					impostosCobrados.Add(imposto.Nome, imposto);
				}
			}
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
		/// Unidades da mercadoria
		/// </summary>
		public long Unidades
		{
			get { return unidades; }
			set { unidades = value; }
		}

		/// <summary>
		/// Estoque ao qual � mercadoria pertence
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
