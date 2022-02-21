using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,
        
        [Display(Name = "Обработан")] 
        Processed,
        
        [Display(Name = "Отправлен")] 
        Delivering,

        [Display(Name = "Доставлен")] 
        Delivered,

        [Display(Name = "Отменен")] 
        Canceled
    }
}