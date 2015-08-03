using System;
using System.Collections;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Hierarquia de grupos
	/// </summary>
	public class GrupoHier�rquico : Neg�cio.Estoque.Grupo
	{
		private GrupoHier�rquico	superGrupo;
		private ArrayList			subGrupos;

		/// <summary>
		/// Constr�i um GrupoHier�rquico
		/// </summary>
		public GrupoHier�rquico()
		{
			superGrupo = null;
			subGrupos  = new ArrayList();
		}

		/// <summary>
		/// Valida se um grupo pode ser supergrupo deste
		/// </summary>
		/// <remarks>Pode ser reimplementado</remarks>
		protected virtual bool ValidarSuperGrupo(GrupoHier�rquico grupo)
		{
			return true;
		}

		/// <summary>
		/// Valida se um grupo pode ser subgrupo deste
		/// </summary>
		/// <remarks>Pode ser reimplementado</remarks>
		protected virtual bool ValidarSubGrupo(GrupoHier�rquico grupo)
		{
			return true;
		}

		/// <summary>
		/// Super grupo
		/// </summary>
		internal GrupoHier�rquico SuperGrupo
		{
			get { return superGrupo; }
			set { superGrupo = value; }
		}

		/// <summary>
		/// Adiciona um subgrupo a este grupo
		/// </summary>
		/// <param name="grupo">Subgrupo a ser adicionado</param>
		public void AdicionarGrupo(GrupoHier�rquico grupo)
		{
			lock (this)
			{
				// Verifica se subgrupo j� possui supergrupo
				if (grupo.SuperGrupo != null)
					throw new Exception("Subgrupo j� possui um supergrupo.");

				// Verifica se n�o causa ciclo
				if (ExisteSuperGrupo(grupo))
					throw new Exception("Subgrupo causar� ciclo, pois j� � um supergrupo.");

				subGrupos.Add(grupo);
				grupo.SuperGrupo = this;
			}
		}

		/// <summary>
		/// Verifica se existe um supergrupo espec�fico
		/// </summary>
		/// <param name="grupo">Grupo a ser procurado como supergrupo</param>
		/// <returns>Verdadeiro se encontrado</returns>
		private bool ExisteSuperGrupo(GrupoHier�rquico grupo)
		{
			GrupoHier�rquico super = this.SuperGrupo;

			while (super != null)
			{
				if (super == grupo)
					return true;

				super = super.superGrupo;
			}

			return false;
		}

		/// <summary>
		/// Remove um subgrupo
		/// </summary>
		/// <param name="grupo">Subgrupo a ser removido</param>
		public void RemoverGrupo(GrupoHier�rquico grupo)
		{
			lock (this)
			{
				if (grupo.SuperGrupo != this)
					throw new Exception("O grupo n�o � subgrupo do objeto invocado.");

				subGrupos.Remove(grupo);
				grupo.SuperGrupo = null;
			}
		}

		/// <summary>
		/// Impostos deste grupo e de todos supergrupos
		/// </summary>
		public override Imposto[] Impostos
		{
			get
			{
				ArrayList impostos = new ArrayList();
				Imposto [] vetor;

				impostos.AddRange(base.Impostos);
				impostos.AddRange(superGrupo.Impostos);

				vetor = new Imposto[impostos.Count];
				impostos.CopyTo(vetor);

				return vetor;
			}
		}
	}
}
