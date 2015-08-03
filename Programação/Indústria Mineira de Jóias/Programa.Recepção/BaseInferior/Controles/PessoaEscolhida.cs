using System;

namespace Programa.Recep��o.BaseInferior.Controles
{
	enum TipoPessoa
	{
		Gen�rico = 0,
		Visitante = 1,
		Vendedor = 2,
		S�cio = 3
	}

	/// <summary>
	/// Cont�m a pessoa escolhida e sua classifica��o.
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
