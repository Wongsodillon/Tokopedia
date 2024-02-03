using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Factories
{
    public class ShopFactory
    {
        public static Shop CreateShop(String shopId, String shopName, String userId)
        {
            Shop shop = new Shop()
            {
                ShopID = shopId,
                ShopName = shopName,
                UserID = userId
            };
            return shop;
        }
    }
}