using System;/*It provides basic functions for data  
*types and also imports the system namespace...*/
using System.Collections.Generic;/*It imports the  
* namespace of collections such as dictionaries and lists */
using System.Data;/*It works by accessing data from databases
*  and managing it by importing the namespace.*/
using System.Data.SqlClient;/*It works to 
* access SQL Server data by importing the namespace...*/
using System.Linq;/*Works on LINQ queries by 
* importing the namespace.*/
using System.Web;/*Imports the namespace of 
* an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server 
*elements and pages by  importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the 
 * namespace of ASP.NET web server controls....*/
namespace EShopping.User/*The namespace refers to
* all pages and  categories related to the user...*/
{/**..*/
public partial class Contact : System.Web.UI.Page/*It is 
* inheriting from the ASP.NET Page 
* class where the subclass defines the contact validity...*/
    {/**..*/
        SqlConnection con;/*This object works by 
* connecting to the database...*/
SqlCommand cmd;/*It executes SQL commands...*/
protected void Page_Load(object sender, EventArgs e)/*.It
*  processes the event to load the page.....*/
{/**..*/
}/**..*/
protected void btnSubmit_Click(object sender, EventArgs e)/*...*/
/*Indicates the event handler for an event by pressing the button*/
{/**..*/
try/**..*/
{/**..*/
con = new SqlConnection(Utils.getConnection());/*.It  
* initializes the connection string.....*/
cmd = new SqlCommand("ContactSp", con);/*.It initializes 
* the SQLCommand with the name of
* the stored procedure.....*/
cmd.Parameters.AddWithValue("@Action", "INSERT");/*.Insert a parameter
* to a stored procedure.*/
cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());/*..Refers 
 * to filling out the field by adding the name of user....*/
cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());/*..Refers 
 * to filling out the field by adding the user email....*/
cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());/*..Refers 
 * to filling out the field by adding the user subject....*/
cmd.Parameters.AddWithValue("@Message", txtMessage.Text.Trim());/*..Refers 
 * to filling out the field by adding the user name....*/
cmd.CommandType = CommandType.StoredProcedure; /*....Trying to
* set the command type to the stored procedure.....*/
 con.Open();/*.It opens ....the connection to the database..*/
cmd.ExecuteNonQuery(); /*.Working on implementing it.....*/
lblMsg.Visible = true; /*.It displays the label of the message......*/
lblMsg.Text = "Thanks for reaching out will look into your query!";
lblMsg.CssClass = "alert alert-success";
 clear();/*.Helps clear the 
* fields of the form..*/
}/*...*/
catch (Exception ex)/*..It works to catch general exceptions..*/
{/*...*/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET
* application*/
}/*...*/
finally
{/*...*/
con.Close();/*.It closes the connection to the database....*/
}/**..*/
}/**..*/
private void clear()/*.Helps clear the fields of the form..*/
{/**..*/
txtName.Text = string.Empty;/*.Allows you
* to delete the name from the field.....*/
txtEmail.Text = string.Empty;/*.Allows you
* to delete the email from the field.....*/
txtSubject.Text = string.Empty;/*.Allows you
* to delete the subject from the field.....*/
txtMessage.Text = string.Empty;/*.Allows you
* to delete message from the field.....*/
 }/**..*/
}/**..*/
}/**..*/