using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Configuração
{
    public class ConfiguraçãoGlobal<TValor> : DbManipulação
    {
        /// <summary>
        /// Chave da configuração.
        /// </summary>
        protected string chave;

        /// <summary>
        /// Valor da configuração.
        /// </summary>
        protected TValor valor;

        /// <summary>
        /// Constrói uma configuração global.
        /// </summary>
        /// <param name="chave">Chave de configuração.</param>
        /// <param name="valor">Valor da configuração.</param>
        public ConfiguraçãoGlobal(string chave, TValor valorPadrão)
        {
            this.chave = chave;
            this.valor = valorPadrão;

            Carregar();
        }

        /// <summary>
        /// Valor da configuração.
        /// </summary>
        /// <remarks>
        /// Alterações são automaticamente gravadas no banco de dados.
        /// </remarks>
        public TValor Valor
        {
            get { return valor; }
            set
            {
                valor = value;
                Gravar();
            }
        }

        /// <summary>
        /// Conversão implícita da configuração para o valor.
        /// </summary>
        public static implicit operator TValor(ConfiguraçãoGlobal<TValor> cfg)
        {
            return cfg.valor;
        }

        /// <summary>
        /// Grava uma configuração no banco de dados.
        /// </summary>
        /// <param name="chave">Chave a ser armazenada no banco de dados.</param>
        /// <param name="valor">Valor a ser armazenado na chave.</param>
        protected virtual void Gravar()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    bool existe;

                    cmd.CommandText = "SELECT COUNT(*) FROM `config-globais` WHERE chave = " + DbTransformar(chave);

                    existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                    if (existe)
                        cmd.CommandText = "UPDATE `config-globais` SET valor = " + (valor is Boolean ? DbTransformar(valor.ToString()) : DbTransformar(valor))
                            + " WHERE chave = " + DbTransformar(chave);
                    else
                        cmd.CommandText = "INSERT INTO `config-globais` (chave, valor) VALUES "
                            + "(" + DbTransformar(chave) + ", " + (valor is Boolean ? DbTransformar(valor.ToString()) : DbTransformar(valor)) + ")";

                    cmd.ExecuteNonQuery();
                }
            }

            DefinirCadastrado();

            lock (CacheChaves.Instância)
            {
                CacheChaves.Instância.TodosValoresBd = null;
            }
        }

        /// <summary>
        /// Lê configuração do banco de dados.
        /// </summary>
        /// <param name="chave">Chave da configuração.</param>
        /// <returns>Valor da configuração.</returns>
        protected virtual void Carregar()
        {
            lock (CacheChaves.Instância)
            {
                if (CacheChaves.Instância.TodosValoresBd == null)
                    CacheChaves.Instância.TodosValoresBd = CarregarTodosValores();

            }

            Object obj;
            if (CacheChaves.Instância.TodosValoresBd.TryGetValue(chave, out obj))
            {
                if (!(obj is DBNull) && obj != null)
                {
                    valor = (TValor)Convert.ChangeType(obj, typeof(TValor));
                    DefinirCadastrado();
                }
            }
        }

        private static SortedDictionary<string, object> CarregarTodosValores()
        {
            IDataReader leitor = null;
            SortedDictionary<string, object> retorno = new SortedDictionary<string, object>();

             try
             {
                IDbConnection conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT chave, valor FROM `config-globais`"; // WHERE chave = " + DbTransformar(chave);

                        using (leitor = cmd.ExecuteReader()) {
                            while (leitor.Read()) {
                                retorno.Add(leitor.GetString(0), leitor.GetValue(1));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (Acesso.Comum.Usuários.UsuárioAtual != null)
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }

             return retorno;
        }

        #region Manipulação não suportada

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        protected override void Descadastrar(System.Data.IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM `config-globais` WHERE chave = " + DbTransformar(chave);
            cmd.ExecuteNonQuery();
        }

        #endregion
    }
}
