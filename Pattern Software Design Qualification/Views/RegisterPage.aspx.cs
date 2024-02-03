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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {

            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            String username = UsernameField.Text;
            String email = EmailField.Text;
            String password = PasswordField.Text;
            String confirm = ConfirmField.Text;
            String phone = PhoneField.Text;
            String address = AddressField.Text;
            Response<User> response = UserController.RegisterUser(username, email, password, confirm, phone, address);
            if (!response.IsSuccess)
            {
                ErrorLabel.Text = response.Message;
                ErrorLabel.Visible = true;
                return;
            }
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}