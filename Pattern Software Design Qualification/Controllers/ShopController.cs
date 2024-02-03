using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Controllers
{
    public class ShopController
    {
        public static Response<Shop> GetShopByUserID(String id)
        {
            return ShopHandler.GetShopByUserID(id);
        }
        public static Response<Shop> GetShopByID(String id)
        {
            return ShopHandler.GetShopByID(id);
        }
    }
}