using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Handlers
{
    public class TransactionHandler
    {
        public static Response<List<Transaction>> GetTransactionByUserID(String userId)
        {
            List<Transaction> transactions = TransactionRepository.GetTransactionByUserID(userId);
            if (transactions.Count == 0)
            {
                return new Response<List<Transaction>>()
                {
                    IsSuccess = false,
                    Message = "No transactions yet",
                    Payload = null
                };
            }
            return new Response<List<Transaction>>()
            {
                IsSuccess = true,
                Message = "Fetched Transactions",
                Payload = transactions
            };
        }
        public static String GenerateID()
        {
            Transaction transaction = TransactionRepository.GetLastTransaction();
            if (transaction == null)
            {
                return "TR001";
            }
            String id = transaction.TransactionID.Substring(2);
            int lastID = Int32.Parse(id);
            lastID++;
            String newID = String.Format("TR{0:000}", lastID);
            return newID;
        }
    }
}