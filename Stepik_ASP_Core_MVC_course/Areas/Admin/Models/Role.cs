using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
