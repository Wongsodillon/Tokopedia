using Pattern_Software_Design_Qualification.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Facades
{
    public class Redirect
    {
        public static void HomePage(HttpResponse Response)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
        public static void LoginPage(HttpResponse Response)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
        public static void ManageProduct(HttpResponse Response)
        {
            Response.Redirect("~/Views/ManageProduct.aspx");
        }
    }
}