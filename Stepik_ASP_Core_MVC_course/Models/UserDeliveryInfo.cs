using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class UserDeliveryInfo
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPhone { get; set; }
        [Required]
        public string UserAdress { get; set; }
    }
}
