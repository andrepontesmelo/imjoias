using System;
using System.Data;
using Acesso.Comum;

namespace Entidades
{
	[Serializable] 
	public class Telefonema : DbManipula��o
	{
		public enum TipoOrigem { Funcion�rio, Visitante, Externo };
		public enum TipoDestino { Funcion�rio, Cliente, Particular };

		private DateTime	quando;
		private string		telefone;
		private string		nome = null;
		private string		cidade;
		private int			tipoOrigem;
		private int			tipoDestino;
		private ulong		funcionario;
		private string		nomeFuncionario;

		public Telefonema() {}

		public Telefonema(DateTime quando, string telefone, string nome, ulong funcion�rio, string nomeFuncion�rio, string cidade, TipoOrigem tipoOrigem, TipoDestino tipoDestino)
		{
			this.quando = quando;
			this.telefone = telefone;
			this.nome = nome;
			this.funcionario = funcion�rio;
			this.cidade = cidade;
			this.tipoOrigem = (int) tipoOrigem;
			this.tipoDestino = (int) tipoDestino;
			this.nomeFuncionario = nomeFuncion�rio;
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
				if (tipoOrigem == (int) TipoOrigem.Funcion�rio)
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
				if (tipoDestino == (int) TipoDestino.Funcion�rio)
					return nomeFuncionario;
				else
					return nome;
			}
		}

		public ulong Funcion�rio
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

		#region Manipula��o de dados

		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			// Verificar tipo de registro
			if (TOrigem == TipoOrigem.Funcion�rio ||
				TDestino == TipoDestino.Funcion�rio)
			{
				cmd.CommandText =
					"INSERT INTO telefonemanomefuncionario " +
					"(quando, telefone, nome, funcionario, cidade, tipoOrigem, tipoDestino) " +
					"VALUES (" + DbTransformar(Quando) + ", " +
					DbTransformar(Telefone) + ", " +
					DbTransformar(Nome) + ", " +
					DbTransformar(Funcion�rio) + ", " +
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
				throw new Exception("N�o foi poss�vel inserir os dados do telefonema!");
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

		#region Recupera��o de Dados

		/// <summary>
		/// Mistura telefonemas de funcionarios e n�o-funcion�rios
		/// ordem por data
		/// </summary>
		/// <param name="limite">limite de telefonemas para buscar</param>
		/// <returns></returns>
		public static System.Data.DataSet Obter�ltimosTelefonemas(int limite)
		{
			string        cmd;
			IDataAdapter  adaptador;
			System.Data.DataSet       ds = new System.Data.DataSet();
			IDbConnection conex�o = Conex�o;

			cmd = "SELECT quando as data, telefone, pessoa.nome as origem, "
				+ " telefonemanomefuncionario.nome as destino, cidade  FROM  "
				+ " telefonemanomefuncionario, pessoa where "
				+ " telefonemanomefuncionario.funcionario ="
				+ " pessoa.codigo UNION SELECT quando as data, telefone, "
				+ " origem, destino, cidade  FROM `telefonemanomenome`"
				+ "order by data DESC limit " + limite;

			adaptador = Usu�rios.Usu�rioAtual.CriarAdaptadorDados(conex�o, cmd);

			lock (conex�o)
			{
				adaptador.Fill(ds);
			}
			
			Pessoa.Pessoa.AbreviarNomes(ds, 2);

			return ds;
		}

		#endregion

	}
}
