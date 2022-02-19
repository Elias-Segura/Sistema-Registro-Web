using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaRegistro.CapaIntegracion;
namespace SistemaRegistroWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CheckLogin(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
            Server.Transfer("frmMenu.aspx");
        }
    }
}