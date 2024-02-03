using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Controllers
{
    public class CartController
    {
        public static Response<Cart> AddCart(String userId, String productId, String qty)
        {
            int quantity = Int32.Parse(qty);
            if (quantity == 0)
            {
                return new Response<Cart>()
                {
                    IsSuccess = false,
                    Message = "Invalid Quantity",
                    Payload = null
                };
            }
            return CartHandler.AddCart(userId, productId, quantity);
        }
        public static Response<List<Cart>> GetUserCart(String userId)
        {
            return CartHandler.GetUserCart(userId);
        }
        public static Response<Cart> DeleteCart(String id)
        {
            return CartHandler.DeleteCart(id);
        }
        public static Response<List<Cart>> Checkout(String userId, String address)
        {
            return CartHandler.Checkout(userId, address);
        }
    }

}