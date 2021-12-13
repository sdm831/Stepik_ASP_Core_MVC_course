using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
