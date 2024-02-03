using Pattern_Software_Design_Qualification.Facades;
using Pattern_Software_Design_Qualification.Handlers;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Pattern_Software_Design_Qualification.Controllers
{
    public class UserController
    {
        public static Response<User> LoginUser(String email, String password)
        {
            if (email.Length == 0 || password.Length == 0)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Please fill all fields!",
                    Payload = null
                };
            }
            return UserHandler.LoginUser(email, password);
        }
        private static Boolean IsAlphanumeric(String password)
        {
            Regex alphanumericRegex = new Regex("^(?=.*[a-zA-Z])(?=.*[0-9])");

            return alphanumericRegex.IsMatch(password);
        }
        private static Boolean IsValidEmail(String email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static Response<User> RegisterUser(String username, String email, String password, String confirmPassword, String phone, String address)
        {
            if (username.Length == 0 || email.Length == 0 || password.Length == 0 || confirmPassword.Length == 0 || phone.Length == 0 || address.Length == 0)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Please fill all fields!",
                    Payload = null
                };
            }
            if (!IsValidEmail(email))
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Invalid Email!",
                    Payload = null
                };
            }
            if (password != confirmPassword)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Confirm password is not the same!",
                    Payload = null
                };
            }
            if (password.Length < 8)
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Password must be at least 8 characters!",
                    Payload = null
                };
            }
            if (!IsAlphanumeric(password))
            {
                return new Response<User>()
                {
                    IsSuccess = false,
                    Message = "Password must be alphanumeric!",
                    Payload = null
                };
            }
            return UserHandler.RegisterUser(username, email, password, phone, address);
        }
        public static Response<User> LoginByCookie(String cookie)
        {
            return UserHandler.LoginByCookie(cookie);
        }
    }
}