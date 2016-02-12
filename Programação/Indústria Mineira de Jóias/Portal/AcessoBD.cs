using System.Data;
using MySql.Data.MySqlClient;

public class AcessoBD
{
    public static void AssegurarConectado()
    {
        if (Acesso.Comum.DbManipulaçãoSimples.conexãoAlternativa == null)
        {
            IDbConnection conexão;

            string strConexão;
            //int tentativas = 0;

            // "Database=Test;Data Source=localhost;User Id=username;Password=pass	
            strConexão = "Data Source=localhost";
            strConexão += ";Database=imjoias";
            strConexão += ";User Id=imjoias";
            strConexão += ";Password=b9r8hukl3";
            strConexão += ";Pooling=False";
            strConexão += ";Port=3306";

            conexão = new MySqlConnection(strConexão);
            conexão.Open();

            Acesso.Comum.DbManipulaçãoSimples.conexãoAlternativa = conexão;
        }
    }
}
