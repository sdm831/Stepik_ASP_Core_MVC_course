using System;
using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Models
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
