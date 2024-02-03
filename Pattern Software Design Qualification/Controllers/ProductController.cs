using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Controllers
{
    public class ProductController
    {
        public static Response<List<Product>> GetProducts(User user)
        {
            return ProductHandler.GetProducts(user); 
        }
        public static Response<Product> GetProductByID(String id)
        {
            return ProductHandler.GetProductByID(id);
        }
        public static Response<List<Product>> SearchProduct(String query, User user)
        {
            return ProductHandler.SearchProduct(query, user);
        }
        public static Response<List<Product>> GetProductByShopID(String shopID)
        {
            return ProductHandler.GetProductByShopID(shopID);
        }
        public static Response<Product> CreateProduct(String shopId, String name, String price, String stock, FileUpload image, String desc, HttpServerUtility Server)
        {
            String Error = String.Empty;
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(desc) || String.IsNullOrEmpty(price) || String.IsNullOrEmpty(stock) || !image.HasFile)
            {
                Error = "Fill all fields!";
            }
            else if (Int32.Parse(price) <= 999)
            {
                Error = "Price must be at least 1000";
            }
            else if (Int32.Parse(stock) <= 0)
            {
                Error = "Stock must be at least 1";
            }
            else if (!File.CheckFileExtention(image))
            {
                Error = "Image File extension must be .png, .jpg, .jpeg or .jfif";
            }
            else if (!File.CheckFileSize(image))
            {
                Error = "Image File Size must be lower than 2MB";
            }
            if (Error != String.Empty)
            {
                return new Response<Product>()
                {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };
            }
            return ProductHandler.CreateProduct(shopId, name, Int32.Parse(price), Int32.Parse(stock), image, desc, Server);
        }
        public static Response<Product> UpdateProduct(String id, String name, String price, String stock, FileUpload image, String desc, HttpServerUtility Server)
        {
            String Error = String.Empty;
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(desc) || String.IsNullOrEmpty(price) || String.IsNullOrEmpty(stock))
            {
                Error = "Fill all fields!";
            }
            else if (Int32.Parse(price) <= 999)
            {
                Error = "Price must be at least 1000";
            }
            else if (Int32.Parse(stock) <= 0)
            {
                Error = "Stock must be at least 1";
            }
            else if (!File.CheckFileExtention(image) && image.HasFile)
            {
                Error = "Image File extension must be .png, .jpg, .jpeg or .jfif";
            }
            else if (!File.CheckFileSize(image))
            {
                Error = "Image File Size must be lower than 2MB";
            }
            if (Error != String.Empty)
            {
                return new Response<Product>()
                {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };
            }
            if (image.HasFile)
            {
                String imagePath = File.SaveFile(image, id, Server);
            }
            return ProductHandler.UpdateProduct(id, name, Int32.Parse(price), Int32.Parse(stock), desc);
        }
        public static Response<Product> DeleteProduct(String id, HttpServerUtility Server)
        {
            return ProductHandler.RemoveProduct(id, Server);
        }
    }
}