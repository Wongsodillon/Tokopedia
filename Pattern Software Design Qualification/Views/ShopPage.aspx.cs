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
    public partial class ShopPage : System.Web.UI.Page
    {
        public List<Product> Products;
        public Shop shop;
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request["Id"];
            if (id == null)
            {
                Redirect.HomePage(Response);
            }
            Response<Shop> shopResponse = ShopController.GetShopByID(id);
            shop = shopResponse.Payload;
            if (shop.UserID == Auth.GetUser(Session).UserID)
            {
                Response.Redirect("~/Views/ManageProduct.aspx");
            }
            Response<List<Product>> productResponse = ProductController.GetProductByShopID(shop.ShopID);
            Products = productResponse.Payload;
        }
    }
}