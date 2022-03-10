using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class Register
    {
        [Required(ErrorMessage = "не заполнен email")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]        
        public string Phone { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "неправильная длина")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
