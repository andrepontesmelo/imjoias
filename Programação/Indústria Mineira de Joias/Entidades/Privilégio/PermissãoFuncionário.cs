using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Privilégio
{
    /// <summary>
    /// Define a permissão de acesso de um funcionário.
    /// </summary>
    public sealed class PermissãoFuncionário : DbManipulaçãoSimples
    {
        private PermissãoFuncionário() { }

        /// <summary>
        /// Valida se usuário atual possui privilégios necessários
        /// utilizando cache.
        /// </summary>
        /// <param name="privilégio">Privilégios necessários.</param>
        /// <exception cref="PermissãoNegada">
        /// Levanta exceção caso funcionário
        /// não possua privilégios suficientes.
        /// </exception>
        public static void AssegurarPermissão(Permissão privilégio)
        {
            if (privilégio != Permissão.Nenhuma)
            {
                Usuário usuário;
                Pessoa.Funcionário funcionário;

                usuário = Usuários.UsuárioAtual;
                funcionário = CacheDb.Instância.ObterEntidade(typeof(Pessoa.Funcionário), usuário.Nome) as Pessoa.Funcionário;

                if ((funcionário.Privilégios & privilégio) != privilégio)
                    throw new PermissãoNegada(funcionário);
            }
        }

        /// <summary>
        /// Valida se usuário atual possui privilégios necessários
        /// utilizando cache.
        /// </summary>
        /// <param name="privilégio">Privilégios necessários.</param>
        /// <returns>Se o usuário atual possui os privilégios necessários.</returns>
        public static bool ValidarPermissão(Permissão privilégio)
        {
            try
            {
                if (privilégio != Permissão.Nenhuma)
                {
                    Usuário usuário;
                    Pessoa.Funcionário funcionário;

                    usuário = Usuários.UsuárioAtual;
                    funcionário = CacheDb.Instância.ObterEntidade(typeof(Pessoa.Funcionário), usuário.Nome) as Pessoa.Funcionário;

                    if ((funcionário.Privilégios & privilégio) == 0)
                        return false;
                }

                return true;
            }
            catch (Exception e)
            {
                try
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                }
                catch { }

                return false;
            }
        }
    }
}
