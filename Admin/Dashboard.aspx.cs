using System;/*Import system namespace*/
using System.Collections.Generic;/*Import generic collections*/
using System.Linq;/*Import LINQ capabilities*/
using System.Web;/*Import web functionalities*/
using System.Web.UI;/*Import UI functionalities*/
using System.Web.UI.WebControls;/*Import web controls*/
namespace EShopping.Admin/*Define namespace*/
{/**/
public partial class Dashboard : System.Web.UI.Page/*
* Define Dashboard class and Inherit from Page*/
{/**/
protected void Page_Load(object sender, EventArgs e)/*page
* Load event handler and Parameters for handler*/
{/**/
Session["breadCrumbTitle"] = "Dashboard";/*et breadcrumb
* title and set to "Dashboard*/
Session["breadCrumbPage"] = "";/*Set breadcrumb
* page and Set to empty string*/
if (Session["userId"] == null)/*If userId session null check if null*/
{/**/
Response.Redirect("../User/Login.aspx");/*edirect to login page,login page url*/
}/**/
else if (Session["roleId"].ToString() == "1")/*If roleId session
* equals,check if 1*/
{/**/
Utils utils = new Utils();/*Create Utils object,Instantiate Utils*/
Session["category"] = Convert.ToInt32(utils.dashboardCount("CATEGORY"));/*
* set category count,convert to int,get count*/
Session["subCategory"] = Convert.ToInt32(utils.dashboardCount("SUBCATEGORY"));/*/*
* set sub category count,convert to int,get count*/
Session["product"] = Convert.ToInt32(utils.dashboardCount("PRODUCT"));/*
* set product count,convert to int,get count*/
Session["order"] = Convert.ToInt32(utils.dashboardCount("ORDER"));/*
* set order count,convert to int,get count*/
Session["pending"] = Convert.ToInt32(utils.dashboardCount("PENDING"));/*
* set pending count,convert to int,get count*/
Session["dispatched"] = Convert.ToInt32(utils.dashboardCount("DISPATCHED"));/*
* set dispatched count,convert to int,get count*/
Session["outForDelivery"] = Convert.ToInt32(utils.dashboardCount("OUT4DELIVERY"));/*
* set outForDelivery count,convert to int,get count*/
Session["delivered"] = Convert.ToInt32(utils.dashboardCount("DELIVERED"));/*
* set delivered count,convert to int,get count*/
Session["ltSoldAmount"] = Convert.ToInt32(utils.dashboardCount("LIFETIME_SOLD_AMOUNT"));/*
* set ltSoldAmount count,convert to int,get count*/
Session["lmSoldAmount"] = Convert.ToInt32(utils.dashboardCount("LASTMONTH_SOLD_AMOUNT"));/*
* set lmSoldAmount count,convert to int,get count*/
Session["user"] = Convert.ToInt32(utils.dashboardCount("USER"));/*
* set user count,convert to int,get count*/
 Session["contact"] = Convert.ToInt32(utils.dashboardCount("CONTACT"));/*
* set contact count,convert to int,get count*/
}/**/
else if (Session["roleId"].ToString() == "3")/**/
{/**/
Utils utils = new Utils();/*Create Utils object,Instantiate Utils*/
Session["product"] = Convert.ToInt32(utils.dashboardCount("PRODUCT"));/*/*
* set product count,convert to int,get count*/
Session["order"] = Convert.ToInt32(utils.dashboardCount("ORDER"));/*
* set order count,convert to int,get count*/
}/**/
else/**/
{/**/
Response.Redirect("../User/Default.aspx");/*Redirect to default page,Default page URL*/
}/**/
}/**/
}/**/
}/**/