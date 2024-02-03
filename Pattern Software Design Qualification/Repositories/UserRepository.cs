using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Repositories
{
    public class UserRepository
    {
        private static DatabaseEntities db = Database.GetInstance();
        public static User GetUserByID(String id)
        {
            User user = db.Users.Find(id);
            return user;
        }
        public static User GetUserByEmail(String email)
        {
            User user = db.Users.Where(u => u.UserEmail == email).FirstOrDefault();
            return user;
        }
        public static User GetLastUser()
        {
            User user = db.Users.ToList().LastOrDefault();
            return user;
        }
        public static User GetUserByUsername(String username)
        {
            User user = db.Users.Where(u => u.Username == username).FirstOrDefault();
            return user;
        }
        public static void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return;
        }
    }
}