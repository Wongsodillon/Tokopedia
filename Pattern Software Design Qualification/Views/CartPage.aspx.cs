using Pattern_Software_Design_Qualification.Controllers;
using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        public List<Cart> Carts;
        public Boolean NoCart = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.LoginPage(Response);
                return;
            }
            if(!IsPostBack)
            {
                FetchData();
            }
        }
        public void FetchData()
        {
            User user = Auth.GetUser(Session);
            Response<List<Cart>> response = CartController.GetUserCart(user.UserID);
            if (!response.IsSuccess)
            {
                NoCart = true;
            }
            Carts = response.Payload;
            CartRepeater.DataSource = Carts;
            CartRepeater.DataBind();
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            String id = ((LinkButton)sender).CommandArgument.ToString();
            Response<Cart> response = CartController.DeleteCart(id);
            if (response.IsSuccess)
            {
                FetchData();
            }
        }

        protected void AddToOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderPage.aspx");
        }
    }
}