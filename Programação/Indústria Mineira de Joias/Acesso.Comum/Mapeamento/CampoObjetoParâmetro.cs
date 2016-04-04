using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento de um campo de um objeto para um
	/// parâmetro de banco de dados.
	/// </summary>
	internal class CampoObjetoParâmetro : CampoParâmetroBase
	{
		/// <summary>
		/// Campo que contém o objeto.
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
		private CampoParâmetroBase mapeamento;

		/// <summary>
		/// Constrói um mapeamento de um campo de um objeto
		/// para um parâmetro.
		/// </summary>
		/// <param name="campo">Campo que contém o objeto.</param>
		/// <param name="nome">Nome do campo no objeto.</param>
		/// <param name="coluna">Nome da coluna no objeto.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public CampoObjetoParâmetro(FieldInfo campo, string nome, string coluna, IDbCommand cmd, string prefixo)
		{
			CampoParâmetroBase [] mapeamentos;

			this.coluna      = coluna;
			prefixo         += ExtrairNomeColuna(campo);
			this.campo       = campo;
			this.campoObjeto = campo.FieldType.GetField(nome, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (campoObjeto == null)
                throw new ArgumentException(
                    String.Format("Nome do campo de DbRelacionamento encontra-se incorreto para o campo {0} do tipo {1}.",
                    campo.Name, campo.DeclaringType.Name));

			mapeamentos      = FábricaCampoParâmetro.MapearCampoParâmetro(campoObjeto, cmd, prefixo);

			if (mapeamentos.Length > 1)
				throw new NotSupportedException("Não é possível realizar um mapeamento de um campo para um objeto, cujo campo é um mapeamento de outros objetos.");

			this.mapeamento  = mapeamentos[0];
		}

		/// <summary>
		/// Define valor do objeto final do campo proveniente da
		/// entidade para o parâmetro do banco de dados.
		/// </summary>
		/// <param name="entidade">Entidade que contém os valores.</param>
		public override void DefinirParâmetro(object entidade)
		{
			object objetoFinal;

			objetoFinal = campo.GetValue(entidade);

			mapeamento.DefinirParâmetro(objetoFinal);
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
		/// Nomes dos parâmetro.
		/// </summary>
		public override string Parâmetro
		{
			get
			{
				return mapeamento.Parâmetro;
			}
		}
	}
}
