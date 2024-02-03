using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Factories
{
    public class ProductFactory
    {
        public static Product CreateProduct(String id, String shopId, String name, String desc, int price, String url, int stock)
        {
            Product product = new Product()
            {
                ProductID = id,
                ShopID = shopId,
                ProductName = name,
                ProductDescription = desc,
                ProductPrice = price,
                ProductImageUrl = url, 
                ProductStock = stock
            };
            return product;
        }
    }
}