using Pattern_Software_Design_Qualification.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using IOFile = System.IO.File;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pattern_Software_Design_Qualification.Facades
{
    public class File
    {
        private static String filePath = "~/Assets/Products/";
        public static string SaveFile(FileUpload FileImage, String fileName, HttpServerUtility Server)
        {
            string ImagePath = filePath + fileName + Path.GetExtension(FileImage.FileName).ToLower();
            if (IOFile.Exists(ImagePath))
            {
                IOFile.Delete(ImagePath);
            }
            FileImage.SaveAs(Server.MapPath(ImagePath));

            return ImagePath.Substring(1);
        }
        public static void RemoveFile(String imagePath, HttpServerUtility Server)
        {
            // TODO
            String fullPath = Server.MapPath(imagePath);
            if (IOFile.Exists(imagePath))
            {
                IOFile.Delete(fullPath);
            }
        }
        public static bool CheckFileExtention(FileUpload fileUpload)
        {
            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif"};

            if (!allowedExtensions.Contains(fileExtension)) return false;
            else return true;

        }
        public static bool CheckFileSize(FileUpload fileUpload)
        {
            if (fileUpload.PostedFile.ContentLength >= 2 * 1024 * 1024) return false;
            else return true;
        }

    }
}