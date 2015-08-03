using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace IMJWeb
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Context.Items["tema"] = Request["tema"] ?? WebConfigurationManager.AppSettings["tema"];
            Server.Transfer("~/Capa/ModeloFotoCheia.aspx", true);
        }
    }
}