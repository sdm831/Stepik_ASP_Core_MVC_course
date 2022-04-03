﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Models
{
    public class AddProductViewModel
    {        
        [Required]
        public string Name { get; set; }

        [Range(1, 1000000, ErrorMessage = "Цена должна быть от 1 до 1 000 000 руб.")]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile[] UploadedFiles { get; set; }
    }
}
