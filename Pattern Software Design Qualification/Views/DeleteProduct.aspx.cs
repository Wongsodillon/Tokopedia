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
    public partial class DeleteProduct : System.Web.UI.Page
    {
        public Product product = null;
        String id;
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
            id = Request["Id"];
            Response<Product> response = ProductController.GetProductByID(id);
            if (!response.IsSuccess || response.Payload.ShopID != shopResponse.Payload.ShopID)
            {
                Redirect.ManageProduct(Response);
                return;
            }
            product = response.Payload;
            ProductImage.ImageUrl = product.ProductImageUrl;
            NameLabel.Text = product.ProductName;
            PriceLabel.Text = "Rp. " + product.ProductPrice.ToString();
            DescLabel.Text = product.ProductDescription;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Response<Product> response = ProductController.DeleteProduct(id, Server);
            if (response.IsSuccess)
            {
                Redirect.ManageProduct(Response);
            }
        }
    }
}