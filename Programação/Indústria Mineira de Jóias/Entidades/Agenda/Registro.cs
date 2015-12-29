using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Agenda
{
    [DbTabela("agenda")]
    public class Registro : DbManipulaçãoAutomática
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set 
            { 
                nome = value.Trim();
                palavraschave = Acentuação.Singleton.TirarAcentos(nome.ToLower());
            }
        }

        private string palavraschave;

        [DbColuna("telfixo")]
        private string telFixo;

        public string TelFixo
        {
            get { return telFixo; }
            set { telFixo = value; }
        }

        [DbColuna("telcelular")]
        private string telCelular;

        public string TelCelular
        {
            get { return telCelular; }
            set { telCelular = value; }
        }

        [DbColuna("teloutro")]
        private string telOutro;

        public string TelOutro
        {
            get { return telOutro; }
            set { telOutro = value; }
        }

        [DbColuna("endcidade")]
        private string endCidade;

        public string EndCidade
        {
            get { return endCidade; }
            set { endCidade = value; }
        }

        [DbColuna("endestado")]
        private string endEstado;

        public string EndEstado
        {
            get { return endEstado; }
            set { endEstado = value; }
        }

        public Registro()
        {
        }

        public Registro(string nome, string telFixo, string telCelular, string telOutro, string endCidade, string endEstado)
        {
            Nome = nome.Trim();
            this.telFixo = telFixo;
            this.telCelular = telCelular;
            this.telOutro = telOutro;
            this.endCidade = endCidade;
            this.endEstado = endEstado;
        }


        /// <summary>
        /// Altera dados da agenda
        /// </summary>
        public static void Alterar(string antigoNome, string nome, string telFixo, string telCelular, string telOutro, string cidade, string estado)
        {
            IDbConnection conexão = Conexão;
          
            string consulta;
            consulta = "UPDATE agenda SET "
                + " nome = " + DbTransformar(nome)
                + ", telfixo = " + DbTransformar(telFixo)
                + ", telcelular = " + DbTransformar(telCelular)
                + ", teloutro = " + DbTransformar(telOutro)
                + ", endcidade = " + DbTransformar(cidade)
                + ", endestado = " + DbTransformar(estado)
                + ", palavraschave = " + DbTransformar(Acentuação.Singleton.TirarAcentos(nome.Trim().ToLower()))
                + " WHERE nome = " + DbTransformar(antigoNome);

              lock (conexão)
              {
                  using (IDbCommand cmd = conexão.CreateCommand())
                  {
                      cmd.CommandText = consulta;
                      cmd.ExecuteNonQuery();
                  }
              }
         }

        public static bool VerificarExistência(string nome)
        {
            IDbConnection conexão = Conexão;
            bool existe;

            string consulta = "SELECT count(*) from agenda where nome = " + DbTransformar(nome.Trim());

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = consulta;
                    existe = ((long) cmd.ExecuteScalar() == 1);
                }
            }

            return existe;
        }

        public static void Excluir(string nome)
		{
            IDbConnection conexão = Conexão;
            string consulta;
            consulta = "DELETE FROM agenda where nome = "
                + DbTransformar(nome.Trim());

              lock (conexão)
              {
                  IDbCommand cmd = conexão.CreateCommand();
                  cmd.CommandText = consulta;
                  cmd.ExecuteNonQuery();
              }
        }

        public static List<Registro> Buscar(string nome)
        {
            IDbConnection conexão = Conexão;
            List<Registro> registros = new List<Registro>();

            string consulta = "SELECT * from agenda where palavraschave like '%" + 
                Acentuação.Singleton.TirarAcentos(nome.Trim().ToLower().Replace("'", "")) + "%'";

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = consulta;
                    Mapear<Registro>(cmd, registros);
                }
            }

            return registros;
        }
    }
}
