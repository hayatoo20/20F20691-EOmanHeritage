using EShopping.Admin;
using System;/*It provides basic functions for data types and also 
* imports the ...system namespace...*/
using System.Collections.Generic;/*It imports the namespace of 
* collections such as... dictionaries and lists */
using System.Data;/*It works ....by accessing data 
* from databases and managing it by importing the namespace.*/
using System.Data.SqlClient;/*It works to access SQL Server data
* by ...importing the namespace...*/
using System.Linq;/*Works on ..LINQ queries by importing the namespace.*/
using System.Net;
using System.Web;/*Imports the namespace of an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server elements and pages by 
* importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the namespace of ASP.NET
 * web server controls....*/
using System.Xml.Linq;/**/
namespace EShopping.User/*The namespace refers to all pages and 
* categories related to the user...*/
{/**/
public partial class Payment : System.Web.UI.Page/*It is inheriting 
* from the ASP.NET Page */
{/**/
SqlConnection con;/*This object works by connecting to the database...*/
SqlCommand cmd;/*It executes SQL commands...*/
SqlDataReader dr, dr1;/*Declares two data readers.*/
DataTable dt;/*// Declare a SqlDataAdapter object
* to fill DataTable with the result set.*/
SqlTransaction transaction = null;/**/
Utils utils;/* Declare a Utils object,
* which might contain utility methods used throughout the code.*/
string name = string.Empty; string cardNo = string.Empty; string
expiryDate = string.Empty; string cvv = string.Empty;
string address; string paymentMode;
 protected void Page_Load(object sender, EventArgs e)/*.It processes 
* the event to load the page.....*/
{/**/
if (!IsPostBack)/*/*.It processes 
* the event to load the page.....*/
{/**/
if (Session["userId"] == null)/*// Check if the user is not logged in*/
{/**/
Response.Redirect("Login.aspx");/*// Check if the user is not logged in*/
}/**/
showOrder();
}/**/
}/**/
private void showOrder()/*Declares a private method named 
* showOrder which doesn't return any value*/
{/**/
try/**/
{/**/
if (Session["userId"] != null)/*Checks if the session variable
 * "userId" is not null, indicating that the user is logged in*/
{/**/
utils = new Utils();/*Creates a new instance of the Utils class*/
dt = utils.CartItemByUserId();/*Calls the CartItemByUserId method
* from the utils instance to get the user's cart items and stores
* the result in a DataTable named d*/
if (dt.Rows.Count > 0)/*Checks if the cart has any items*/
{/**/
rOrderSummary.DataSource = dt;/*Connects the cart items to
* the order summary display*/
btnPlaceOrder.Enabled = true;/*Enables the "Place Order"
* button because the cart has items.*/
}/**/
else/**/
{/**/
rOrderSummary.DataSource = dt;/*Connects the empty table to
* the order summary display.*/
btnPlaceOrder.Enabled = false;/*Disables the "Place Order" 
* button because the cart is empty*/
rOrderSummary.FooterTemplate = null;/*Clears any existing
* footer in the order summary*/
rOrderSummary.FooterTemplate = new CustomTemplate(ListItemType.Footer);/*
Adds a new footer message saying there are no items*/
}/**/
//Session["cartCount"] = dt.Rows.Count.ToString();/**/
Session["price"] = getProductPrice(dt);/*Calculates the
* total price of the items in the cart and stores it in the session*/
rOrderSummary.DataBind();/*Updates the order summary display with the cart data*/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx", false);/*If the user is not logged in*/
}/**/
}/**/
catch (Exception ex)/*If any errors occur in the try block*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*
* Shows an alert with the error message*/
}/**/
}/**/
protected void cbCOD_CheckedChanged(object sender, EventArgs e)/*
* checkbox changed event*/
{/**/
if (cbCOD.Checked)/*Check if COD selected*/
{/**/
pnlCOD.Visible = true;/*Show COD panel*/
btnPlaceOrder.ValidationGroup = "codPayment";/*Set validation group to COD*/
}/**/
else/**/
{/**/
pnlCOD.Visible = false;/*Hide COD panel*/
btnPlaceOrder.ValidationGroup = "cardPayment";/*Set
* validation group to card*/
}/**/
}/**/
private decimal getProductPrice(DataTable dt)/*Method to get product price*/
{/**/
decimal price = 0;/*Initialize price to zero*/
decimal quantity = 0;/*Initialize quantity to zero*/
decimal totalPrice = 0;/*Initialize total price to zero*/
foreach (DataRow row in dt.Rows)/*Loop through each row.*/
{/**/
quantity = Convert.ToDecimal(row["Quantity"]);/*Get item quantity*/
price = Convert.ToDecimal(row["Price"]);/*Get item price*/
totalPrice += quantity * price;/*Calculate total price*/
}/**/
return totalPrice;/*Return total price*/
}/**/
protected void btnPlaceOrder_Click(object sender, EventArgs e)/*Place
* order click event*/
{/**/
if (cbCOD.Checked)/*Check if COD selected.*/
{/**/
address = txtCodAddress.Text.Trim();/*Get COD address*/
paymentMode = "cod";/*Set payment mode to COD*/
}/**/
else/**/
{/**/
name = txtCardHolderName.Text.Trim();/*Get card holder name*/
cardNo = string.Format("************{0}", txtCardNumber.Text.Trim().
Substring(12, 4));/*Mask card number.*/
expiryDate = txtExpiryMonthYear.Text;/*Get card expiry date*/
cvv = txtCVV.Text.Trim();/*Get CVV code*/
address = txtAddress.Text.Trim();/*Get billing address*/
paymentMode = "card";/*Set payment mode to card*/
}/**/
if (Session["userId"] != null)/*Check if user is logged in*/
{/**/
OrderPayment(name, cardNo, expiryDate, cvv, address, paymentMode);/*
* Process the order payment*/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx");/*Redirect to login page*/
}/**/
}/**/
void OrderPayment(string name, string cardNo, string expiryDate,
string cvv, string address, string paymentMode)/*Method to process payment*/
{/**/
int paymentId; int productId; int quantity;/*Declare variables*/
dt = new DataTable();/* Create new data table*/
dt.Columns.AddRange(new DataColumn[7] {/*Add columns to table*/
new DataColumn("OrderNo", typeof(string)),/*Add OrderNo column*/
new DataColumn("ProductId", typeof(int)),/*Add ProductId column*/
new DataColumn("Quantity",typeof(int)),/*Add Quantity column*/
new DataColumn("UserId",typeof(int)),/*Add UserId column*/
new DataColumn("Status",typeof(string)),/*Add Status column*/
new DataColumn("PaymentId",typeof(int)),/*Add PaymentId column*/
new DataColumn("OrderDate",typeof(DateTime))/*Add OrderDate column*/
});/**/
con = new SqlConnection(Utils.getConnection());/*Create database connection*/
con.Open();/*Open database connection*/
#region Sql Transaction/*Start transaction region*/
transaction = con.BeginTransaction();/*Begin database transaction*/
#region Adding Payment Details/*Start adding payment details region*/
cmd = new SqlCommand("Save_Payment", con, transaction);/*Create SQL command.*/
cmd.CommandType = CommandType.StoredProcedure;/*Set command
* type to stored procedure*/
cmd.Parameters.AddWithValue("@Name", name);/*Add Name parameter*/
cmd.Parameters.AddWithValue("@CardNo", cardNo);/*Add CardNo parameter*/
cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);/* Add ExpiryDate parameter*/
cmd.Parameters.AddWithValue("@Cvv", cvv);/*Add CVV parameter*/
cmd.Parameters.AddWithValue("@Address", address);/*Add Address parameter*/
cmd.Parameters.AddWithValue("@PaymentMode", paymentMode);/*Add PaymentMode parameter*/
cmd.Parameters.Add("@InsertedId", SqlDbType.Int);/*Add InsertedId output parameter*/
cmd.Parameters["@InsertedId"].Direction = ParameterDirection.Output;/*Set
* InsertedId direction*/
try/**/
{/**/
cmd.ExecuteNonQuery();/*Execute the command*/
paymentId = Convert.ToInt32(cmd.Parameters["@InsertedId"].Value);/*Get inserted payment ID*/
#endregion Adding Payment Details/*End adding payment details region.*/
#region Getting Cart Items/*Start getting cart items region*/
cmd = new SqlCommand("Cart_Crud", con, transaction);/*Create cart CRUD command*/
cmd.Parameters.AddWithValue("@Action", "SELECTBYUSERID");/*Set action to select by user id*/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/*Add user ID parameter*/
cmd.CommandType = CommandType.StoredProcedure;/*Set command type to stored procedure*/
dr = cmd.ExecuteReader();/*Execute the reader*/
while (dr.Read())/*Loop through cart items*/
{/**/
productId = (int)dr["ProductId"];/*Get product ID*/
quantity = (int)dr["Quantity"];/*Get quantity.*/
// Update Product Quantity/*Update product quantity*/
UpdateQuantity(productId, quantity, transaction, con);/*Update
* product quantity*/
// Update Product Quantity End/**/
// Delete Cart Item/**/
DeleteCartItem(productId, transaction, con);/**/
// Delete Cart Item End/**/
 dt.Rows.Add(Utils.GetUniqueId(), productId, quantity, (int)Session["userId"],
"Pending", paymentId, Convert.ToDateTime(DateTime.Now));/*Add row to order table*/
}/**/
dr.Close();/*Close data reader*/
#endregion Getting Cart Items/**/
#region Order Details/**/
if (dt.Rows.Count > 0)/*If order table has rows*/
{/**/
cmd = new SqlCommand("Save_Orders", con, transaction);/*Create save orders command*/
cmd.CommandType = CommandType.StoredProcedure;/*Set command type to stored procedure*/
cmd.Parameters.AddWithValue("@tblOrders", dt);/*Add orders parameter.*/
cmd.ExecuteNonQuery();/*Execute the command*/
}/**/
#endregion Order Details/*End order details region*/
transaction.Commit();/*Commit the transaction*/
lblMsg.Visible = true;/*Show message label*/
lblMsg.Text = "Your Request ordered successfully!'..'";/*Set
* success message text*/
lblMsg.CssClass = "alert alert-success";/*Set success message style*/
Response.AddHeader("REFRESH", "2;URL=Invoice.aspx?id=" + paymentId);/*
* Redirect to invoice page*/
}/**/
catch (Exception e)/*Catch any exceptions*/
{/**/
try/**/
{/**/
transaction.Rollback();/*Rollback the transaction*/
}/**/
catch (Exception ex)/*Catch rollback exceptions*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*
* Show error alert*/
}/**/
}/**/
#endregion Sql Transaction/*End transaction region*/
finally/*Execute finally block*/
{/**/
con.Close();/*Close database connection*/
}/**/
}/**/
#region Update Product Quantity & Sold Quantity/*Start update quantity region*/
void UpdateQuantity(int productId, int quantity, 
SqlTransaction sqlTransaction, SqlConnection sqlConnection)/*Method to update quantity*/
{/**/
int dbQuantity,soldQuantity;/*Declare variables*/
cmd = new SqlCommand("Product_Crud", sqlConnection, sqlTransaction);/*
* Create product CRUD command*/
cmd.Parameters.AddWithValue("@Action", "GETBYID");/*Set action to get by ID*/
cmd.Parameters.AddWithValue("@ProductId", productId);/*Add product ID parameter*/
cmd.CommandType = CommandType.StoredProcedure;/*Set command type to stored procedure*/
try/**/
{/**/
dr1 = cmd.ExecuteReader();/*Execute the reader*/
while (dr1.Read())/*Loop through products*/
{/**/
dbQuantity = (int)dr1["Quantity"];/*Get current quantity*/
soldQuantity = (int)dr1["Sold"];/*Get sold quantity*/
if (dbQuantity > quantity && dbQuantity > 1)/*Check quantity available.*/
{/**/
dbQuantity -= quantity;/* Decrease quantity*/
 soldQuantity += quantity;/*Increase sold quantity*/
cmd = new SqlCommand("Product_Crud", sqlConnection, sqlTransaction);/*
* Create update quantity command*/
cmd.Parameters.AddWithValue("@Action", "QTY_UPDATE");/*Set action
* to update quantity.*/
cmd.Parameters.AddWithValue("@Quantity", dbQuantity);/*Add updated quantity.*/
cmd.Parameters.AddWithValue("@Sold", soldQuantity);/*dd updated sold quantity*/
cmd.Parameters.AddWithValue("@ProductId", productId);/*Add product ID parameter*/
cmd.CommandType = CommandType.StoredProcedure;/*Set command type to stored procedure.*/
cmd.ExecuteNonQuery();/* Execute the command*/
}/**/
}/**/
dr1.Close();/*Close data reader*/
}/**/
catch (Exception ex)/*Catch any exceptions.*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*
* Show error alert.*/
}/**/
}/**/
 #endregion Update Product Quantity/**/
#region Delete Cart Item/**/
void DeleteCartItem(int productId, SqlTransaction sqlTransaction,
SqlConnection sqlConnection)/*Method to delete cart item*/
{/**/
cmd = new SqlCommand("Cart_Crud", sqlConnection, sqlTransaction);/*
* Create cart CRUD command*/
cmd.Parameters.AddWithValue("@Action", "DELETE");/*Set action to delete*/
cmd.Parameters.AddWithValue("@ProductId", productId);/*Add product ID parameter*/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/*Add user ID parameter*/
cmd.CommandType = CommandType.StoredProcedure;/*Set command type to stored procedure*/
try/**/
{/**/
cmd.ExecuteNonQuery();/*Execute the command*/
}/**/
catch (Exception ex)/*Catch any exceptions*/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*
* Show error alert.*/
}/**/
}/**/
#endregion Delete Cart Item/**/
// Custom template class to add controls to the repeater's
// header, item and footer sections.
 private sealed class CustomTemplate : ITemplate/*Custom template class*/
{/**/
private ListItemType ListItemType { get; set; }/*Property for item type**/
public CustomTemplate(ListItemType type)/*Constructor with type*/
{/**/
ListItemType = type;/*Set item type*/
}/**/
 public void InstantiateIn(Control container)/*Method to instantiate control*/
{/**/
if (ListItemType == ListItemType.Footer)/*Check if footer type*/
{/**/
var footer = new LiteralControl(@"<li><b>You have no order.<br>
<a href=""Shop.aspx"">Continue Shopping</a></b></li>");/*Create footer control*/
container.Controls.Add(footer);/*Add footer control*/
}/**/
}/**/
}/**/
}/**/
}/**/