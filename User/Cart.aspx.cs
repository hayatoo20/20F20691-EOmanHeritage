using EShopping.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EShopping.User
{
    public partial class Cart : System.Web.UI.Page
    {
        decimal grandTotal = 0;
        Utils utils;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                getCartItem();
            }
            lblMsg.Visible = false;
        }

        private void getCartItem()
        {
            try
            {
                if (Session["userId"] != null)
                {
                    DataTable dt;
                    utils = new Utils();
                    dt = utils.CartItemByUserId();
                    if (dt.Rows.Count > 0)
                    {
                        rCart.DataSource = dt;
                        lbCheckOut.Enabled = true;
                    }
                    else
                    {
                        rCart.DataSource = dt;
                        lbCheckOut.Enabled = false;
                        rCart.FooterTemplate = null;
                        rCart.FooterTemplate = new CustomTemplate(ListItemType.Footer);
                    }
                    Session["cartCount"] = dt.Rows.Count.ToString();
                    //Session["price"] = Common.getCartProductPrice(dt);
                    rCart.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void rCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label totalPrice = e.Item.FindControl("lblTotalPrice") as Label;
                Label productPrice = e.Item.FindControl("lblPrice") as Label;
                HtmlInputText quantity = e.Item.FindControl("txtQuantity") as HtmlInputText;
                decimal calTotalPrice = Convert.ToDecimal(productPrice.Text) * Convert.ToDecimal(quantity.Value);
                totalPrice.Text = calTotalPrice.ToString();
                grandTotal += calTotalPrice;
            }
            Session["totalPrice"] = grandTotal;
        }

        protected void rCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            utils = new Utils();
            if (e.CommandName == "remove")
            {
                try
                {
                    int r = utils.deleteCartItem(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (r > 0)
                    {
                        lblMessage("Item removed successful from cart", "success");
                        getCartItem();
                    }
                    else
                    {
                        lblMessage("Cannot delete item from cart right now.", "warning");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else if (e.CommandName == "updateCart")
            {
                bool isCartUpdated = false;
                //foreach (RepeaterItem item in rCartItem.Items)
                for (int item = 0; item < rCart.Items.Count; item++)
                {
                    if (rCart.Items[item].ItemType == ListItemType.Item || rCart.Items[item].ItemType == ListItemType.AlternatingItem)
                    {
                        HtmlInputText quantity = rCart.Items[item].FindControl("txtQuantity") as HtmlInputText;
                        HiddenField _productId = rCart.Items[item].FindControl("hdnProductId") as HiddenField;
                        HiddenField _quantity = rCart.Items[item].FindControl("hdnQuantity") as HiddenField;
                        int quantityFromCart = Convert.ToInt32(quantity.Value);
                        int ProductId = Convert.ToInt32(_productId.Value);
                        int quantityFromDB = Convert.ToInt32(_quantity.Value);
                        bool isTrue = false;
                        int updatedQuantity = 1;
                        if (quantityFromCart > quantityFromDB)
                        {
                            updatedQuantity = quantityFromCart;
                            isTrue = true;
                        }
                        else if (quantityFromCart < quantityFromDB)
                        {
                            updatedQuantity = quantityFromCart;
                            isTrue = true;
                        }

                        if (isTrue)
                        {
                            //Update cart item quantity in db.
                            isCartUpdated = utils.updateCartQuantity(updatedQuantity, ProductId);
                        }
                    }
                }
                getCartItem();
            }
        }

        protected void lbCheckOut_Click(object sender, EventArgs e)
        {
            bool isTrue = false;
            string pName = string.Empty;

            // First will check item quantity
            foreach (RepeaterItem item in rCart.Controls)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField _cartQuantity = item.FindControl("hdnQuantity") as HiddenField;
                    HiddenField _productQuantity = item.FindControl("hdnPrdQuantity") as HiddenField;
                    Label productName = item.FindControl("lblProductName") as Label;

                    int cartQuantity = Convert.ToInt32(_cartQuantity.Value);
                    int productQuantity = Convert.ToInt32(_productQuantity.Value);

                    if (productQuantity > cartQuantity && productQuantity > 1)
                    {
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                        pName = productName.Text.ToString();
                        break;
                    }
                }
            }

            if (isTrue)
            {
                Response.Redirect("Checkout.aspx");
            }
            else
            {
                //lblMsg.Visible = true;
                //lblMsg.Text = "Item <b>'" + pName + "'</b> is out of stock :(";
                //lblMsg.CssClass = "alert alert-warning";
                string msg = "Item <b>'" + pName + "'</b> is out of stock :(";
                lblMessage(msg, "warning");
            }
        }

        void lblMessage(string textMessage, string cssClass)
        {
            lblMsg.Visible = true;
            lblMsg.Text = textMessage;
            lblMsg.CssClass = "alert alert-" + cssClass + "";
        }

        // Custom template class to add controls to the repeater's header, item and footer sections.
        private sealed class CustomTemplate : ITemplate
        {
            private ListItemType ListItemType { get; set; }

            public CustomTemplate(ListItemType type)
            {
                ListItemType = type;
            }

            public void InstantiateIn(Control container)
            {
                if (ListItemType == ListItemType.Footer)
                {
                    var footer = new LiteralControl("<tr><td colspan='5'><b>Your Cart is empty.</b></td></tr></tbody></table>");
                    container.Controls.Add(footer);
                }
            }
        }

    }
}