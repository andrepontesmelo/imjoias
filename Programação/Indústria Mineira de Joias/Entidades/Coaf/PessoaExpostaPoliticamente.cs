using Acesso.Comum;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Coaf
{
    [DbTabela("pep")]
    public class PessoaExpostaPoliticamente : DbManipulaçãoSimples
    {
        protected string cpf;
        protected string descricao;

        public string Descrição => descricao;
        public string Cpf => cpf;

        public PessoaExpostaPoliticamente()
        {
        }

        public PessoaExpostaPoliticamente(string cpf, string descrição)
        {
            this.cpf = cpf;
            this.descricao = descrição;
        }        

        public static void Persistir(List<PessoaExpostaPoliticamente> pessoas)
        {
            var conexão = Conexão;

            lock (conexão)
            {
                var transação = conexão.BeginTransaction();
                var cmd = conexão.CreateCommand();
                cmd.Transaction = transação;
                cmd.CommandText = "delete from pep";
                cmd.ExecuteNonQuery();

                cmd = conexão.CreateCommand();
                cmd.Transaction = transação;
                cmd.CommandText = ObterSqlInclusão(pessoas);
                cmd.ExecuteNonQuery();
                transação.Commit();
            }
        }

        private static string ObterSqlInclusão(List<PessoaExpostaPoliticamente> pessoas)
        {
            if (pessoas.Count == 0)
                return "";

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("insert into pep (cpf, descricao) values ('");

            foreach (var pessoa in pessoas)
            {
                sql.Append(pessoa.cpf);
                sql.Append("','");
                sql.Append(pessoa.descricao.Trim());
                sql.Append("'),('");
            }

            sql.Remove(sql.Length - 3, 3);

            return sql.ToString();
        }

        public static List<PessoaExpostaPoliticamente> Obter()
        {
            return Mapear<PessoaExpostaPoliticamente>("select * from pep");
        }
    }
}
