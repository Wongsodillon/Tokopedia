using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Factories
{
    public class UserFactory
    {
        public static User CreateUser(String id, String username, String email, String password, String phone, String address)
        {
            User user = new User()
            {
                UserID = id,
                Username = username,
                UserEmail = email,
                UserPassword = password,
                UserPhoneNumber = phone,
                UserAddress = address
            };
            return user;
        }
    }
}