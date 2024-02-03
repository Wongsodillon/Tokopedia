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
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session) && !Auth.HasCookie(Request))
            {
                Redirect.LoginPage(Response);
                return;
            }
            if (!Auth.IsLoggedIn(Session))
            {
                String cookie = Request.Cookies["user_cookie"].Value;
                Response<User> response = UserController.LoginByCookie(cookie);
                if (!response.IsSuccess)
                {
                    Auth.RemoveCookie(Request, Response);
                    Redirect.LoginPage(Response);
                    return;
                }
                else
                {
                    Auth.SetUser(Session, response.Payload);
                }
            }
            User user = Auth.GetUser(Session);
            ProfileButton.Text = user.Username;
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            String query = SearchField.Text;
            if (query.Length == 0)
            {
                Redirect.HomePage(Response);
            }
            Response.Redirect("~/Views/SearchPage.aspx?Search=" + query);
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Redirect.HomePage(Response);
        }

        protected void CartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CartPage.aspx");
        }

        protected void HistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }
    }
}