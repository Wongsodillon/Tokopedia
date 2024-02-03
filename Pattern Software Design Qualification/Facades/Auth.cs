using Pattern_Software_Design_Qualification.Controllers;
using Pattern_Software_Design_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Pattern_Software_Design_Qualification.Facades
{
    public class Auth
    {
        public static String KEY = "user";
        public static String COOKIE_KEY = "user_cookie";
        public static void SetUser(HttpSessionState Session, User user)
        {
            Session[KEY] = user;
        }
        public static void SetCookie(HttpResponse response, String userID)
        {
            HttpCookie cookie = new HttpCookie(COOKIE_KEY);
            byte[] encryptedBytes = MachineKey.Protect(Encoding.UTF8.GetBytes(userID));
            string encryptedValue = HttpServerUtility.UrlTokenEncode(encryptedBytes);
            cookie.Value = encryptedValue;
            cookie.Expires = DateTime.Now.AddHours(24);
            response.Cookies.Add(cookie);
        }
        public static Boolean IsProductOwner(HttpSessionState Session, Product product)
        {
            User user = GetUser(Session);
            Response<Shop> response = ShopController.GetShopByUserID(user.UserID);
            if (!response.IsSuccess)
            {
                return false;
            }
            if (response.Payload.ShopID == product.ShopID)
            {
                return true;
            }
            else return false;
        }
        public static User GetUser(HttpSessionState Session)
        {
            User user = Session[KEY] as User;
            return user;
        }
        public static HttpCookie GetCookie(HttpRequest request)
        {
            HttpCookie cookie = request.Cookies["user_cookie"];
            return cookie;
        }
        public static String GetCookieValue(HttpRequest request)
        {
            String cookieValue = GetCookie(request).Value;
            return cookieValue;
        }
        public static bool IsLoggedIn(HttpSessionState Session)
        {
            return Session[KEY] != null;
        }
        public static bool HasCookie(HttpRequest request)
        {
            HttpCookie cookie = GetCookie(request);
            return cookie != null;
        }
        public static void RemoveSession(HttpSessionState Session)
        {
            Session.Clear();
        }
        public static void RemoveCookie(HttpRequest request, HttpResponse response)
        {
            HttpCookie cookie = GetCookie(request);
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                response.Cookies.Add(cookie);
            }

        }
    }
}