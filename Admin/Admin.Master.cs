using System; // Import system namespace
using System.Collections.Generic; // Import collections namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web controls namespace

namespace EShopping.Admin // Define namespace
{
    public partial class Admin : System.Web.UI.MasterPage // Define class inheriting MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) // Page load event handler
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e) // Logout button click event handler
        {
            Session.Abandon(); // Abandon session
            Response.Redirect("../User/Login.aspx"); // Redirect to login page
        }
    }
}
