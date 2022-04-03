using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using Stepik_ASP_Core_MVC_course.Helpers;
using Stepik_ASP_Core_MVC_course.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stepik_ASP_Core_MVC_course.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment appEnvironment;

        public ImagesProvider(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }

        public List<string> SafeFiles(IFormFile[] files, ImageFolders folder)
        {
            var imagesPaths = new List<string>();
            
            foreach (var file in files)
            {
                var imagePath = SafeFile(file, folder);
                imagesPaths.Add(imagePath);
            }
            
            return imagesPaths;
        }

        public string SafeFile(IFormFile file, ImageFolders folder)
        {
            if(file != null)
            {
                var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/" + folder);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                var path = Path.Combine(folderPath, fileName);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                
                return "/images/" + folder + "/" + fileName;
            }

            return null;
        }
    }
}
