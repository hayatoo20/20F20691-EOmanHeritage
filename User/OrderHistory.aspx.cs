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
using EShopping.Admin;/**/
namespace EShopping.User/*The namespace refers to all pages and 
* categories related to the user...*/
{/**/
/*Declare necessary database-related objects**/
public partial class OrderHistory : System.Web.UI.Page/**/
{/**/
SqlConnection con;/*Database connection*/
SqlCommand cmd;/*SQL command to execute*/
SqlDataAdapter sda;/*Adapter to fill a DataTable*/
DataTable dt;/*DataTable to hold query results*/
SqlTransaction transaction = null;/*Database transaction*/
SqlDataReader dr;/*Data reader to read query results*/
protected void Page_Load(object sender, EventArgs e)/*
* Page load event handler*/
{/**/
if (!IsPostBack)/*Check if the page is not being
* loaded due to a postback*/
{/**/
if (!IsPostBack)/**/
{/**/
if (Session["userId"] == null)/*Check if the user is not logged in*/
{/**/
Response.Redirect("Login.aspx");/*Redirect to login page
* if not logged in*/
}/**/
else/**/
{/**/
getPurchaseHistory();/*Fetch and display purchase history*/
}/**/
}/**/
}/**/
lblMsg.Visible = false;/*Hide the message label*/
}/**/
private void getPurchaseHistory()/*Method to retrieve
* and display purchase history*/
{/**/
int sr = 1;/*Initialize a serial number counter*/
con = new SqlConnection(Utils.getConnection());/*Establish
* a database connection*/
/*Create a SQL command to fetch invoice data for a specific user*/
cmd = new SqlCommand("Invoice", con);/**/
cmd.Parameters.AddWithValue("@Action", "ODRHISTORY");/**/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/**/
cmd.CommandType = CommandType.StoredProcedure;/**/
/*Initialize a data adapter and DataTable to store query results.*/
sda = new SqlDataAdapter(cmd);/**/
dt = new DataTable();/**/
sda.Fill(dt);/*Fill the DataTable with query results*/
dt.Columns.Add("SrNo", typeof(System.Int32));/*Add
* a column for serial numbers to the DataTable.*/
if (dt.Rows.Count > 0)/*Populate the serial number column*/
{/**/
foreach (DataRow drow in dt.Rows)/**/
{/**/
drow["SrNo"] = sr;/**/
sr++;/**/
}/**/
}/**/
if (dt.Rows.Count == 0)/*If there are no records
* in the DataTable, display a custom footer in the repeater*/
{/**/
rPurchaseHistory.FooterTemplate = null;/**/
rPurchaseHistory.FooterTemplate = new CustomTemplate(ListItemType.Footer);/**/
}/**/
/***Bind the DataTable to the repeater control for display***/
rPurchaseHistory.DataSource = dt;/**/
rPurchaseHistory.DataBind();/**/
}/**/
protected void rPurchaseHistory_ItemDataBound(object sender, RepeaterItemEventArgs e)/*
* Event handler for repeater item data binding*/
{/**/
if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == 
ListItemType.AlternatingItem)/*If the item is an actual
* data item (not header, footer, etc*/
{/**/
double grandTotal = 0;/*Initialize a variable to store the grand total*/
/** Find controls within the repeater item*/
HiddenField paymentId = e.Item.FindControl("hdnPaymentId") as HiddenField;/**/
Repeater repOrders = e.Item.FindControl("rOrders") as Repeater;/**/
con = new SqlConnection(Utils.getConnection());/*/**Establish a
* new database connection**/
cmd = new SqlCommand("Invoice", con);/*Create a SQL command to fetch
* invoice details for a specific payment ID*/
cmd.Parameters.AddWithValue("@Action", "INVOICBYID");/**/
cmd.Parameters.AddWithValue("@PaymentId", Convert.ToInt32(paymentId.Value));/**/
cmd.Parameters.AddWithValue("@UserId", Session["userId"]);/**/
cmd.CommandType = CommandType.StoredProcedure;/**/
/* Initialize a data adapter and DataTable to store query results*/
sda = new SqlDataAdapter(cmd);/**/
dt = new DataTable();/**/
sda.Fill(dt);/* Fill the DataTable with query results*/
if (dt.Rows.Count > 0)/*Calculate the grand total by summing up the
* total prices of non-cancelled orders*/
{/**/
foreach (DataRow drow in dt.Rows)/**/
{/**/
if (drow["Status"].ToString() != "Cancelled")/**/
{/**/
grandTotal += Convert.ToDouble(drow["TotalPrice"]);/**/
}/**/
}/**/
}/**/
/*Add a row to the DataTable to display the grand total*/
DataRow dr = dt.NewRow();/**/
dr["TotalPrice"] = grandTotal;/**/
dr["IsCancel"] = true;/**/
dt.Rows.Add(dr);/**/
/*Bind the DataTable to the nested repeater control for order details display*/
repOrders.DataSource = dt;/**/
repOrders.DataBind();/**/
}/**/
}/**/
protected void rOrders_ItemCommand(object source, RepeaterCommandEventArgs e)/*
* Event handler for repeater item command*/
{/**/
if (e.CommandName == "cancel")/*If the cancel button is clicked.*/
{/**/
int productId; int quantity; int soldQuantity;/*Initialize variables
* for order cancellation*/
/*Establish a database connection*/
con = new SqlConnection(Utils.getConnection());/**/
con.Open();/**/
transaction = con.BeginTransaction();/**/
/*Create a SQL command to cancel an order*/
cmd = new SqlCommand("Invoice", con, transaction);/**/
cmd.Parameters.AddWithValue("@Action", "CANCELORDER");/**/
cmd.Parameters.AddWithValue("@OrderDetailsId", e.CommandArgument);/**/
cmd.Parameters.AddWithValue("@Status", "Cancelled");/**/
cmd.CommandType = CommandType.StoredProcedure;/**/
try/**/
{/**/
cmd.ExecuteNonQuery();/*Execute the cancellation command*/
#region Order Cancellation/*Update product quantity upon cancellation*/
Label lblQuantity = e.Item.FindControl("lblQuantity") as Label;/*Finds a label*/
HiddenField hfProductId = e.Item.FindControl("hfProductId") as HiddenField;/*
* Get hidden field*/
productId = Convert.ToInt32(hfProductId.Value);/*Convert product ID*/
cmd = new SqlCommand("Product_Crud", con, transaction);/*SQL command creation*/
cmd.Parameters.AddWithValue("@Action", "GETBYID");/*Add SQL parameters*/
cmd.Parameters.AddWithValue("@ProductId", productId);/**/
cmd.CommandType = CommandType.StoredProcedure;/*Set command type*/
dr = cmd.ExecuteReader();/*Execute SQL command*/
while (dr.Read())/*Loop through results*/
{/**/
quantity = (int)dr["Quantity"];/*Get quantity values*/
soldQuantity = (int)dr["Sold"];/**/
quantity += Convert.ToInt32(lblQuantity.Text);/*Commit transaction changes*/
soldQuantity -= Convert.ToInt32(lblQuantity.Text);/**/
//Update Product Quantity/**/
UpdateQuantity(productId, quantity, soldQuantity, transaction, con);/**/
//Update Product Quantity End/**/
}/**/
dr.Close();/**/
#endregion Order Cancellation/**/
transaction.Commit();/*Update product quantities*/
lblMessage("Ordered cancelled successfully!", "success");/*Calls
* a method to display message */
getPurchaseHistory();/*efresh the purchase history*/
}/**/
catch (Exception exceptn)/**/
{/**/
try/**/
{/**/
transaction.Rollback();/*Rollback transaction if necessary*/
}/**/
catch (Exception ex)/**/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/**/
}/**/
}/**/
finally/**/
{/**/
con.Close();/**/
}/**/
}/**/
}/**/
#region Update Product quantity & Sold quantity/**/
 void UpdateQuantity(int productId, int quantity, int soldQuantity,
SqlTransaction sqlTransaction, SqlConnection sqlConnection)/*method is 
* defined, taking parameters*/
{ /**/
try/**/
{/**/
cmd = new SqlCommand("Product_Crud", sqlConnection, sqlTransaction);/*created,
* specifying the stored procedure name*/
cmd.Parameters.AddWithValue("@Action", "QTY_UPDATE");/**/
cmd.Parameters.AddWithValue("@Quantity", quantity);/**/
cmd.Parameters.AddWithValue("@Sold", soldQuantity);/**/
cmd.Parameters.AddWithValue("@ProductId", productId);/**/
cmd.ExecuteNonQuery();/**/
}/**/
catch (Exception ex)/**/
{/**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/**/
 }/**/
}/**/
#endregion Update Product quantity & Sold quantity/**/
void lblMessage(string textMessage, string cssClass)/**/
{/**/
lblMsg.Visible = true;/**/
lblMsg.Text = textMessage;/**/
lblMsg.CssClass = "alert alert-" + cssClass + "";/**/
}/**/
// Custom template class to add controls to the
// repeater's header, item and footer sections./**/
private sealed class CustomTemplate : ITemplate/**/
{/**/
private ListItemType ListItemType { get; set; }/**/
 public CustomTemplate(ListItemType type)/**/
{/**/
ListItemType = type;/**/
}/**/
public void InstantiateIn(Control container)/**/
{/***/
if (ListItemType == ListItemType.Footer)/**/
{/**/
var footer = new LiteralControl("<tr><td><b>Don't wait! Make your first order now.</b>" +
"<a href='Shop.aspx' class='badge badge-info ml-2'>Click to Order</a></td>" +
"</tr></tbody></table>");/**/
container.Controls.Add(footer);/**/
}/**/
}/**/
}/**/
}/**/
}/**/