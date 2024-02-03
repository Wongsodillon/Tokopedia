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
    public partial class CreateProduct : System.Web.UI.Page
    {
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
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            String name = NameField.Text;
            String price = PriceField.Text;
            String stock = StockField.Text;
            FileUpload image = ImageField;
            String desc = DescField.Text;
            Response<Product> response = ProductController.CreateProduct(shop.ShopID, name, price, stock, image, desc, Server);
            if (!response.IsSuccess)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = response.Message;
            }
            else Response.Redirect("~/Views/ManageProduct.aspx");
        }
    }
}