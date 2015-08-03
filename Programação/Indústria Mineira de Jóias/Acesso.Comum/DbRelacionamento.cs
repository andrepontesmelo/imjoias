using System;

namespace Acesso.Comum
{
	/// <summary>
	/// Atributo que permite o mapeamento de relacionamento
	/// entre objetos, assim como no banco de dados.
	/// </summary>
	public class DbRelacionamento : DbAtributo
	{
		/// <summary>
		/// Campo do objeto.
		/// </summary>
		private string campo;

		/// <summary>
		/// Nome da coluna.
		/// </summary>
		private string coluna;

        /// <summary>
		/// Quando atribu�do � algum membro de uma entidade, indica que alguma coluna 
        /// desta entidade ser� preenchida obtendo-se algum campo de outra tabela.
		/// </summary>
        /// <param name="campo">Campo deste objeto que ser� selecionado.</param>
        /// <param name="coluna">Nome da coluna da tabela atual que ser� preenchido.</param>
		public DbRelacionamento(string campo, string coluna) : base(TipoAtributo.Relacionamento)
		{
			this.campo = campo;
			this.coluna = coluna;
		}

		/// <summary>
        /// Quando atribu�do � algum membro de uma entidade, indica que alguma coluna 
        /// desta entidade ser� preenchida obtendo-se algum campo de outra tabela.
        /// </summary>
		/// <param name="chavePrim�ria">Determina se o atributo �
		/// chave-prim�ria da entidade atual.</param>
        /// <param name="campo">Campo deste objeto que ser� selecionado.</param>
        /// <param name="coluna">Nome da coluna da tabela atual que ser� preenchido.</param>
        public DbRelacionamento(bool chavePrim�ria, string campo, string coluna)
            : this(campo, coluna)
		{
			if (chavePrim�ria)
				this.tipo |= TipoAtributo.ChavePrim�ria;
		}

		/// <summary>
		/// Campo extrangeiro;
		/// </summary>
		public string Campo
		{
			get { return campo; }
		}

		/// <summary>
		/// Nome da coluna.
		/// </summary>
		public string Coluna
		{
			get { return coluna; }
		}
	}
}
