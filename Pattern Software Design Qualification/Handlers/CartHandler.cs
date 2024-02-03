using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Factories;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Handlers
{
    public class CartHandler
    {
        public static String GenerateID()
        {
            Cart cart = CartRepository.GetLastCart();
            if (cart == null)
            {
                return "CR001";
            }
            String id = cart.CartID.Substring(2);
            int lastId = Convert.ToInt32(id);
            lastId++;
            String newID = String.Format("CR{0:000}", lastId);
            return newID;
        }
        public static Response<Cart> AddCart(String userId, String productId, int quantity)
        {
            if (CartRepository.GetProductCart(userId, productId) == null)
            {
                Cart cart = CartFactory.CreateCart(GenerateID(), userId, productId, quantity);
                CartRepository.AddCart(cart);
                return new Response<Cart>()
                {
                    IsSuccess = true,
                    Message = "Added to Cart",
                    Payload = cart
                };
            }
            else
            {
                Cart cart = CartRepository.UpdateQuantity(userId, productId, quantity);
                return new Response<Cart>()
                {
                    IsSuccess = true,
                    Message = "Updated Cart Quantity",
                    Payload = cart
                };
            }
        }
        public static Response<List<Cart>> GetUserCart(String userId)
        {
            List<Cart> carts = CartRepository.GetUserCart(userId);
            if (carts.Count == 0)
            {
                return new Response<List<Cart>>()
                {
                    IsSuccess = false,
                    Message = "No Products In Cart",
                    Payload = carts
                };
            }
            return new Response<List<Cart>>()
            {
                IsSuccess = true,
                Message = "Fetched User Cart",
                Payload = carts
            };
        }
        public static Response<Cart> DeleteCart(String id)
        {
            Boolean Success = CartRepository.DeleteCart(id);
            if (!Success)
            {
                return new Response<Cart>()
                {
                    IsSuccess = Success,
                    Message = "Failed to delete cart",
                    Payload = null
                };
            }
            return new Response<Cart>()
            {
                IsSuccess = Success,
                Message = "Deleted the cart",
                Payload = null,
            };
        }
        public static Response<List<Cart>> Checkout(String userId, String address)
        {
            List<Cart> carts = CartRepository.GetUserCart(userId);
            for (int i = 0; i < carts.Count; i++)
            {
                Cart cart = carts[i];
                if (cart.Quantity > cart.Product.ProductStock)
                {
                    return new Response<List<Cart>>()
                    {
                        IsSuccess = false,
                        Message = "Stock not enough",
                        Payload = null,
                    };
                }
            }
            carts = CartRepository.Checkout(userId, address);
            if (carts == null)
            {
                return new Response<List<Cart>>()
                {
                    IsSuccess = false,
                    Message = "Failed to checkout",
                    Payload = null
                };
            }
            return new Response<List<Cart>>()
            {
                IsSuccess = true,
                Message = "Check out",
                Payload = carts
            };
        }
    }
}