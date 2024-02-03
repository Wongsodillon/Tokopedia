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
    public partial class ManageProduct : System.Web.UI.Page
    {
        public List<Product> Products;
        public Shop shop;
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = Auth.GetUser(Session);
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.LoginPage(Response);
                return;
            }
            Response<Shop> shopResponse = ShopController.GetShopByUserID(user.UserID);
            if (!shopResponse.IsSuccess)
            {
                Redirect.HomePage(Response);
                return;
            }
            shop = shopResponse.Payload;
            FetchProduct();
        }
        public void FetchProduct()
        {
            Response<List<Product>> productResponse = ProductController.GetProductByShopID(shop.ShopID);
            Products = productResponse.Payload;
        }
        protected void BackProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void CreateProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CreateProduct.aspx");
        }
    }
}