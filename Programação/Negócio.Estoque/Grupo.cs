using System;
using System.Collections;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Grupo de mercadorias
	/// </summary>
	public class Grupo : IEnumerable, ISujeitoImposto
	{
		protected string	nome;
		private Hashtable	refer�ncias;
		private Hashtable	impostos;

		/// <summary>
		/// Constr�i um grupo de refer�ncias
		/// </summary>
		public Grupo()
		{
			refer�ncias = new Hashtable();
			impostos    = new Hashtable();
		}

		#region IEnumerable

		public IEnumerator GetEnumerator()
		{
			return refer�ncias.GetEnumerator();
		}

		#endregion

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
		public virtual Imposto[] Impostos
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
		/// Adiciona uma refer�ncia ao grupo
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser adicionada</param>
		public void AdicionarRefer�ncia(Refer�ncia refer�ncia)
		{
			if (!ValidarRefer�ncia(refer�ncia))
				throw new Exception("Refer�ncia inv�lida para este grupo.");

			refer�ncias.Add(refer�ncia, refer�ncia);
			refer�ncia.AdicionarGrupo(this);
		}

		/// <summary>
		/// Remove refer�ncia do grupo
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser removida</param>
		public void RemoverRefer�ncia(Refer�ncia refer�ncia)
		{
			/* Teoricamente, n�o deveria ocorrer a remo��o
			 * de uma refer�ncia a partir de um objeto que
			 * n�o esteja na tabela hash. Por�m utilizaremos
			 * a t�cnica de programa��o defensiva.
			 */
			Refer�ncia local;

			local = (Refer�ncia) refer�ncias[refer�ncia];

			refer�ncias.Remove(refer�ncia);

			if (local != refer�ncia)
				local.RemoverGrupo(this);

			refer�ncia.RemoverGrupo(this);
		}

		/// <summary>
		/// Nome do grupo
		/// </summary>
		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		/// <summary>
		/// Verifica se uma refer�ncia � v�lida para pertencer
		/// ao grupo.
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser validada</param>
		/// <returns>Verdadeiro se a refer�ncia for v�lida</returns>
		/// <remarks>Esta fun��o � chamada por AdicionarRefer�ncia</remarks>
		protected virtual bool ValidarRefer�ncia(Refer�ncia refer�ncia)
		{
			/* Esta fun��o pode ser sobreposta.
			 * Padr�o = verdadeiro
			 */
			return true;
		}
	}
}
