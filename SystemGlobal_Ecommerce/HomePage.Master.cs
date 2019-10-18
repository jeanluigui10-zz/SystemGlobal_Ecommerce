using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xSystem_Maintenance.src.app_code;
namespace SystemGlobal_Ecommerce
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCloseSession_ServerClick(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("Index.aspx");
        }
    }
}