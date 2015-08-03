using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Importador
{
    public class Importador
    {
        private System.Data.OleDb.OleDbConnection cOrigem;
        private MySql.Data.MySqlClient.MySqlConnection cDestino;

        private Dictionary<string, uint> localidades = new Dictionary<string,uint>();
        public volatile bool Cancelar = false;
        private int qtdLogradouros = 0;
        private int qtdImportado = 0;

        public Importador(string origem)
        {
            cDestino = new MySql.Data.MySqlClient.MySqlConnection(
                "Data Source=imj.no-ip.com" +
                ";Database=imjoias" +
                ";User Id=root" +
                ";Password=***REMOVED***" +
                ";Pooling=False" +
                ";Port=46033");

            cDestino.Open();

            cOrigem = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + origem);
            cOrigem.Open();

            IDbCommand cmd = cOrigem.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM LOG_LOGRADOURO";
            qtdLogradouros = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "SELECT COUNT(*) FROM LOG_LOCALIDADE";
            qtdLogradouros += Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int QtdLogradouros { get { return qtdLogradouros; } }
        public int QtdImportado { get { return qtdImportado; } }

        private  void ImportadorLocalidades()
        {
            using (IDbCommand cmd = cOrigem.CreateCommand())
            {
                cmd.CommandText = "SELECT UFE_SG, LOC_NO, CEP FROM LOG_LOCALIDADE";

                IDataReader leitor = cmd.ExecuteReader();

                using (IDbCommand cmdDestino = cDestino.CreateCommand())
                {
                    while (leitor.Read() && !Cancelar)
                    {
                        uint localidade;

                        cmdDestino.CommandText = "SELECT l.codigo FROM localidade l JOIN estado e ON l.estado = e.codigo WHERE e.sigla = '"
                            + leitor.GetString(0) + "' AND l.nome = '" + leitor.GetString(1).Replace("'", @"\'") + "'";

                        localidade = Convert.ToUInt32(cmdDestino.ExecuteScalar());

                        localidades.Add(leitor.GetString(0) + leitor.GetString(1), localidade);

                        if (!leitor.IsDBNull(2))
                        {
                            cmdDestino.CommandText = "INSERT INTO cep (cep, localidade, logradouro, bairro) VALUES (" +
                                "'" + leitor.GetString(2) + "', " +
                                "'" + localidade.ToString().Replace("'", @"\'") + "', " +
                                "NULL, NULL)";
                            cmdDestino.ExecuteNonQuery();
                        }

                        qtdImportado++;
                    }

                    leitor.Close();
                }
            }
        }

        private void ImportadorLogradouros()
        {
            using (IDbCommand cmd = cOrigem.CreateCommand())
            {
                cmd.CommandText = "SELECT loc.UFE_SG, loc.LOC_NO, LOG_NOME, log.CEP, b.BAI_NO FROM LOG_LOCALIDADE loc, LOG_LOGRADOURO log, LOG_BAIRRO b WHERE loc.LOC_NU_SEQUENCIAL = log.LOC_NU_SEQUENCIAL AND b.BAI_NU_SEQUENCIAL = log.BAI_NU_SEQUENCIAL_INI";

                IDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read() && !Cancelar)
                {
                    using (IDbCommand cmdDestino = cDestino.CreateCommand())
                    {
                            cmdDestino.CommandText = "INSERT INTO cep (cep, localidade, logradouro, bairro) VALUES (" +
                                "'" + leitor.GetString(3) + "', " +
                                "'" + localidades[leitor.GetString(0) + leitor.GetString(1)].ToString() + "', " +
                                "'" + leitor.GetString(2).Replace("'", @"\'") + "', " +
                                "'" + leitor.GetString(4).Replace("'", @"\'") + "')";
                            cmdDestino.ExecuteNonQuery();
                    }

                    qtdImportado++;
                }

                leitor.Close();
            }
        }
    
        public void Importar()
        {
            ImportadorLocalidades();
            ImportadorLogradouros();
        }
    }
}
