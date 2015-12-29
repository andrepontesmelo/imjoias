using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Configuração
{
    /// <summary>
    /// Conjunto de configurações de um usuário.
    /// </summary>
    /// <remarks>
    /// Esta classe é singleton.
    /// </remarks>
    class ConfiguraçõesUsuário : DbManipulaçãoSimples
    {
        /// <summary>
        /// Hash contendo configurações do usuário.
        /// </summary>
        private Dictionary<string, object> hashConfigurações;

        /// <summary>
        /// Tamanho mínimo para a tabela hash.
        /// </summary>
        /// <remarks>
        /// Recomendável utilização de números primos.
        /// </remarks>
        private const int tamanhoMínimoHash = 23;

        #region Singleton

        /// <summary>
        /// Instância única (singleton).
        /// </summary>
        private static ConfiguraçõesUsuário instância = null;

        /// <summary>
        /// Instância única contendo configurações do usuário.
        /// </summary>
        public static ConfiguraçõesUsuário Instância
        {
            get
            {
                if (instância == null)
                    instância = new ConfiguraçõesUsuário();

                return instância;
            }
        }

        #endregion

        /// <summary>
        /// Carrega todas as configurações do usuário.
        /// </summary>
        private ConfiguraçõesUsuário()
        {
            if (Entidades.Pessoa.Funcionário.FuncionárioAtual == null)
            {
                hashConfigurações = new Dictionary<string, object>();
                return;
            }

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    int qtd;
                    IDataReader leitor;

                    /* Tentando melhorar a utilização de memória,
                     * será verificado antes quantos registros existem,
                     * alocando 1/3 a mais para a hash, reduzindo assim
                     * o número de colisões e realocações.
                     */
                    cmd.CommandText = "SELECT COUNT(*) FROM configuracoes WHERE pessoa = "
                        + DbTransformar(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código);

                    qtd = Convert.ToInt32(cmd.ExecuteScalar());

                    // 1/3 a mais é um valor considerado ideal na literatura.
                    hashConfigurações = new Dictionary<string, object>(Math.Max(qtd + qtd / 3, tamanhoMínimoHash), StringComparer.Ordinal);


                    // Recuperar os dados.
                    cmd.CommandText = "SELECT chave, valor FROM configuracoes WHERE pessoa = "
                        + DbTransformar(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código);

                    using (leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (leitor.Read())
                                hashConfigurações.Add(leitor.GetString(0), leitor.GetValue(1));
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();

                            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Obtém valor da chave.
        /// </summary>
        /// <param name="chave">Chave procurada.</param>
        /// <param name="padrão">Valor padrão.</param>
        /// <returns>Valor da chave.</returns>
        public object this[string chave, object padrão]
        {
            get
            {
                object valor;

                if (hashConfigurações.TryGetValue(chave, out valor))
                    return valor;

                return padrão;
            }
        }

        /// <summary>
        /// Grava valor da chave na tabela hash.
        /// </summary>
        /// <param name="valor">Valor a ser gravado.</param>
        public void Gravar(string chave, object valor)
        {
            hashConfigurações[chave] = valor;
        }

        public void Remover(string chave)
        {
            hashConfigurações.Remove(chave);
        }
    }
}
