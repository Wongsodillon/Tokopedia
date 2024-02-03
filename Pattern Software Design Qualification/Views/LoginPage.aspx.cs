using Pattern_Software_Design_Qualification.Controllers;
using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Pattern_Software_Design_Qualification.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            if (Auth.GetUser(Session) != null || Auth.GetCookie(Request) != null)
            {
                Redirect.HomePage(Response);
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String email = EmailField.Text;
            String password = PasswordField.Text;
            Response<User> response = UserController.LoginUser(email, password);
            if(!response.IsSuccess)
            {
                ErrorLabel.Text = response.Message;
                ErrorLabel.Visible = true;
                return;
            }
            if (rememberBox.Checked)
            {
                Auth.SetCookie(Response, response.Payload.UserID);
            }
            Auth.SetUser(Session, response.Payload);
            Redirect.HomePage(Response);
        }
    }
}