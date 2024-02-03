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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        public List<Transaction> transactions;
        public User user;
        public Boolean NoTransaction;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Auth.IsLoggedIn(Session))
            {
                Redirect.LoginPage(Response);
                return;
            }
            FetchData();
        }
        public void FetchData()
        {
            user = Auth.GetUser(Session);
            Response<List<Transaction>> response = TransactionController.GetTransactionByUserID(user.UserID);
            if (!response.IsSuccess)
            {
                NoTransaction = true;
            }
            transactions = response.Payload;
        }
    }
}