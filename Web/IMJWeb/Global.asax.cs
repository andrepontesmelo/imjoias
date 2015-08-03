using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using IMJWeb.Servico.Comunicacao;
using IMJWeb.Dominio.Util;
using IMJWeb.Servico.Catalogo;
using IMJWeb.DAO.Db4o;
using System.Web.Configuration;
using System.IO;

namespace IMJWeb
{
    public class Global : System.Web.HttpApplication
    {
        public static String CaminhoEscrita
        {
            get;
            private set;
        }

        static Global()
        {
            CaminhoEscrita = WebConfigurationManager.AppSettings["caminhoEscrita"] ?? System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");

            if (!Directory.Exists(CaminhoEscrita))
                CaminhoEscrita = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");

            try
            {
                String tmp = Path.Combine(CaminhoEscrita, "teste.tmp");

                File.Create(tmp).Close();
                File.Delete(tmp);
            }
            catch
            {
                CaminhoEscrita = Path.GetTempPath();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Mercadorias.CaminhoCacheEmDisco = CaminhoEscrita;
            MercadoriaDAO.CaminhoDB = System.IO.Path.Combine(CaminhoEscrita, "Mercadorias.db4o");
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