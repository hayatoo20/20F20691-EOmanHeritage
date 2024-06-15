using System;/*It provides basic functions for data types and also 
* imports the system namespace...*/
using System.Collections.Generic;/*It imports the namespace of 
* collections such as dictionaries and lists */
using System.Data.SqlClient;/*It works to access SQL Server data
* by importing the namespace...*/
using System.Data;/*It works by accessing data 
* from databases and managing it by importing the namespace.*/
 using System.Linq;/*Works on LINQ queries by importing the namespace.*/
using System.Web;/*Imports the namespace of an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server elements and pages by 
* importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the namespace of ASP.NET
 * web server controls....*/
 using System.IO;/*It imports the namespace to complete the input and output operations*/
namespace EShopping.User/*The namespace refers to all pages and 
* categories related to the user...*/
{
public partial class Registration : System.Web.UI.Page/*It is 
* inheriting from the ASP.NET Page 
* class where the subclass defines the registration validity...*/
{
SqlConnection con;/*This object works by connecting to the database...*/
SqlCommand cmd;/*It executes SQL commands...*/
SqlDataAdapter sda;/*...*/
DataTable dt;/*It keeps all query results
...*/
protected void Page_Load(object sender, EventArgs e)/*.It processes the 
* event to load the page.....*/
{
if (!IsPostBack)/*.It verifies whether the page was loaded for the first 
* time... and not for re-posting..*/
{
if (Request.QueryString["id"] != null && Session["userId"] != null)/*.It checks 
* whether the user is logged in by checking whether the identifier is in the query string
..*/
{
getUserDetails();/*.It works by calling a method to get all the user details.....*/
}
else if (Session["userId"] != null)/*.It verifies that the user is logged 
* in, so that there is no ID in... the query string.....*/
{/*...*/
Response.Redirect("Default.aspx");/*.It works by redirecting to the 
* default page......*/
}/*...*/
}/*...*/
}/*.>>..*/
void getUserDetails()/*.It is a method that displays and 
* retrieves user details...*/
{/*.>>..*/
con = new SqlConnection(Utils.getConnection());/*.It initializes 
* the connection string.....*/
cmd = new SqlCommand("User_Crud", con);/*.It initializes 
* the SQLCommand with the name of the stored procedure.....*/
cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE");/*.Adds a parameter
* to a stored procedure.*/
cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);/*.Adds
* the parameter to the user ID.....*/
cmd.CommandType = CommandType.StoredProcedure;/*.It adjusts the type
* of command based on the stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command.........*/
dt = new DataTable();/* Preparing ... table for data...*/
 sda.Fill(dt);/*.Through it, the DATA TABLE is filled with the 
* results of the query.....*/
if (dt.Rows.Count == 1)/*.It checks whether
* exactly one record is returned..*/
{/*......*/
 txtName.Text = dt.Rows[0]["Name"].ToString();/*..Refers 
 * to filling out the field by adding the name of user....*/
txtUsername.Text = dt.Rows[0]["Username"].ToString();/*Refers 
 * to filling out the field by adding the UserName of user....*/
txtMobile.Text = dt.Rows[0]["Mobile"].ToString();/*.Refers 
 * to filling out the field by adding the user mobile no...*/
txtEmail.Text = dt.Rows[0]["Email"].ToString();/*.
 * to filling out the field by adding the email of user...*/
txtAddress.Text = dt.Rows[0]["Address"].ToString();/*.Refers 
 * to filling out the field by adding the address of user...*/
 txtPostCode.Text = dt.Rows[0]["PostCode"].ToString();/*..Refers 
* Refers 
 * to filling out the field by adding the Postcode of user..*/
imgUser.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["ImageUrl"].
ToString())/*Refers 
 * to filling out the field by adding the image of user profile....*/
? "../Images/No_image.png" : "../" + dt.Rows[0]["ImageUrl"].
ToString();/*...*/
imgUser.Height = 200;/*.Refer to the Heigt of image..*/
imgUser.Width = 200;/*.Refer to the width of image..*/
imgUser.Style.Remove("display");/*...*/
txtPassword.TextMode = TextBoxMode.SingleLine;/*...*/
txtPassword.ReadOnly = true;/*...*/
txtPassword.Text = dt.Rows[0]["Password"].ToString();/*...*/
}/*...*/
lblHeaderMsg.Text = "Update Profile";/*.Indicates the
* update of the profile ..*/
btnRegisterOrUpdate.Text = "Update";/*.Indicates 
* that the text for the button has changed to Update..*/
lblAlreadyUser.Text = "";/*. Indicates scanning text
* for label..*/
}/*...*/
protected void btnRegisterOrUpdate_Click(object sender, EventArgs e)/*...*/
/*Indicates the event handler for an event by pressing the button*/
{/*...*/
string actionName = string.Empty, imagePath = string.Empty, fileExtension 
= string.Empty;/*.Indicates the declaration of variables
..*/
bool isValidToExecute = false;/*. It prepares the tag for execution..*/
int userId = Convert.ToInt32(Request.QueryString["id"]);/*.The user 
* ID is obtained from the query string.....*/
con = new SqlConnection(Utils.getConnection());/*.Configures 
* SQL CONNECTON..*/
cmd = new SqlCommand("User_Crud", con);/*.Initializes SQL 
* COMMAND..*/
cmd.Parameters.AddWithValue("@Action", userId == 0 ?
"INSERT" : "UPDATE");/*.It adds and updates the action 
* parameter based on the user ID.....*/
cmd.Parameters.AddWithValue("@UserId", userId);/*...*/
cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());/*.Indicates 
.adding the user ID.*/
cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());/*.Indicates 
.adding the user Name..*/
cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());/*.Indicates 
.adding the user mobile no..*/
cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());/*..Indicates 
.adding the user email.*/
cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());/*.Indicates 
.adding the user Address..*/
cmd.Parameters.AddWithValue("@PostCode", txtPostCode.Text.Trim());/*.Indicates 
.adding the user postcode..*/
cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());/*.Indicates 
.adding the user password..*/
if (fuUserImage.HasFile)/*.It works by verifying that the image is added....*/
{/*...*/
if (Utils.IsValidExtension(fuUserImage.FileName))/*It checks the validity
* of the file extension......*/
{/*...*/
string newImageName = Utils.GetUniqueId();/*..It creates a unique name 
* for the image.*/
fileExtension = Path.GetExtension(fuUserImage.FileName);/*.It works
* to get the file extension...  ..*/
imagePath = "Images/User/" + newImageName.ToString() + fileExtension;/*..It sets
* the correct path for the image....*/
fuUserImage.PostedFile.SaveAs(Server.MapPath("~/Images/User/") + newImageName.
ToString() + fileExtension);/*.It saves the file that... has been downloaded...   
..*/
cmd.Parameters.AddWithValue("@ImageUrl", imagePath); /*.It adds the 
* parameter to the image path*/
 isValidToExecute = true;/*.It works by setting the correct mark..*/
}/*...*/
else/*...*/
{/*...*/
lblMsg.Visible = true;/*..Displays the label for the message....*/
lblMsg.Text = "Please Select .jpg, .jpeg, .png Images";/*.Indicates
* the type of image to be selected along with an error message if an 
* image is uploaded otherwise.....*/
lblMsg.CssClass = "alert alert-danger";/*...*/
isValidToExecute = false;/*.Indicates a danger alert, as it sets
* the Css class..*/
}/*...*/
}/*...*/
else/*...*/
{/*...*/
isValidToExecute = true;/*.If no file is uploaded, it sets 
* the flag to true..*/
}/*...*/
if (isValidToExecute)/*.It checks the correctness of
* the implementation..*/
{/*...*/
cmd.CommandType = CommandType.StoredProcedure;/*.Trying to
* set the command type to the stored procedure.....*/
try/*...*/
{/*...*/
con.Open();/*.It opens the connection to the database.....*/
cmd.ExecuteNonQuery();/*.Working on implementing it.....*/
actionName = userId == 0 ?/*...*/
"Registration is Successful! <b><a href='Login.aspx'>Click Here</a>" +
"</b> to do login" :
"Details Updated Successful! <b><a href='Profile.aspx'>Check Here</a>" +
"</b>";/*.Action message set......*/
lblMsg.Visible = true;/*.It displays the label of the message......*/
 lblMsg.Text = "<b>" + txtUsername.Text.Trim() + "</b> " +
actionName;/*.Works
* to set the message for success......*/
lblMsg.CssClass = "alert alert-success";/*.It activates the success alert 
* by setting the css class..*/
if (userId != 0)/*...*/
{/*...*/
Response.AddHeader("REFRESH", "3;URL=Profile.aspx");/*.The redirect
* to the profile page works for 3 seconds.....*/
}/*...*/
clear();/*.Indicates that the fields of the form are cleared..*/
}/*...*/
catch (SqlException ex)/*.Catches exceptions for SQL>>..*/
{/*...*/
if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))/*.It
* checks for violation of the unique key..*/
{/*...*/
lblMsg.Visible = true;/*..It displays the label of the message...
....*/
lblMsg.Text = "<b>" + txtUsername.Text.Trim() + "</b>" +
" This UserName is" +
" Already Exist, Try a New UserName..";/*..It indicates that 
* there is a username with the same name and a different username 
* must be chosen.*/
lblMsg.CssClass = "alert alert-danger";/*It sets a css class*/
}/*...*/
}/*...*/
catch (Exception ex)/*..It works to catch general exceptions..*/
{/*...*/
lblMsg.Visible = true;/*.It displays the label of the message...*/
lblMsg.Text = "Error-" + ex.Message;/*.Sets the error message..*/
lblMsg.CssClass = "alert alert-danger";/*.It alerts the danger by 
* setting the Css class ..*/
}/*...*/
finally/*...*/
{/*...*/
con.Close();/*.It closes the connection to the database....
..*/
}/*...*/
}/*...*/
}/*...*/
void clear()/*.Helps clear the fields of the form..*/
{
txtName.Text = string.Empty;/*.Allows you
* to delete the name from the field.....*/
txtUsername.Text = string.Empty;/*.Allows you
* to delete the USERNAME from the field..*/
txtMobile.Text = string.Empty;/*.Allows you
* to delete the MOBILE from the field..*/
txtEmail.Text = string.Empty;/*.Allows you
* to delete the EMAIL from the field..*/
txtAddress.Text = string.Empty;/*.Allows you
* to delete the ADDRESS from the field..*/
txtPostCode.Text = string.Empty;/*.Allows you
* to delete the POSTCODE from the field..*/
txtPassword.Text = string.Empty;/*.Allows you
* to delete the PASSWORD from the field..*/
}/*...*/
}/*...*/
}/*...*/