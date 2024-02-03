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
    public partial class SearchPage : System.Web.UI.Page
    {
        public List<Product> Products;
        public String Message;
        protected void Page_Load(object sender, EventArgs e)
        {
            String query = Request["Search"];
            if (query == null)
            {
                Redirect.HomePage(Response);
            }
            User user = Auth.GetUser(Session);
            Response<List<Product>> response = ProductController.SearchProduct(query, user);
            Products = response.Payload;
            Message = response.Message;
            Debug.WriteLine(Products.Count);
            Debug.WriteLine(query);
        }
    }
}