using System;
using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var role = (RoleViewModel)obj;
            return Name == role.Name;
        }
    }
}
