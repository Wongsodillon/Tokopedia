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
    public partial class ProfilePage : System.Web.UI.Page
    {
        public User user;
        public Shop shop;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.HomePage(Response);
            }
            user = Auth.GetUser(Session);
            AddressField.Text = user.UserAddress;
            Response<Shop> response = ShopController.GetShopByUserID(user.UserID);
            shop = response.Payload;
            if (response.IsSuccess)
            {
                ShopPanel.Visible = true;
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Auth.RemoveCookie(Request, Response);
            Auth.RemoveSession(Session);
            Redirect.LoginPage(Response);
        }

        protected void ManageShopButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageProduct.aspx");
        }
    }
}