using System;/*It provides basic 
* functions for data types and also 
* imports the system namespace...*/
using System.Collections.Generic;/*It imports......  
* the namespace ofcollections such as dictionaries and lists */
using System.Data.SqlClient;/*It works to access
*  * SQL Server databy importing the namespace...*/
using System.Data;/*It works by accessing data 
* from databases and managing it by 
* importing the namespace.*/
using System.Drawing;/*It processes ..images and graphics*/
using System.Linq;/*Works on LINQ queries
* by importing the namespace.*/
using System.Security.Cryptography;/*It works on 
 * encryption and... security...*/
using System.Web;/*Imports the namespace of
* an ASP.NET web application*/
using System.Web.UI;/*Controls ASP.NET server  
* elements and pages by...importing the namespaceUsing */
using System.Web.UI.WebControls;/*Imports ...the 
 * namespace of ASP.NET...web server controls....*/
using Org.BouncyCastle.Asn1.Ocsp;/*It helps in handling 
* OCSP responses and requests in encryption*/
namespace EShopping.User/*The namespace  
* refers to all pages and..categories related to the user...*/
{/***/
 public partial class Shop : System.Web.UI.Page/*It is 
* inheriting from the ASP.NET Page class where the subclass
*  defines the SHOP validity...*/
 {/***/
SqlConnection con;/*This object works by 
* connecting to the database...*/
SqlCommand cmd;/*It executes... SQL commands...*/
DataTable dt;/*It keeps.. all query results.*/
SqlDataAdapter sda;/***/
Utils utils;/*Provides auxiliary functions 
* and declares the ulits variable**/
DataView dv;/*It is used to display and manage 
* data from a datatable and declares a dv variable of type dataview*/
protected void Page_Load(object sender, EventArgs e)/*.It....  
* processes the event to load the page.....*/
{/****/
if (!IsPostBack)/*.It verifies whether the page was loaded for the first 
* time... and not for re-posting..*/
            {/***/
if (Request.QueryString["cid"] != null) // Get products by category
{/****/
getProductByCategory();/**/
}/*****/
else if (Request.QueryString["sid"] != null) //* it indicat
//  to get products by sub-category*/
{/***/
getProductBySubCategory();//* */
}/***/
else //* */
{/***/
getAllProducts();//* it indicate to get all products*/
}/***/
}/***/
}/***/
void getAllProducts()/*.It is a method that displays and 
* retrieves product details...*/
{/***/
try/***/
{/**/
using (con = new SqlConnection(Utils.getConnection()))/*.It initializes 
* the connection ....string.....*/
{/**/
cmd = new SqlCommand("Product_Crud", con);/*.It ...initializes 
* the SQLCommand with the name of the stored procedure.....*/
cmd.Parameters.AddWithValue("@Action", "ACTIVEPRODUCT");/*.Adds a parameter
* to a stored procedure.*/
cmd.CommandType = CommandType.StoredProcedure;/*.It... adjusts the type
* of command based on the ....stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command.........*/
dt = new DataTable();/* Preparing ... table for data...*/
sda.Fill(dt);/*.Through it, the DATA TABLE is 
*  filled with the results of the query.....*/
if (dt.Rows.Count > 0)/**/
{/***/
rProducts.DataSource = dt;/**/
}//***/
else//**/
{//**/
rProducts.DataSource = dt;/*It checks whether the datatable
* dt contains any rows...*/
rProducts.FooterTemplate = null;/*It is set if rows exist...
*/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);/*It
* sets it when there are no rows and makes updates...*/
}//***//
rProducts.DataBind();/*It binds data to a repeating control..*/
Session["product"] = dt; /*Stores session variables for the product*/
}/***/
}/****/
catch (Exception ex)/*..It works to catch general exceptions..*/
{/*...*/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET
* application*/
 }/**..*/
}/***/
void getProductByCategory()/*.It is a method that displays and 
* retrieves product details...*/
{/**/
try/***/
{//**/
using (con = new SqlConnection(Utils.getConnection()))/*.It.. initializes 
* the connection string.....*/
{/*///*/
int categoryId = Convert.ToInt32(Request.QueryString["cid"]);/*.Adds
* the parameter to the user ID.....*/
cmd = new SqlCommand("Product_Crud", con);/*.It initializes 
* the SQLCommand with the name of the stored procedure.....*/
 cmd.Parameters.AddWithValue("@Action", "PRDTBYCATEGORY");/*
* .Adds a parameter* to a stored procedure.*/
cmd.Parameters.AddWithValue("@CategoryId", categoryId);
cmd.CommandType = CommandType.StoredProcedure;/*.It adjusts the type
* of command based on the stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command.........*/
 dt = new DataTable();/* Preparing ... table for data...*/
sda.Fill(dt);/* Preparing ... table for data...*/
if (dt.Rows.Count > 0)/*.It checks whether
* exactly  more zero record is returned..*/
{/**/
rProducts.DataSource = dt;/*Updates the user interface with updated data
* source Linking to restored product data...*/
}//**/
else/**/
{//**/
rProducts.DataSource = dt;/***/
rProducts.FooterTemplate = null;/***/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);/**/
}//***/
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
Session["product"] = dt;/**/
}//**/
}//**/
catch (Exception ex)/*..It works to catch general exceptions..*/
{//**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET
* application*/
}//**/
}//**/
void getProductBySubCategory()/**/
{/**/
try/**/
{/**/
using (con = new SqlConnection(Utils.getConnection())) /*.It..initializes
 * the connection string.....*/
{/**/
int subCategoryId = Convert.ToInt32(Request.QueryString["sid"]);
cmd = new SqlCommand("Product_Crud", con);/*.It initializes 
* the SQLCommand with the name of the stored procedure.....*/
cmd.Parameters.AddWithValue("@Action", "PRDTBYSUBCATEGORY");/*
* .Adds a parameter* to a stored procedure.*/
cmd.Parameters.AddWithValue("@SubCategoryId", subCategoryId);
cmd.CommandType = CommandType.StoredProcedure;/*.It adjusts the type
* of command based on the stored procedure...*/
sda = new SqlDataAdapter(cmd);/*.Initializes SQLDATAADAPTER
* with the command.........*/
dt = new DataTable(); /*Preparing... table for data...*/
sda.Fill(dt);/* Preparing ... table for data...*/
if (dt.Rows.Count > 0)/*Ensures that the data exists before 
* it is displayed for follow-up by checking that the datatable contains any rows*/
{//**/
rProducts.DataSource = dt;/*Helps set the source designation
* for data while preparing it for display*/
}/**/
else/**/
{//**/
rProducts.DataSource = dt;/*Helps set the source designation
* for data while preparing it for display*/
rProducts.FooterTemplate = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);
}/**/
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
Session["product"] = dt;/**/
}///*..*/
}/**/
catch (Exception ex)/*..It works to catch general exceptions..*/
{//**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET
* application*/
}/**/
}/**/
protected void rProducts_ItemCommand(object source, RepeaterCommandEventArgs e)/**/
{//**/
utils = new Utils();/**/
if (e.CommandName == "addToCart")/**/
{//**/
try//**/
{//**/
if (Session["userId"] != null)/**/
{//*...*/
//HtmlInputText quantity = (HtmlInputText)(e.Item.FindControl("txtQuantity"));
int quantityFromCart = 1; //Convert.ToInt32(quantity.Value);
int productId = Convert.ToInt32(e.CommandArgument.ToString());/**/
int savedQuantity = utils.cartItemExistReturnQuantity(productId);/**/
if (savedQuantity == 0) //Adding the new item in the cart
{//***/
int r = utils.addOrUpdateCartItem(productId, quantityFromCart, "INSERT");/**/
if (r > 0)//**/
{/***/
Session["cartCount"] = Convert.ToInt32(Session["cartCount"]) + 1;
lblMessage("Item Is Successfully Saved In The Cart ", "success");/**/
}//***/
else//**//
{/**/
lblMessage("Cannot Save Item In The Cart Right Now.", "Warning");/**/
}///***/
}/**/
else // *Updating.. existing cart item*///
{/**/
int quantityFromDB = Convert.ToInt32(savedQuantity);/***/
int updatedQuantity = quantityFromDB + quantityFromCart;
int r = utils.addOrUpdateCartItem(productId, updatedQuantity, "UPDATE");/***/
if (r > 0)//**/
{//****/
lblMessage("Item In Cart Is Successfully Modified ", "success");/*MESSEAGE*/
Session["cartCount"] = utils.itemCount("cart");/**/
}///**../
else//*>>*/
 {//**/
lblMessage("Cannot Modify Item In Cart Right Now", "Warning");/**/
}///**..*/
}//**.*/
}//**/
else//**/
{/**/
Response.Redirect("Login.aspx", false);/**/
}/**/
}/**/
catch (Exception ex)/*..It works to catch general exceptions..*/
{//**/
Response.Write("<script>alert('" + ex.Message + "');</script>");/*It
* issues an error alert message from a user exception in an ASP.NET*/
}/**/
}/**/
}/**/
protected void btnSearch_Click(object sender, EventArgs e)/**/
{//**/
dt = (DataTable)Session["product"];/*It works to
* restore the original data of the product...*/
if (dt != null)/**/
{//**/
if (dt.Rows.Count > 0)/**/
{//*/
dv = new DataView(dt);
dv.RowFilter = "ProductName LIKE '%" + txtSearchInput.Value.Trim() + "%'"; // values
 // that contain 'search term'
if(dv.Count > 0)/*******/
{//*//
rProducts.DataSource = dv;/**********/
}/**/
else/**/
{//**/
rProducts.DataSource = dv;/***/
rProducts.FooterTemplate = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);/****/
}/**/
rProducts.DataBind();/******/
}//**/
else/**/
{//**/
rProducts.DataSource = dt;/*Helps set the source designation
* for data while preparing it for display*/
rProducts.FooterTemplate = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);/**/
}//**..*/
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
}//**/
}//**/
protected void ddlSortBy_SelectedIndexChanged(object sender, EventArgs e)/**/
{/**/
if (ddlSortBy.SelectedIndex != 0)/**/
{//*//*
dt = (DataTable)Session["product"];/**/
if (dt != null)/**/
{//**/
if (dt.Rows.Count > 0)/**/
{//**//
dv = new DataView(dt);/**/
if (ddlSortBy.SelectedIndex == 1) // Sort by latest
{//**/
dv.Sort = "CreatedDate ASC";/**/
}//**/
else if (ddlSortBy.SelectedIndex == 2)//* Sort by A to Z*//
{/*..*/
dv.Sort = "ProductName ASC";/**/
}//**//
else // //**//Sort by price//**//
{//**//
dv.Sort = "Price ASC";/**/
}//**//
if (dv.Count > 0)/**/
{//**//
rProducts.DataSource = dv;/**/
}//**//
{//**//
rProducts.DataSource = dv;/**/
rProducts.FooterTemplate = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);/**/
}//**//
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
}//**//
else/**/
{//**//
rProducts.DataSource = dt;/*Helps set the source designation
* for data while preparing it for display*/
rProducts.FooterTemplate = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.FooterTemplate = new CustomTemplate(ListItemType.Footer);
}//**//
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
}//**//
}//**//
else//**//
{//*//
rProducts.DataSource = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.DataSource = (DataTable)Session["product"];/*It works to
* restore the original data of the product...*/
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
}//*//
}//*//
void lblMessage(string textMessage, string cssClass)//**/
{/**/
lblMsg.Visible = true;/*..Displays the label for the message....*/
lblMsg.Text = textMessage;/*/Refer to invalid 
* enter user text message*/
lblMsg.CssClass = "alert alert-" + cssClass + "";/*...*/
}/**/
/*/ Custom template class to add controls to the repeater's
// header, item and footer sections.*/
private sealed class CustomTemplate : ITemplate
{/**/
private ListItemType ListItemType { get; set; }/* to set 
* and get type of item*/
public CustomTemplate(ListItemType type)//**/
{//*//
ListItemType = type;//***//
}//*//
public void InstantiateIn(Control container)/*__*/
{//*//
if (ListItemType == ListItemType.Footer)/**/
{//*//
var footer = new LiteralControl("<b>No Product To Display.</b>");/*..*/
container.Controls.Add(footer);/**/
}//*//
}//*//
}//*//
protected void btnReset_Click(object sender, EventArgs e)/*It helps 
*to allow it to respond and interact with the user...*/
{///**/
rProducts.DataSource = null;/*It resets the data source 
* to null by effectively clearing previously associated data*/
rProducts.DataSource = (DataTable)Session["product"];/*It works to
* restore the original data of the product...*/
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
txtSearchInput.Value = string.Empty;/*It resets the user's search 
* criteria while erasing any text in the search entry field....*/
} //*//   
protected void btnSortReset_Click(object sender, EventArgs e)/*It helps 
*to allow it to respond and interact with the user...*/
{//*//
rProducts.DataSource = null;///*It resets the data source to null 
/*by effectively clearing previously associated data*/
rProducts.DataSource = (DataTable)Session["product"];/*It works to
* restore the original data of the product...*/
rProducts.DataBind();/*Updates the user interface with updated data
* source Linking to restored product data...*/
ddlSortBy.ClearSelection();/**/
}//*//
}//*//
}//*//