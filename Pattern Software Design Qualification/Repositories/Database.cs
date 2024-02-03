using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pattern_Software_Design_Qualification.Repositories
{
    public class Database
    {
        private static DatabaseEntities instance = null;
        public static DatabaseEntities GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseEntities();
            }
            return instance;
        }
    }
}