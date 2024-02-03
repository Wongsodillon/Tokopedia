using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Factories
{
    public class TransactionFactory
    {
        public static Transaction CreateTransaction(String userId, String address)
        {
            String id = TransactionHandler.GenerateID();
            Transaction transaction = new Transaction()
            {
                TransactionID = id,
                UserID = userId,
                TransactionDate = DateTime.Now,
                TransactionAddress = address
            };
            return transaction;
        }
        public static TransactionDetail CreateTransactionDetail(String transactionId, String productId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionId,
                ProductID = productId,
                Quantity = quantity
            };
            return transactionDetail;
        }
    }
}