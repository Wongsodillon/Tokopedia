using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Repositories
{
    public class ProductRepository
    {
        private static DatabaseEntities db = Database.GetInstance();
        public static List<Product> GetProducts(User user)
        {
            List<Product> products;
            Shop shop = db.Shops.FirstOrDefault(s => s.UserID == user.UserID);
            if (shop == null)
            {
                products = db.Products.ToList();
            }
            else
            {
                products = db.Products.Where(p => p.ShopID != shop.ShopID).ToList();
            }
            return products;
        }
        public static Product GetProductByID(String id)
        {
            Product product = db.Products.Find(id);
            return product;
        }
        public static List<Product> SearchProduct(String query, User user)
        {
            Shop shop = db.Shops.FirstOrDefault(s => s.UserID == user.UserID);
            List<Product> products;
            if (shop == null)
            {
                products = db.Products.Where(p => p.ProductName.Contains(query.ToLower())).ToList();
            }
            else
            {
                products = db.Products.Where(p => p.ProductName.Contains(query.ToLower()) && p.ShopID != shop.ShopID).ToList();
            }
            return products;
        }
        public static List<Product> GetProductByShopID(String shopId)
        {
            List<Product> products = db.Products.Where(p => p.ShopID == shopId).ToList();
            return products;
        }
        public static void CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return;
        }
        public static Product GetLastProduct()
        {
            Product product = db.Products.ToList().LastOrDefault();
            return product;
        }
        public static Product UpdateProduct(String id, String name, int price, int stock, String desc)
        {
            Product product = db.Products.Find(id);
            product.ProductName = name;
            product.ProductPrice = price;
            product.ProductStock = stock;
            product.ProductDescription = desc;
            db.SaveChanges();
            return product;
        }
        public static Boolean DeleteProduct(String id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return true;
        }
        public static void UpdateStock(String id, int purchased)
        {
            Product product = db.Products.Find(id);
            product.ProductStock -= purchased;
            db.SaveChanges();
        }
    }
}