using System; // Import system namespace
using System.Collections.Generic; // Import collections namespace
using System.Data.SqlClient; // Import SQL client namespace
using System.Data; // Import data namespace
using System.Linq; // Import LINQ namespace
using System.Web; // Import web namespace
using System.Web.UI; // Import web UI namespace
using System.Web.UI.WebControls; // Import web controls namespace
using EShopping.User; // Import User namespace

namespace EShopping.Admin // Define namespace
{
    public partial class Users : System.Web.UI.Page // Define class inheriting Page
    {
        SqlConnection con; // Declare SQL connection
        SqlCommand cmd; // Declare SQL command
        SqlDataAdapter sda; // Declare SQL data adapter
        DataTable dt; // Declare data table

        protected void Page_Load(object sender, EventArgs e) // Page load event handler
        {
            if (!IsPostBack) // Check if not postback
            {
                Session["breadCrumbTitle"] = "Manage Users"; // Set breadcrumb title
                Session["breadCrumbPage"] = "Users"; // Set breadcrumb page
                if (Session["userId"] == null) // Check if user ID null
                {
                    Response.Redirect("../User/Login.aspx"); // Redirect to login
                }
                else if (Session["roleId"].ToString() == "1") // Check if admin role
                {
                    getUsers(); // Call getUsers method
                }
                else // Else block
                {
                    Response.Redirect("../User/Default.aspx"); // Redirect to default
                }
                lblMsg.Visible = false; // Hide message label
            }
        }

        private void getUsers() // Method to get users
        {
            con = new SqlConnection(Utils.getConnection()); // Get SQL connection
            cmd = new SqlCommand("User_Crud", con); // Set stored procedure
            cmd.Parameters.AddWithValue("@Action", "SELECT4ADMIN"); // Add action parameter
            cmd.CommandType = CommandType.StoredProcedure; // Set command type
            sda = new SqlDataAdapter(cmd); // Initialize SQL data adapter
            dt = new DataTable(); // Initialize data table
            sda.Fill(dt); // Fill data table
            rUsers.DataSource = dt; // Set repeater data source
            rUsers.DataBind(); // Bind repeater data
        }

        protected void rUsers_ItemCommand(object source, RepeaterCommandEventArgs e) // Repeater item command event handler
        {
            if (e.CommandName == "delete") // Check if command is delete
            {
                con = new SqlConnection(Utils.getConnection()); // Get SQL connection
                cmd = new SqlCommand("User_Crud", con); // Set stored procedure
                cmd.Parameters.AddWithValue("@Action", "DELETE"); // Add delete action parameter
                cmd.Parameters.AddWithValue("@UserId", e.CommandArgument); // Add user ID parameter
                cmd.CommandType = CommandType.StoredProcedure; // Set command type
                try // Begin try block
                {
                    con.Open(); // Open connection
                    cmd.ExecuteNonQuery(); // Execute query
                    lblMsg.Visible = true; // Show message label
                    lblMsg.Text = "User deleted successfully!"; // Set success message
                    lblMsg.CssClass = "alert alert-success"; // Set success class
                    getUsers(); // Refresh user list
                }
                catch (Exception ex) // Catch exceptions
                {
                    lblMsg.Visible = true; // Show message label
                    lblMsg.Text = "Error- " + ex.Message; // Set error message
                    lblMsg.CssClass = "alert alert-danger"; // Set error class
                }
                finally // Finally block
                {
                    con.Close(); // Close connection
                }
            }
        }
    }
}
