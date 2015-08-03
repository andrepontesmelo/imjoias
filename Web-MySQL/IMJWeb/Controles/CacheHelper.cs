using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace IMJWeb.Controles
{
    public static class CacheHelper
    {
        /// <summary>
        /// Define a política de cache para respostas de foto de mercadorias.
        /// </summary>
        public static void DefinirPoliticaCacheLonga(HttpResponse resposta)
        {
            resposta.Cache.SetCacheability(HttpCacheability.Public);
        }

        /// <summary>
        /// Define a política de cache para respostas de foto de mercadorias.
        /// </summary>
        public static void DefinirPoliticaCacheLonga(this Page pagina)
        {
            DefinirPoliticaCacheLonga(pagina.Response);
        }

        /// <summary>
        /// Define a política de cache para respostas de foto de mercadorias.
        /// </summary>
        public static void DefinirPoliticaCacheCurta(HttpResponse resposta)
        {
            resposta.Cache.SetCacheability(HttpCacheability.Public);
            resposta.Cache.SetExpires(DateTime.Now.AddHours(4));
        }

        /// <summary>
        /// Define a política de cache para respostas de foto de mercadorias.
        /// </summary>
        public static void DefinirPoliticaCacheCurta(this Page pagina)
        {
            DefinirPoliticaCacheLonga(pagina.Response);
        }
    }
}