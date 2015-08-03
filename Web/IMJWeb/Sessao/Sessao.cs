using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMJWeb.Dominio;
using System.Web.SessionState;

namespace IMJWeb.Sessao
{
    public static class Sessao
    {
        public static IUsuario ObterUsuarioAtual(this HttpSessionState sessao)
        {
            return sessao["usuario"] as IUsuario;
        }

        public static void DefinirUsuarioAtual(this HttpSessionState sessao, IUsuario usuario)
        {
            sessao["usuario"] = usuario;
        }
    }
}