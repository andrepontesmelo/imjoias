using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using IMJWeb.Dominio.Util;

namespace IMJWeb.Servico.Usuario
{
    [Serializable]
    public class UsuarioTO : IUsuario
    {
        #region IUsuario Members

        public long IDUsuario
        {
            get;
            set;
        }

        public string Login
        {
            get;
            set;
        }

        public string Senha
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string EMail
        {
            get;
            set;
        }

        public int? Tabela { get; set; }

        ITabela IUsuario.Tabela
        {
            get { return this.Tabela.HasValue ? TabelaFlyweight.ObterTabela(this.Tabela.Value) : null; }
        }

        public long? IMJ_IDPessoa
        {
            get;
            set;
        }

        public bool ValidarSenha(string senha)
        {
            return this.Senha == senha;
        }

        public bool Administrador
        {
            get;
            set;
        }

        public DateTime? UltimoAcesso
        {
            get;
            set;
        }

        #endregion
    }
}
