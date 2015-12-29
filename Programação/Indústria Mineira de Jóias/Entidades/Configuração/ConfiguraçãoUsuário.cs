using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Entidades.Configuração
{
    public class ConfiguraçãoUsuário<TValor> : ConfiguraçãoGlobal<TValor>
    {
        /// <summary>
        /// Constrói uma configuração global.
        /// </summary>
        /// <param name="chave">Chave de configuração.</param>
        /// <param name="valor">Valor da configuração.</param>
        public ConfiguraçãoUsuário(string chave, TValor valorPadrão)
            : base(chave, valorPadrão)
        {
        }

        /// <summary>
        /// Grava uma configuração no banco de dados.
        /// </summary>
        /// <param name="chave">Chave a ser armazenada no banco de dados.</param>
        /// <param name="valor">Valor a ser armazenado na chave.</param>
        protected override void Gravar()
        {
            if (Entidades.Pessoa.Funcionário.FuncionárioAtual == null)
                return;

            lock (ConfiguraçõesUsuário.Instância)
            {
                IDbConnection conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        bool existe;

                        cmd.CommandText = "SELECT COUNT(*) FROM configuracoes WHERE chave = " + DbTransformar(chave)
                            + " AND pessoa = " + DbTransformar(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código);

                        existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                        if (existe)
                            cmd.CommandText = "UPDATE configuracoes SET valor = " + (valor is Boolean ? DbTransformar(valor.ToString()) : DbTransformar(valor))
                                + " WHERE chave = " + DbTransformar(chave)
                                + " AND pessoa = " + DbTransformar(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código);
                        else
                            cmd.CommandText = "INSERT INTO configuracoes (chave, valor, pessoa) VALUES "
                                + "(" + DbTransformar(chave) + ", " + (valor is Boolean ? DbTransformar(valor.ToString()) : DbTransformar(valor)) + ", "
                                + DbTransformar(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código) + ")";

                        cmd.ExecuteNonQuery();
                    }
                }

                ConfiguraçõesUsuário.Instância.Gravar(chave, valor);
            }

            DefinirCadastrado();
        }

        /// <summary>
        /// Lê configuração do banco de dados.
        /// </summary>
        /// <param name="chave">Chave da configuração.</param>
        /// <returns>Valor da configuração.</returns>
        protected override void Carregar()
        {
            ConfiguraçõesUsuário cfgs = ConfiguraçõesUsuário.Instância;
            object obj;

            lock (cfgs)
                obj = cfgs[chave, valor];

            if (obj != null)
                valor = (TValor)Convert.ChangeType(cfgs[chave, valor], typeof(TValor));
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            ConfiguraçõesUsuário cfgs = ConfiguraçõesUsuário.Instância;

            cmd.CommandText = "DELETE FROM configuracoes WHERE chave = " + DbTransformar(chave)
                + " AND pessoa = " + DbTransformar(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código);
            cmd.ExecuteNonQuery();

            cfgs.Remover(chave);
        }
    }
}
