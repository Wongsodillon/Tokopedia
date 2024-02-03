using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Repositories
{
    public class CartRepository
    {
        private static DatabaseEntities db = Database.GetInstance();
        public static void AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
            return;
        }
        public static List<Cart> GetUserCart(String userId)
        {
            List<Cart> carts = db.Carts.Where(c => c.UserID == userId).ToList();
            return carts;
        }
        public static Cart GetProductCart(String userId, String productId)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.ProductID == productId);
            return cart;
        }
        public static Cart UpdateQuantity(String userId, String productId, int quantity)
        {
            Cart cart = GetProductCart(userId, productId);
            cart.Quantity += quantity;
            db.SaveChanges();
            return cart;
        }
        public static Cart GetLastCart()
        {
            Cart cart = db.Carts.ToList().LastOrDefault();
            return cart;
        }
        public static Boolean DeleteCart(String id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return false;
            }
            db.Carts.Remove(cart);
            db.SaveChanges();
            return true;
        }
        public static List<Cart> Checkout(String userId, String address)
        {
            List<Cart> Carts = GetUserCart(userId);
            if (Carts == null)
            {
                return null;
            }
            Transaction newTransaction = TransactionRepository.CreateHeader(userId, address);
            for (int i = 0; i < Carts.Count; i++)
            {
                Cart cart = Carts[i];
                TransactionRepository.CreateDetail(newTransaction.TransactionID, cart.Product.ProductID, cart.Quantity);
                ProductRepository.UpdateStock(cart.Product.ProductID, cart.Quantity);
                DeleteCart(cart.CartID);
            }
            return Carts;
        }
    }
}