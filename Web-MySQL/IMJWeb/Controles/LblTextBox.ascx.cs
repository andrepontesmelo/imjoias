using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMJWeb.Controles
{
    public partial class LblTextBox : System.Web.UI.UserControl
    {
        public string Texto { get; set; }
        public bool Obrigatorio { get; set; }
        public bool Opcional { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}