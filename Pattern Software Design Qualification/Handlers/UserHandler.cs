using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Factories;
using Pattern_Software_Design_Qualification.Models;
using Pattern_Software_Design_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Pattern_Software_Design_Qualification.Handlers
{
    public class UserHandler
    {
        private static DatabaseEntities db = Database.GetInstance();

        public static Response<User> LoginUser(String email, String password)
        {
            User user = UserRepository.GetUserByEmail(email);
            if (user == null)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Email does not exist",
                    Payload = null
                };
            }
            if (password != user.UserPassword)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Incorrect Password",
                    Payload = null
                };
            }
            return new Response<User>()
            {
                IsSuccess = true,
                Message = "Login Successful",
                Payload = user
            };
        }
        private static String GenerateID()
        {
            User user = UserRepository.GetLastUser();
            if (user == null)
            {
                return "US001";
            }
            String id = user.UserID.Substring(2);
            int lastID = Convert.ToInt32(id);
            lastID++;
            String newID = String.Format("US{0:000}", lastID);
            return newID;
        }
        public static Response<User> RegisterUser(String username, String email, String password, String phone, String address)
        {
            if (UserRepository.GetUserByUsername(username) != null)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Username taken!",
                    Payload = null
                };
            }
            if (UserRepository.GetUserByEmail(email) != null)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Email taken!",
                    Payload = null
                };
            }
            User user = UserFactory.CreateUser(GenerateID(), username, email, password, phone, address);
            UserRepository.CreateUser(user);
            return new Response<User>()
            {
                IsSuccess = true,
                Message = "Registered a new User",
                Payload = user
            };
        }
        public static Response<User> LoginByCookie(String cookie)
        {
            byte[] decryptedBytes = MachineKey.Unprotect(HttpServerUtility.UrlTokenDecode(cookie));
            string decryptedUserId = Encoding.UTF8.GetString(decryptedBytes);
            User user = UserRepository.GetUserByID(decryptedUserId);
            if (user == null)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Payload = null
                };
            }
            return new Response<User>()
            {
                IsSuccess = true,
                Message = "Logged in by cookie",
                Payload = user
            };
        }
    }
}