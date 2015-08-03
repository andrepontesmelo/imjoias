﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using IMJWeb.Sessao;
using System.Security;

namespace IMJWeb.Cadastro
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
    public partial class NovoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session.ObterUsuarioAtual().Administrador)
                throw new SecurityException("Usuário não autorizado.");

            DetailsViewUsuarios.ChangeMode(DetailsViewMode.Insert);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack)
                Response.Redirect("GerenciarUsuarios.aspx");
        }
    }
}
