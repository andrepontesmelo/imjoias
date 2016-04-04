using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento de um campo de um objeto para um
	/// par�metro de banco de dados.
	/// </summary>
	internal class CampoObjetoPar�metro : CampoPar�metroBase
	{
		/// <summary>
		/// Campo que cont�m o objeto.
		/// </summary>
		private FieldInfo campo;

		/// <summary>
		/// Campo no objeto.
		/// </summary>
		private FieldInfo campoObjeto;

		/// <summary>
		/// Nome da coluna.
		/// </summary>
		private string coluna;

		/// <summary>
		/// Mapeamento para o campo fianl.
		/// </summary>
		private CampoPar�metroBase mapeamento;

		/// <summary>
		/// Constr�i um mapeamento de um campo de um objeto
		/// para um par�metro.
		/// </summary>
		/// <param name="campo">Campo que cont�m o objeto.</param>
		/// <param name="nome">Nome do campo no objeto.</param>
		/// <param name="coluna">Nome da coluna no objeto.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public CampoObjetoPar�metro(FieldInfo campo, string nome, string coluna, IDbCommand cmd, string prefixo)
		{
			CampoPar�metroBase [] mapeamentos;

			this.coluna      = coluna;
			prefixo         += ExtrairNomeColuna(campo);
			this.campo       = campo;
			this.campoObjeto = campo.FieldType.GetField(nome, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (campoObjeto == null)
                throw new ArgumentException(
                    String.Format("Nome do campo de DbRelacionamento encontra-se incorreto para o campo {0} do tipo {1}.",
                    campo.Name, campo.DeclaringType.Name));

			mapeamentos      = F�bricaCampoPar�metro.MapearCampoPar�metro(campoObjeto, cmd, prefixo);

			if (mapeamentos.Length > 1)
				throw new NotSupportedException("N�o � poss�vel realizar um mapeamento de um campo para um objeto, cujo campo � um mapeamento de outros objetos.");

			this.mapeamento  = mapeamentos[0];
		}

		/// <summary>
		/// Define valor do objeto final do campo proveniente da
		/// entidade para o par�metro do banco de dados.
		/// </summary>
		/// <param name="entidade">Entidade que cont�m os valores.</param>
		public override void DefinirPar�metro(object entidade)
		{
			object objetoFinal;

			objetoFinal = campo.GetValue(entidade);

			mapeamento.DefinirPar�metro(objetoFinal);
		}

		/// <summary>
		/// Nomes das coluna.
		/// </summary>
		public override string Coluna
		{
			get
			{
				return coluna;
			}
		}

		/// <summary>
		/// Nomes dos par�metro.
		/// </summary>
		public override string Par�metro
		{
			get
			{
				return mapeamento.Par�metro;
			}
		}
	}
}
