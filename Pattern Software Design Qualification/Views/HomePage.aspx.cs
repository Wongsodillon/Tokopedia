using Pattern_Software_Design_Qualification.Controllers;
using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        public List<Product> Products;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session) && !Auth.HasCookie(Request))
            {
                // Redirect to LoginPage
                Redirect.LoginPage(Response);
                return;
            }
            if (Auth.GetUser(Session) == null)
            {
                // Use Cookie to login
                String cookie = Auth.GetCookieValue(Request);
                Response<User> userResponse = UserController.LoginByCookie(cookie);
                if (!userResponse.IsSuccess)
                {
                    Auth.RemoveCookie(Request, Response);
                    Redirect.LoginPage(Response);
                    return;
                }
                else
                {
                    Auth.SetUser(Session, userResponse.Payload);
                }
            }
            FetchProducts();
        }
        public void FetchProducts()
        {
            User currentUser = Auth.GetUser(Session);
            Response<List<Product>> response = ProductController.GetProducts(currentUser);
            if (response.IsSuccess)
            {
                Products = response.Payload;
            }
        }
        protected void ViewDetailButton_Command(object sender, CommandEventArgs e)
        {
            String productID = e.CommandName;
            Response.Redirect("~/Views/ProductDetails.aspx?Id=" + productID);
        }
    }
}