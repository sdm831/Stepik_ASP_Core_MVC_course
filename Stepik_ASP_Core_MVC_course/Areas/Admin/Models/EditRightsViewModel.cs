using System.Collections.Generic;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Models
{
    public class EditRightsViewModel
    {
        public string UserName { get; set; }
        public List<RoleViewModel> UserRoles { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
    }
}
