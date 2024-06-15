using System;/*/*Importing basic system functionalities*/
using System.Collections.Generic;/*/*Importing collections
* functionalities*/
using System.Linq;/*Importing LINQ functionalities*/
using System.Web;/*Importing web-related functionalities*/
using System.Web.UI;/*Importing ASP.NET web UI functionalities*/
using System.Web.UI.WebControls;/*Importing ASP.NET web UI controls*/
namespace EShopping.User/*Defining a namespace*/
{/**/
public partial class NewRating : System.Web.UI.Page/*Defining
* a partial class NewRating*/
{/**/
protected void Page_Load(object sender, EventArgs e)/*/*
* Page Load event handler*/
{/**/
}/**/
protected void submit_Click(object sender, EventArgs e)/**/
{/**/
Response.Write("<script>alert('" + Rating1.CurrentRating.ToString
() + "');</script>");/**/
}/**/
}/**/
}/**/