using System; // Import system namespace
using System.Collections.Generic; // Import collections namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Data; // Import data namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web controls namespace
namespace EShopping.Admin // Define namespace
{//
public partial class SellingReport : System.Web.UI.Page //
//Define class inheriting Page
{//
SqlConnection con; // Declare SQL connection
SqlCommand cmd; // Declare SQL command
SqlDataAdapter sda; // Declare SQL data adapter
DataTable dt; // Declare data table
protected void Page_Load(object sender, EventArgs e) // Page
// load event handler
{//
if (!IsPostBack) // Check if not postback
{//
Session["breadCrumbTitle"] = "Selling Report"; // Set breadcrumb title
Session["breadCrumbPage"] = "SellingReport"; // Set breadcrumb page
if (Session["userId"] == null) // Check if user ID null
{//
Response.Redirect("../User/Login.aspx"); // Redirect to login
}//
else if (Session["roleId"].ToString() == "1") // Check if admin role
{//
// Do nothing
}//
else // Else block
{//
Response.Redirect("../User/Default.aspx"); // Redirect to default
}//
lblMsg.Visible = false; // Hide message label
}//
}//
protected void btnSearch_Click(object sender, EventArgs e) // Search button click event handler
{//
DateTime fromDate = Convert.ToDateTime(txtFromDate.Text); // Convert from date
DateTime toDate = Convert.ToDateTime(txtToDate.Text); // Convert to date
if (toDate > DateTime.Now) // Check if toDate is greater than current date
{//
Response.Write("<script>alert('To Date Cannot be" +
" Greater than Current Date!');</script>"); // Show alert
}//
 else if (fromDate > toDate) // Check if fromDate is greater than toDate
{//
Response.Write("<script>alert('FromDate cannot be greater than ToDate!');</script>"); // Show alert
}//
else // Else block
{//
getReportData(fromDate, toDate); // Call getReportData method
}//
}//
private void getReportData(DateTime fromDate, DateTime toDate) // Method to get report data
{//
double grandTotal = 0; // Initialize grand total
con = new SqlConnection(Utils.getConnection()); // Get SQL connection
cmd = new SqlCommand("SellingReport", con); // Set stored procedure
cmd.Parameters.AddWithValue("@FromDate", fromDate); // Add from date parameter
cmd.Parameters.AddWithValue("@ToDate", toDate); // Add to date parameter
cmd.CommandType = CommandType.StoredProcedure; // Set command type
sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
dt = new DataTable(); // Initialize data table
sda.Fill(dt); // Fill data table
if (dt.Rows.Count > 0) // Check if rows exist
{//
foreach (DataRow drow in dt.Rows) // Loop through data rows
{//
grandTotal += Convert.ToDouble(drow["TotalPrice"]); // Calculate grand total
 }//
lblTotal.Text = "Sold Cost: OMR" + grandTotal; // Set total label text
lblTotal.CssClass = "badge badge-primary"; // Set total label CSS class
}//
rReport.DataSource = dt; // Set repeater data source
rReport.DataBind(); // Bind repeater data
}//
}//
}//
