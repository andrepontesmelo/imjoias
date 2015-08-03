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
		/// Quando atribuído à algum membro de uma entidade, indica que alguma coluna 
        /// desta entidade será preenchida obtendo-se algum campo de outra tabela.
		/// </summary>
        /// <param name="campo">Campo deste objeto que será selecionado.</param>
        /// <param name="coluna">Nome da coluna da tabela atual que será preenchido.</param>
		public DbRelacionamento(string campo, string coluna) : base(TipoAtributo.Relacionamento)
		{
			this.campo = campo;
			this.coluna = coluna;
		}

		/// <summary>
        /// Quando atribuído à algum membro de uma entidade, indica que alguma coluna 
        /// desta entidade será preenchida obtendo-se algum campo de outra tabela.
        /// </summary>
		/// <param name="chavePrimária">Determina se o atributo é
		/// chave-primária da entidade atual.</param>
        /// <param name="campo">Campo deste objeto que será selecionado.</param>
        /// <param name="coluna">Nome da coluna da tabela atual que será preenchido.</param>
        public DbRelacionamento(bool chavePrimária, string campo, string coluna)
            : this(campo, coluna)
		{
			if (chavePrimária)
				this.tipo |= TipoAtributo.ChavePrimária;
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
