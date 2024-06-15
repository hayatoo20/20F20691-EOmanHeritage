using EShopping.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI.WebControls;

namespace EShopping
{
    public class Utils
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlDataReader sdr;
        DataTable dt;
        public static string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        public static bool IsValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".png", ".jpeg" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        // Generates Unique ID/VALUE
        public static string GetUniqueId()
        {
            Guid obj = Guid.NewGuid();
            return obj.ToString();
        }

        // Setting default image if their is no image for any job.
        public static string GetImageUrl(Object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "../Images/No_image.png";
            }
            else
            {
                url1 = string.Format("../{0}", url);
            }
            return url1;
        }

        public static string[] getImagesPath(string[] imagesArr)
        {
            List<string> list = new List<string>();
            string[] imagesPath = null;
            string fileExtension = string.Empty;
            for (int i = 0; i <= imagesArr.Length - 1; i++)
            {
                fileExtension = Path.GetExtension(imagesArr[i]);
                list.Add("Images/Product/" + GetUniqueId().ToString() + fileExtension);
            }
            return imagesPath = list.ToArray();
        }

        public static string getItemWithCommaSeparater(ListBox listBox)
        {
            string selectedItem = string.Empty;
            foreach (int i in listBox.GetSelectedIndices())
            {
                selectedItem += listBox.Items[i].Text + ",";
            }
            return selectedItem;
        }

        public int WishlistItemExist(int productId)
        {
            using (con = new SqlConnection(getConnection()))
            {
                try
                {
                    cmd = new SqlCommand("Wishlist_Crud", con);
                    cmd.Parameters.AddWithValue("@Action", "ITEMEXIST");
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    cmd.Dispose();
                    return dt.Rows.Count;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int AddToWishlist(int productId)
        {
            using (con = new SqlConnection(getConnection()))
            {
                try
                {
                    int result = 0;
                    cmd = new SqlCommand("Wishlist_Crud", con);
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = 1;
                    cmd.Dispose();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int itemCount(string type)
        {
            using (con = new SqlConnection(getConnection()))
            {
                try
                {
                    int result = 0;
                    string spName = type == "cart" ? "Cart_Crud" : "Wishlist_Crud";
                    cmd = new SqlCommand(spName, con);
                    cmd.Parameters.AddWithValue("@Action", "GETITEMCOUNT");
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        result = sdr.GetInt32(0);
                    }
                    cmd.Dispose();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int cartItemExistReturnQuantity(int productId)
        {
            using (con = new SqlConnection(getConnection()))
            {
                try
                {
                    cmd = new SqlCommand("Cart_Crud", con);
                    cmd.Parameters.AddWithValue("@Action", "GETBYID");
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    cmd.Dispose();
                    int result = dt.Rows.Count;
                    int quantity = 0;
                    if (result == 1)
                    {
                        quantity = Convert.ToInt32( dt.Rows[0]["Quantity"]);
                    }
                    return quantity;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int addOrUpdateCartItem(int productId, int quantity, string actionType)
        {
            using (con = new SqlConnection(getConnection()))
            {
                try
                {
                    int result = 0;
                    //cmd = new SqlCommand("Insert into Cart values(@ProductId,@Quantity,@UserId,@CreatedDate)", con);
                    cmd = new SqlCommand("Cart_Crud", con);
                    cmd.Parameters.AddWithValue("@Action", actionType);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = 1;
                    cmd.Dispose();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DataTable CartItemByUserId()
        {
            try
            {
                using (con = new SqlConnection(getConnection()))
                {
                    cmd = new SqlCommand("Cart_Crud", con);
                    cmd.Parameters.AddWithValue("@Action", "SELECTBYUSERID");
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

        public int deleteCartItem(int productId)
        {
            using (con = new SqlConnection(getConnection()))
            {
                try
                {
                    int result = 0;
                    cmd = new SqlCommand("Cart_Crud", con);
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = 1;
                    cmd.Dispose();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool updateCartQuantity(int quantity, int productId)
        {
            bool isUpdated = false;
            con = new SqlConnection(getConnection());
            cmd = new SqlCommand("Cart_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "UPDATE");
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@UserId", System.Web.HttpContext.Current.Session["userId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error - " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
            return isUpdated;
        }

        public int dashboardCount(string name)
        {
            int count = 0;
            con = new SqlConnection(getConnection());
            cmd = new SqlCommand("Dashboard", con);
            cmd.Parameters.AddWithValue("@Action", name);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr[0] == DBNull.Value)
                {
                    count = 0;
                }
                else
                {
                    count = Convert.ToInt32(sdr[0]);
                }
            }
            sdr.Close();
            con.Close();
            return count;
        }

    }
}