using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using IMJWeb.Dominio.Util;
using System.Security.Cryptography;

namespace IMJWeb.DAO.EF
{
    partial class Usuario : IUsuario
    {
        #region IUsuario Members

        /// <summary>
        /// Tabela para região de atendimento do cliente.
        /// </summary>
        ITabela IUsuario.Tabela
        {
            get
            {
                if (this.IDTabela.HasValue)
                    return TabelaFlyweight.ObterTabela(this.IDTabela.Value);
                else
                    return null;
            }
        }

        /// <summary>
        /// Valida a senha do usuário.
        /// </summary>
        /// <param name="senha">Senha a ser validada.</param>
        /// <returns>Verdadeiro se a senha está correta.</returns>
        public bool ValidarSenha(string senha)
        {
            if (senha == null)
                throw new ArgumentNullException("senha");

            SHA512 criptografia = SHA512.Create();
            ASCIIEncoding ascii = new ASCIIEncoding();
            
            criptografia.Initialize();
            
            try
            {
                byte[] senhaCriptografada = criptografia.ComputeHash(ascii.GetBytes(senha));
                string senhaFinal = Convert.ToBase64String(senhaCriptografada);

                return this.Senha == senhaFinal;
            }
            finally
            {
                criptografia.Clear();
            }
        }

        /// <summary>
        /// Senha criptografada do usuário.
        /// </summary>
        string IUsuario.Senha
        {
            set
            {
                CriptografarSenha(value);
            }
        }

        #endregion

        /// <summary>
        /// Criptografa uma nova senha do usuário.
        /// </summary>
        /// <param name="senha">Nova senha do usuário.</param>
        public void CriptografarSenha(string senha)
        {
            if (senha == null)
                throw new ArgumentNullException("senha");

            SHA512 criptografia = SHA512.Create();
            ASCIIEncoding ascii = new ASCIIEncoding();

            criptografia.Initialize();

            try
            {
                byte[] senhaCriptografada = criptografia.ComputeHash(ascii.GetBytes(senha));
                string senhaFinal = Convert.ToBase64String(senhaCriptografada);

                this.Senha = senhaFinal;
            }
            finally
            {
                criptografia.Clear();
            }
        }

        public override string ToString()
        {
            return this.Login;
        }
    }
}
