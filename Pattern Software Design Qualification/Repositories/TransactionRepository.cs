using Pattern_Software_Design_Qualification.Factories;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Repositories
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = Database.GetInstance();
        public static Transaction CreateHeader(String userId, String address)
        {
            Transaction transaction = TransactionFactory.CreateTransaction(userId, address);
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return transaction;
        }
        public static TransactionDetail CreateDetail(String transactionId, String productId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionFactory.CreateTransactionDetail(transactionId, productId, quantity);
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
            return transactionDetail;
        }
        public static List<Transaction> GetTransactionByUserID(String userId)
        {
            return (from Transaction in db.Transactions where Transaction.UserID == userId select Transaction).ToList();
        }
        public static Transaction GetLastTransaction()
        {
            Transaction transaction = db.Transactions.ToList().LastOrDefault();
            return transaction;
        }
    }
}