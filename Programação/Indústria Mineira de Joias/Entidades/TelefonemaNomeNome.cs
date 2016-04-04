using System;
using Acesso.Comum;

namespace Entidades
{
	/// <summary>
	/// Summary description for TelefonemaNomeNome.
	/// </summary>
	[Serializable]
	public class TelefonemaNomeNome : DbManipulação
	{
		public enum TipoOrigem { Funcionário, Visitante, Externo };
		public enum TipoDestino { Funcionário, Cliente, Particular };

		private DateTime	quando;
		private string		telefone;
		private string		origem = null;
		private string		cidade;
		private int			tipoOrigem;
		private int			tipoDestino;
		private string		destino;

		public TelefonemaNomeNome() {}

		public TelefonemaNomeNome(DateTime quando, string telefone, string origem, string destino, string cidade, TipoOrigem tipoOrigem, TipoDestino tipoDestino)
		{
			this.quando = quando;
			this.telefone = telefone;
			this.origem = origem;
			this.cidade = cidade;
			this.tipoOrigem = (int) tipoOrigem;
			this.tipoDestino = (int) tipoDestino;
			this.destino = destino;
		}

		public DateTime Quando
		{
			get { return quando; }
		}

		public string Data
		{
			get { return quando.Date.ToShortDateString(); }
		}

		public TimeSpan Hora
		{
			get { return quando.TimeOfDay; }
		}

		public string Telefone
		{
			get { return telefone; }
		}

		public TipoOrigem TOrigem
		{
			get { return (TipoOrigem) tipoOrigem; }
		}

		public string Origem
		{
			get
			{
				return origem;
			}
		}

		public TipoDestino TDestino
		{
			get { return (TipoDestino) tipoDestino; }
		}

		public string Destino
		{
			get
			{		
				return destino;
			}
		}

		public string Cidade
		{
			get { return cidade; }
		}

		public string De
		{
			get { return Origem + "\n(" + TOrigem + ")"; }
		}

		public string Para
		{
			get { return Destino + "\n(" + TDestino + ")"; }
		}

		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			// Verificar tipo de registro
			cmd.CommandText =
				"INSERT INTO telefonemanomenome " +
				"(quando, telefone, origem, destino, cidade, tipoOrigem, tipoDestino) " +
				"VALUES (" + DbTransformar(Quando) + ", " +
				DbTransformar(Telefone) + ", " +
				DbTransformar(Origem) + ", " +
				DbTransformar(Destino) + ", " +
				DbTransformar(Cidade) + ", " +
				"'" + ((int) TOrigem).ToString() + "', " +
				"'" + ((int) TDestino).ToString() + "')";

			if (cmd.ExecuteNonQuery() != 1)
				throw new Exception("Não foi possível inserir os dados do telefonema!");
		}

		protected override void Atualizar(System.Data.IDbCommand cmd)
		{
			throw new NotImplementedException();
		}

		protected override void Descadastrar(System.Data.IDbCommand cmd)
		{
			throw new NotImplementedException();
		}
	}
}
