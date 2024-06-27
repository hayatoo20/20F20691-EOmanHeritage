using System;/*It provides basic functions for data types and also 
* imports the system namespace......*/
using System.Collections.Generic;/*It imports the namespace of 
* collections such as dictionaries and lists... */
using System.Data;/*It works by accessing data 
* from databases and managing it by importing the namespace....*/
using System.Data.SqlClient;/*It _ works to access SQL Server data
* by importing the namespace...*/
using System.Linq;/*Works on LINQ queries by 
* importing the namespace.*/
using System.Net.Mail;/*Works on the process of 
* sending messages to @mail*/
using System.Net;/*Refers to the functions and
* categories that relate to the network...*/
using System.Web;/*Imports the namespace of an ASP.NET 
* web application*/
using System.Web.Services.Description;/*Import with web
* service description*/
using System.Web.UI;/*Controls ASP.NET server elements and pages by 
* importing the namespaceUsing.... */
using System.Web.UI.WebControls;/*Imports ...the namespace of ASP.NET
 * web server controls.......*/
using System.Xml.Linq;/*It works to query and process
* XML data...*/

namespace EShopping.User/*The namespace refers to all pages and 
* categories related to the user...*/
{/****/
public partial class ForgotPassword : System.Web.UI.Page/*It is 
* inheriting from the ASP.NET Page 
* class where the subclass defines the ForgetPassword validity...*/
{/****/
SqlConnection con;/*This object works by connecting to 
* the database...*/
SqlCommand cmd;/*It executes SQL commands...*/
SqlDataAdapter sda;/****/
DataTable dt;/*It keeps all query results
...*/
static string UserEmail = "20F20691@mec.edu.om";
static string UserPassword = "Oman@2040";
string destinationEmail = string.Empty;
protected void Page_Load(object sender, EventArgs e)/*.It 
* processes the 
* event to load the page.....*/
{/****/
if (Session["userId"] != null)/*It refers to verifying the validity
* of the logged in user, making sure that the userid field is not empty*/
{/****/
Response.Redirect("Default.aspx");/* It refers to directing 
* the user to the home page after verifying that his data is correct...*/
}/****/
lblMsg.Visible = false;/****/
}/****/
protected void btnSubmit_Click(object sender, EventArgs e)/*...*/
/*Indicates the event handler for an event by pressing the button*/
{/****/
try/****/
{/****/
dt = new DataTable();/*Creating a new data table...*/
dt = getUserEmail(txtUsername.Value.Trim());/*It works based
* on the user name to retrieve the email*/
if (dt.Rows.Count == 1)/*It works by checking if user is found 1*/
{/****/
using (SmtpClient client = new SmtpClient("smtp.office365.com", 587))/*
* Refers to the process of setting up a client by using a server...*/
{/****/
destinationEmail = dt.Rows[0]["Email"].ToString();/*Indicates to
* get the user's @email...*/
 string userPassword = dt.Rows[0]["Password"].ToString();/*Indicates
* to obtain the password*** for the user...
*/
string userName = txtUsername.Value.Trim().ToLower();/*Refers to
* dividing the username into lowercase letters...*/
string emailSubject = "Update Regarding Your Password for " +
"E-Oman Heritage login!";/*Refers to updating the password to 
* access the aforementioned system...*/
//emailSubject = emailSubject + " (" + ddlCaseType.SelectedItem.Text.ToString() + ") by " + userName;
 string emailMessage = "Hello "+userName+",<br/>" +
"We Have Received Your Request For Your Password,<br/>" +/**/
"Your password is <b>" + userPassword + "</b><br/><br/><br/>" +
"Thank You<br/>" +
"Team EOmanHeritage(._.)";/*Indicate to create message format...*/
client.EnableSsl = true;/*Helps enable SSL for the client....
*/
client.DeliveryMethod = SmtpDeliveryMethod.Network;/*Used to 
* designate... delivery method...*/
client.UseDefaultCredentials = false;/* It works on 
* adopting default data...
It sets customer data credentials...
*/
client.Credentials = new NetworkCredential
(UserEmail, UserPassword);/*Working on creating a new object...*/
 MailMessage msgObj = new MailMessage();/*Indicate to new message*/
msgObj.To.Add(destinationEmail);/*Adds the email@destination 
* to the message...*/
msgObj.From = new MailAddress(UserEmail);/*It sets the address
* for the sender's @mail*/
msgObj.Subject = emailSubject;/*Sets the @ subject for the mail*/
msgObj.IsBodyHtml = true;/* It adjusts the formatting of @mail to HTML*/
msgObj.Body = emailMessage;/* It works by assigning the 
* text @ to the mail  */
client.Send(msgObj);/*Working on sending email*/
txtUsername.Value = string.Empty;/*Indicates that the field will
* be cleared after processing for the user
*/
string msg = "Your Password is Sent to Your Registered Email <b>"+
destinationEmail +
"</b>. <a href='Login.aspx'>Click to login</a>.";/*It indicates that
* the password has been sent to the registered email address & Click on 
* login to display the success message*/
lblMessage(msg, "success");/*It displays the success message,,,
*/
}/***/
}/***/
else/***/
{/***/
lblMessage("Invalid Username.!", "danger");/*display to wrong entired usernme*/
}/**/
}/**/
catch (Exception ex)/*..It works to catch general exceptions..*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET
* application*/
}/***/
}/***/
private DataTable getUserEmail(string username)
{/***/
con = new SqlConnection(Utils.getConnection());/*.Configures 
* SQL CONNECTON..*/
cmd = new SqlCommand("User_Crud", con); /*.Initializes SQL
 * COMMAND..*/
cmd.Parameters.AddWithValue("@Action", "GETBYUSERNAME");/*.Adds 
* a parameter
* to a stored procedure.*/
cmd.Parameters.AddWithValue("@Username", username);/*.Indicates 
.adding the user name.*/
cmd.CommandType = CommandType.StoredProcedure;/*.It adjusts the type
* of command based on the stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command........*/
dt = new DataTable();/* Preparing ... table for data...*/
sda.Fill(dt);/*.Through it, the DATA TABLE is filled with the 
* results of the query.....*/
return dt;/*It returns @mail information by returning the filled-in data table
*/
        }/***/
void lblMessage(string textMessage, string cssClass)/*Indicates 
* the special type of function return*/
{/***/
lblMsg.Visible = true;/*.It displays the label of the message...*/
lblMsg.Text = textMessage;/*.Sets the text message..*/
lblMsg.CssClass = "alert alert-" + cssClass + "";/*.It alerts  by 
* setting the Css class ..*/
}/***/
}/***/
}/***/