using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Models
{
    public class ChangePassword
    {        
        public string UserName  { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "неправильная длина")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
