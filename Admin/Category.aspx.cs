using System;/*Import system namespace*/
using System.Collections.Generic;/*IImport generic collections*/
using System.Data;/*IImport data namespace*/
using System.Data.SqlClient;/*IImport SQL client namespace*/
using System.IO;/*IImport IO functionalities*/
using System.Linq;/*IImport LINQ functionalities*/
using System.Web;/*IImport web functionalities*/
using System.Web.UI;/*Import UI functionalities*/
using System.Web.UI.WebControls;/*IImport web controls*/
namespace EShopping.Admin/*IDefine namespace*/
{/**/
public partial class Category : System.Web.UI.Page/* Define Category
* class,Inherit from Page*/  
{/**/
SqlConnection con;/*Declare SQL connection*/
SqlCommand cmd;/*Declare SQL command*/
SqlDataAdapter sda;/*Declare data adapter*/
DataTable dt;/*Declare data table*/
protected void Page_Load(object sender, EventArgs e)/*
* Page Load event handler,Parameters for handler*/
{/**/
Session["breadCrumbTitle"] = "Manage Category";/*
* Set breadcrumb title,Set to "Manage Category"*/
Session["breadCrumbPage"] = "Category";/*Set breadcrumb page,Set to "Category"*/
if (Session["userId"] == null)  /*If userId session null,Check if null*/
{/**/
Response.Redirect("../User/Login.aspx");/*Redirect to login page,Login page URL*/
}/**/
            else if (Session["roleId"] // If roleId session equals
            .ToString() == "1") // Check if "1"
            {//
                getCategories();// Call getCategories method
                
            }//
            else//
            {//
                Response.Redirect // Redirect to default page
                ("../User/Default.aspx"); // Default page URL
            }//
            lblMsg.Visible = false;/*Hide message label*/
}/**/
private void getCategories()/*Define getCategories method*/
{/**/
con = new SqlConnection     // Initialize SQL connection
(Utils.getConnection()); /*Get connection string*/
cmd = new SqlCommand/*Initialize SQL command*/
("Category_Crud", con); /*Use stored procedure*/
cmd.Parameters.AddWithValue/*Add Action parameter*/
("@Action", "GETALL");  // Set to "GETALL"
cmd.CommandType = CommandType.StoredProcedure;/*Set command
* type,As stored procedure*/
sda = new SqlDataAdapter(cmd);/*Initialize data adapter,Use the command*/
dt = new DataTable();/*Initialize data table*/
sda.Fill(dt);/*Fill data table*/
rCategory.DataSource = dt;/*Set repeater data source,Use filled data table*/
rCategory.DataBind();/*Bind data to repeater*/
}/**/
protected void btnAddOrUpdate_Click(object sender, EventArgs e)// Add
// or update event,// Event parameters
{/**/
string actionName = string.Empty, ///**/ Initialize variables
imagePath = string.Empty,     ///**/ Initialize variables
fileExtension = string.Empty; ///**/ Initialize variables
bool isValidToExecute = false; ///**/ Initialize flag
int categoryId = Convert         // Convert hidden field/**/
.ToInt32(hfCategoryId.Value); // To integer/**/
con = new SqlConnection// Initialize SQL connection
(Utils.getConnection());// Get connection string
cmd = new SqlCommand // Initialize SQL command
("Category_Crud", con);// Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", categoryId == 0 ? // Check categoryId
"INSERT" : "UPDATE"); // Set action accordingly
cmd.Parameters.AddWithValue      // Add CategoryId parameter
("@CategoryId", categoryId); // Set to categoryId
cmd.Parameters.AddWithValue  // Add CategoryName parameter
("@CategoryName", txtCategoryName.Text.Trim()); // Set name
cmd.Parameters.AddWithValue // Add IsActive parameter
("@IsActive", cbIsActive.Checked); // Set checkbox value
if (fuCategoryImage.HasFile) // If file upload has file
{/**/
if (Utils.IsValidExtension // Check file extension
(fuCategoryImage.FileName)) // Validate extension
{/**/
string newImageName = // Generate unique image name
Utils.GetUniqueId(); // Get unique ID
fileExtension = Path     // Get file extension
.GetExtension(fuCategoryImage.FileName); // Get extension
imagePath = "Images/Category/" + // Set image path
newImageName.ToString() + fileExtension; // Full path
fuCategoryImage.PostedFile // Save posted file
.SaveAs(Server.MapPath("~/Images/Category/") + // Save path
newImageName.ToString() + fileExtension); // Full path
cmd.Parameters.AddWithValue // Add image path parameter
("@CategoryImageUrl", imagePath); // Set path
isValidToExecute = true; // Set flag true
}/**/
else/**/
{/**/
lblMsg.Visible = true;// Show message label
lblMsg.Text = "Please Select .jpg, .jpeg or .png images"; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set CSS class
isValidToExecute = false; // Set flag false
}/**/
}/**/
else/**/
{/**/
isValidToExecute = true; // Set flag true
}/**/
if (isValidToExecute)  // If valid to execute
{/**/
cmd.CommandType = // Set command type
CommandType.StoredProcedure; // As stored procedure
try/**/
{/**/
con.Open(); // Open SQL connection
cmd.ExecuteNonQuery(); // Execute command
actionName = categoryId == 0 ? "Added" : "updated"; // Set action name
lblMsg.Visible = true;   // Show message label
lblMsg.Text = "Category " + actionName + " successfully!"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set CSS class
getCategories(); // Refresh categories
clear(); // Clear form fields
}/**/
catch (Exception ex) // Catch exceptions
{/**/
lblMsg.Visible = true;   // Show message label
lblMsg.Text = "Error- " + ex.Message; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set CSS class
}/**/
finally/**/
{/**/
con.Close();// Close SQL connection
}/**/
}/**/
}/**/
protected void rCategory_ItemCommand // Item command event handler
(object source, RepeaterCommandEventArgs e) // Event parameters
{/**/
lblMsg.Visible = false;// Hide message label
if (e.CommandName == "edit") // If command is edit
{/**/
con = new SqlConnection// Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand  // Initialize SQL command
("Category_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", "GETBYID"); // Set to "GETBYID"
cmd.Parameters.AddWithValue // Add CategoryId parameter
("@CategoryId", e.CommandArgument); // Set command argument
cmd.CommandType = // Set command type
CommandType.StoredProcedure; // As stored procedure
sda = new SqlDataAdapter  // Initialize data adapter
(cmd);  // Use the command
dt = new DataTable();// Initialize data table
sda.Fill(dt);// Fill data table
txtCategoryName.Text = dt.Rows[0] // Set text box value
["CategoryName"].ToString(); // Get category name
cbIsActive.Checked = Convert // Set checkbox value
.ToBoolean(dt.Rows[0]// Convert to boolean
["IsActive"]);// Get IsActive value
imagePreview.ImageUrl = string // Set image URL
.IsNullOrEmpty(dt.Rows[0] // Check if empty
["CategoryImageUrl"].ToString()) // Get image URL
? "../Images/No_image.png" // Default image URL
: "../" + dt.Rows[0]["CategoryImageUrl"].ToString(); // Set image URL
imagePreview.Height = 200;  // Set image height
imagePreview.Width = 200;   // Set image width
hfCategoryId.Value = dt.Rows[0] // Set hidden field value
["CategoryId"].ToString(); // Get category ID
btnAddOrUpdate.Text = "Update"; // Set button text
}/**/
else if (e.CommandName == "delete") // If command is delete
{/**/
con = new SqlConnection // Initialize SQL connection
(Utils.getConnection()); // Get connection string
cmd = new SqlCommand  // Initialize SQL command
("Category_Crud", con); // Use stored procedure
cmd.Parameters.AddWithValue // Add Action parameter
("@Action", "DELETE");  // Set to "DELETE"
cmd.Parameters.AddWithValue // Add CategoryId parameter
("@CategoryId", e.CommandArgument); // Set command argument
cmd.CommandType = // Set command type
CommandType.StoredProcedure; // As stored procedure
try/**/
{/**/
con.Open();// Open SQL connection
cmd.ExecuteNonQuery();// Execute command
lblMsg.Visible = true;   // Show message label
lblMsg.Text = "Category Deleted Successfully"; // Set success message
lblMsg.CssClass = "alert alert-success"; // Set CSS class
getCategories(); // Refresh categories
}/**/
catch (Exception ex) // Catch exceptions
{/**/
lblMsg.Visible = true;// Show message label
lblMsg.Text = "Error- " + ex.Message; // Set error message
lblMsg.CssClass = "alert alert-danger"; // Set CSS class
}/**/
finally/**/
{/**/
 con.Close();// Close SQL connection
}/**/
}/**/
}/**/
 protected void btnClear_Click(object // Clear button event handler
sender, EventArgs e)            // Event parameters
{/**/
clear();  // Call clear method
}/**/
void clear()// Define clear method
{/**/
txtCategoryName.Text = string.Empty;// Clear text box,Set to empty
cbIsActive.Checked = false;    // Uncheck checkbox
hfCategoryId.Value = "0";      // Reset hidden field
btnAddOrUpdate.Text = "Add";   // Set button text
imagePreview.ImageUrl = string.Empty;   // Clear image URL,Set to empty
}/**/
}/**/
}/**/
