using Pattern_Software_Design_Qualification.Controllers;
using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Layouts
{
    public partial class ShopHeader : System.Web.UI.MasterPage
    {
        public Shop shop = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.HomePage(Response);
            }
            User user = Auth.GetUser(Session);
            Response<Shop> shopResponse = ShopController.GetShopByUserID(user.UserID);
            if (!shopResponse.IsSuccess)
            {
                Redirect.HomePage(Response);
            }
            shop = shopResponse.Payload;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageProduct.aspx");
        }
    }
}