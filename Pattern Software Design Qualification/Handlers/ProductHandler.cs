using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Factories;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Handlers
{
    public class ProductHandler
    {
        public static Response<List<Product>> GetProducts(User user)
        {
            List<Product> products = ProductRepository.GetProducts(user);
            return new Response<List<Product>>()
            {
                IsSuccess = true,
                Message = "Fetched products successful",
                Payload = products
            };
        } 
        public static Response<Product> GetProductByID(String id)
        {
            Product product = ProductRepository.GetProductByID(id);
            if (product == null)
            {
                return new Response<Product>()
                {
                    IsSuccess = false,
                    Message = "Product not found!",
                    Payload = null
                };
            }
            return new Response<Product>()
            {
                IsSuccess = true,
                Message = "Product Found",
                Payload = product
            };
        }
        public static Response<List<Product>> SearchProduct(String query, User user)
        {
            List<Product> products = ProductRepository.SearchProduct(query, user);
            if (products.Count == 0)
            {
                return new Response<List<Product>>()
                {
                    IsSuccess = true,
                    Message = "No Products Found",
                    Payload = products
                };
            }
            return new Response<List<Product>>()
            {
                IsSuccess = true,
                Message = "Search results for: " + query,
                Payload = products
            };
        }
        public static Response<List<Product>> GetProductByShopID(String shopID)
        {
            List<Product> products = ProductRepository.GetProductByShopID(shopID);
            return new Response<List<Product>>()
            {
                IsSuccess = true,
                Message = "Fetched Producted By ShopID Successful",
                Payload = products
            };
        }
        public static String GenerateID()
        {
            Product product = ProductRepository.GetLastProduct();
            String id = product.ProductID.Substring(2);
            int lastID = Convert.ToInt32(id);
            lastID++;
            String newID = String.Format("PR{0:000}", lastID);
            return newID;
        }
        public static Response<Product> CreateProduct(String shopId, String name, int price, int stock, FileUpload image, String desc, HttpServerUtility Server)
        {
            String productID = GenerateID();
            String imagePath = File.SaveFile(image, productID, Server);
            Product product = ProductFactory.CreateProduct(productID, shopId, name, desc, price, imagePath, stock);
            if (product == null)
            {
                return new Response<Product>()
                {
                    IsSuccess = false,
                    Message = "Failed to create product",
                    Payload = null
                };
            }
            ProductRepository.CreateProduct(product);
            return new Response<Product>()
            {
                IsSuccess = true,
                Message = "Created",
                Payload = product,
            };
        }
        public static Response<Product> UpdateProduct(String id, String name, int price, int stock, String desc)
        {
            Product product = ProductRepository.UpdateProduct(id, name, price, stock, desc);
            if (product == null)
            {
                return new Response<Product>()
                {
                    IsSuccess = false,
                    Message = "Failed to update product",
                    Payload = null
                };
            }
            return new Response<Product>()
            {
                IsSuccess = true,
                Message = "Updated Product",
                Payload = product
            };
        }
        public static Response<Product> RemoveProduct(String id, HttpServerUtility Server)
        {
            Product product = ProductRepository.GetProductByID(id);
            Boolean IsSuccess = ProductRepository.DeleteProduct(id);
            if (!IsSuccess)
            {
                return new Response<Product>()
                {
                    IsSuccess = false,
                    Message = "Product failed to delete",
                    Payload = null,
                };
            }
            File.RemoveFile(product.ProductImageUrl, Server);
            return new Response<Product>()
            {
                IsSuccess = true,
                Message = "Successfully Deleted a Product",
                Payload = product,
            };
        }
    }
}