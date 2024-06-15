using System;// Import system namespace..
using System.Collections.Generic;// Import generic collections..
using System.Data;// Import data namespace...
using System.Data.SqlClient;// Import SQL client namespace...
using System.Linq;// Import LINQ functionalities...
using System.Web;// Import web functionalities...
using System.Web.UI;// Import UI functionalities...
using System.Web.UI.WebControls;// Import web controls...
namespace EShopping.Admin// Define namespace...
{//
public partial class SubCategory : System.Web.UI.Page//
// Define SubCategory class, Inherit from Page...
{//
SqlConnection con;// Declare SQL connection
SqlCommand cmd;// Declare SQL command
SqlDataAdapter sda;// Declare data adapter
DataTable dt;// Declare data table
protected void Page_Load // Page Load event handler
(object sender, EventArgs e) // Parameters for handler
{//
Session["breadCrumbTitle"] // Set breadcrumb title
= "Manage Sub-Category"; // Set to "Manage Sub-Category"
Session["breadCrumbPage"]  // Set breadcrumb page
= "Sub-Category"; // Set to "Sub-Category"
if (!IsPostBack)// If not postback
{//
if (Session["userId"] == null) // If userId session null
// Check if null
{//
Response.Redirect // Redirect to login page
("../User/Login.aspx"); // Login page URL
}//
else if (Session["roleId"] // If roleId session equals
.ToString() == "1") // Check if "1"
{//
getCategories();// Call getCategories method
getSubCategories(); // Call getSubCategories method
}//
else//
{//
Response.Redirect // Redirect to default page
("../User/Default.aspx"); // Default page URL
}//
}//
lblMsg.Visible = false;// Hide message label
}//
private void getCategories()   // Define getCategories method
{//
con = new SqlConnection // Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand // Initialize SQL command
("Category_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", "GETALL"); // Set to "GETALL"
cmd.CommandType =// Set command type
CommandType.StoredProcedure; // As stored procedure
sda = new SqlDataAdapter // Initialize data adapter
(cmd);// Use the command
dt = new DataTable(); // Initialize data table
sda.Fill(dt);// Fill data table
ddlCategory.DataSource = dt;// Set dropdown data source
 // Use filled data table
ddlCategory.DataTextField = "CategoryName"; // Set text field
ddlCategory.DataValueField = "CategoryId"; // Set value field
ddlCategory.DataBind();// Bind data to dropdown
}//
private void getSubCategories() // Define getSubCategories method
{//
con = new SqlConnection // Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand // Initialize SQL command
("SubCategory_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", "GETALL"); // Set to "GETALL"
cmd.CommandType =// Set command type
CommandType.StoredProcedure; // As stored procedure
 sda = new SqlDataAdapter // Initialize data adapter
(cmd); // Use the command
dt = new DataTable(); // Initialize data table
sda.Fill(dt);// Fill data table
rSubCategory.DataSource =  // Set repeater data source
dt;// Use filled data table
rSubCategory.DataBind(); // Bind data to repeater
}//
protected void btnAddOrUpdate_Click // Add or update event
(object sender, EventArgs e) // Event parameters
{//
string actionName = string.Empty; // Initialize variable
int subCategoryId = Convert   // Convert hidden field
.ToInt32(hfSubCategoryId.Value); // To integer
con = new SqlConnection // Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand // Initialize SQL command
("SubCategory_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue   // Add Action parameter
("@Action", subCategoryId == 0 ? // Check subCategoryId
"INSERT" : "UPDATE"); // Set action accordingly
cmd.Parameters.AddWithValue // Add SubCategoryId parameter
("@SubCategoryId", subCategoryId); // Set subCategoryId
cmd.Parameters.AddWithValue   // Add SubCategoryName parameter
("@SubCategoryName", txtSubCategoryName.Text.Trim()); // Set name
cmd.Parameters.AddWithValue   // Add CategoryId parameter
("@CategoryId", Convert.ToInt32(ddlCategory.SelectedValue)); // Set category ID
cmd.Parameters.AddWithValue   // Add IsActive parameter
("@IsActive", cbIsActive.Checked); // Set checkbox value
cmd.CommandType = // Set command type
CommandType.StoredProcedure; // As stored procedure
try//
{//
con.Open();// Open SQL connection
cmd.ExecuteNonQuery();// Execute command
actionName = subCategoryId == 0 ? "Added" : "updated"; // Set action name
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Sub-Category " + actionName + " successfully!"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set CSS class
getSubCategories(); // Refresh subcategories
clear();// Clear form fields
}//
catch (Exception ex) // Catch exceptions
{//
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Error- " + ex.Message; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set CSS class
}//
finally//
{//
con.Close(); // Close SQL connection
}//
}//
protected void rSubCategory_ItemCommand // Item command event handler
            (object source, RepeaterCommandEventArgs e) // Event parameters
{//
lblMsg.Visible = false; // Hide message label
if (e.CommandName == "edit") // If command is edit
{//
con = new SqlConnection  // Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand     // Initialize SQL command
("SubCategory_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", "GETBYID"); // Set to "GETBYID"
cmd.Parameters.AddWithValue // Add SubCategoryId parameter
("@SubCategoryId", e.CommandArgument); // Set command argument
cmd.CommandType = // Set command type
CommandType.StoredProcedure; // As stored procedure
sda = new SqlDataAdapter // Initialize data adapter
(cmd);// Use the command
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
txtSubCategoryName.Text = dt.Rows[0] // Set text box value
["SubCategoryName"].ToString(); // Get subcategory name
ddlCategory.SelectedValue = dt.Rows[0] // Set dropdown value
["CategoryId"].ToString(); // Get category ID
cbIsActive.Checked = Convert // Set checkbox value
.ToBoolean(dt.Rows[0] // Convert to boolean
["IsActive"]);       // Get IsActive value
hfSubCategoryId.Value = dt.Rows[0] // Set hidden field value
["SubCategoryId"].ToString(); // Get subcategory ID
btnAddOrUpdate.Text = "Update"; // Set button text
}//
else if (e.CommandName == "delete") // If command is delete
{//
con = new SqlConnection  // Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand     // Initialize SQL command
("SubCategory_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", "DELETE"); // Set to "DELETE"
cmd.Parameters.AddWithValue // Add SubCategoryId parameter
("@SubCategoryId", e.CommandArgument); // Set command argument
cmd.CommandType = // Set command type
CommandType.StoredProcedure; // As stored procedure
try//
{//
con.Open();// Open SQL connection
cmd.ExecuteNonQuery(); // Execute command
lblMsg.Visible = true; // Show message label
lblMsg.Text = "SubCategory Deleted Successfully!"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set CSS class
getSubCategories(); // Refresh subcategories
}//
catch (Exception ex) // Catch exceptions
{//
lblMsg.Visible = true; // Show message label
lblMsg.Text = "Error- " + ex.Message; // Set error message
 lblMsg.CssClass = "alert alert-danger"; // Set CSS class
}//
finally//
{//
con.Close(); // Close SQL connection
}//
}//
}//
protected void btnClear_Click(object // Clear button event handler
sender, EventArgs e)// Event parameters
{//
clear();// Call clear method
}//
void clear() // Define clear method
{//
txtSubCategoryName.Text = string.Empty; // Clear text box
// Set to empty
ddlCategory.ClearSelection();// Clear dropdown selection
cbIsActive.Checked = false;// Uncheck checkbox
hfSubCategoryId.Value = "0";// Reset hidden field
btnAddOrUpdate.Text = "Add";// Set button text
}//
}//
}//
