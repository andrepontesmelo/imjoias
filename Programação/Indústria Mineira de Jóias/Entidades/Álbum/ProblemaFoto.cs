using System;
using Acesso.Comum;
using System.Collections;
using System.Data;

namespace Entidades.Álbum
{
	/// <summary>
	/// Summary description for ProblemaFoto.
	/// </summary>
	[Serializable]
	public class ProblemaFoto : DbManipulação
	{
		private string		descricao;
		private string		referencia;
		private DateTime	data;
		private string		usuário;
		private int			digito; // Dígito da mercadoria.
		
		#region Propriedades
		
		/// <summary>
		/// É a descrição sem os chr(13) e chr(10)
		/// </summary>
		public string DescriçãoLinear
		{
			get
			{
				return Descrição.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n","; ");
			}
		}

		public string Descrição
		{
			get { return descricao; }
			set { descricao = value; }
		}
		public string Referência
		{
			get { return referencia; }
			set { referencia = value; }
		}
		
		public string ReferênciaFormatada
		{
			get
			{
				return Entidades.Mercadoria.Mercadoria.MascararReferência(Referência, digito);
			}
		}
		
		public DateTime Data
		{
			get { return data; }
			set { data = value; }
		}
		public string Usuário
		{
			get { return usuário; }
			set { usuário = value; }
		}
		public int Dígito
		{
			get { return digito; }
			set { digito = value; }
		}
		#endregion

        public ProblemaFoto(string referência, string descrição)
        {
            this.descricao = descrição;
            this.referencia = referência;
        }

		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			cmd.CommandText = "INSERT INTO `problemafoto` (`referencia`, `descricao`, `data`, `usuario`) "
				+ " VALUES ("
				+ DbTransformar(referencia) + ", "
				+ DbTransformar(descricao) + ", "
				+ " NOW(), " // Data do BD
				+ DbTransformar(Usuários.UsuárioAtual.Nome) + ")";

			if (cmd.ExecuteNonQuery() == 0)
				throw new Exception("O sistema conseguiu registrar o problema da foto. Nenhuma query foi alterada. \n\n Consulta SQL: " + cmd.CommandText);
		}
		
		protected override void Atualizar(IDbCommand cmd)
		{
			throw new NotImplementedException();
		}

		protected override void Descadastrar(IDbCommand cmd)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Grava no bano de dados que o problema foi resolvido.
        /// </summary>
        public void ResolverProblema()
        {
            IDbCommand commando = Conexão.CreateCommand();

            commando.CommandText = "update problemafoto set resolvido=1 where "
            + " DATA=" + DbTransformar(data)
            + " AND usuario=" + DbTransformar(usuário)
            + " AND referencia=" + DbTransformar(referencia);

            commando.ExecuteNonQuery();
        }

		private enum Ordem { Referência, Descrição, Data, Usuário, Dígito }
		
		public static ArrayList ObterProblemasPendentes()
		{
			IDbConnection conexão = Conexão;
			IDataReader leitor = null;
			ArrayList lista = new ArrayList();

			lock (conexão)
			{
				using (IDbCommand cmd = conexão.CreateCommand())
				{

					cmd.CommandText = 
						"SELECT problemafoto.referencia, descricao, data, usuario, digito from  problemafoto, mercadoria where resolvido=0 AND mercadoria.referencia=problemafoto.referencia";

					leitor = cmd.ExecuteReader();
					try
					{
						while (leitor.Read())
						{
							ProblemaFoto problema = new ProblemaFoto(
								leitor.GetString((int) Ordem.Referência),
								leitor.GetString((int) Ordem.Descrição));
							problema.Data = leitor.GetDateTime((int) Ordem.Data);
							problema.Usuário = leitor.GetString((int) Ordem.Usuário);
							problema.Dígito = Int32.Parse(leitor.GetString((int) Ordem.Dígito));

                            problema.DefinirCadastrado();
							lista.Add(problema);
						}
					}
					finally
					{
						if (leitor != null)
							leitor.Close();
					}
					
					return lista;
				}
			}
		}
	}
}
