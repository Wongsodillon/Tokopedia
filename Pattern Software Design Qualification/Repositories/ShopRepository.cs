using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Repositories
{
    public class ShopRepository
    {
        private static DatabaseEntities db = Database.GetInstance();
        public static Shop GetShopByUserID(String userId)
        {
            Shop shop = db.Shops.Where(s => s.UserID == userId).FirstOrDefault();
            return shop;
        }
        public static Shop GetShopByID(String id)
        {
            Shop shop = db.Shops.Find(id);
            return shop;
        }
        public static void CreateShop(Shop shop)
        {
            db.Shops.Add(shop);
            db.SaveChanges();
            return;
        }
    }
}