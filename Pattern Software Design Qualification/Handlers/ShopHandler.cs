using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Handlers
{
    public class ShopHandler
    {
        public static Response<Shop> GetShopByUserID(String id)
        {
            Shop shop = ShopRepository.GetShopByUserID(id);
            if (shop == null)
            {
                return new Response<Shop>()
                {
                    IsSuccess = false,
                    Message = "Shop Not Found!",
                    Payload = null
                };
            }
            return new Response<Shop>()
            {
                IsSuccess = true,
                Message = "Shop Found!",
                Payload = shop
            };
        } 
        public static Response<Shop> GetShopByID(String id)
        {
            Shop shop = ShopRepository.GetShopByID(id);
            if (shop == null)
            {
                return new Response<Shop>()
                {
                    IsSuccess = false,
                    Message = "Shop Not Found!",
                    Payload = null
                };
            }
            return new Response<Shop>()
            {
                IsSuccess = true,
                Message = "Shop Found!",
                Payload = shop
            };
        }
    }
}