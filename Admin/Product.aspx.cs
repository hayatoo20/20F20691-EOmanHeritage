using System;// Import base class library
using System.Collections.Generic;// Import generic collections
using System.Data.SqlClient;// Import SQL client library
using System.Data;// Import data handling library
using System.Linq;// Import LINQ library
using System.Web;// Import web handling library
using System.Web.UI;// Import web UI library
using System.Web.UI.WebControls;// Import web UI controls library
using System.IO;// Import file handling library
using static System.Net.Mime.MediaTypeNames;// Import media type names statically
namespace EShopping.Admin// Define namespace
{/**/
public partial class Product : System.Web.UI.Page// Define class
{/**/
SqlConnection con; // Declare SQL connection
SqlCommand cmd;// Declare SQL command
SqlDataAdapter sda;// Declare SQL data adapter
DataTable dt, dt1;// Declare data tables
string[] imagePath;// Declare image paths array
ProductObj productObj;// Declare product object
ProductDAL productDAL;// Declare data access layer
 List<ProductImageObj> productImages = new List<ProductImageObj>(); // Declare product images list
int defaultImgAfterEdit = 0;   // Declare default image index
protected void Page_Load(object sender, EventArgs e) // Page load event handler
{/**/
Session["breadCrumbTitle"] = "Product"; // Set breadcrumb title
Session["breadCrumbPage"] = "Product";  // Set breadcrumb page
if (!IsPostBack)// Check if page is not postback
{/**/
if (Session["userId"] == null)  // Check if user not logged in
{/**/
Response.Redirect("../User/Login.aspx"); // Redirect to login
}/**/
else if (Session["roleId"].ToString() == "1")// Check if user is admin
{/**/
getCategories();// Get categories
if (Request.QueryString["id"] != null)// Check if product ID is present
{/**/
GetProductDetails(); /*Get product details*/
}/**/
}/**/
else if (Session["roleId"].ToString() == "3")// Check if user is vendor
{/**/

GetProductDetails();/*Get product details*/
}/**/

else/**/
{/**/
Response.Redirect("../User/Default.aspx");// Redirect to default
}/**/
}/**/
lblMsg.Visible = false;// Hide message label
}/**/
private void getCategories()// Get categories method
{/**/
con = new SqlConnection(Utils.getConnection()); // Initialize SQL connection
cmd = new SqlCommand("Category_Crud", con); // Initialize SQL command
cmd.Parameters.AddWithValue("@Action", "GETALL"); // Add action parameter
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize data adapter
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
ddlCategory.DataSource = dt; // Set dropdown data source
ddlCategory.DataTextField = "CategoryName"; // Set text field
ddlCategory.DataValueField = "CategoryId"; // Set value field
ddlCategory.DataBind(); // Bind data to dropdown
}/**/
protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e) // Category change handler
{/**/
getSubCategories(Convert.ToInt32(ddlCategory.SelectedValue)); // Get subcategories
}/**/
void getSubCategories(int categoryId) // Get subcategories method
{/**/
con = new SqlConnection(Utils.getConnection()); // Initialize SQL connection
cmd = new SqlCommand("SubCategory_Crud", con); // Initialize SQL command
cmd.Parameters.AddWithValue("@Action", "SUBCATEGORYBYID"); // Add action parameter
cmd.Parameters.AddWithValue("@CategoryId", categoryId); // Add category ID parameter
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize data adapter
dt1 = new DataTable(); // Initialize data table
sda.Fill(dt1); // Fill data table
ddlSubCategory.Items.Clear(); // Clear dropdown items
ddlSubCategory.DataSource = dt1; // Set dropdown data source
ddlSubCategory.DataTextField = "SubCategoryName"; // Set text field
ddlSubCategory.DataValueField = "SubCategoryId"; // Set value field
ddlSubCategory.DataBind();    // Bind data to dropdown
ddlSubCategory.Items.Insert(0, "Select SubCategory"); // Insert default item
}/**/
void GetProductDetails() // Get product details method
{/**/
if (Request.QueryString["id"] != null) // Check if product ID is present
{/**/
int productId = Convert.ToInt32(Request.QueryString["id"]); // Get product ID
productDAL = new ProductDAL(); // Initialize data access layer
dt = productDAL.ProductByIdWithImages(productId); // Get product data
if (dt.Rows.Count > 0) // Check if data exists
{/**/
txtProductName.Text = dt.Rows[0]["ProductName"].ToString(); // Set product name
txtPrice.Text = dt.Rows[0]["Price"].ToString(); // Set price
txtQuantity.Text = dt.Rows[0]["Quantity"].ToString(); // Set quantity
txtShortDescription.Text = dt.Rows[0]["ShortDescription"].ToString(); // Set short description
txtLongDescription.Text = dt.Rows[0]["LongDescription"].ToString(); // Set long description
txtAdditionalDescription.Text = dt.Rows[0]["AdditionalDescription"].ToString(); // Set additional description
string[] color = dt.Rows[0]["Color"].ToString().Split('\u002C'); // Get colors
string[] size = dt.Rows[0]["Size"].ToString().Split('\u002C'); // Get sizes
for (int i = 0; i < color.Length - 1; i++) // Loop through colors
{/**/
lboxColor.Items.FindByText(color[i]).Selected = true; // Select color
}/**/
for (int i = 0; i < size.Length - 1; i++) // Loop through sizes
{/**/
lboxSize.Items.FindByText(size[i]).Selected = true;// Select size from list
}/**/
txtTags.Text = dt.Rows[0]["Tags"].ToString(); // Set tags text field
txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString(); // Set company name field
ddlCategory.SelectedValue = dt.Rows[0]["CategoryId"].ToString(); // Set category dropdown value
getSubCategories(Convert.ToInt32(dt.Rows[0]["CategoryId"])); // Get subcategories for category
ddlSubCategory.SelectedValue = dt.Rows[0]["SubCategoryId"].ToString(); // Set subcategory dropdown value
cbIsCustomized.Checked = Convert.ToBoolean(dt.Rows[0]["IsCustomized"]); // Set customized checkbox state
cbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]); // Set active checkbox state
rblDefaultImage.SelectedIndex = Convert.ToInt32(dt.Rows[0]["DefaultImage"]); // Set default image index
hfDefImgagePos.Value = (Convert.ToInt32(dt.Rows[0]["DefaultImage"]) + 1).ToString(); // Set hidden image position
imgProduct1.ImageUrl = "../" + dt.Rows[0]["Image1"].ToString().Substring(0, dt.Rows[0]["Image1"].ToString().IndexOf(":")); // Set product 1 image URL
imgProduct2.ImageUrl = "../" + dt.Rows[0]["Image2"].ToString().Substring(0, dt.Rows[0]["Image2"].ToString().IndexOf(":")); // Set product 2 image URL
imgProduct3.ImageUrl = "../" + dt.Rows[0]["Image3"].ToString().Substring(0, dt.Rows[0]["Image3"].ToString().IndexOf(":")); // Set product 3 image URL
imgProduct4.ImageUrl = "../" + dt.Rows[0]["Image4"].ToString().Substring(0, dt.Rows[0]["Image4"].ToString().IndexOf(":")); // Set product 4 image URL
imgProduct1.Width = 200; // Set product 1 width
imgProduct2.Width = 200; // Set product 2 width
imgProduct3.Width = 200; // Set product 3 width
imgProduct4.Width = 200; // Set product 4 width
imgProduct1.Style.Remove("display"); imgProduct2.Style.Remove("display"); // Show product 1 and 2
imgProduct3.Style.Remove("display"); imgProduct4.Style.Remove("display"); // Show product 3 and 4
btnAddOrUpdate.Text = "Update"; // Set button text
}/**/
}/**/
}/**/
protected void btnAddOrUpdate_Click(object sender, EventArgs e)// Button click event handler
{/**/
try/**/
{/**/
string selectedColor = string.Empty; // Initialize color variable
string selectedSize = string.Empty; // Initialize size variable
bool isValid = false; // Initialize valid flag
bool isValidToExecute = false; // Initialize execution flag
List<string> list = new List<string>(); // Initialize string list
bool isImageSaved = false; // Initialize image save flag
if (Request.QueryString["id"] == null)// Check if ID is null
{ /**/
if (fuFirstImage.HasFile && fuSecondImage.HasFile && fuThirdImage.HasFile && fuFourthImage.HasFile)// Check all images uploaded
{ /**/
list.Add(fuFirstImage.FileName); // Add first image file
list.Add(fuSecondImage.FileName); // Add second image file
list.Add(fuThirdImage.FileName); // Add third image file
list.Add(fuFourthImage.FileName); // Add fourth image file
string[] fu = list.ToArray(); // Convert list to array
#region Validate images/**/
for (int i = 0; i <= fu.Length - 1; i++)// Loop through images
{/**/
if (Utils.IsValidExtension(fu[i]))// Check image extension
{/**/
isValid = true; // Set valid flag true
}/**/
else/**/
{// Else block 
isValid = false; // Set valid flag false
break; // Break loop
}/**/
}/**/
#endregion
#region After image validation proceeding to add product
if (isValid)// Check if valid
{ /**/
imagePath = Utils.getImagesPath(fu); // Get image paths
for (int i = 0; i <= imagePath.Length - 1; i++)/**/
{ // Loop through image paths
for (int j = i; j <= rblDefaultImage.Items.Count - 1;)
{ // Loop through radio buttons
productImages.Add(new ProductImageObj()/**/
{ // Add product image
ImageUrl = imagePath[i], // Set image URL
DefaultImage = Convert.ToBoolean(rblDefaultImage.Items[j].Selected) // Set default image
});/**/
break; // Break loop
}/**/
#region saving all images
if (i == 0)// If first image
{ /**/
fuFirstImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") + 
imagePath[i].Replace("Images/Product/", "")); // Save first image
isImageSaved = true; // Set image saved
}/**/
else if (i == 1)// If second image
{/**/
fuSecondImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") +
imagePath[i].Replace("Images/Product/", "")); // Save second image
isImageSaved = true; // Set image saved
}//
else if (i == 2)// If third image
{ //
fuThirdImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") +
imagePath[i].Replace("Images/Product/", "")); // Save third image
isImageSaved = true; // Set image saved
}//
else if (i == 3)//
{ // If fourth image
fuFourthImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") +
imagePath[i].Replace("Images/Product/", "")); // Save fourth image
isImageSaved = true; // Set image saved
}//
#endregion
}//
#region saving new product data//
if (isImageSaved)//// If image saved
{//
selectedColor = Utils.getItemWithCommaSeparater(lboxColor); // Get selected colors
selectedSize = Utils.getItemWithCommaSeparater(lboxSize); // Get selected sizes
productDAL = new ProductDAL(); // Initialize product DAL
productObj = new ProductObj()// Create product object
{//
ProductId = Request.QueryString["id"] == null ? 0 : Convert.ToInt32(Request.QueryString["id"]), // Set product ID
ProductName = txtProductName.Text.Trim(), // Set product name
ShortDescription = txtShortDescription.Text.Trim(), // Set short description
LongDescription = txtLongDescription.Text.Trim(), // Set long description
AdditionalDescription = txtAdditionalDescription.Text.Trim(), // Set additional description
Price = Convert.ToDecimal(txtPrice.Text.Trim()), // Set price
Quantity = Convert.ToInt32(txtQuantity.Text.Trim()), // Set quantity
Size = selectedSize, // Set size
Color = selectedColor, // Set color
CompanyName = txtCompanyName.Text.Trim(), // Set company name
Tags = txtTags.Text.Trim(), // Set tags
CategoryId = Convert.ToInt32(ddlCategory.SelectedValue), // Set category ID
SubCategoryId = Convert.ToInt32(ddlSubCategory.SelectedValue), // Set subcategory ID
IsCustomized = cbIsCustomized.Checked, // Set customized flag
IsActive = cbIsActive.Checked, // Set active flag
ProductImages = productImages // Set product images
};/**/
int r = productDAL.AddUpdateProduct(productObj); // Add or update product
if (r > 0)// If successful
{ /**/
lblMessage("Product saved succesfull.", "success"); // Display success message
Response.AddHeader("REFRESH", "2;URL=ProductList.aspx"); // Refresh page
}/**/
else/**/
{ // Else block
DeleteFile(imagePath); // Delete images
lblMessage("Cannot save record right now!", "warning"); // Display warning message
}/**/
}/**/
else/**/
{/**/
DeleteFile(imagePath); // Delete images
}/**/
#endregion/**/
}/**/
else/**/
{ // Else block
lblMessage("Please select .jpg, .jpeg, .png file for image!",
"warning"); // Display warning message
}/**/
#endregion/**/
}/**/
else/**/
{ // Else block
lblMessage("Please select all product images", "warning"); //
// Display warning message
}/**/
}/**/
else/**/
{ // Else bloc
// Update product with images
if (fuFirstImage.HasFile && fuSecondImage.HasFile &&
fuThirdImage.HasFile && fuFourthImage.HasFile)
{/**/
list.Add(fuFirstImage.FileName); // Add first image file
list.Add(fuSecondImage.FileName); // Add second image file
list.Add(fuThirdImage.FileName); // Add third image file
list.Add(fuFourthImage.FileName); // Add fourth image file
string[] fu = list.ToArray(); // Convert list to array
#region Validate images
for (int i = 0; i <= fu.Length - 1; i++)// Loop through images
{ // 
if (Utils.IsValidExtension(fu[i]))// Check image extension
{ //
isValid = true; // Set valid flag true
}//
else//
{ // Else block
isValid = false; // Set valid flag false
break; // Break loop
}//
}//
#endregion
#region After image validation saving all images
if (isValid)// Check if valid
{ //
imagePath = Utils.getImagesPath(fu); // Get image paths
for (int i = 0; i <= imagePath.Length - 1; i++)
{ // Loop through image paths
for (int j = i; j <= rblDefaultImage.Items.Count - 1;)
{ // Loop through radio buttons
productImages.Add(new ProductImageObj()
{ // Add product image
ImageUrl = imagePath[i], // Set image URL
 DefaultImage = Convert.ToBoolean(rblDefaultImage.Items[j].Selected) // Set default image
});//
break; /// Break loop
}//
#region saving all images
if (i == 0)//If first image
{ // 
fuFirstImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") 
+ imagePath[i].Replace("Images/Product/", "")); // Save first image
isImageSaved = true; // Set image saved
}//
else if (i == 1)// If second image
{ //
fuSecondImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") +
imagePath[i].Replace("Images/Product/", "")); // Save second image
isImageSaved = true; // Set image saved
}//
else if (i == 2)//If third image
{ // 
fuThirdImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") +
imagePath[i].Replace("Images/Product/", "")); // Save third image
isImageSaved = true; // Set image saved
}//
else if (i == 3)// If fourth image
{ // 
fuFourthImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") +
imagePath[i].Replace("Images/Product/", "")); // Save fourth image
isImageSaved = true; // Set image saved
}//
#endregion
}//
if (isImageSaved)//
{ // If image saved
isValidToExecute = true; // Set execution flag
}//
else//
{ // Else block
DeleteFile(imagePath); // Delete images
}//
}//
else//
{ // Else block
lblMessage("Please select .jpg, .jpeg, .png file for image!",
"warning"); // Display warning message
}//
#endregion
}/**/
else if (fuFirstImage.HasFile || fuSecondImage.HasFile ||
fuThirdImage.HasFile || fuFourthImage.HasFile)
{ // Check if any image
lblMessage("Please add all 4 images if want to update images",
"warning"); // Display warning message
}//
else//
{ // Else block
if (Convert.ToInt32(hfDefImgagePos.Value) !=
Convert.ToInt32(rblDefaultImage.SelectedValue))
{ // Check default image
defaultImgAfterEdit = Convert.ToInt32(rblDefaultImage.
SelectedValue); // Set default image position
}
isValidToExecute = true; // Set execution flag
}//
#region Updating product
if (isValidToExecute)//
{ // Check if valid to execute
selectedColor = Utils.getItemWithCommaSeparater(lboxColor); // Get selected colors
selectedSize = Utils.getItemWithCommaSeparater(lboxSize); // Get selected sizes
productDAL = new ProductDAL(); // Initialize product DAL
productObj = new ProductObj()
{ // Create product object
ProductId = Convert.ToInt32(Request.QueryString["id"]), // Set product ID
ProductName = txtProductName.Text.Trim(), // Set product name
ShortDescription = txtShortDescription.Text.Trim(), // Set short description
LongDescription = txtLongDescription.Text.Trim(), // Set long description
AdditionalDescription = txtAdditionalDescription.Text.Trim(), // Set additional description
Price = Convert.ToDecimal(txtPrice.Text.Trim()), // Set price
Quantity = Convert.ToInt32(txtQuantity.Text.Trim()), // Set quantity
Size = selectedSize, // Set size
Color = selectedColor, // Set color
CompanyName = txtCompanyName.Text.Trim(), // Set company name
Tags = txtTags.Text.Trim(), // Set tags
CategoryId = Convert.ToInt32(ddlCategory.SelectedValue), // Set category ID
SubCategoryId = Convert.ToInt32(ddlSubCategory.SelectedValue), // Set subcategory ID
IsCustomized = cbIsCustomized.Checked, // Set customized flag
IsActive = cbIsActive.Checked, // Set active flag
ProductImages = productImages, // Set product images
DefaultImagePosition = defaultImgAfterEdit // Set default image position
};//
int r = productDAL.AddUpdateProduct(productObj); // Add or update product
if (r > 0)//
{ // If successful
lblMessage("Product updated succesfull.", "success"); // Display success message
Response.AddHeader("REFRESH", "2;URL=ProductList.aspx"); // Refresh page
}//
else//
{ // Else block
lblMessage("Cannot update record right now!", "warning"); // Display warning message
}//
}//
else//
{ // Else block
lblMessage("Something went wrong..", "danger"); // Display error message
}//
#endregion
}//
}//
catch (Exception ex)// Catch block
{ //
Response.Write("<script>alert('" + ex.Message + "');</script>"); // Display exception message
}//
}//
void DeleteFile(string[] filepath)// Delete file method
{ // 
for (int i = 0; i <= filepath.Length - 1; i++)// Loop through file paths
{ // 
if (File.Exists(Server.MapPath("~/" + filepath[i])))// Check if file exists
{// 
File.Delete(Server.MapPath("~/" + filepath[i])); // Delete file
}//
}//
}//
void lblMessage(string textMessage, string cssClass)//
{ // Label message method
lblMsg.Visible = true; // Show label
lblMsg.Text = textMessage; // Set label text
lblMsg.CssClass = "alert alert-" + cssClass + ""; // Set label CSS class
}//
protected void btnClear_Click(object sender, EventArgs e)//
{ // Clear button click event
clear(); // Call clear method
}//
private void clear()// Clear method
{ /**/
txtProductName.Text = string.Empty; // Clear product name
txtShortDescription.Text = string.Empty; // Clear short description
txtLongDescription.Text = string.Empty; // Clear long description
txtAdditionalDescription.Text = string.Empty; // Clear additional description
txtPrice.Text = string.Empty; // Clear price
txtQuantity.Text = string.Empty; // Clear quantity
txtCompanyName.Text = string.Empty; // Clear company name
lboxSize.ClearSelection(); // Clear size selection
lboxColor.ClearSelection(); // Clear color selection
txtTags.Text = string.Empty; // Clear tags
ddlCategory.ClearSelection(); // Clear category selection
ddlSubCategory.ClearSelection(); // Clear subcategory selection
rblDefaultImage.ClearSelection(); // Clear default image selection
cbIsCustomized.Checked = false; // Uncheck customized checkbox
cbIsActive.Checked = false; // Uncheck active checkbox
}/**/
}/**/
}/**/




