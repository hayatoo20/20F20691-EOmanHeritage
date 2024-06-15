using System;/*It provides basic functions for data types and also 
* imports the ...system namespace...*/
using System.Collections.Generic;/*It imports the namespace of 
* collections such as... dictionaries and lists */
using System.Data.SqlClient;/*It works to access SQL Server data
* by ...importing the namespace...*/
using System.Data;/*It works ....by accessing data 
* from databases and managing it by importing the namespace.*/
using System.Linq;/*Works on ..LINQ queries by importing the namespace.*/
using System.Web;/*Imports the namespace of an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server elements and pages by 
* importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the namespace of ASP.NET
 * web server controls....*/
namespace EShopping.User/*The namespace refers to all pages and 
* categories related to the user...*/
{/*..*/
public partial class Login : System.Web.UI.Page/*It is inheriting 
* from the ASP.NET Page 
* class where the subclass defines the Login validity...*/
 {/*..*/
SqlConnection con;/*This object works by connecting to the database...*/
SqlCommand cmd;/*It executes SQL commands...*/
SqlDataAdapter sda;
DataTable dt;/*It keeps all query results...*/
protected void Page_Load(object sender, EventArgs e)/*.It processes 
* the event to load the page.....*/
{/*...*/
if (Session["userId"] != null)/*It refers to verifying the validity
* of the logged in user, making sure that the userid field is not empty*/
{/*...*/
Response.Redirect("Default.aspx");/*It refers to directing the user 
* to the home page after verifying that his data is correct...*/
}/*...*/
}/*...*/
protected void btnLogin_Click(object sender, EventArgs e)/*...*/
/*Indicates the event handler for an event by pressing the button*/
{/*...*/
            try /*...*/
{/*...*/
con = new SqlConnection(Utils.getConnection());/*.It initializes 
* the connection string.....*/
cmd = new SqlCommand("User_Crud", con);/*.It initializes 
* the SQLCommand with the name of the stored procedure.....*/
cmd.Parameters.AddWithValue("@Action", "SELECT4LOGIN");/*.Adds a parameter
* to a stored procedure.*/
cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());/*.Indicates 
.adding the UserName....*/
cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());/*.Indicates 
.adding the Password.*/
cmd.CommandType = CommandType.StoredProcedure;/*.It adjusts the type
* of command based on the stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command.........*/
dt = new DataTable();/* Preparing ... table for data...*/
sda.Fill(dt);/*.Through it, the DATA TABLE is filled with the 
* results of the query.....*/
if (dt.Rows.Count == 1)/*.It checks whether
* exactly one record is returned..*/
{/*...*/
                    if (Convert.ToInt32(dt.Rows[0]["RoleId"]) == 1) /* It checks the
* ID of the role in the Datatable. If the role number is equal to
* 1, it gives the user the responsibility of admin. */
                    {
                        /*Refers to the storage data for role ID 1*/
                        Session["userId"] = dt.Rows[0]["UserId"];/* Store the user id for role id (1)*/
                        Session["roleId"] = dt.Rows[0]["RoleId"];/* Store the role id (1)*/
                        Session["loggedInName"] = dt.Rows[0]["Name"];/* Store the user name for role id (1)*/
                        Session["loggedInImage"] = dt.Rows[0]["ImageUrl"];/* Store the user imagefor role id (1)*/
                        Response.Redirect("../Admin/Dashboard.aspx", false);/*It indicates that the user'
* s ID number, first floor, is directed to the admin page... The False parameter
* also indicates that the current page will not be stopped while allowing the 
* execution of suspended code to continue...
*/
                    }
                    else if (Convert.ToInt32(dt.Rows[0]["RoleId"]) == 3) /* It checks the
* ID of the role in the Datatable. If the role number is equal to
* 2, it gives the user the responsibility of Vendor. */
                    {
                        /*Refers to the storage data for role ID 2*/
                        Session["userId"] = dt.Rows[0]["UserId"];/* Store the user id for role id (2)*/
                        Session["roleId"] = dt.Rows[0]["RoleId"];/* Store the role id (1)*/
                        Session["loggedInName"] = dt.Rows[0]["Name"];/* Store the user 
* login name for role id (2)*/
                        Session["loggedInImage"] = dt.Rows[0]["ImageUrl"];
                        Response.Redirect("../Admin/Product.aspx", false);/*It indicates that the user'
* s ID number, first role, is directed to the Product page... The False parameter
* also indicates that the current page will not be stopped 
*/
                        Response.Redirect("../Admin/ProductList.aspx", false);
                        Response.Redirect("../Admin/OrderStatus.aspx", false);
                    }/*...*/
                    else
                    {/*...*/
                        Session["userId"] = dt.Rows[0]["UserId"]; /*Refers to the storage 
* data for all users except user with role 1 & 2*/
                        Session["username"] = txtUsername.Text.Trim();/* Store the user 
* user username for the users*/
                        Session["name"] = dt.Rows[0]["Name"];/* Store the user 
* user name for the users*/
                        Response.Redirect("Default.aspx", false);/*It indicates that the user'
*is directed to the Dehault page(home page)... 
* The False parameter
* also indicates that the current page will not be stopped 
*/
                    }/*...*/
                }/*...*/
                else/*...*/
                {/*...*/
                    lblMsg.Visible = true;/*..Displays the label for the message....*/
                    lblMsg.Text = "Invalid UserName Or Password..!";/*/Refer to invalid 
* enter user name or password*/
                    lblMsg.CssClass = "alert alert-danger";/*...*/
                }/*...*/
            }/*...*/
            catch (Exception ex)/*..It works to catch general exceptions..*/
            {/*...*/
                Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET
* application*/
            }/*...*/
        }/*...*/
    }/*...*/
}/*...*/
