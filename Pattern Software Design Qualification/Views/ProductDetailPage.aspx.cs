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
    public partial class ProductDetailPage : System.Web.UI.Page
    {
        public Product product = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            String productID = Request["Id"];
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.LoginPage(Response);
            }
            Response<Product> response = ProductController.GetProductByID(productID);
            if (!response.IsSuccess)
            {
                Redirect.HomePage(Response);
                return;
            }
            product = response.Payload;
            if (!Auth.IsProductOwner(Session, product)) 
            {
                Label.Visible = true;
                QuantityField.Visible = true;
                AddToCartButton.Visible = true;
            }
            else
            {
                EditButton.Visible = true;
                DeleteButton.Visible = true;
            }
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            QuantityField.Text = "1";
        }

        protected void AddCartButton_Click(object sender, EventArgs e)
        {
            String qty = QuantityField.Text;
            String userId = Auth.GetUser(Session).UserID;
            String productId = Request["Id"];
            Response<Cart> response = CartController.AddCart(userId, productId, qty);
            if (!response.IsSuccess)
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
            }
            else ErrorLabel.ForeColor = System.Drawing.Color.Green;
            ErrorLabel.Text = response.Message;
            ErrorLabel.Visible = true;
        }

        protected void ViewShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ShopPage.aspx?Id="+product.ShopID);
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProduct.aspx?Id=" + product.ProductID);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/DeleteProduct.aspx?Id=" + product.ProductID);
        }
    }
}