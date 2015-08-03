using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.ComissãoCálculo
{
    /// <summary>
    /// Tabela de percentuais de comissão.
    /// </summary>
    public class ComissãoSetorFaixa : DbManipulaçãoSimples
    {
        public Setor Setor { get; set; }
        public Dictionary<char, double> HashComissões { get; set; }

        public static ComissãoSetorFaixa ObterTabela(Setor setor)
        {
            ComissãoSetorFaixa encontrado = null;
            HashTabelas.TryGetValue(setor.Código, out encontrado);

            return encontrado;
        }

        private static Dictionary<uint, ComissãoSetorFaixa> hashTabelas = null;
        /// <summary>
        /// Dado o código do setor, retorna a tabela de comissão dele.
        /// </summary>
        private static Dictionary<uint, ComissãoSetorFaixa> HashTabelas
        {
            get
            {
                if (hashTabelas == null)
                {
                    IDbConnection conexão = Conexão;
                    IDbCommand cmd = null;
                    IDataReader leitor = null;

                    hashTabelas = new Dictionary<uint, ComissãoSetorFaixa>();
                    ComissãoSetorFaixa tabelaAtual = null;

                    lock (conexão)
                    {
                        using (cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = "select setor, faixa, valor from comissaosetorfaixa";
                            using (leitor = cmd.ExecuteReader())
                            {
                                while (leitor.Read())
                                {
                                    uint setor = (uint) leitor.GetInt32(0);
                                    char faixa = leitor.GetChar(1);
                                    double valor = leitor.GetDouble(2);

                                    if (tabelaAtual == null || (tabelaAtual.Setor.Código != setor))
                                    {
                                        tabelaAtual = new ComissãoSetorFaixa();
                                        hashTabelas.Add(setor, tabelaAtual);
                                        tabelaAtual.Setor = Setor.ObterSetor(setor);
                                        tabelaAtual.HashComissões = new Dictionary<char, double>();
                                    }

                                    tabelaAtual.HashComissões[faixa] = valor;
                                }

                                leitor.Close();
                            }
                        }
                    }

                }

                return hashTabelas;
            }
        }
    }
}
