using System; // Import System namespace
using System.Collections.Generic; // Import generic collections
using System.Data; // Import Data namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web UI controls
namespace EShopping.User // Define EShopping.User namespace
{//
public partial class User : System.Web.UI.MasterPage // Define partial User class
{//
SqlConnection con; // Declare SQL connection variable
SqlCommand cmd; // Declare SQL command variable
SqlDataAdapter sda; // Declare SQL data adapter
DataTable dt; // Declare DataTable variable
Utils utils; // Declare Utils variable
protected void Page_Load(object sender, EventArgs e) //
//Page_Load event handler
{//
if (Request.Url.AbsoluteUri.ToString().Contains("Default.aspx")) //
//Check if URL contains Default.aspx
{//
Control sliderUserControl = (Control)Page.LoadControl
("SliderUserControl.ascx"); // Load slider control
pnlSliderUC.Controls.Add(sliderUserControl); // Add slider to panel
}//
if (!IsPostBack) // Check if not postback
{//
getNestedCategories(); // Call getNestedCategories method
}//
if (Session["userId"] != null) // Check if userId session exists
{//
btnLoginOrLogout.Text = "Logout"; // Set button text to Logout
btnRegisterOrProfile.Text = "Profile"; // Set button text to Profile
utils = new Utils(); // Initialize Utils object
Session["wishlistCount"] = utils.itemCount("wishlist"); // Get wishlist count
Session["cartCount"] = utils.itemCount("cart"); // Get cart count
}//
else // If userId session does not exist
{//
btnLoginOrLogout.Text = "Login"; // Set button text to Login
btnRegisterOrProfile.Text = "Register"; // Set button text to Register
Session["cartCount"] = "0"; // Set cart count to 0
Session["wishlistCount"] = "0"; // Set wishlist count to 0
}//
}//
private void getNestedCategories() // Define getNestedCategories method
{//
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
protected void rCategory_ItemDataBound(object sender,
RepeaterItemEventArgs e) // ItemDataBound event handler
{//
if (e.Item.ItemType == ListItemType.Item || e.
Item.ItemType == ListItemType.AlternatingItem) // Check item type
{//
HiddenField categoryId = e.Item.FindControl("hfCategoryId")
as HiddenField; // Find categoryId control
Repeater repSubCategory = e.Item.FindControl("rSubCategory")
as Repeater; // Find subcategory repeater
con = new SqlConnection(Utils.getConnection()); // Initialize SQL connection
cmd = new SqlCommand("SubCategory_Crud", con); // Initialize SQL command
cmd.Parameters.AddWithValue("@Action", "ACTIVEBYID"); // Add action parameter
cmd.Parameters.AddWithValue("@CategoryId", Convert.
ToInt32(categoryId.Value)); // Add categoryId parameter
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize DataTable
sda.Fill(dt); // Fill DataTable with data
if (dt.Rows.Count > 0) // Check if data exists
{//
repSubCategory.DataSource = dt; // Set subcategory data source
repSubCategory.DataBind(); // Bind data to subcategory
}//
}//
}//
protected void btnLoginOrLogout_Click(object sender,
 EventArgs e) // Login or Logout button click event
{//
if (Session["userId"] == null) // Check if userId session does not exist
{//
Response.Redirect("Login.aspx"); // Redirect to Login page
}//
else // If userId session exists
{//
Session.Abandon(); // Abandon session
Response.Redirect("Login.aspx"); // Redirect to Login page
}//
}//
protected void btnRegisterOrProfile_Click(object sender, EventArgs e) // Register or Profile button click event
{//
if (Session["userId"] != null) // Check if userId session exists
{//
Response.Redirect("Profile.aspx"); // Redirect to Profile page
}//
else // If userId session does not exist
{//
Response.Redirect("Registration.aspx"); // Redirect to Registration page
}//
}//
}//
}//
