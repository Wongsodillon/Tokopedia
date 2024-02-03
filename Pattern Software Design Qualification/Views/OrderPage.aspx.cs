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
    public partial class OrderPage : System.Web.UI.Page
    {
        public List<Cart> Carts;
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.LoginPage(Response);
                return;
            }
            FetchData();
        }
        public void FetchData()
        {
            user = Auth.GetUser(Session);
            Response<List<Cart>> response = CartController.GetUserCart(user.UserID);
            if (!response.IsSuccess)
            {
                Redirect.HomePage(Response);
                return;
            }
            List<Cart> payload = response.Payload;
            Carts = payload;
            AddressField.Text = user.UserAddress;
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            String address = AddressField.Text;

            Response<List<Cart>> response = CartController.Checkout(user.UserID, address);
            if (!response.IsSuccess)
            {
                Redirect.HomePage(Response);
            }
            else
            {
                Redirect.HomePage(Response);
            }
        }
    }
}