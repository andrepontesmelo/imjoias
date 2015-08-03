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
    public partial class Modelo_01 : System.Web.UI.Page
    {
        protected enum Temas
        {
            Azul, Roxo
        }

        protected Temas Tema { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string tema = Request.QueryString["tema"];

            Tema = Temas.Roxo;

            if (!string.IsNullOrEmpty(tema))
            {
                switch (tema)
                {
                    case "azul":
                        Tema = Temas.Azul;
                        break;
                }
            }
        }
    }
}