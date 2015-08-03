using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login_ascx : System.Web.UI.UserControl

{
    public Login_ascx ()
    {
        Load += new EventHandler(Page_Load);
    }
    
    void Page_Load(object sender, EventArgs e)
    {
        
    }

	protected void DadosLogin_Authenticate(object sender, AuthenticateEventArgs e)
	{
		
	}
}
