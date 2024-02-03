using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Controllers
{
    public class TransactionController
    {
        public static Response<List<Transaction>> GetTransactionByUserID(String userId)
        {
            return TransactionHandler.GetTransactionByUserID(userId);
        }
    }
}