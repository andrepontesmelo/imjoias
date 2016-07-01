using System;
using System.Data;
using Acesso.Comum;

namespace Entidades
{
	[Serializable] 
	public class Telefonema : DbManipulação
	{
		public enum TipoOrigem { Funcionário, Visitante, Externo };
		public enum TipoDestino { Funcionário, Cliente, Particular };

		private DateTime	quando;
		private string		telefone;
		private string		nome = null;
		private string		cidade;
		private int			tipoOrigem;
		private int			tipoDestino;
		private ulong		funcionario;
		private string		nomeFuncionario;

		public Telefonema() {}

		public Telefonema(DateTime quando, string telefone, string nome, ulong funcionário, string nomeFuncionário, string cidade, TipoOrigem tipoOrigem, TipoDestino tipoDestino)
		{
			this.quando = quando;
			this.telefone = telefone;
			this.nome = nome;
			this.funcionario = funcionário;
			this.cidade = cidade;
			this.tipoOrigem = (int) tipoOrigem;
			this.tipoDestino = (int) tipoDestino;
			this.nomeFuncionario = nomeFuncionário;
		}

		#region Atributos

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
				// Ao ler do banco de dados, origem = null
				if (tipoOrigem == (int) TipoOrigem.Funcionário)
					return nomeFuncionario;
				else
					return nome;
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
				if (tipoDestino == (int) TipoDestino.Funcionário)
					return nomeFuncionario;
				else
					return nome;
			}
		}

		public ulong Funcionário
		{
			get { return funcionario; }
		}

		public string Nome
		{
			get { return nome; }
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

		#endregion

		#region Manipulação de dados

		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			// Verificar tipo de registro
			if (TOrigem == TipoOrigem.Funcionário ||
				TDestino == TipoDestino.Funcionário)
			{
				cmd.CommandText =
					"INSERT INTO telefonemanomefuncionario " +
					"(quando, telefone, nome, funcionario, cidade, tipoOrigem, tipoDestino) " +
					"VALUES (" + DbTransformar(Quando) + ", " +
					DbTransformar(Telefone) + ", " +
					DbTransformar(Nome) + ", " +
					DbTransformar(Funcionário) + ", " +
					DbTransformar(Cidade) + ", " +
					"'" + ((int) TOrigem).ToString() + "', " +
					"'" + ((int) TDestino).ToString() + "')";
			}
			else
			{
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
			}

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

		#endregion

		#region Recuperação de Dados

		/// <summary>
		/// Mistura telefonemas de funcionarios e não-funcionários
		/// ordem por data
		/// </summary>
		/// <param name="limite">limite de telefonemas para buscar</param>
		/// <returns></returns>
		public static System.Data.DataSet ObterÚltimosTelefonemas(int limite)
		{
			string        cmd;
			IDataAdapter  adaptador;
			System.Data.DataSet       ds = new System.Data.DataSet();
			IDbConnection conexão = Conexão;

			cmd = "SELECT quando as data, telefone, pessoa.nome as origem, "
				+ " telefonemanomefuncionario.nome as destino, cidade  FROM  "
				+ " telefonemanomefuncionario, pessoa where "
				+ " telefonemanomefuncionario.funcionario ="
				+ " pessoa.codigo UNION SELECT quando as data, telefone, "
				+ " origem, destino, cidade  FROM `telefonemanomenome`"
				+ "order by data DESC limit " + limite;

			adaptador = Usuários.UsuárioAtual.CriarAdaptadorDados(conexão, cmd);

			lock (conexão)
			{
				adaptador.Fill(ds);
			}
			
			Pessoa.Pessoa.AbreviarNomes(ds, 2);

			return ds;
		}

		#endregion

	}
}
