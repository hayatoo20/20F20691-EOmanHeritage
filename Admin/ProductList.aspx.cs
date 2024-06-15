using System; // Import system namespace
using System.Collections.Generic; // Import collections namespace
using System.Data; // Import data namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Drawing; // Import drawing namespace
using System.Linq; // Import LINQ namespace
using System.Security.Cryptography; // Import cryptography namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web controls namespace
using System.Xml.Linq; // Import XML namespace
namespace EShopping.Admin // Define namespace
{//
public partial class ProductList : System.Web.UI.Page // Define class inheriting Page
{//
SqlConnection con; // Declare SQL connection
SqlCommand cmd; // Declare SQL command
DataTable dt; // Declare data table
ProductDAL productDAL; // Declare product data access layer
protected void Page_Load(object sender, EventArgs e) // Page load event handler
{//
Session["breadCrumbTitle"] = "Product List"; // Set breadcrumb title
Session["breadCrumbPage"] = "ProductList"; // Set breadcrumb page
if (!IsPostBack) // Check if first load
{//
if (Session["userId"] == null) // Check if user ID null
{//
Response.Redirect("../User/Login.aspx"); // Redirect to login
}//
if (Session["roleId"].ToString() == "1") // Check if admin role
{
getProducts(); // Call getProducts method
}//
else if (Session["roleId"].ToString() == "3") // Check if admin role
{//
getProducts(); // Call getProducts method
}//
else // Else block
{//
Response.Redirect("../User/Default.aspx"); // Redirect to default
}//
}//
lblMsg.Visible = false; // Hide message label
}//
private void getProducts() // Method to get products
{//
productDAL = new ProductDAL(); // Instantiate product DAL
dt = new DataTable(); // Initialize data table
dt = productDAL.ProductsWithDefaultImg(); // Get products with images
rProductList.DataSource = dt; // Set repeater data source
rProductList.DataBind(); // Bind repeater data
}//
protected void rProductList_ItemCommand(object source,
RepeaterCommandEventArgs e) // Repeater item command
{//
lblMsg.Visible = false; // Hide message label
 if (e.CommandName == "edit") // Check if command edit
{//
Response.Redirect("Product.aspx?id=" +
e.CommandArgument); // Redirect to edit page
}//
else if (e.CommandName == "delete") // Check if command delete
{//
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("Product_Crud", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "DELETE"); // Add delete action
cmd.Parameters.AddWithValue("@ProductId", e.CommandArgument); // Add product ID
cmd.CommandType = CommandType.StoredProcedure; // Set command type
try // Begin try block
{//
con.Open(); // Open connection
cmd.ExecuteNonQuery(); // Execute query
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Product deleted successfully!"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set success class
getProducts(); // Refresh product list
}//
catch (Exception ex) // Catch exceptions
{//
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Error : " + ex.Message; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set error class
}//
finally // Finally block
{//
con.Close(); // Close connection
}//
}//
}//
protected void rProductList_ItemDataBound(object sender,
RepeaterItemEventArgs e) // Repeater item data bound
{//
if (e.Item.ItemType == ListItemType.Item || e.
Item.ItemType == ListItemType.AlternatingItem) // Check item type
{//
Label lbQuantity = e.Item.FindControl("lblQuantity") 
as Label; // Find quantity label
if (Convert.ToInt32(lbQuantity.Text) <= 5) // Check quantity value
{//
lbQuantity.CssClass = "badge badge-danger"; // Set CSS class
lbQuantity.ToolTip = "Item about to be 'Out of stock'!"; // Set tooltip text
}//
}//
}//
}//
}//
