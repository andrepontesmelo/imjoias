using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.DAO.Azure;

namespace IMJWeb.Azure.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MercadoriaDAO dao = new MercadoriaDAO();

            dao.Obter("201.200");
        }
    }
}