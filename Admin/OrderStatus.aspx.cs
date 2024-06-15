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
public partial class OrderStatus : System.Web.UI.Page //
//Define class inheriting Page
{//
SqlConnection con; // Declare SQL connection
SqlCommand cmd; // Declare SQL command
SqlDataAdapter sda; // Declare SQL data adapter
DataTable dt; // Declare data table
protected void Page_Load(object sender, EventArgs e) //
// Page load event handler
{//
if (!IsPostBack) // Check if not postback
{//
Session["breadCrumbTitle"] = "Manage Order Status"; // Set breadcrumb title
Session["breadCrumbPage"] = "Order Status"; // Set breadcrumb page
if (Session["userId"] == null) // Check if user ID null
{//
Response.Redirect("../User/Login.aspx"); // Redirect to login
}//
 if (Session["roleId"].ToString() == "1") // Check if admin role
{//
getOrderStatus(); // Call getOrderStatus method
}//
else if (Session["roleId"].ToString() == "3") // Check if admin role
{//
getOrderStatus(); // Call getOrderStatus method
}//
else // Else block
{//
Response.Redirect("../User/Default.aspx"); // Redirect to default
}//
lblMsg.Visible = false; // Hide message label
}//
pUpdateOrderStatus.Visible = false; // Hide update order status panel
}//
private void getOrderStatus() // Method to get order status
{//
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("Invoice", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "GETSTATUS"); // Add get status action
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
rOrderStatus.DataSource = dt; // Set repeater data source
rOrderStatus.DataBind(); // Bind repeater data
}//
protected void rOrderStatus_ItemCommand(object source,
RepeaterCommandEventArgs e) // Repeater item command
{//
lblMsg.Visible = false; // Hide message label
if (e.CommandName == "edit") // Check if command edit
{//
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("Invoice", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "STATUSBYID"); // Add status by ID action
cmd.Parameters.AddWithValue("@OrderDetailsId", e.CommandArgument); // Add order details ID
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
ddlOrderStatus.SelectedValue = dt.Rows[0]["Status"].ToString(); // Set selected value
hdnId.Value = dt.Rows[0]["OrderDetailsId"].ToString(); // Set hidden ID value
pUpdateOrderStatus.Visible = true; // Show update order status panel
}//
}//
protected void btnUpdate_Click(object sender, EventArgs e) // Update button click event handler
{//
int orderDetailsId = Convert.ToInt32(hdnId.Value); // Get order details ID
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("Invoice", con); // Set stored procedure
cmd.Parameters.AddWithValue("@Action", "UPDTSTATUS"); // Add update status action
cmd.Parameters.AddWithValue("@OrderDetailsId", orderDetailsId); // Add order details ID
cmd.Parameters.AddWithValue("@Status", ddlOrderStatus.SelectedValue); // Add selected status
cmd.CommandType = CommandType.StoredProcedure; // Set command type
try // Begin try block
{//
con.Open(); // Open connection
cmd.ExecuteNonQuery(); // Execute query
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Order status updated successfully!"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set success class
getOrderStatus(); // Refresh order status
}//
catch (Exception ex) // Catch exceptions
{//
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Error - " + ex.Message; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set error class
}//
finally // Finally block
{//
con.Close(); // Close connection
}//
}//
protected void btnCancel_Click(object sender, EventArgs e) // Cancel button click event handler
{//
pUpdateOrderStatus.Visible = false; // Hide update order status panel
}//
}//
}//
