using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Estrutura para consulta de ramal.
    /// </summary>
    public struct Ramal
    {
        private string nome;
        private int ramal;
        private ulong funcionário;
        private uint setor;

        public string Nome
        {
            get { return nome; }
        }

        public int Número
        {
            get { return ramal; }
        }

        public ulong Funcionário
        {
            get { return funcionário; }
        }

        public uint Setor 
        {
            get { return setor; }
        }

        public Ramal(string nome, int ramal, ulong funcionário, uint setor)
        {
            this.nome = nome;
            this.ramal = ramal;
            this.funcionário = funcionário;
            this.setor = setor;
        }

        public static Ramal[] ObterRamais()
        {
            IDbConnection conexão;
            List<Ramal> ramais = new List<Ramal>();

            conexão = Acesso.Comum.Usuários.UsuárioAtual.Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    IDataReader leitor;

                    cmd.CommandText = "SELECT p.nome, f.ramal, f.codigo, p.setor FROM pessoa p, funcionario f"
                        + " WHERE p.codigo = f.codigo"
                        + " AND f.dataSaida is null"
                        + " AND ramal > 0 ORDER BY p.nome";

                    using (leitor = cmd.ExecuteReader())
                    {

                        try
                        {
                            while (leitor.Read())
                                ramais.Add(new Ramal(leitor.GetString(0),
                                    leitor.GetInt32(1),
                                    (ulong)leitor.GetInt64(2),
                                    (uint)leitor.GetInt32(3)
                                    ));
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();
                        }
                    }
                }
            }

            return ramais.ToArray();
        }

    }
}
