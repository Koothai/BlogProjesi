using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace BlogProjesi.Managers
{
    public static class FileManager
    {
        public static string GetUniqueNameAndSaveImageToDisk(this IFormFile imageFile, IWebHostEnvironment webHostEnvironment)
        {
            string uniqueFileName = default;
            if (imageFile is not null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public static void RemoveImageFromDisk(string imageName, IWebHostEnvironment webHostEnvironment)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, imageName);
                File.Delete(filePath);
            }
        }
    }
}
