using System;/*Importing basic system functionalities*/
using System.Collections.Generic;/*Importing collections
* functionalities*/
using System.Linq;/*Importing LINQ functionalities*/
using System.Web;/*Importing web-related functionalities*/
using System.Web.UI;/*Importing ASP.NET web UI functionalities*/
using System.Web.UI.WebControls;/*Importing ASP.NET web UI controls*/
using System.Xml.Linq;/*Importing XML functionalities*/
using System.Data.SqlClient;/*Importing SQL Server database
* functionalities*/
using System.Data;/*Importing ADO.NET data functionalities*/
using iTextSharp.text.pdf;/*Importing iTextSharp for PDF generation*/
using iTextSharp.text;/*Importing iTextSharp text functionalities*/
using System.IO;/*Importing input-output functionalities*/
using System.Net;/*Importing networking functionalities*/
namespace EShopping.User/*Defining a namespace*/
{/**/
public partial class Invoice : System.Web.UI.Page/*Defining
* a partial class Invoice*/
{/* */
SqlConnection con;/*Declaring SqlConnection object*//**/
SqlCommand cmd;/*Declaring SqlCommand object*/
SqlDataAdapter sda;/*Declaring SqlDataAdapter object*/
DataTable dt;/*Declaring DataTable object*/
protected void Page_Load(object sender, EventArgs e)/*
* Page Load event handler*/
{/**/
if (!IsPostBack)/*checking if page is not being loaded for the first time*/
{/**/
if (Session["userId"] != null)/*Checking if user is logged in*/
{/**/
if (Request.QueryString["id"] != null)/*Checking if
* order ID is present in query string*/
{/**/
rOrderItem.DataSource = GetOrderDetails();/*Binding
* order details to a control*/
rOrderItem.DataBind();/*Binding data to the control*/
}/**/
else/**/
{/**/
Response.Redirect("Checkout.aspx");/*Redirecting to checkout page*/
}/**/
}/**/
else/**/
{/**/
Response.Redirect("Login.aspx");/*Redirecting to login page*/
}/**/
}/**/
}/**/
 DataTable GetOrderDetails()/*Method to retrieve
* order details from the database*/
{/**/
double grandTotal = 0;/*Initializing grand total variable*/
con = new SqlConnection(Utils.getConnection());/*Creating
* SqlConnection object*/
cmd = new SqlCommand("Invoice", con);/*Creating SqlCommand
* object with stored procedure name*/
cmd.Parameters.AddWithValue("@Action", "INVOICEBYID");/*Adding
* parameter to command*/
cmd.Parameters.AddWithValue("@PaymentId", Convert.ToInt32(Request.
QueryString["id"]));/*Adding parameter to command*/
cmd.Parameters.AddWithValue("@UserId", Session
["userId"]);/*Adding parameter to command*/
cmd.CommandType = CommandType.StoredProcedure;/*
* Setting command type to stored procedure*/
sda = new SqlDataAdapter(cmd);/*Creating SqlDataAdapter object*/
dt = new DataTable();/*Creating DataTable object*/
sda.Fill(dt);/* Filling DataTable with data from SqlDataAdapter*/
if (dt.Rows.Count > 0)/*Checking if DataTable contains rows*/
{/**/
foreach (DataRow drow in dt.Rows)/*Looping through rows of DataTable*/
{/**/
grandTotal += Convert.ToDouble(drow["TotalPrice"]);/*Calculating grand total*/
}/**/
 }/**/
DataRow dr = dt.NewRow();/*Creating a new row for DataTable*/
dr["TotalPrice"] = grandTotal;/*Assigning grand total to the new row*/
dt.Rows.Add(dr);/*Adding new row to DataTable*/
return dt;/*Returning DataTable*/
}/**/
 protected void lbDownloadInvoice_Click(object sender, EventArgs e)/*
 * Download Invoice button click event handler*/
{/**/
try/**/
{/**/
string downloadPath = @"E:\order_invoice.pdf";/*Setting download path for PDF*/
DataTable dtbl = GetOrderDetails();/*Retrieving order details*/
ExportToPdf(dtbl, downloadPath, "Order Invoice");/*Exporting
* order details to PDF*/
WebClient client = new WebClient();/*Creating WebClient object*/
Byte[] buffer = client.DownloadData(downloadPath);/*Downloading PDF file*/
if (buffer != null)/*Checking if buffer is not null*/
{/**/
 Response.ContentType = "application/pdf";/*Setting response content type*/
Response.AddHeader("content-length", buffer.Length.ToString());/*Adding
* content length header*/
Response.BinaryWrite(buffer);/*Writing binary data to response*/
}/**/
}/**/
catch (Exception ex)/**/
{/**/
lblMsg.Visible = true;/*Making error message label visible*/
lblMsg.Text = "Error Message: " + ex.Message.ToString();/*Setting error message*/
}/**/
}/**/
void ExportToPdf(DataTable dtblTable, String strPdfPath, string strHeader)/*
* Method to export DataTable to PDF*/
{/**/
FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.
Write, FileShare.None);/*Creating FileStream object*/
Document document = new Document();/* Creating Document object*/
document.SetPageSize(PageSize.A4);/*Setting page size*/
PdfWriter writer = PdfWriter.GetInstance(document, fs);/*
* Creating PdfWriter object*/
document.Open();/*Opening document*/
//Report Header
BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,
BaseFont.CP1252, BaseFont.NOT_EMBEDDED);/*Creating base font*/
Font fntHead = new Font(bfntHead, 16, 1, Color.GRAY);/*Creating font*/
Paragraph prgHeading = new Paragraph();/*Creating paragraph object*/
prgHeading.Alignment = Element.ALIGN_CENTER;/*Setting alignment*/
prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));/*
* Adding header text to paragraph*/
document.Add(prgHeading);/*Adding paragraph to document*/
//Author
Paragraph prgAuthor = new Paragraph();/*Creating paragraph object*/
BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,
BaseFont.CP1252, BaseFont.NOT_EMBEDDED);/*Creating base font*/
Font fntAuthor = new Font(btnAuthor, 8, 2, Color.GRAY);/*Creating font*/
prgAuthor.Alignment = Element.ALIGN_RIGHT;/* Setting alignment*/
prgAuthor.Add(new Chunk("Order From : EOmanHeritage With Love:)",
fntAuthor));/*Adding author information to paragraph*/
prgAuthor.Add(new Chunk("\nOrder Date : " + dtblTable.Rows[0]
["OrderDate"].ToString(), fntAuthor));/*Adding order date to paragraph*/
document.Add(prgAuthor);/*Adding paragraph to document*/
//Add a line seperation
Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.
LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));/*
* Creating paragraph object*/
document.Add(p);/*Adding paragraph to document*/
//Add line break
document.Add(new Chunk("\n", fntHead));/*Adding chunk with line break*/
//Write the table
PdfPTable table = new PdfPTable(dtblTable.Columns.Count - 2);/*
* Creating PdfPTable object*/
//Table header
BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,
BaseFont.CP1252, BaseFont.NOT_EMBEDDED);/*Creating base font*/
Font fntColumnHeader = new Font(btnColumnHeader, 9, 1, Color.WHITE);/*
* Creating font*/
for (int i = 0; i < dtblTable.Columns.Count - 2; i++)/*Looping through columns*/
{/**/
PdfPCell cell = new PdfPCell();/*Creating PdfPCell object*/
cell.BackgroundColor = Color.GRAY;/*Setting background color*/
cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(),
fntColumnHeader));/*Adding column name to cell*/
table.AddCell(cell);/*Adding cell to table*/
}/**/
//table Data
Font fntColumnData = new Font(btnColumnHeader, 8, 1, 
Color.BLACK);/*Creating font for table data*/
for (int i = 0; i < dtblTable.Rows.Count; i++)/*Looping through rows*/
{/**/
for (int j = 0; j < dtblTable.Columns.Count - 2; j++)/*Looping through columns*/
{/**/
PdfPCell cell = new PdfPCell();/*Creating PdfPCell object*/
cell.AddElement(new Chunk(dtblTable.Rows[i][j].ToString(),
fntColumnData));/*Adding data to cell*/
table.AddCell(cell);/*Adding cell to table*/
}/**/
}/**/
document.Add(table);/*Adding table to document*/
document.Close();/* Closing document*/
writer.Close();/*Closing writer*/
fs.Close();/*Closing file stream*/
}/**/
}/**/
}/**/