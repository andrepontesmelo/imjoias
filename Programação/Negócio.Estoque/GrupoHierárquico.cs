using System;
using System.Collections;

namespace Negócio.Estoque
{
	/// <summary>
	/// Hierarquia de grupos
	/// </summary>
	public class GrupoHierárquico : Negócio.Estoque.Grupo
	{
		private GrupoHierárquico	superGrupo;
		private ArrayList			subGrupos;

		/// <summary>
		/// Constrói um GrupoHierárquico
		/// </summary>
		public GrupoHierárquico()
		{
			superGrupo = null;
			subGrupos  = new ArrayList();
		}

		/// <summary>
		/// Valida se um grupo pode ser supergrupo deste
		/// </summary>
		/// <remarks>Pode ser reimplementado</remarks>
		protected virtual bool ValidarSuperGrupo(GrupoHierárquico grupo)
		{
			return true;
		}

		/// <summary>
		/// Valida se um grupo pode ser subgrupo deste
		/// </summary>
		/// <remarks>Pode ser reimplementado</remarks>
		protected virtual bool ValidarSubGrupo(GrupoHierárquico grupo)
		{
			return true;
		}

		/// <summary>
		/// Super grupo
		/// </summary>
		internal GrupoHierárquico SuperGrupo
		{
			get { return superGrupo; }
			set { superGrupo = value; }
		}

		/// <summary>
		/// Adiciona um subgrupo a este grupo
		/// </summary>
		/// <param name="grupo">Subgrupo a ser adicionado</param>
		public void AdicionarGrupo(GrupoHierárquico grupo)
		{
			lock (this)
			{
				// Verifica se subgrupo já possui supergrupo
				if (grupo.SuperGrupo != null)
					throw new Exception("Subgrupo já possui um supergrupo.");

				// Verifica se não causa ciclo
				if (ExisteSuperGrupo(grupo))
					throw new Exception("Subgrupo causará ciclo, pois já é um supergrupo.");

				subGrupos.Add(grupo);
				grupo.SuperGrupo = this;
			}
		}

		/// <summary>
		/// Verifica se existe um supergrupo específico
		/// </summary>
		/// <param name="grupo">Grupo a ser procurado como supergrupo</param>
		/// <returns>Verdadeiro se encontrado</returns>
		private bool ExisteSuperGrupo(GrupoHierárquico grupo)
		{
			GrupoHierárquico super = this.SuperGrupo;

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
		public void RemoverGrupo(GrupoHierárquico grupo)
		{
			lock (this)
			{
				if (grupo.SuperGrupo != this)
					throw new Exception("O grupo não é subgrupo do objeto invocado.");

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
