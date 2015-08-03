using System;

namespace Programa.Recepção.BaseInferior.Controles
{
	enum TipoPessoa
	{
		Genérico = 0,
		Visitante = 1,
		Vendedor = 2,
		Sócio = 3
	}

	/// <summary>
	/// Contém a pessoa escolhida e sua classificação.
	/// </summary>
	sealed class PessoaEscolhida
	{
		private TipoPessoa	quem;
		private object		objeto;

		public PessoaEscolhida(TipoPessoa quem, object objeto)
		{
			this.quem = quem; this.objeto = objeto;
		}

		public TipoPessoa Quem { get { return quem; } }
		public object Objeto { get { return objeto; } }
	}
}
