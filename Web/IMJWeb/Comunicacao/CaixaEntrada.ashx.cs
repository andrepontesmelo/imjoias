using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMJWeb.Servico.Comunicacao;
using IMJWeb.Dominio.Util;
using System.Threading;

namespace IMJWeb.Comunicacao
{
    /// <summary>
    /// Summary description for CaixaEntrada
    /// </summary>
    public class CaixaEntrada : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var pares = ChaveValor.Interpretar(context.Request.Form["dados"]);
            string strCategoria = context.Request.Form["categoria"];
            Correio.Categoria categoria = (Correio.Categoria)Enum.Parse(typeof(Correio.Categoria), strCategoria, true);

            ThreadPool.QueueUserWorkItem(delegate(object obj)
            {
                int tentativa = 0;

                while (tentativa++ < 3)
                {
                    try
                    {
                        Correio correio = InjecaoDependencia.Resolver<Correio>();
                        correio.Enviar(categoria, pares);
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }

            });

            context.Response.StatusCode = 204;
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}