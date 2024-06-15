using EShopping.Admin;
using System;/*It provides basic 
* functions for data types and also */
using System.Collections.Generic;/*It imports the namespace of 
* collections such as... dictionaries and lists */
using System.Data;/*It works ....by accessing data 
* from databases and managing it by importing the namespace.*/
using System.Data.SqlClient;/*It works to access
*  * SQL Server databy importing the namespace...*/
using System.Linq;/*Works on ..LINQ queries by importing the namespace.*/
using System.Web;/*Imports the namespace of
* an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server  
* elements and pages by...importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the namespace of ASP.NET
 * web server controls....*/
namespace EShopping.User/*The namespace  
* refers to all pages and..categories related to the user...*/
{/**/
public partial class Wishlist : System.Web.UI.Page/*It is 
* inheriting from the ASP.NET Page class where the subclass
*  defines the SHOPDETAILS validity...*/
{/**/
SqlConnection con;/*This object works by 
* connecting to the database...*/
SqlCommand cmd;/*This object works by connecting to the database...*/
SqlDataAdapter sda;/*// Declare a SqlDataAdapter object
* to fill DataTable with the result set.*/
DataTable dt;/*It keeps all query results...*/
Utils utils;/* Declare a Utils object,
* which might contain utility methods used throughout the code.*/
protected void Page_Load(object sender, EventArgs e)/*// Page_Load event handler, 
* which executes when the page loads.*/
{/**/
if (!IsPostBack)/*// Check if the page is
* being loaded for the first time and
* not in response to a postback.*/
{/**/
if (Session["userId"] == null)/*// Check if the user is not logged in*/
{/**/
Response.Redirect("Login.aspx");/*// Redirect to login page if not logged in*/
}/**/
getWishlistItem();/*// Call the method to get the wishlist items*/
}/**/
}/**/
private void getWishlistItem()/*// Method to get wishlist items for the logged-in user*/
{/**/
if (Session["userId"] != null)/*// Check if the user is logged in*/
{/**/
using (con = new SqlConnection(Utils.getConnection()))/*// Establish a new SQL connection*/
{/**/
try/**/
{/**/
cmd = new SqlCommand("Wishlist_Crud", con);/*Create a new SQL command for
* stored procedure*/
cmd.Parameters.AddWithValue("@Action", "SELECTBYUSERID");/*Set action 
* parameter to select by user ID*/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/*Add user ID parameter*/
cmd.CommandType = CommandType.StoredProcedure;/*Define command type
* as stored procedure*/
sda = new SqlDataAdapter(cmd);/*Create a data adapter*/
dt = new DataTable();/*Create a new DataTable*/
sda.Fill(dt);/*Fill the DataTable with the result of the SQL command*/
if (dt.Rows.Count > 0)/*Check if any rows are returned*/
{/**/
rWishlist.DataSource = dt;/*Bind the DataTable to the wishlist repeater*/
}/**/
else/**/
{/**/
rWishlist.DataSource = dt;/*Bind an empty DataTable*/ 
rWishlist.FooterTemplate = null;/*Clear the footer template*/
rWishlist.FooterTemplate = new CustomTemplate(ListItemType.Footer);/*Set
* a custom footer template*/
}/**/
rWishlist.DataBind();/*Bind the data to the repeater*/
}/**/
catch (Exception ex)/*Catch any exceptions*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*Display
* an alert with the exception message*/
}/**/
}/**/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx", false);/*Redirect to login page if not logged in*/
}/**/
}/**/
protected void rWishlist_ItemCommand(object source, RepeaterCommandEventArgs e)/*Method 
* to handle commands for wishlist items*/
{/**/
utils = new Utils();/*Create an instance of the Utils class*/
if (e.CommandName == "remove")/*Check if the command is to remove an item*/
{/**/
using (con = new SqlConnection(Utils.getConnection()))/*Establish a new SQL connection*/
{/**/
try/**/
{/**/
cmd = new SqlCommand("Wishlist_Crud", con);/*Create a new SQL command
* for stored procedure*/
cmd.Parameters.AddWithValue("@Action", "DELETE");/*Set action
* parameter to delete*/
cmd.Parameters.AddWithValue("@WishlistId", Convert.ToInt32(e.CommandArgument.ToString()));/*
* Add wishlist ID parameter*/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/*Add user ID parameter*/
cmd.CommandType = CommandType.StoredProcedure;/*Define command
* type as stored procedure*/
con.Open();/*Open the SQL connection*/
cmd.ExecuteNonQuery();/*Execute the command*/
lblMessage("Item removed successful", "success");/*Display success message*/
getWishlistItem();/*Refresh the wishlist*/
Session["wishlistCount"] = utils.itemCount("wishlist");/*Update the wishlist count*/
}/**/
catch (Exception ex)/*Catch any exceptions*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*
* Display an alert with the exception message*/
}/**/
}/**/
}/**/
 else // Add To Cart..
{/**/
try/**/
{/**/
if (Session["userId"] != null)/* Check if the user is logged in*/
{/**/
//HtmlInputText quantity = (HtmlInputText)(e.Item.FindControl("txtQuantity"));
///*Optional: get quantity from input*/
int quantityFromCart = 1; //Convert.ToInt32(quantity.Value);/*Set
//quantity to 1 (can be replaced with input value)*/
int productId = Convert.ToInt32(e.CommandArgument.ToString());/*Get
* product ID from command argument*/
int savedQuantity = utils.cartItemExistReturnQuantity(productId);/*Check
* if item already exists in the cart*/
if (savedQuantity == 0) //Adding new item into cart/**/
{/**/
int r = utils.addOrUpdateCartItem(productId, quantityFromCart, "INSERT");/*
* Add item to the cart*/
if (r > 0)/*If insertion is successful*/
{/**/
Session["cartCount"] = Convert.ToInt32(Session["cartCount"]) + 1;/*Update
* cart count*/
lblMessage("Item saved in cart successful.", "success");/*Display success message*/
}/**/
else/**/
{/**/
lblMessage("Cannot save item in cart right now.", "warning");/*Display
* warning message*/
}/**/
}/**/
else // Updating existing cart item
{/**/
int quantityFromDB = Convert.ToInt32(savedQuantity);/*Get existing quantity*/
int updatedQuantity = quantityFromDB + quantityFromCart;/*Update the quantity*/
int r = utils.addOrUpdateCartItem(productId, updatedQuantity, "UPDATE");/*
* Update the cart item*/
if (r > 0)/**/
{/**/
lblMessage("Item in cart is modified successful.", "success");/*Display success message*/
Session["cartCount"] = utils.itemCount("cart");/*Update cart count*/
}/**/
else/**/
{/**/
lblMessage("Cannot modify item in cart right now.", "warning");/*Display warning message*/
}/***/
}/**/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx", false);/*Redirect to login page if not logged in*/
}/**/
}/**/
catch (Exception ex)/*Catch any exceptions*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*
* Display an alert with the exception message*/
}/**/
}/**/
}/**/
void lblMessage(string textMessage, string cssClass)/*Method
* to display a message with a specific CSS class*/
{/**/
lblMsg.Visible = true;/*Make the message label visible*/
lblMsg.Text = textMessage;/*Set the text of the message label*/
lblMsg.CssClass = "alert alert-" + cssClass + "";/*Set the CSS class of the message label*/
}/**/
private sealed class CustomTemplate : ITemplate// Custom template
// class to add controls to the repeater's header, item and footer sections.
{/**/
private ListItemType ListItemType { get; set; }/*Define the type of the list item*/
public CustomTemplate(ListItemType type)
{/**/
 ListItemType = type;/**/
}/**/
public void InstantiateIn(Control container)/**/
{/**/
if (ListItemType == ListItemType.Footer)/**/
{/**/
var footer = new LiteralControl("<tr><td colspan='5'><b>Your Wishlist is empty." +
"</b></td></tr></tbody></table>");/**/
container.Controls.Add(footer);/*Add footer content to the container*/
}/**/
}/**/
}/**/
}/**/
}/**/