using System; // Import system namespace
using System.Collections.Generic; // Import collections namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Data; // Import data namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web controls namespace
namespace EShopping.Admin // Define namespace
{/**/
public partial class Profile : System.Web.UI.Page // Define class inheriting Page
{/**/
SqlConnection con; // Declare SQL connection
SqlCommand cmd; // Declare SQL command
SqlDataAdapter sda; // Declare SQL data adapter
DataTable dt; // Declare data table
protected void Page_Load(object sender, EventArgs e) // Page load event handler
{/**/
if (!IsPostBack) // Check if not postback
{/**/
Session["breadCrumbTitle"] = "Admin Profile"; // Set breadcrumb title
Session["breadCrumbPage"] = "Profile"; // Set breadcrumb page
if (Session["userId"] == null) // Check if user ID null
{/**/
Response.Redirect("../User/Login.aspx"); // Redirect to login
}/**/
else if (Session["roleId"].ToString() == "1") // Check if admin role
{/**/
getProfileDetails(); // Call getProfileDetails method
}/**/
else // Else block
{/**/
Response.Redirect("../User/Default.aspx"); // Redirect to default
}/**/
}/**/
}/**/
private void getProfileDetails() // Method to get profile details//
{/**/
using (con = new SqlConnection(Utils.getConnection())) //
// Use SqlConnection with Utils
{/**/
try // Begin try block
{/**/
cmd = new SqlCommand("User_Crud", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE"); // Add select action
cmd.Parameters.AddWithValue("@UserId", Session["userId"]); // Add user ID
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
if (dt.Rows.Count > 0) // Check if rows exist
{/**/
rProfile.DataSource = dt; // Set repeater data source
rProfile.DataBind(); // Bind repeater data
}/**/
}/**/
catch (Exception ex) // Catch exceptions
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>"); // Show error message
}/**/
}/**/
}/**/
}/**/
}
