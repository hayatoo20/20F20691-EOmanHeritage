using AjaxControlToolkit;
using EShopping.Admin;
using System;/*It provides basic 
* functions for data types and also */
using System.Collections.Generic;/*It imports......  
* the namespace ofcollections such as dictionaries and lists */
using System.Data;/*It works by accessing data 
* from databases and managing it by 
* importing the namespace.*/
using System.Data.SqlClient;/*It works to access
*  * SQL Server databy importing the namespace...*/
using System.Drawing;/*It processes ..images and graphics*/
using System.Linq;/*Works on LINQ queries
* by importing the namespace.*/
using System.Security.Cryptography;/*It works on 
 * encryption and... security...*/
using System.Web;/*Imports the namespace of
* an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server  
* elements and pages by...importing the namespaceUsing */
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
/*Imports ...the 
 * namespace of ASP.NET...web server controls....*/
using System.Xml.Linq;
namespace EShopping.User/*The namespace  
* refers to all pages and..categories related to the user...*/
{/***/
public partial class ShopDetail : System.Web.UI.Page/*It is 
* inheriting from the ASP.NET Page class where the subclass
*  defines the SHOPDETAILS validity...*/
{/**/
SqlConnection con;/*This object works by 
* connecting to the database...*/
SqlCommand cmd;/*This object works by connecting to the database...*/
DataTable dt,dt1;/*It keeps all query results...*/
SqlDataAdapter sda;/*// Declare a SqlDataAdapter object
* to fill DataTable with the result set.*/
ProductDAL productDAL;/*// Declare a ProductDAL object, which likely 
* handles data access for products*/
Utils utils;/*// Declare a Utils object,
* which might contain utility methods used throughout the code.*/
protected void Page_Load(object sender, EventArgs e)/*// Page_Load event handler, 
* which executes when the page loads.*/
{/**/
if (!IsPostBack)/*// Check if the page is
* being loaded for the first time and
* not in response to a postback.*/
{/**/
if (Request.QueryString["id"] != null)/*// Check if the query string 
contains an "id" parameter.*/
{/**/
showProductDetails();/*// Call the method to show product details.*/
showTop5Products();/*Call the method to show product details.*/
}/**/
else/**/
{/**/
Response.Redirect("Shop.aspx");/*Redirect to the Shop page if "id" 
* is not present in the query string.*/
}/**/
}/**/
}/**/
private void showProductDetails()/*// Method to display
* product details.*/
{/**/
if (Request.QueryString["id"] != null)/* // Check if the query 
* string contains an "id" parameter.*/
{/**/
int productId = Convert.ToInt32(Request.QueryString["id"]);/* // Convert the "id"
* parameter to an integer.*/
productDAL = new ProductDAL();/*Instantiate the ProductDAL object.*/
dt = productDAL.ProductByIdWithImages(productId);// Get the product details
// along with images using the ProductDAL method.
rProductDetails.DataSource = dt;/*Set the data source of the Repeater 
* control to the DataTable.*/
rProductDetails.DataBind();/*Bind the data to the Repeater control.*/
}/**/
}/**/
private int getProductAvgRating()/*Method to get the average 
* rating of the product.*/
{/**/
 int avgRating = 0;/*Initialize the average rating to 0.*/
if (Request.QueryString["id"] != null)/*Check if the query string contains an "id" parameter*/
{/**/
int productId = Convert.ToInt32(Request.QueryString["id"]);/*Convert the "id"
* parameter to an integer.*/
con = new SqlConnection(Utils.getConnection());/*Create a new SQL connection 
 * using a method from the Utils class*/
 cmd = new SqlCommand("Product_Review", con);/*Create a new SqlCommand to call the 
 * "Product_Review" stored procedure*/
cmd.Parameters.AddWithValue("@Action", "AVGRATING");/* Add the "AVGRATING" action
* parameter to the command.*/
cmd.Parameters.AddWithValue("@ProductId", productId); // Add the ProductId
 // parameter to the command.
cmd.CommandType = CommandType.StoredProcedure;// Specify that the
// command is a stored procedure.
sda = new SqlDataAdapter(cmd);// Create a SqlDataAdapter to execute the
// command and fill the DataTable*/
dt1 = new DataTable();/*Instantiate a new DataTable.*/
sda.Fill(dt1);/*Fill the DataTable with the result of the command*/
avgRating = Convert.ToInt32(dt1.Rows[0]["AverageRating"]);// Get the average
// rating from the first row of the DataTable.
}/**/
return avgRating;/*Return the average rating*/
}/**/
protected void rProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)/*Event
* handler for when an item is data-bound in the Repeater control.*/
{/**/
if (dt.Rows.Count > 0) // Check if there are any rows in the DataTable.
{/**/
string size = dt.Rows[0]["Size"].ToString();// Get the size of the
// product from the first row.
string color = dt.Rows[0]["Color"].ToString();// Get the color of the
// product from the first row.
if (!string.IsNullOrEmpty(size)) /*Check if the size is not empty*/
{/**/
RadioButtonList radioBtnListSize = e.Item.FindControl("rblSizes") as RadioButtonList;// Find the
//RadioButtonList control for sizes in the Repeater item.
string[] sizes = size.Split(',');/*Split the sizes by comma*/
for (int i = 0; i < sizes.Length - 1; i++)/*Loop through the sizes*/
{/**/
radioBtnListSize.Items.Insert(i, new ListItem("&nbsp;" + sizes[i] + "&nbsp;&nbsp;", sizes[i], true));
// Insert each size as a ListItem in the RadioButtonList.
}/**/
}/**/
if (!string.IsNullOrEmpty(color))// Check if the color is not empty/
{
RadioButtonList radioBtnListColor = e.Item.FindControl("rblColors") as RadioButtonList;
/*Find the RadioButtonList control for colors in the Repeater item*/
string[] colors = color.Split(',');/* Split the colors by comma*/
for (int i = 0; i < colors.Length - 1; i++)/* Loop through the colors*/
{/**/
radioBtnListColor.Items.Insert(i, new ListItem("&nbsp;" + colors[i] + "&nbsp;", colors[i], true));
/*Insert each color as a ListItem in the RadioButtonList*/
}/**/
}/**/
int productId = Convert.ToInt32(Request.QueryString["id"]);// Convert the
// "id" parameter to an integer.
Repeater repReviews = e.Item.FindControl("rReview") as Repeater;// Find the
// Repeater control for reviews in the Repeater item.
con = new SqlConnection(Utils.getConnection()); // Create a new SQL
// connection using a method from the Utils class.
cmd = new SqlCommand("Product_Review", con);// Create a new SqlCommand
// to call the "Product_Review" stored procedure.
cmd.Parameters.AddWithValue("@Action", "GETBYPRDID");// Add the "GETBYPRDID"
// action parameter to the command.
cmd.Parameters.AddWithValue("@ProductId", productId);  // Add the ProductId
// parameter to the command.
cmd.CommandType = CommandType.StoredProcedure;// Specify that the command
// is a stored procedure.
sda = new SqlDataAdapter(cmd);// Create a SqlDataAdapter to
// execute the command and fill the DataTable.
dt1 = new DataTable(); // Instantiate a new DataTable.
sda.Fill(dt1);// Fill the DataTable with the result of the command.
if (dt1.Rows.Count > 0)// Check if there are any rows in the DataTable.
{/**/
repReviews.DataSource = dt1;// Set the data source of the
// reviews Repeater to the DataTable.
}/**/
Session["reviewCount"] = dt1.Rows.Count;// Store the review count in the session.
repReviews.DataBind();// Bind the data to the reviews Repeater.//
Rating userRating = (Rating)(e.Item.FindControl("userRating2"));// Find the Rating
// control in the Repeater item.
userRating.CurrentRating = getProductAvgRating();// Set the current
// rating of the Rating control to the average rating.
}/**/
}/**/
protected void rProductDetails_ItemCommand(object source, RepeaterCommandEventArgs e)// Event
 // handler for command events in the Repeater control.
 {/**/
if (Session["userId"] != null) // Check if the user is logged in//
{/**/
utils = new Utils(); // Instantiate the Utils object//
int productId = Convert.ToInt32(e.CommandArgument);// Get
 // the product ID from the command argument.
if (e.CommandName == "addToWishlist")// Check if the command is
// to add the item to the wishlist.
{/**/
try/**/
{/**/
int count = utils.WishlistItemExist(productId);// Check if
// the item already exists in the wishlist.
if (count != 1)/**/
{/**/
int r = utils.AddToWishlist(productId);// Add the item to the wishlist/
if (r > 0)/**/
{/**/
lblMessage("Item saved in wishlist successful.", "success"); // Display
// a success message.
Session["wishlistCount"] = utils.itemCount("wishlist");// Update the wishlist
// count in the session.
}/**/
else/**/
{/**/
lblMessage("Cannot save item in wishlist right now.", "warning");// Display
// a warning message.
}/**/
}/**/
else/**/
{/**/
lblMessage("Item already exist in wishlist.", "warning");// Display a warning message.
}/**/
}/**/
catch (Exception ex)/**/
{//**/
Response.Write("<script>alert('" + ex.Message + "');</script>");  // Display
// an alert with the exception message.
}/**/
}/**/
else if (e.CommandName == "addToCart")// Check if the command
// is to add the item to the cart.
{/**/
try/**/
{/**/
HtmlInputText quantity = (HtmlInputText)(e.Item.FindControl("txtQuantity"));
// Find the quantity input control in the Repeater item//                  
int quantityFromCart = Convert.ToInt32(quantity.Value);  // Get the quantity
// from the input control.
int savedQuantity = utils.cartItemExistReturnQuantity(productId); // Check
// if the item already exists in the cart and get its quantity.
if (savedQuantity == 0)// If the item does not exist in the cart, add it//
{/**/
int r = utils.addOrUpdateCartItem(productId, quantityFromCart, "INSERT");//
// Add the item to the cart.
if (r > 0)/**/
{/**/
Session["cartCount"] = Convert.ToInt32(Session["cartCount"]) + 1;// Update
// the cart count in the session.
lblMessage("Item saved in cart successful.", "success");// Display a success message/
}/**/
else/**/
{/**/
lblMessage("Cannot save item in cart right now.", "warning");// Display
// a warning message//
}/**/
}/**/
else/**/// If the item exists in the cart, update its quantity.
{/**/
int quantityFromDB = Convert.ToInt32(savedQuantity);// Get the
// existing quantity from the cart.
int updatedQuantity = quantityFromDB + quantityFromCart;// Calculate
// the updated quantity.
int r = utils.addOrUpdateCartItem(productId, updatedQuantity, "UPDATE");//
//Update the item quantity in the cart.
if (r > 0)/**/
{/**/
lblMessage("Item in cart is modified successful.", "success");  // Display
// a success message.
Session["cartCount"] = utils.itemCount("cart");// Update the cart count
// in the session.
 }/**/
else/**/
{/**/
lblMessage("Cannot modify item in cart right now.", "warning");// Display
// a warning message.
}/**/
}/**/
}/**/
catch (Exception ex)/**/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");// Display
// an alert with the exception message.
}/**/
}/**/
else if (e.CommandName == "addReview")// Check if the command is
// to add a review.
{/**/
try/**/
{/**/
int count = itemAlreadyBought(productId); // Check if the user
// has already bought the item.
TextBox comment = (TextBox)(e.Item.FindControl("txtMessage"));// Find the
// comment input control in the Repeater item.
Rating userRating = (Rating)(e.Item.FindControl("userRating"));// Find the
// Rating control in the Repeater item.
if (count > 0)/**/
{/**/
using (con = new SqlConnection(Utils.getConnection()))/**/
{/**/
int rating = userRating.CurrentRating;// Get the current
// rating from the Rating control.
cmd = new SqlCommand("Product_Review", con);// Create a new
// SqlCommand to call the "Product_Review" stored procedure.
cmd.Parameters.AddWithValue("@Action", "INSERT");// Add the "INSERT"
// action parameter to the command.
cmd.Parameters.AddWithValue("@Rating", rating);// Add the rating parameter
// to the command.
cmd.Parameters.AddWithValue("@Comment", comment.Text);// Add the comment
// parameter to the command.
cmd.Parameters.AddWithValue("@ProductId", productId); // Add the ProductId
// parameter to the command.
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);// Add the UserId
// parameter to the command.
cmd.CommandType = CommandType.StoredProcedure;// Specify that the command
// is a stored procedure.
con.Open();/*// Open the SQL connection//*/
cmd.ExecuteNonQuery();// Execute the command//
cmd.Dispose();// Dispose of the command object//
lblMessage("Your review added successful.", "success");// Display a success message.
Response.AddHeader("REFRESH", "2;URL=ShopDetail.aspx?id=" + Request.QueryString["id"]);//
// Refresh the page after 2 seconds to show the updated review.
}/**/
}/**/
else/**/
{/**/
lblMessage("Only user who bought this item can add review!", "info");// Display
// an informational message.
userRating.CurrentRating = 1; // Reset the rating to 1//
comment.Text = string.Empty;// Clear the comment text//
}/**/
}/**/
catch (Exception ex)/**/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");// Display an
// alert with the exception message.
}/**/
}/**/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx", false);// Redirect to the login
// page if the user is not logged in.
}/**/
}/**/
private int itemAlreadyBought(int productId)// Method to check if
// the user has already bought the item.
{/**/
int count = 0; /*Declares an integer variable named count and 
 * initializes it with the value*/
using (con = new SqlConnection(Utils.getConnection()))/*Begins a using block
* to automatically dispose of resources when the block is exited. It establishes
* a connection to the database using the SqlConnection class and a connection string
* obtained from the Utils class.*/
{/**/
try/*Begins a block of code that might throw exceptions.*/
{/**/
cmd = new SqlCommand("Product_Review", con);/*Creates a new instance 
* of the SqlCommand class with the SQL command "Product_Review" and 
* associates it with the connection con.*/
cmd.Parameters.AddWithValue("@Action", "ITEMBOUGHT");/*dds 
* a parameter named @Action with the value "ITEMBOUGHT" to the SQL command.*/
cmd.Parameters.AddWithValue("@ProductId", productId);/*dds a parameter
* named @ProductId with the value of the productId variable to the SQL command.*/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/*Adds a parameter
* named @UserId with the value stored in the Session["userId"] object to the 
* SQL command.*/
cmd.CommandType = CommandType.StoredProcedure;/*Specifies that
* the SQL command is a stored procedure.*/
sda = new SqlDataAdapter(cmd);/*Creates a new instance
* of the SqlDataAdapter class with the SQL command.*/
dt1 = new DataTable();/*Creates a new instance of the DataTable class.*/
sda.Fill(dt1);/*Executes the SQL command and fills the DataTable with 
* the result set*/
count = dt1.Rows.Count;/*Retrieves the number of rows in the DataTable
* and assigns it to the count variable.*/
}/**/
 catch (Exception ex)/*Catches any exceptions that occur during the 
* execution of the try block.*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*Displays 
* an alert message with the exception message using JavaScript.*/
}/**/
}/**/
return count;/*Returns the value of the count variable*/
}/**/
private void showTop5Products()/**/
{/**/
try/*Begins a block of code where exceptions might occur.*/
{/**/
using (con = new SqlConnection(Utils.getConnection()))/*Establishes 
* a connection to the database using the SqlConnection class and a connection
* string obtained from the Utils class. The using statement ensures that the
* connection is properly disposed of when it's no longer needed.*/
{/**/
con.Open();/*Opens the database connection*/
cmd = new SqlCommand("Product_Crud", con);/*/*Creates a new 
* instance of the SqlCommand class with the SQL command "Product_Crud"
* and associates it with the connection con.*/
cmd.Parameters.AddWithValue("@Action", "TOP_5_PRODUCTS"); /*Adds
 * a parameter named @Action with the value "TOP_5_PRODUCTS" to the SQL command.*/
 cmd.CommandType = CommandType.StoredProcedure;/*Specifies that the SQL command is a stored procedure.*/
sda = new SqlDataAdapter(cmd);/*Creates a new instance of the SqlDataAdapter class with the SQL command.*/
dt1 = new DataTable();/*Creates a new instance of the DataTable class*/
sda.Fill(dt1);/*Executes the SQL command and fills the DataTable with the result set*/
if (dt1.Rows.Count > 0)/*Checks if the DataTable contains any rows*/
{/**/
rTop5Products.DataSource = dt1;/*Sets the DataSource property of the
* rTop5Products control to the DataTable.*/
rTop5Products.DataBind();/*Binds the data to the rTop5Products control*/
}/**/
}/**/
}/**/
catch (Exception ex)/*Catches any exceptions that occur within the try block*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*Displays
* an alert message with the exception message using JavaScript*/
}/**/
}/**/
protected void rTop5Products_ItemCommand(object source, RepeaterCommandEventArgs e)/*
Defines a method to handle events raised by the rTop5Products control.*/
{/**/
utils = new Utils();/*Creates a new instance of the Utils class*/
if (e.CommandName == "addToCart")/*Checks if the command name
* associated with the event is "addToCart".
*/
{/**/
try/**/
{/**/
if (Session["userId"] != null)/*Checks if the user is logged in*/
{/**/
//HtmlInputText quantity = (HtmlInputText)(e.Item.FindControl("txtQuantity"));/**/
int quantityFromCart = 1; //Convert.ToInt32(quantity.Value);/* nitializes a variable
//quantityFromCart with a value of 1, representing the quantity of the item to
//be added to the cart*/
int productId = Convert.ToInt32(e.CommandArgument.ToString());/*Converts product ID*/
int savedQuantity = utils.cartItemExistReturnQuantity(productId);/*Converts product ID*/
 if (savedQuantity == 0) //Adding new /**/item into cart/*Checks saved quantity*/
{/**/
int r = utils.addOrUpdateCartItem(productId, quantityFromCart, "INSERT");/*
* Adds or updates item.*/
if (r > 0)/*hecks operation success*/
{/**/
Session["cartCount"] = Convert.ToInt32(Session["cartCount"]) + 1;/*Updates cart count*/
lblMessage("Item saved in cart successful.", "success");/*Success message*/
}/**/
else/**/
{/**/
lblMessage("Cannot save item in cart right now.", "warning");/*Warning message*/
}/**/
}/**/
else // Updating /**/existing cart item
{/**/
int quantityFromDB = Convert.ToInt32(savedQuantity);/*Converts saved quantity*/
int updatedQuantity = quantityFromDB + quantityFromCart;/*Calculates updated quantity*/
int r = utils.addOrUpdateCartItem(productId, updatedQuantity, "UPDATE");/*Adds
* or updates item in the cart.*/
if (r > 0)/*Checks if the operation was successfu*/
{/**/
lblMessage("Item in cart is modified successful.", "success");/*Displays 
* success message*/
Session["cartCount"] = utils.itemCount("cart");/* Updates the cart count.*/
}/**/
else/**/
{/**/
lblMessage("Cannot modify item in cart right now.", "warning");/*Displays
* warning message.*/
}/**/
}/**/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx", false);/*Redirects the
* user to the login page */
}/**/
}/**/
catch (Exception ex)/*Catches any exceptions that occur within the try block*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/* Displays
* an alert with the exception message using JavaScript*/
}/**/
}/**/
}/**/
void lblMessage(string textMessage, string cssClass)/*Defines a method named lblMessage
* with two parameters: textMessage and cssClass*/
{/**/
lblMsg.Visible = true;/*Sets the visibility of the lblMsg control to true*/
lblMsg.Text = textMessage;/*Sets the text of the lblMsg control
* to the value passed in textMessage.*/
lblMsg.CssClass = "alert alert-" + cssClass + "";/*Sets the CSS class
* of the lblMsg control to concatenate "alert alert-" with the value passed in cssClass*/
}/**/
}/**/
}/**/