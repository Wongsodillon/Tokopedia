using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Factories
{
    public class CartFactory
    {
        public static Cart CreateCart(String id, String userId, String productId, int quantity)
        {
            Cart cart = new Cart()
            {
                CartID = id,
                UserID = userId,
                ProductID = productId,
                Quantity = quantity,
                DateAdded = DateTime.Now,
            };
            return cart;
        }
    }
}