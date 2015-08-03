using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.DAO;
using IMJWeb.Dominio;
using System.Threading;
using System.Security.Principal;
using IMJWeb.Dominio.Util;
using Microsoft.Practices.Unity;
using IMJWeb.Servico.Comunicacao;
using System.Transactions;

namespace IMJWeb.Servico.Usuario
{
    /// <summary>
    /// Serviço para efetuação de login do usuário.
    /// </summary>
    public class ServicoUsuario : IDisposable
    {
        [Dependency]
        public IUsuarioDAO UsuarioDAO { get; set; }

        /// <summary>
        /// Efetua login de um usuário.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha fornecida.</param>
        /// <exception cref="IMJWeb.Servico.Usuario.UsuarioNaoEncontradoException">
        /// Login do usuário não encontrado.
        /// </exception>
        /// <exception cref="IMJWeb.Servico.Usuario.SenhaInvalidaException">
        /// Senha fornecida não é válida.
        /// </exception>
        public IUsuario EfetuarLogin(string login, string senha)
        {
            IUsuario usuario = UsuarioDAO.ObterPorLogin(login);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException(login);

            if (!usuario.ValidarSenha(senha))
                throw new SenhaInvalidaException(login);

            UsuarioDAO.RegistrarLogin(usuario);

            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity(login),
                new string[] { });

            return usuario;
        }

        /// <summary>
        /// Obtém o usuário atual.
        /// </summary>
        /// <returns>Usuário atual.</returns>
        [Obsolete("Utilize Session.ObterUsuarioAtual()", true)]
        public IUsuario ObterUsuarioAtual()
        {
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return null;

            return UsuarioDAO.ObterPorLogin(Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        /// Define a senha do usuário.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="novaSenha">Nova senha do usuário.</param>
        public void DefinirSenha(string login, string novaSenha)
        {
            IUsuario usuario = UsuarioDAO.ObterPorLogin(login);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException(login);

            usuario.Senha = novaSenha;

            UsuarioDAO.Atualizar(usuario);
        }

        /// <summary>
        /// Redefine a senha de um usuário, enviando-a por e-mail.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="email">E-Mail do usuário.</param>
        public void RedefinirSenha(string login, string email)
        {
            IUsuario usuario = UsuarioDAO.ObterPorLogin(login);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException(login);

            if (usuario.EMail != email)
                throw new EmailIncorretoException();

            string senha = GerarSenhaAleatoria();
            Correio correio = InjecaoDependencia.Resolver<Correio>();

#if USAR_TRANSACAO
            using (TransactionScope transacao = new TransactionScope())
#endif
            {
#if USAR_TRANSACAO
                using (TransactionScope transacaoIntermediaria = new TransactionScope(TransactionScopeOption.RequiresNew))
#endif
                {
                    usuario.Senha = senha;
                    UsuarioDAO.Atualizar(usuario);
#if USAR_TRANSACAO
                    transacaoIntermediaria.Complete();
#endif
                }

                correio.EnviarRedefinicaoSenha(usuario, senha);
#if USAR_TRANSACAO
                transacao.Complete();
#endif
            }
        }

        /// <summary>
        /// Gera uma senha aleatória.
        /// </summary>
        /// <returns></returns>
        private string GerarSenhaAleatoria()
        {
            Random rnd = new Random();
            byte[] valores = new byte[6];
            StringBuilder str = new StringBuilder();
            
            rnd.NextBytes(valores);

            foreach (byte b in valores)
                str.Append((char)((b % 10) + '0'));

            return str.ToString();
        }

        private List<UsuarioTO> usuarios;

        public List<UsuarioTO> ObterUsuarios()
        {
            if (usuarios != null)
                return usuarios;

            if (UsuarioDAO == null)
                UsuarioDAO = InjecaoDependencia.Resolver<IUsuarioDAO>();

            return usuarios = (from usr in UsuarioDAO.Listar().OrderBy(u => u.Nome)
                               select new UsuarioTO()
                               {
                                   Administrador = usr.Administrador,
                                   EMail = usr.EMail,
                                   IDUsuario = usr.IDUsuario,
                                   IMJ_IDPessoa = usr.IMJ_IDPessoa,
                                   Login = usr.Login,
                                   Nome = usr.Nome,
                                   Senha = "*****",
                                   Tabela = usr.Tabela != null ? (int?)usr.Tabela.IDTabela : null,
                                   UltimoAcesso = usr.UltimoAcesso
                               }).ToList();
        }

        public void AtualizarUsuario(UsuarioTO usuario)
        {
            if (UsuarioDAO == null)
                UsuarioDAO = InjecaoDependencia.Resolver<IUsuarioDAO>();

            UsuarioDAO.Atualizar(usuario);

            if (!string.IsNullOrEmpty(usuario.Senha) && usuario.Senha.Trim('*').Length > 0)
                DefinirSenha(usuario.Login, usuario.Senha);
        }

        public void InserirUsuario(UsuarioTO usuario)
        {
            if (UsuarioDAO == null)
                UsuarioDAO = InjecaoDependencia.Resolver<IUsuarioDAO>();

            if (string.IsNullOrEmpty(usuario.Senha))
                usuario.Senha = GerarSenhaAleatoria();

#if USAR_TRANSACAO
            using (TransactionScope transacao = new TransactionScope())
#endif
            {
#if USAR_TRANSACAO
                using (TransactionScope transacaoIntermediaria = new TransactionScope(TransactionScopeOption.RequiresNew))
#endif
                {
                    UsuarioDAO.Incluir(usuario);
                    DefinirSenha(usuario.Login, usuario.Senha);
#if USAR_TRANSACAO
                    transacaoIntermediaria.Complete();
#endif
                }

                Correio correio = InjecaoDependencia.Resolver<Correio>();

                correio.EnviarCriacaoUsuario(usuario, usuario.Senha);
#if USAR_TRANSACAO
                transacao.Complete();
#endif
            }
        }

        public void ExcluirUsuario(UsuarioTO usuario)
        {
            if (UsuarioDAO == null)
                UsuarioDAO = InjecaoDependencia.Resolver<IUsuarioDAO>();

            UsuarioDAO.Remover(usuario);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (UsuarioDAO != null)
                UsuarioDAO.Dispose();
        }

        #endregion
    }
}
