using System;/*It provides basic functions for data types  
* and also imports the system namespace...*/
using System.Collections.Generic;/*It imports the  
* namespace of collections such as dictionaries and lists */
using System.Data.SqlClient;/*It works to access 
* SQL Server data by importing the namespace...*/
using System.Data;/*It works by accessing data from databases
*and managing it by importing the namespace.*/
using System.Drawing;/*It processes images and graphics*/
using System.Linq;/*Works on LINQ queries by
* importing the namespace.*/
using System.Security.Cryptography;/*It works on 
 * encryption and security...*/
using System.Web;/*Imports the namespace of an ASP.NET 
* web application*/
using System.Web.UI;/*Controls ASP.NET server elements and 
* pages by importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the namespace of 
 *ASP.NET web server controls....*/
namespace EShopping.User/*The namespace refers to all 
* pages and categories related to the user...*/
{/****/
public partial class Profile : System.Web.UI.Page/*It is inheriting 
* from the ASP.NET Page 
* class where the subclass defines the Profile validity...*/
{/****/
SqlConnection con;/*This object works by connecting
* to the database...*/
SqlCommand cmd;/*It executes..,,, SQL commands...*/
SqlDataAdapter sda;/*...*/
DataTable dt;/*It keeps all query results...*/
protected void Page_Load(object sender, EventArgs e)/*.It processes  
* the event to load the page.....*/
 {/****/
if (!IsPostBack)/*.It verifies whether the 
* page was loaded for the first 
* time... and not for re-posting..*/
 {/****/
if (Session["userId"] == null)/**It represents the beginning of
* the block as it works by ensuring that the user is logged in**/
{/****/
 Response.Redirect("Login.aspx");/*It directs the user to the login page...
**/
}/****/
getUserDetails();/*.It works by calling a method
* to get all the user details.....*/
}/****/
}/****/
private void getUserDetails()/*.It is a method that displays and 
* retrieves user details...*/
{/****/
using (con = new SqlConnection(Utils.getConnection()))/*.It
* initializes 
* the connection string.....*/
{/****/
try/****/
{/****/
cmd = new SqlCommand("User_Crud", con);/*.It initializes 
* the SQLCommand with the name of the stored procedure.....*/
cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE");/*.Adds a parameter
* to a stored procedure.*/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/*.Adds
* the parameter to the user ID.....*/
cmd.CommandType = CommandType.StoredProcedure;/*.It adjusts 
* the type of command based on the stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command.........*/
dt = new DataTable();/* Preparing ... table for data...*/
sda.Fill(dt);/*.Through it, the DATA TABLE is filled with the 
* results of the query.....*/
 if (dt.Rows.Count > 0)/*.It checks whether
* exactly zero record is returned..*/
{/****/
rProfile.DataSource = dt;/*It assigns... data to the source...
*/
rProfile.DataBind();/*Operates using data link control*/
}/****/ 
}/****/
catch (Exception ex)/*..It works to catch general exceptions..*/
{/****/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues ..an error alert message from a user exception in an ASP.NET
* application*/
}/****/
}/****/
}/****/
}/****/
}/****/