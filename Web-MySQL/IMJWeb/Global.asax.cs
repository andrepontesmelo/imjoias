using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using IMJWeb.Servico.Comunicacao;
using IMJWeb.Dominio.Util;
using IMJWeb.Servico.Catalogo;

namespace IMJWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Mercadorias.CaminhoCacheEmDisco = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
#if !DEBUG
            try
            {
                var ex = Server.GetLastError();

                Correio correio = InjecaoDependencia.Resolver<Correio>();

                correio.Enviar(ex);
            }
            catch { }
#endif
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}