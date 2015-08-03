using System;
using Acesso.Comum;
using System.Collections;
using System.Data;

namespace Entidades.�lbum
{
	/// <summary>
	/// Summary description for ProblemaFoto.
	/// </summary>
	[Serializable]
	public class ProblemaFoto : DbManipula��o
	{
		private string		descricao;
		private string		referencia;
		private DateTime	data;
		private string		usu�rio;
		private int			digito; // D�gito da mercadoria.
		
		#region Propriedades
		
		/// <summary>
		/// � a descri��o sem os chr(13) e chr(10)
		/// </summary>
		public string Descri��oLinear
		{
			get
			{
				return Descri��o.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n","; ");
			}
		}

		public string Descri��o
		{
			get { return descricao; }
			set { descricao = value; }
		}
		public string Refer�ncia
		{
			get { return referencia; }
			set { referencia = value; }
		}
		
		public string Refer�nciaFormatada
		{
			get
			{
				return Entidades.Mercadoria.Mercadoria.MascararRefer�ncia(Refer�ncia, digito);
			}
		}
		
		public DateTime Data
		{
			get { return data; }
			set { data = value; }
		}
		public string Usu�rio
		{
			get { return usu�rio; }
			set { usu�rio = value; }
		}
		public int D�gito
		{
			get { return digito; }
			set { digito = value; }
		}
		#endregion

        public ProblemaFoto(string refer�ncia, string descri��o)
        {
            this.descricao = descri��o;
            this.referencia = refer�ncia;
        }

		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			cmd.CommandText = "INSERT INTO `problemafoto` (`referencia`, `descricao`, `data`, `usuario`) "
				+ " VALUES ("
				+ DbTransformar(referencia) + ", "
				+ DbTransformar(descricao) + ", "
				+ " NOW(), " // Data do BD
				+ DbTransformar(Usu�rios.Usu�rioAtual.Nome) + ")";

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
            IDbCommand commando = Conex�o.CreateCommand();

            commando.CommandText = "update problemafoto set resolvido=1 where "
            + " DATA=" + DbTransformar(data)
            + " AND usuario=" + DbTransformar(usu�rio)
            + " AND referencia=" + DbTransformar(referencia);

            commando.ExecuteNonQuery();
        }

		private enum Ordem { Refer�ncia, Descri��o, Data, Usu�rio, D�gito }
		
		public static ArrayList ObterProblemasPendentes()
		{
			IDbConnection conex�o = Conex�o;
			IDataReader leitor = null;
			ArrayList lista = new ArrayList();

			lock (conex�o)
			{
				using (IDbCommand cmd = conex�o.CreateCommand())
				{

					cmd.CommandText = 
						"SELECT problemafoto.referencia, descricao, data, usuario, digito from  problemafoto, mercadoria where resolvido=0 AND mercadoria.referencia=problemafoto.referencia";

					leitor = cmd.ExecuteReader();
					try
					{
						while (leitor.Read())
						{
							ProblemaFoto problema = new ProblemaFoto(
								leitor.GetString((int) Ordem.Refer�ncia),
								leitor.GetString((int) Ordem.Descri��o));
							problema.Data = leitor.GetDateTime((int) Ordem.Data);
							problema.Usu�rio = leitor.GetString((int) Ordem.Usu�rio);
							problema.D�gito = Int32.Parse(leitor.GetString((int) Ordem.D�gito));

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
