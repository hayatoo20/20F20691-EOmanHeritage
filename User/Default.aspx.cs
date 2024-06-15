using EShopping.Admin; // Import EShopping.Admin namespace
using System; // Import System namespace
using System.Collections.Generic; // Import generic collections namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Data; // Import Data namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web UI controls namespace
namespace EShopping.User // Define EShopping.User namespace
{//
public partial class Default : System.Web.UI.Page // Define partial Default class
{//
SqlConnection con; // Declare SQL connection variable
SqlCommand cmd; // Declare SQL command variable
SqlDataAdapter sda; // Declare SQL data adapter
DataTable dt; // Declare DataTable variable
protected void Page_Load(object sender, EventArgs e) // Page_Load event handler
{//
if (!IsPostBack) // Check if not postback
{//
getCategories(); // Call getCategories method
}//
}//
private void getCategories() // Define getCategories method
{/**/
con = new SqlConnection(Utils.getConnection()); // Initialize SQL connection
cmd = new SqlCommand("Category_Crud", con); // Initialize SQL command
cmd.Parameters.AddWithValue("@Action", "ACTIVECATEGORY"); // Add action parameter
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize DataTable
sda.Fill(dt); // Fill DataTable with data
rCategory.DataSource = dt; // Set repeater data source
rCategory.DataBind(); // Bind data to repeater
}//
 protected void btnSubscribe_Click(object sender, EventArgs e) //
// Subscribe button click event
{//
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Thank you for subscribing us..!"; // Set message text
lblMsg.CssClass = "alert alert-success"; // Set message CSS class
}//
}//
}//
