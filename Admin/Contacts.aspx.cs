using System; // Import system namespace
using System.Collections.Generic; // Import collections namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Data; // Import data namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web controls namespace
namespace EShopping.Admin // Define namespace
{//
public partial class Contacts : System.Web.UI.Page //
//Define class inheriting Page
{//
SqlConnection con; // Declare SQL connection
SqlCommand cmd; // Declare SQL command
SqlDataAdapter sda; // Declare SQL data adapter
DataTable dt; // Declare data table
protected void Page_Load(object sender, EventArgs e) //
//Page load event handler
{//
Session["breadCrumbTitle"] = "Manage Contacts"; // Set breadcrumb title
Session["breadCrumbPage"] = "Contacts"; // Set breadcrumb page
if (Session["userId"] == null) // Check if user ID null
{//
Response.Redirect("../User/Login.aspx"); // Redirect to login
}//
else if (Session["roleId"].ToString() == "1") // Check if admin role
{//
getContacts(); // Call getContacts method
}//
else // Else block
{//
Response.Redirect("../User/Default.aspx"); // Redirect to default
}//
lblMsg.Visible = false; // Hide message label
}//
private void getContacts() // Method to get contacts
{//
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("ContactSp", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "SELECT"); // Add select action
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
rContacts.DataSource = dt; // Set repeater data source
rContacts.DataBind(); // Bind repeater data
}//
protected void rContacts_ItemCommand(object source, RepeaterCommandEventArgs e) // Repeater item command
{//
if (e.CommandName == "delete") // Check if command delete
{//
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("ContactSp", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "DELETE"); // Add delete action
cmd.Parameters.AddWithValue("@ContactId", e.CommandArgument); // Add contact ID
cmd.CommandType = CommandType.StoredProcedure; // Set command type
try // Begin try block
{//
con.Open(); // Open connection
cmd.ExecuteNonQuery(); // Execute query
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Record deleted successfully!"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set success class
getContacts(); // Refresh contact list
}//
catch (Exception ex) // Catch exceptions
{//
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Error- " + ex.Message; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set error class
}//
finally // Finally block
{//
con.Close(); // Close connection
}//
}//
}//
}//
}//
