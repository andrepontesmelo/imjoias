using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.Controles;
using System.Web.UI.HtmlControls;

namespace IMJWeb.Capa
{
    public partial class ModeloFotoCheia : System.Web.UI.Page
    {
        private const string Param_Tema = "tema";

        public string Tema
        {
            get
            {
                string tema = ViewState[Param_Tema] as string;

                if (string.IsNullOrEmpty(tema))
                {
                    tema = Context.Items[Param_Tema] as string;

                    if (string.IsNullOrEmpty(tema))
                        tema = Request[Param_Tema];

                    ViewState[Param_Tema] = tema;
                }

                return tema;
            }
        }

        public string CaminhoTema
        {
            get
            {
                return ResolveClientUrl(string.Concat("~/Capa/", Tema));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tema))
                throw new NotSupportedException("Tema indefinido.");

            if (!Tema.All(c => char.IsLetterOrDigit(c)))
                throw new NotSupportedException("Nome inválido para tema: " + Tema);

            ImgCapa.ImageUrl = string.Format("~/Capa/{0}/550/capa-1.jpg", Tema);
        }
    }
}